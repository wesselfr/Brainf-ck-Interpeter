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
    public partial class MemoryViewForm : Form
    {
        private BrainfuckInterperter m_Brainfuck;
        public MemoryViewForm(BrainfuckInterperter interpeter)
        {
            InitializeComponent();
            m_Brainfuck = interpeter;
            m_Brainfuck.OnStepDone += UpdateMemory;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MemoryViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void UpdateMemory()
        {
            VirtualMachine machine = m_Brainfuck.machine;
            byte[] memory = machine.memory;

            memoryViewBox.Text = "0000   ";

            for (int i = 0; i < memory.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    memoryViewBox.Text += "   ";
                }
                if (i % 8 == 0 && i != 0)
                {
                    memoryViewBox.Text += Environment.NewLine;
                    memoryViewBox.Text += (i + 1).ToString().PadLeft(4, '0') + "   ";
                }
                memoryViewBox.Text += memory[i].ToString().PadLeft(3, '0') + " ";
            }
        }
    }
}
