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
    public partial class Клиент : Form
    {
        public Клиент()
        {
            InitializeComponent();
        }

        private void Клиент_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet2.клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.rabotaDataSet2.клиент);
            populateDGR();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=rabota; password=root;");
        MySqlCommand command;

        public void populateDGR()
        {
            string selectQuery = "SELECT * FROM клиент";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }



        public void executeQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO клиент(имя_заказчика, транспортное_средство, вид_поломки, цена_восстановления) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            executeQuery(insertQuery);
            populateDGR();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE клиент SET имя_заказчика='" + textBox2.Text + "', транспортное_средство='" + textBox3.Text + "', вид_поломки='" + textBox4.Text + "', цена_восстановления='" + textBox5.Text + "' WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(updateQuery);
            populateDGR();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM клиент WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(deleteQuery);
            populateDGR();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            string select = "SELECT * FROM клиент WHERE id =" + int.Parse(textBox1.Text);
            command = new MySqlCommand(select, connection);
            openConnection();
            mdr = command.ExecuteReader();

            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("имя_заказчика");
                textBox3.Text = mdr.GetString("транспортное_средство");
                textBox4.Text = mdr.GetString("вид_поломки");
                textBox5.Text = mdr.GetString("цена_восстановления");
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
            closeConnection();
        }
    }
}
