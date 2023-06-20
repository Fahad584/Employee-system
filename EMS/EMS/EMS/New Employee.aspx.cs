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
    public partial class New_Employee : System.Web.UI.Page
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
            string commandstr = "Insert into employee(ID, Name, Fname, City, Education, Phone, Address, Email)" +
                            " Values('" + Convert.ToInt32(TextBox1.Text) + "'," +
                            "'" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "') ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandstr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pathstr = @"Data Source=.;Initial Catalog=Data;
                                   Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = pathstr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update employee SET Name='" + TextBox2.Text + "', Fname='" + TextBox3.Text + "',City='" + TextBox4.Text + "',Education='" + TextBox5.Text + "',Phone='" + TextBox6.Text + "',Address='" + TextBox7.Text + "',Email='" + TextBox8.Text + "' Where ID='" + Convert.ToInt32(TextBox1.Text) + "'";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string pathstr = @"Data Source=.;Initial Catalog=Data;
                                   Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = pathstr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete From employee Where ID='" + Convert.ToInt32(TextBox1.Text) + "'";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connectionstr = @"Data Source=.;Initial Catalog=Data;
                                   Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionstr;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *From employee", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            con.Close();
            Display();
        }
        public void Display()
        {
            string connectionstr = @"Data Source=.;Initial Catalog=Data;
                                   Integrated Security=True";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionstr;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *From employee", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}