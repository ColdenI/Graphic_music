namespace Graphic_music
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.checkBox_isAutoStartSerial = new System.Windows.Forms.CheckBox();
            this.numericUpDown_AutoUpdateSerialListInterval = new System.Windows.Forms.NumericUpDown();
            this.checkBox_isAutoUpdateSerialList = new System.Windows.Forms.CheckBox();
            this.checkBox_isAutoStartEngine = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_isAutoStartApp = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_getVolumeIndex = new System.Windows.Forms.ComboBox();
            this.checkBox_isAddTestModes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AutoUpdateSerialListInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_isAutoStartSerial
            // 
            this.checkBox_isAutoStartSerial.AutoSize = true;
            this.checkBox_isAutoStartSerial.Location = new System.Drawing.Point(3, 3);
            this.checkBox_isAutoStartSerial.Name = "checkBox_isAutoStartSerial";
            this.checkBox_isAutoStartSerial.Size = new System.Drawing.Size(149, 20);
            this.checkBox_isAutoStartSerial.TabIndex = 2;
            this.checkBox_isAutoStartSerial.Text = "Auto start Serial Port";
            this.checkBox_isAutoStartSerial.UseVisualStyleBackColor = true;
            this.checkBox_isAutoStartSerial.CheckedChanged += new System.EventHandler(this.checkBox_isAutoStartSerial_CheckedChanged);
            // 
            // numericUpDown_AutoUpdateSerialListInterval
            // 
            this.numericUpDown_AutoUpdateSerialListInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_AutoUpdateSerialListInterval.Location = new System.Drawing.Point(442, 57);
            this.numericUpDown_AutoUpdateSerialListInterval.Maximum = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.numericUpDown_AutoUpdateSerialListInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_AutoUpdateSerialListInterval.Name = "numericUpDown_AutoUpdateSerialListInterval";
            this.numericUpDown_AutoUpdateSerialListInterval.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_AutoUpdateSerialListInterval.TabIndex = 1;
            this.numericUpDown_AutoUpdateSerialListInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_AutoUpdateSerialListInterval.ValueChanged += new System.EventHandler(this.numericUpDown_AutoUpdateSerialListInterval_ValueChanged);
            // 
            // checkBox_isAutoUpdateSerialList
            // 
            this.checkBox_isAutoUpdateSerialList.AutoSize = true;
            this.checkBox_isAutoUpdateSerialList.Location = new System.Drawing.Point(3, 30);
            this.checkBox_isAutoUpdateSerialList.Name = "checkBox_isAutoUpdateSerialList";
            this.checkBox_isAutoUpdateSerialList.Size = new System.Drawing.Size(259, 20);
            this.checkBox_isAutoUpdateSerialList.TabIndex = 0;
            this.checkBox_isAutoUpdateSerialList.Text = "Automatic update of the Serial Ports list";
            this.checkBox_isAutoUpdateSerialList.UseVisualStyleBackColor = true;
            this.checkBox_isAutoUpdateSerialList.CheckedChanged += new System.EventHandler(this.checkBox_isAutoUpdateSerialList_CheckedChanged);
            // 
            // checkBox_isAutoStartEngine
            // 
            this.checkBox_isAutoStartEngine.AutoSize = true;
            this.checkBox_isAutoStartEngine.Location = new System.Drawing.Point(6, 6);
            this.checkBox_isAutoStartEngine.Name = "checkBox_isAutoStartEngine";
            this.checkBox_isAutoStartEngine.Size = new System.Drawing.Size(173, 20);
            this.checkBox_isAutoStartEngine.TabIndex = 1;
            this.checkBox_isAutoStartEngine.Text = "Auto start of the analyzer";
            this.checkBox_isAutoStartEngine.UseVisualStyleBackColor = true;
            this.checkBox_isAutoStartEngine.CheckedChanged += new System.EventHandler(this.checkBox_isAutoStartEngine_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 117);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.checkBox_isAddTestModes);
            this.tabPage1.Controls.Add(this.comboBox_getVolumeIndex);
            this.tabPage1.Controls.Add(this.checkBox_isAutoStartApp);
            this.tabPage1.Controls.Add(this.checkBox_isAutoStartEngine);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(591, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_isAutoStartApp
            // 
            this.checkBox_isAutoStartApp.AutoSize = true;
            this.checkBox_isAutoStartApp.Enabled = false;
            this.checkBox_isAutoStartApp.Location = new System.Drawing.Point(6, 33);
            this.checkBox_isAutoStartApp.Name = "checkBox_isAutoStartApp";
            this.checkBox_isAutoStartApp.Size = new System.Drawing.Size(152, 20);
            this.checkBox_isAutoStartApp.TabIndex = 2;
            this.checkBox_isAutoStartApp.Text = "Auto program launch";
            this.checkBox_isAutoStartApp.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(591, 88);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Serial Port";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.21368F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78633F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox_isAutoStartSerial, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_AutoUpdateSerialListInterval, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_isAutoUpdateSerialList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 82);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Frequency of auto update of the list of Serial Ports (in milliseconds)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_getVolumeIndex
            // 
            this.comboBox_getVolumeIndex.FormattingEnabled = true;
            this.comboBox_getVolumeIndex.Items.AddRange(new object[] {
            "Average of R and L",
            "Max between R and L",
            "Min between R and L"});
            this.comboBox_getVolumeIndex.Location = new System.Drawing.Point(272, 56);
            this.comboBox_getVolumeIndex.Name = "comboBox_getVolumeIndex";
            this.comboBox_getVolumeIndex.Size = new System.Drawing.Size(311, 24);
            this.comboBox_getVolumeIndex.TabIndex = 3;
            this.comboBox_getVolumeIndex.SelectedIndexChanged += new System.EventHandler(this.comboBox_getVolumeIndex_SelectedIndexChanged);
            // 
            // checkBox_isAddTestModes
            // 
            this.checkBox_isAddTestModes.AutoSize = true;
            this.checkBox_isAddTestModes.Location = new System.Drawing.Point(272, 6);
            this.checkBox_isAddTestModes.Name = "checkBox_isAddTestModes";
            this.checkBox_isAddTestModes.Size = new System.Drawing.Size(123, 20);
            this.checkBox_isAddTestModes.TabIndex = 4;
            this.checkBox_isAddTestModes.Text = "Add test modes";
            this.checkBox_isAddTestModes.UseVisualStyleBackColor = true;
            this.checkBox_isAddTestModes.CheckedChanged += new System.EventHandler(this.checkBox_isAddTestModes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Calculate volume as:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 117);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AutoUpdateSerialListInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown_AutoUpdateSerialListInterval;
        private System.Windows.Forms.CheckBox checkBox_isAutoUpdateSerialList;
        private System.Windows.Forms.CheckBox checkBox_isAutoStartEngine;
        private System.Windows.Forms.CheckBox checkBox_isAutoStartSerial;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_isAutoStartApp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_getVolumeIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_isAddTestModes;
    }
}