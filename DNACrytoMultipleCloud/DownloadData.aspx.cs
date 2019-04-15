using DNA_DataAccessLayer;
using DNA_TransportLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class DownloadData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadData();
            }
        }

        protected void LoadData()
        {
            DataAccess obj = new DataAccess();
            CloudMaster ob = new CloudMaster();

            ob.Id = Convert.ToInt32(Convert.ToInt32(Session["CSP1"].ToString()));
            DataTable dt = obj.SelectCloudById(ob);
            if (dt != null && dt.Rows.Count > 0)
            {
                string CloudId = dt.Rows[0]["Id"].ToString();
                string CloudName = dt.Rows[0]["CloudName"].ToString();
                string CloudDBServerName = dt.Rows[0]["CloudDBServerName"].ToString();
                string CloudDBUserName = dt.Rows[0]["CloudDBUserName"].ToString();
                string CloudDBPassword = dt.Rows[0]["CloudDBPassword"].ToString();

                string ConnectionString = "User Id = " + CloudDBUserName + "; Password = " + CloudDBPassword + ";Initial Catalog= " + CloudName + "; Data Source=" + CloudDBServerName;

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                DataSet dst = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter("select * from tbl_Data where RefId = " + Session["Id"].ToString() + " order by UploadedDate asc", con);
                dap.Fill(dst, "DataSetName");
                con.Close();

                GridData.DataSource = dst.Tables[0];
                GridData.DataBind();
            }
        }

        protected void GridData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public string GetDataFromServer(string Dataid)
        {
            DataAccess obj = new DataAccess();
            CloudMaster ob = new CloudMaster();

            string Part2data = string.Empty;
            ob.Id = Convert.ToInt32(Convert.ToInt32(Session["CSP2"].ToString()));
            DataTable dt = obj.SelectCloudById(ob);
            if (dt != null && dt.Rows.Count > 0)
            {
                string CloudId = dt.Rows[0]["Id"].ToString();
                string CloudName = dt.Rows[0]["CloudName"].ToString();
                string CloudDBServerName = dt.Rows[0]["CloudDBServerName"].ToString();
                string CloudDBUserName = dt.Rows[0]["CloudDBUserName"].ToString();
                string CloudDBPassword = dt.Rows[0]["CloudDBPassword"].ToString();

                string ConnectionString = "User Id = " + CloudDBUserName + "; Password = " + CloudDBPassword + ";Initial Catalog= " + CloudName + "; Data Source=" + CloudDBServerName;

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                DataSet dst = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from tbl_Data where RefId = " + Session["Id"].ToString() + " and DataId = " + Dataid + " order by UploadedDate asc", con);
                SqlDataReader buf = cmd.ExecuteReader();
                if (buf.Read())
                {
                    Part2data = buf["Data"].ToString();
                }
                buf.Close();
                con.Close();
            }

            return Part2data;
        }

        public void Delete(string Dataid)
        {
            int[] serverid = { Convert.ToInt32(Session["CSP1"].ToString()), Convert.ToInt32(Session["CSP2"].ToString()) };
            bool resultstatus = false;
            try
            {
                string DataId = string.Empty;
               DataAccess obj = new DataAccess();


                CloudMaster ob = new CloudMaster();
                for (int j = 0; j < serverid.Length; j++)
                {
                    ob.Id = Convert.ToInt32(serverid[j].ToString());
                    DataTable dt = obj.SelectCloudById(ob);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string CloudId = dt.Rows[0]["Id"].ToString();
                        string CloudName = dt.Rows[0]["CloudName"].ToString();
                        string CloudDBServerName = dt.Rows[0]["CloudDBServerName"].ToString();
                        string CloudDBUserName = dt.Rows[0]["CloudDBUserName"].ToString();
                        string CloudDBPassword = dt.Rows[0]["CloudDBPassword"].ToString();

                        string ConnectionString = "User Id = " + CloudDBUserName + "; Password = " + CloudDBPassword + ";Initial Catalog= " + CloudName + "; Data Source=" + CloudDBServerName;


                        SqlConnection con = new SqlConnection(ConnectionString);
                        con.Open();
                        string Refid = Session["Id"].ToString();
                        string sqlquery = "delete from  tbl_Data where DataId = " + Dataid + "";
                        SqlCommand cmd1 = new SqlCommand(sqlquery, con);
                        if (cmd1.ExecuteNonQuery() == 1)
                        {
                            resultstatus = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Deleted Successfully')", true);
                            LoadData();
                            
                        }
                        con.Close();

                        //}
                    }
                }

                TxtData.Text = string.Empty;

                //return resultstatus;
            }
            catch (Exception er)
            {
                //return resultstatus;
            }
        }

        protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Download")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    HiddenField HiddenId = row.FindControl("HiddenId") as HiddenField;
                    HiddenField HiddenDataId = row.FindControl("HiddenDataId") as HiddenField;
                    HiddenField HiddenData = row.FindControl("HiddenData") as HiddenField;
                    Label LblTitle = row.FindControl("LblTitle") as Label;
                    Label LblUploadedDate = row.FindControl("LblUploadedDate") as Label;

                    string part2data = GetDataFromServer(HiddenDataId.Value);
                    string data = HiddenData.Value + part2data;

                    string originaldata = GetData(data);

                    string data1 = originaldata.Replace('^', 'o');
                    string data2 = data1.Replace('|', 'O');
                    string data3 = data2.Replace(':', '-');
                    string data4 = data3.Replace('~', ' ');                                  

                    //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    //// Create a stringbuilder and write the new user input to it.
                    //StringBuilder sb = new StringBuilder();

                    //sb.AppendLine("New User Input");
                    //sb.AppendLine("= = = = = =");
                    ////sb.Append(UserInputTextBox.Text);
                    //sb.AppendLine();
                    //sb.AppendLine();

                    // Open a streamwriter to a new text file named "UserInputFile.txt"and write the contents of 
                    // the stringbuilder to it. 
                    //using (StreamWriter outfile = new StreamWriter(mydocpath + @"\UserInputFile.docx", true))
                    //{
                    //    outfile.WriteAsync(data2);
                    //}

                    TxtData.Text = data4;

                    TxtTitle.Text = LblTitle.Text;

                }

                if (e.CommandName == "Delete")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    HiddenField HiddenId = row.FindControl("HiddenId") as HiddenField;
                    HiddenField HiddenDataId = row.FindControl("HiddenDataId") as HiddenField;
                    HiddenField HiddenData = row.FindControl("HiddenData") as HiddenField;

                    Delete(HiddenId.Value.ToString());
                }
            }
            catch (Exception)
            {

            }
        }

        protected void GridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected string GetData(string Password)
        {
            int chunkSize = 2;

            //string firstpart = TextBox15.Text.Substring(0, Convert.ToInt32(first)).ToString();

            StringBuilder data1 = new StringBuilder();
            for (int i = 0; i < Password.Length; i += chunkSize)
            {
                chunkSize = 2;
                if (i + chunkSize > Password.Length) chunkSize = Password.Length - i;
                int val1 = Convert.ToInt32(Password.Substring(i, chunkSize));
                if (val1 > 16)
                {
                    chunkSize = 1;
                    string firstpart = val1.ToString().Substring(0, 1).ToString();
                    for (int l = 0; l < DNA.DNASequnceIdValue1.Length; l++)
                    {
                        if (firstpart == DNA.DNASequnceIdValue1[l].ToString())
                        {
                            data1.Append(DNA.DNASequnceId1[l].ToString());
                            chunkSize = 2;
                            i = i - 1;
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 0; l < DNA.DNASequnceIdValue1.Length; l++)
                    {
                        if (val1.ToString() == DNA.DNASequnceIdValue1[l].ToString())
                        {
                            data1.Append(DNA.DNASequnceId1[l].ToString());
                            break;
                        }
                    }
                }
            }

            //TextBox16.Text = data1.ToString();

            int chunkSize2 = 1;

            string vv = data1.ToString();
            StringBuilder dddd = new StringBuilder();

            for (int i = 0; i < vv.Length; i += chunkSize2)
            {
                if (i + chunkSize2 > vv.Length) chunkSize2 = vv.ToString().Length - i;
                string val1 = (vv.ToString().Substring(i, chunkSize2));
                for (int k = 0; k < DNA.DNASubPart2ValueS1.Length; k++)
                {
                    if (val1.ToString() == DNA.DNASubPart2ValueS1[k].ToString())
                    {
                        dddd.Append(DNA.DNASubPart2KeyS1[k].ToString());
                        break;
                    }
                }
            }

            //TextBox17.Text = dddd.ToString();

            StringBuilder Binaryvalue = new StringBuilder();

            int chunkSize1 = 1;
            for (int j = 0; j < dddd.Length; j += chunkSize1)
            {
                if (j + chunkSize1 > dddd.Length) chunkSize1 = dddd.Length - j;
                string val1 = (dddd.ToString().Substring(j, chunkSize1));
                for (int k = 0; k < DNA.DNASubPart1Key.Length; k++)
                {
                    if (val1 == DNA.DNASubPart1Key[k].ToString())
                    {
                        Binaryvalue.Append(DNA.DNASubPart1Value[k].ToString());
                        break;
                    }
                }
            }

            //TextBox18.Text = Binaryvalue.ToString();

            return BinaryToString(Binaryvalue.ToString());

            //TextBox19.Text = BinaryToString(Binaryvalue);
        }

        public string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();
            try
            {
                for (int i = 0; i < data.Length; i += 8)
                {
                    byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
                }

                return Encoding.ASCII.GetString(byteList.ToArray());
            }
            catch (Exception er)
            {
                return Encoding.ASCII.GetString(byteList.ToArray());
            }
        }

    }
}