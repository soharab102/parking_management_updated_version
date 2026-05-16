using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking_management
{
	public partial class admin : Form
	{
		public string username;
		string cs = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=userDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
		public admin()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
