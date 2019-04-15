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
    public partial class UploadData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;

            //return System.Text.Encoding.UTF8.GetString(buffer);
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            ServerInformationandInsert();
        }

        public string GetPart1EncryptionData()
        {

            //string inputContent;
            //using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
            //{
            //    inputContent = inputStreamReader.ReadToEnd();
            //}

            //TxtData.Text = inputContent;

            double lenghtoffile = TxtData.Text.Length;

            double first = 0;
            double second = 0;
            //double third = 0;

            first = Math.Round(lenghtoffile / 2);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize);

            //ReadAllBytes(Server.MapPath(FileUpload1.FileName));
            //ReadAllBytes(Path.GetFileName(FileUpload1.PostedFile.FileName));

            //= FileUpload1.FileContent.Read()
            string valueee = TxtData.Text;
            valueee = valueee.ToString().Replace('o', '^');
            valueee = valueee.ToString().Replace('O', '|');
            valueee = valueee.ToString().Replace('-', ':');
            valueee = valueee.ToString().Replace('~', ' ');           

            string firstpart = valueee.ToString().Substring(0, Convert.ToInt32(first)).ToString();
            //string secondpart = TxtPassword.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();



            StringBuilder sb = new StringBuilder();


            foreach (char c in firstpart.ToCharArray())
            {
                //sb.Append(Convert.ToString(Encoding.ASCII.GetString(c.ToString())));
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

            //string inputContent;
            //using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
            //{
            //    inputContent = inputStreamReader.ReadToEnd();
            //}

            //TxtData.Text = inputContent;
            double lenghtoffile = TxtData.Text.Length;

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


            string valueee = TxtData.Text;
            valueee = valueee.ToString().Replace('o', '^');
            valueee = valueee.ToString().Replace('O', '|');
            valueee = valueee.ToString().Replace('-', ':');
            valueee = valueee.ToString().Replace('~', ' ');          
           

            string firstpart = valueee.ToString().Substring(0, Convert.ToInt32(first)).ToString();
            string secondpart = valueee.ToString().Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
        
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

                        string partpwd = string.Empty;
                        if (j == 0)
                        {
                            partpwd = GetPart1EncryptionData();
                        }
                        else if (j == 1)
                        {
                            partpwd = GetPart2EncryptionData();
                        }

                        if (DataId == "")
                        {

                            SqlConnection con1 = new SqlConnection(ConnectionString);
                            con1.Open();
                            string sql = "select isnull(max(PK_DataId)+1,1) from tbl_Data";
                            SqlCommand cmd = new SqlCommand(sql, con1);
                            SqlDataReader buf = cmd.ExecuteReader();
                            if (buf.Read())
                            {
                                DataId = buf.GetValue(0).ToString();
                            }
                            buf.Close();
                            con1.Close();
                        }

                        //DataTable dt2 = obj.SelectMaxId();
                        //if (dt2 != null && dt2.Rows.Count > 0)
                        //{
                        SqlConnection con = new SqlConnection(ConnectionString);
                        con.Open();
                        string Refid = Session["Id"].ToString();
                        string sqlquery = "insert into tbl_Data (RefId,DataId,Title,Data,UploadedDate) values (" + Refid + "," + DataId + ",'" + TxtTitle.Text + "', '" + partpwd + "','" + System.DateTime.Now.ToString() + "')";
                        SqlCommand cmd1 = new SqlCommand(sqlquery, con);
                        if (cmd1.ExecuteNonQuery() == 1)
                        {
                            resultstatus = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Saved Successfully')", true);
                         
                        }
                        con.Close();
                        //}
                    }
                }

                TxtData.Text = string.Empty;

                return resultstatus;
            }
            catch (Exception er)
            {
                return resultstatus;
            }
        }

        protected void BtnBrowse_Click(object sender, EventArgs e)
        {
            //string text = System.IO.File.ReadAllText(TxtFilePath.Text);

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2 
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file. 
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

        }

        protected void BtnBrowse_Click1(object sender, EventArgs e)
        {
            //string filepath1 = Path.GetFileName(FileUpload1.FileName);
            //string value = FileUpload1.FileName;
            //File.ReadAllText(filepath1);

            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }

            TxtData.Text = inputContent;

        }
    }
}