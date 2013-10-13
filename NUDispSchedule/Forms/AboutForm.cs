using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace NUDispSchedule.Forms
{
    public partial class AboutForm : Form
    {
        readonly Form _antecedent;

        public AboutForm(Form antecedent)
        {
            InitializeComponent();

            Icon = Properties.Resources.information1;

            _antecedent = antecedent;
        }

        private void LabelLinkMouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void LabelLinkMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void LabelLinkClick(object sender, EventArgs e)
        {
            Process.Start(((Label)sender).Text);
        }

        private void AboutFormLoad(object sender, EventArgs e)
        {
            if (_antecedent.WindowState == FormWindowState.Minimized)
            {
                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
            }
        }
    }
}
