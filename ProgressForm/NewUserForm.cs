using System;
using System.Linq;
using System.Windows.Forms;
using ProgressSharp.Character;
using ProgressSharp.Enums;
using ProgressSharp.Extensions;
using ProgressSharp.GameClasses;
using ProgressSharp.Player;

namespace ProgressForm
{
    public partial class NewUserForm : Form
    {
        public string PlayerName = string.Empty;
        public Stats PlayerStats = null;
        public Race PlayerRace = null;
        public Klass PlayerKlass = null;

        public bool Cancel = true;

        private readonly StatsBuilder _builder = new StatsBuilder();

        public NewUserForm()
        {
            InitializeComponent();
        }

        private void Setup()
        {
            btnRoll.Click += btnRoll_Click;
            btnSold.Click += btnSold_Click;
        }

        private void NewUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSold_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            RollStats();
        }

        private void RollStats()
        {
            var stats = _builder.Roll();
            LoadStats(stats);
        }

        private void LoadStats(Stats stats)
        {
            PlayerStats = stats;

            txtStr.Text = stats[StatType.Strength].ToString();
            txtCon.Text = stats[StatType.Condition].ToString();
            txtDex.Text = stats[StatType.Dexterity].ToString();
            txtInt.Text = stats[StatType.Intelligence].ToString();
            txtWis.Text = stats[StatType.Wisdom].ToString();
            txtCha.Text = stats[StatType.Charisma].ToString();

            var primeStats = EnumExtensions.PrimeStats();

            var total = stats.Where(i => primeStats.Contains(i.Key))
                .Select(i => i.Value)
                .Sum();

            txtTotal.Text = total.ToString();
        }
    }
}
