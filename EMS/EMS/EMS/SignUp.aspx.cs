using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace EMS
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstr = @"Data Source=.;Initial Catalog=Data;                     Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionstr;
            con.Open();
            string commandstr = "Insert into Student(ID, Name, City,Program,Username,Password)" +
                            " Values('" + Convert.ToInt32(TextBox1.Text) + "'," +
                            "'" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "') ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandstr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}