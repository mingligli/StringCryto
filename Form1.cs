using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//文本加密
        {
            //lml0126加密为yTfOM5Nskw==
            byte[] input = Encoding.UTF8.GetBytes(textBox1.Text);//文本转为byte[]
            byte[] output = (input.Select((byte s, int i) => (byte)((i % 2 == 0) ? ((int)(byte.MaxValue - s)) : ((int)s ^ i % 255)))).Reverse().ToArray<byte>();
            textBox2.Text = Convert.ToBase64String(output);
        }

        private void button2_Click(object sender, EventArgs e)//文本解密
        {
            //yTfOM5Nskw==解密为lml0126
            byte[] input = Convert.FromBase64String(textBox2.Text);//文本转为byte[]
            byte[] output = input.Reverse<byte>().Select((byte s, int i) => (byte)((i % 2 == 0) ? ((int)(byte.MaxValue - s)) : ((int)s ^ i % 255))).ToArray<byte>();
            textBox1.Text = Encoding.UTF8.GetString(output);
        }
    }
}
