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
using DotNetNuke.Framework.Providers;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;


namespace bhattji.Modules.YouTubeVideos
{
    [Serializable]
    public class YouTubeVideoInfo : IHydratable
    {
        //---------------------------------------------------------------------
        // TODO Declare BLL Class Info fields and property accessors
        // You can use CodeSmith templates to generate this code
        //---------------------------------------------------------------------

        #region " Private Members "
        private int _ItemId;
        private int _ModuleId;

        private string _Title;
        private int _CategoryId;
        private string _Category;
        private string _MediaSrc;
        private string _MediaWidth;
        private string _MediaHeight;
        private string _MediaAlign;
        private string _Description;
        //Insert the Actual Fields Below

        private string _ActualFields;

        //Insert the Actual Fields above

        private string _Details;
        private string _MediaSrc2;
        private string _MediaWidth2;
        private string _MediaHeight2;
        private string _MediaAlign2;

        private string _NavURL;
        private bool _NewWindow;
        private bool _TrackClicks;

        private DateTime _PublishDate;
        private DateTime _ExpiryDate;
        private DateTime _DisplayDate;

        private int _ViewOrder;
        private int _UpdatedByUserId;
        private string _UpdatedByUser;
        private DateTime _UpdatedDate;
        private int _CreatedByUserId;
        private string _CreatedByUser;
        private DateTime _CreatedDate;

        private int _RatingVotes;
        private int _RatingTotal;
        private int _RatingAverage;
        #endregion

        #region " Properties "

