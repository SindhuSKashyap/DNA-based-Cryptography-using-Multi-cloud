using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class VerificationCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if(Session["VCode"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            if (Session["VCode"] != null)
            {
                if (TxtVerificationCode.Text.Trim() == Session["VCode"].ToString())
                {
                    Session["VCode"] = null;
                    Response.Redirect("~/NewPassword.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Info", "alert('Invalid Verification Code')", true);
                }
            }
        }
    }
}