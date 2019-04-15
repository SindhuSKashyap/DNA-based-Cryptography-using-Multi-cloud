using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class MasterPageMain : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                if (Session["Id"] != null)
                {
                    Welcometext.InnerText = "Welcome " + Session["Name"].ToString();
                }
                else
                {
                    Response.Redirect("~/home/index.aspx");
                }
            //}
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/home/index.aspx");
        }
    }
}