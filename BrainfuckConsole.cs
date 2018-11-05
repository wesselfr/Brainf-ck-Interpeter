using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brainf_ck_IDE
{
    class BrainfuckConsole
    {
        public static BrainfuckConsole instance;
        private TextBox m_TextBox;
        private int m_CurrentKeyEvent = 0;
        public BrainfuckConsole(TextBox box)
        {
            instance = this;
            m_TextBox = box;
        }

        public void GetInput(int key)
        {
            m_CurrentKeyEvent = key;
        }

        public ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo((char)m_CurrentKeyEvent, (ConsoleKey)m_CurrentKeyEvent, false, false, false);
            m_CurrentKeyEvent = 0;
            return key;
        }

        public void Clear()
        {
            m_TextBox.Text = "";
        }

        public void Write(byte charachter)
        {
            //m_TextBox.Text += charachter;
            m_TextBox.AppendText(Encoding.ASCII.GetString(new byte[] { charachter }));
        }

        public void WriteLine(string line)
        {
            //m_TextBox.Text += line + Environment.NewLine;
            m_TextBox.AppendText(line + Environment.NewLine);
        }
    }
}
