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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace parking_management
{
    public partial class add : Form
    {
        public string username;
        private DateTimePicker timePicker;

        string cs = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=userDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public add()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            SqlConnection con = new SqlConnection(cs);

            string showQuery = "SELECT * FROM Parking WHERE VehicleNumber=@v";

            SqlDataAdapter da = new SqlDataAdapter(showQuery, con);

            da.SelectCommand.Parameters.AddWithValue("@v", textBox2.Text);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
		 dateTimePickerStart.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Fill All Fields");
            }

            else
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                // string query = "INSERT INTO Parking(username, VehicleNumber, EntryTime, slot) VALUES(@u,@v,@e,@s)";
                string query = "INSERT INTO Parking(username, ownername, VehicleNumber, EntryTime, slot, status) VALUES(@currentUser,@o,@v,@e,@s,@st)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@o", textBox1.Text);

                cmd.Parameters.AddWithValue("@v", textBox2.Text.ToUpper());

                cmd.Parameters.AddWithValue("@e", DateTime.Now);

                cmd.Parameters.AddWithValue("@s", comboBox1.Text);

                cmd.Parameters.AddWithValue("@st", "not paid");

				cmd.Parameters.AddWithValue("@currentUser", username);

				try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Added Successfully");
                }
                catch (SqlException ex)
                {
					//MessageBox.Show("Vehicle already added in database");
					MessageBox.Show("Database Error: " + ex.Message);
				}


                // SHOW ONLY NEWLY ADDED DATA
                string showQuery = "SELECT * FROM Parking WHERE UPPER(VehicleNumber)=UPPER(@v)";

                SqlDataAdapter da = new SqlDataAdapter(showQuery, con);

                da.SelectCommand.Parameters.AddWithValue("@v", textBox2.Text);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                textBox1.Clear();
                textBox2.Clear();

                comboBox1.SelectedIndex = -1;

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.username=username;
            d.Show();

            this.Hide();
            //this.Close();
        }

        private void add_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("A");
            comboBox1.Items.Add("B");
            comboBox1.Items.Add("C");
            comboBox1.Items.Add("D");
            comboBox1.Items.Add("E");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
      

            
        }
    }
}
