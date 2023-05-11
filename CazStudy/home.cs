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
    public partial class home : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public home(string user)
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=DT-6728\SQLEXPRESS;Initial Catalog=scov;User ID=sa;Password=F@ridul123");
            cn.Open();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (vnumtxt.Text != string.Empty || vdatetxt.Text != string.Empty || pidtxt.Text != string.Empty || pnametxt.Text != string.Empty || agetxt.Text != string.Empty)
            {
                if (pidtxt.Text != string.Empty)
                {
                    cmd = new SqlCommand("select * from folowcrf where pidtxt ='" + pidtxt.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("PID Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into folowcrf values(@vnumtxt,@vdatetxt,@pidtxt,@pnametxt,@agetxt)", cn);
                        cmd.Parameters.AddWithValue("vnumtxt", vnumtxt.Text);
                        cmd.Parameters.AddWithValue("vdatetxt", vdatetxt.Text);
                        cmd.Parameters.AddWithValue("pidtxt", pidtxt.Text);
                        cmd.Parameters.AddWithValue("pnametxt", pnametxt.Text);
                        cmd.Parameters.AddWithValue("agetxt", agetxt.Text);

                        int v = cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Data is Inserted . Please Input Next From now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vnumtxt.Text = "";
                        vdatetxt.Text = "";
                        pidtxt.Text = "";
                        pnametxt.Text = "";
                        agetxt.Text = "";
                        vnumtxt.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("Please enter Correct PID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pidtxt.Focus();
                }
            }
            else
            {
                if (vnumtxt.Text != string.Empty)
                {
                    vnumtxt.Focus();
                }
                else if (vdatetxt.Text != string.Empty)
                {
                    vdatetxt.Focus();
                }
                else if (pidtxt.Text != string.Empty)
                {
                    pidtxt.Focus();
                }
                else if (pnametxt.Text != string.Empty)
                {
                    pnametxt.Focus();
                }
                else if (agetxt.Text != string.Empty)
                {
                    agetxt.Focus();
                }

                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void vnumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    vdatetxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vnumtxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vnumtxt.Text != "1" & vnumtxt.Text != "2" & vnumtxt.Text != "3")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    vnumtxt.Clear();
                    vnumtxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vdatetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    pidtxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vdatetxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (vdatetxt.Text != "1" & vdatetxt.Text != "2" & vdatetxt.Text != "3")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    vdatetxt.Clear();
                    vdatetxt.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
