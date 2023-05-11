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
        SqlConnection con = Program.ServerCon();
        SqlDataReader dr;
        public home(string userN)
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            if (Q11.Text != string.Empty || Q12.Text != string.Empty || Q15.Text != string.Empty || txtinterviewer.Text != string.Empty || txtcrfdate.Text != string.Empty)
            {
                if (Q15.Text != string.Empty)
                {
                    cmd = new SqlCommand("select * from folowcrf where pidtxt ='" + Q15.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("PID Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into folowcrf values(@vnumtxt,@vdatetxt,@pidtxt,@pnametxt,@agetxt)", con);
                        cmd.Parameters.AddWithValue("vnumtxt", Q11.Text);
                        cmd.Parameters.AddWithValue("vdatetxt", Q12.Text);
                        cmd.Parameters.AddWithValue("pidtxt", Q15.Text);
                        cmd.Parameters.AddWithValue("pnametxt", txtinterviewer.Text);
                        cmd.Parameters.AddWithValue("agetxt", txtcrfdate.Text);

                        int v = cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Data is Inserted . Please Input Next From now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Q11.Text = "";
                        Q12.Text = "";
                        Q15.Text = "";
                        txtinterviewer.Text = "";
                        txtcrfdate.Text = "";
                        Q11.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("Please enter Correct PID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Q15.Focus();
                }
            }
            else
            {
                if (Q11.Text != string.Empty)
                {
                    Q11.Focus();
                }
                else if (Q12.Text != string.Empty)
                {
                    Q12.Focus();
                }
                else if (Q15.Text != string.Empty)
                {
                    Q15.Focus();
                }
                else if (txtinterviewer.Text != string.Empty)
                {
                    txtinterviewer.Focus();
                }
                else if (txtcrfdate.Text != string.Empty)
                {
                    txtcrfdate.Focus();
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
                    Q12.Focus();
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
                if (Q11.Text != "1" & Q11.Text != "2" & Q11.Text != "3")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q11.Clear();
                    Q11.Focus();
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
                    Q15.Focus();
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
                if (Q12.Text != "1" & Q12.Text != "2" & Q12.Text != "3")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q12.Clear();
                    Q12.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
