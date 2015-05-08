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
using bhattji.Modules.XYZ60s.PetaPoco;
//using DotNetNuke.ComponentModel.DataAnnotations;


namespace bhattji.Modules.XYZ60s
{
    [Serializable]
    [TableName("bhattji_XYZ60s")]
    [PrimaryKey("ItemId")]
    public class XYZ60Info
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
                if (PublishDate.HasValue && (PublishDate > DateTime.MinValue)) //(PublishDate > Convert.ToDateTime("1/1/0001"))) //
                    return Convert.ToDateTime(PublishDate).ToShortDateString();
                else
                    return string.Empty;
            }
            set
            {
                try
                {
                    PublishDate = Convert.ToDateTime(value);
                    if (PublishDate < Convert.ToDateTime("1/1/1753")) //DateTime.MinValue)
                        PublishDate = null;
                    //PublishDate = Convert.ToDateTime("1/1/1753"); //DateTime.MinValue;
                }
                catch
                {

                }
            }
        }
        public DateTime? ExpiryDate { get; set; }
        [Ignore]
        public string ExpiryDateString
        {
            get
            {
                if (ExpiryDate.HasValue && (ExpiryDate > DateTime.MinValue)) //(ExpiryDate > Convert.ToDateTime("1/1/1753")))
                    return Convert.ToDateTime(ExpiryDate).ToShortDateString();
                else
                    return string.Empty;
            }
            set
            {
                try
                {
                    ExpiryDate = Convert.ToDateTime(value);
                    if (ExpiryDate < Convert.ToDateTime("1/1/1753"))
                        ExpiryDate = null;

                    //ExpiryDate = Convert.ToDateTime("1/1/1753");
                }
                catch
                {

                }
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
                return ViewOrder > 0 ? ViewOrder.ToString() : string.Empty;
            }
            set
            {
                try { ViewOrder = Convert.ToInt32(value); }catch { }
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
    } //XYZ60Info
    public class XYZ60sController : CommonControllerMethods, ISearchable, IPortable, IUpgradeable
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

            sbSql.Append("FROM " + GetDboName("XYZ60s") + " AS x ");
            sbSql.Append(ScopeJoins);
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("UrlTracking") + " As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uu ON x.UpdatedByUserId = uu.UserId ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uc ON x.CreatedByUserId = uc.UserId ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ60Categories") + " AS ca ON x.CategoryId = ca.ItemId ");

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

            sbSql.Append("FROM " + GetDboName("XYZ60s") + " AS x ");
            sbSql.Append(ScopeJoins);
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Files") + " As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("UrlTracking") + " As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");
            //sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uu ON x.UpdatedByUserId = uu.UserId ");
            //sbSql.Append("LEFT OUTER JOIN " + PrefixObjectQualifier("Users") + " AS uc ON x.CreatedByUserId = uc.UserId ");
            //sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ60Categories") + " AS ca ON x.CategoryId = ca.ItemId ");

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
        public int AddUpdateXYZ60(XYZ60Info objXYZ60)
        {
            if (objXYZ60.ItemId > 0)
            {
                UpdateXYZ60(objXYZ60);
                return objXYZ60.ItemId;
            }
            else
            {
                return AddXYZ60(objXYZ60);
            }
        }

        public int AddXYZ60(XYZ60Info objXYZ60)
        {
            return Convert.ToInt32(db.Insert(GetDboName("XYZ60s"), "ItemId", objXYZ60));//returns the (object) Primary Field Added
        }

        public int UpdateXYZ60(XYZ60Info objXYZ60)
        {
            return db.Update(GetDboName("XYZ60s"), "ItemId", objXYZ60);
        }

        public int UpdateXYZ60Rating(int ItemId, int RatingTotal)
        {
            XYZ60Info objXYZInfo = GetXYZ60(ItemId);
            if (objXYZInfo.RatingVotes < 1)
                objXYZInfo.RatingVotes = 1;
            else
                objXYZInfo.RatingVotes += 1;

            if (objXYZInfo.RatingTotal < 1)
                objXYZInfo.RatingTotal = RatingTotal;
            else
                objXYZInfo.RatingTotal += RatingTotal;
            return db.Update(GetDboName("XYZ60s"), "ItemId", objXYZInfo, new string[] { "RatingVotes", "RatingTotal" });
        }

        public int DeleteXYZ60(XYZ60Info objXYZ60)
        {
            return db.Delete(GetDboName("XYZ60s"), "ItemId", objXYZ60);
        }

        public int DeleteXYZ60(int ItemID)
        {
            return db.Delete(GetDboName("XYZ60s"), "ItemId", null, ItemID);
        }

        public int GetXYZ60Id(string Title)
        {
            //return DataProvider.Instance().ExecuteScalar<int>(PrefixCompanyID("GetXYZ60Id"), Title);
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT TOP 1 ItemId ");
            sbSql.Append("FROM " + GetDboName("XYZ60s") + " ");
            sbSql.Append("WHERE Title = " + Title);

            return db.ExecuteScalar<int>(sbSql.ToString());
        }
        public XYZ60Info GetXYZ60(string Title)
        {
            return GetXYZ60(GetXYZ60Id(Title));
        }
        public XYZ60Info GetXYZ60(int ItemID)
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

            sbSql.Append("FROM " + GetDboName("XYZ60s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Files") + "] As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("UrlTracking") + "] As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");

            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Users") + "] AS uu ON x.UpdatedByUserId = uu.UserId ");
            sbSql.Append("LEFT OUTER JOIN [" + PrefixObjectQualifier("Users") + "] AS uc ON x.CreatedByUserId = uc.UserId ");

            sbSql.Append("LEFT OUTER JOIN [" + GetDboName("XYZ60Categories") + "] AS ca ON x.CategoryId = ca.ItemId ");

            sbSql.Append("WHERE x.ItemID = " + ItemID.ToString());

            return db.SingleOrDefault<XYZ60Info>(sbSql.ToString());
        }

        public Page<XYZ60Info> GetPagedXYZ60s(string SearchText, string SearchOn, bool StartsWith, int PageIndex, int PageSize, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope)
        {
            StringBuilder sbSql = GetSearchSql(ModuleId, PortalId, ItemsScope, SearchText, SearchOn, StartsWith, FromDate, ToDate, CategoryId);

            return db.Page<XYZ60Info>(PageIndex, PageSize, sbSql.ToString());
        }
        public IEnumerable<XYZ60Info> GetModuleXYZ60s(int ModuleId)
        {
            StringBuilder sbSql = GetFullSql(ModuleId, -1, 0);
            return db.Query<XYZ60Info>(sbSql.ToString());
        }

        #endregion

        #region " Userful Stored Procedures "
        public int SetViewOrderXYZ60s(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("SetViewOrderXYZ60s"), ModuleID);
            string strSP = ";EXEC " + GetDboName("SetViewOrderXYZ60s") + " @0";
            return db.Execute(strSP, ModuleID);
        }
        public int ClaimOrphanXYZ60s(int ModuleID)
        {
            //DataProvider.Instance().ExecuteNonQuery(PrefixCompanyID("ClaimOrphanXYZ60s"), ModuleID);
            string strSP = ";EXEC " + GetDboName("ClaimOrphanXYZ60s") + " @0";
            return db.Execute(strSP, ModuleID);
        }
        #endregion

        #region " Custom Import From Xls Csv Txt Files "

        public bool UpdateXYZ60s(string XlsCsvTxtFile)
        {
            bool success = false;
            try
            {
                CategoriesController objCategoriesController = new CategoriesController();
                //XYZ60sController objXYZ60sController = new XYZ60sController();
                //List<XYZ60Info> lot = ImportFromFile(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<XYZ60Info>(ImportXYZ60s(XlsCsvTxtFile));
                List<XYZ60Info> lot = ImportFromFile(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<XYZ60Info>(ImportXYZ60s(XlsCsvTxtFile));
                foreach (XYZ60Info XYZ60 in lot)
                {
                    XYZ60.CategoryId = objCategoriesController.GetCategoryIdAddIfNotExists(XYZ60.Category);
                    //objXYZ60sController.AddXYZ60(XYZ60);
                    AddXYZ60(XYZ60);
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

            //ArrayList XYZ60s = (ArrayList)GetModuleXYZ60s(ModInfo.ModuleID);
            //List<XYZ60Info> lotXYZ60s = GetModuleXYZ60s(ModInfo.ModuleID).ToLOT();//CBO.FillCollection<XYZ60Info>(GetModuleXYZ60s(ModInfo.ModuleID));
            IEnumerable<XYZ60Info> lotXYZ60s = GetModuleXYZ60s(ModInfo.ModuleID);//CBO.FillCollection<XYZ60Info>(GetModuleXYZ60s(ModInfo.ModuleID));

            //XYZ60Info objXYZ60;
            foreach (XYZ60Info objXYZ60 in lotXYZ60s)
            {
                SearchItemInfo SearchItem;

                int UserId = objXYZ60.CreatedByUserId;

                string strContent = HttpUtility.HtmlDecode(((XYZ60Info)objXYZ60).Title + " " + ((XYZ60Info)objXYZ60).Description);
                string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((XYZ60Info)objXYZ60).Description + " " + ((XYZ60Info)objXYZ60).Details), false), 100, "...");

                SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((XYZ60Info)objXYZ60).Title, strDescription, UserId, ((XYZ60Info)objXYZ60).CreatedDate, ModInfo.ModuleID, ((XYZ60Info)objXYZ60).ItemId.ToString(), strContent, "ItemId=" + ((XYZ60Info)objXYZ60).ItemId.ToString(), Null.NullInteger);
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
            sbXML.Append("<XYZ60s>");

            //Export each XYZ60 Details
            //ArrayList arrXYZ60s = (ArrayList)GetModuleXYZ60s(ModuleID);
            //List<XYZ60Info> lotXYZ60s = GetModuleXYZ60s(ModuleID).ToLOT();//CBO.FillCollection<XYZ60Info>(GetModuleXYZ60s(ModuleID));
            IEnumerable<XYZ60Info> lotXYZ60s = GetModuleXYZ60s(ModuleID);//CBO.FillCollection<XYZ60Info>(GetModuleXYZ60s(ModInfo.ModuleID));
            //if (lotXYZ60s.Count != 0)
            //{   
            //XYZ60Info objXYZ60;
            foreach (XYZ60Info objXYZ60 in lotXYZ60s)
            {
                sbXML.Append("<XYZ60>");
                sbXML.Append("<Title>" + XmlUtils.XMLEncode(objXYZ60.Title) + "</Title>");
                sbXML.Append("<CategoryId>" + XmlUtils.XMLEncode(objXYZ60.CategoryId.ToString()) + "</CategoryId>");
                sbXML.Append("<Category>" + XmlUtils.XMLEncode(objXYZ60.Category) + "</Category>");
                sbXML.Append("<MediaSrc>" + XmlUtils.XMLEncode(objXYZ60.MediaSrc) + "</MediaSrc>");
                sbXML.Append("<MediaWidth>" + XmlUtils.XMLEncode(objXYZ60.MediaWidth.ToString()) + "</MediaWidth>");
                sbXML.Append("<MediaHeight>" + XmlUtils.XMLEncode(objXYZ60.MediaHeight.ToString()) + "</MediaHeight>");
                sbXML.Append("<MediaAlign>" + XmlUtils.XMLEncode(objXYZ60.MediaAlign) + "</MediaAlign>");
                sbXML.Append("<Description>" + XmlUtils.XMLEncode(objXYZ60.Description) + "</Description>");

                //Actual Fields

                sbXML.Append("<Details>" + XmlUtils.XMLEncode(objXYZ60.Details) + "</Details>");
                sbXML.Append("<MediaSrc2>" + XmlUtils.XMLEncode(objXYZ60.MediaSrc2) + "</MediaSrc2>");
                sbXML.Append("<MediaWidth2>" + XmlUtils.XMLEncode(objXYZ60.MediaWidth2.ToString()) + "</MediaWidth2>");
                sbXML.Append("<MediaHeight2>" + XmlUtils.XMLEncode(objXYZ60.MediaHeight2.ToString()) + "</MediaHeight2>");
                sbXML.Append("<MediaAlign2>" + XmlUtils.XMLEncode(objXYZ60.MediaAlign2) + "</MediaAlign2>");
                sbXML.Append("<NavURL>" + XmlUtils.XMLEncode(objXYZ60.NavURL) + "</NavURL>");
                sbXML.Append("<PublishDate>" + XmlUtils.XMLEncode(objXYZ60.PublishDate.ToString()) + "</PublishDate>");
                sbXML.Append("<ExpiryDate>" + XmlUtils.XMLEncode(objXYZ60.ExpiryDate.ToString()) + "</ExpiryDate>");
                sbXML.Append("<ViewOrder>" + XmlUtils.XMLEncode(objXYZ60.ViewOrder.ToString()) + "</ViewOrder>");
                sbXML.Append("</XYZ60>");

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



            sbXML.Append("</XYZ60s>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlXYZ60s = Globals.GetContent(Content, "XYZ60s");

            foreach (XmlNode xmlXYZ60 in xmlXYZ60s.SelectNodes("XYZ60"))
            {
                XYZ60Info objXYZ60 = new XYZ60Info();

                objXYZ60.ModuleId = ModuleID;

                objXYZ60.Title = xmlXYZ60["Title"].InnerText;
                try { objXYZ60.CategoryId = int.Parse(xmlXYZ60["CategoryId"].InnerText); }
                catch { }
                //try { objXYZ60.Category = xmlXYZ60["Category"].InnerText; }
                //catch { }
                try { objXYZ60.MediaSrc = Globals.ImportUrl(ModuleID, xmlXYZ60["MediaSrc"].InnerText); }
                catch { }
                try { objXYZ60.MediaWidth = xmlXYZ60["MediaWidth"].InnerText; }
                catch { }
                try { objXYZ60.MediaHeight = xmlXYZ60["MediaHeight"].InnerText; }
                catch { }
                try { objXYZ60.MediaAlign = xmlXYZ60["MediaAlign"].InnerText; }
                catch { }
                try { objXYZ60.Description = xmlXYZ60["Description"].InnerText; }
                catch { }

                //Actual Fields

                try { objXYZ60.Details = xmlXYZ60["Details"].InnerText; }
                catch { }
                try { objXYZ60.MediaSrc2 = Globals.ImportUrl(ModuleID, xmlXYZ60["MediaSrc2"].InnerText); }
                catch { }
                try { objXYZ60.MediaWidth2 = xmlXYZ60["MediaWidth2"].InnerText; }
                catch { }
                try { objXYZ60.MediaHeight2 = xmlXYZ60["MediaHeight2"].InnerText; }
                catch { }
                try { objXYZ60.MediaAlign2 = xmlXYZ60["MediaAlign2"].InnerText; }
                catch { }
                try { objXYZ60.NavURL = Globals.ImportUrl(ModuleID, xmlXYZ60["NavURL"].InnerText); }
                catch { }
                try { objXYZ60.PublishDate = DateTime.Parse(xmlXYZ60["PublishDate"].InnerText); }
                catch { }
                try { objXYZ60.ExpiryDate = DateTime.Parse(xmlXYZ60["ExpiryDate"].InnerText); }
                catch { }
                try { objXYZ60.ViewOrder = int.Parse(xmlXYZ60["ViewOrder"].InnerText); }
                catch { }

                objXYZ60.UpdatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objXYZ60.UpdatedDate = DateTime.Now;
                objXYZ60.CreatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objXYZ60.CreatedDate = DateTime.Now;


                AddXYZ60(objXYZ60);
            }

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.ItemsScope = int.Parse(xmlXYZ60s.SelectSingleNode("ItemsScope").InnerText); }
            catch { }
            try { objOI.ViewControl = xmlXYZ60s.SelectSingleNode("ViewControl").InnerText; }
            catch { }
            try { objOI.AddDescription = bool.Parse(xmlXYZ60s.SelectSingleNode("AddDescription").InnerText); }
            catch { }
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlXYZ60s.SelectSingleNode("OnlyHostCanEdit").InnerText); }
            catch { }
            //try { objOI.BackColor = xmlXYZ60s.SelectSingleNode("BackColor").InnerText; }
            //catch { }
            //try { objOI.AltColor = xmlXYZ60s.SelectSingleNode("AltColor").InnerText; }
            //catch { }
            //try { objOI.HeaderBackColor = xmlXYZ60s.SelectSingleNode("HeaderBackColor").InnerText; }
            //catch { }
            //try { objOI.PagerBackColor = xmlXYZ60s.SelectSingleNode("PagerBackColor").InnerText; }
            //catch { }
            try { objOI.TabCss = xmlXYZ60s.SelectSingleNode("TabCss").InnerText; }
            catch { }
            try { objOI.NoOfPages = int.Parse(xmlXYZ60s.SelectSingleNode("NoOfPages").InnerText); }
            catch { }
            try { objOI.DeleteFromGrid = bool.Parse(xmlXYZ60s.SelectSingleNode("DeleteFromGrid").InnerText); }
            catch { }
            try { objOI.ViewOption = xmlXYZ60s.SelectSingleNode("ViewOption").InnerText; }
            catch { }
            try { objOI.AddDate = xmlXYZ60s.SelectSingleNode("AddDate").InnerText; }
            catch { }
            try { objOI.ImagePosition = xmlXYZ60s.SelectSingleNode("ImagePosition").InnerText; }
            catch { }
            try { objOI.DynamicThumb = bool.Parse(xmlXYZ60s.SelectSingleNode("DynamicThumb").InnerText); }
            catch { }
            try { objOI.UpdateRedirection = xmlXYZ60s.SelectSingleNode("UpdateRedirection").InnerText; }
            catch { }
            try { objOI.ScrollColumns = int.Parse(xmlXYZ60s.SelectSingleNode("ScrollColumns").InnerText); }
            catch { }
            try { objOI.TextMode = bool.Parse(xmlXYZ60s.SelectSingleNode("TextMode").InnerText); }
            catch { }
            try { objOI.DisplayInfo = bool.Parse(xmlXYZ60s.SelectSingleNode("DisplayInfo").InnerText); }
            catch { }
            try { objOI.ThumbWidth = xmlXYZ60s.SelectSingleNode("ThumbWidth").InnerText; }
            catch { }
            try { objOI.ThumbHeight = xmlXYZ60s.SelectSingleNode("ThumbHeight").InnerText; }
            catch { }
            try { objOI.ThumbColumns = int.Parse(xmlXYZ60s.SelectSingleNode("ThumbColumns").InnerText); }
            catch { }
            try { objOI.HideTextLink = bool.Parse(xmlXYZ60s.SelectSingleNode("HideTextLink").InnerText); }
            catch { }
            try { objOI.InfoCssClass = xmlXYZ60s.SelectSingleNode("InfoCssClass").InnerText; }
            catch { }
            try { objOI.ScrollBehavior = xmlXYZ60s.SelectSingleNode("ScrollBehavior").InnerText; }
            catch { }
            try { objOI.ScrollDirection = xmlXYZ60s.SelectSingleNode("ScrollDirection").InnerText; }
            catch { }
            try { objOI.ScrollAmount = xmlXYZ60s.SelectSingleNode("ScrollAmount").InnerText; }
            catch { }
            try { objOI.ScrollDelay = xmlXYZ60s.SelectSingleNode("ScrollDelay").InnerText; }
            catch { }
            try { objOI.ScrollWidth = xmlXYZ60s.SelectSingleNode("ScrollWidth").InnerText; }
            catch { }
            try { objOI.ScrollHeight = xmlXYZ60s.SelectSingleNode("ScrollHeight").InnerText; }
            catch { }
            try { objOI.CellPadding = xmlXYZ60s.SelectSingleNode("CellPadding").InnerText; }
            catch { }
            try { objOI.CellSpacing = xmlXYZ60s.SelectSingleNode("CellSpacing").InnerText; }
            catch { }
            try { objOI.RattleImage = bool.Parse(xmlXYZ60s.SelectSingleNode("RattleImage").InnerText); }
            catch { }
            try { objOI.SSWidth = xmlXYZ60s.SelectSingleNode("SSWidth").InnerText; }
            catch { }
            try { objOI.SSHeight = xmlXYZ60s.SelectSingleNode("SSHeight").InnerText; }
            catch { }
            try { objOI.Delay = xmlXYZ60s.SelectSingleNode("Delay").InnerText; }
            catch { }
            try { objOI.Transition = xmlXYZ60s.SelectSingleNode("Transition").InnerText; }
            catch { }
            try { objOI.Thumbnail = bool.Parse(xmlXYZ60s.SelectSingleNode("Thumbnail").InnerText); }
            catch { }
            try { objOI.ThumbnailWidth = xmlXYZ60s.SelectSingleNode("ThumbnailWidth").InnerText; }
            catch { }
            try { objOI.Resizing = xmlXYZ60s.SelectSingleNode("Resizing").InnerText; }
            catch { }
            try
            {
                objOI.OnlyEmbedTag = bool.Parse(xmlXYZ60s.SelectSingleNode("OnlyEmbedTag").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowControls = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowControls").InnerText);
            }
            catch { }
            try
            {
                objOI.SSTitle = xmlXYZ60s.SelectSingleNode("SSTitle").InnerText;
            }
            catch { }
            try
            {
                objOI.CaptionFont = xmlXYZ60s.SelectSingleNode("CaptionFont").InnerText;
            }
            catch { }

            try
            {
                objOI.CaptionSize = int.Parse(xmlXYZ60s.SelectSingleNode("CaptionSize").InnerText);
            }
            catch { }
            try
            {
                objOI.BgColor = xmlXYZ60s.SelectSingleNode("BgColor").InnerText;
            }
            catch { }
            try
            {
                objOI.FSSTransition = xmlXYZ60s.SelectSingleNode("FSSTransition").InnerText;
            }
            catch { }
            try
            {
                objOI.Repeat = bool.Parse(xmlXYZ60s.SelectSingleNode("Repeat").InnerText);
            }
            catch { }
            try
            {
                objOI.Streaming = bool.Parse(xmlXYZ60s.SelectSingleNode("Streaming").InnerText);
            }
            catch { }
            try
            {
                objOI.EffectTime = double.Parse(xmlXYZ60s.SelectSingleNode("EffectTime").InnerText);
            }
            catch { }
            try
            {
                objOI.TransitionTime = int.Parse(xmlXYZ60s.SelectSingleNode("TransitionTime").InnerText);
            }
            catch { }
            try
            {
                objOI.Volume = int.Parse(xmlXYZ60s.SelectSingleNode("Volume").InnerText);
            }
            catch { }
            try
            {
                objOI.MusicUrl = xmlXYZ60s.SelectSingleNode("MusicUrl").InnerText;
            }
            catch { }
            try
            {
                objOI.ShowMusicControls = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowMusicControls").InnerText);
            }
            catch { }
            try
            {
                objOI.ProgressColor = xmlXYZ60s.SelectSingleNode("ProgressColor").InnerText;
            }
            catch { }
            try
            {
                objOI.TextColor = xmlXYZ60s.SelectSingleNode("TextColor").InnerText;
            }
            catch { }
            try
            {
                objOI.ThumbFolder = xmlXYZ60s.SelectSingleNode("ThumbFolder").InnerText;
            }
            catch { }
            try { objOI.ThumbnailPosition = xmlXYZ60s.SelectSingleNode("ThumbnailPosition").InnerText; }
            catch { }
            try { objOI.ThumbnailRows = int.Parse(xmlXYZ60s.SelectSingleNode("ThumbnailRows").InnerText); }
            catch { }
            try { objOI.ThumbnailColumns = int.Parse(xmlXYZ60s.SelectSingleNode("ThumbnailColumns").InnerText); }
            catch { }
            try { objOI.NTWidth = xmlXYZ60s.SelectSingleNode("NTWidth").InnerText; }
            catch { }
            try { objOI.NTHeight = xmlXYZ60s.SelectSingleNode("NTHeight").InnerText; }
            catch { }
            try { objOI.Pause = xmlXYZ60s.SelectSingleNode("Pause").InnerText; }
            catch { }
            try { objOI.Speed = xmlXYZ60s.SelectSingleNode("Speed").InnerText; }
            catch { }
            try { objOI.InitialJuke = int.Parse(xmlXYZ60s.SelectSingleNode("InitialJuke").InnerText); }
            catch { }
            try { objOI.AutoStart = bool.Parse(xmlXYZ60s.SelectSingleNode("AutoStart").InnerText); }
            catch { }
            try
            {
                objOI.AutoRewind = bool.Parse(xmlXYZ60s.SelectSingleNode("AutoRewind").InnerText);
            }
            catch { }
            try
            {
                objOI.JukeSelector = int.Parse(xmlXYZ60s.SelectSingleNode("JukeSelector").InnerText);
            }
            catch { }
            try
            {
                objOI.ReferIt = xmlXYZ60s.SelectSingleNode("ReferIt").InnerText;
            }
            catch { }
            try
            {
                objOI.AutoRefresh = int.Parse(xmlXYZ60s.SelectSingleNode("AutoRefresh").InnerText);
            }
            catch { }
            try
            {
                objOI.JukePager = int.Parse(xmlXYZ60s.SelectSingleNode("JukePager").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowJukePanel = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowJukePanel").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowReferJuke = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowReferJuke").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowAddToFavourite = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowAddToFavourite").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowDownload = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowDownload").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowMusicDownload = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowMusicDownload").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowRatings = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowRatings").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowSlotAvailability = bool.Parse(xmlXYZ60s.SelectSingleNode("ShowSlotAvailability").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swSaveEnabled = bool.Parse(xmlXYZ60s.SelectSingleNode("swSaveEnabled").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swVolume = bool.Parse(xmlXYZ60s.SelectSingleNode("swVolume").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRestart = bool.Parse(xmlXYZ60s.SelectSingleNode("swRestart").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swPausePlay = bool.Parse(xmlXYZ60s.SelectSingleNode("swPausePlay").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swFastForward = bool.Parse(xmlXYZ60s.SelectSingleNode("swFastForward").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swContextMenu = bool.Parse(xmlXYZ60s.SelectSingleNode("swContextMenu").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRemote = xmlXYZ60s.SelectSingleNode("swRemote").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Speed = xmlXYZ60s.SelectSingleNode("Speed").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.FlvSkinUrl = xmlXYZ60s.SelectSingleNode("FlvSkinUrl").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Palette = xmlXYZ60s.SelectSingleNode("Palette").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.awWindow = xmlXYZ60s.SelectSingleNode("awWindow").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.RatingsInNewWindow = bool.Parse(xmlXYZ60s.SelectSingleNode("RatingsInNewWindow").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.DataFolder = xmlXYZ60s.SelectSingleNode("DataFolder").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.PayPalId = xmlXYZ60s.SelectSingleNode("PayPalId").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.SlotAdPrice = decimal.Parse(xmlXYZ60s.SelectSingleNode("SlotAdPrice").InnerText);
            }
            catch
            {

            }

            try
            {
                objOI.UpdatedByUserId = int.Parse(xmlXYZ60s.SelectSingleNode("UpdatedByUserId").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.UpdatedByUser = xmlXYZ60s.SelectSingleNode("UpdatedByUser").InnerText;
            }
            catch
            {
            }
            try { objOI.UpdatedDate = DateTime.Parse(xmlXYZ60s.SelectSingleNode("UpdatedDate").InnerText); }
            catch { }

            //Option1 Options
            try { objOI.PagerSize = int.Parse(xmlXYZ60s.SelectSingleNode("PagerSize").InnerText); }
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
            string ModuleFriendlyName = "bhattji.XYZ60s";
            string ModuleName = "bhattji.XYZ60s";
            //string PathOfModule = "/DesktopModules/Feedback/";
            //string SharedResources = "~/" + PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";

            //Permissions
            string Code = "bhattji.XYZ60s_PERMISSION";
            //string ModerateFeedbackPosts = "MODERATEPOSTS";
            //string ManageFeedbackLists = "MANAGELISTS";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add XYZ60", "Alter XYZ60", "Approve XYZ60", "Configure XYZ60", "Delete XYZ60", "SelfEdit XYZ60" };
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
    } //XYZ60sController
} //bhattji.Modules.XYZ60s
