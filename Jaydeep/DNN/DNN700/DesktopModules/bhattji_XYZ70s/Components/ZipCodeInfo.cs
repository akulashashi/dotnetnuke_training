using System.Data;
using System;
using System.Collections;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Framework.Providers;

namespace bhattji.Modules.XYZ70s
{
    [Serializable]
    public class ZipCodeInfo
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "

		private int _ItemId;
		private string _ZipCode;
		private string _Area;
		private string _City;
		private string _StateCode;
		private string _State;
		private string _Display;

		#endregion

		#region " Properties "

		public int ItemId {
			get { return _ItemId; }
			set { _ItemId = value; }
		}

		public string ZipCode {
			get { return _ZipCode; }

			set { _ZipCode = value; }
		}

		public string Area {
			get { return _Area; }

			set { _Area = value; }
		}

		public string City {
			get { return _City; }

			set { _City = value; }
		}

		public string StateCode {
			get { return _StateCode; }

			set { _StateCode = value; }
		}

		public string State {
			get { return _State; }

			set { _State = value; }
		}

		public string Display {
			get { return _Display; }

			set { _Display = value; }
		}

		#endregion

		#region " Constructors "

		#endregion

	}//ZipCodeInfo

	public class ZipCodesController
	{
		
		#region " Public Methods "

		private object GetNull(object Field)
		{
			return Null.GetNull(Field, System.DBNull.Value);
		}
        private string GetObjectQualifier()
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
		private string GetPrefixedDbObjectName(string DbObjectName)
		{
			if (DbObjectName.StartsWith("bhattji_"))
			{
				return DbObjectName;
			}
			else
			{
				return "bhattji_" + DbObjectName;
			}
		} //PrefixCompanyID
		//---------------------------------------------------------------------
		// TODO Implement BLL methods
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		public int AddUpdateZipCode(ZipCodeInfo objZipCode)
		{
			if (objZipCode.ItemId > 0)
			{
				UpdateZipCode(objZipCode);
				return objZipCode.ItemId;
			}
			else
			{
				return AddZipCode(objZipCode);
			}
		}

		public int AddZipCode(ZipCodeInfo objZipCode)
		{
			{
                return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddZipCode"), GetNull(objZipCode.ZipCode), GetNull(objZipCode.Area), GetNull(objZipCode.City), GetNull(objZipCode.StateCode.ToUpper()), GetNull(objZipCode.State));
			}
		}

		public void UpdateZipCode(ZipCodeInfo objZipCode)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateZipCode"), objZipCode.ItemId, GetNull(objZipCode.ZipCode), GetNull(objZipCode.Area), GetNull(objZipCode.City), GetNull(objZipCode.StateCode.ToUpper()), GetNull(objZipCode.State));
			}
		}

		public void DeleteZipCode(ZipCodeInfo objZipCode)
		{
			DeleteZipCode(objZipCode.ItemId);
		}

		public void DeleteZipCode(int ItemId)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteZipCode"), ItemId);
		}


		public ZipCodeInfo GetZipCode(int ItemId)
		{
			return (ZipCodeInfo)DotNetNuke.Common.Utilities.CBO.FillObject(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCode"), ItemId), typeof(ZipCodeInfo));
		}
		public ZipCodeInfo GetZipCode(string ZipCode)
		{
            return (ZipCodeInfo)DotNetNuke.Common.Utilities.CBO.FillObject(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCodeByZipCode"), ZipCode), typeof(ZipCodeInfo));
		}

		//List(Of ZipCodeInfo) 'IDataReader
        public IDataReader GetZipCodes() //ArrayList
		{
            //return DotNetNuke.Common.Utilities.CBO.FillCollection(DataProvider.Instance().ExecuteReader(PrefixCompanyID("GetZipCodes")), typeof(ZipCodeInfo));
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCodes"));
        }

        public IDataReader GetSearchedZipCodes(string SearchText)
		{
			return GetSearchedZipCodes(SearchText, "Any", 100);
		}//GetSearchedZipCodes

        public IDataReader GetSearchedZipCodes(string SearchText, string SearchOn)
		{
			return GetSearchedZipCodes(SearchText, SearchOn, 100);
		}//GetSearchedZipCodes

        //List(Of ZipCodeInfo) 'IDataReader 
        public IDataReader GetSearchedZipCodes(string SearchText, string SearchOn, int NoOfItems)
        {
            string MyObjectQualifier = GetObjectQualifier();

            StringBuilder sbSql = new StringBuilder();

            sbSql.Append("SELECT TOP " + NoOfItems.ToString() + " ");
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ZipCode, ");
            sbSql.Append("x.Area, ");
            sbSql.Append("x.City, ");
            sbSql.Append("x.StateCode, ");
            sbSql.Append("sc.State, ");
            sbSql.Append("'Display'=x.City + ', ' + x.StateCode + ' ' + x.ZipCode ");

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("ZipCodes") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + MyObjectQualifier + GetPrefixedDbObjectName("StateCodes") + " AS sc ON x.StateCode=sc.StateCode ");

            switch (SearchOn.ToUpper())
            {
                case "ZIPCODE":
                    sbSql.Append("WHERE (x.ZipCode LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.ZipCode ");
                    break;

                case "AREA":
                    sbSql.Append("WHERE (x.Area LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.Area, x.City ");
                    break;

                case "CITY":
                    sbSql.Append("WHERE (x.City LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.City, x.Area ");
                    break;

                case "SATAE":
                    sbSql.Append("WHERE (sc.State LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY sc.State, x.City, x.Area ");
                    break;

                default:
                    //"ANY" 
                    sbSql.Append("WHERE (x.ZipCode LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (x.Area LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (x.City LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (sc.State LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY sc.State, x.City, x.Area ");
                    break;

            }
            //return DotNetNuke.Common.Utilities.CBO.FillCollection(DataProvider.Instance().ExecuteSQL(sbSql.ToString()), typeof(ZipCodeInfo));
            return DataProvider.Instance().ExecuteSQL(sbSql.ToString());
        } //GetSearchedZipCodes 

		#endregion

		#region " Optional Interfaces "

		
		#endregion

	} //ZipCodesController

} //bhattji.Modules.XYZ70s
