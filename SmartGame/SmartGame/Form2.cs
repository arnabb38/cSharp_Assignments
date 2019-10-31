using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void yes_click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void mouse_enter(object sender, EventArgs e)
        {
            Random r = new Random();

            button1.Location = new Point(r.Next(this.Width - button1.Width), r.Next(this.Height - button1.Height));
        }

        private void no_click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
