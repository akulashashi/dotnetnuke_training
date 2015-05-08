using System;
using System.Data;
using System.Web;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
//using bhattji.Modules.YouTubeVideos.Business;

namespace bhattji.Modules.YouTubeVideos
{
    public static class StringHelper
    {
        //public static string FormatPhoneNo(string thisString)
        public static string FormatPhoneNo(this string thisString)
        {
            string strPhoneNo = thisString.StripPhoneNo();
            try
            {
                int L = strPhoneNo.Length;
                if (L < 5)
                    return strPhoneNo;
                else if (L < 8)
                    return string.Format("{0}-{1}", strPhoneNo.Substring(0, L - 4), strPhoneNo.Substring(L - 4));
                else if (L < 11)
                    return string.Format("({0}){1}-{2}", strPhoneNo.Substring(0, L - 7), strPhoneNo.Substring(L - 7, 3), strPhoneNo.Substring(L - 4));
                else
                    return string.Format("+{0}({1}){2}-{3}", strPhoneNo.Substring(0, L - 10), strPhoneNo.Substring(L - 10, 3), strPhoneNo.Substring(L - 7, 3), strPhoneNo.Substring(L - 4));
            }
            catch
            {
                return strPhoneNo;
            }
        }

        //public static string StripPhoneNo(string thisString)
        public static string StripPhoneNo(this string thisString)
        {
            return thisString.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(",", "").Replace(".", "");
        }

        public static bool IsValidEmail(this string thisString) 
        {
            //return IsValidEmail(thisString, false);
            return thisString.IsValidEmail(false);
        }
        public static bool IsValidEmail(this string thisString, bool useRegix)
        {
            if (useRegix)
            {
                // Return true if eMail is in valid e-mail format. using System.Text.RegularExpressions.Regex class
                return System.Text.RegularExpressions.Regex.IsMatch(thisString,
                       @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            }
            else
            {
                // Return true if eMail is in valid e-mail format. using System.Net.Mail.MailAddress class
                try
                {
                    System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(thisString);
                    return true;
                }
                catch { return false; }
            }
        }
    }
    
    /// <summary>
    /// Summary description for NumberHelper
    /// </summary>
    public static class NumberHelper
    {
        static string[] Number2Word = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };
        static string[] Tens2Word = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
        //static string[] PlaceValueHi = {"","Thousand", "Lac", "Crore", "Arab", "Kharab", "Nikharab", "Shanku", "Jaladhi", "Padma"};

        public static string ToDigits(this string thisString)
        {
            string s = "";
            foreach (char c in thisString.ToCharArray())
            {
                if (c == '0')
                    s += "Zero ";
                else
                    s += Number2Word[(int)c - 48] + " ";
                //s += c.ToString().ToWords() + " ";
            }
            return s;
        }
        //public static string ToWordsUpto99(int N99)
        //{
        //    int n = N99 % 100;
        //    if (n < 20)
        //        return Number2Word[n];
        //    else
        //        return Tens2Word[n / 10] + Number2Word[n % 10];
        //    //return Tens2Word[(int)(n / 10)] + Number2Word[n % 10];
        //}
        //public static string ToWordsUpto999(int N999)
        //{
        //    int n = N999 % 1000;
        //    if (n < 100)
        //        return ToWordsUpto99(n);
        //    else
        //        return Number2Word[n / 100] + " Hundred " + ToWordsUpto99(n % 100);
        //    //return Number2Word[(int)(n / 100)] + " Hundred " + ToWordsUpto99(n % 100);
        //}
        public static string ToWordsUpto999(int N999)
        {
            string s = "";
            int i = N999 % 1000;
            if (i > 99) s = Number2Word[i / 100] + " Hundred ";
            i = i % 100;
            if (i > 19)
                s += Tens2Word[i / 10] + Number2Word[i % 10];
            else
                s += Number2Word[i];
            return s;
        }

        public static string ToWords(this long Number)
        {
            string[] PlaceValueHi = { "Thousand", "Lac", "Crore", "Arab", "Kharab", "Nikharab", "Padma", "MahaPadma", "Shanku", "Jaladhi", "Antya", "Madhya", "Parardh" };
            long j = Number;
            string Words = ToWordsUpto999((int)(j % 1000));
            j = j / 1000;
            int p = 0;
            while ((j > 0) && (p < PlaceValueHi.Length))
            {
                Words = ToWordsUpto999((int)(j % 100)) + " " + PlaceValueHi[p] + " " + Words;

                j = j / 100;
                p++;
            }
            return Words;
        }
        public static string ToWordsEn(this long Number)
        {
            string[] PlaceValueEn = { "Thousand", "Million", "Trillion" };
            long j = Number;
            string Words = ToWordsUpto999((int)(j % 1000));
            j = j / 1000;
            int p = 0;
            while ((j > 0) && (p < PlaceValueEn.Length))
            {
                Words = ToWordsUpto999((int)(j % 1000)) + " " + PlaceValueEn[p] + " " + Words;
                j = j / 1000;
                p++;
            }
            return Words;
        }

