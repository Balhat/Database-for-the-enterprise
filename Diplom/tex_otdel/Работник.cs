using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tex_otdel
{
    public partial class Работник : Form
    {
        public Работник()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rabotniki bd1 = new Rabotniki();
            bd1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bd_вид_работ bd2 = new bd_вид_работ();
            bd2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Клиент bd3 = new Клиент();
            bd3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bd_сведения bd4 = new bd_сведения();
            bd4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bd_детали bd5 = new bd_детали();
            bd5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bd_по_деталям bd6 = new bd_по_деталям();
            bd6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Работник_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Работник_Load(object sender, EventArgs e)
        {

        }
    }
}
