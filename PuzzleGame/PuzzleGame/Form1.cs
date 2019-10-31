using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<Button> btn;
        List<string> img;
        int randomNumber, ranButton, count = 0, timeLeft = 15;
        Button firstImg, secImg, firstImgStore;
       

        public Form1()
        {
            InitializeComponent();

            btn = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };

            img = new List<string> { "[", "]", "%", ">", "{" };//, "b", "l", "m", "x", "y" };
            //img = new List<string>
            //{ "a", "b", "c", "d", "e" , "f", "g", "h", "i", "j",
            //"k", "l", "m", "n", "o" , "p", "q", "r", "s", "t",
            //"u", "v", "w", "x", "y" , "z"};

            buttonLocation();
            selectButtons();

           
            timer3.Start();

        }

        

        Form1 formReference
        {
            get
            {
                return new Form1();
            }
        }

        private void show_tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstImg.ForeColor = firstImg.BackColor;
            secImg.ForeColor = secImg.BackColor;
            firstImg = null;
            secImg = null;
        }

        private void replay_click(object sender, EventArgs e)
        {
            using (formReference)
            {
                timeLeft = 15;
                this.Hide();
                this.formReference.Show();
            }
        }

        
        private void timerOver_tick(object sender, EventArgs e)
        {
            if(timeLeft > -1)
            {
                label2.Text = timeLeft.ToString() + "  Seconds Left!";
                timeLeft--;
                
            }

            else
            {
                timer3.Enabled = false;
                panel2.Enabled = false;
                MessageBox.Show("Time's UP!", "FAILED");
            }
        }

        private void info_click(object sender, EventArgs e)
        {
            MessageBox.Show("by,\nArnab Basak\nID: 16-32206-2", "Info");
        }

        private void exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button_click(object sender, EventArgs e)
        {
            if(firstImg != null && secImg != null)
            {
                return;
            }
            Button btn = (Button)sender;
            //Button btn = sender as Button;
            
            if (btn == null)
            {
                return;
            }

            if(btn.ForeColor == Color.Black)
            {
                return;
            }

            if(firstImg == null)
            {
                firstImg = btn;
                firstImgStore = btn;
                firstImg.ForeColor = Color.Black;
                return;
            }

            secImg = btn;
            secImg.ForeColor = Color.Black;

            if(firstImg.Text == secImg.Text)
            {
                firstImg = null;
                secImg = null;
                btn.Visible = false;
                firstImgStore.Visible = false;
                count++;
                checkClear();
                
            }

            

            else
            {
                timer1.Start();
            }
            
        }

        void selectButtons()
        {
          
            for (int i = 0; i < btn.Count+3; i++)
            {
                
                    randomNumber = r.Next(0, img.Count);

                    for (int n = 0; n < 2; n++)
                    {
                        ranButton = r.Next(0, btn.Count);
                        btn[ranButton].Text = img[randomNumber];
                        btn.RemoveAt(ranButton);

                    }
                    //btn[i].Text = img[randomNumber];
                    //btn.RemoveAt(i);

                    //btn[i].Text = img[randomNumber];

                    img.RemoveAt(randomNumber);

                
            }
        }

        void buttonLocation()
        {
            
            foreach (Button btn in btn)
            {

                btn.Location = new Point(r.Next(this.panel2.Width - btn.Width), r.Next(this.panel2.Height - btn.Height));

            }
        }

        void checkClear()
        {
            if (count == 5)
            {
                panel2.Enabled = false;
                MessageBox.Show("Congrats! All Pairs Matched!", "Congratulation!");
            }
        }



    }
}
