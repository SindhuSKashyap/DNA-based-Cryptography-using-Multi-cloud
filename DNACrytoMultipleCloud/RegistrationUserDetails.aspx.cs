using DNA_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class RegistrationUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            try
            {
                DataAccess obj = new DataAccess();
                DataTable dt = obj.SelectCloudUserDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridCloud.DataSource = dt;
                    GridCloud.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}