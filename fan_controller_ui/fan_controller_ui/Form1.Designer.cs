namespace fan_controller_ui_window
{
    partial class ui_form
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
            this.tempULabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fanSpeedBar = new System.Windows.Forms.TrackBar();
            this.rbCels = new System.Windows.Forms.RadioButton();
            this.rbFahr = new System.Windows.Forms.RadioButton();
            this.fanSpeedLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fanSpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tempULabel
            // 
            this.tempULabel.AutoSize = true;
            this.tempULabel.Location = new System.Drawing.Point(13, 13);
            this.tempULabel.Name = "tempULabel";
            this.tempULabel.Size = new System.Drawing.Size(64, 13);
            this.tempULabel.TabIndex = 0;
            this.tempULabel.Text = "tempULabel";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // fanSpeedBar
            // 
            this.fanSpeedBar.LargeChange = 2;
            this.fanSpeedBar.Location = new System.Drawing.Point(0, 70);
            this.fanSpeedBar.Name = "fanSpeedBar";
            this.fanSpeedBar.Size = new System.Drawing.Size(284, 45);
            this.fanSpeedBar.TabIndex = 2;
            this.fanSpeedBar.Value = 5;
            // 
            // rbCels
            // 
            this.rbCels.AutoSize = true;
            this.rbCels.Location = new System.Drawing.Point(13, 30);
            this.rbCels.Name = "rbCels";
            this.rbCels.Size = new System.Drawing.Size(54, 17);
            this.rbCels.TabIndex = 3;
            this.rbCels.TabStop = true;
            this.rbCels.Text = "rbCels";
            this.rbCels.UseVisualStyleBackColor = true;
            // 
            // rbFahr
            // 
            this.rbFahr.AutoSize = true;
            this.rbFahr.Location = new System.Drawing.Point(105, 30);
            this.rbFahr.Name = "rbFahr";
            this.rbFahr.Size = new System.Drawing.Size(55, 17);
            this.rbFahr.TabIndex = 4;
            this.rbFahr.TabStop = true;
            this.rbFahr.Text = "rbFahr";
            this.rbFahr.UseVisualStyleBackColor = true;
            // 
            // fanSpeedLabel
            // 
            this.fanSpeedLabel.AutoSize = true;
            this.fanSpeedLabel.Location = new System.Drawing.Point(13, 54);
            this.fanSpeedLabel.Name = "fanSpeedLabel";
            this.fanSpeedLabel.Size = new System.Drawing.Size(79, 13);
            this.fanSpeedLabel.TabIndex = 5;
            this.fanSpeedLabel.Text = "fanSpeedLabel";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(197, 213);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fanSpeedLabel);
            this.Controls.Add(this.rbFahr);
            this.Controls.Add(this.rbCels);
            this.Controls.Add(this.fanSpeedBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tempULabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fanSpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tempULabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TrackBar fanSpeedBar;
        private System.Windows.Forms.RadioButton rbCels;
        private System.Windows.Forms.RadioButton rbFahr;
        private System.Windows.Forms.Label fanSpeedLabel;
        private System.Windows.Forms.Button sendButton;
    }
}

