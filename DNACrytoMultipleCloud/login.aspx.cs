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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetPart1EncryptionData(string Password)
        {
            double lenghtoffile = Password.Length;

            double first = 0;
            double second = 0;
            //double third = 0;

            first = Math.Round(lenghtoffile / 2);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize);

            string firstpart = Password.Substring(0, Convert.ToInt32(first)).ToString();
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

        public string GetPart2EncryptionData(string Password)
        {
            double lenghtoffile = Password.Length;

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

            //string firstpart = Password.Substring(0, Convert.ToInt32(first)).ToString();
            string secondpart = Password.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
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

        public string GetPassword()
        {
            string id = string.Empty;
            DataAccess obj = new DataAccess();
            UserRegistration ob = new UserRegistration();
            ob.EmailId = txtUserName.Text;
            DataTable dt = obj.SelectDataByEmailId(ob);
            StringBuilder pwd = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["PK_UserID"].ToString();
                Session["Name"] = dt.Rows[0]["UserName"].ToString();
                Session["Id"] = id.ToString();
                Session["CSP1"] = dt.Rows[0]["CSP1"].ToString();
                Session["CSP2"] = dt.Rows[0]["CSP2"].ToString();

                int[] serverid = { Convert.ToInt32(dt.Rows[0]["CSP1"].ToString()), Convert.ToInt32(dt.Rows[0]["CSP2"].ToString()) };


                bool resultstatus = false;
                try
                {
                    DataAccess obj1 = new DataAccess();
                    CloudMaster ob1 = new CloudMaster();
                    for (int j = 0; j < serverid.Length; j++)
                    {
                        ob1.Id = Convert.ToInt32(serverid[j].ToString());
                        DataTable dt11 = obj1.SelectCloudById(ob1);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string CloudId = dt11.Rows[0]["Id"].ToString();
                            string CloudName = dt11.Rows[0]["CloudName"].ToString();
                            string CloudDBServerName = dt11.Rows[0]["CloudDBServerName"].ToString();
                            string CloudDBUserName = dt11.Rows[0]["CloudDBUserName"].ToString();
                            string CloudDBPassword = dt11.Rows[0]["CloudDBPassword"].ToString();

                            string ConnectionString = "User Id = " + CloudDBUserName + "; Password = " + CloudDBPassword + ";Initial Catalog= " + CloudName + "; Data Source=" + CloudDBServerName;

                            SqlConnection con = new SqlConnection(ConnectionString);
                            con.Open();
                            string sqlquery = "select * from tbl_Users where RefId = " + id;
                            SqlCommand cmd = new SqlCommand(sqlquery, con);
                            SqlDataReader buf = cmd.ExecuteReader();
                            if (buf.Read())
                            {
                                resultstatus = true;
                                pwd.Append(buf["Pwd"].ToString());
                            }
                            buf.Close();
                            con.Close();
                        }
                    }
                }
                catch (Exception er)
                {
                    return "";
                }

                //string orginialpwd = GetData(pwd.ToString());
            }
            else
            {
                lblres.Text = "Invalid UserName"; 
            }

            return pwd.ToString();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string firstpart = GetPart1EncryptionData(txtPassword.Text);
            string secondpart = GetPart2EncryptionData(txtPassword.Text);
            string storedpasswrd = GetPassword();
            if (storedpasswrd == firstpart + secondpart)
            {
                Response.Redirect("~/HomePage.aspx");
            }
            else
            {
                lblres.Text = "Invalid Password";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Info", "alert('Invalid UserName / Password')", true);
            }
        }

        protected void BtnForgotPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgotPassword.aspx");
        }
    }
}