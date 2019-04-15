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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPrimaryCloud();
            }
        }

        public void LoadPrimaryCloud()
        {
            try
            {
                DataAccess obj = new DataAccess();
                DataTable dt = obj.SelectCloud();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DropdownPrimary.DataSource = dt;
                    DropdownPrimary.DataTextField = "CloudName";
                    DropdownPrimary.DataValueField = "Id";
                    DropdownPrimary.DataBind();

                    ListItem lstitem = new ListItem(" -- Select Primary Cloud---", "-1");
                    DropdownPrimary.Items.Insert(0, lstitem);
                }
            }
            catch (Exception)
            {

            }
        }

        public void LoadSecondaryCloud()
        {
            try
            {
                DataAccess obj = new DataAccess();
                CloudMaster ob = new CloudMaster();
                ob.Id = Convert.ToInt32(DropdownPrimary.SelectedValue);
                DataTable dt = obj.SelectByIdothercloud(ob);

                if (DropdownPrimary.SelectedValue == "-1")
                {
                    DropDownSecondary.DataSource = null;
                    DropDownSecondary.DataBind();
                    return;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DropDownSecondary.DataSource = dt;
                    DropDownSecondary.DataTextField = "CloudName";
                    DropDownSecondary.DataValueField = "Id";
                    DropDownSecondary.DataBind();

                    ListItem lstitem = new ListItem(" -- Select Secondary Cloud---", "-1");
                    DropDownSecondary.Items.Insert(0, lstitem);
                }
            }
            catch (Exception er)
            {

            }
        }

        protected void clear()
        {
            TxtEmail.Text = TxtPassword.Text = TxtPhoneNo.Text = TxtUserName.Text = string.Empty;
            DropdownPrimary.ClearSelection();
            DropDownSecondary.ClearSelection();
        }

        public string GetPart1EncryptionData()
        {
            double lenghtoffile = TxtPassword.Text.Length;

            double first = 0;
            double second = 0;
            //double third = 0;

            first = Math.Round(lenghtoffile / 2);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize);

            string firstpart = TxtPassword.Text.Substring(0, Convert.ToInt32(first)).ToString();
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
            double lenghtoffile = TxtPassword.Text.Length;

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

            string firstpart = TxtPassword.Text.Substring(0, Convert.ToInt32(first)).ToString();
            string secondpart = TxtPassword.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
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

        public bool ServerInformationandInsert()
        {
            int[] serverid = { Convert.ToInt32(DropdownPrimary.SelectedValue), Convert.ToInt32(DropDownSecondary.SelectedValue) };
            bool resultstatus = false;
            try
            {
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
                            string sqlquery = "insert into tbl_Users (RefId,Pwd) values (" + Refid + ", " + partpwd + ")";
                            SqlCommand cmd = new SqlCommand(sqlquery, con);
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                resultstatus = true;
                            }
                            con.Close();
                        }
                    }
                }

                return resultstatus;
            }
            catch (Exception er)
            {
                return resultstatus;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {            
            DataAccess ob = new DataAccess();
            UserRegistration obj = new UserRegistration();

            obj.UserName = TxtUserName.Text;
            obj.PhoneNo = TxtPhoneNo.Text;
            obj.EmailId = TxtEmail.Text;
            obj.CSP1 = Convert.ToInt32(DropdownPrimary.SelectedValue);
            obj.CSP2 = Convert.ToInt32(DropDownSecondary.SelectedValue);

            //SqlConnection con = new SqlConnection("Data Source=192.168.0.18;initial catalog=DNADB;user id = sa; password=vss;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("insert into tbl_UserRegistration ( UserName, PhoneNo, EmailId, CSP1, CSP2) values ('" + TxtUserName.Text + "','" + TxtPhoneNo.Text + "','" + TxtEmail.Text + "'," + DropdownPrimary.SelectedValue + "," + DropDownSecondary.SelectedValue + ")", con);
            //if (cmd.ExecuteNonQuery() == 1)
            //{
            //    lblres.Text = "Registration Success";
            //    lblres.CssClass = "alert alert-success";
            //    return;
            //}
            //con.Close();


            if (ob.CheckUserNameAvailable(obj))
            {
                if (ServerInformationandInsert())
                {
                    if (ob.AddUserRegistration(obj))
                    {
                        string value = "Dear " + TxtUserName.Text + ",</br></br> Thank you for registering in multi cloud.";
                        ob.SendMail(TxtEmail.Text, value, "Greeting from Cloud");
                        lblres.Text = "Registration Success";
                        lblres.CssClass = "alert alert-success";
                        clear();
                        TxtUserName.Focus();
                    }
                    else
                    {
                        lblres.Text = "Registration not done";
                        lblres.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblres.Text = "Server not available";
                    lblres.CssClass = "alert alert-danger";
                }
            }
            else
            {
                lblres.Text = "Email Address already exists";
                lblres.CssClass = "alert alert-danger";
                TxtEmail.Focus();
            }
        }

        protected void DropdownPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSecondaryCloud();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            DataAccess ob = new DataAccess();
            UserRegistration obj = new UserRegistration();

            obj.UserName = TxtUserName.Text;
            obj.PhoneNo = TxtPhoneNo.Text;
            obj.EmailId = TxtEmail.Text;
            obj.CSP1 = Convert.ToInt32(DropdownPrimary.SelectedValue);
            obj.CSP2 = Convert.ToInt32(DropDownSecondary.SelectedValue);
            if (ServerInformationandInsert())
            {
                if (ob.AddUserRegistration(obj))
                {
                    lblres.Text = "Registration Success";
                    lblres.CssClass = "alert alert-success";
                    clear();
                    TxtUserName.Focus();
                }
                else
                {
                    lblres.Text = "Registration not done";
                    lblres.CssClass = "alert alert-danger";
                }
            }
            else
            {
                lblres.Text = "Server not available";
                lblres.CssClass = "alert alert-danger";
            }
        }
    }
}