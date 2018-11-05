using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brainf_ck_IDE
{
    public partial class BrainfuckConsoleForm : Form
    {
        private BrainfuckConsole m_Console;
        public BrainfuckConsoleForm()
        {
            InitializeComponent();
            m_Console = new BrainfuckConsole(this.brainfuckConsoleTextbox);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void BrainfuckConsole_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BrainfuckConsole_HandleInput(object sender, KeyEventArgs e)
        {
            m_Console.GetInput((int)e.KeyCode);
        }
    }
}
