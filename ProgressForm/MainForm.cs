using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProgressSharp;
using ProgressSharp.Enums;
using ProgressSharp.GameClasses;
using ProgressSharp.Helpers;
using ProgressSharp.Player;

namespace ProgressForm
{
    public partial class MainForm : Form
    {
        public Simulation Simulation;
        public Timer Timer = new Timer();
        public int IntervalMs = 100;

        public bool AllowSelection;

        public MainForm(Player player)
        {
            InitializeComponent();

            Simulation = new Simulation(player);
        }

        internal void Setup()
        {
            ConfigDataGrid(dataInfo);
            AddTextColumn(dataInfo, "Trait");
            AddTextColumn(dataInfo, "Value");
            SetColumnWidth(dataInfo, "Trait", 50);
            SetColumnWidth(dataInfo, "Value", 147);

            ConfigDataGrid(dataStats);
            AddTextColumn(dataStats, "Stat");
            AddTextColumn(dataStats, "Value");
            SetColumnWidth(dataStats, "Stat", 50);
            SetColumnWidth(dataStats, "Value", 147);

            ConfigDataGrid(dataSpells);
            AddTextColumn(dataSpells, "Spell");
            AddTextColumn(dataSpells, "Level");
            SetColumnWidth(dataSpells, "Spell", 98);
            SetColumnWidth(dataSpells, "Level", 98);

            ConfigDataGrid(dataEquipment);
            AddTextColumn(dataEquipment, "Type");
            AddTextColumn(dataEquipment, "Equiped");
            dataEquipment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataEquipment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ConfigDataGrid(dataInventory);
            AddTextColumn(dataInventory, "Item");
            AddTextColumn(dataInventory, "Qty");
            dataInventory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataInventory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataInventory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ConfigDataGrid(dataPlot);
            AddCheckDataGrid(dataPlot, "Check");
            AddTextColumn(dataPlot, "Act");
            SetColumnWidth(dataPlot, "Check", 20);
            SetColumnWidth(dataPlot, "Act", 177);

            dataPlot.ColumnHeadersVisible = false;

            ConfigDataGrid(dataQuests);
            AddCheckDataGrid(dataQuests, "Check");
            AddTextColumn(dataQuests, "Act");
            SetColumnWidth(dataQuests, "Check", 20);
            SetColumnWidth(dataQuests, "Act", 177);

            dataQuests.ColumnHeadersVisible = false;

            PopulateGrids();

            Simulation.Player.LeveledUp += Player_LeveledUp;

            Simulation.Player.NewTask += Player_NewTask;

            Simulation.Player.Stats.StatsChanged += Player_StatsChanged;

            Simulation.Player.SpellBook.SpellAdded += Spell_Added;
            Simulation.Player.SpellBook.SpellChanged += Spell_Changed;

            Simulation.Player.Equipment.EquipmentChanged += Equipment_Changed;
            
            Simulation.Player.Inventory.GoldChanged += Gold_Changed;
            Simulation.Player.Inventory.ItemAdded += Item_Added;
            Simulation.Player.Inventory.ItemChanged += Item_Changed;
            Simulation.Player.Inventory.ItemRemoved += Item_Removed;

            Simulation.Player.QuestBook.StartAct += Start_Act;

            Simulation.Player.QuestBook.NewQuest += Quest_New;
            Simulation.Player.QuestBook.RemoveQuest += Quest_Remove;

            Simulation.Player.ExpBar.ProgressChanged += ExpBar_ProgressChanged;
            Simulation.Player.Inventory.EncumBar.ProgressChanged += Encumberance_ProgressChanged;
            Simulation.Player.QuestBook.PlotBar.ProgressChanged += Plot_ProgressChanged;
            Simulation.Player.QuestBook.QuestBar.ProgressChanged += Quest_ProgressChanged;
            Simulation.Player.TaskBar.ProgressChanged += TaskBar_ProgressChanged;

            Timer.Interval = IntervalMs;
            Timer.Tick += Timer_Tick;
            Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Simulation.Tick(IntervalMs);
        }

