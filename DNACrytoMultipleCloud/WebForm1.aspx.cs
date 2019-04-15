using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNACrytoMultipleCloud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void part2()
        {
            //check for even length

            //double lenghtoffile = TextBox2.Text.Length;

            //double first = 0;
            //double second = 0;
            //double third = 0;

            //first = Math.Round(lenghtoffile / 3);
            //double leftsize = lenghtoffile - first;
            //second = Math.Round(leftsize / 2);
            //third = lenghtoffile - (second + first);

            //string firstpart = TextBox1.Text.Substring(0, Convert.ToInt32(first)).ToString();
            //string secondpart = TextBox1.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
            //string thirdpart = TextBox1.Text.Substring(Convert.ToInt32(first + second), Convert.ToInt32(third)).ToString();

            //StringBuilder sb = new StringBuilder();
            //foreach (char c in firstpart.ToCharArray())
            //{
            //    sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            //}
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
            for (int i = 0; i < TextBox3.Text.Length; i += chunkSize)
            {
                if (i + chunkSize > TextBox3.Text.Length) chunkSize = TextBox3.Text.Length - i;
                string val = (TextBox3.Text.Substring(i, chunkSize));

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

            TextBox6.Text = Valuee;

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

            TextBox11.Text = enrypteddata;
        }

        public void part3()
        {
            string Valuee = string.Empty;

            int chunkSize = 8;
            for (int i = 0; i < TextBox4.Text.Length; i += chunkSize)
            {
                if (i + chunkSize > TextBox4.Text.Length) chunkSize = TextBox4.Text.Length - i;
                string val = (TextBox4.Text.Substring(i, chunkSize));

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

            TextBox7.Text = Valuee;

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

            TextBox12.Text = enrypteddata;

            TextBox15.Text = TextBox10.Text + TextBox11.Text + TextBox12.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //TextBox1.Text = string.Empty;


            string value2;
            string value3;
            int middlePos = 0;
            //check for even length

            double lenghtoffile = TextBox1.Text.Length;

            double first = 0;
            double second = 0;
            double third = 0;

            first = Math.Round(lenghtoffile / 3);
            double leftsize = lenghtoffile - first;
            second = Math.Round(leftsize / 2);
            third = lenghtoffile - (second + first);

            string firstpart = TextBox1.Text.Substring(0, Convert.ToInt32(first)).ToString();
            string secondpart = TextBox1.Text.Substring(Convert.ToInt32(first), Convert.ToInt32(second)).ToString();
            string thirdpart = TextBox1.Text.Substring(Convert.ToInt32(first + second), Convert.ToInt32(third)).ToString();

            StringBuilder sb = new StringBuilder();
            foreach (char c in firstpart.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            TextBox2.Text = sb.ToString();

            StringBuilder sb1 = new StringBuilder();
            foreach (char c in secondpart.ToCharArray())
            {
                sb1.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            TextBox3.Text = sb1.ToString();

            StringBuilder sb2 = new StringBuilder();
            foreach (char c in thirdpart.ToCharArray())
            {
                sb2.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            TextBox4.Text = sb2.ToString();

            string Valuee = string.Empty;

            int chunkSize = 8;
            for (int i = 0; i < TextBox2.Text.Length; i += chunkSize)
            {
                if (i + chunkSize > TextBox2.Text.Length) chunkSize = TextBox2.Text.Length - i;
                string val = (TextBox2.Text.Substring(i, chunkSize));

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

            TextBox5.Text = Valuee;

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

            TextBox10.Text = enrypteddata;


            //if (TextBox1.Text.Length % 2 == 0)
            //{
            //    middlePos = TextBox1.Text.Length / 2;
            //    value2 = TextBox1.Text.Substring(0, middlePos);
            //    value3 = TextBox1.Text.Substring(middlePos);
            //}
            //else
            //{               
            //}
            part2();
            part3();
        }

        public static string BinaryToString(string data)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < TextBox2.Text.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(TextBox2.Text.Substring(i, 8), 2));
            }
            TextBox5.Text = Encoding.ASCII.GetString(byteList.ToArray());

            List<Byte> byteList1 = new List<Byte>();
            for (int i = 0; i < TextBox3.Text.Length; i += 8)
            {
                byteList1.Add(Convert.ToByte(TextBox3.Text.Substring(i, 8), 2));
            }
            TextBox6.Text = Encoding.ASCII.GetString(byteList1.ToArray());

            List<Byte> byteList2 = new List<Byte>();
            for (int i = 0; i < TextBox4.Text.Length; i += 8)
            {
                byteList2.Add(Convert.ToByte(TextBox4.Text.Substring(i, 8), 2));
            }
            TextBox7.Text = Encoding.ASCII.GetString(byteList2.ToArray());
            //TextBox2.Text = string.Empty;
        }

        static int BinarySearch(int[] array, int value)
        {
            int low = 0, high = array.Length - 1, midpoint = 0;

            while (low <= high)
            {
                midpoint = low + (high - low) / 2;

                // check to see if value is equal to item in array
                if (value == array[midpoint])
                {
                    return midpoint;
                }
                else if (value < array[midpoint])
                    high = midpoint - 1;
                else
                    low = midpoint + 1;
            }

            // item was not found
            return -1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int chunkSize = 2;

            //string firstpart = TextBox15.Text.Substring(0, Convert.ToInt32(first)).ToString();

            StringBuilder data1 = new StringBuilder();
            for (int i = 0; i < TextBox15.Text.Length; i += chunkSize)
            {
                chunkSize = 2;
                if (i + chunkSize > TextBox15.Text.Length) chunkSize = TextBox15.Text.Length - i;
                int val1 = Convert.ToInt32(TextBox15.Text.Substring(i, chunkSize));
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

            TextBox16.Text = data1.ToString();

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

            TextBox17.Text = dddd.ToString();

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

            TextBox18.Text = Binaryvalue.ToString();

            TextBox19.Text =  BinaryToString(TextBox18.Text);
        }
    }
}