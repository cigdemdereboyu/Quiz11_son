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
    public partial class Content : System.Web.UI.Page
    {
        int ids;
        SqlConnection con = new SqlConnection("Server=.;database=Quiz11Blog;Trusted_Connection=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ids = Convert.ToInt32(Request.QueryString["cid"]);
            if (ids != null)
            {

                SqlDataAdapter da3 = new SqlDataAdapter("select Ad,Soyad,[Dogum Yeri],[Dogum Tarihi],[Mezun Olunan Okul],[Mezun Olunan Bölüm],Mail from Kisi where Id=@id", con);

                da3.SelectCommand.Parameters.AddWithValue("@id", ids);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                grid.DataSource = dt3;
                grid.DataBind();


            }

        
        }
    }
}