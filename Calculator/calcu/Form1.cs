using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcu
{
    public partial class Form1 : Form
    {
        double result = 0;
        double tempNum;
        string arOpr = "";
        bool enter_value = false;
        bool operationComplete, numberClick;
        string fnum, snum, optStore;

        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            numberClick = false;
            //arOpr = "";
            Button btn = (Button)sender;
            //snum = "0";
            //result = 0;
            if ((textBox1.Text == "0") || (enter_value))
            {
                textBox1.Text = "";
            }
            enter_value = false;

            if (btn.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text = textBox1.Text + btn.Text;
                }

            }

            else
            {
                if(operationComplete == false)
                {
                    textBox1.Text = textBox1.Text + btn.Text;
                }

                else
                {
                    operationComplete = false; //solved append text after Equal click
                    textBox1.Text = "";
                    textBox1.Text = textBox1.Text + btn.Text;
                }

            }
        }

        private void aropt_click(object sender, EventArgs e)
        {
            
            //numberClick = false;
            Button btn = (Button)sender;
            
            if (result != 0) // operationComplete == false
            {
                buttonEql.PerformClick();
                enter_value = true;
                arOpr = btn.Text;
                label1.Text = result + " " + arOpr;

            }

            else
            {
                arOpr = btn.Text;
                result = double.Parse(textBox1.Text);
                operationComplete = true; //append solve
                label1.Text = Convert.ToString(result) + "  " + arOpr;

            }

            fnum = label1.Text;
            //tempNum = result;
            //optStore = arOpr;
        }
        
        private void buttonEql_click(object sender, EventArgs e)
        {
            //numberClick = true;
            Button btn = (Button)sender;
            //fnum = label1.Text;
            label1.Text = "";
            //snum = textBox1.Text;
            
            switch (arOpr)
            {
                case "+":
                    
                    if (numberClick == true)
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (double.Parse(snum) + double.Parse(textBox1.Text)).ToString();
                    }
                    else
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (result + double.Parse(textBox1.Text)).ToString();
                        numberClick = true;
                    }
                        
                    break;

                case "-":
                    
                    if(numberClick == true)
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (double.Parse(snum) - double.Parse(textBox1.Text)).ToString();
                    }
                    else
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (result - double.Parse(textBox1.Text)).ToString();
                        numberClick = true;
                    }
                    
                    break;

                case "x":

                    if(numberClick == true)
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (double.Parse(snum) * double.Parse(textBox1.Text)).ToString();
                    }

                    else
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (result * double.Parse(textBox1.Text)).ToString();
                        numberClick = false;
                    }
                    
                    break;

                case "÷":

                    if(numberClick == true)
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (double.Parse(snum) / double.Parse(textBox1.Text)).ToString();
                    }

                    else
                    {
                        snum = textBox1.Text;
                        textBox1.Text = (result / double.Parse(textBox1.Text)).ToString();
                        numberClick = false;
                    }
                    
                    break;

                
                default:
                    break;
            }

            result = Double.Parse(textBox1.Text);
            //arOpr = "";
            operationComplete = true; //solved append text after Equal click
            //buttonEql_click() = true;
            

            //history part
            if(numberClick == false)
            {
                if (textBox2.Text == "There's no history yet")
                {
                    textBox2.Text = "";
                    textBox2.AppendText(fnum + "  " + snum + "  = " + "\n");
                    textBox2.AppendText("\t" + textBox1.Text + "\n");
                    //fnum = "";
                    //snum = "";
                }

                else
                {
                    textBox2.AppendText(fnum + "  " + snum + "  = " + "\n");
                    textBox2.AppendText("\t" + textBox1.Text + "\n");
                    //fnum = "";
                    //snum = "";           
                }

            }

            else
            {
                if (textBox2.Text == "There's no history yet")
                {
                    //fnum = snum;
                    textBox2.Text = "";
                    textBox2.AppendText(fnum + "  " + snum + "  = " + "\n");
                    textBox2.AppendText("\t" + textBox1.Text + "\n");
                    //fnum = "";
                    //snum = "";
                }

                else
                {
                    textBox2.AppendText(fnum + "  " + snum + "  = " + "\n");
                    textBox2.AppendText("\t" + textBox1.Text + "\n");
                    //fnum = "";
                    //snum = "";           
                }
            }
            
            
        }

        private void buttonCE_click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void buttonC_click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            result = 0;
            //snum = "0";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }

            else if(textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void buttonOff_click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //memory work
        private void memoryPlus_click(object sender, EventArgs e)
        {
            if(memorybox.Text.Length == 0)
            {
                //memorybox.Text = "";
                //string memo = textBox1.Text;
                memorybox.AppendText(textBox1.Text);
                if (textBox2.Text == "There's no history yet")
                {
                    textBox2.Text = "";
                    textBox2.AppendText(memorybox.Text + ". M+ Performed!\n");
                }

                else
                    textBox2.AppendText(memorybox.Text + ". M+ Performed!\n");

            }

            else if(memorybox.Text.Length != 0)
            {
                memorybox.Text = (double.Parse(memorybox.Text) + double.Parse(textBox1.Text)).ToString();
                if (textBox2.Text == "There's no history yet")
                {
                    textBox2.Text = "";
                    textBox2.AppendText(memorybox.Text + ". M+ Performed!\n");
                }

                else
                    textBox2.AppendText(memorybox.Text + ". M+ Performed!\n");
            }

            buttonMemory.Enabled = true;
            buttonMemoryClear.Enabled = true;  
                  
        }

        private void memoryMinus_click(object sender, EventArgs e)
        {
            if(memorybox.Text.Length != 0)
            {
                memorybox.Text = (double.Parse(memorybox.Text) - double.Parse(textBox1.Text)).ToString();
                if (textBox2.Text == "There's no history yet")
                {
                    textBox2.Text = "";
                    textBox2.AppendText(memorybox.Text + ". M- Performed!\n");
                }

                 else
                    textBox2.AppendText(memorybox.Text + ". M- Performed!\n");
            }

            else if(memorybox.Text.Length == 0)
            {
                memorybox.Text = (- double.Parse(textBox1.Text)).ToString();
                if (textBox2.Text == "There's no history yet")
                {
                    textBox2.Text = "";
                    textBox2.AppendText(memorybox.Text + ". M- Performed!\n");
                }
                else
                    textBox2.AppendText(memorybox.Text + ". M- Performed!\n");
            }

            buttonMemory.Enabled = true;
            buttonMemoryClear.Enabled = true;

        }

        private void memoryShow_click(object sender, EventArgs e)
        {
            if(memorybox.Text.Length != 0)
            {
                //string m = memorybox.Text;
                textBox1.Text = "";
                textBox1.AppendText(memorybox.Text);
                textBox2.AppendText("MR Performed!\n");
            }

        }

        private void memoryClear_click(object sender, EventArgs e)
        {
            if (memorybox.Text.Length != 0)
            {
                memorybox.Text = "";
                textBox2.AppendText("Memory Cleared!\n");
            }

            buttonMemory.Enabled = false;
            buttonMemoryClear.Enabled = false;
        }


        //memory slide button
        private void memorySlide_click(object sender, EventArgs e)
        {
            label2.Hide();
            textBox2.Hide();
            clearHistory.Hide();
            label3.Show();
            memorybox.Show();

            /*if (this.Height == 466 && this.Width == 279)
            {
                this.Height = 466;
                this.Width = 500;
            }

            else if (this.Height == 466 && this.Width == 500)
            {
                this.Height = 466;
                this.Width = 279;
            }*/
        }

        private void info_click(object sender, EventArgs e)
        {
            MessageBox.Show("by,,\nArnab Basak\nID: 16-32206-2", "Info", MessageBoxButtons.OK);
        }

        //history clear button
        private void clearHistoy_click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length != 0)
            {
                textBox2.Text = "There's no history yet";
            }
        }

        //history showing button
        private void historybutton_click(object sender, EventArgs e)
        {
            label3.Hide();
            memorybox.Hide();
            label2.Show();
            textBox2.Show();
            clearHistory.Show();
        }

        //history sliding part
        private void buttonHistory_click(object sender, EventArgs e)
        {
            //279, 466 || 500, 466

            label3.Hide();
            memorybox.Hide();
            label2.Show();
            textBox2.Show();
            clearHistory.Show();

            if (this.Height == 466 && this.Width == 279)
            {
                this.Height = 466;
                this.Width = 500;
            }

            else if (this.Height == 466 && this.Width == 500)
            {
                this.Height = 466;
                this.Width = 279;
            }
        }
    }

}
