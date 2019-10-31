using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickScore
{
    public partial class Form1 : Form
    {
        private Timer t;
        private Random r;
        private List<Button> btn;
        private int count = 0;
        public static string score = "";

        public Form1()
        {
            InitializeComponent();

            btn = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };

            r = new Random();
            t = new Timer();
            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += t_Tick;

        }

        private void t_Tick(object sender, EventArgs e)
        {
            tick();   
        }

        void tick()
        {
            int i = r.Next(12);
            btn[i].BackColor = Color.OrangeRed;
            btn[i].Text = "Hit Me!";
            blinkButton(i);

            count++;
            if (count == 15)
            {
                t.Enabled = false;
                foreach (Button btn in btn)
                {
                    btn.Enabled = false;
                    btn.Text = "";
                    btn.BackColor = Color.YellowGreen;
                }

                score = scoreLabel.Text;
                MessageBox.Show("Your Score : " +score);
            }

        }

        void blinkButton(int x)
        {
            for(int i = 0; i < 12; i++)
            {
                if(i != x && btn[i].BackColor == Color.OrangeRed)
                {
                    btn[i].BackColor = Color.YellowGreen;
                    btn[i].Text = "";
                }
            }
        }
        
        private void button_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if(btn.BackColor == Color.OrangeRed)
            {
                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 10).ToString();    
            }

            else
            {
                scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) - 10).ToString();
            }

        }

        private void replay_click(object sender, EventArgs e)
        {
            t.Enabled = true;
            scoreLabel.Text = "0";
            count = 0;
            foreach (Button btn in btn)
            {
                btn.Enabled = true;
            }
            tick();
        }

        private void exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
