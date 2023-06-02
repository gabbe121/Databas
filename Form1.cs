using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ace.oledb.12.0; Data Source = Database1.accdb";
            conn.Open();


            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = "insert into Tabell1(fname, lname, nummer, epost)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("data saved");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString= "Provider = Microsoft.ace.oledb.12.0; Data Source = Database1.accdb";
            conn.Open();
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = "select * from Tabell1";
            comm.Connection = conn;
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = comm;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ace.oledb.12.0; Data Source = Database1.accdb";
            conn.Open();

            OleDbCommand selectCommand = new OleDbCommand();
            selectCommand.CommandText = "SELECT COUNT(*) FROM Tabell1 WHERE fname = @fname";
            selectCommand.Parameters.AddWithValue("@fname", txtDel.Text);
            selectCommand.Connection = conn;

            int count = (int)selectCommand.ExecuteScalar();

            if (count > 0)
            {
                OleDbCommand deleteCommand = new OleDbCommand();
                deleteCommand.CommandText = "DELETE FROM Tabell1 WHERE fname = @fname";
                deleteCommand.Parameters.AddWithValue("@fname", txtDel.Text);
                deleteCommand.Connection = conn;
                deleteCommand.ExecuteNonQuery();

                conn.Close();
                this.Hide();
                MessageBox.Show("Data removed");
                Application.Exit();
            }
            else
            {
                conn.Close();
                MessageBox.Show("Data not found");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
