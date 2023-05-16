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
            this.username = userN;
        }
        string username;

        private void home_Load(object sender, EventArgs e)
        {
           Q12.Text = "__/__/____";
        }

        public bool IsValidDate(String date_value)
        {
            bool validdate = true;
            try
            {
                int Day = Convert.ToInt32(date_value.Substring(0, 2));
                int Mon = Convert.ToInt32(date_value.Substring(3, 2));
                int Yrs = Convert.ToInt32(date_value.Substring(6, 4));
                string Slash1 = date_value.Substring(2, 1);
                string Slash2 = date_value.Substring(5, 1);

                if (Slash1 != "/" && Slash2 != "/")
                {
                    validdate = false;
                }
                if (Mon < 1 || Mon > 12)
                {
                    validdate = false;
                }
                if (Mon == 4 || Mon == 6 || Mon == 9 || Mon == 11)
                {
                    if (Day < 1 || Day > 30)
                    {
                        validdate = false;
                    }
                }
                if (Mon == 1 || Mon == 3 || Mon == 5 || Mon == 7 || Mon == 8 || Mon == 10 || Mon == 12)
                {
                    if (Day < 1 || Day > 31)
                    {
                        validdate = false;
                    }
                }
                if (Mon == 2)
                {
                    if ((Yrs % 4) == 0)
                    {
                        if (Day > 29)
                        {
                            validdate = false;
                        }
                    }
                    else
                    {
                        if (Day > 28)
                        {
                            validdate = false;
                        }
                    }
                }
                int CurYear = DateTime.Today.Year;
                if (Yrs < 2014 || Yrs > CurYear)
                {
                    validdate = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return validdate;
        }
        public bool IsValidtime(String time_value)
        {
            bool Validtime = true;
            try
            {
                int HH = Convert.ToInt32(time_value.Substring(0, 2));
                int MM = Convert.ToInt32(time_value.Substring(3, 2));
                string colon = time_value.Substring(2, 1);

                if (colon != ":")
                {
                    Validtime = false;
                }
                if (HH < 00 || HH > 12)
                {
                    Validtime = false;
                }
                if (MM < 00 || MM > 59)
                {
                    Validtime = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Validtime;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (Q11.Text != string.Empty || Q12.Text != string.Empty || Q15.Text != string.Empty || txtinterviewer.Text != string.Empty || txtcrfdate.Text != string.Empty)
            {
                if (Q15.Text != string.Empty)
                {
                    cmd = new SqlCommand("select * from folowcrf where Q15 ='" + Q15.Text + "'", con);
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
                        cmd.Parameters.AddWithValue("Q11", Q11.Text);
                        cmd.Parameters.AddWithValue("Q12", Q12.Text);
                        cmd.Parameters.AddWithValue("Q15", Q15.Text);
                        cmd.Parameters.AddWithValue("txtinterviewer", txtinterviewer.Text);
                        cmd.Parameters.AddWithValue("txtcrfdate", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q13", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q13", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q16", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q17", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q211", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q212", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2211", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2212", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2213", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2214", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2215", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2216", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2221", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2222", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2223", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2224", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2225", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2226", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2227", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2228", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2229", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q22210", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q231", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q232", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q233", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q234", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q235", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q236", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q237", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q238", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q239", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2310", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2311", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2312", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2313", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2314", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q241", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q242", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q251", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q252", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q253", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q254", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q255", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q256", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q257", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q258", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q259", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2510", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q2511", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q26", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q3", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q4", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q51", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q52", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("Q53", txtcrfdate.Text);
                        cmd.Parameters.AddWithValue("username", "NULL");
                        cmd.Parameters.AddWithValue("entrydate", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));


                        int v = cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Data is Inserted . Please Input Next From now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Q11.Text = "";
                        Q12.Text = "";
                        Q13.Text = "";
                        Q14.Text = "";
                        Q15.Text = "";
                        Q16.Text = "";
                        Q17.Text = "";
                        Q211.Text = "";
                        Q212.Text = "";
                        Q2211.Text = "";
                        Q2212.Text = "";
                        Q2213.Text = "";
                        Q2214.Text = "";
                        Q2215.Text = "";
                        Q2216.Text = "";
                        Q2221.Text = "";
                        Q2222.Text = "";
                        Q2223.Text = "";
                        Q2224.Text = "";
                        Q2225.Text = "";
                        Q2226.Text = "";
                        Q2227.Text = "";
                        Q2228.Text = "";
                        Q2229.Text = "";
                        Q22210.Text = "";
                        Q231.Text = "";
                        Q232.Text = "";
                        Q233.Text = "";
                        Q234.Text = "";
                        Q235.Text = "";
                        Q236.Text = "";
                        Q237.Text = "";
                        Q238.Text = "";
                        Q239.Text = "";
                        Q2310.Text = "";
                        Q2311.Text = "";
                        Q2312.Text = "";
                        Q2313.Text = "";
                        Q2314.Text = "";
                        Q241.Text = "";
                        Q242.Text = "";
                        Q251.Text = "";
                        Q252.Text = "";
                        Q253.Text = "";
                        Q254.Text = "";
                        Q255.Text = "";
                        Q256.Text = "";
                        Q257.Text = "";
                        Q258.Text = "";
                        Q259.Text = "";
                        Q2510.Text = "";
                        Q2511.Text = "";
                        Q26.Text = "";
                        Q3.Text = "";
                        Q4.Text = "";
                        Q51.Text = "";
                        Q52.Text = "";
                        Q53.Text = "";
                        txtinterviewer.Text = "";
                        txtcrfdate.Text = "";
                        Q15.Focus();

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
                else if (Q13.Text != string.Empty)
                {
                    Q13.Focus();
                }
                else if (Q14.Text != string.Empty)
                {
                    Q14.Focus();
                }
                else if (Q15.Text != string.Empty)
                {
                    Q15.Focus();
                }
                else if (Q16.Text != string.Empty)
                {
                    Q16.Focus();
                }
                else if (Q17.Text != string.Empty)
                {
                    Q17.Focus();
                }
                else if (Q211.Text != string.Empty)
                {
                    Q211.Focus();
                }
                else if (Q212.Text != string.Empty)
                {
                    Q212.Focus();
                }
                else if (Q2211.Text != string.Empty)
                {
                    Q2211.Focus();
                }
                else if (Q2212.Text != string.Empty)
                {
                    Q2212.Focus();
                }
                else if (Q2213.Text != string.Empty)
                {
                    Q2213.Focus();
                }
                else if (Q2214.Text != string.Empty)
                {
                    Q2214.Focus();
                }
                else if (Q2215.Text != string.Empty)
                {
                    Q2215.Focus();
                }
                else if (Q2216.Text != string.Empty)
                {
                    Q2216.Focus();
                }
                else if (Q2221.Text != string.Empty)
                {
                    Q2221.Focus();
                }
                else if (Q2222.Text != string.Empty)
                {
                    Q2222.Focus();
                }
                else if (Q2223.Text != string.Empty)
                {
                    Q2223.Focus();
                }
                else if (Q2224.Text != string.Empty)
                {
                    Q2224.Focus();
                }
                else if (Q2225.Text != string.Empty)
                {
                    Q2225.Focus();
                }
                else if (Q2226.Text != string.Empty)
                {
                    Q2226.Focus();
                }
                else if (Q2227.Text != string.Empty)
                {
                    Q2227.Focus();
                }
                else if (Q2228.Text != string.Empty)
                {
                    Q2228.Focus();
                }
                else if (Q2229.Text != string.Empty)
                {
                    Q2229.Focus();
                }
                else if (Q22210.Text != string.Empty)
                {
                    Q22210.Focus();
                }
                else if (Q231.Text != string.Empty)
                {
                    Q231.Focus();
                }
                else if (Q232.Text != string.Empty)
                {
                    Q232.Focus();
                }
                else if (Q233.Text != string.Empty)
                {
                    Q233.Focus();
                }
                else if (Q234.Text != string.Empty)
                {
                    Q234.Focus();
                }
                else if (Q235.Text != string.Empty)
                {
                    Q235.Focus();
                }
                else if (Q236.Text != string.Empty)
                {
                    Q236.Focus();
                }
                else if (Q237.Text != string.Empty)
                {
                    Q237.Focus();
                }
                else if (Q238.Text != string.Empty)
                {
                    Q238.Focus();
                }
                else if (Q239.Text != string.Empty)
                {
                    Q239.Focus();
                }
                else if (Q2310.Text != string.Empty)
                {
                    Q2310.Focus();
                }
                else if (Q2311.Text != string.Empty)
                {
                    Q2311.Focus();
                }
                else if (Q2312.Text != string.Empty)
                {
                    Q2312.Focus();
                }
                else if (Q2313.Text != string.Empty)
                {
                    Q2313.Focus();
                }
                else if (Q2314.Text != string.Empty)
                {
                    Q2314.Focus();
                }
                else if (Q241.Text != string.Empty)
                {
                    Q241.Focus();
                }
                else if (Q242.Text != string.Empty)
                {
                    Q242.Focus();
                }
                else if (Q251.Text != string.Empty)
                {
                    Q251.Focus();
                }
                else if (Q252.Text != string.Empty)
                {
                    Q252.Focus();
                }
                else if (Q253.Text != string.Empty)
                {
                    Q253.Focus();
                }
                else if (Q254.Text != string.Empty)
                {
                    Q254.Focus();
                }
                else if (Q255.Text != string.Empty)
                {
                    Q255.Focus();
                }
                else if (Q256.Text != string.Empty)
                {
                    Q256.Focus();
                }
                else if (Q257.Text != string.Empty)
                {
                    Q257.Focus();
                }
                else if (Q258.Text != string.Empty)
                {
                    Q258.Focus();
                }
                else if (Q259.Text != string.Empty)
                {
                    Q259.Focus();
                }
                else if (Q2510.Text != string.Empty)
                {
                    Q2510.Focus();
                }
                else if (Q2511.Text != string.Empty)
                {
                    Q2511.Focus();
                }
                else if (Q26.Text != string.Empty)
                {
                    Q26.Focus();
                }
                else if (Q3.Text != string.Empty)
                {
                    Q3.Focus();
                }
                else if (Q4.Text != string.Empty)
                {
                    Q4.Focus();
                }
                else if (Q51.Text != string.Empty)
                {
                    Q51.Focus();
                }
                else if (Q52.Text != string.Empty)
                {
                    Q52.Focus();
                }
                else if (Q53.Text != string.Empty)
                {
                    Q53.Focus();
                }
                else if (txtinterviewer.Text != string.Empty)
                {
                    txtinterviewer.Focus();
                }
                else if (txtcrfdate.Text != string.Empty)
                {
                    txtcrfdate.Focus();
                }
                /*
Q15,Q11,Q12,Q13,Q14,Q16,Q17,Q211,Q212,Q2211,Q2212,Q2213,Q2214,Q2215,Q2216,Q2221,Q2222,Q2223,Q2224,Q2225,Q2226,
Q2227,Q2228,Q2229,Q22210,Q231,Q232,Q233,Q234,Q235,Q236,Q237,Q238,Q239,Q2310,Q2311,Q2312,Q2313,Q2314,Q241,Q242,
Q251,Q252,Q253,Q254,Q255,Q256,Q257,Q258,Q259,Q2510,Q2511,Q26,Q3,Q4,Q51,Q52,Q53,
txtinterviewer,txtcrfdate,
btnsave,btnexit;
*/

                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void Q15_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Q15_Leave(object sender, EventArgs e)
        {
            try
            {
                
                cmd = new SqlCommand("select * from folowcrf where Q15 ='" + Q15.Text + "'", con);
                dr = cmd.ExecuteReader();

                if (dr.Read() && this.Q15.Text == dr["Q15"].ToString())
                {
                    MessageBox.Show("This ID result, you already Entered !");
                    Q15.Clear();
                    Q15.Focus();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q11_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (Q11.Text == "1" & Q11.Text == "2")
                    {
                        Q15.Focus();
                        Q13.Enabled = false;
                        Q16.Enabled = false;
                    }
                    else if (Q11.Text == "3" & Q11.Text == "4" & Q11.Text == "5" & Q11.Text == "6" & Q11.Text == "7")
                    {
                        Q13.Enabled = false;
                        Q14.Enabled = false;
                        Q16.Enabled = false;
                        Q17.Enabled = false;
                        Q2211.Enabled = false;
                        Q2212.Enabled = false;
                        Q2213.Enabled = false;
                        Q2214.Enabled = false;
                        Q2215.Enabled = false;
                        Q2216.Enabled = false;
                        Q2221.Enabled = false;
                        Q2222.Enabled = false;
                        Q2223.Enabled = false;
                        Q2224.Enabled = false;
                        Q2225.Enabled = false;
                        Q2226.Enabled = false;
                        Q2227.Enabled = false;
                        Q2228.Enabled = false;
                        Q2229.Enabled = false;
                        Q22210.Enabled = false;
                        Q15.Focus();
                    }
                    else if (Q11.Text == "8")
                    {
                        Q15.Focus();
                        Q13.Enabled = false;
                        Q14.Enabled = false;
                        Q17.Enabled = false;
                    }
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q11_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q11.Text != "1" & Q11.Text != "2" & Q11.Text != "3" & Q11.Text != "4" & Q11.Text != "5" & Q11.Text != "6" & Q11.Text != "7" & Q11.Text != "8")
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

        private void Q12_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (Q11.Text == "1" & Q11.Text == "2")
                    {
                        Q14.Focus();
                        Q13.Enabled = false;
                        Q16.Enabled = false;
                    }
                    else if (Q11.Text == "3" & Q11.Text == "4" & Q11.Text == "5" & Q11.Text == "6" & Q11.Text == "7")
                    {
                        Q13.Enabled = false;
                        Q14.Enabled = false;
                        Q16.Enabled = false;
                        Q17.Enabled = false;
                        Q2211.Enabled = false;
                        Q2212.Enabled = false;
                        Q2213.Enabled = false;
                        Q2214.Enabled = false;
                        Q2215.Enabled = false;
                        Q2216.Enabled = false;
                        Q2221.Enabled = false;
                        Q2222.Enabled = false;
                        Q2223.Enabled = false;
                        Q2224.Enabled = false;
                        Q2225.Enabled = false;
                        Q2226.Enabled = false;
                        Q2227.Enabled = false;
                        Q2228.Enabled = false;
                        Q2229.Enabled = false;
                        Q22210.Enabled = false;
                        Q211.Focus();
                    }
                    else if (Q11.Text == "8")
                    {
                        Q16.Focus();
                        Q13.Enabled = false;
                        Q14.Enabled = false;
                        Q17.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q12_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!Q12.MaskFull)
                {
                    MessageBox.Show("Please insert Visit date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q12.Clear();
                    Q12.Focus();
                }
                else
                {
                    if (IsValidDate(Q12.Text) == false)
                    {
                        MessageBox.Show("Please insert valid Visit date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Q12.Clear();
                        Q12.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q13_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q14.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q13_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q13.Text != "1" & Q13.Text != "2" & Q13.Text != "3")
                {
                    MessageBox.Show("Please insert Q 1.3 a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q13.Clear();
                    Q13.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q14_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q14_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q14.TextLength <= 9 || (Q15.TextLength >= 10 && Q15.TextLength <= 16))
                {
                    MessageBox.Show("Please insert a valid NID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q14.Clear();
                    Q14.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q16_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q17.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q16_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!Q16.MaskFull)
                {
                    MessageBox.Show("Please insert Booster date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q16.Clear();
                    Q16.Focus();
                }
                else
                {
                    if (IsValidDate(Q12.Text) == false)
                    {
                        MessageBox.Show("Please insert valid Booster date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Q16.Clear();
                        Q16.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q17_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q211.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q17_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q17.Text.Length <= 18 )
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q17.Clear();
                    Q17.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q211_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                  if(Q211.Text =="11")
                    {
                        Q212.Focus();
                    }
                  else if (Q11.Text == "3" || Q11.Text == "4" || Q11.Text == "5" || Q11.Text == "6" || Q11.Text == "7")
                    {
                        Q2211.Enabled = false;
                        Q2212.Enabled = false;
                        Q2213.Enabled = false;
                        Q2214.Enabled = false;
                        Q2215.Enabled = false;
                        Q2216.Enabled = false;
                        Q2221.Enabled = false;
                        Q2222.Enabled = false;
                        Q2223.Enabled = false;
                        Q2224.Enabled = false;
                        Q2225.Enabled = false;
                        Q2226.Enabled = false;
                        Q2227.Enabled = false;
                        Q2228.Enabled = false;
                        Q2229.Enabled = false;
                        Q22210.Enabled = false;

                        Q231.Focus();
                    }
                  else
                    {
                        Q2211.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q211_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q211.Text != "1" || Q15.Text != "2" || Q15.Text != "3" || Q15.Text != "4" || Q15.Text != "5" || Q211.Text !="11")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q211.Clear();
                    Q211.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q212_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (Q11.Text == "3" & Q11.Text == "4" & Q11.Text == "5" & Q11.Text == "6" & Q11.Text == "7")
                    {
                        Q2211.Enabled = false;
                        Q2212.Enabled = false;
                        Q2213.Enabled = false;
                        Q2214.Enabled = false;
                        Q2215.Enabled = false;
                        Q2216.Enabled = false;
                        Q2221.Enabled = false;
                        Q2222.Enabled = false;
                        Q2223.Enabled = false;
                        Q2224.Enabled = false;
                        Q2225.Enabled = false;
                        Q2226.Enabled = false;
                        Q2227.Enabled = false;
                        Q2228.Enabled = false;
                        Q2229.Enabled = false;
                        Q22210.Enabled = false;

                        Q231.Focus();
                    }
                    else
                    {
                        Q2211.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q212_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q212.Text == "")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q212.Clear();
                    Q212.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2211_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2211_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2212_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2212_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2213_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2213_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2214_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2214_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2215_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2215_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2216_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2216_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2221_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2221_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2222_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2222_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2223_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2223_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2224_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2224_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2225_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2225_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2226_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2226_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2227_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2227_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2228_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2228_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2229_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2229_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q22210_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q22210_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q231_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q231_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q232_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q232_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q233_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q233_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q234_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q234_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q235_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q235_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q236_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q236_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q237_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q237_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q238_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q238_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q239_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q239_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2310_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2310_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2311_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2311_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2312_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2312_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2313_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2313_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2314_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2314_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q241_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q241_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q242_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q242_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q251_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q251_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q252_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q252_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q253_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q253_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q254_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q254_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q255_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q255_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q256_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q256_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q257_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q257_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q258_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q258_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q259_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q259_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2510_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2510_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q2511_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q2511_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q26_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q26_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q4_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q51_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q51_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q52_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q52_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Q53_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Q16.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Q53_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Q15.Text != "1" & Q15.Text != "2")
                {
                    MessageBox.Show("Please insert a valid Result!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Q15.Clear();
                    Q15.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtinterviewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    txtcrfdate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtinterviewer_Leave(object sender, EventArgs e)
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

        private void txtcrfdate_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtcrfdate_Leave(object sender, EventArgs e)
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



        private void btnexit_Click(object sender, EventArgs e)
        {
        
                Application.Exit();
                this.Close();
           
        }
    }
}
