using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CazStudy
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static SqlConnection ServerCon()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DT-6728\SQLEXPRESS;Initial Catalog=scov;User ID=sa;Password=F@ridul123");
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Error with the database connection");
            }
            return con;
        }

        public static void Datamanip(string SQLString)
        {
            SqlConnection con = Program.ServerCon();
            SqlCommand cmdsql = new SqlCommand(SQLString, con);
            try
            {
                con.Open();
                cmdsql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool Exists(string SQLString)
        {
            bool GetValue = false;
            SqlConnection con = Program.ServerCon();
            SqlCommand cmdsql = new SqlCommand(SQLString, con);

            try
            {
                con.Open();
                object Found = cmdsql.ExecuteScalar();
                if (Found == null)
                {
                    GetValue = false;
                }
                else
                {
                    GetValue = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return GetValue;
        }
    }
}
