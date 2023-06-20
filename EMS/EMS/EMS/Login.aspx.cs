using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = Data; Integrated Security = True";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Student WHERE username='" + TextBox5.Text + "' AND password='" + TextBox6.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 1)
            {
                Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                Response.Redirect("New Employee.aspx");
            }
            else
            {
                Response.Write("Invalid Username or Password!");
            }
            con.Close();
        }
    }
}