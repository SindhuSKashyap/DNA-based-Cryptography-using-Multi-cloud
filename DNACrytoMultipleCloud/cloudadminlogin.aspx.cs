using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "cloudadmin" && txtPassword.Text == "cloudadmin")
            {
                Session["Id"] = 1;
                Response.Redirect("~/MasterCloud.aspx");
            }
        }
    }
}