namespace NUDispSchedule.Forms
{
    partial class AboutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webSiteLink = new System.Windows.Forms.Label();
            this.versionLogo = new System.Windows.Forms.PictureBox();
            this.wikiSiteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.versionLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(123, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Версия 0.2 (Terrifying Terrorist)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(125, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Веб сайты:";
            // 
            // webSiteLink
            // 
            this.webSiteLink.AutoSize = true;
            this.webSiteLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webSiteLink.ForeColor = System.Drawing.Color.Blue;
            this.webSiteLink.Location = new System.Drawing.Point(125, 63);
            this.webSiteLink.Name = "webSiteLink";
            this.webSiteLink.Size = new System.Drawing.Size(393, 20);
            this.webSiteLink.TabIndex = 2;
            this.webSiteLink.Text = "https://github.com/BesuglovS/NUDispSchedule/wiki";
            this.webSiteLink.Click += new System.EventHandler(this.LabelLinkClick);
            this.webSiteLink.MouseEnter += new System.EventHandler(this.LabelLinkMouseEnter);
            this.webSiteLink.MouseLeave += new System.EventHandler(this.LabelLinkMouseLeave);
            // 
            // versionLogo
            // 
            this.versionLogo.Image = global::NUDispSchedule.Properties.Resources.adt;
            this.versionLogo.Location = new System.Drawing.Point(17, 12);
            this.versionLogo.Name = "versionLogo";
            this.versionLogo.Size = new System.Drawing.Size(87, 129);
            this.versionLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.versionLogo.TabIndex = 3;
            this.versionLogo.TabStop = false;
            // 
            // wikiSiteLabel
            // 
            this.wikiSiteLabel.AutoSize = true;
            this.wikiSiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wikiSiteLabel.ForeColor = System.Drawing.Color.Blue;
            this.wikiSiteLabel.Location = new System.Drawing.Point(125, 83);
            this.wikiSiteLabel.Name = "wikiSiteLabel";
            this.wikiSiteLabel.Size = new System.Drawing.Size(185, 20);
            this.wikiSiteLabel.TabIndex = 4;
            this.wikiSiteLabel.Text = "http://wiki.nayanova.edu";
            this.wikiSiteLabel.Click += new System.EventHandler(this.LabelLinkClick);
            this.wikiSiteLabel.MouseEnter += new System.EventHandler(this.LabelLinkMouseEnter);
            this.wikiSiteLabel.MouseLeave += new System.EventHandler(this.LabelLinkMouseLeave);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 160);
            this.Controls.Add(this.wikiSiteLabel);
            this.Controls.Add(this.versionLogo);
            this.Controls.Add(this.webSiteLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.versionLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label webSiteLink;
        private System.Windows.Forms.PictureBox versionLogo;
        private System.Windows.Forms.Label wikiSiteLabel;
    }
}