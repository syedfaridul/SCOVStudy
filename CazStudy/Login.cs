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

namespace CazStudy
{
    public partial class Login : Form

    {
        /*SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;*/

        public Login()
        {
            InitializeComponent();
        }

        private void cbshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if(cbshowpass.Checked == false)
            
                txtpass.UseSystemPasswordChar = true;
            else 
                txtpass.UseSystemPasswordChar = false;
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Exit Application", "Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                Application.Exit();
                this.Close();
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    txtpass.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    btnlogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = Program.ServerCon();
            string qry1 = "Select * from userdata where Password=@Password and Username=@Username";
            SqlCommand com = new SqlCommand(qry1, con);

            com.Parameters.AddWithValue("@Username", this.txtuser.Text.ToString().Trim());
            com.Parameters.AddWithValue("@Password", this.txtpass.Text.ToString().Trim());

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successfull", "Login Info");
                    string userN = txtuser.Text;
                    home f = new home(userN);
                    f.Show();
                    this.Hide();
                }
            }
            if (dr.HasRows == false)
            {
                MessageBox.Show("Access Denied because of Your given Login Information may be wrong !", "Wrong Information!");
                txtuser.Focus();
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
