//Imports System
using System.Data;
using DotNetNuke.Common.Utilities;
using System;
using System.Text;
using DotNetNuke.Data;
//Imports DotNetNuke.Data

namespace bhattji.Modules.SalesReps.Business
{

	public class CategoryInfo : DotNetNuke.Entities.Modules.IHydratable
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "
		private int _ItemId;
		private int _ModuleId;

		private string _Category;

		private int _ViewOrder;
		#endregion

		#region " Properties "

		int DotNetNuke.Entities.Modules.IHydratable.KeyID {
			get { return _ItemId; }
			set { _ItemId = value; }
		}

		public int ItemId {
			get { return _ItemId; }
			set { _ItemId = value; }
		}

		public int ModuleId {
			get { return _ModuleId; }
			set { _ModuleId = value; }
		}

		public string Category {
			get { return _Category; }
			set { _Category = value; }
		}

		public int ViewOrder {
			get { return _ViewOrder; }
			set { _ViewOrder = value; }
		}

		#endregion

		#region " Optional IHydratable Implementation "

		void DotNetNuke.Entities.Modules.IHydratable.Fill(IDataReader dr)
		{
			_ItemId = Convert.ToInt32(Null.SetNull(dr["ItemID"], ItemId));
			_ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleID"], ModuleId));
			_Category = Convert.ToString(Null.SetNull(dr["Category"], Category));

			_ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
		}

