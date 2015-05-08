using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Framework.Providers;
using bhattji.Modules.XYZ70s.PetaPoco;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace bhattji.Modules.XYZ70s
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

		public IDataReader ImportFromFile(string XlsCsvTxtFile)
		{
			if ((System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".csv") || (System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".txt"))
				return XlsCsvTxtFile.FromCsvTxt2DR();
			else
				return XlsCsvTxtFile.FromXls2DR();
		}
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

			DateTime DateFrom = new DateTime(1947,1,1);
			if (!string.IsNullOrEmpty(FromDate))
			{
                try { DateFrom = Convert.ToDateTime(FromDate); } catch {}
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
