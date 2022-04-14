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
using Excel = Microsoft.Office.Interop.Excel;

namespace tex_otdel
{
    public partial class bd_сведения : Form
    {
        public bd_сведения()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=rabota; password=root;");
        MySqlCommand command;

        private void bd_сведения_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet2.клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.rabotaDataSet2.клиент);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet1.vidrabot". При необходимости она может быть перемещена или удалена.
            this.vidrabotTableAdapter.Fill(this.rabotaDataSet1.vidrabot);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet.rabotniki". При необходимости она может быть перемещена или удалена.
            this.rabotnikiTableAdapter.Fill(this.rabotaDataSet.rabotniki);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rabotaDataSet3.сведения". При необходимости она может быть перемещена или удалена.
            this.сведенияTableAdapter.Fill(this.rabotaDataSet3.сведения);

            populateDGR();

        }

        public void populateDGR()
        {
            string selectQuery = "SELECT * FROM сведения";
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
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO сведения(имя_заказчика, имя_спец, транспортное_средство, вид_работ, итог) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            executeQuery(insertQuery);
            populateDGR();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE сведения SET имя_заказчика='" + textBox2.Text + "', имя_спец='" + textBox3.Text + "', транспортное_средство='" + textBox4.Text + "', вид_работ='" + textBox5.Text + "', итог='" + textBox6.Text + "' WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(updateQuery);
            populateDGR();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM сведения WHERE id =" + int.Parse(textBox1.Text);
            executeQuery(deleteQuery);
            populateDGR();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            string select = "SELECT * FROM сведения WHERE id =" + int.Parse(textBox1.Text);
            command = new MySqlCommand(select, connection);
            openConnection();
            mdr = command.ExecuteReader();

            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("имя_заказчика");
                textBox3.Text = mdr.GetString("имя_спец");
                textBox4.Text = mdr.GetString("транспортное_средство");
                textBox5.Text = mdr.GetString("вид_работ");
                textBox6.Text = mdr.GetString("итог");
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
            closeConnection();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void экспорToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }
            exApp.Visible = true;
        }
    }
}
