namespace NUDispSchedule.Forms
{
    partial class SplashScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wikiSiteLabel = new System.Windows.Forms.Label();
            this.webSiteLink = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NUDispSchedule.Properties.Resources.NULogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NUDispSchedule.Properties.Resources.ajaxloader3;
            this.pictureBox2.Location = new System.Drawing.Point(223, 164);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 128);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(210, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 76);
            this.label1.TabIndex = 2;
            this.label1.Text = "СГОАН";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(225, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "расписание занятий";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(225, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "версия 0.3";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(224, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "(Unique University)";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // wikiSiteLabel
            // 
            this.wikiSiteLabel.AutoSize = true;
            this.wikiSiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wikiSiteLabel.ForeColor = System.Drawing.Color.Blue;
            this.wikiSiteLabel.Location = new System.Drawing.Point(12, 356);
            this.wikiSiteLabel.Name = "wikiSiteLabel";
            this.wikiSiteLabel.Size = new System.Drawing.Size(185, 20);
            this.wikiSiteLabel.TabIndex = 8;
            this.wikiSiteLabel.Text = "http://wiki.nayanova.edu";
            this.wikiSiteLabel.Click += new System.EventHandler(this.LabelLinkClick);
            this.wikiSiteLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            this.wikiSiteLabel.MouseEnter += new System.EventHandler(this.LabelLinkMouseEnter);
            this.wikiSiteLabel.MouseLeave += new System.EventHandler(this.LabelLinkMouseLeave);
            // 
            // webSiteLink
            // 
            this.webSiteLink.AutoSize = true;
            this.webSiteLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webSiteLink.ForeColor = System.Drawing.Color.Blue;
            this.webSiteLink.Location = new System.Drawing.Point(12, 329);
            this.webSiteLink.Name = "webSiteLink";
            this.webSiteLink.Size = new System.Drawing.Size(393, 20);
            this.webSiteLink.TabIndex = 7;
            this.webSiteLink.Text = "https://github.com/BesuglovS/NUDispSchedule/wiki";
            this.webSiteLink.Click += new System.EventHandler(this.LabelLinkClick);
            this.webSiteLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            this.webSiteLink.MouseEnter += new System.EventHandler(this.LabelLinkMouseEnter);
            this.webSiteLink.MouseLeave += new System.EventHandler(this.LabelLinkMouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Веб сайты:";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 393);
            this.Controls.Add(this.wikiSiteLabel);
            this.Controls.Add(this.webSiteLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplashScreenLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wikiSiteLabel;
        private System.Windows.Forms.Label webSiteLink;
        private System.Windows.Forms.Label label5;
    }
}