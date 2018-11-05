using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Brainf_ck_IDE
{
    public partial class Form1 : Form
    {
        private BrainfuckInterperter m_BrainFuckInterperter;
        public Form1()
        {
            InitializeComponent();
            m_BrainFuckInterperter = new BrainfuckInterperter();
            BrainfuckConsoleForm console = new BrainfuckConsoleForm();
            console.Show();
            BrainfuckConsole.instance.WriteLine("Startup Completed.");
            BrainfuckConsole.instance.WriteLine("Ready for compiling");

            MemoryViewForm memory = new MemoryViewForm(m_BrainFuckInterperter);
            memory.Show();

            //HelperWindow helper = new HelperWindow();
            //helper.Show();

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_BrainFuckInterperter.ImportText(this.brainfuckCodeBox.Text);
            m_BrainFuckInterperter.Excecute();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void SaveFile(Stream path)
        {
            StreamWriter writer = new StreamWriter(path);
            Char[] charachters = brainfuckCodeBox.Text.ToCharArray();
            for(int i = 0; i < charachters.Length; i++)
            {
                writer.Write(charachters[i]);
            }
            writer.Close();
            path.Close();
        }

        private void OpenFile(Stream path)
        {
            StreamReader reader = new StreamReader(path);
            brainfuckCodeBox.Text = reader.ReadToEnd();
            reader.Close();
            path.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.CheckPathExists)
            {
                Stream filePath = saveFileDialog1.OpenFile();
                if (filePath != null)
                {
                    SaveFile(filePath);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.CheckPathExists)
            {
                Stream filePath = openFileDialog1.OpenFile();
                if (filePath != null)
                {
                    OpenFile(filePath);
                }
            }
        }
    }
}
