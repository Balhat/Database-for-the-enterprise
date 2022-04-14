using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string a;

        private void button1_Click(object sender, EventArgs e)
        {
            if (a == textBox4.Text)
            {
                String loginUser = textBox1.Text;
                String passUser = textBox2.Text;

                DB db = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `authorization` WHERE `Login`=@uL AND `Pass`=@uP", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                    MessageBox.Show("Yes");
                else
                    MessageBox.Show("No");

                if (loginUser == "Работник" && passUser == "123")
                {
                    this.Hide();
                    Работник r1 = new Работник();
                    r1.Show();
                }
                if (loginUser == "Заказчик" && passUser == "456")
                {
                    this.Hide();
                    Заказчик z1 = new Заказчик();
                    z1.Show();
                }
            }
            else
            {
                MessageBox.Show("Капча не верная");
            }
        }
        private static string RndStr(int len)
        {
            string s = "", symb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();

            for (int i = 0; i < len; i++)
                s += symb[rnd.Next(0, symb.Length)];
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = RndStr(10);
            a = textBox3.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
