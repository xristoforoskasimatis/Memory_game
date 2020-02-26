using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace omadiki1
{
    public partial class Form3 : Form
    {
        class Top : IComparable<Top>
        {
            int number;
            string afterNumber;
            string line;

            public Top(string line)
            {
                string[] tmp = line.Split(' ');
                string integer = tmp[1];
                this.number = int.Parse(integer);
                this.afterNumber = tmp[0];
                this.line = line;
            }

            public int CompareTo(Top other)
            {
                // First compare number.
                int result1 = number.CompareTo(other.number);
                if (result1 != 0)
                {
                    return result1;
                }
                // Second compare part after number.
                return afterNumber.CompareTo(other.afterNumber);
            }

            public override string ToString()
            {
                return this.line;
            }
        }



        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            richTextBox1.Text = "Name  Tries  Time :" + Environment.NewLine;
            var top = new List<Top>();
            richTextBox2.LoadFile("scores.txt", RichTextBoxStreamType.PlainText);
            foreach (string s in richTextBox2.Lines)
            {
                string[] tmp = s.Split(' ');
                if (tmp[0] == "")
                {
                    break;
                }
                
                top.Add(new Top(s));
            }
            top.Sort();

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    richTextBox1.Text += top[i] + Environment.NewLine;

                }
            }catch(ArgumentOutOfRangeException r) { }
        }
    }
}
