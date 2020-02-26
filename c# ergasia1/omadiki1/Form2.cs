using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;

namespace omadiki1
{  
    public partial class Form2 : Form
    {
        public string name;
        Color c = Form1.DefaultBackColor;
        public Form2()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            int length = name.Length;
            char[] space = name.ToCharArray();
            int sp = 0;
            for (int i = 0; i < length; i++)
            {
                if (space[i] == ' ')
                {
                    sp++;
                }
            }

            if (name == "")
            {
                MessageBox.Show("ΠΡΕΠΕΙ ΝΑ ΒΑΛΕΙΣ ΟΝΟΜΑ ΠΡΩΤΑ");
            }
            else
            if (sp > 0)
            {
                MessageBox.Show("ΔΕΝ ΕΠΙΤΡΕΠΟΝΤΑΙ ΤΑ ΚΕΝΑ");
            }
            else
            {
                Form1 form1 = new Form1(c,name);
                form1.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                c = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("scores.txt", RichTextBoxStreamType.PlainText);
            foreach (string s in richTextBox1.Lines)
            {
                string[] tmp = s.Split(' ');
                if (tmp[0] == "")
                {
                    break;
                }
                MessageBox.Show("User : " + tmp[0] + "\n needed " + tmp[2]+" seconds and "+tmp[1]+" tries");
            }
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tries = int.MaxValue;
            string best = "", best1 = "";
            richTextBox1.LoadFile("scores.txt", RichTextBoxStreamType.PlainText);
            foreach (string s in richTextBox1.Lines)
            {
                string[] tmp = s.Split(' ');
                if (tmp[0] == "")
                {
                    break;
                }
                if (int.Parse(tmp[1]) < tries)
                {
                    tries = int.Parse(tmp[1]);
                    best1 = tmp[0];
                    best = tmp[2];
                }
            }
            MessageBox.Show("Ο ΚΑΛΥΤΕΡΟΣ ΠΑΙΧΤΗΣ ΤΟΥ ΠΑΙΧΝΙΔΙΟΥ ΕΙΝΑΙ : \n" + best1 + " ΜΕ ΧΡΟΝΟ : \n" + best +"\n ΚΑΙ "+tries+" ΠΡΟΣΠΑΘΕΙΕΣ");
            richTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void iMAGESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In order to change the images of the game you must go to the resources folder and delete the image you want to remove." +
                "Then you must copy the image you want to add but it must have the same name with the on \n" +
                "HAVE FUN!!!");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit ?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game's purpose is to find the same images with the fewer tries you can. \n" +
                "Let's see who is the best !!!");
        }
    }
          
        }
    


