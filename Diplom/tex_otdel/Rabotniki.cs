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
    public partial class Rabotniki : Form
    {
        public Rabotniki()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=rabota; password=root;");
        MySqlCommand command;

        public void populateDGR()
        {
            string selectQuery = "SELECT * FROM rabotniki";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Rabotniki_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet.rabotniki". При необходимости она может быть перемещена или удалена.
            this.rabotnikiTableAdapter.Fill(this.rabotaDataSet.rabotniki);
            populateDGR();
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





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO rabotniki(имя, специальность, стаж) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            executeQuery(insertQuery);
            populateDGR();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE rabotniki SET имя='" + textBox2.Text + "', специальность='" + textBox3.Text + "', стаж='" + textBox4.Text + "' WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(updateQuery);
            populateDGR();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM rabotniki WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(deleteQuery);
            populateDGR();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            string select = "SELECT * FROM rabotniki WHERE id =" + int.Parse(textBox1.Text);
            command = new MySqlCommand(select, connection);
            openConnection();
            mdr = command.ExecuteReader();

            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("имя");
                textBox3.Text = mdr.GetString("специальность");
                textBox4.Text = mdr.GetString("стаж");
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
            closeConnection();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
