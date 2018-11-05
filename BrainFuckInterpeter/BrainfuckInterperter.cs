using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Brainf_ck_IDE
{
    public delegate void BrainfuckEvent();
    public delegate void MemoryEvent(uint pointer, byte value);

    /// <summary>
    /// Brainf*ck Interpeter.
    /// By: Wessel Frijters
    /// </summary>
    public class BrainfuckInterperter
    {
        private char[] m_BrainfuckText;
        private VirtualMachine m_Machine;

        public BrainfuckEvent OnStepDone;
        public MemoryEvent OnByteChanged;

        public BrainfuckInterperter()
        {
            m_Machine = new VirtualMachine(1024);
            //m_Machine.InputByte();
        }

        public void ImportText(string input)
        {
            m_BrainfuckText = input.ToCharArray();
        }

        public void Loop(int start)
        {
            int innerLoops = 0;
            for (int i = start + 1; i < m_BrainfuckText.Length; i++)
            {
                switch (m_BrainfuckText[i])
                {
                    case '>':
                        m_Machine.RaisePointer();
                        break;
                    case '<':
                        m_Machine.LowerPointer();
                        break;
                    case '+':
                        m_Machine.Raise();
                        break;
                    case '-':
                        m_Machine.Lower();
                        break;
                    case '.':
                        m_Machine.Print();
                        break;
                    case ',':
                        m_Machine.InputByte();
                        break;
                    case '[':
                        if (m_Machine.GetValue() > 1)
                        {
                            innerLoops++;
                            Loop(i);
                        }
                        break;
                    case ']':
                        if (innerLoops == 0)
                        {
                            if (m_Machine.GetValue() > 1)
                            {
                                i = start;
                            }
                            else { return; }
                        }
                        else
                        {
                            innerLoops--;
                        }
                        break;
                }
                //if(OnStepDone != null) { OnStepDone(); }
            }
        }

        public void Excecute()
        {
            BrainfuckConsole.instance.Clear();
            BrainfuckConsole.instance.WriteLine("Code Excecution");
            m_Machine = new VirtualMachine(1024);
            for (int i = 0; i < m_BrainfuckText.Length; i++)
            {
                switch (m_BrainfuckText[i])
                {
                    case '>':
                        m_Machine.RaisePointer();
                        break;
                    case '<':
                        m_Machine.LowerPointer();
                        break;
                    case '+':
                        m_Machine.Raise();
                        break;
                    case '-':
                        m_Machine.Lower();
                        break;
                    case '.':
                        m_Machine.Print();
                        break;
                    case ',':
                        m_Machine.InputByte();
                        break;
                    case '[':
                        if (m_Machine.GetValue() > 1)
                        {
                            Loop(i);
                        }
                        break;
                    case ']':

                        break;

                }
            }
            if (OnStepDone != null) { OnStepDone(); }
        }

        public VirtualMachine machine { get { return m_Machine; } }
    }
}

