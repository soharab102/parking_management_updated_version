using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking_management
{
    public partial class delete : Form
    {
        public string username;
       // string cs = @"Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True";
        string cs = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=userDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        public delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "SELECT * FROM Parking WHERE UPPER(VehicleNumber)=UPPER(@v)";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue("@v", textBox1.Text);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Vehicle Found");
            }
            else
            {
                MessageBox.Show("Vehicle Not Found");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            string query = "DELETE FROM Parking WHERE VehicleNumber=@v";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@v", textBox1.Text);

            int row = cmd.ExecuteNonQuery();

            if (row > 0)
            {
                MessageBox.Show("Data Deleted Successfully");

                dataGridView1.DataSource = null;

                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Delete Failed");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.username = username;

            d.Show();

            this.Hide();
            //this.Close();
        }
    }
}
