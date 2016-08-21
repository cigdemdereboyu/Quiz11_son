using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz11
{
    public partial class Anasayfa : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection("Server=.;database=Quiz11Blog;Trusted_Connection=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Konu",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repeater1.DataSource = dt;
            repeater1.DataBind();

            Random rn = new Random();
            SqlDataAdapter dasoz = new SqlDataAdapter("select * from Soz",con);
            DataTable dtsoz = new DataTable();
            dasoz.Fill(dtsoz);

            lblsoz.Text = dtsoz.Rows[rn.Next(0, dtsoz.Rows.Count)][1].ToString();


            SqlDataAdapter da2 = new SqlDataAdapter("select Id,Concat(Ad,' ',Soyad) as AdSoyad from Kisi", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            repeaterprofil.DataSource = dt2;
            repeaterprofil.DataBind();

         

            }
    }
}