using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ResturentBookingProject
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        

        private void UserRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {

        }

        private void MaleradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //EmailtextBox.Checked;
        }

        private void EmailtextBox_Leave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.;Initial Catalog=MyProject;Integrated Security=True");
            connection.Open();

            string gen = null;
            if (MaleradioButton1.Checked)
            {
                gen = MaleradioButton1.Text;
            }
            else
                gen = FemaleradioButton2.Text;

            string sql = "INSERT INTO Users(Username,Password,Email,DateOfBirth,Gender,usertype) VALUES('" + UsernametextBox.Text + "','" + PasswordtextBox.Text + "','" + EmailtextBox.Text + "','" + dateTimePicker.Text + "','" + gen + "','" + comboBox1.Text + "')";
            SqlCommand command = new SqlCommand(sql,connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                MessageBox.Show("User added successfully");
                NametextBox.Text = UsernametextBox.Text = PasswordtextBox.Text = ConfirmPasswordtextBox.Text = EmailtextBox.Text = dateTimePicker.Text = comboBox1.Text = string.Empty;
                MaleradioButton1.Checked = false;
                FemaleradioButton2.Checked = false;
            }
            else
                MessageBox.Show("Error in adding user.");

           ///
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm ff1 = new LoginForm();
            ff1.ShowDialog();
        }
    }
}
