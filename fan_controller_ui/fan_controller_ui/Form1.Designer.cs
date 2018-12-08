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
            this.fanSpeedBar = new System.Windows.Forms.TrackBar();
            this.rbCels = new System.Windows.Forms.RadioButton();
            this.rbFahr = new System.Windows.Forms.RadioButton();
            this.fanSpeedLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fanSpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tempULabel
            // 
            this.tempULabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempULabel.AutoSize = true;
            this.tempULabel.Location = new System.Drawing.Point(3, 9);
            this.tempULabel.Name = "tempULabel";
            this.tempULabel.Size = new System.Drawing.Size(64, 13);
            this.tempULabel.TabIndex = 0;
            this.tempULabel.Text = "tempULabel";
            // 
            // fanSpeedBar
            // 
            this.fanSpeedBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fanSpeedBar.LargeChange = 1;
            this.fanSpeedBar.Location = new System.Drawing.Point(0, 70);
            this.fanSpeedBar.Maximum = 9;
            this.fanSpeedBar.Name = "fanSpeedBar";
            this.fanSpeedBar.Size = new System.Drawing.Size(284, 45);
            this.fanSpeedBar.TabIndex = 2;
            this.fanSpeedBar.Value = 4;
            // 
            // rbCels
            // 
            this.rbCels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCels.AutoSize = true;
            this.rbCels.Location = new System.Drawing.Point(13, 30);
            this.rbCels.Name = "rbCels";
            this.rbCels.Size = new System.Drawing.Size(54, 17);
            this.rbCels.TabIndex = 3;
            this.rbCels.Text = "rbCels";
            this.rbCels.UseVisualStyleBackColor = true;
            // 
            // rbFahr
            // 
            this.rbFahr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFahr.AutoSize = true;
            this.rbFahr.Checked = true;
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
            this.fanSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fanSpeedLabel.AutoSize = true;
            this.fanSpeedLabel.Location = new System.Drawing.Point(13, 54);
            this.fanSpeedLabel.Name = "fanSpeedLabel";
            this.fanSpeedLabel.Size = new System.Drawing.Size(79, 13);
            this.fanSpeedLabel.TabIndex = 5;
            this.fanSpeedLabel.Text = "fanSpeedLabel";
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(209, 126);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // ui_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fanSpeedLabel);
            this.Controls.Add(this.rbFahr);
            this.Controls.Add(this.rbCels);
            this.Controls.Add(this.fanSpeedBar);
            this.Controls.Add(this.tempULabel);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "ui_form";
            this.Text = "Fan Controller";
            ((System.ComponentModel.ISupportInitialize)(this.fanSpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tempULabel;
        private System.Windows.Forms.TrackBar fanSpeedBar;
        private System.Windows.Forms.RadioButton rbCels;
        private System.Windows.Forms.RadioButton rbFahr;
        private System.Windows.Forms.Label fanSpeedLabel;
        private System.Windows.Forms.Button sendButton;
    }
}

