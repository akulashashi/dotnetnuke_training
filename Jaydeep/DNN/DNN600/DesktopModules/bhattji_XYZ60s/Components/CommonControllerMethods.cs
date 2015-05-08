using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Framework.Providers;
using bhattji.Modules.XYZ60s.PetaPoco;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace bhattji.Modules.XYZ60s
{
	abstract public class CommonControllerMethods
	{
		#region " Protected Members "

		protected string GetObjectQualifier()
		{
			ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration("data");
			Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
			string ObjectQualifier = objProvider.Attributes["objectQualifier"];
			if ((ObjectQualifier.Length > 0) && (!ObjectQualifier.EndsWith("_")))
			{
				ObjectQualifier += "_";
			}

			return ObjectQualifier;
		} //GetObjectQualifier
		protected string PrefixObjectQualifier(string DboName) {
			return GetObjectQualifier() + DboName;
		}
		protected string PrefixCompanyID(string DbObjectName)
		{
			if (DbObjectName.StartsWith("bhattji_"))
				return DbObjectName;
			else
				return "bhattji_" + DbObjectName;
		} //PrefixCompanyID

		protected string GetDboName(string DboName)
		{
			return PrefixObjectQualifier(PrefixCompanyID(DboName));
		}//GetDboName
		protected string GetSiteConnString() {
			return ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
		}//GetSiteConnString
		protected Database db = new Database("SiteSqlServer");

		////protected IDataReader GetDataReader(string strSql)
		////{
		////    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString);
		////    conn.Open();
		////    return new SqlCommand(strSql, conn).ExecuteReader();
		////}
		//protected DataTable GetDataTable(string strSql)
		//{
		//    //string strConn = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
		//    //SqlDataAdapter sda = new SqlDataAdapter(strSql, strConn);
		//    //DataTable dt = new DataTable();
		//    //sda.Fill(dt);
		//    //return dt;
		//    //GetDataReader(strSql).ToDataTable();
		//    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString);
		//    conn.Open();
		//    IDataReader dr = new SqlCommand(strSql, conn).ExecuteReader();
		//    DataTable dt = new DataTable();
		//    dt.Load(dr);
		//    conn.Close();
		//    return dt;
		//} 
		public IDataReader ImportFromFile(string XlsCsvTxtFile)
		{
			if ((System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".csv") || (System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".txt"))
				return XlsCsvTxtFile.FromCsvTxt2DR();
			else
				return XlsCsvTxtFile.FromXls2DR();
		}
		//public IDataReader ImportFromFile(string XlsCsvTxtFile)
		//{
		//    string strConn;
		//    string strCmd;
		//    if ((System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".csv") || (System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".txt"))
		//    {
		//        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + CsvFile + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
		//        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(System.IO.Path.GetDirectoryName(XlsCsvTxtFile)) + ";Extended Properties=\"Text;HDR=Yes;IMEX=1\"";
		//        strCmd = "SELECT * FROM " + XlsCsvTxtFile;
		//    }
		//    else
		//    {
		//        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(XlsCsvTxtFile) + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
		//        strCmd = "SELECT * FROM [Sheet1$]";
		//    }

		//    //System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(strCmd, strConn);

		//    //DataTable dt = new DataTable();
		//    //da.Fill(dt);

		//    //return dt;

		//    System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strConn);
		//    Conn.Open();

		//    System.Data.OleDb.OleDbCommand Cmd = new System.Data.OleDb.OleDbCommand(strCmd, Conn);

		//    return Cmd.ExecuteReader();
		//}

		protected void GetScopeFilter(ref string ScopeJoins, ref string ScopeFilter, ref string ScopeFilterWhere, int ModuleId, int PortalId, int ItemsScope)
		{
			switch (ItemsScope)
			{
				case 0:
					if (ModuleId > -1)
					{
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						ScopeFilterWhere = "WHERE (x.ModuleId = " + ModuleId.ToString() + ") ";
					}
					break;
				case 1:
					if (PortalId > -1)
					{
						ScopeJoins = "INNER JOIN " + PrefixObjectQualifier("Modules") + " As m on x.ModuleId = m.ModuleId ";
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						ScopeFilterWhere = "WHERE (m.PortalId = " + PortalId.ToString() + ") ";
					}
					break;
				case 2://Do Nothing
					break;
				default://0
					if (PortalId > -1)
					{
						ScopeJoins = "INNER JOIN " + PrefixObjectQualifier("Modules") + " As m on x.ModuleId = m.ModuleId ";
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						ScopeFilterWhere = "WHERE (m.PortalId = " + PortalId.ToString() + ") ";
					}
					else if (ModuleId > -1)
					{
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						ScopeFilterWhere = "WHERE (x.ModuleId = " + ModuleId.ToString() + ") ";
					}
					break;
			}
		} //GetScopeFilter
		protected string GetDateFilter(string FromDate, string ToDate, string DateField)
		{
			string DateFilter = "";

			DateTime DateTo = DateTime.Now;
			if (!string.IsNullOrEmpty(ToDate))
			{
				try { DateTo = DateTime.Parse(ToDate); }
				catch { DateTo = DateTime.Now; }
			}

			DateTime DateFrom = Convert.ToDateTime("1/1/1947");
			if (!string.IsNullOrEmpty(FromDate))
			{
				try { DateFrom = DateTime.Parse(FromDate); }
				catch { DateFrom = Convert.ToDateTime("1/1/1947"); }
			}

			if (DateFrom > DateTo)
			{
				DateTime tDate = DateFrom;
				DateFrom = DateTo;
				DateTo = tDate;
			}

			if (!string.IsNullOrEmpty(FromDate)) DateFilter = "AND (" + DateField + " >= Convert(DateTime, '" + DateFrom.ToShortDateString() + "')) ";
			if (!string.IsNullOrEmpty(ToDate)) DateFilter += "AND (" + DateField + " <= Convert(DateTime, '" + DateTo.ToShortDateString() + "')) ";

			return DateFilter;
		} //GetDateFilter

		#endregion
	}
}
