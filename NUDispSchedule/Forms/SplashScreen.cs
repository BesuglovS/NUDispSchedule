using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NUDispSchedule.Forms
{
    public partial class SplashScreen : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
    }
}