        private void Player_LeveledUp(object sender, EventArgs args)
        {
            UpdateGrid(dataInfo, "Level", Simulation.Player.Level.ToString(), false);
        }

        private void Player_NewTask(object sender, EventArgs args)
        {
            lblTask.Text = Simulation.Player.CurrentTask.Description;
            progressTask.Value = 0;
            progressTask.Maximum = Simulation.Player.CurrentTask.Duration;
        }

        private void Player_StatsChanged(object sender, StatsArgs e)
        {
            SetStats();
        }

        private void Spell_Added(object sender, SpellArgs args)
        {
            var spell = args.PlayerSpell;
            var roman = Roman.ToRoman(spell.Level);

            UpdateGrid(dataSpells, spell.Name, roman, true);
        }

        private void Spell_Changed(object sender, SpellArgs args)
        {
            var spell = args.PlayerSpell;
            var roman = Roman.ToRoman(spell.Level);

            UpdateGrid(dataSpells, spell.Name, roman, false);
        }

        private void Equipment_Changed(object sender, EquipmentArgs args)
        {
            var type = $"{args.Type:G}";
            var val = args.Item;

            UpdateGrid(dataEquipment, type, val, false);
        }

        private void Gold_Changed(object sender, EventArgs e)
        {
            UpdateGrid(dataInventory, "Gold", $"{Simulation.Player.Inventory.Gold}", false);
        }

        private void Item_Added(object sender, InventoryArgs args)
        {
            var item = args.Item;
            UpdateGrid(dataInventory, item.Name, $"{item.Quantity}", true);
        }

        private void Item_Changed(object sender, InventoryArgs args)
        {
            var item = args.Item;
            UpdateGrid(dataInventory, item.Name, $"{item.Quantity}", false);
        }

        private void Item_Removed(object sender, InventoryArgs args)
        {
            var item = args.Item;
            RemoveRow(dataInventory, item.Name);

            AllowSelection = true;
            dataPlot.FirstDisplayedScrollingRowIndex = 0;
            AllowSelection = false;
        }

        private void Start_Act(object sender, QuestArgs args)
        {
            var actName = $"Act {Roman.ToRoman(Simulation.Player.QuestBook.Act)}";

            foreach (DataGridViewRow row in dataPlot.Rows)
            {
                row.Cells[0].Value = true;
            }

            var index = dataPlot.Rows.Add(false, actName);
            dataPlot.FirstDisplayedScrollingRowIndex = index;
        }

        private void Quest_New(object sender, QuestArgs args)
        {
            var newQuest = args.Name;

            foreach (DataGridViewRow row in dataQuests.Rows)
            {
                row.Cells[0].Value = true;
            }

            var index = dataQuests.Rows.Add(false, newQuest);
            dataQuests.FirstDisplayedScrollingRowIndex = index;
        }

        private void Quest_Remove(object sender, QuestArgs args)
        {
            RemoveRow(dataQuests, args.Name);
        }

        private void ExpBar_ProgressChanged(object sender, ProgressArgs args)
        {
            progressExperience.Maximum = Simulation.Player.ExpBar.Max;
            progressExperience.Value = (int) Simulation.Player.ExpBar.Position;
        }

        private void Encumberance_ProgressChanged(object sender, ProgressArgs args)
        {
            progressInventory.Maximum = Simulation.Player.Inventory.EncumBar.Max;
            progressInventory.Value = (int) Simulation.Player.Inventory.EncumBar.Position;
        }

        private void Plot_ProgressChanged(object sender, ProgressArgs args)
        {
            progressPlot.Maximum = Simulation.Player.QuestBook.PlotBar.Max;
            progressPlot.Value = (int) Simulation.Player.QuestBook.PlotBar.Position;
        }

        private void Quest_ProgressChanged(object sender, ProgressArgs args)
        {
            progressQuest.Maximum = Simulation.Player.QuestBook.QuestBar.Max;
            progressQuest.Value = (int) Simulation.Player.QuestBook.QuestBar.Position;
        }