        public static string ToWords(this string thisString)
        {
            string[] arr = thisString.Replace(" ", "").Replace(",", "").Split('.');
            string s = "";
            if (!string.IsNullOrEmpty(arr[0])) s += long.Parse(arr[0]).ToWords();
            if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1])) s += " Decimal " + arr[1].ToDigits();
            return s.Trim().Replace("  ", " ");
        }
        public static string ToWordsEn(this string thisString)
        {
            string[] arr = thisString.Replace(" ", "").Replace(",", "").Split('.');
            string s = "";
            if (!string.IsNullOrEmpty(arr[0])) s += long.Parse(arr[0]).ToWordsEn();
            if (arr.Length > 1 && !string.IsNullOrEmpty(arr[1])) s += " Decimal " + arr[1].ToDigits();
            return s.Trim().Replace("  ", " ");
        }

        public static string ToRupees(this string thisString)
        {
            string[] arr = thisString.Replace(" ", "").Replace(",", "").Split('.');
            string s = "";
            long r = long.Parse("0" + arr[0]);
            if (r > 0) s += "Rupees " + r.ToWords();
            if (arr.Length > 1)
            {
                int p = int.Parse((arr[1] + "00").Substring(0, 2));
                if (p > 0) s += " Paise " + ToWordsUpto999(p);
            }
            return s.Trim().Replace("  ", " ");
        }
        public static string ToDollors(this string thisString)
        {
            string[] arr = thisString.Replace(" ", "").Replace(",", "").Split('.');
            string s = "";
            long r = long.Parse("0" + arr[0]);
            if (r > 0) s += "Dollors " + r.ToWordsEn();
            if (arr.Length > 1)
            {
                int p = int.Parse((arr[1] + "00").Substring(0, 2));
                if (p > 0) s += " Cents " + ToWordsUpto999(p);
            }
            return s.Trim().Replace("  ", " ");
        }
    }

    public static class DataTableHelper
    {
        //public static void Load(ref DataTable thisDT, string XlsCsvTxtXmlFile)
        public static void Load(this DataTable thisDT, string XlsCsvTxtXmlFile, string TableName)
        {
            IDataReader dr = null;
            //thisDT = dr.ToIDataReader(XlsCsvTxtXmlFile, TableName).ToDataTable();
            thisDT.Load(dr.ToIDataReader(XlsCsvTxtXmlFile, TableName));
            //try
            //{
            //    if (Path.GetExtension(XlsCsvTxtXmlFile).ToLower() == ".xml")
            //    {
            //        thisDT.ReadXml(HttpContext.Current.Server.MapPath(XlsCsvTxtXmlFile));
            //    }
            //    else
            //    {
            //        string strConn;
            //        string strCmd;
            //        if ((Path.GetExtension(XlsCsvTxtXmlFile).ToLower() == ".csv") || (Path.GetExtension(XlsCsvTxtXmlFile).ToLower() == ".txt"))
            //        {
            //            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + CsvFile + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(Path.GetDirectoryName(XlsCsvTxtXmlFile)) + ";Extended Properties=\"Text;HDR=Yes;IMEX=1\"";
            //            strCmd = "SELECT * FROM " + XlsCsvTxtXmlFile;
            //        }
            //        else if (Path.GetExtension(XlsCsvTxtXmlFile).ToLower() == ".mdb")
            //        {
            //            if (TableName == "") TableName = "Table1";
            //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(XlsCsvTxtXmlFile) + ";";
            //            strCmd = "SELECT * FROM [" + TableName + "]";
            //        }
            //        else
            //        {
            //            if (TableName == "") TableName = "Sheet1";
            //            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(XlsCsvTxtXmlFile) + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            //            strCmd = "SELECT * FROM [" + TableName + "$]";
            //        }

            //        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(strCmd, strConn);
            //        da.Fill(thisDT);
            //    }
            //}
            //catch
            //{
            //}
            ////return thisDT;
        }

        //public static DataTable ToDataTable(string XlsCsvTxtXmlFile)
        public static DataTable ToDataTable(this DataTable thisDT, string XlsCsvTxtXmlFile, string TableName)
        {
            //DataTable dt = new DataTable();
            //dt.Load(XlsCsvTxtXmlFile, TableName);//Load(ref dt, XlsCsvTxtXmlFile);//
            //return dt;
            IDataReader dr = null;
            return dr.ToIDataReader(XlsCsvTxtXmlFile, TableName).ToDataTable();
        }

        //public static DataTable ToDataTable(string XlsCsvTxtXmlFile)
        public static void Sort(this DataTable thisDT, string SortExpression, bool SortDescending)
        {

            if (!string.IsNullOrEmpty(SortExpression))
            {
                if (!SortExpression.ToUpper().EndsWith(" ASC") && !SortExpression.ToUpper().EndsWith(" DESC"))
                {
                    if (SortDescending)
                        SortExpression += " DESC";
                    else
                        SortExpression += " ASC";
                }
                thisDT.Sort(SortExpression);
            }
        }

        //public static DataTable ToDataTable(string XlsCsvTxtXmlFile)
        public static void Sort(this DataTable thisDT, string SortExpression)
        {
            try
            {
                if (!string.IsNullOrEmpty(SortExpression))
                {
                    thisDT.DefaultView.Sort = SortExpression;
                    thisDT = thisDT.DefaultView.ToTable();
                }
            }
            catch { }
        }

        //public static void Export(string Filename)
        public static void Export(this DataTable thisDT, string Filename)
        {
            switch (Path.GetExtension(Filename).ToLower())
            {
                case ".xml":
                    thisDT.ToXML(Filename);
                    break;

                default://".csv",".txt"
                    thisDT.ToCSV(Filename);
                    break;
            }

        }

        //public static void ToXML(DataTable thisDT, string XmlFilename)
        public static void ToXML(this DataTable thisDT, string XmlFilename)
        {
            thisDT.WriteXml(HttpContext.Current.Server.MapPath(XmlFilename), XmlWriteMode.WriteSchema);
        }

        //public static void ToCSV(DataTable thisDT, string CsvFilename)
        public static void ToCSV(this DataTable thisDT, string CsvFilename)
        {
            StringBuilder sb = new StringBuilder();
            string s = "";
            foreach (DataColumn column in thisDT.Columns)
            {
                s += "\"" + column.ColumnName + "\",";
            }
            sb.Append(s.Substring(0, s.Length - 1) + Environment.NewLine);

            foreach (DataRow row in thisDT.Rows)
            {
                s = "";
                foreach (DataColumn column in thisDT.Columns)
                {
                    s += "\"" + row[column].ToString().Replace("\"", "\"\"") + "\",";//replace quot with two-times quots
                }
                //for (int i = 0; i < thisDT.Columns.Count; i++)
                //{
                //    s += "\"" + row[i].ToString().Replace("\"", "\"\"") + "\",";//replace quot with two-times quots
                //}
                sb.Append(s.Substring(0, s.Length - 1) + Environment.NewLine);
            }

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.ContentType = "text/csv";
            if (string.IsNullOrEmpty(Path.GetExtension(CsvFilename))) CsvFilename += ".csv";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + CsvFilename);
            context.Response.End();
        }
    }

    public static class IDataReaderHelper
    {
        //public static IDataReader ToIDataReader(string XlsCsvTxtFile)
        public static IDataReader ToIDataReader(this IDataReader thisDR, string XlsCsvTxtFile, string TableName)
        {
            try
            {
                string strConn;
                string strCmd;
                if ((Path.GetExtension(XlsCsvTxtFile).ToLower() == ".csv") || (Path.GetExtension(XlsCsvTxtFile).ToLower() == ".txt"))
                {
                    //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + CsvFile + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(Path.GetDirectoryName(XlsCsvTxtFile)) + ";Extended Properties=\"Text;HDR=Yes;IMEX=1\"";
                    strCmd = "SELECT * FROM " + XlsCsvTxtFile;
                }
                else if (Path.GetExtension(XlsCsvTxtFile).ToLower() == ".mdb")
                {
                    if (string.IsNullOrEmpty(TableName)) TableName = "Table1";
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(XlsCsvTxtFile) + ";";
                    strCmd = "SELECT * FROM [" + TableName + "]";
                }
                else
                {
                    if (string.IsNullOrEmpty(TableName)) TableName = "Sheet1";
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(XlsCsvTxtFile) + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                    strCmd = "SELECT * FROM [" + TableName + "$]";
                }

                System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strConn);
                Conn.Open();

                System.Data.OleDb.OleDbCommand Cmd = new System.Data.OleDb.OleDbCommand(strCmd, Conn);

                return Cmd.ExecuteReader();
            }
            catch
            { return null; }
        }

        //public static DataTable ToDataTable(IDataReader thisDR)
        public static DataTable ToDataTable(this IDataReader thisDR)
        {
            DataTable dt = new DataTable();
            dt.Load(thisDR);
            return dt;
        }

        //public static List<YouTubeVideoInfo> ToLOT(IDataReader thisDR)
        public static List<YouTubeVideoInfo> ToLOT(this IDataReader thisDR)
        {
            return CBO.FillCollection<YouTubeVideoInfo>(thisDR);
        }

        //public static List<YouTubeVideoInfo> ToLOT(IDataReader thisDR)
        public static List<YouTubeVideoInfo> ToLOT(this IDataReader thisDR, ref int totalRecords)
        {
            return CBO.FillCollection<YouTubeVideoInfo>(thisDR, ref totalRecords);
        }

        //public static List<YouTubeVideoInfo> ToLOT(IDataReader thisDR, ref IList<YouTubeVideoInfo> objToFill)
        public static IList<YouTubeVideoInfo> ToLOT(this IDataReader thisDR, ref IList<YouTubeVideoInfo> objToFill)
        {
            return CBO.FillCollection<YouTubeVideoInfo>(thisDR, ref objToFill);
        }
    }

    public static class ResponseHelper
    {
        public static void Redirect(this HttpResponse thisResponse, string url, string target, string windowFeatures)
        {
            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                thisResponse.Redirect(url);
            }
            else
            {
                Page myPage = (Page)HttpContext.Current.Handler;
                if (myPage == null)
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                url = myPage.ResolveClientUrl(url);
                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                else
                    script = @"window.open(""{0}"", ""{1}"");";
                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(myPage, typeof(Page), "Redirect", script, true);
            }
        }
    }

    public static class GPS
    {
        /// <summary>
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        ///:::                                                                         :::
        ///:::  This routine calculates the distance between two points (given the     :::
        ///:::  latitude/longitude of those points). It is being used to calculate     :::
        ///:::  the distance between two ZIP Codes or Postal Codes using our           :::
        ///:::  ZIPCodeWorld(TM) and PostalCodeWorld(TM) products.                     :::
        ///:::                                                                         :::
        ///:::  Definitions:                                                           :::
        ///:::    South latitudes are negative, North latitudes are positive           :::
        ///:::    West longitudes are negative, East longitudes are positive           :::
        ///:::                                                                         :::
        ///:::  Passed to function:                                                    :::
        ///:::    lat1, lon1 = Latitude and Longitude of point 1 (in decimal degrees)  :::
        ///:::    lat2, lon2 = Latitude and Longitude of point 2 (in decimal degrees)  :::
        ///:::    unit = the unit you desire for results                               :::
        ///:::           where: 'M' is statute miles                                   :::
        ///:::                  'K' is kilometers (default)                            :::
        ///:::                  'N' is nautical miles                                  :::
        ///:::                                                                         :::
        ///:::  United States ZIP Code/ Canadian Postal Code databases with latitude   :::
        ///:::  & longitude are available at http:///www.zipcodeworld.com               :::
        ///:::                                                                         :::
        ///:::  For enquiries, please contact sales@zipcodeworld.com                   :::
        ///:::                                                                         :::
        ///:::  Official Web site: http:///www.zipcodeworld.com                         :::
        ///:::                                                                         :::
        ///:::  Hexa Software Development Center © All Rights Reserved 2004            :::
        ///:::                                                                         :::
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        /// </summary>
        //private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        //{
        //    double theta = lon1 - lon2;
        //    double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
        //    dist = Math.Acos(dist);
        //    dist = rad2deg(dist);
        //    dist = dist * 60 * 1.1515;
        //    if (unit == 'K')
        //    {
        //        dist = dist * 1.609344;
        //    }
        //    else if (unit == 'N')
        //    {
        //        dist = dist * 0.8684;
        //    }
        //    return (dist);
        //}
        static double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            switch (unit)
            {
                case 'M': //International Mile
                    return Miles(lat1, lon1, lat2, lon2);
                case 'N': //UK Nautical Mile
                    return Nauticals(lat1, lon1, lat2, lon2);
                default://case 'K': //Kilometer
                    return Kms(lat1, lon1, lat2, lon2);
            }
        }
        static double Nauticals(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            return Rad2Deg(dist) * 60;
        }
        static double Kms(double lat1, double lon1, double lat2, double lon2)
        {
            return 1.853184 * Nauticals(lat1, lon1, lat2, lon2);
        }
        static double Miles(double lat1, double lon1, double lat2, double lon2)
        {
            return 1.151515 * Nauticals(lat1, lon1, lat2, lon2);
        }        

        /// <summary>
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        ///::  This function converts decimal degrees to radians             :::
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        /// </summary>
        static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        /// <summary>
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        ///::  This function converts radians to decimal degrees             :::
        ///:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        /// </summary>
        static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

    }
}//bhattji.Modules.YouTubeVideos
