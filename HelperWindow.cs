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
    public partial class HelperWindow : Form
    {
        public HelperWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.textBox1.Text.ToCharArray());
            byteLabel.Text = "";
            for(int i = 0; i < bytes.Length; i++)
            {
                byteLabel.Text += bytes[i].ToString().PadLeft(3, '0') + " ";
            }
        }
    }
}
