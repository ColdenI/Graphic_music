namespace Graphic_music
{
    partial class SettingsProtocolForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_protocol = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.checkBox_isUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the message to be sent over SerialPort.\r\nThe following characters will be r" +
    "eplaced with their corresponding values:\r\n<volume> - volume\r\n<freq1>, <freq2>…<f" +
    "req16> - frequency values\r\n";
            // 
            // textBox_protocol
            // 
            this.textBox_protocol.Location = new System.Drawing.Point(13, 13);
            this.textBox_protocol.Name = "textBox_protocol";
            this.textBox_protocol.Size = new System.Drawing.Size(694, 22);
            this.textBox_protocol.TabIndex = 1;
            this.textBox_protocol.TextChanged += new System.EventHandler(this.textBox_protocol_TextChanged);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(713, 13);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(66, 42);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(722, 22);
            this.textBox_result.TabIndex = 4;
            // 
            // timer_update
            // 
            this.timer_update.Enabled = true;
            this.timer_update.Interval = 500;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // checkBox_isUpdate
            // 
            this.checkBox_isUpdate.AutoSize = true;
            this.checkBox_isUpdate.Checked = true;
            this.checkBox_isUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_isUpdate.Location = new System.Drawing.Point(628, 126);
            this.checkBox_isUpdate.Name = "checkBox_isUpdate";
            this.checkBox_isUpdate.Size = new System.Drawing.Size(158, 20);
            this.checkBox_isUpdate.TabIndex = 5;
            this.checkBox_isUpdate.Text = "Animation of the result";
            this.checkBox_isUpdate.UseVisualStyleBackColor = true;
            this.checkBox_isUpdate.CheckedChanged += new System.EventHandler(this.checkBox_isUpdate_CheckedChanged);
            // 
            // SettingsProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 158);
            this.Controls.Add(this.checkBox_isUpdate);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_protocol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsProtocolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsProtocolForm";
            this.Load += new System.EventHandler(this.SettingsProtocolForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_protocol;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.CheckBox checkBox_isUpdate;
    }
}