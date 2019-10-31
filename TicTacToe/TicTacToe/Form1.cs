using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool shift = true;
        int count = 0;
        List<Button> btn;

        public Form1()
        {
            InitializeComponent();

            btn = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};
            label1.Text = "X" + " 's Turn!";
        }

        private void buttons_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (shift == true)
            {
                label1.Text = "O" + " 's Turn!";
                btn.Text = "X";
            }
            else
            {
                label1.Text = "X" + " 's Turn!";
                btn.Text = "O";
            }

            shift = !shift;
            btn.Enabled = false;

            count++;

            checking();

        }

        //checck for winning conditions
        void checking()
        {
            bool winner = false;

            //horizontally checking
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text != ""))
            {
                winner = true;
            }

            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (button4.Text != ""))
            {
                winner = true;
            }

            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (button7.Text != ""))
            {
                winner = true;
            }

            //vertical checking
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (button1.Text != ""))
            {
                winner = true;
            }

            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (button2.Text != ""))
            {
                winner = true;
            }

            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Text != ""))
            {
                winner = true;
            }

            //diagonally checking 
            if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (button1.Text != ""))
            {
                winner = true;
            }

            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Text != ""))
            {
                winner = true;
            }

            //winner status
            if (winner)
            {
              
                disableButtons();

                string win = "";

                if (shift)
                {
                    win = "O";
                }

                else
                {
                    win = "X";
                }

                MessageBox.Show(win + "  WON!!", "Winner");
            }

            else if (count == 9)
            {
                MessageBox.Show("Draw!!", "Tic Tac Toe");
            }
        }

        //disable buttons after win
        void disableButtons()
        {
            foreach (Button b in btn)
            {
                Button btn = (Button)b;
                b.Enabled = false;
            }
        }


        private void exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGame_click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void infoLabel_click(object sender, EventArgs e)
        {
            MessageBox.Show("by,\n\nArnab B.\n16-32206-2", "info");
        }
    }
}
