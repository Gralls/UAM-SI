namespace SZI
{
    partial class TilePropertiesWindow
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
            this.ImageListBox = new System.Windows.Forms.ListBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.PlayerSetterButton = new System.Windows.Forms.Button();
            this.XPosLabel = new System.Windows.Forms.Label();
            this.YPosLabel = new System.Windows.Forms.Label();
            this.XPosValue = new System.Windows.Forms.Label();
            this.YPosValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageListBox
            // 
            this.ImageListBox.FormattingEnabled = true;
            this.ImageListBox.Location = new System.Drawing.Point(12, 12);
            this.ImageListBox.Name = "ImageListBox";
            this.ImageListBox.Size = new System.Drawing.Size(301, 303);
            this.ImageListBox.TabIndex = 0;
            this.ImageListBox.SelectedIndexChanged += new System.EventHandler(this.ImageListBoxSelectedIndexChanged);
            // 
            // PictureBox
            // 
            this.PictureBox.ErrorImage = null;
            this.PictureBox.InitialImage = null;
            this.PictureBox.Location = new System.Drawing.Point(363, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(128, 128);
            this.PictureBox.TabIndex = 4;
            this.PictureBox.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(343, 292);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(432, 292);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // PlayerSetterButton
            // 
            this.PlayerSetterButton.Location = new System.Drawing.Point(343, 160);
            this.PlayerSetterButton.Name = "PlayerSetterButton";
            this.PlayerSetterButton.Size = new System.Drawing.Size(164, 23);
            this.PlayerSetterButton.TabIndex = 7;
            this.PlayerSetterButton.Text = "Place Player here";
            this.PlayerSetterButton.UseVisualStyleBackColor = true;
            this.PlayerSetterButton.Click += new System.EventHandler(this.PlayerSetterButton_Click);
            // 
            // XPosLabel
            // 
            this.XPosLabel.AutoSize = true;
            this.XPosLabel.Location = new System.Drawing.Point(343, 202);
            this.XPosLabel.Name = "XPosLabel";
            this.XPosLabel.Size = new System.Drawing.Size(17, 13);
            this.XPosLabel.TabIndex = 8;
            this.XPosLabel.Text = "X:";
            this.XPosLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // YPosLabel
            // 
            this.YPosLabel.AutoSize = true;
            this.YPosLabel.Location = new System.Drawing.Point(343, 226);
            this.YPosLabel.Name = "YPosLabel";
            this.YPosLabel.Size = new System.Drawing.Size(17, 13);
            this.YPosLabel.TabIndex = 9;
            this.YPosLabel.Text = "Y:";
            // 
            // XPosValue
            // 
            this.XPosValue.AutoSize = true;
            this.XPosValue.Location = new System.Drawing.Point(382, 202);
            this.XPosValue.Name = "XPosValue";
            this.XPosValue.Size = new System.Drawing.Size(35, 13);
            this.XPosValue.TabIndex = 10;
            this.XPosValue.Text = "label3";
            // 
            // YPosValue
            // 
            this.YPosValue.AutoSize = true;
            this.YPosValue.Location = new System.Drawing.Point(382, 226);
            this.YPosValue.Name = "YPosValue";
            this.YPosValue.Size = new System.Drawing.Size(35, 13);
            this.YPosValue.TabIndex = 11;
            this.YPosValue.Text = "label4";
            this.YPosValue.Click += new System.EventHandler(this.label4_Click);
            // 
            // TilePropertiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 335);
            this.Controls.Add(this.YPosValue);
            this.Controls.Add(this.XPosValue);
            this.Controls.Add(this.YPosLabel);
            this.Controls.Add(this.XPosLabel);
            this.Controls.Add(this.PlayerSetterButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.ImageListBox);
            this.Name = "TilePropertiesWindow";
            this.Text = "TileProperties";
            this.Load += new System.EventHandler(this.TileProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ImageListBox;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button PlayerSetterButton;
        private System.Windows.Forms.Label XPosLabel;
        private System.Windows.Forms.Label YPosLabel;
        private System.Windows.Forms.Label XPosValue;
        private System.Windows.Forms.Label YPosValue;
    }
}