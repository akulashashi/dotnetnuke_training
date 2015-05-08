using System;
using System.Data;
using System.Xml;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using System.Text;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Common;
using bhattji.Modules.XYZ70s.PetaPoco;
//using DotNetNuke.ComponentModel.DataAnnotations;


namespace bhattji.Modules.XYZ70s
{
    [Serializable]
    [TableName("bhattji_XYZ70s")]
    [PrimaryKey("ItemId")]
    public class XYZ70Info
    {
        #region " Properties "
        public int ItemId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        [ResultColumn]
        public string Category { get; set; }
        public string MediaSrc { get; set; }
        public string MediaWidth { get; set; }
        public string MediaHeight { get; set; }
        public string MediaAlign { get; set; }
        public string Description { get; set; }

        //Insert the Actual Fields Below

        public string ActualFields { get; set; }

        //Insert the Actual Fields above

        public string Details { get; set; }
        public string MediaSrc2 { get; set; }
        public string MediaWidth2 { get; set; }
        public string MediaHeight2 { get; set; }
        public string MediaAlign2 { get; set; }
        public string NavURL { get; set; }
        [ResultColumn]
        public bool NewWindow { get; set; }
        [ResultColumn]
        public bool TrackClicks { get; set; }
        public DateTime? PublishDate { get; set; }
        [Ignore]
        public string PublishDateString
        {
            get
            {
                return PublishDate.HasValue ? Convert.ToDateTime(PublishDate).ToShortDateString() : string.Empty;
                //if (PublishDate.HasValue && (PublishDate > DateTime.MinValue)) //(PublishDate > Convert.ToDateTime("1/1/0001"))) //
                //    return Convert.ToDateTime(PublishDate).ToShortDateString();
                //else
                //    return string.Empty;
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value) && (Convert.ToDateTime(value).Year > 1752)) PublishDate = Convert.ToDateTime(value);
                    //PublishDate = Convert.ToDateTime(value);
                    //if (PublishDate < Convert.ToDateTime("1/1/1753")) //DateTime.MinValue)
                    //    PublishDate = null;
                    //PublishDate = Convert.ToDateTime("1/1/1753"); //DateTime.MinValue;
                }
                catch{}
            }
        }
        public DateTime? ExpiryDate { get; set; }
        [Ignore]
        public string ExpiryDateString
        {
            get
            {
                return ExpiryDate.HasValue ? Convert.ToDateTime(ExpiryDate).ToShortDateString() : string.Empty;
                //if (ExpiryDate.HasValue && (ExpiryDate > DateTime.MinValue)) //(ExpiryDate > Convert.ToDateTime("1/1/1753")))
                //    return Convert.ToDateTime(ExpiryDate).ToShortDateString();
                //else
                //    return string.Empty;
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value) && (Convert.ToDateTime(value).Year > 1752)) ExpiryDate = Convert.ToDateTime(value);

                    //ExpiryDate = Convert.ToDateTime(value);
                    //if (ExpiryDate < Convert.ToDateTime("1/1/1753"))
                    //    ExpiryDate = null;                    

                    //ExpiryDate = Convert.ToDateTime("1/1/1753");
                }
                catch{}
            }
        }
        [ResultColumn]
        public DateTime DisplayDate { get; set; }
        public int? ViewOrder { get; set; }
        [Ignore]
        public string ViewOrderString
        {
            get
            {
                return ViewOrder.HasValue ? ViewOrder.ToString() : string.Empty;
            }
            set
            {
                try { if (!string.IsNullOrEmpty((value))) ViewOrder = Convert.ToInt32(value); }
                catch { }
            }
        }
        //Ratings
        public int RatingVotes { get; set; }
        public int RatingTotal { get; set; }
        [ResultColumn]
        public int RatingAverage { get; set; }
        //Audit Control
        public int UpdatedByUserId { get; set; }
        [ResultColumn]
        public string UpdatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        [ResultColumn]
        public string CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        #endregion
    } //XYZ70Info
    public class XYZ70sController : CommonControllerMethods, ISearchable, IPortable, IUpgradeable
    {
        #region " Private Members "

        private StringBuilder GetFullSql(int ModuleId, int PortalId, int ItemsScope)
        {
            string ScopeJoins = "";
            string ScopeFilter = "";
            string ScopeFilterWhere = "";
            GetScopeFilter(ref ScopeJoins, ref ScopeFilter, ref ScopeFilterWhere, ModuleId, PortalId, ItemsScope);

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT ");
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ModuleId, ");
            sbSql.Append("x.Title, ");
            sbSql.Append("x.CategoryId, ");
            sbSql.Append("ca.Category, ");
            sbSql.Append("'MediaSrc' = CASE WHEN mf.FileName IS NULL THEN x.MediaSrc ELSE mf.Folder + mf.FileName END, ");
            sbSql.Append("x.MediaWidth, ");
            sbSql.Append("x.MediaHeight, ");
            sbSql.Append("x.MediaAlign, ");

            sbSql.Append("x.ActualFields, ");

            sbSql.Append("'MediaSrc2' = CASE WHEN mf2.FileName IS NULL THEN x.MediaSrc2 ELSE mf2.Folder + mf2.FileName END, ");
            sbSql.Append("x.MediaWidth2, ");
            sbSql.Append("x.MediaHeight2, ");
            sbSql.Append("x.MediaAlign2, ");
            sbSql.Append("'DisplayDate' = CASE WHEN x.PublishDate IS NULL THEN x.CreatedDate ELSE x.PublishDate END, ");
            sbSql.Append("x.Description, ");
            sbSql.Append("x.Details, ");
            sbSql.Append("x.PublishDate, ");
            sbSql.Append("x.ExpiryDate, ");
            sbSql.Append("'NavURL' = CASE WHEN nf.FileName IS NULL THEN x.NavURL ELSE nf.Folder + nf.FileName END, ");
            sbSql.Append("nt.NewWindow, ");
            sbSql.Append("nt.TrackClicks, ");

            sbSql.Append("x.ViewOrder, ");

            sbSql.Append("x.UpdatedByUserId, ");
            sbSql.Append("'UpdatedByUser' = CASE WHEN uu.DisplayName IS NULL THEN uu.FirstName + ' ' + uu.LastName ELSE uu.DisplayName END, ");
            sbSql.Append("x.UpdatedDate, ");
            sbSql.Append("x.CreatedByUserId, ");
            sbSql.Append("'CreatedByUser' = CASE WHEN uc.DisplayName IS NULL THEN uc.FirstName + ' ' + uc.LastName ELSE uc.DisplayName END, ");
            sbSql.Append("x.CreatedDate, ");

            sbSql.Append("'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END ");

            sbSql.Append("FROM " + GetDboName("XYZ70s") + " AS x ");
            sbSql.Append(ScopeJoins);
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("UrlTracking") + " As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uu ON x.UpdatedByUserId = uu.UserId ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uc ON x.CreatedByUserId = uc.UserId ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ70Categories") + " AS ca ON x.CategoryId = ca.ItemId ");

            //sbSql.Append("WHERE (x.ModuleId = " + ModuleId.ToString() + ") ");
            sbSql.Append(ScopeFilterWhere);

            return sbSql;
        }
        private StringBuilder GetSearchSql(int ModuleId, int PortalId, int ItemsScope, string SearchText, string SearchOn, bool StartsWith, string FromDate, string ToDate, int CategoryId)
        {
            string CategoryFilter = (CategoryId > -1 ? "AND (x.CategoryId = " + CategoryId.ToString() + ") " : "").ToString();
            string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();
            string DateFilter = GetDateFilter(FromDate, ToDate, "x.UpdatedDate");
            string ScopeJoins = "";
            string ScopeFilter = "";
            string ScopeFilterWhere = "";
            GetScopeFilter(ref ScopeJoins, ref ScopeFilter, ref ScopeFilterWhere, ModuleId, PortalId, ItemsScope);


            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT ");
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ModuleId, ");
            sbSql.Append("x.CategoryId, ");
            //sbSql.Append("ca.Category, ");
            sbSql.Append("x.Title, ");
            sbSql.Append("'MediaSrc' = CASE WHEN mf.FileName IS NULL THEN x.MediaSrc ELSE mf.Folder + mf.FileName END, ");
            sbSql.Append("x.MediaAlign, ");
            sbSql.Append("'MediaSrc2' = CASE WHEN mf2.FileName IS NULL THEN x.MediaSrc2 ELSE mf2.Folder + mf2.FileName END, ");
            sbSql.Append("'DisplayDate' = CASE WHEN x.PublishDate IS NULL THEN x.CreatedDate ELSE x.PublishDate END, ");
            sbSql.Append("x.Description, ");
            sbSql.Append("x.Details, ");
            sbSql.Append("'NavURL' = CASE WHEN nf.FileName IS NULL THEN x.NavURL ELSE nf.Folder + nf.FileName END, ");
            sbSql.Append("nt.NewWindow, ");
            sbSql.Append("nt.TrackClicks, ");

            sbSql.Append("x.UpdatedByUserId, ");
            //sbSql.Append("'UpdatedByUser' = CASE WHEN uu.DisplayName IS NULL THEN uu.FirstName + ' ' + uu.LastName ELSE uu.DisplayName END, ");
            //sbSql.Append("x.UpdatedDate, ");
            sbSql.Append("x.CreatedByUserId, ");
            //sbSql.Append("'CreatedByUser' = CASE WHEN uc.DisplayName IS NULL THEN uc.FirstName + ' ' + uc.LastName ELSE uc.DisplayName END, ");
            //sbSql.Append("x.CreatedDate, ");

            sbSql.Append("'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END ");

            sbSql.Append("FROM " + GetDboName("XYZ70s") + " AS x ");
            sbSql.Append(ScopeJoins);
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("UrlTracking") + " As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");
            //sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uu ON x.UpdatedByUserId = uu.UserId ");
            //sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uc ON x.CreatedByUserId = uc.UserId ");
            //sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ70Categories") + " AS ca ON x.CategoryId = ca.ItemId ");

            if (string.IsNullOrEmpty(SearchText))
            {
                sbSql.Append(ScopeFilterWhere);
                sbSql.Append("ORDER BY x.ViewOrder desc, x.UpdatedDate desc, x.Title ");
            }
            else
                switch (SearchOn.ToUpper())
                {
                    case "TITLE":
                    case "DESCRIPTION":
                        sbSql.Append("WHERE (x." + SearchOn + " LIKE '" + strSearchText + "') ");
                        sbSql.Append(DateFilter);
                        sbSql.Append(ScopeFilter);
                        sbSql.Append(CategoryFilter);
                        sbSql.Append("ORDER BY x." + SearchOn + ", x.ViewOrder, x.UpdatedDate desc ");
                        break;

                    case "DETAILS":
                        sbSql.Append("WHERE (x." + SearchOn + " LIKE '" + strSearchText + "') ");
                        sbSql.Append(DateFilter);
                        sbSql.Append(ScopeFilter);
                        sbSql.Append(CategoryFilter);
                        sbSql.Append("ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc ");
                        break;

                    default:
                        //"ANY"
                        sbSql.Append("WHERE ((x.Title LIKE '" + strSearchText + "') ");
                        sbSql.Append("OR (x.Description LIKE '" + strSearchText + "') ");
                        sbSql.Append("OR (x.Details LIKE '" + strSearchText + "')) ");
                        sbSql.Append(DateFilter);
                        sbSql.Append(ScopeFilter);
                        sbSql.Append(CategoryFilter);
                        sbSql.Append("ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc ");
                        break;
                }
            return sbSql;
        }

        #endregion

        #region " Public Methods "
        public int AddUpdateXYZ70(XYZ70Info objXYZ70)
        {
            if (objXYZ70.ItemId > 0)
            {
                UpdateXYZ70(objXYZ70);
                return objXYZ70.ItemId;
            }
            else
            {
                return AddXYZ70(objXYZ70);
            }
        }

        public int AddXYZ70(XYZ70Info objXYZ70)
        {
            return Convert.ToInt32(db.Insert(GetDboName("XYZ70s"), "ItemId", objXYZ70));//returns the (object) Primary Field Added
        }

        public int UpdateXYZ70(XYZ70Info objXYZ70)
        {
            return db.Update(GetDboName("XYZ70s"), "ItemId", objXYZ70);
        }

        public int UpdateXYZ70Rating(int ItemId, int RatingTotal)
        {
            XYZ70Info objXYZInfo = GetXYZ70(ItemId);
            if (objXYZInfo.RatingVotes < 1)
                objXYZInfo.RatingVotes = 1;
            else
                objXYZInfo.RatingVotes += 1;

            if (objXYZInfo.RatingTotal < 1)
                objXYZInfo.RatingTotal = RatingTotal;
            else
                objXYZInfo.RatingTotal += RatingTotal;
            return db.Update(GetDboName("XYZ70s"), "ItemId", objXYZInfo, new string[] { "RatingVotes", "RatingTotal" });
        }

        public int DeleteXYZ70(XYZ70Info objXYZ70)
        {
            return db.Delete(GetDboName("XYZ70s"), "ItemId", objXYZ70);
        }

        public int DeleteXYZ70(int ItemID)
        {
            return db.Delete(GetDboName("XYZ70s"), "ItemId", null, ItemID);
        }

        public int GetXYZ70Id(string Title)
        {
            //return DataProvider.Instance().ExecuteScalar<int>(PrefixCompanyID("GetXYZ70Id"), Title);
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT TOP 1 ItemId ");
            sbSql.Append("FROM " + GetDboName("XYZ70s") + " ");
            sbSql.Append("WHERE Title = " + Title);

            return db.ExecuteScalar<int>(sbSql.ToString());
        }
        public XYZ70Info GetXYZ70(string Title)
        {
            return GetXYZ70(GetXYZ70Id(Title));
        }
        public XYZ70Info GetXYZ70(int ItemID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT ");
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ModuleId, ");
            sbSql.Append("x.Title, ");
            sbSql.Append("x.CategoryId, ");
            sbSql.Append("ca.Category, ");
            sbSql.Append("'MediaSrc' = CASE WHEN mf.FileName IS NULL THEN x.MediaSrc ELSE mf.Folder + mf.FileName END, ");
            sbSql.Append("x.MediaWidth, ");
            sbSql.Append("x.MediaHeight, ");
            sbSql.Append("x.MediaAlign, ");

            sbSql.Append("x.ActualFields, ");

            sbSql.Append("'MediaSrc2' = CASE WHEN mf2.FileName IS NULL THEN x.MediaSrc2 ELSE mf2.Folder + mf2.FileName END, ");
            sbSql.Append("x.MediaWidth2, ");
            sbSql.Append("x.MediaHeight2, ");
            sbSql.Append("x.MediaAlign2, ");
            sbSql.Append("'DisplayDate' = CASE WHEN x.PublishDate IS NULL THEN x.CreatedDate ELSE x.PublishDate END, ");
            sbSql.Append("x.Description, ");
            sbSql.Append("x.Details, ");
            sbSql.Append("x.PublishDate, ");
            sbSql.Append("x.ExpiryDate, ");
            sbSql.Append("'NavURL' = CASE WHEN nf.FileName IS NULL THEN x.NavURL ELSE nf.Folder + nf.FileName END, ");
            sbSql.Append("nt.NewWindow, ");
            sbSql.Append("nt.TrackClicks, ");

            sbSql.Append("x.ViewOrder, ");

            sbSql.Append("x.UpdatedByUserId, ");
            sbSql.Append("'UpdatedByUser' = CASE WHEN uu.DisplayName IS NULL THEN uu.FirstName + ' ' + uu.LastName ELSE uu.DisplayName END, ");
            sbSql.Append("x.UpdatedDate, ");
            sbSql.Append("x.CreatedByUserId, ");
            sbSql.Append("'CreatedByUser' = CASE WHEN uc.DisplayName IS NULL THEN uc.FirstName + ' ' + uc.LastName ELSE uc.DisplayName END, ");
            sbSql.Append("x.CreatedDate, ");

            sbSql.Append("'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END ");

            sbSql.Append("FROM " + GetDboName("XYZ70s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("UrlTracking") + "] As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");

            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Users") + "] AS uu ON x.UpdatedByUserId = uu.UserId ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Users") + "] AS uc ON x.CreatedByUserId = uc.UserId ");

            sbSql.Append("LEFT OUTER JOIN [" + GetDboName("XYZ70Categories") + "] AS ca ON x.CategoryId = ca.ItemId ");

            sbSql.Append("WHERE x.ItemID = " + ItemID.ToString());

            return db.SingleOrDefault<XYZ70Info>(sbSql.ToString());
        }

        public Page<XYZ70Info> GetPagedXYZ70s(string SearchText, string SearchOn, bool StartsWith, int PageIndex, int PageSize, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope)
        {
            StringBuilder sbSql = GetSearchSql(ModuleId, PortalId, ItemsScope, SearchText, SearchOn, StartsWith, FromDate, ToDate, CategoryId);

            return db.Page<XYZ70Info>(PageIndex, PageSize, sbSql.ToString());
        }
        public IEnumerable<XYZ70Info> GetModuleXYZ70s(int ModuleId)
        {
            StringBuilder sbSql = GetFullSql(ModuleId, -1, 0);
            return db.Query<XYZ70Info>(sbSql.ToString());
        }

        #endregion

        #region " Userful Stored Procedures "
        public int SetViewOrderXYZ70s(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("SetViewOrderXYZ70s"), ModuleID);
            string strSP = ";EXEC " + GetDboName("SetViewOrderXYZ70s") + " @0";
            return db.Execute(strSP, ModuleID);
        }
        public int ClaimOrphanXYZ70s(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(PrefixCompanyID("ClaimOrphanXYZ70s"), ModuleID);
            string strSP = ";EXEC " + GetDboName("ClaimOrphanXYZ70s") + " @0";
            return db.Execute(strSP, ModuleID);
        }
        #endregion

        #region " Custom Import From Xls Csv Txt Files "

        public bool UpdateXYZ70s(string XlsCsvTxtFile)
        {
            bool success = false;
            try
            {
                CategoriesController objCategoriesController = new CategoriesController();
                //XYZ70sController objXYZ70sController = new XYZ70sController();
                //List<XYZ70Info> lot = ImportFromFile(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<XYZ70Info>(ImportXYZ70s(XlsCsvTxtFile));
                List<XYZ70Info> lot = ImportFromFile(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<XYZ70Info>(ImportXYZ70s(XlsCsvTxtFile));
                foreach (XYZ70Info XYZ70 in lot)
                {
                    XYZ70.CategoryId = objCategoriesController.GetCategoryIdAddIfNotExists(XYZ70.Category);
                    //objXYZ70sController.AddXYZ70(XYZ70);
                    AddXYZ70(XYZ70);
                }
                success = true;
            }
            catch { }
            return success;
        }

        #endregion //Custom Import From Xls Csv Txt Files

        #region " Optional Interface(s) Implementation "
        #region " ISearchable Members "
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //ArrayList XYZ70s = (ArrayList)GetModuleXYZ70s(ModInfo.ModuleID);
            //List<XYZ70Info> lotXYZ70s = GetModuleXYZ70s(ModInfo.ModuleID).ToLOT();//CBO.FillCollection<XYZ70Info>(GetModuleXYZ70s(ModInfo.ModuleID));
            IEnumerable<XYZ70Info> lotXYZ70s = GetModuleXYZ70s(ModInfo.ModuleID);//CBO.FillCollection<XYZ70Info>(GetModuleXYZ70s(ModInfo.ModuleID));

            //XYZ70Info objXYZ70;
            foreach (XYZ70Info objXYZ70 in lotXYZ70s)
            {
                SearchItemInfo SearchItem;

                int UserId = objXYZ70.CreatedByUserId;

                string strContent = HttpUtility.HtmlDecode(((XYZ70Info)objXYZ70).Title + " " + ((XYZ70Info)objXYZ70).Description);
                string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((XYZ70Info)objXYZ70).Description + " " + ((XYZ70Info)objXYZ70).Details), false), 100, "...");

                SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((XYZ70Info)objXYZ70).Title, strDescription, UserId, ((XYZ70Info)objXYZ70).CreatedDate, ModInfo.ModuleID, ((XYZ70Info)objXYZ70).ItemId.ToString(), strContent, "ItemId=" + ((XYZ70Info)objXYZ70).ItemId.ToString(), Null.NullInteger);
                SearchItemCollection.Add(SearchItem);

            }

            return SearchItemCollection;

        }
        #endregion //" ISearchable Members "
        #region " IPortable Members "
        public string ExportModule(int ModuleID)
        {
            //Hashtable settings = PortalSettings.GetModuleSettings(ModuleID);
            StringBuilder sbXML = new StringBuilder();
            sbXML.Append("<XYZ70s>");

            //Export each XYZ70 Details
            //ArrayList arrXYZ70s = (ArrayList)GetModuleXYZ70s(ModuleID);
            //List<XYZ70Info> lotXYZ70s = GetModuleXYZ70s(ModuleID).ToLOT();//CBO.FillCollection<XYZ70Info>(GetModuleXYZ70s(ModuleID));
            IEnumerable<XYZ70Info> lotXYZ70s = GetModuleXYZ70s(ModuleID);//CBO.FillCollection<XYZ70Info>(GetModuleXYZ70s(ModInfo.ModuleID));
            //if (lotXYZ70s.Count != 0)
            //{   
            //XYZ70Info objXYZ70;
            foreach (XYZ70Info objXYZ70 in lotXYZ70s)
            {
                sbXML.Append("<XYZ70>");
                sbXML.Append("<Title>" + XmlUtils.XMLEncode(objXYZ70.Title) + "</Title>");
                sbXML.Append("<CategoryId>" + XmlUtils.XMLEncode(objXYZ70.CategoryId.ToString()) + "</CategoryId>");
                sbXML.Append("<Category>" + XmlUtils.XMLEncode(objXYZ70.Category) + "</Category>");
                sbXML.Append("<MediaSrc>" + XmlUtils.XMLEncode(objXYZ70.MediaSrc) + "</MediaSrc>");
                sbXML.Append("<MediaWidth>" + XmlUtils.XMLEncode(objXYZ70.MediaWidth.ToString()) + "</MediaWidth>");
                sbXML.Append("<MediaHeight>" + XmlUtils.XMLEncode(objXYZ70.MediaHeight.ToString()) + "</MediaHeight>");
                sbXML.Append("<MediaAlign>" + XmlUtils.XMLEncode(objXYZ70.MediaAlign) + "</MediaAlign>");
                sbXML.Append("<Description>" + XmlUtils.XMLEncode(objXYZ70.Description) + "</Description>");

                //Actual Fields

                sbXML.Append("<Details>" + XmlUtils.XMLEncode(objXYZ70.Details) + "</Details>");
                sbXML.Append("<MediaSrc2>" + XmlUtils.XMLEncode(objXYZ70.MediaSrc2) + "</MediaSrc2>");
                sbXML.Append("<MediaWidth2>" + XmlUtils.XMLEncode(objXYZ70.MediaWidth2.ToString()) + "</MediaWidth2>");
                sbXML.Append("<MediaHeight2>" + XmlUtils.XMLEncode(objXYZ70.MediaHeight2.ToString()) + "</MediaHeight2>");
                sbXML.Append("<MediaAlign2>" + XmlUtils.XMLEncode(objXYZ70.MediaAlign2) + "</MediaAlign2>");
                sbXML.Append("<NavURL>" + XmlUtils.XMLEncode(objXYZ70.NavURL) + "</NavURL>");
                sbXML.Append("<PublishDate>" + XmlUtils.XMLEncode(objXYZ70.PublishDate.ToString()) + "</PublishDate>");
                sbXML.Append("<ExpiryDate>" + XmlUtils.XMLEncode(objXYZ70.ExpiryDate.ToString()) + "</ExpiryDate>");
                sbXML.Append("<ViewOrder>" + XmlUtils.XMLEncode(objXYZ70.ViewOrder.ToString()) + "</ViewOrder>");
                sbXML.Append("</XYZ70>");

            }
            //}

            //Export the Module Settings
            OptionsInfo objOI = new OptionsInfo(ModuleID);

            //Control Options
            sbXML.Append("<ItemsScope>" + XmlUtils.XMLEncode(objOI.ItemsScope.ToString()) + "</ItemsScope>");
            sbXML.Append("<ViewControl>" + XmlUtils.XMLEncode(objOI.ViewControl) + "</ViewControl>");
            sbXML.Append("<AddDescription>" + XmlUtils.XMLEncode(objOI.AddDescription.ToString()) + "</AddDescription>");
            sbXML.Append("<OnlyHostCanEdit>" + XmlUtils.XMLEncode(objOI.OnlyHostCanEdit.ToString()) + "</OnlyHostCanEdit>");
            //sbXML.Append("<BackColor>" + XmlUtils.XMLEncode(objOI.BackColor) + "</BackColor>");
            //sbXML.Append("<AltColor>" + XmlUtils.XMLEncode(objOI.AltColor) + "</AltColor>");
            //sbXML.Append("<HeaderBackColor>" + XmlUtils.XMLEncode(objOI.HeaderBackColor) + "</HeaderBackColor>");
            //sbXML.Append("<PagerBackColor>" + XmlUtils.XMLEncode(objOI.PagerBackColor) + "</PagerBackColor>");
            sbXML.Append("<TabCss>" + XmlUtils.XMLEncode(objOI.TabCss) + "</TabCss>");
            sbXML.Append("<NoOfPages>" + XmlUtils.XMLEncode(objOI.NoOfPages.ToString()) + "</NoOfPages>");
            sbXML.Append("<DeleteFromGrid>" + XmlUtils.XMLEncode(objOI.DeleteFromGrid.ToString()) + "</DeleteFromGrid>");
            sbXML.Append("<ViewOption>" + XmlUtils.XMLEncode(objOI.ViewOption) + "</ViewOption>");
            sbXML.Append("<AddDate>" + XmlUtils.XMLEncode(objOI.AddDate) + "</AddDate>");
            sbXML.Append("<ImagePosition>" + XmlUtils.XMLEncode(objOI.ImagePosition) + "</ImagePosition>");
            sbXML.Append("<DynamicThumb>" + XmlUtils.XMLEncode(objOI.DynamicThumb.ToString()) + "</DynamicThumb>");
            sbXML.Append("<UpdateRedirection>" + XmlUtils.XMLEncode(objOI.UpdateRedirection) + "</UpdateRedirection>");
            sbXML.Append("<ScrollColumns>" + XmlUtils.XMLEncode(objOI.ScrollColumns.ToString()) + "</ScrollColumns>");
            sbXML.Append("<TextMode>" + XmlUtils.XMLEncode(objOI.TextMode.ToString()) + "</TextMode>");
            sbXML.Append("<DisplayInfo>" + XmlUtils.XMLEncode(objOI.DisplayInfo.ToString()) + "</DisplayInfo>");
            sbXML.Append("<ThumbWidth>" + XmlUtils.XMLEncode(objOI.ThumbWidth) + "</ThumbWidth>");
            sbXML.Append("<ThumbHeight>" + XmlUtils.XMLEncode(objOI.ThumbHeight) + "</ThumbHeight>");
            sbXML.Append("<ThumbColumns>" + XmlUtils.XMLEncode(objOI.ThumbColumns.ToString()) + "</ThumbColumns>");
            sbXML.Append("<HideTextLink>" + XmlUtils.XMLEncode(objOI.HideTextLink.ToString()) + "</HideTextLink>");
            sbXML.Append("<InfoCssClass>" + XmlUtils.XMLEncode(objOI.InfoCssClass) + "</InfoCssClass>");
            sbXML.Append("<ScrollBehavior>" + XmlUtils.XMLEncode(objOI.ScrollBehavior) + "</ScrollBehavior>");
            sbXML.Append("<ScrollDirection>" + XmlUtils.XMLEncode(objOI.ScrollDirection) + "</ScrollDirection>");
            sbXML.Append("<ScrollAmount>" + XmlUtils.XMLEncode(objOI.ScrollAmount) + "</ScrollAmount>");
            sbXML.Append("<ScrollDelay>" + XmlUtils.XMLEncode(objOI.ScrollDelay) + "</ScrollDelay>");
            sbXML.Append("<ScrollWidth>" + XmlUtils.XMLEncode(objOI.ScrollWidth) + "</ScrollWidth>");
            sbXML.Append("<ScrollHeight>" + XmlUtils.XMLEncode(objOI.ScrollHeight) + "</ScrollHeight>");
            sbXML.Append("<CellPadding>" + XmlUtils.XMLEncode(objOI.CellPadding) + "</CellPadding>");
            sbXML.Append("<CellSpacing>" + XmlUtils.XMLEncode(objOI.CellSpacing) + "</CellSpacing>");
            sbXML.Append("<RattleImage>" + XmlUtils.XMLEncode(objOI.RattleImage.ToString()) + "</RattleImage>");
            sbXML.Append("<SSWidth>" + XmlUtils.XMLEncode(objOI.SSWidth) + "</SSWidth>");
            sbXML.Append("<SSHeight>" + XmlUtils.XMLEncode(objOI.SSHeight) + "</SSHeight>");
            sbXML.Append("<Delay>" + XmlUtils.XMLEncode(objOI.Delay) + "</Delay>");
            sbXML.Append("<Transition>" + XmlUtils.XMLEncode(objOI.Transition) + "</Transition>");
            sbXML.Append("<Thumbnail>" + XmlUtils.XMLEncode(objOI.Thumbnail.ToString()) + "</Thumbnail>");
            sbXML.Append("<ThumbnailWidth>" + XmlUtils.XMLEncode(objOI.ThumbnailWidth) + "</ThumbnailWidth>");
            sbXML.Append("<Resizing>" + XmlUtils.XMLEncode(objOI.Resizing) + "</Resizing>");
            sbXML.Append("<OnlyEmbedTag>" + XmlUtils.XMLEncode(objOI.OnlyEmbedTag.ToString()) + "</OnlyEmbedTag>");
            sbXML.Append("<ShowControls>" + XmlUtils.XMLEncode(objOI.ShowControls.ToString()) + "</ShowControls>");
            sbXML.Append("<SSTitle>" + XmlUtils.XMLEncode(objOI.SSTitle) + "</SSTitle>");
            sbXML.Append("<CaptionFont>" + XmlUtils.XMLEncode(objOI.CaptionFont) + "</CaptionFont>");
            sbXML.Append("<CaptionSize>" + XmlUtils.XMLEncode(objOI.CaptionSize.ToString()) + "</CaptionSize>");
            sbXML.Append("<BgColor>" + XmlUtils.XMLEncode(objOI.BgColor) + "</BgColor>");
            sbXML.Append("<FSSTransition>" + XmlUtils.XMLEncode(objOI.FSSTransition) + "</FSSTransition>");
            sbXML.Append("<Repeat>" + XmlUtils.XMLEncode(objOI.Repeat.ToString()) + "</Repeat>");
            sbXML.Append("<Streaming>" + XmlUtils.XMLEncode(objOI.Streaming.ToString()) + "</Streaming>");
            sbXML.Append("<EffectTime>" + XmlUtils.XMLEncode(objOI.EffectTime.ToString()) + "</EffectTime>");
            sbXML.Append("<TransitionTime>" + XmlUtils.XMLEncode(objOI.TransitionTime.ToString()) + "</TransitionTime>");
            sbXML.Append("<Volume>" + XmlUtils.XMLEncode(objOI.Volume.ToString()) + "</Volume>");
            sbXML.Append("<MusicUrl>" + XmlUtils.XMLEncode(objOI.MusicUrl) + "</MusicUrl>");
            sbXML.Append("<ShowMusicControls>" + XmlUtils.XMLEncode(objOI.ShowMusicControls.ToString()) + "</ShowMusicControls>");
            sbXML.Append("<ProgressColor>" + XmlUtils.XMLEncode(objOI.ProgressColor) + "</ProgressColor>");
            sbXML.Append("<TextColor>" + XmlUtils.XMLEncode(objOI.TextColor) + "</TextColor>");
            sbXML.Append("<ThumbFolder>" + XmlUtils.XMLEncode(objOI.ThumbFolder) + "</ThumbFolder>");
            sbXML.Append("<ThumbnailPosition>" + XmlUtils.XMLEncode(objOI.ThumbnailPosition) + "</ThumbnailPosition>");
            sbXML.Append("<ThumbnailRows>" + XmlUtils.XMLEncode(objOI.ThumbnailRows.ToString()) + "</ThumbnailRows>");
            sbXML.Append("<ThumbnailColumns>" + XmlUtils.XMLEncode(objOI.ThumbnailColumns.ToString()) + "</ThumbnailColumns>");
            sbXML.Append("<NTWidth>" + XmlUtils.XMLEncode(objOI.NTWidth) + "</NTWidth>");
            sbXML.Append("<NTHeight>" + XmlUtils.XMLEncode(objOI.NTHeight) + "</NTHeight>");
            sbXML.Append("<Pause>" + XmlUtils.XMLEncode(objOI.Pause) + "</Pause>");
            sbXML.Append("<Speed>" + XmlUtils.XMLEncode(objOI.Speed) + "</Speed>");
            sbXML.Append("<InitialJuke>" + XmlUtils.XMLEncode(objOI.InitialJuke.ToString()) + "</InitialJuke>");
            sbXML.Append("<AutoStart>" + XmlUtils.XMLEncode(objOI.AutoStart.ToString()) + "</AutoStart>");
            sbXML.Append("<AutoRewind>" + XmlUtils.XMLEncode(objOI.AutoRewind.ToString()) + "</AutoRewind>");
            sbXML.Append("<JukeSelector>" + XmlUtils.XMLEncode(objOI.JukeSelector.ToString()) + "</JukeSelector>");
            sbXML.Append("<ReferIt>" + XmlUtils.XMLEncode(objOI.ReferIt) + "</ReferIt>");
            sbXML.Append("<AutoRefresh>" + XmlUtils.XMLEncode(objOI.AutoRefresh.ToString()) + "</AutoRefresh>");
            sbXML.Append("<JukePager>" + XmlUtils.XMLEncode(objOI.JukePager.ToString()) + "</JukePager>");
            sbXML.Append("<ShowJukePanel>" + XmlUtils.XMLEncode(objOI.ShowJukePanel.ToString()) + "</ShowJukePanel>");
            sbXML.Append("<ShowReferJuke>" + XmlUtils.XMLEncode(objOI.ShowReferJuke.ToString()) + "</ShowReferJuke>");
            sbXML.Append("<ShowAddToFavourite>" + XmlUtils.XMLEncode(objOI.ShowAddToFavourite.ToString()) + "</ShowAddToFavourite>");
            sbXML.Append("<ShowDownload>" + XmlUtils.XMLEncode(objOI.ShowDownload.ToString()) + "</ShowDownload>");
            sbXML.Append("<ShowMusicDownload>" + XmlUtils.XMLEncode(objOI.ShowMusicDownload.ToString()) + "</ShowMusicDownload>");
            sbXML.Append("<ShowRatings>" + XmlUtils.XMLEncode(objOI.ShowRatings.ToString()) + "</ShowRatings>");
            sbXML.Append("<ShowSlotAvailability>" + XmlUtils.XMLEncode(objOI.ShowSlotAvailability.ToString()) + "</ShowSlotAvailability>");
            sbXML.Append("<swSaveEnabled>" + XmlUtils.XMLEncode(objOI.swSaveEnabled.ToString()) + "</swSaveEnabled>");
            sbXML.Append("<swVolume>" + XmlUtils.XMLEncode(objOI.swVolume.ToString()) + "</swVolume>");
            sbXML.Append("<swRestart>" + XmlUtils.XMLEncode(objOI.swRestart.ToString()) + "</swRestart>");
            sbXML.Append("<swPausePlay>" + XmlUtils.XMLEncode(objOI.swPausePlay.ToString()) + "</swPausePlay>");
            sbXML.Append("<swFastForward>" + XmlUtils.XMLEncode(objOI.swFastForward.ToString()) + "</swFastForward>");
            sbXML.Append("<swContextMenu>" + XmlUtils.XMLEncode(objOI.swContextMenu.ToString()) + "</swContextMenu>");

            sbXML.Append("<swRemote>" + XmlUtils.XMLEncode(objOI.swRemote) + "</swRemote>");
            sbXML.Append("<swStretchStyle>" + XmlUtils.XMLEncode(objOI.swStretchStyle) + "</swStretchStyle>");
            sbXML.Append("<FlvSkinUrl>" + XmlUtils.XMLEncode(objOI.FlvSkinUrl) + "</FlvSkinUrl>");
            sbXML.Append("<Palette>" + XmlUtils.XMLEncode(objOI.Palette) + "</Palette>");

            sbXML.Append("<awWindow>" + XmlUtils.XMLEncode(objOI.awWindow) + "</awWindow>");
            sbXML.Append("<RatingsInNewWindow>" + XmlUtils.XMLEncode(objOI.RatingsInNewWindow.ToString()) + "</RatingsInNewWindow>");
            sbXML.Append("<DataFolder>" + XmlUtils.XMLEncode(objOI.DataFolder) + "</DataFolder>");
            sbXML.Append("<PayPalId>" + XmlUtils.XMLEncode(objOI.PayPalId) + "</PayPalId>");

            sbXML.Append("<SlotAdPrice>" + XmlUtils.XMLEncode(objOI.SlotAdPrice.ToString()) + "</SlotAdPrice>");

            sbXML.Append("<UpdatedByUserId>" + XmlUtils.XMLEncode(objOI.UpdatedByUserId.ToString()) + "</UpdatedByUserId>");
            sbXML.Append("<UpdatedByUser>" + XmlUtils.XMLEncode(objOI.UpdatedByUser) + "</UpdatedByUser>");
            sbXML.Append("<UpdatedDate>" + XmlUtils.XMLEncode(objOI.UpdatedDate.ToString()) + "</UpdatedDate>");

            //Option1 Options
            sbXML.Append("<PagerSize>" + XmlUtils.XMLEncode(objOI.PagerSize.ToString()) + "</PagerSize>");



            sbXML.Append("</XYZ70s>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlXYZ70s = Globals.GetContent(Content, "XYZ70s");

            foreach (XmlNode xmlXYZ70 in xmlXYZ70s.SelectNodes("XYZ70"))
            {
                XYZ70Info objXYZ70 = new XYZ70Info();

                objXYZ70.ModuleId = ModuleID;

                objXYZ70.Title = xmlXYZ70["Title"].InnerText;
                try { objXYZ70.CategoryId = int.Parse(xmlXYZ70["CategoryId"].InnerText); }
                catch { }
                //try { objXYZ70.Category = xmlXYZ70["Category"].InnerText; }
                //catch { }
                try { objXYZ70.MediaSrc = Globals.ImportUrl(ModuleID, xmlXYZ70["MediaSrc"].InnerText); }
                catch { }
                try { objXYZ70.MediaWidth = xmlXYZ70["MediaWidth"].InnerText; }
                catch { }
                try { objXYZ70.MediaHeight = xmlXYZ70["MediaHeight"].InnerText; }
                catch { }
                try { objXYZ70.MediaAlign = xmlXYZ70["MediaAlign"].InnerText; }
                catch { }
                try { objXYZ70.Description = xmlXYZ70["Description"].InnerText; }
                catch { }

                //Actual Fields

                try { objXYZ70.Details = xmlXYZ70["Details"].InnerText; }
                catch { }
                try { objXYZ70.MediaSrc2 = Globals.ImportUrl(ModuleID, xmlXYZ70["MediaSrc2"].InnerText); }
                catch { }
                try { objXYZ70.MediaWidth2 = xmlXYZ70["MediaWidth2"].InnerText; }
                catch { }
                try { objXYZ70.MediaHeight2 = xmlXYZ70["MediaHeight2"].InnerText; }
                catch { }
                try { objXYZ70.MediaAlign2 = xmlXYZ70["MediaAlign2"].InnerText; }
                catch { }
                try { objXYZ70.NavURL = Globals.ImportUrl(ModuleID, xmlXYZ70["NavURL"].InnerText); }
                catch { }
                try { objXYZ70.PublishDate = DateTime.Parse(xmlXYZ70["PublishDate"].InnerText); }
                catch { }
                try { objXYZ70.ExpiryDate = DateTime.Parse(xmlXYZ70["ExpiryDate"].InnerText); }
                catch { }
                try { objXYZ70.ViewOrder = int.Parse(xmlXYZ70["ViewOrder"].InnerText); }
                catch { }

                objXYZ70.UpdatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objXYZ70.UpdatedDate = DateTime.Now;
                objXYZ70.CreatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objXYZ70.CreatedDate = DateTime.Now;


                AddXYZ70(objXYZ70);
            }

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.ItemsScope = int.Parse(xmlXYZ70s.SelectSingleNode("ItemsScope").InnerText); }
            catch { }
            try { objOI.ViewControl = xmlXYZ70s.SelectSingleNode("ViewControl").InnerText; }
            catch { }
            try { objOI.AddDescription = bool.Parse(xmlXYZ70s.SelectSingleNode("AddDescription").InnerText); }
            catch { }
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlXYZ70s.SelectSingleNode("OnlyHostCanEdit").InnerText); }
            catch { }
            //try { objOI.BackColor = xmlXYZ70s.SelectSingleNode("BackColor").InnerText; }
            //catch { }
            //try { objOI.AltColor = xmlXYZ70s.SelectSingleNode("AltColor").InnerText; }
            //catch { }
            //try { objOI.HeaderBackColor = xmlXYZ70s.SelectSingleNode("HeaderBackColor").InnerText; }
            //catch { }
            //try { objOI.PagerBackColor = xmlXYZ70s.SelectSingleNode("PagerBackColor").InnerText; }
            //catch { }
            try { objOI.TabCss = xmlXYZ70s.SelectSingleNode("TabCss").InnerText; }
            catch { }
            try { objOI.NoOfPages = int.Parse(xmlXYZ70s.SelectSingleNode("NoOfPages").InnerText); }
            catch { }
            try { objOI.DeleteFromGrid = bool.Parse(xmlXYZ70s.SelectSingleNode("DeleteFromGrid").InnerText); }
            catch { }
            try { objOI.ViewOption = xmlXYZ70s.SelectSingleNode("ViewOption").InnerText; }
            catch { }
            try { objOI.AddDate = xmlXYZ70s.SelectSingleNode("AddDate").InnerText; }
            catch { }
            try { objOI.ImagePosition = xmlXYZ70s.SelectSingleNode("ImagePosition").InnerText; }
            catch { }
            try { objOI.DynamicThumb = bool.Parse(xmlXYZ70s.SelectSingleNode("DynamicThumb").InnerText); }
            catch { }
            try { objOI.UpdateRedirection = xmlXYZ70s.SelectSingleNode("UpdateRedirection").InnerText; }
            catch { }
            try { objOI.ScrollColumns = int.Parse(xmlXYZ70s.SelectSingleNode("ScrollColumns").InnerText); }
            catch { }
            try { objOI.TextMode = bool.Parse(xmlXYZ70s.SelectSingleNode("TextMode").InnerText); }
            catch { }
            try { objOI.DisplayInfo = bool.Parse(xmlXYZ70s.SelectSingleNode("DisplayInfo").InnerText); }
            catch { }
            try { objOI.ThumbWidth = xmlXYZ70s.SelectSingleNode("ThumbWidth").InnerText; }
            catch { }
            try { objOI.ThumbHeight = xmlXYZ70s.SelectSingleNode("ThumbHeight").InnerText; }
            catch { }
            try { objOI.ThumbColumns = int.Parse(xmlXYZ70s.SelectSingleNode("ThumbColumns").InnerText); }
            catch { }
            try { objOI.HideTextLink = bool.Parse(xmlXYZ70s.SelectSingleNode("HideTextLink").InnerText); }
            catch { }
            try { objOI.InfoCssClass = xmlXYZ70s.SelectSingleNode("InfoCssClass").InnerText; }
            catch { }
            try { objOI.ScrollBehavior = xmlXYZ70s.SelectSingleNode("ScrollBehavior").InnerText; }
            catch { }
            try { objOI.ScrollDirection = xmlXYZ70s.SelectSingleNode("ScrollDirection").InnerText; }
            catch { }
            try { objOI.ScrollAmount = xmlXYZ70s.SelectSingleNode("ScrollAmount").InnerText; }
            catch { }
            try { objOI.ScrollDelay = xmlXYZ70s.SelectSingleNode("ScrollDelay").InnerText; }
            catch { }
            try { objOI.ScrollWidth = xmlXYZ70s.SelectSingleNode("ScrollWidth").InnerText; }
            catch { }
            try { objOI.ScrollHeight = xmlXYZ70s.SelectSingleNode("ScrollHeight").InnerText; }
            catch { }
            try { objOI.CellPadding = xmlXYZ70s.SelectSingleNode("CellPadding").InnerText; }
            catch { }
            try { objOI.CellSpacing = xmlXYZ70s.SelectSingleNode("CellSpacing").InnerText; }
            catch { }
            try { objOI.RattleImage = bool.Parse(xmlXYZ70s.SelectSingleNode("RattleImage").InnerText); }
            catch { }
            try { objOI.SSWidth = xmlXYZ70s.SelectSingleNode("SSWidth").InnerText; }
            catch { }
            try { objOI.SSHeight = xmlXYZ70s.SelectSingleNode("SSHeight").InnerText; }
            catch { }
            try { objOI.Delay = xmlXYZ70s.SelectSingleNode("Delay").InnerText; }
            catch { }
            try { objOI.Transition = xmlXYZ70s.SelectSingleNode("Transition").InnerText; }
            catch { }
            try { objOI.Thumbnail = bool.Parse(xmlXYZ70s.SelectSingleNode("Thumbnail").InnerText); }
            catch { }
            try { objOI.ThumbnailWidth = xmlXYZ70s.SelectSingleNode("ThumbnailWidth").InnerText; }
            catch { }
            try { objOI.Resizing = xmlXYZ70s.SelectSingleNode("Resizing").InnerText; }
            catch { }
            try
            {
                objOI.OnlyEmbedTag = bool.Parse(xmlXYZ70s.SelectSingleNode("OnlyEmbedTag").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowControls = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowControls").InnerText);
            }
            catch { }
            try
            {
                objOI.SSTitle = xmlXYZ70s.SelectSingleNode("SSTitle").InnerText;
            }
            catch { }
            try
            {
                objOI.CaptionFont = xmlXYZ70s.SelectSingleNode("CaptionFont").InnerText;
            }
            catch { }

            try
            {
                objOI.CaptionSize = int.Parse(xmlXYZ70s.SelectSingleNode("CaptionSize").InnerText);
            }
            catch { }
            try
            {
                objOI.BgColor = xmlXYZ70s.SelectSingleNode("BgColor").InnerText;
            }
            catch { }
            try
            {
                objOI.FSSTransition = xmlXYZ70s.SelectSingleNode("FSSTransition").InnerText;
            }
            catch { }
            try
            {
                objOI.Repeat = bool.Parse(xmlXYZ70s.SelectSingleNode("Repeat").InnerText);
            }
            catch { }
            try
            {
                objOI.Streaming = bool.Parse(xmlXYZ70s.SelectSingleNode("Streaming").InnerText);
            }
            catch { }
            try
            {
                objOI.EffectTime = double.Parse(xmlXYZ70s.SelectSingleNode("EffectTime").InnerText);
            }
            catch { }
            try
            {
                objOI.TransitionTime = int.Parse(xmlXYZ70s.SelectSingleNode("TransitionTime").InnerText);
            }
            catch { }
            try
            {
                objOI.Volume = int.Parse(xmlXYZ70s.SelectSingleNode("Volume").InnerText);
            }
            catch { }
            try
            {
                objOI.MusicUrl = xmlXYZ70s.SelectSingleNode("MusicUrl").InnerText;
            }
            catch { }
            try
            {
                objOI.ShowMusicControls = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowMusicControls").InnerText);
            }
            catch { }
            try
            {
                objOI.ProgressColor = xmlXYZ70s.SelectSingleNode("ProgressColor").InnerText;
            }
            catch { }
            try
            {
                objOI.TextColor = xmlXYZ70s.SelectSingleNode("TextColor").InnerText;
            }
            catch { }
            try
            {
                objOI.ThumbFolder = xmlXYZ70s.SelectSingleNode("ThumbFolder").InnerText;
            }
            catch { }
            try { objOI.ThumbnailPosition = xmlXYZ70s.SelectSingleNode("ThumbnailPosition").InnerText; }
            catch { }
            try { objOI.ThumbnailRows = int.Parse(xmlXYZ70s.SelectSingleNode("ThumbnailRows").InnerText); }
            catch { }
            try { objOI.ThumbnailColumns = int.Parse(xmlXYZ70s.SelectSingleNode("ThumbnailColumns").InnerText); }
            catch { }
            try { objOI.NTWidth = xmlXYZ70s.SelectSingleNode("NTWidth").InnerText; }
            catch { }
            try { objOI.NTHeight = xmlXYZ70s.SelectSingleNode("NTHeight").InnerText; }
            catch { }
            try { objOI.Pause = xmlXYZ70s.SelectSingleNode("Pause").InnerText; }
            catch { }
            try { objOI.Speed = xmlXYZ70s.SelectSingleNode("Speed").InnerText; }
            catch { }
            try { objOI.InitialJuke = int.Parse(xmlXYZ70s.SelectSingleNode("InitialJuke").InnerText); }
            catch { }
            try { objOI.AutoStart = bool.Parse(xmlXYZ70s.SelectSingleNode("AutoStart").InnerText); }
            catch { }
            try
            {
                objOI.AutoRewind = bool.Parse(xmlXYZ70s.SelectSingleNode("AutoRewind").InnerText);
            }
            catch { }
            try
            {
                objOI.JukeSelector = int.Parse(xmlXYZ70s.SelectSingleNode("JukeSelector").InnerText);
            }
            catch { }
            try
            {
                objOI.ReferIt = xmlXYZ70s.SelectSingleNode("ReferIt").InnerText;
            }
            catch { }
            try
            {
                objOI.AutoRefresh = int.Parse(xmlXYZ70s.SelectSingleNode("AutoRefresh").InnerText);
            }
            catch { }
            try
            {
                objOI.JukePager = int.Parse(xmlXYZ70s.SelectSingleNode("JukePager").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowJukePanel = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowJukePanel").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowReferJuke = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowReferJuke").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowAddToFavourite = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowAddToFavourite").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowDownload = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowDownload").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowMusicDownload = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowMusicDownload").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowRatings = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowRatings").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowSlotAvailability = bool.Parse(xmlXYZ70s.SelectSingleNode("ShowSlotAvailability").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swSaveEnabled = bool.Parse(xmlXYZ70s.SelectSingleNode("swSaveEnabled").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swVolume = bool.Parse(xmlXYZ70s.SelectSingleNode("swVolume").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRestart = bool.Parse(xmlXYZ70s.SelectSingleNode("swRestart").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swPausePlay = bool.Parse(xmlXYZ70s.SelectSingleNode("swPausePlay").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swFastForward = bool.Parse(xmlXYZ70s.SelectSingleNode("swFastForward").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swContextMenu = bool.Parse(xmlXYZ70s.SelectSingleNode("swContextMenu").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRemote = xmlXYZ70s.SelectSingleNode("swRemote").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Speed = xmlXYZ70s.SelectSingleNode("Speed").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.FlvSkinUrl = xmlXYZ70s.SelectSingleNode("FlvSkinUrl").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Palette = xmlXYZ70s.SelectSingleNode("Palette").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.awWindow = xmlXYZ70s.SelectSingleNode("awWindow").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.RatingsInNewWindow = bool.Parse(xmlXYZ70s.SelectSingleNode("RatingsInNewWindow").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.DataFolder = xmlXYZ70s.SelectSingleNode("DataFolder").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.PayPalId = xmlXYZ70s.SelectSingleNode("PayPalId").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.SlotAdPrice = decimal.Parse(xmlXYZ70s.SelectSingleNode("SlotAdPrice").InnerText);
            }
            catch
            {

            }

            try
            {
                objOI.UpdatedByUserId = int.Parse(xmlXYZ70s.SelectSingleNode("UpdatedByUserId").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.UpdatedByUser = xmlXYZ70s.SelectSingleNode("UpdatedByUser").InnerText;
            }
            catch
            {
            }
            try { objOI.UpdatedDate = DateTime.Parse(xmlXYZ70s.SelectSingleNode("UpdatedDate").InnerText); }
            catch { }

            //Option1 Options
            try { objOI.PagerSize = int.Parse(xmlXYZ70s.SelectSingleNode("PagerSize").InnerText); }
            catch { }

            objOI.Update(ModuleID);
        }
        #endregion //" IPortable Members "
        #region " IUpgradeable Members "
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Implements the upgrade interface for DotNetNuke
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {
            InitPermissions();
            //SetPortalSettings();
            return Version;
        }

        private void SetPortalSettings()
        {
            //PortalSettings.UpdateSiteSetting(0, "ControlPanelSecurity", "TAB");
            PortalController.UpdatePortalSetting(0, "ControlPanelSecurity", "TAB");
            //PortalSettings.UpdateSiteSetting(0, "ControlPanelVisibility", "MIN");
            PortalController.UpdatePortalSetting(0, "ControlPanelVisibility", "MIN");
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// adds the module specific permissions
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        private void InitPermissions()
        {
            //Definition
            string ModuleFriendlyName = "bhattji.XYZ70s";
            string ModuleName = "bhattji.XYZ70s";
            //string PathOfModule = "/DesktopModules/Feedback/";
            //string SharedResources = "~/" + PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";

            //Permissions
            string Code = "bhattji.XYZ70s_PERMISSION";
            //string ModerateFeedbackPosts = "MODERATEPOSTS";
            //string ManageFeedbackLists = "MANAGELISTS";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add XYZ70", "Alter XYZ70", "Approve XYZ70", "Configure XYZ70", "Delete XYZ70", "SelfEdit XYZ70" };
            //bool[] permissionExists = new bool[2] { false, false };

            //PermissionFlags
            //bool bModeratePosts = false;
            //bool bManageLists = false;

            PermissionController pc = new PermissionController();
            ArrayList permissions = pc.GetPermissionByCodeAndKey(Code, null);
            DesktopModuleController dc = new DesktopModuleController();
            //DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByName(ModuleFriendlyName);
            //DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByFriendlyName(ModuleFriendlyName);
            DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByModuleName(ModuleName);
            //DesktopModuleInfo desktopInfo = DesktopModuleController.GetDesktopModuleByModuleName(ModuleName, 0);
            ModuleDefinitionController mc = new ModuleDefinitionController();
            ModuleDefinitionInfo mInfo = ModuleDefinitionController.GetModuleDefinitionByFriendlyName(ModuleFriendlyName, desktopInfo.DesktopModuleID);
            //ModuleDefinitionInfo mInfo = mc.GetModuleDefinitionByName(desktopInfo.DesktopModuleID, ModuleFriendlyName);
            //ModuleDefinitionInfo mInfo = ModuleDefinitionController.GetModuleDefinitionByFriendlyName(ModuleFriendlyName,desktopInfo.DesktopModuleID);
            int moduleDefId = mInfo.ModuleDefID;

            //foreach (PermissionInfo p in permissions)
            //{
            //    if (p.ModuleDefID == moduleDefId)
            //    {
            //        for (int i = 0; i < permissionKeys.GetLength(0); i++)
            //        {
            //            //if (p.PermissionKey == permissionKeys[i]) permissionExists[i] = true;
            //            if (p.PermissionKey == permissionKeys[i]) permissionKeys[i] = "permissionExists";
            //        }
            //    }
            //}

            //for (int i = 0; i < permissionKeys.GetLength(0); i++)
            //{
            //    if (permissionKeys[i] != "permissionExists")
            //    {
            //        PermissionInfo p = new PermissionInfo();
            //        p.ModuleDefID = moduleDefId;
            //        p.PermissionCode = Code;
            //        p.PermissionKey = permissionKeys[i];//"MODERATEPOSTS";
            //        p.PermissionName = permissionNames[i];//"Moderate Posts";
            //        pc.AddPermission(p);
            //    }
            //}
            for (int i = 0; i < permissionKeys.GetLength(0); i++)
            {
                foreach (PermissionInfo p in permissions)
                {
                    if ((p.ModuleDefID == moduleDefId) && (p.PermissionKey == permissionKeys[i]))
                    {
                        permissionKeys[i] = "permissionExists";
                        break;
                    }
                }
                if (permissionKeys[i] != "permissionExists")
                {
                    PermissionInfo p = new PermissionInfo();
                    p.ModuleDefID = moduleDefId;
                    p.PermissionCode = Code;
                    p.PermissionKey = permissionKeys[i];//"MODERATEPOSTS";
                    p.PermissionName = permissionNames[i];//"Moderate Posts";
                    pc.AddPermission(p);
                }
            }
        }//InitPermissions
        //private void InitPermissions1()
        //{
        //    //Definition
        //    string ModuleFriendlyName = "Feedback";
        //    //string ModuleName = "Feedback";
        //    //string PathOfModule = "/DesktopModules/Feedback/";
        //    //string SharedResources = "~/" + PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";

        //    //Permissions
        //    string Code = "FEEDBACK_PERMISSION";
        //    //string ModerateFeedbackPosts = "MODERATEPOSTS";
        //    //string ManageFeedbackLists = "MANAGELISTS";

        //    //PermissionFlags
        //    bool bModeratePosts = false;
        //    bool bManageLists = false;

        //    PermissionController pc = new PermissionController();
        //    ArrayList permissions = pc.GetPermissionByCodeAndKey(Code, null);
        //    DesktopModuleController dc = new DesktopModuleController();
        //    DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByName(ModuleFriendlyName);
        //    //DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByModuleName(Definition.ModuleName);
        //    ModuleDefinitionController mc = new ModuleDefinitionController();
        //    ModuleDefinitionInfo mInfo = mc.GetModuleDefinitionByName(desktopInfo.DesktopModuleID, ModuleFriendlyName);
        //    int moduleDefId = mInfo.ModuleDefID;

        //    foreach (PermissionInfo p in permissions)
        //    {
        //        if (p.ModuleDefID == moduleDefId)
        //        {
        //            if (p.PermissionKey == "MODERATEPOSTS") bModeratePosts = true;
        //            if (p.PermissionKey == "MANAGELISTS") bManageLists = true;
        //        }
        //    }
        //    if (!bModeratePosts)
        //    {
        //        PermissionInfo p = new PermissionInfo();
        //        p.ModuleDefID = moduleDefId;
        //        p.PermissionCode = Code;
        //        p.PermissionKey = "MODERATEPOSTS";
        //        p.PermissionName = "Moderate Posts";
        //        pc.AddPermission(p);
        //    }
        //    if (!bManageLists)
        //    {
        //        PermissionInfo p = new PermissionInfo();
        //        p.ModuleDefID = moduleDefId;
        //        p.PermissionCode = Code;
        //        p.PermissionKey = "MANAGELISTS";
        //        p.PermissionName = "Manage Feedback Lists";
        //        pc.AddPermission(p);
        //    }
        //}//InitPermissions

        //public class Definition
        //{
        //    public const string PathOfModule = "/DesktopModules/Feedback/";
        //    public const string ModuleFriendlyName = "Feedback";
        //    //public const string ModuleName = "Feedback";
        //    public const string SharedResources = "~/" + Definition.PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";
        //}//Definition

        //public class PermissionName
        //{
        //    public const string ModerateFeedbackPosts = "MODERATEPOSTS";
        //    public const string ManageFeedbackLists = "MANAGELISTS";
        //    public const string Code = "FEEDBACK_PERMISSION";

        //}//PermissionName
        #endregion //" IUpgradeable Members "
        #endregion //" Optional Interface(s) Implementation "
    } //XYZ70sController
} //bhattji.Modules.XYZ70s