using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaytee_Townlain_Unit9_IT481
{
	public partial class Form1 : Form
	{
		private DB db;
		private string user;
		private string password;
		private string server;
		private string database;

		public Form1()
		{
			InitializeComponent();
			button1.Click += new EventHandler(button1_Click);
			button2.Click += new EventHandler(button2_Click);
			button3.Click += new EventHandler(button3_Click);
			button4.Click += new EventHandler(button4_Click);
			button5.Click += new EventHandler(button5_Click);
			button6.Click += new EventHandler(button6_Click);
			button7.Click += new EventHandler(button7_Click);
		}
		//LAPTOP-QG48ED35 (server name)

		private void button1_Click(object sender, EventArgs e)
		{
			bool isValid = true;
			user = textBox1.Text;
			password = textBox2.Text;
			server = textBox3.Text;
			database = textBox4.Text;

			if (user.Length == 0 || password.Length == 0 || server.Length == 0 || database.Length == 0)
			{
				isValid = false;
				MessageBox.Show("You must enter user name, password, server, and database values");
			}
			else if (password.Length < 12)
			{
				isValid = false;
				MessageBox.Show("Password length must be 12 characters or more");
			}
			else
			{
				//if (password.Asll(char.IsLetterOrDigit) && password.Any(ch=> !char.IsLetterOrDigit(ch)))
				if (password.All(char.IsLetterOrDigit) && password.Any(ch => char.IsLetterOrDigit(ch)))
				{
					isValid = false;
					MessageBox.Show("You must enter alphanumeric and special characters for the password");
				}
			}
			if (isValid)
			{
				db = new DB("Server = " + server + "\\SQLEXPRESS01; " +
											"Trusted_Connection=true;" +
											"Database = " + database + ";" +
											//"User Instance=false;" +
											"USer Id = " + user + ";" +
											//"Connection timeout=30");
											"Password = " + password + ";"
											);
				MessageBox.Show("Connection information sent");
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			string count = db.getCustomerCount();
			MessageBox.Show(count, "Customer count");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string names = db.getCompanyNames();
			MessageBox.Show(names, "Company names");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string count = db.getOrderCount();
			MessageBox.Show(count, "Order count");
		}

		private void button5_Click(object sender, EventArgs e)
		{

			string names = db.getCustomerID();
			MessageBox.Show(names, "CustomerID");
		}

		private void button6_Click(object sender, EventArgs e)
		{
			string count = db.getEmployeeCount();
			MessageBox.Show(count, "Employee count");
		}

		private void button7_Click(object sender, EventArgs e)
		{
			string names = db.getEmployeeLastName();
			MessageBox.Show(names, "Employee Last Name");
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