        public int ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; }
        }

        public int ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public int CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public string MediaSrc
        {
            get { return _MediaSrc; }
            set { _MediaSrc = value; }
        }

        public string MediaWidth
        {
            get { return _MediaWidth; }
            set { _MediaWidth = value; }
        }

        public string MediaHeight
        {
            get { return _MediaHeight; }
            set { _MediaHeight = value; }
        }

        public string MediaAlign
        {
            get { return _MediaAlign; }
            set { _MediaAlign = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        //Insert the Actual Fields Below

        public string ActualFields
        {
            get { return _ActualFields; }
            set { _ActualFields = value; }
        }

        //Insert the Actual Fields above


        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }

        public string MediaSrc2
        {
            get { return _MediaSrc2; }
            set { _MediaSrc2 = value; }
        }

        public string MediaWidth2
        {
            get { return _MediaWidth2; }
            set { _MediaWidth2 = value; }
        }

        public string MediaHeight2
        {
            get { return _MediaHeight2; }
            set { _MediaHeight2 = value; }
        }

        public string MediaAlign2
        {
            get { return _MediaAlign2; }
            set { _MediaAlign2 = value; }
        }


        public string NavURL
        {
            get { return _NavURL; }
            set { _NavURL = value; }
        }

        public bool NewWindow
        {
            get { return _NewWindow; }
            set { _NewWindow = value; }
        }

        public bool TrackClicks
        {
            get { return _TrackClicks; }
            set { _TrackClicks = value; }
        }


        public DateTime PublishDate
        {
            get { return _PublishDate; }
            set { _PublishDate = value; }
        }

        public DateTime ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value; }
        }

        public DateTime DisplayDate
        {
            get { return _DisplayDate; }
            set { _DisplayDate = value; }
        }


        public int ViewOrder
        {
            get { return _ViewOrder; }
            set { _ViewOrder = value; }
        }

        //Ratings
        public int RatingVotes
        {
            get { return _RatingVotes; }
            set { _RatingVotes = value; }
        }

        public int RatingTotal
        {
            get { return _RatingTotal; }
            set { _RatingTotal = value; }
        }


        public int RatingAverage
        {
            get { return _RatingAverage; }
            set { _RatingAverage = value; }
        }

        //Audit Control
        public int UpdatedByUserId
        {
            get { return _UpdatedByUserId; }
            set { _UpdatedByUserId = value; }
        }

        public string UpdatedByUser
        {
            get { return _UpdatedByUser; }
            set { _UpdatedByUser = value; }
        }

        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        public int CreatedByUserId
        {
            get { return _CreatedByUserId; }
            set { _CreatedByUserId = value; }
        }

        public string CreatedByUser
        {
            get { return _CreatedByUser; }
            set { _CreatedByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        #endregion

        #region " Optional Interface(s) Implementation "
        #region " IHydratable Members "

        public int KeyID
        {
            get { return _ItemId; }
            set { _ItemId = value; }
        }

        public void Fill(IDataReader dr)
        {

            //'Following two Sections are created, so that those Items, which are not part of the Search may not be returned, in Try-Catch Block
            _ItemId = Convert.ToInt32(Null.SetNull(dr["ItemID"], ItemId));
            _ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleID"], ModuleId));
            _Title = Convert.ToString(Null.SetNull(dr["Title"], Title));
            _MediaSrc = Convert.ToString(Null.SetNull(dr["MediaSrc"], MediaSrc));
            _MediaAlign = Convert.ToString(Null.SetNull(dr["MediaAlign"], MediaAlign));
            _Description = Convert.ToString(Null.SetNull(dr["Description"], Description));

            _Details = Convert.ToString(Null.SetNull(dr["Details"], Details));
            _MediaSrc2 = Convert.ToString(Null.SetNull(dr["MediaSrc2"], MediaSrc2));

            _NavURL = Convert.ToString(Null.SetNull(dr["NavURL"], NavURL));
            _NewWindow = Convert.ToBoolean(Null.SetNull(dr["NewWindow"], NewWindow));
            _TrackClicks = Convert.ToBoolean(Null.SetNull(dr["TrackClicks"], TrackClicks));
            _DisplayDate = Convert.ToDateTime(Null.SetNull(dr["DisplayDate"], DisplayDate));
            _RatingAverage = Convert.ToInt32(Null.SetNull(dr["RatingAverage"], RatingAverage));

            try
            {
                _CategoryId = Convert.ToInt32(Null.SetNull(dr["CategoryID"], CategoryId));
                _Category = Convert.ToString(Null.SetNull(dr["Category"], Category));

                _MediaWidth = Convert.ToString(Null.SetNull(dr["MediaWidth"], MediaWidth));
                _MediaHeight = Convert.ToString(Null.SetNull(dr["MediaHeight"], MediaHeight));

                //Insert the Actual Fields Below

                _ActualFields = Convert.ToString(Null.SetNull(dr["ActualFields"], ActualFields));

                //Insert the Actual Fields above

                _MediaWidth2 = Convert.ToString(Null.SetNull(dr["MediaWidth2"], MediaWidth2));
                _MediaHeight2 = Convert.ToString(Null.SetNull(dr["MediaHeight2"], MediaHeight2));
                _MediaAlign2 = Convert.ToString(Null.SetNull(dr["MediaAlign2"], MediaAlign2));

                _PublishDate = Convert.ToDateTime(Null.SetNull(dr["PublishDate"], PublishDate));
                _ExpiryDate = Convert.ToDateTime(Null.SetNull(dr["ExpiryDate"], ExpiryDate));

                _ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
                _UpdatedByUserId = Convert.ToInt32(Null.SetNull(dr["UpdatedByUserId"], UpdatedByUserId));
                _UpdatedByUser = Convert.ToString(Null.SetNull(dr["UpdatedByUser"], UpdatedByUser));
                _UpdatedDate = Convert.ToDateTime(Null.SetNull(dr["UpdatedDate"], UpdatedDate));
                _CreatedByUserId = Convert.ToInt32(Null.SetNull(dr["CreatedByUserId"], CreatedByUserId));
                _CreatedByUser = Convert.ToString(Null.SetNull(dr["CreatedByUser"], CreatedByUser));
                _CreatedDate = Convert.ToDateTime(Null.SetNull(dr["CreatedDate"], CreatedDate));

                _RatingVotes = Convert.ToInt32(Null.SetNull(dr["RatingVotes"], RatingVotes));
                _RatingTotal = Convert.ToInt32(Null.SetNull(dr["RatingTotal"], RatingTotal));
            }
            catch
            {
            }
        }

        #endregion //" IHydratable Members "
        #endregion //" Optional Interface(s) Implementation "
    } //YouTubeVideoInfo

    public static class YouTubeVideoInfoHelper
    {
        public static object GetNull(object Field)
        {
            return Null.GetNull(Field, DBNull.Value);
        }//GetNull
        public static string GetPrefixedDbObjectName(string DbObjectName)
        {
            if (DbObjectName.StartsWith("bhattji_"))
                return DbObjectName;
            else
                return "bhattji_" + DbObjectName;
        } //GetPrefixedDbObjectName

        public static int GetItemID(string Title)
        {
            int i = Null.NullInteger;
            try
            {
                i = Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("GetYouTubeVideoId"), Title));
            }
            catch { }
            return i;
        }//GetItemID
        public static YouTubeVideoInfo GetYouTubeVideoInfo(string Title)
        {
            return GetYouTubeVideoInfo(GetItemID(Title));
        }//GetYouTubeVideoInfo
        public static YouTubeVideoInfo GetYouTubeVideoInfo(int ItemID)
        {
            YouTubeVideoInfo objYouTubeVideoInfo = new YouTubeVideoInfo();
            try
            {
                objYouTubeVideoInfo.Load(ItemID);
            }
            catch { }
            return objYouTubeVideoInfo;
        }//GetYouTubeVideoInfo
        #region YouTubeVideoInfo Extention Methods
        public static void Load(this YouTubeVideoInfo thisYouTubeVideoInfo, string Title)
        {
            try
            {
                int i = GetItemID(Title);
                if (i != Null.NullInteger) thisYouTubeVideoInfo.Load(i);
            }
            catch { }
        }//Load
        public static void Load(this YouTubeVideoInfo thisYouTubeVideoInfo, int ItemID)
        {
            try
            {
                thisYouTubeVideoInfo = CBO.FillObject<YouTubeVideoInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetYouTubeVideo"), ItemID));
            }
            catch { }
        }//Load

        public static int AddUpdate(this YouTubeVideoInfo thisYouTubeVideoInfo)
        {
            if (thisYouTubeVideoInfo.ItemId > 0)
            {
                thisYouTubeVideoInfo.Update();
                return thisYouTubeVideoInfo.ItemId;
            }
            else
            {
                return thisYouTubeVideoInfo.Add();
            }
        }//AddUpdate
        public static int Add(this YouTubeVideoInfo thisYouTubeVideoInfo)
        {
            return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddYouTubeVideo"), thisYouTubeVideoInfo.ModuleId, GetNull(thisYouTubeVideoInfo.Title), GetNull(thisYouTubeVideoInfo.CategoryId), GetNull(thisYouTubeVideoInfo.MediaSrc), GetNull(thisYouTubeVideoInfo.MediaWidth), GetNull(thisYouTubeVideoInfo.MediaHeight), GetNull(thisYouTubeVideoInfo.MediaAlign), GetNull(thisYouTubeVideoInfo.Description), GetNull(thisYouTubeVideoInfo.ActualFields), GetNull(thisYouTubeVideoInfo.Details), GetNull(thisYouTubeVideoInfo.MediaSrc2), GetNull(thisYouTubeVideoInfo.MediaWidth2), GetNull(thisYouTubeVideoInfo.MediaHeight2), GetNull(thisYouTubeVideoInfo.MediaAlign2), GetNull(thisYouTubeVideoInfo.NavURL), GetNull(thisYouTubeVideoInfo.PublishDate), GetNull(thisYouTubeVideoInfo.ExpiryDate), GetNull(thisYouTubeVideoInfo.ViewOrder), GetNull(thisYouTubeVideoInfo.CreatedByUserId)));
        }//Add
        public static void Update(this YouTubeVideoInfo thisYouTubeVideoInfo)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateYouTubeVideo"), thisYouTubeVideoInfo.ItemId, GetNull(thisYouTubeVideoInfo.Title), GetNull(thisYouTubeVideoInfo.CategoryId), GetNull(thisYouTubeVideoInfo.MediaSrc), GetNull(thisYouTubeVideoInfo.MediaWidth), GetNull(thisYouTubeVideoInfo.MediaHeight), GetNull(thisYouTubeVideoInfo.MediaAlign), GetNull(thisYouTubeVideoInfo.Description), GetNull(thisYouTubeVideoInfo.ActualFields), GetNull(thisYouTubeVideoInfo.Details), GetNull(thisYouTubeVideoInfo.MediaSrc2), GetNull(thisYouTubeVideoInfo.MediaWidth2), GetNull(thisYouTubeVideoInfo.MediaHeight2), GetNull(thisYouTubeVideoInfo.MediaAlign2), GetNull(thisYouTubeVideoInfo.NavURL), GetNull(thisYouTubeVideoInfo.PublishDate), GetNull(thisYouTubeVideoInfo.ExpiryDate), GetNull(thisYouTubeVideoInfo.ViewOrder), GetNull(thisYouTubeVideoInfo.UpdatedByUserId));
        }//Update
        public static void Delete(this YouTubeVideoInfo thisYouTubeVideoInfo)
        {
            Delete(thisYouTubeVideoInfo.ItemId);
        }//Delete
        #endregion //YouTubeVideoInfo Extention Methods
        public static void Delete(int ItemID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteYouTubeVideo"), ItemID);
        }//Delete


    }

    public class YouTubeVideosController : ISearchable, IPortable, IUpgradeable
    {
        #region " Public Methods "
        private object GetNull(object Field)
        {
            return Null.GetNull(Field, DBNull.Value);
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
                return DbObjectName;
            else
                return "bhattji_" + DbObjectName;
        } //GetPrefixedDbObjectName

        //---------------------------------------------------------------------
        // TODO Implement BLL methods
        // You can use CodeSmith templates to generate this code
        //---------------------------------------------------------------------

        public int AddUpdateYouTubeVideo(YouTubeVideoInfo objYouTubeVideo)
        {
            if (objYouTubeVideo.ItemId > 0)
            {
                UpdateYouTubeVideo(objYouTubeVideo);
                return objYouTubeVideo.ItemId;
            }
            else
            {
                return AddYouTubeVideo(objYouTubeVideo);
            }
        }

        public int AddYouTubeVideo(YouTubeVideoInfo objYouTubeVideo)
        {

            return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddYouTubeVideo"), objYouTubeVideo.ModuleId, GetNull(objYouTubeVideo.Title), GetNull(objYouTubeVideo.CategoryId), GetNull(objYouTubeVideo.MediaSrc), GetNull(objYouTubeVideo.MediaWidth), GetNull(objYouTubeVideo.MediaHeight), GetNull(objYouTubeVideo.MediaAlign), GetNull(objYouTubeVideo.Description), GetNull(objYouTubeVideo.ActualFields),
            GetNull(objYouTubeVideo.Details), GetNull(objYouTubeVideo.MediaSrc2), GetNull(objYouTubeVideo.MediaWidth2), GetNull(objYouTubeVideo.MediaHeight2), GetNull(objYouTubeVideo.MediaAlign2), GetNull(objYouTubeVideo.NavURL), GetNull(objYouTubeVideo.PublishDate), GetNull(objYouTubeVideo.ExpiryDate), GetNull(objYouTubeVideo.ViewOrder), GetNull(objYouTubeVideo.CreatedByUserId)
            ));

        }

        public void UpdateYouTubeVideo(YouTubeVideoInfo objYouTubeVideo)
        {

            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateYouTubeVideo"), objYouTubeVideo.ItemId, GetNull(objYouTubeVideo.Title), GetNull(objYouTubeVideo.CategoryId), GetNull(objYouTubeVideo.MediaSrc), GetNull(objYouTubeVideo.MediaWidth), GetNull(objYouTubeVideo.MediaHeight), GetNull(objYouTubeVideo.MediaAlign), GetNull(objYouTubeVideo.Description), GetNull(objYouTubeVideo.ActualFields),
            GetNull(objYouTubeVideo.Details), GetNull(objYouTubeVideo.MediaSrc2), GetNull(objYouTubeVideo.MediaWidth2), GetNull(objYouTubeVideo.MediaHeight2), GetNull(objYouTubeVideo.MediaAlign2), GetNull(objYouTubeVideo.NavURL), GetNull(objYouTubeVideo.PublishDate), GetNull(objYouTubeVideo.ExpiryDate), GetNull(objYouTubeVideo.ViewOrder), GetNull(objYouTubeVideo.UpdatedByUserId)
            );

        }

        public void DeleteYouTubeVideo(YouTubeVideoInfo objYouTubeVideo)
        {
            DeleteYouTubeVideo(objYouTubeVideo.ItemId);
        }

        public void DeleteYouTubeVideo(int ItemID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteYouTubeVideo"), ItemID);
        }

        public void SetViewOrderYouTubeVideos(int ModuleID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderYouTubeVideos"), ModuleID);
        }

        public void ClaimOrphanYouTubeVideos(int ModuleID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanYouTubeVideos"), ModuleID);
        }

        public void UpdateYouTubeVideoRating(int ItemId, int RatingTotal)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateYouTubeVideoRating"), ItemId, RatingTotal);
        }


        public int GetYouTubeVideoId(string Title)
        {
            return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("GetYouTubeVideoId"), Title));
        }
        public YouTubeVideoInfo GetYouTubeVideo(string Title)
        {
            return GetYouTubeVideo(GetYouTubeVideoId(Title));
        }
        public YouTubeVideoInfo GetYouTubeVideo(int ItemID)
        {
            return CBO.FillObject<YouTubeVideoInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetYouTubeVideo"), ItemID));
        }

        #region Custom Import From Xls Csv Txt Files

        public IDataReader ImportYouTubeVideos(string XlsCsvTxtFile)
        {
            string strConn;
            string strCmd;
            if ((System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".csv") || (System.IO.Path.GetExtension(XlsCsvTxtFile).ToLower() == ".txt"))
            {
                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + CsvFile + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(System.IO.Path.GetDirectoryName(XlsCsvTxtFile)) + ";Extended Properties=\"Text;HDR=Yes;IMEX=1\"";
                strCmd = "SELECT * FROM " + XlsCsvTxtFile;
            }
            else
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath(XlsCsvTxtFile) + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                strCmd = "SELECT * FROM [Sheet1$]";
            }

            //System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(strCmd, strConn);

            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //return dt;

            System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strConn);
            Conn.Open();

            System.Data.OleDb.OleDbCommand Cmd = new System.Data.OleDb.OleDbCommand(strCmd, Conn);

            return Cmd.ExecuteReader();
        }
        public bool UpdateYouTubeVideos(string XlsCsvTxtFile)
        {
            bool success = false;
            try
            {
                CategoriesController objCategoriesController = new CategoriesController();
                YouTubeVideosController objYouTubeVideosController = new YouTubeVideosController();
                List<YouTubeVideoInfo> lot = ImportYouTubeVideos(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<YouTubeVideoInfo>(ImportYouTubeVideos(XlsCsvTxtFile));
                foreach (YouTubeVideoInfo YouTubeVideo in lot)
                {
                    YouTubeVideo.CategoryId = objCategoriesController.GetCategoryIdAddIfNotExists(YouTubeVideo.Category);
                    objYouTubeVideosController.AddYouTubeVideo(YouTubeVideo);
                }
                success = true;
            }
            catch { }
            return success;
        }

        #endregion //Custom Import From Xls Csv Txt Files

        public DataTable GetYouTubeVideos()
        {
            return GetYouTubeVideos("");
        } //GetYouTubeVideos
        public DataTable GetYouTubeVideos(string SearchText)
        {
            return GetYouTubeVideos(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1);
        } //GetYouTubeVideos

        //This function retreives the Items from Database,
        //depending upon the paramters supplied
        //If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        //If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        //If you dont suppliy any parameter it gets GetAllItems()
        public DataTable GetYouTubeVideos(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //List(Of YouTubeVideoInfo) 'ArrayList 'IDataReader '
        )
        {
            //DataTable dt = new DataTable();
            //dt.Load(GetYouTubeVideoCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope));

            //return dt;
            return GetYouTubeVideoCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope).ToDataTable();
        } //GetYouTubeVideos

        public IDataReader GetYouTubeVideoCommons(string SearchText)
        {
            return GetYouTubeVideoCommons(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1);
        }//GetYouTubeVideoCommons

        public IDataReader GetYouTubeVideoCommons(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //ArrayList 'List(Of YouTubeVideoInfo) '
        )
        {
            // Public Function GetYouTubeVideoCommons(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = -1) As IDataReader 'ArrayList 'List(Of YouTubeVideoInfo) '
            if ((!string.IsNullOrEmpty(SearchText) || (CategoryId > -1)))
            {
                return GetSearchedYouTubeVideos(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope);
            }
            else
            {
                switch (ItemsScope)
                {
                    case 0:
                        if (ModuleId > -1)
                            return GetModuleYouTubeVideos(ModuleId, NoOfItems);
                        else
                            return GetAllYouTubeVideos(NoOfItems);
                    //break;
                    case 1:
                        if (PortalId > -1)
                            return GetPortalYouTubeVideos(PortalId, NoOfItems);
                        else
                            return GetAllYouTubeVideos(NoOfItems);
                    //break;
                    case 2:
                        return GetAllYouTubeVideos(NoOfItems);
                    default://0
                        if (PortalId > -1)
                            return GetPortalYouTubeVideos(PortalId, NoOfItems);
                        else if (ModuleId > -1)
                            return GetModuleYouTubeVideos(ModuleId, NoOfItems);
                        else
                            return GetAllYouTubeVideos(NoOfItems);
                    //break;
                }
            }
        }

        public IDataReader GetModuleYouTubeVideos(int ModuleId)
        {
            return GetModuleYouTubeVideos(ModuleId, 100);
        }//GetModuleYouTubeVideos
        //ArrayList 'List(Of YouTubeVideoInfo) '
        public IDataReader GetModuleYouTubeVideos(int ModuleId, int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetModuleYouTubeVideos"), ModuleId, NoOfItems);
        }

        public IDataReader GetPortalYouTubeVideos(int PortalId)
        {
            return GetPortalYouTubeVideos(PortalId, 100);
        } //GetPortalYouTubeVideos
        //ArrayList 'List(Of YouTubeVideoInfo) '
        public IDataReader GetPortalYouTubeVideos(int PortalId, int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetPortalYouTubeVideos"), PortalId, NoOfItems);
        }

        public IDataReader GetAllYouTubeVideos()
        {
            return GetAllYouTubeVideos(100);
        } //GetAllYouTubeVideos
        //ArrayList 'List(Of YouTubeVideoInfo) '
        public IDataReader GetAllYouTubeVideos(int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllYouTubeVideos"), NoOfItems);
        }

        private void GetScopeFilter(ref string ScopeFilter, ref string ScopeJoins, int ModuleId, int PortalId, int ItemsScope, string ObjectQualifier)
        {
            switch (ItemsScope)
            {
                case 0:
                    if (ModuleId > -1)
                    {
                        ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
                    }

                    break;
                case 1:
                    if (PortalId > -1)
                    {
                        ScopeJoins = "INNER JOIN [" + ObjectQualifier + "Modules] As m on x.ModuleId = m.ModuleId ";
                        ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
                    }

                    break;
                case 2://Do Nothing
                    break;

                default://0
                    if (PortalId > -1)
                    {
                        ScopeJoins = "INNER JOIN [" + ObjectQualifier + "Modules] As m on x.ModuleId = m.ModuleId ";
                        ScopeFilter = "AND (m.PortalId = " + PortalId.ToString() + ") ";
                    }
                    else if (ModuleId > -1)
                    {
                        ScopeFilter = "AND (x.ModuleId = " + ModuleId.ToString() + ") ";
                    }

                    break;
            }
        } //GetScopeFilter

        private string GetDateFilter(string FromDate, string ToDate, string DateField)
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


        public IDataReader GetSearchedYouTubeVideos(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //ArrayList 'List(Of YouTubeVideoInfo) ' '
        )
        {
            string MyObjectQualifier = GetObjectQualifier();
            string CategoryFilter = (CategoryId > -1 ? "AND (x.CategoryId = " + CategoryId.ToString() + ") " : "").ToString();
            string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();
            string DateFilter = GetDateFilter(FromDate, ToDate, "x.UpdatedDate");
            string ScopeJoins = "";
            string ScopeFilter = "";
            GetScopeFilter(ref ScopeFilter, ref ScopeJoins, ModuleId, PortalId, ItemsScope, MyObjectQualifier);


            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT TOP " + NoOfItems.ToString() + " ");
            // sbSql.Append("x.* ")
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ModuleId, ");
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
            sbSql.Append("'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END ");

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("YouTubeVideos") + " AS x ");
            sbSql.Append(ScopeJoins);
            sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
            sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "UrlTracking] As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");


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

            return DataProvider.Instance().ExecuteSQL(sbSql.ToString());
        }



        #endregion

        #region " Optional Interface(s) Implementation "
        #region " ISearchable Members "
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //ArrayList YouTubeVideos = (ArrayList)GetModuleYouTubeVideos(ModInfo.ModuleID);
            List<YouTubeVideoInfo> lotYouTubeVideos = GetModuleYouTubeVideos(ModInfo.ModuleID).ToLOT();//CBO.FillCollection<YouTubeVideoInfo>(GetModuleYouTubeVideos(ModInfo.ModuleID));
            //YouTubeVideoInfo objYouTubeVideo;
            foreach (YouTubeVideoInfo objYouTubeVideo in lotYouTubeVideos)
            {
                SearchItemInfo SearchItem;

                int UserId = objYouTubeVideo.CreatedByUserId;

                string strContent = HttpUtility.HtmlDecode(((YouTubeVideoInfo)objYouTubeVideo).Title + " " + ((YouTubeVideoInfo)objYouTubeVideo).Description);
                string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((YouTubeVideoInfo)objYouTubeVideo).Description + " " + ((YouTubeVideoInfo)objYouTubeVideo).Details), false), 100, "...");

                SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((YouTubeVideoInfo)objYouTubeVideo).Title, strDescription, UserId, ((YouTubeVideoInfo)objYouTubeVideo).CreatedDate, ModInfo.ModuleID, ((YouTubeVideoInfo)objYouTubeVideo).ItemId.ToString(), strContent, "ItemId=" + ((YouTubeVideoInfo)objYouTubeVideo).ItemId.ToString(), Null.NullInteger);
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
            sbXML.Append("<YouTubeVideos>");

            //Export each YouTubeVideo Details
            //ArrayList arrYouTubeVideos = (ArrayList)GetModuleYouTubeVideos(ModuleID);
            List<YouTubeVideoInfo> lotYouTubeVideos = GetModuleYouTubeVideos(ModuleID).ToLOT();//CBO.FillCollection<YouTubeVideoInfo>(GetModuleYouTubeVideos(ModuleID));
            if (lotYouTubeVideos.Count != 0)
            {
                //YouTubeVideoInfo objYouTubeVideo;
                foreach (YouTubeVideoInfo objYouTubeVideo in lotYouTubeVideos)
                {

                    sbXML.Append("<YouTubeVideo>");
                    sbXML.Append("<Title>" + XmlUtils.XMLEncode(objYouTubeVideo.Title) + "</Title>");
                    sbXML.Append("<CategoryId>" + XmlUtils.XMLEncode(objYouTubeVideo.CategoryId.ToString()) + "</CategoryId>");
                    sbXML.Append("<Category>" + XmlUtils.XMLEncode(objYouTubeVideo.Category) + "</Category>");
                    sbXML.Append("<MediaSrc>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaSrc) + "</MediaSrc>");
                    sbXML.Append("<MediaWidth>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaWidth.ToString()) + "</MediaWidth>");
                    sbXML.Append("<MediaHeight>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaHeight.ToString()) + "</MediaHeight>");
                    sbXML.Append("<MediaAlign>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaAlign) + "</MediaAlign>");
                    sbXML.Append("<Description>" + XmlUtils.XMLEncode(objYouTubeVideo.Description) + "</Description>");

                    //Actual Fields

                    sbXML.Append("<Details>" + XmlUtils.XMLEncode(objYouTubeVideo.Details) + "</Details>");
                    sbXML.Append("<MediaSrc2>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaSrc2) + "</MediaSrc2>");
                    sbXML.Append("<MediaWidth2>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaWidth2.ToString()) + "</MediaWidth2>");
                    sbXML.Append("<MediaHeight2>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaHeight2.ToString()) + "</MediaHeight2>");
                    sbXML.Append("<MediaAlign2>" + XmlUtils.XMLEncode(objYouTubeVideo.MediaAlign2) + "</MediaAlign2>");
                    sbXML.Append("<NavURL>" + XmlUtils.XMLEncode(objYouTubeVideo.NavURL) + "</NavURL>");
                    sbXML.Append("<PublishDate>" + XmlUtils.XMLEncode(objYouTubeVideo.PublishDate.ToString()) + "</PublishDate>");
                    sbXML.Append("<ExpiryDate>" + XmlUtils.XMLEncode(objYouTubeVideo.ExpiryDate.ToString()) + "</ExpiryDate>");
                    sbXML.Append("<ViewOrder>" + XmlUtils.XMLEncode(objYouTubeVideo.ViewOrder.ToString()) + "</ViewOrder>");
                    sbXML.Append("</YouTubeVideo>");

                }
            }

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



            sbXML.Append("</YouTubeVideos>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlYouTubeVideos = Globals.GetContent(Content, "YouTubeVideos");

            foreach (XmlNode xmlYouTubeVideo in xmlYouTubeVideos.SelectNodes("YouTubeVideo"))
            {
                YouTubeVideoInfo objYouTubeVideo = new YouTubeVideoInfo();

                objYouTubeVideo.ModuleId = ModuleID;

                objYouTubeVideo.Title = xmlYouTubeVideo["Title"].InnerText;
                try { objYouTubeVideo.CategoryId = int.Parse(xmlYouTubeVideo["CategoryId"].InnerText); }
                catch { }
                try { objYouTubeVideo.Category = xmlYouTubeVideo["Category"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaSrc = Globals.ImportUrl(ModuleID, xmlYouTubeVideo["MediaSrc"].InnerText); }
                catch { }
                try { objYouTubeVideo.MediaWidth = xmlYouTubeVideo["MediaWidth"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaHeight = xmlYouTubeVideo["MediaHeight"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaAlign = xmlYouTubeVideo["MediaAlign"].InnerText; }
                catch { }
                try { objYouTubeVideo.Description = xmlYouTubeVideo["Description"].InnerText; }
                catch { }

                //Actual Fields

                try { objYouTubeVideo.Details = xmlYouTubeVideo["Details"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaSrc2 = Globals.ImportUrl(ModuleID, xmlYouTubeVideo["MediaSrc2"].InnerText); }
                catch { }
                try { objYouTubeVideo.MediaWidth2 = xmlYouTubeVideo["MediaWidth2"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaHeight2 = xmlYouTubeVideo["MediaHeight2"].InnerText; }
                catch { }
                try { objYouTubeVideo.MediaAlign2 = xmlYouTubeVideo["MediaAlign2"].InnerText; }
                catch { }
                try { objYouTubeVideo.NavURL = Globals.ImportUrl(ModuleID, xmlYouTubeVideo["NavURL"].InnerText); }
                catch { }
                try { objYouTubeVideo.PublishDate = DateTime.Parse(xmlYouTubeVideo["PublishDate"].InnerText); }
                catch { }
                try { objYouTubeVideo.ExpiryDate = DateTime.Parse(xmlYouTubeVideo["ExpiryDate"].InnerText); }
                catch { }
                try { objYouTubeVideo.ViewOrder = int.Parse(xmlYouTubeVideo["ViewOrder"].InnerText); }
                catch { }

                objYouTubeVideo.UpdatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objYouTubeVideo.UpdatedDate = DateTime.Now;
                objYouTubeVideo.CreatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objYouTubeVideo.CreatedDate = DateTime.Now;


                AddYouTubeVideo(objYouTubeVideo);
            }

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.ItemsScope = int.Parse(xmlYouTubeVideos.SelectSingleNode("ItemsScope").InnerText); }
            catch { }
            try { objOI.ViewControl = xmlYouTubeVideos.SelectSingleNode("ViewControl").InnerText; }
            catch { }
            try { objOI.AddDescription = bool.Parse(xmlYouTubeVideos.SelectSingleNode("AddDescription").InnerText); }
            catch { }
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlYouTubeVideos.SelectSingleNode("OnlyHostCanEdit").InnerText); }
            catch { }
            //try { objOI.BackColor = xmlYouTubeVideos.SelectSingleNode("BackColor").InnerText; }
            //catch { }
            //try { objOI.AltColor = xmlYouTubeVideos.SelectSingleNode("AltColor").InnerText; }
            //catch { }
            //try { objOI.HeaderBackColor = xmlYouTubeVideos.SelectSingleNode("HeaderBackColor").InnerText; }
            //catch { }
            //try { objOI.PagerBackColor = xmlYouTubeVideos.SelectSingleNode("PagerBackColor").InnerText; }
            //catch { }
            try { objOI.TabCss = xmlYouTubeVideos.SelectSingleNode("TabCss").InnerText; }
            catch { }
            try { objOI.NoOfPages = int.Parse(xmlYouTubeVideos.SelectSingleNode("NoOfPages").InnerText); }
            catch { }
            try { objOI.DeleteFromGrid = bool.Parse(xmlYouTubeVideos.SelectSingleNode("DeleteFromGrid").InnerText); }
            catch { }
            try { objOI.ViewOption = xmlYouTubeVideos.SelectSingleNode("ViewOption").InnerText; }
            catch { }
            try { objOI.AddDate = xmlYouTubeVideos.SelectSingleNode("AddDate").InnerText; }
            catch { }
            try { objOI.ImagePosition = xmlYouTubeVideos.SelectSingleNode("ImagePosition").InnerText; }
            catch { }
            try { objOI.DynamicThumb = bool.Parse(xmlYouTubeVideos.SelectSingleNode("DynamicThumb").InnerText); }
            catch { }
            try { objOI.UpdateRedirection = xmlYouTubeVideos.SelectSingleNode("UpdateRedirection").InnerText; }
            catch { }
            try { objOI.ScrollColumns = int.Parse(xmlYouTubeVideos.SelectSingleNode("ScrollColumns").InnerText); }
            catch { }
            try { objOI.TextMode = bool.Parse(xmlYouTubeVideos.SelectSingleNode("TextMode").InnerText); }
            catch { }
            try { objOI.DisplayInfo = bool.Parse(xmlYouTubeVideos.SelectSingleNode("DisplayInfo").InnerText); }
            catch { }
            try { objOI.ThumbWidth = xmlYouTubeVideos.SelectSingleNode("ThumbWidth").InnerText; }
            catch { }
            try { objOI.ThumbHeight = xmlYouTubeVideos.SelectSingleNode("ThumbHeight").InnerText; }
            catch { }
            try { objOI.ThumbColumns = int.Parse(xmlYouTubeVideos.SelectSingleNode("ThumbColumns").InnerText); }
            catch { }
            try { objOI.HideTextLink = bool.Parse(xmlYouTubeVideos.SelectSingleNode("HideTextLink").InnerText); }
            catch { }
            try { objOI.InfoCssClass = xmlYouTubeVideos.SelectSingleNode("InfoCssClass").InnerText; }
            catch { }
            try { objOI.ScrollBehavior = xmlYouTubeVideos.SelectSingleNode("ScrollBehavior").InnerText; }
            catch { }
            try { objOI.ScrollDirection = xmlYouTubeVideos.SelectSingleNode("ScrollDirection").InnerText; }
            catch { }
            try { objOI.ScrollAmount = xmlYouTubeVideos.SelectSingleNode("ScrollAmount").InnerText; }
            catch { }
            try { objOI.ScrollDelay = xmlYouTubeVideos.SelectSingleNode("ScrollDelay").InnerText; }
            catch { }
            try { objOI.ScrollWidth = xmlYouTubeVideos.SelectSingleNode("ScrollWidth").InnerText; }
            catch { }
            try { objOI.ScrollHeight = xmlYouTubeVideos.SelectSingleNode("ScrollHeight").InnerText; }
            catch { }
            try { objOI.CellPadding = xmlYouTubeVideos.SelectSingleNode("CellPadding").InnerText; }
            catch { }
            try { objOI.CellSpacing = xmlYouTubeVideos.SelectSingleNode("CellSpacing").InnerText; }
            catch { }
            try { objOI.RattleImage = bool.Parse(xmlYouTubeVideos.SelectSingleNode("RattleImage").InnerText); }
            catch { }
            try { objOI.SSWidth = xmlYouTubeVideos.SelectSingleNode("SSWidth").InnerText; }
            catch { }
            try { objOI.SSHeight = xmlYouTubeVideos.SelectSingleNode("SSHeight").InnerText; }
            catch { }
            try { objOI.Delay = xmlYouTubeVideos.SelectSingleNode("Delay").InnerText; }
            catch { }
            try { objOI.Transition = xmlYouTubeVideos.SelectSingleNode("Transition").InnerText; }
            catch { }
            try { objOI.Thumbnail = bool.Parse(xmlYouTubeVideos.SelectSingleNode("Thumbnail").InnerText); }
            catch { }
            try { objOI.ThumbnailWidth = xmlYouTubeVideos.SelectSingleNode("ThumbnailWidth").InnerText; }
            catch { }
            try{objOI.Resizing = xmlYouTubeVideos.SelectSingleNode("Resizing").InnerText;}
            catch { }
            try
            {
                objOI.OnlyEmbedTag = bool.Parse(xmlYouTubeVideos.SelectSingleNode("OnlyEmbedTag").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowControls = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowControls").InnerText);
            }
            catch { }
            try
            {
                objOI.SSTitle = xmlYouTubeVideos.SelectSingleNode("SSTitle").InnerText;
            }
            catch { }
            try
            {
                objOI.CaptionFont = xmlYouTubeVideos.SelectSingleNode("CaptionFont").InnerText;
            }
            catch { }

            try
            {
                objOI.CaptionSize = int.Parse(xmlYouTubeVideos.SelectSingleNode("CaptionSize").InnerText);
            }
            catch { }
            try
            {
                objOI.BgColor = xmlYouTubeVideos.SelectSingleNode("BgColor").InnerText;
            }
            catch { }
            try
            {
                objOI.FSSTransition = xmlYouTubeVideos.SelectSingleNode("FSSTransition").InnerText;
            }
            catch { }
            try
            {
                objOI.Repeat = bool.Parse(xmlYouTubeVideos.SelectSingleNode("Repeat").InnerText);
            }
            catch { }
            try
            {
                objOI.Streaming = bool.Parse(xmlYouTubeVideos.SelectSingleNode("Streaming").InnerText);
            }
            catch { }
            try
            {
                objOI.EffectTime = double.Parse(xmlYouTubeVideos.SelectSingleNode("EffectTime").InnerText);
            }
            catch { }
            try
            {
                objOI.TransitionTime = int.Parse(xmlYouTubeVideos.SelectSingleNode("TransitionTime").InnerText);
            }
            catch { }
            try
            {
                objOI.Volume = int.Parse(xmlYouTubeVideos.SelectSingleNode("Volume").InnerText);
            }
            catch { }
            try
            {
                objOI.MusicUrl = xmlYouTubeVideos.SelectSingleNode("MusicUrl").InnerText;
            }
            catch { }
            try
            {
                objOI.ShowMusicControls = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowMusicControls").InnerText);
            }
            catch { }
            try
            {
                objOI.ProgressColor = xmlYouTubeVideos.SelectSingleNode("ProgressColor").InnerText;
            }
            catch { }
            try
            {
                objOI.TextColor = xmlYouTubeVideos.SelectSingleNode("TextColor").InnerText;
            }
            catch { }
            try
            {
                objOI.ThumbFolder = xmlYouTubeVideos.SelectSingleNode("ThumbFolder").InnerText;
            }
            catch { }
            try { objOI.ThumbnailPosition = xmlYouTubeVideos.SelectSingleNode("ThumbnailPosition").InnerText; }
            catch { }
            try { objOI.ThumbnailRows = int.Parse(xmlYouTubeVideos.SelectSingleNode("ThumbnailRows").InnerText); }
            catch { }
            try { objOI.ThumbnailColumns = int.Parse(xmlYouTubeVideos.SelectSingleNode("ThumbnailColumns").InnerText); }
            catch { }
            try { objOI.NTWidth = xmlYouTubeVideos.SelectSingleNode("NTWidth").InnerText; }
            catch { }
            try{objOI.NTHeight = xmlYouTubeVideos.SelectSingleNode("NTHeight").InnerText;}
            catch { }
            try { objOI.Pause = xmlYouTubeVideos.SelectSingleNode("Pause").InnerText; }
            catch { }
            try { objOI.Speed = xmlYouTubeVideos.SelectSingleNode("Speed").InnerText; }
            catch { }
            try { objOI.InitialJuke = int.Parse(xmlYouTubeVideos.SelectSingleNode("InitialJuke").InnerText); }
            catch { }
            try { objOI.AutoStart = bool.Parse(xmlYouTubeVideos.SelectSingleNode("AutoStart").InnerText); }
            catch { }
            try
            {
                objOI.AutoRewind = bool.Parse(xmlYouTubeVideos.SelectSingleNode("AutoRewind").InnerText);
            }
            catch { }
            try
            {
                objOI.JukeSelector = int.Parse(xmlYouTubeVideos.SelectSingleNode("JukeSelector").InnerText);
            }
            catch { }
            try
            {
                objOI.ReferIt = xmlYouTubeVideos.SelectSingleNode("ReferIt").InnerText;
            }
            catch { }
            try
            {
                objOI.AutoRefresh = int.Parse(xmlYouTubeVideos.SelectSingleNode("AutoRefresh").InnerText);
            }
            catch { }
            try
            {
                objOI.JukePager = int.Parse(xmlYouTubeVideos.SelectSingleNode("JukePager").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowJukePanel = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowJukePanel").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowReferJuke = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowReferJuke").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowAddToFavourite = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowAddToFavourite").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowDownload = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowDownload").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowMusicDownload = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowMusicDownload").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowRatings = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowRatings").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowSlotAvailability = bool.Parse(xmlYouTubeVideos.SelectSingleNode("ShowSlotAvailability").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swSaveEnabled = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swSaveEnabled").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swVolume = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swVolume").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRestart = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swRestart").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swPausePlay = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swPausePlay").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swFastForward = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swFastForward").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swContextMenu = bool.Parse(xmlYouTubeVideos.SelectSingleNode("swContextMenu").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRemote = xmlYouTubeVideos.SelectSingleNode("swRemote").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Speed = xmlYouTubeVideos.SelectSingleNode("Speed").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.FlvSkinUrl = xmlYouTubeVideos.SelectSingleNode("FlvSkinUrl").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Palette = xmlYouTubeVideos.SelectSingleNode("Palette").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.awWindow = xmlYouTubeVideos.SelectSingleNode("awWindow").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.RatingsInNewWindow = bool.Parse(xmlYouTubeVideos.SelectSingleNode("RatingsInNewWindow").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.DataFolder = xmlYouTubeVideos.SelectSingleNode("DataFolder").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.PayPalId = xmlYouTubeVideos.SelectSingleNode("PayPalId").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.SlotAdPrice = decimal.Parse(xmlYouTubeVideos.SelectSingleNode("SlotAdPrice").InnerText);
            }
            catch
            {

            }

            try
            {
                objOI.UpdatedByUserId = int.Parse(xmlYouTubeVideos.SelectSingleNode("UpdatedByUserId").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.UpdatedByUser = xmlYouTubeVideos.SelectSingleNode("UpdatedByUser").InnerText;
            }
            catch
            {
            }
            try { objOI.UpdatedDate = DateTime.Parse(xmlYouTubeVideos.SelectSingleNode("UpdatedDate").InnerText); }
            catch { }

            //Option1 Options
            try { objOI.PagerSize = int.Parse(xmlYouTubeVideos.SelectSingleNode("PagerSize").InnerText); }
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
            string ModuleFriendlyName = "bhattji.YouTubeVideos";
            string ModuleName = "bhattji.YouTubeVideos";
            //string PathOfModule = "/DesktopModules/Feedback/";
            //string SharedResources = "~/" + PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";

            //Permissions
            string Code = "bhattji.YouTubeVideos_PERMISSION";
            //string ModerateFeedbackPosts = "MODERATEPOSTS";
            //string ManageFeedbackLists = "MANAGELISTS";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add YouTubeVideo", "Alter YouTubeVideo", "Approve YouTubeVideo", "Configure YouTubeVideo", "Delete YouTubeVideo", "SelfEdit YouTubeVideo" };
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
    } //YouTubeVideosController
} //bhattji.Modules.YouTubeVideos