		#endregion

	}
	//CategoryInfo

	public class CategoriesController
	{

		#region " Public Methods "
		private object GetNull(object Field)
		{
			return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
		}
		//GetNull
		private string GetObjectQualifier()
		{
            DotNetNuke.Framework.Providers.ProviderConfiguration _providerConfiguration = DotNetNuke.Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data");
            DotNetNuke.Framework.Providers.Provider objProvider = (DotNetNuke.Framework.Providers.Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
            string ObjectQualifier = objProvider.Attributes["objectQualifier"];
            if ((ObjectQualifier.Length > 0) && (!ObjectQualifier.EndsWith("_")))
            {
                ObjectQualifier += "_";
            }

			return ObjectQualifier;
		}
		//GetObjectQualifier
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
		}
		//GetPrefixedDbObjectName

		//---------------------------------------------------------------------
		// TODO Implement BLL methods
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------
		public int AddUpdateCategory(CategoryInfo objCategory)
		{
			if (objCategory.ItemId > 0)
			{
				UpdateCategory(objCategory);
				return objCategory.ItemId;
			}
			else
			{
				return AddCategory(objCategory);
			}
		}

		public int AddCategory(CategoryInfo objCategory)
		{
			{
                return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddSalesRepCategory"), objCategory.ModuleId, objCategory.Category, GetNull(objCategory.ViewOrder)));
			}
		}

		public void UpdateCategory(CategoryInfo objCategory)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateSalesRepCategory"), objCategory.ItemId, objCategory.Category, GetNull(objCategory.ViewOrder));
			}
		}

		public void DeleteCategory(CategoryInfo objCategory)
		{
			DeleteCategory(objCategory.ItemId);
		}

		public void DeleteCategory(int ItemID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteSalesRepCategory"), ItemID);
		}

		public void SetViewOrderCategories(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderSalesRepCategories"), ModuleID);
		}

		public void ClaimOrphanCategories(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanSalesRepCategories"), ModuleID);
		}



		public CategoryInfo GetCategory(int ItemID)
		{
			//Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRepCategory", ItemID), GetType(CategoryInfo)), CategoryInfo)
			return CBO.FillObject<CategoryInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetSalesRepCategory"), ItemID));
		}

		//This function retreives the Items from Database,
		//depending upon the paramters supplied
		//If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
		//If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
		//If you dont suppliy any parameter it gets GetAllItems()

		//List(Of CategoryInfo) 'ArrayList 'IDataReader '
		public DataTable GetCategories()
		{
			return GetCategories("");
		}
		public DataTable GetCategories(string SearchText)
		{
			return GetCategories(SearchText, false, -1, -1, 2);
		}
		//GetCategories
		//List(Of CategoryInfo) 'ArrayList 'IDataReader '
		public DataTable GetCategories(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
			//Public Function GetCategories(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal CategoriesScope As Integer = 2) As DataTable 'List(Of CategoryInfo) 'ArrayList 'IDataReader '
			//Return GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope), GetType(SalesRepInfo)
			//Return CBO.FillCollection(GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of CategoryInfo)(GetCategoriesCommon(SearchText, StartsWith, ModuleId, PortalId, CategoriesScope))

			DataTable dt = new DataTable();
			dt.Load(GetCategoriesCommon(SearchText, StartsWith, ModuleId, PortalId, CategoriesScope));
			return dt;
		}

		public IDataReader GetCategoriesCommon(string SearchText, bool StartsWith)
		{
			return GetCategoriesCommon(SearchText, false, -1, -1, -1);
		}
		//GetCategoriesCommon
		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetCategoriesCommon(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
			//Public Function GetCategoriesCommon(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal CategoriesScope As Integer = -1) As IDataReader 'ArrayList 'List(Of CategoryInfo) '
			if (SearchText != "")
			{
				return GetSearchedCategories(SearchText, StartsWith, ModuleId, PortalId, CategoriesScope);
			}
			else
			{
				switch (CategoriesScope) {
					case 0:
						if (ModuleId > -1)
						{
							return GetModuleCategories(ModuleId);
						}
						else
						{
							return GetAllCategories();
						}

                        //break;
					case 1:
						if (PortalId > -1)
						{
							return GetPortalCategories(PortalId);
						}
						else
						{
							return GetAllCategories();
						}

                        //break;
					case 2:
						return GetAllCategories();
					default:
						//0
						if (PortalId > -1)
						{
							return GetPortalCategories(PortalId);
						}
else if (ModuleId > -1) {
							return GetModuleCategories(ModuleId);
						}
						else
						{
							return GetAllCategories();
						}

                        //break;
				}
			}
		}

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetModuleCategories(int ModuleId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetModuleSalesRepCategories"), ModuleId);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesRepCategories", ModuleId), GetType(CategoryInfo))
			//Return CBO.FillCollection(Of CategoryInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesRepCategories", ModuleId))
		}

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetPortalCategories(int PortalId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetPortalSalesRepCategories"), PortalId);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesRepCategories", PortalId), GetType(CategoryInfo))
			//Return CBO.FillCollection(Of CategoryInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesRepCategories", PortalId))
		}

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetAllCategories()
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllSalesRepCategories"));
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesRepCategories"), GetType(CategoryInfo))
			//Return CBO.FillCollection(Of CategoryInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesRepCategories"))
		}


		private void GetScopeFilter(ref string ScopeFilter, ref string ScopeJoins, int ModuleId, int PortalId, int ItemsScope, string ObjectQualifier)
		{
			switch (ItemsScope) {
				case 0:
					if (ModuleId > -1)
					{
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						//Return GetModuleSalesReps(ModuleId)
					}

					break;
				case 1:
					if (PortalId > -1)
					{
						ScopeJoins = "INNER JOIN [" + ObjectQualifier + "Modules] As m on x.ModuleId = m.ModuleId ";
						//Return GetPortalSalesReps(PortalId)
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						//Return GetPortalSalesReps(PortalId)
					}

					break;
				case 2:
					break;
				//Do Nothing
				default:
					//0
					if (PortalId > -1)
					{
						ScopeJoins = "INNER JOIN [" + ObjectQualifier + "Modules] As m on x.ModuleId = m.ModuleId ";
						//Return GetPortalSalesReps(PortalId)
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						//Return GetPortalSalesReps(PortalId)
					}
else if (ModuleId > -1) {
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						//Return GetModuleSalesReps(ModuleId)
					}

					break;
			}
		}
		//GetScopeFilter

		private string GetDateFilter(string FromDate, string ToDate)
		{
			string DateFilter = "";
            DateTime DateTo = DateTime.Now;
			if (ToDate != "")
			{
				try {
					DateTo = DateTime.Parse(ToDate);
				}
				catch {
                    DateTo = DateTime.Now;
				}
			}
            DateTime DateFrom = Convert.ToDateTime("1/1/1947");
			if (FromDate != "")
			{
				try {
					DateFrom = DateTime.Parse(FromDate);
				}
				catch {
                    DateFrom = Convert.ToDateTime("1/1/1947");
				}
			}

			if (DateFrom > DateTo)
			{
				DateTime tDate = DateFrom;
				DateFrom = DateTo;
				DateTo = tDate;
			}

			if (FromDate != "") DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" + DateFrom.ToShortDateString() + "')) ";
            if (ToDate != "") DateFilter += "AND (x.UpdatedDate <= Convert(DateTime, '" + DateTo.ToShortDateString() + "')) ";

			return DateFilter;
		}
		//GetDateFilter

		public IDataReader GetSearchedCategories(string SearchText)
		{
			return GetSearchedCategories(SearchText, false, -1, -1, 0);
		}
		//GetSearchedCategories
		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetSearchedCategories(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
			//Public Function GetSearchedCategories(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal CategoriesScope As Integer = 0) As IDataReader 'ArrayList 'List(Of CategoryInfo) '
			string MyObjectQualifier = GetObjectQualifier();

			string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();

			//Set for Joining tables
			string ScopeJoins = "";
			string ScopeFilter = "";
			GetScopeFilter(ref ScopeFilter, ref ScopeJoins, ModuleId, PortalId, CategoriesScope, MyObjectQualifier);

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT ");
            //sbSql += "x.* " 
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ModuleId, ");
            sbSql.Append("x.Category, ");
            sbSql.Append("x.ViewOrder ");

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("SalesRepCategories") + " AS x ");
            //sbSql += ScopeJoins;
            sbSql.Append(ScopeJoins);
            sbSql.Append("WHERE (x.Category LIKE '" + strSearchText + "') ");
            //sbSql += ScopeFilter;
            sbSql.Append(ScopeFilter);
            sbSql.Append("ORDER BY x.ViewOrder, x.Category ");

            return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()); 

			//Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), GetType(CategoryInfo))
			//Return CBO.FillCollection(Of CategoryInfo)(DataProvider.Instance().ExecuteReader(sbSql.ToString()))

		}


		#endregion

	}
	//CategoriesController

}
//bhattji.Modules.SalesReps.Business
