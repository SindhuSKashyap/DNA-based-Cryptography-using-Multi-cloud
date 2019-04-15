using DNA_DataAccessLayer;
using DNA_TransportLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class MasterCloud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }


        private SqlDataReader reader = null;
        private SqlConnection conn = null;
        private SqlCommand cmd = null;

        protected bool CreateDataBase()
        {
            try
            {
                string ConnectionString = "User Id = " + TxtDBUserName.Text + "; Password = " + TxtDBPassword.Text + ";Initial Catalog=;" + "Data Source=" + TxtDBServerName.Text;
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "CREATE DATABASE " + TxtCloudName.Text + " ON PRIMARY"
                + "(Name=test_data, filename = 'C:\\mysql\\" + TxtCloudName.Text + ".mdf', size=3,"
                + "maxsize=5, filegrowth=10%)log on"
                + "(name=mydbb_log, filename='C:\\mysql\\" + TxtCloudName.Text + ".ldf',size=3,"
                + "maxsize=20,filegrowth=1)";
                if (ExecuteSQLStmt(sql, ""))
                {
                    CreateTable();
                    return true;
                }

                return false;
            }
            catch (Exception er)
            {
                return false;
            }
        }

        protected bool CreateTable()
        {
            try
            {
                bool success = false;
                string ConnectionString = "User Id = " + TxtDBUserName.Text + "; Password = " + TxtDBPassword.Text + ";Initial Catalog= " + TxtCloudName.Text + ";" + "Data Source=" + TxtDBServerName.Text;
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = @"CREATE TABLE [dbo].[tbl_Users](
	[PK_UId] [int] IDENTITY(1,1) NOT NULL,
	[RefId] [int] NOT NULL,
	[Pwd] [varchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Users] PRIMARY KEY CLUSTERED 
(
	[PK_UId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[tbl_Users] ADD  CONSTRAINT [DF_tbl_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]";

                string sql1 = @"CREATE TABLE [dbo].[tbl_Data](
	[PK_DataId] [int] IDENTITY(1,1) NOT NULL,
	[RefId] [int] NULL,
	[DataId] [int] NULL,
	[Title] [varchar](50) NULL,
	[Data] [varchar](max) NULL,
	[UploadedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Data] PRIMARY KEY CLUSTERED 
(
	[PK_DataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[tbl_Data] ADD  CONSTRAINT [DF_tbl_Data_IsActive]  DEFAULT ((1)) FOR [IsActive]";

                if (ExecuteSQLStmt(sql, TxtCloudName.Text))
                {
                    if (ExecuteSQLStmt(sql1, TxtCloudName.Text))
                        success = true;
                }
                else
                {

                    success = false;
                }

                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ExecuteSQLStmt(string sql, string initialcatlog)
        {
            string ConnectionString = "User Id = " + TxtDBUserName.Text + "; Password = " + TxtDBPassword.Text + ";Initial Catalog= " + initialcatlog + "; Data Source=" + TxtDBServerName.Text;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.ConnectionString = ConnectionString;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ae)
            {
                return false;
                //MessageBox.Show(ae.Message.ToString());
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess ob = new DataAccess();
                CloudMaster obj = new CloudMaster();


                if (HiddenID.Value.ToString() != null && HiddenID.Value.ToString() != "")
                {
                    obj.Id = Convert.ToInt32(HiddenID.Value);
                }

                obj.CloudName = TxtCloudName.Text;
                obj.CloudDBServerName = TxtDBServerName.Text;
                obj.CloudDBUserName = TxtDBUserName.Text;
                obj.CloudDBPassword = TxtDBPassword.Text;

                if (BtnSubmit.Text == "Save")
                {
                    if (CreateDataBase())
                    {
                        if (ob.AddCloud(obj))
                        {
                            lblres.Text = "Data Saved Successfully";
                            lblres.CssClass = "alert alert-success";
                            clear();
                            TxtCloudName.Focus();
                        }
                        else
                        {
                            lblres.Text = "Data not Saved";
                            lblres.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        lblres.Text = "Database not created";
                        lblres.CssClass = "alert alert-danger";
                    }
                }
                else if (BtnSubmit.Text == "Update")
                {
                    if (ob.EditCloud(obj))
                    {
                        lblres.Text = "Data Updated Successfully";
                        lblres.CssClass = "alert alert-success";
                        clear();
                        TxtCloudName.Focus();
                    }
                    else
                    {
                        lblres.Text = "Data not updated";
                        lblres.CssClass = "alert alert-danger";
                    }
                }
            }
            catch (Exception ER)
            {

            }
        }

        public void clear()
        {
            BtnSubmit.Text = "Add";
            HiddenID.Value = TxtCloudName.Text = TxtDBPassword.Text = TxtDBServerName.Text = TxtDBUserName.Text = string.Empty;
            LoadGrid();
        }

        public void LoadGrid()
        {
            try
            {
                DataAccess obj = new DataAccess();
                DataTable dt = obj.SelectCloud();
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

        protected void GridCloud_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridCloud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridCloud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    HiddenID.Value = Convert.ToInt32(e.CommandArgument).ToString();
                    Label LblCountry = row.FindControl("LblCloudName") as Label;
                    Label LblCloudDBServerName = row.FindControl("LblCloudDBServerName") as Label;
                    Label LblCloudDBUserName = row.FindControl("LblCloudDBUserName") as Label;
                    Label LblCloudDBPassword = row.FindControl("LblCloudDBPassword") as Label;
                    TxtCloudName.Text = LblCountry.Text;
                    TxtDBServerName.Text = LblCloudDBServerName.Text;
                    TxtDBUserName.Text = LblCloudDBUserName.Text;
                    TxtDBPassword.Text = LblCloudDBPassword.Text;
                    BtnSubmit.Text = "Update";
                    lblres.CssClass = lblres.Text = string.Empty;
                }
                if (e.CommandName == "Delete")
                {
                    DataAccess ob = new DataAccess();
                    CloudMaster obj = new CloudMaster();
                    obj.Id = Convert.ToInt32(e.CommandArgument);
                    DataTable dt = new DataTable();

                    //if (ob.DeleteCountry(obj))
                    //{
                    //    LoadGrid();
                    //    lblres.Text = "Data Deleted Successfully";
                    //    lblres.CssClass = "alert alert-success";
                    //}
                    //else
                    //{
                    //    lblres.Text = "Data not Deleted";
                    //    lblres.CssClass = "alert alert-error";
                    //}
                }
            }
            catch (Exception)
            {

            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            clear();
            lblres.Text = lblres.CssClass = string.Empty;
        }
    }
}