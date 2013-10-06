using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NUDispSchedule.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
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
    }
}
