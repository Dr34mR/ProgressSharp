
namespace ProgressForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressTask = new System.Windows.Forms.ProgressBar();
            this.lblTask = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataQuests = new System.Windows.Forms.DataGridView();
            this.progressQuest = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataPlot = new System.Windows.Forms.DataGridView();
            this.progressPlot = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataSpells = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.progressExperience = new System.Windows.Forms.ProgressBar();
            this.dataStats = new System.Windows.Forms.DataGridView();
            this.dataInfo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataInventory = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.progressInventory = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataEquipment = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuests)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlot)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSpells)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInventory)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // progressTask
            // 
            this.progressTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressTask.Location = new System.Drawing.Point(0, 552);
            this.progressTask.Name = "progressTask";
            this.progressTask.Size = new System.Drawing.Size(800, 18);
            this.progressTask.TabIndex = 9;
            // 
            // lblTask
            // 
            this.lblTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTask.Location = new System.Drawing.Point(0, 529);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(800, 23);
            this.lblTask.TabIndex = 10;
            this.lblTask.Text = "Executing a greater Beagle...";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(600, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 529);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataQuests);
            this.panel2.Controls.Add(this.progressQuest);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 344);
            this.panel2.TabIndex = 6;
            // 
            // dataQuests
            // 
            this.dataQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataQuests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataQuests.Location = new System.Drawing.Point(0, 15);
            this.dataQuests.Name = "dataQuests";
            this.dataQuests.RowTemplate.Height = 25;
            this.dataQuests.Size = new System.Drawing.Size(200, 311);
            this.dataQuests.TabIndex = 8;
            // 
            // progressQuest
            // 
            this.progressQuest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressQuest.Location = new System.Drawing.Point(0, 326);
            this.progressQuest.Name = "progressQuest";
            this.progressQuest.Size = new System.Drawing.Size(200, 18);
            this.progressQuest.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Quests";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataPlot);
            this.panel1.Controls.Add(this.progressPlot);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 185);
            this.panel1.TabIndex = 5;
            // 
            // dataPlot
            // 
            this.dataPlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPlot.Location = new System.Drawing.Point(0, 15);
            this.dataPlot.Name = "dataPlot";
            this.dataPlot.RowTemplate.Height = 25;
            this.dataPlot.Size = new System.Drawing.Size(200, 152);
            this.dataPlot.TabIndex = 8;
            // 
            // progressPlot
            // 
            this.progressPlot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressPlot.Location = new System.Drawing.Point(0, 167);
            this.progressPlot.Name = "progressPlot";
            this.progressPlot.Size = new System.Drawing.Size(200, 18);
            this.progressPlot.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Plot Development";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 529);
            this.panel4.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataSpells);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 220);
            this.panel5.TabIndex = 18;
            // 
            // dataSpells
            // 
            this.dataSpells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSpells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSpells.Location = new System.Drawing.Point(0, 15);
            this.dataSpells.Name = "dataSpells";
            this.dataSpells.RowTemplate.Height = 25;
            this.dataSpells.Size = new System.Drawing.Size(200, 205);
            this.dataSpells.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Spell Book";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.progressExperience);
            this.panel6.Controls.Add(this.dataStats);
            this.panel6.Controls.Add(this.dataInfo);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 309);
            this.panel6.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Experience";
            // 
            // progressExperience
            // 
            this.progressExperience.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressExperience.Location = new System.Drawing.Point(0, 291);
            this.progressExperience.Name = "progressExperience";
            this.progressExperience.Size = new System.Drawing.Size(200, 18);
            this.progressExperience.TabIndex = 3;
            // 
            // dataStats
            // 
            this.dataStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStats.Location = new System.Drawing.Point(0, 109);
            this.dataStats.Name = "dataStats";
            this.dataStats.RowTemplate.Height = 25;
            this.dataStats.Size = new System.Drawing.Size(200, 167);
            this.dataStats.TabIndex = 2;
            // 
            // dataInfo
            // 
            this.dataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInfo.Location = new System.Drawing.Point(0, 15);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.RowTemplate.Height = 25;
            this.dataInfo.Size = new System.Drawing.Size(200, 95);
            this.dataInfo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Character Sheet";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(200, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(400, 529);
            this.panel7.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataInventory);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.progressInventory);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 236);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(400, 293);
            this.panel9.TabIndex = 1;
            // 
            // dataInventory
            // 
            this.dataInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInventory.Location = new System.Drawing.Point(0, 15);
            this.dataInventory.Name = "dataInventory";
            this.dataInventory.RowTemplate.Height = 25;
            this.dataInventory.Size = new System.Drawing.Size(400, 245);
            this.dataInventory.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(0, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Encumberance";
            // 
            // progressInventory
            // 
            this.progressInventory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressInventory.Location = new System.Drawing.Point(0, 275);
            this.progressInventory.Name = "progressInventory";
            this.progressInventory.Size = new System.Drawing.Size(400, 18);
            this.progressInventory.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Inventory";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dataEquipment);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(400, 236);
            this.panel8.TabIndex = 0;
            // 
            // dataEquipment
            // 
            this.dataEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEquipment.Location = new System.Drawing.Point(0, 15);
            this.dataEquipment.Name = "dataEquipment";
            this.dataEquipment.RowTemplate.Height = 25;
            this.dataEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.dataEquipment.Size = new System.Drawing.Size(400, 221);
            this.dataEquipment.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Equipment";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.progressTask);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuests)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlot)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSpells)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInventory)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressTask;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressQuest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressPlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataSpells;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressExperience;
        private System.Windows.Forms.DataGridView dataStats;
        private System.Windows.Forms.DataGridView dataInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dataInventory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar progressInventory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dataEquipment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataQuests;
        private System.Windows.Forms.DataGridView dataPlot;
    }
}

