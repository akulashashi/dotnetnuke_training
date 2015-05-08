using System.Data;
using DotNetNuke.Common.Utilities;
using System;
using System.Text;
using DotNetNuke.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.Providers;
using bhattji.Modules.XYZ60s.PetaPoco;
using System.Collections.Generic;

namespace bhattji.Modules.XYZ60s
{
    [Serializable]
    [TableName("bhattji_XYZ60Categories")]
    [PrimaryKey("ItemId")]
    public class CategoryInfo
    {
        #region " Properties "

        public int ItemId { get; set; }
        public int ModuleId { get; set; }
        public string Category { get; set; }
        public int? ViewOrder { get; set; } //JP: Made Nullable
        [Ignore]
        public string ViewOrderString
        {
            get
            {
                return ViewOrder > 0 ? ViewOrder.ToString() : string.Empty;
            }
            set
            {
                try { ViewOrder = Convert.ToInt32(value); }
                catch { }
            }
        }

        #endregion
    } //CategoryInfo

    public class CategoriesController : CommonControllerMethods
    {
        #region " Private Members "

        private StringBuilder GetSearchSql(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope)
        {
            string strSearchText = StartsWith ? SearchText + "%" : "%" + SearchText + "%";
            //Set for Joining tables
            string ScopeJoins = "", ScopeFilter = "", ScopeFilterWhere = "";
            GetScopeFilter(ref ScopeJoins, ref ScopeFilter, ref ScopeFilterWhere, ModuleId, PortalId, CategoriesScope);

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT x.ItemId, x.ModuleId, x.Category, x.ViewOrder ");

            sbSql.Append("FROM " + GetDboName("XYZ60Categories") + " AS x ");
            sbSql.Append(ScopeJoins);

            if (string.IsNullOrEmpty(SearchText))
                sbSql.Append(ScopeFilterWhere);
            else
            {
                sbSql.Append("WHERE (x.Category LIKE '" + strSearchText + "') ");
                sbSql.Append(ScopeFilter);
            }

            sbSql.Append("ORDER BY x.ViewOrder, x.Category ");
            return sbSql;
        }

        #endregion

        #region " Public Methods "

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
            return Convert.ToInt32(db.Insert(GetDboName("XYZ60Categories"), "ItemId", objCategory));
        }
        public int UpdateCategory(CategoryInfo objCategory)
        {
            return db.Update(GetDboName("XYZ60Categories"), "ItemId", objCategory);
        }
        public int DeleteCategory(CategoryInfo objCategory)
        {
            return db.Delete(GetDboName("XYZ60Categories"), "ItemId", objCategory);
        }
        public int DeleteCategory(int ItemID)
        {
            return db.Delete(GetDboName("XYZ60Categories"), "ItemId", null, ItemID);
        }


        public int GetCategoryId(string Category)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT TOP 1 ItemId ");
            sbSql.Append("FROM " + GetDboName("XYZ60Categories") + " ");
            sbSql.Append("WHERE Category = " + Category);

            return db.ExecuteScalar<int>(sbSql.ToString());
        }
        public int GetCategoryIdAddIfNotExists(string Category)
        {
            int CatId = GetCategoryId(Category);
            if (CatId < 1)
            {
                CategoryInfo objCategory = new CategoryInfo();
                objCategory.Category = Category;
                CatId = AddCategory(objCategory);
            }
            return CatId;
        }
        public CategoryInfo GetCategory(int ItemID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT ItemId, ModuleId, Category, ViewOrder ");
            sbSql.Append("FROM " + GetDboName("XYZ60Categories") + " ");

            sbSql.Append("WHERE ItemID = " + ItemID.ToString());

            return db.SingleOrDefault<CategoryInfo>(sbSql.ToString());
        }
        public IEnumerable<XYZ60Info> GetSearchedCategories()
        {
            StringBuilder sbSql = GetSearchSql("",false,-1,-1,2);
            return db.Query<XYZ60Info>(sbSql.ToString());
        }

        public Page<CategoryInfo> GetSearchedCategories(string SearchText, bool StartsWith, int ModuleId, int PortalId, int CategoriesScope, int PageIndex, int PageSize)
        {
            StringBuilder sbSql = GetSearchSql(SearchText, StartsWith, ModuleId, PortalId, CategoriesScope);

            return db.Page<CategoryInfo>(PageIndex, PageSize, sbSql.ToString());
        }

        #endregion

        #region " Userful Stored Procedures "
        public int SetViewOrderCategories(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(PrefixCompanyID("SetViewOrderXYZ60Categories"), ModuleID);
            string strSP = ";EXEC " + GetDboName("SetViewOrderXYZ60Categories") + " @0";
            return db.Execute(strSP, ModuleID);
        }
        public int ClaimOrphanCategories(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(PrefixCompanyID("ClaimOrphanXYZ60Categories"), ModuleID);
            string strSP = ";EXEC " + GetDboName("ClaimOrphanXYZ60Categories") + " @0";
            return db.Execute(strSP, ModuleID);
        }

        #endregion

    } //CategoriesController

} //bhattji.Modules.XYZ60s
