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
    public partial class Заказчик : Form
    {
        public Заказчик()
        {
            InitializeComponent();
        }

        private void Заказчик_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Заказчик_Load(object sender, EventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
