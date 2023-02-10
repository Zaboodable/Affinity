namespace JavaAffinity
{
    partial class AffinityBoy
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
            this.textBox_processNames = new System.Windows.Forms.TextBox();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_setAffinity = new System.Windows.Forms.Button();
            this.button_selectProcesses = new System.Windows.Forms.Button();
            this.label_systemInfo = new System.Windows.Forms.Label();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_processNames
            // 
            this.textBox_processNames.Location = new System.Drawing.Point(3, 3);
            this.textBox_processNames.Multiline = true;
            this.textBox_processNames.Name = "textBox_processNames";
            this.textBox_processNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_processNames.Size = new System.Drawing.Size(320, 72);
            this.textBox_processNames.TabIndex = 1;
            this.textBox_processNames.TextChanged += new System.EventHandler(this.textBox_processNames_TextChanged);
            // 
            // panel_bottom
            // 
            this.panel_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 104);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1344, 346);
            this.panel_bottom.TabIndex = 2;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.button_setAffinity);
            this.panel_top.Controls.Add(this.button_selectProcesses);
            this.panel_top.Controls.Add(this.label_systemInfo);
            this.panel_top.Controls.Add(this.textBox_processNames);
            this.panel_top.Location = new System.Drawing.Point(16, 16);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(772, 82);
            this.panel_top.TabIndex = 3;
            // 
            // button_setAffinity
            // 
            this.button_setAffinity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_setAffinity.Location = new System.Drawing.Point(657, 52);
            this.button_setAffinity.Name = "button_setAffinity";
            this.button_setAffinity.Size = new System.Drawing.Size(112, 23);
            this.button_setAffinity.TabIndex = 3;
            this.button_setAffinity.Text = "SET AFFINITY";
            this.button_setAffinity.UseVisualStyleBackColor = false;
            this.button_setAffinity.Click += new System.EventHandler(this.button_setAffinity_Click);
            // 
            // button_selectProcesses
            // 
            this.button_selectProcesses.Location = new System.Drawing.Point(329, 52);
            this.button_selectProcesses.Name = "button_selectProcesses";
            this.button_selectProcesses.Size = new System.Drawing.Size(109, 23);
            this.button_selectProcesses.TabIndex = 2;
            this.button_selectProcesses.Text = "Refresh Processes";
            this.button_selectProcesses.UseVisualStyleBackColor = true;
            this.button_selectProcesses.Click += new System.EventHandler(this.button_selectProcesses_Click);
            // 
            // label_systemInfo
            // 
            this.label_systemInfo.AutoSize = true;
            this.label_systemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_systemInfo.Location = new System.Drawing.Point(329, 6);
            this.label_systemInfo.Name = "label_systemInfo";
            this.label_systemInfo.Size = new System.Drawing.Size(82, 13);
            this.label_systemInfo.TabIndex = 0;
            this.label_systemInfo.Text = "ghfgh46ghfhfgh";
            // 
            // AffinityBoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 450);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_bottom);
            this.Name = "AffinityBoy";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AffinityBoy_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_processNames;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label_systemInfo;
        private System.Windows.Forms.Button button_selectProcesses;
        private System.Windows.Forms.Button button_setAffinity;
    }
}