        private void TaskBar_ProgressChanged(object sender, ProgressArgs args)
        {
            if (Simulation.Player.CurrentTask.Duration == 0) return;
            progressTask.Maximum = Simulation.Player.CurrentTask.Duration;
            progressTask.Value = (int) Simulation.Player.Elapsed;
        }

        private static void UpdateGrid(DataGridView grid, string rowName, string newVal, bool scrollToRow)
        {
            DataGridViewRow selectedRow = null;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[0].Value.ToString() != rowName) continue;
                row.Cells[1].Value = newVal;
                selectedRow = row;
                break;
            }

            var index = selectedRow?.Index ?? grid.Rows.Add(rowName, newVal);

            if (scrollToRow)
            {
                grid.FirstDisplayedScrollingRowIndex = index;
            }
        }

        private static void RemoveRow(DataGridView grid, string rowName)
        {
            var index = -1;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[0].Value.ToString() != rowName) continue;
                index = row.Index;
                break;
            }

            if (index < 0) return;
            grid.Rows.RemoveAt(index);
        }

        private void PopulateGrids()
        {
            NewGridRow(dataInfo, new[] {"Name", Simulation.Player.Name});
            NewGridRow(dataInfo, new[] {"Race", Simulation.Player.Race.Name});
            NewGridRow(dataInfo, new[] {"Class", Simulation.Player.Klass.Name});
            NewGridRow(dataInfo, new[] {"Level", Simulation.Player.Level.ToString()});

            SetStats();

            foreach(EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
            {
                NewGridRow(dataEquipment, new[] {$"{type:G}", Simulation.Player.Equipment.GetItem(type)});
            }

            NewGridRow(dataInventory, new[] {"Gold", Simulation.Player.Inventory.Gold.ToString()});
        }

        public void SetStats()
        {
            UpdateGrid(dataStats, "STR", $"{Simulation.Player.Stats[StatType.Strength]}", false);
            UpdateGrid(dataStats, "CON", $"{Simulation.Player.Stats[StatType.Condition]}", false);
            UpdateGrid(dataStats, "DEX", $"{Simulation.Player.Stats[StatType.Dexterity]}", false);
            UpdateGrid(dataStats, "INT", $"{Simulation.Player.Stats[StatType.Intelligence]}", false);
            UpdateGrid(dataStats, "WIS", $"{Simulation.Player.Stats[StatType.Wisdom]}", false);
            UpdateGrid(dataStats, "CHA", $"{Simulation.Player.Stats[StatType.Charisma]}", false);
            UpdateGrid(dataStats, "HP Max", $"{Simulation.Player.Stats[StatType.HpMax]}", false);
            UpdateGrid(dataStats, "MP Max", $"{Simulation.Player.Stats[StatType.MpMax]}", false);
        }

        private static void NewGridRow(DataGridView dataGrid, IReadOnlyList<string> objects)
        {
            dataGrid.Rows.Add(objects[0], objects[1]);
        }

        private void ConfigDataGrid(DataGridView dataGrid)
        {
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.Font = new Font(dataGrid.Font.FontFamily, dataGrid.Font.Size - 1);
            dataGrid.RowTemplate.Height = 18;
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGrid.SelectionChanged += DataGrid_ClearSelection;
            dataGrid.BackgroundColor = Color.White;
            dataGrid.BorderStyle = BorderStyle.Fixed3D;
        }

        private void DataGrid_ClearSelection(object sender, EventArgs e)
        {
            if (AllowSelection) return;
            var dataGrid = (DataGridView) sender;
            dataGrid.ClearSelection();
        }

        private static void AddTextColumn(DataGridView dataGrid, string name)
        {
            dataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = name,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private static void AddCheckDataGrid(DataGridView dataGrid, string name)
        {
            dataGrid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = name,
                HeaderText = name,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private static void SetColumnWidth(DataGridView dataGrid, string name, int width)
        {
            if (dataGrid == null) return;
            if (string.IsNullOrEmpty(name)) return;
            dataGrid.Columns[name].Width = width;
        }
    }
}
