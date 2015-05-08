using System.Data;
using DotNetNuke.Common.Utilities;
using System;
using System.Text;
using DotNetNuke.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.Providers;

namespace bhattji.Modules.MyLogins
{
    [Serializable]
    public class CategoryInfo : IHydratable
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "
        //private int _ItemId;
        //private int _ModuleId;

        //private string _Category;

        //private int _ViewOrder;
		#endregion

		#region " Properties "

		int IHydratable.KeyID {
			get { return ItemId; }
			set { ItemId = value; }
		}

        public int ItemId { get; set; }

        public int ModuleId { get; set; }

        public string Category { get; set; }

        public int ViewOrder { get; set; }

		#endregion

		#region " Optional IHydratable Implementation "

		void IHydratable.Fill(IDataReader dr)
		{
			ItemId = Convert.ToInt32(Null.SetNull(dr["ItemID"], ItemId));
			ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleID"], ModuleId));
			Category = Convert.ToString(Null.SetNull(dr["Category"], Category));

			ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
		}

		#endregion

	} //CategoryInfo

	public class CategoriesController
	{

		#region " Public Methods "
		private object GetNull(object Field)
		{
			return Null.GetNull(Field, DBNull.Value);
		}
		//GetNull
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
		} //GetPrefixedDbObjectName

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
            //return Convert.ToInt32(DataProvider.Instance().ExecuteScalar<CategoryInfo>(GetPrefixedDbObjectName("AddMyLoginCategory"), objCategory.ModuleId, objCategory.Category, GetNull(objCategory.ViewOrder)));
            return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddMyLoginCategory"), objCategory.ModuleId, objCategory.Category, GetNull(objCategory.ViewOrder));
            
		}

		public void UpdateCategory(CategoryInfo objCategory)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateMyLoginCategory"), objCategory.ItemId, objCategory.Category, GetNull(objCategory.ViewOrder));
			}
		}

		public void DeleteCategory(CategoryInfo objCategory)
		{
			DeleteCategory(objCategory.ItemId);
		}

		public void DeleteCategory(int ItemID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteMyLoginCategory"), ItemID);
		}

		public void SetViewOrderCategories(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderMyLoginCategories"), ModuleID);
		}

		public void ClaimOrphanCategories(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanMyLoginCategories"), ModuleID);
		}


        public int GetCategoryId(string Category)
        {
            return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("GetMyLoginCategoryId"), Category);
        }
        public int GetCategoryIdAddIfNotExists(string Category)
        {
            int CatId = DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("GetMyLoginCategoryId"), Category);
            if (Null.IsNull(CatId))
            {
                CatId = DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddMyLoginCategory"), -1, Category, -1);
            }
            return CatId;
        }
		public CategoryInfo GetCategory(int ItemID)
		{
			return CBO.FillObject<CategoryInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetMyLoginCategory"), ItemID));
		}

		public DataTable GetCategories()
		{
			return GetCategories("");
        } //GetCategories
		public DataTable GetCategories(string SearchText)
		{
			return GetCategories(SearchText, false, -1, -1, 2);
		} //GetCategories
        public DataTable GetCategories(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
			DataTable dt = new DataTable();
			dt.Load(GetCategoriesCommon(SearchText, StartsWith, ModuleId, PortalId, CategoriesScope));
			return dt;
        } //GetCategories

		public IDataReader GetCategoriesCommon(string SearchText, bool StartsWith)
		{
			return GetCategoriesCommon(SearchText, false, -1, -1, -1);
		} //GetCategoriesCommon

        public IDataReader GetCategoriesCommon(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
			if (!string.IsNullOrEmpty(SearchText))
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

		public IDataReader GetModuleCategories(int ModuleId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetModuleMyLoginCategories"), ModuleId);
		}

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetPortalCategories(int PortalId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetPortalMyLoginCategories"), PortalId);
		}

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetAllCategories()
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllMyLoginCategories"));
		}


		private void GetScopeFilter(ref string ScopeFilter, ref string ScopeJoins, int ModuleId, int PortalId, int ItemsScope, string ObjectQualifier)
		{
			switch (ItemsScope) {
				case 0:
					if (ModuleId > -1)
					{
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						//Return GetModuleMyLogins(ModuleId)
					}

					break;
				case 1:
					if (PortalId > -1)
					{
						ScopeJoins = "INNER JOIN [" + ObjectQualifier + "Modules] As m on x.ModuleId = m.ModuleId ";
						//Return GetPortalMyLogins(PortalId)
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						//Return GetPortalMyLogins(PortalId)
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
						//Return GetPortalMyLogins(PortalId)
						ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
						//Return GetPortalMyLogins(PortalId)
					}
                else if (ModuleId > -1) {
						ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
						//Return GetModuleMyLogins(ModuleId)
					}

					break;
			}
		} //GetScopeFilter

        //private string GetDateFilter(string FromDate, string ToDate)
        //{
        //    string DateFilter = "";

        //    DateTime DateTo = DateTime.Now;
        //    if (!string.IsNullOrEmpty(ToDate))
        //    {
        //        try { DateTo = DateTime.Parse(ToDate); }
        //        catch { DateTo = DateTime.Now; }
        //    }

        //    DateTime DateFrom = Convert.ToDateTime("1/1/1947");
        //    if (!string.IsNullOrEmpty(FromDate))
        //    {
        //        try { DateFrom = DateTime.Parse(FromDate); }
        //        catch { DateFrom = Convert.ToDateTime("1/1/1947"); }
        //    }

        //    if (DateFrom > DateTo)
        //    {
        //        DateTime tDate = DateFrom;
        //        DateFrom = DateTo;
        //        DateTo = tDate;
        //    }

        //    if (!string.IsNullOrEmpty(FromDate)) DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" + DateFrom.ToShortDateString() + "')) ";
        //    if (!string.IsNullOrEmpty(ToDate)) DateFilter += "AND (x.UpdatedDate <= Convert(DateTime, '" + DateTo.ToShortDateString() + "')) ";

        //    return DateFilter;
        //} //GetDateFilter

		public IDataReader GetSearchedCategories(string SearchText)
		{
			return GetSearchedCategories(SearchText, false, -1, -1, 0);
		} //GetSearchedCategories

		//ArrayList 'List(Of CategoryInfo) '
		public IDataReader GetSearchedCategories(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
		{
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

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("MyLoginCategories") + " AS x ");
            //sbSql += ScopeJoins;
            sbSql.Append(ScopeJoins);
            sbSql.Append("WHERE (x.Category LIKE '" + strSearchText + "') ");
            //sbSql += ScopeFilter;
            sbSql.Append(ScopeFilter);
            sbSql.Append("ORDER BY x.ViewOrder, x.Category ");

            return DataProvider.Instance().ExecuteSQL(sbSql.ToString()); 
		}


		#endregion

	} //CategoriesController

} //bhattji.Modules.MyLogins
