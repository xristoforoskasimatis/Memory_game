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
    public partial class Form1 : Form
    {
        bool click = false; 
        PictureBox fisrt;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 0;
       
        player p = new player();
        int tries = 0;
        public Form1(Color bc,String name)
        {
            InitializeComponent();
            this.BackColor = bc;
            string usr = name;
            label1.Text = "";
            label3.Text = usr;            
            p.name = usr;
            label4.Text = "";
            
        }
        public class player
        {
            public string name;
            public int ptries;
            public int timer1;
            public bool save = false;
            public void SaveFile()
            {
                RichTextBox richText = new RichTextBox();
                if (!save)
                {
                    richText.LoadFile("scores.txt", RichTextBoxStreamType.PlainText);
                    richText.Text = richText.Text + name + " " + ptries.ToString()+" "+timer1.ToString()+Environment.NewLine;
                    richText.SaveFile("scores.txt", RichTextBoxStreamType.PlainText);
                    save = true;
                }
            }
        }
        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static IEnumerable<Image> images {
            get {
                return new Image[] {
            Properties.Resources.img1,
            Properties.Resources.img2,
            Properties.Resources.img3,
            Properties.Resources.img4,
            Properties.Resources.img5,
            Properties.Resources.img6,
            Properties.Resources.img7,
            Properties.Resources.img8 };
            } }

        private void start()
        { timer1.Start();
            timer1.Tick += delegate
            {
                time++;
                label1.Text = time.ToString() + " seconds";
            };
           
        }

        private void reset()
        {
            foreach (var picture in pictureBoxes) {
                picture.Tag = null;
                picture.Visible = true;
            }
            hidepic();
            setpics();
            time = 0;
            timer1.Start();
        }

        private void hidepic()
        { foreach (var picture in pictureBoxes)
            { picture.Image = Properties.Resources.question;
            } }

        private PictureBox getFreeSlot() {
            int num;
            do {
                num = rnd.Next(0, pictureBoxes.Count());
            } while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num]; }

        private void setpics() {
            foreach (var image in images) {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image; } }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {   hidepic();
            click = true;
           clickTimer.Stop(); }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void clickImage(object sender, EventArgs e)
        {
            label4.Text = tries.ToString();
            if (!click) return;
            var picture = (PictureBox)sender;
            if (fisrt == null)
            {
                tries++;
                fisrt = picture;
                picture.Image = (Image)picture.Tag;                
                return;                
            }
            picture.Image = (Image)picture.Tag;
            if (picture.Image == fisrt.Image && picture != fisrt)
            {
                picture.Visible = fisrt.Visible = false;
                             
                hidepic();
               
            }
            else
            {
                click = false;
                clickTimer.Start();
              
            }
            fisrt = null;
            if (pictureBoxes.Any(p => p.Visible))
                return;
            timer1.Stop();
            p.ptries = tries;
            p.timer1 = time;

            if (MessageBox.Show("Congratulation !!!\n User : "+p.name +" tried : " +tries+" times in "+time+" seconds \n retry?", "Game Over", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
            {
                this.Close();
                p.SaveFile();
            }
            else {
                p.SaveFile();
                reset();
                tries = 0;
                    }
        }

        private void startGame(object sender, EventArgs e)
        {
           click= true;
            setpics();
            hidepic();
            start();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
    }
}
