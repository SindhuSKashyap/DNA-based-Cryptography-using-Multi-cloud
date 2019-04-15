using DNA_DataAccessLayer;
using DNA_TransportLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class NewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNewPassword.Text == TxtConfirmPassword.Text)
                {

                    if (Session["Email"] != null)
                    {
                        string id = string.Empty;
                        DataAccess obj1 = new DataAccess();
                        UserRegistration ob1 = new UserRegistration();
                        ob1.EmailId = Session["Email"].ToString(); ;
                        DataTable dt = obj1.SelectDataByEmailId(ob1);
                        StringBuilder pwd = new StringBuilder();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            id = dt.Rows[0]["PK_UserID"].ToString();
                            Session["Name"] = dt.Rows[0]["UserName"].ToString();
                            Session["Id"] = id.ToString();
                            Session["CSP1"] = dt.Rows[0]["CSP1"].ToString();
                            Session["CSP2"] = dt.Rows[0]["CSP2"].ToString();

                            int[] serverid = { Convert.ToInt32(dt.Rows[0]["CSP1"].ToString()), Convert.ToInt32(dt.Rows[0]["CSP2"].ToString()) };

                            DataAccess obj = new DataAccess();
                            CloudMaster ob = new CloudMaster();
                            for (int j = 0; j < serverid.Length; j++)
                            {
                                ob.Id = Convert.ToInt32(serverid[j].ToString());
                                DataTable dt1 = obj.SelectCloudById(ob);
                                if (dt1 != null && dt1.Rows.Count > 0)
                                {
                                    string CloudId = dt1.Rows[0]["Id"].ToString();
                                    string CloudName = dt1.Rows[0]["CloudName"].ToString();
                                    string CloudDBServerName = dt1.Rows[0]["CloudDBServerName"].ToString();
                                    string CloudDBUserName = dt1.Rows[0]["CloudDBUserName"].ToString();
                                    string CloudDBPassword = dt1.Rows[0]["CloudDBPassword"].ToString();

                                    string ConnectionString = "User Id = " + CloudDBUserName + "; Password = " + CloudDBPassword + ";Initial Catalog= " + CloudName + "; Data Source=" + CloudDBServerName;

                                    string partpwd = string.Empty;
                                    if (j == 0)
                                    {
                                        partpwd = GetPart1EncryptionData();
                                    }
                                    else if (j == 1)
                                    {
                                        partpwd = GetPart2EncryptionData();
                                    }

                                    DataTable dt2 = obj.SelectMaxId();
                                    if (dt2 != null && dt2.Rows.Count > 0)
                                    {
                                        SqlConnection con = new SqlConnection(ConnectionString);
                                        con.Open();
                                        string Refid = dt2.Rows[0][0].ToString();
                                        string sqlquery = "update tbl_Users set Pwd = '" + partpwd + "' where RefId = " + id + "";
                                        SqlCommand cmd = new SqlCommand(sqlquery, con);
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "info", "alert('Password has been Updated Successfully')", true);
                                        }
                                        con.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "info", "alert('New Password and Confirm password mismatch')", true);
                    TxtConfirmPassword.Text = TxtNewPassword.Text = string.Empty;
                }
            }
            catch (Exception er)
            {

            }
        }
        public string GetPart1EncryptionData()
        {
            double lenghtoffile = TxtNewPassword.Text.Length;

            double first = 0;
            double second = 0;
            //double third = 0;

            first = Math.Round(lenghtoffile / 2);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize);

            string firstpart = TxtNewPassword.Text.Substring(0, Convert.ToInt32(first)).ToString();
            //string secondpart = TxtPassword.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();

            StringBuilder sb = new StringBuilder();
            foreach (char c in firstpart.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            //TextBox2.Text = sb.ToString();

            //StringBuilder sb1 = new StringBuilder();
            //foreach (char c in secondpart.ToCharArray())
            //{
            //    sb1.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            //}
            //TextBox3.Text = sb1.ToString();

            //StringBuilder sb2 = new StringBuilder();
            //foreach (char c in thirdpart.ToCharArray())
            //{
            //    sb2.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            //}
            //TextBox4.Text = sb2.ToString();

            string Valuee = string.Empty;

            int chunkSize = 8;
            for (int i = 0; i < sb.ToString().Length; i += chunkSize)
            {
                if (i + chunkSize > sb.ToString().Length) chunkSize = sb.ToString().Length - i;
                string val = (sb.ToString().Substring(i, chunkSize));

                int chunkSize1 = 2;
                for (int j = 0; j < val.Length; j += chunkSize1)
                {
                    if (j + chunkSize1 > val.Length) chunkSize1 = val.Length - j;
                    string val1 = (val.Substring(j, chunkSize1));

                    for (int k = 0; k < DNA.DNASubPart1Value.Length; k++)
                    {
                        if (val1 == DNA.DNASubPart1Value[k].ToString())
                        {
                            string key = DNA.DNASubPart1Key[k].ToString();

                            for (int l = 0; l < DNA.DNASubPart2ValueS1.Length; l++)
                            {
                                if (key == DNA.DNASubPart2KeyS1[l].ToString())
                                {
                                    Valuee = Valuee + DNA.DNASubPart2ValueS1[l].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //TextBox5.Text = Valuee;

            string enrypteddata = string.Empty;
            int chunkSize11 = 2;
            for (int j = 0; j < Valuee.ToString().Length; j += chunkSize11)
            {
                if (j + chunkSize11 > Valuee.Length) chunkSize11 = Valuee.Length - j;
                string val1 = (Valuee.Substring(j, chunkSize11));
                for (int l = 0; l < DNA.DNASequnceId1.Length; l++)
                {
                    if (val1 == DNA.DNASequnceId1[l].ToString())
                    {
                        enrypteddata = enrypteddata + DNA.DNASequnceIdValue1[l].ToString();
                        break;
                    }
                }
            }

            return enrypteddata;
        }

        public string GetPart2EncryptionData()
        {
            double lenghtoffile = TxtNewPassword.Text.Length;

            double first = 0;
            double second = 0;
            double third = 0;

            //first = Math.Round(lenghtoffile / 3);
            //double leftsize = lenghtoffile - first;
            //second = Math.Round(leftsize / 2);
            //third = lenghtoffile - (second + first);

            first = Math.Round(lenghtoffile / 2);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize);
            //third = lenghtoffile - (second + first);

            string firstpart = TxtNewPassword.Text.Substring(0, Convert.ToInt32(first)).ToString();
            string secondpart = TxtNewPassword.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
            //string thirdpart = TxtPassword.Text.Substring(Convert.ToInt32(first + second), Convert.ToInt32(third)).ToString();

            //StringBuilder sb = new StringBuilder();
            //foreach (char c in firstpart.ToCharArray())
            //{
            //    sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            //}
            //TextBox2.Text = sb.ToString();

            StringBuilder sb = new StringBuilder();
            foreach (char c in secondpart.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            //TextBox3.Text = sb1.ToString();

            //StringBuilder sb2 = new StringBuilder();
            //foreach (char c in thirdpart.ToCharArray())
            //{
            //    sb2.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            //}
            //TextBox4.Text = sb2.ToString();

            string Valuee = string.Empty;

            int chunkSize = 8;
            for (int i = 0; i < sb.ToString().Length; i += chunkSize)
            {
                if (i + chunkSize > sb.ToString().Length) chunkSize = sb.ToString().Length - i;
                string val = (sb.ToString().Substring(i, chunkSize));

                int chunkSize1 = 2;
                for (int j = 0; j < val.Length; j += chunkSize1)
                {
                    if (j + chunkSize1 > val.Length) chunkSize1 = val.Length - j;
                    string val1 = (val.Substring(j, chunkSize1));

                    for (int k = 0; k < DNA.DNASubPart1Value.Length; k++)
                    {
                        if (val1 == DNA.DNASubPart1Value[k].ToString())
                        {
                            string key = DNA.DNASubPart1Key[k].ToString();

                            for (int l = 0; l < DNA.DNASubPart2ValueS1.Length; l++)
                            {
                                if (key == DNA.DNASubPart2KeyS1[l].ToString())
                                {
                                    Valuee = Valuee + DNA.DNASubPart2ValueS1[l].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //TextBox5.Text = Valuee;

            string enrypteddata = string.Empty;
            int chunkSize11 = 2;
            for (int j = 0; j < Valuee.ToString().Length; j += chunkSize11)
            {
                if (j + chunkSize11 > Valuee.Length) chunkSize11 = Valuee.Length - j;
                string val1 = (Valuee.Substring(j, chunkSize11));
                for (int l = 0; l < DNA.DNASequnceId1.Length; l++)
                {
                    if (val1 == DNA.DNASequnceId1[l].ToString())
                    {
                        enrypteddata = enrypteddata + DNA.DNASequnceIdValue1[l].ToString();
                        break;
                    }
                }
            }

            return enrypteddata;
        }
    }
}