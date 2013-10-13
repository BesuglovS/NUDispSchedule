using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NUDispSchedule.Properties;

namespace NUDispSchedule.Forms
{
    public partial class SplashScreen : Form
    {
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        public SplashScreen()
        {
            InitializeComponent();            
        }

        private void LabelLinkClick(object sender, EventArgs e)
        {
            Process.Start(((Label)sender).Text);
        }

        private void LabelLinkMouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void LabelLinkMouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void SplashScreenLoad(object sender, EventArgs e)
        {
            Icon = Resources.NULogo2;
        }
    }
}
