using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainf_ck_IDE
{
    /// <summary>
    /// Virtual Machine used for Brainf*ck Excecution.
    /// By: Wessel Frijters
    /// </summary>
    public class VirtualMachine
    {
        byte[] m_Memory;
        uint m_Pointer = 0;
        public VirtualMachine(uint memorySize)
        {
            m_Memory = new byte[memorySize];
        }

        public void RaisePointer()
        {
            m_Pointer++;
        }
        public void LowerPointer()
        {
            m_Pointer--;
        }
        public void Raise()
        {
            m_Memory[m_Pointer]++;
        }
        public void Lower()
        {
            m_Memory[m_Pointer]--;
        }

        public void Print()
        {
            BrainfuckConsole.instance.Write(m_Memory[m_Pointer]);
        }

        public void InputByte()
        {
            m_Memory[m_Pointer] = (byte)BrainfuckConsole.instance.ReadKey().KeyChar;
        }

        public byte GetValue()
        {
            return m_Memory[m_Pointer];
        }

        //Make Memory Readable for MemoryViewer.
        public byte[] memory { get { return m_Memory; } }
    }
}