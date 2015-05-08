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
//using DotNetNuke.ComponentModel.DataAnnotations;


namespace bhattji.Modules.MyLogins
{
    [Serializable]
    //[TableName("bhattji_MyLogins")]
    public class MyLoginInfo : IHydratable
    {
        //---------------------------------------------------------------------
        // TODO Declare BLL Class Info fields and property accessors
        // You can use CodeSmith templates to generate this code
        //---------------------------------------------------------------------

        #region " Private Members "

        //private int _ItemId;
        //private int _ModuleId;

        //private string _Title;
        //private int _CategoryId;
        private string _Category;
        //private string _MediaSrc;
        //private string _MediaWidth;
        //private string _MediaHeight;
        //private string _MediaAlign;
        //private string _Description;

        ////Insert the Actual Fields Below

        //private string _ActualFields;

        ////Insert the Actual Fields above

        //private string _Details;
        //private string _MediaSrc2;
        //private string _MediaWidth2;
        //private string _MediaHeight2;
        //private string _MediaAlign2;

        //private string _NavURL;
        private bool _NewWindow;
        private bool _TrackClicks;

        //private DateTime _PublishDate;
        //private DateTime _ExpiryDate;
       
        private DateTime _DisplayDate;//=DateTime.Now;

        //private int _ViewOrder;
        //private int _UpdatedByUserId;
        private string _UpdatedByUser;
        //private DateTime _UpdatedDate;
        //private int _CreatedByUserId;
        private string _CreatedByUser;
        //private DateTime _CreatedDate;

        //private int _RatingVotes;
        //private int _RatingTotal;
        private int _RatingAverage;

        #endregion

        #region " Properties "

        public int ItemId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Category { get { return _Category; } }

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

        public bool NewWindow { get { return _NewWindow; } }

        public bool TrackClicks { get { return _TrackClicks; } }


        public DateTime PublishDate { get; set; }

        public DateTime ExpiryDate { get; set; }
       
        public DateTime DisplayDate { get { return _DisplayDate; } }


        public int ViewOrder { get; set; }

        //Ratings
        public int RatingVotes { get; set; }

        public int RatingTotal { get; set; }


        public int RatingAverage { get { return _RatingAverage; } }

        //Audit Control
        public int UpdatedByUserId { get; set; }
        
        public string UpdatedByUser { get { return _UpdatedByUser; } }

        public DateTime UpdatedDate { get; set; }

        public int CreatedByUserId { get; set; }

        public string CreatedByUser { get { return _CreatedByUser; } }

        public DateTime CreatedDate { get; set; }

        #endregion

        #region " Optional Interface(s) Implementation "
        #region " IHydratable Members "

        public int KeyID
        {
            get { return ItemId; }
            set { ItemId = value; }
        }

        public void Fill(IDataReader dr)
        {

            //'Following two Sections are created, so that those Items, which are not part of the Search may not be returned, in Try-Catch Block
            ItemId = Convert.ToInt32(Null.SetNull(dr["ItemID"], ItemId));
            ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleID"], ModuleId));
            Title = Convert.ToString(Null.SetNull(dr["Title"], Title));
            MediaSrc = Convert.ToString(Null.SetNull(dr["MediaSrc"], MediaSrc));
            MediaAlign = Convert.ToString(Null.SetNull(dr["MediaAlign"], MediaAlign));
            Description = Convert.ToString(Null.SetNull(dr["Description"], Description));

            Details = Convert.ToString(Null.SetNull(dr["Details"], Details));
            MediaSrc2 = Convert.ToString(Null.SetNull(dr["MediaSrc2"], MediaSrc2));

            NavURL = Convert.ToString(Null.SetNull(dr["NavURL"], NavURL));
            _NewWindow = Convert.ToBoolean(Null.SetNull(dr["NewWindow"], NewWindow));
            _TrackClicks = Convert.ToBoolean(Null.SetNull(dr["TrackClicks"], TrackClicks));
            _DisplayDate = Convert.ToDateTime(Null.SetNull(dr["DisplayDate"], DisplayDate));
            _RatingAverage = Convert.ToInt32(Null.SetNull(dr["RatingAverage"], RatingAverage));

            try
            {
                CategoryId = Convert.ToInt32(Null.SetNull(dr["CategoryID"], CategoryId));
                _Category = Convert.ToString(Null.SetNull(dr["Category"], Category));

                MediaWidth = Convert.ToString(Null.SetNull(dr["MediaWidth"], MediaWidth));
                MediaHeight = Convert.ToString(Null.SetNull(dr["MediaHeight"], MediaHeight));

                //Insert the Actual Fields Below

                ActualFields = Convert.ToString(Null.SetNull(dr["ActualFields"], ActualFields));

                //Insert the Actual Fields above

                MediaWidth2 = Convert.ToString(Null.SetNull(dr["MediaWidth2"], MediaWidth2));
                MediaHeight2 = Convert.ToString(Null.SetNull(dr["MediaHeight2"], MediaHeight2));
                MediaAlign2 = Convert.ToString(Null.SetNull(dr["MediaAlign2"], MediaAlign2));

                PublishDate = Convert.ToDateTime(Null.SetNull(dr["PublishDate"], PublishDate));
                ExpiryDate = Convert.ToDateTime(Null.SetNull(dr["ExpiryDate"], ExpiryDate));

                ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
                UpdatedByUserId = Convert.ToInt32(Null.SetNull(dr["UpdatedByUserId"], UpdatedByUserId));
                _UpdatedByUser = Convert.ToString(Null.SetNull(dr["UpdatedByUser"], UpdatedByUser));
                UpdatedDate = Convert.ToDateTime(Null.SetNull(dr["UpdatedDate"], UpdatedDate));
                CreatedByUserId = Convert.ToInt32(Null.SetNull(dr["CreatedByUserId"], CreatedByUserId));
                _CreatedByUser = Convert.ToString(Null.SetNull(dr["CreatedByUser"], CreatedByUser));
                CreatedDate = Convert.ToDateTime(Null.SetNull(dr["CreatedDate"], CreatedDate));

                RatingVotes = Convert.ToInt32(Null.SetNull(dr["RatingVotes"], RatingVotes));
                RatingTotal = Convert.ToInt32(Null.SetNull(dr["RatingTotal"], RatingTotal));
            }
            catch
            {
            }
        }

        #endregion //" IHydratable Members "
        #endregion //" Optional Interface(s) Implementation "
    } //MyLoginInfo

    public static class MyLoginInfoHelper
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
                i = DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("GetMyLoginId"), Title);
            }
            catch { }
            return i;
        }//GetItemID
        public static MyLoginInfo GetMyLoginInfo(string Title)
        {
            return GetMyLoginInfo(GetItemID(Title));
        }//GetMyLoginInfo
        public static MyLoginInfo GetMyLoginInfo(int ItemID)
        {
            MyLoginInfo objMyLoginInfo = new MyLoginInfo();
            try
            {
                objMyLoginInfo.Load(ItemID);
            }
            catch { }
            return objMyLoginInfo;
        }//GetMyLoginInfo
        #region MyLoginInfo Extention Methods
        public static void Load(this MyLoginInfo thisMyLoginInfo, string Title)
        {
            try
            {
                int i = GetItemID(Title);
                if (i != Null.NullInteger) thisMyLoginInfo.Load(i);
            }
            catch { }
        }//Load
        public static void Load(this MyLoginInfo thisMyLoginInfo, int ItemID)
        {
            try
            {
                thisMyLoginInfo = CBO.FillObject<MyLoginInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetMyLogin"), ItemID));
            }
            catch { }
        }//Load

        public static int AddUpdate(this MyLoginInfo thisMyLoginInfo)
        {
            if (thisMyLoginInfo.ItemId > 0)
            {
                thisMyLoginInfo.Update();
                return thisMyLoginInfo.ItemId;
            }
            else
            {
                return thisMyLoginInfo.Add();
            }
        }//AddUpdate
        public static int Add(this MyLoginInfo thisMyLoginInfo)
        {
            return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddMyLogin"), thisMyLoginInfo.ModuleId, GetNull(thisMyLoginInfo.Title), GetNull(thisMyLoginInfo.CategoryId), GetNull(thisMyLoginInfo.MediaSrc), GetNull(thisMyLoginInfo.MediaWidth), GetNull(thisMyLoginInfo.MediaHeight), GetNull(thisMyLoginInfo.MediaAlign), GetNull(thisMyLoginInfo.Description), GetNull(thisMyLoginInfo.ActualFields), GetNull(thisMyLoginInfo.Details), GetNull(thisMyLoginInfo.MediaSrc2), GetNull(thisMyLoginInfo.MediaWidth2), GetNull(thisMyLoginInfo.MediaHeight2), GetNull(thisMyLoginInfo.MediaAlign2), GetNull(thisMyLoginInfo.NavURL), GetNull(thisMyLoginInfo.PublishDate), GetNull(thisMyLoginInfo.ExpiryDate), GetNull(thisMyLoginInfo.ViewOrder), GetNull(thisMyLoginInfo.CreatedByUserId));
        }//Add
        public static void Update(this MyLoginInfo thisMyLoginInfo)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateMyLogin"), thisMyLoginInfo.ItemId, GetNull(thisMyLoginInfo.Title), GetNull(thisMyLoginInfo.CategoryId), GetNull(thisMyLoginInfo.MediaSrc), GetNull(thisMyLoginInfo.MediaWidth), GetNull(thisMyLoginInfo.MediaHeight), GetNull(thisMyLoginInfo.MediaAlign), GetNull(thisMyLoginInfo.Description), GetNull(thisMyLoginInfo.ActualFields), GetNull(thisMyLoginInfo.Details), GetNull(thisMyLoginInfo.MediaSrc2), GetNull(thisMyLoginInfo.MediaWidth2), GetNull(thisMyLoginInfo.MediaHeight2), GetNull(thisMyLoginInfo.MediaAlign2), GetNull(thisMyLoginInfo.NavURL), GetNull(thisMyLoginInfo.PublishDate), GetNull(thisMyLoginInfo.ExpiryDate), GetNull(thisMyLoginInfo.ViewOrder), GetNull(thisMyLoginInfo.UpdatedByUserId));
        }//Update
        public static void Delete(this MyLoginInfo thisMyLoginInfo)
        {
            Delete(thisMyLoginInfo.ItemId);
        }//Delete
        #endregion //MyLoginInfo Extention Methods
        public static void Delete(int ItemID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteMyLogin"), ItemID);
        }//Delete


    }

    public class MyLoginsController : ISearchable, IPortable, IUpgradeable
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

        public int AddUpdateMyLogin(MyLoginInfo objMyLogin)
        {
            if (objMyLogin.ItemId > 0)
            {
                UpdateMyLogin(objMyLogin);
                return objMyLogin.ItemId;
            }
            else
            {
                return AddMyLogin(objMyLogin);
            }
        }

        public int AddMyLogin(MyLoginInfo objMyLogin)
        {

            //return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddMyLogin"), objMyLogin.ModuleId, GetNull(objMyLogin.Title), GetNull(objMyLogin.CategoryId), GetNull(objMyLogin.MediaSrc), GetNull(objMyLogin.MediaWidth), GetNull(objMyLogin.MediaHeight), GetNull(objMyLogin.MediaAlign), GetNull(objMyLogin.Description), GetNull(objMyLogin.ActualFields),
            //GetNull(objMyLogin.Details), GetNull(objMyLogin.MediaSrc2), GetNull(objMyLogin.MediaWidth2), GetNull(objMyLogin.MediaHeight2), GetNull(objMyLogin.MediaAlign2), GetNull(objMyLogin.NavURL), GetNull(objMyLogin.PublishDate), GetNull(objMyLogin.ExpiryDate), GetNull(objMyLogin.ViewOrder), GetNull(objMyLogin.CreatedByUserId)
            //));

            //using (IDataContext ctx = DataContext.Instance())
            //{
            //    var rep = ctx.GetRepository<MyLoginInfo>();
            //    rep.Insert(objMyLogin);
            //}

            //int id = objMyLogin.ItemId;
            //objMyLogin.CreatedDate = DateTime.Now;
            //objMyLogin.UpdatedDate = DateTime.Now;
            //DataContext.Instance().GetRepository<MyLoginInfo>().Insert(objMyLogin);
            //id = objMyLogin.ItemId;
            //return id;

            return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddMyLogin"), objMyLogin.ModuleId, GetNull(objMyLogin.Title), GetNull(objMyLogin.CategoryId), GetNull(objMyLogin.MediaSrc), GetNull(objMyLogin.MediaWidth), GetNull(objMyLogin.MediaHeight), GetNull(objMyLogin.MediaAlign), GetNull(objMyLogin.Description), GetNull(objMyLogin.ActualFields),
            GetNull(objMyLogin.Details), GetNull(objMyLogin.MediaSrc2), GetNull(objMyLogin.MediaWidth2), GetNull(objMyLogin.MediaHeight2), GetNull(objMyLogin.MediaAlign2), GetNull(objMyLogin.NavURL), GetNull(objMyLogin.PublishDate), GetNull(objMyLogin.ExpiryDate), GetNull(objMyLogin.ViewOrder), GetNull(objMyLogin.CreatedByUserId)
            );

            //return DataProvider.Instance().ExecuteScalar<MyLoginInfo>(GetPrefixedDbObjectName("AddMyLogin"), objMyLogin.ModuleId, GetNull(objMyLogin.Title), GetNull(objMyLogin.CategoryId), GetNull(objMyLogin.MediaSrc), GetNull(objMyLogin.MediaWidth), GetNull(objMyLogin.MediaHeight), GetNull(objMyLogin.MediaAlign), GetNull(objMyLogin.Description), GetNull(objMyLogin.ActualFields),
            //GetNull(objMyLogin.Details), GetNull(objMyLogin.MediaSrc2), GetNull(objMyLogin.MediaWidth2), GetNull(objMyLogin.MediaHeight2), GetNull(objMyLogin.MediaAlign2), GetNull(objMyLogin.NavURL), GetNull(objMyLogin.PublishDate), GetNull(objMyLogin.ExpiryDate), GetNull(objMyLogin.ViewOrder), GetNull(objMyLogin.CreatedByUserId)
            //).ItemId;

        }

        public void UpdateMyLogin(MyLoginInfo objMyLogin)
        {

            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateMyLogin"), objMyLogin.ItemId, GetNull(objMyLogin.Title), GetNull(objMyLogin.CategoryId), GetNull(objMyLogin.MediaSrc), GetNull(objMyLogin.MediaWidth), GetNull(objMyLogin.MediaHeight), GetNull(objMyLogin.MediaAlign), GetNull(objMyLogin.Description), GetNull(objMyLogin.ActualFields),
            GetNull(objMyLogin.Details), GetNull(objMyLogin.MediaSrc2), GetNull(objMyLogin.MediaWidth2), GetNull(objMyLogin.MediaHeight2), GetNull(objMyLogin.MediaAlign2), GetNull(objMyLogin.NavURL), GetNull(objMyLogin.PublishDate), GetNull(objMyLogin.ExpiryDate), GetNull(objMyLogin.ViewOrder), GetNull(objMyLogin.UpdatedByUserId)
            );

        }

        public void DeleteMyLogin(MyLoginInfo objMyLogin)
        {
            DeleteMyLogin(objMyLogin.ItemId);
        }

        public void DeleteMyLogin(int ItemID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteMyLogin"), ItemID);
        }

        public void SetViewOrderMyLogins(int ModuleID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderMyLogins"), ModuleID);
        }

        public void ClaimOrphanMyLogins(int ModuleID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanMyLogins"), ModuleID);
        }

        public void UpdateMyLoginRating(int ItemId, int RatingTotal)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateMyLoginRating"), ItemId, RatingTotal);
        }


        public int GetMyLoginId(string Title)
        {
            return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("GetMyLoginId"), Title);
        }
        public MyLoginInfo GetMyLogin(string Title)
        {
            return GetMyLogin(GetMyLoginId(Title));
        }
        public MyLoginInfo GetMyLogin(int ItemID)
        {
            return CBO.FillObject<MyLoginInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetMyLogin"), ItemID));
        }

        #region Custom Import From Xls Csv Txt Files

        public IDataReader ImportMyLogins(string XlsCsvTxtFile)
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
        public bool UpdateMyLogins(string XlsCsvTxtFile)
        {
            bool success = false;
            try
            {
                CategoriesController objCategoriesController = new CategoriesController();
                MyLoginsController objMyLoginsController = new MyLoginsController();
                List<MyLoginInfo> lot = ImportMyLogins(XlsCsvTxtFile).ToLOT();//CBO.FillCollection<MyLoginInfo>(ImportMyLogins(XlsCsvTxtFile));
                foreach (MyLoginInfo MyLogin in lot)
                {
                    MyLogin.CategoryId = objCategoriesController.GetCategoryIdAddIfNotExists(MyLogin.Category);
                    objMyLoginsController.AddMyLogin(MyLogin);
                }
                success = true;
            }
            catch { }
            return success;
        }

        #endregion //Custom Import From Xls Csv Txt Files

        public DataTable GetMyLogins()
        {
            return GetMyLogins("");
        } //GetMyLogins
        public DataTable GetMyLogins(string SearchText)
        {
            return GetMyLogins(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1);
        } //GetMyLogins

        //This function retreives the Items from Database,
        //depending upon the paramters supplied
        //If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        //If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        //If you dont suppliy any parameter it gets GetAllItems()
        public DataTable GetMyLogins(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //List(Of MyLoginInfo) 'ArrayList 'IDataReader '
        )
        {
            //DataTable dt = new DataTable();
            //dt.Load(GetMyLoginCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope));

            //return dt;
            return GetMyLoginCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope).ToDataTable();
        } //GetMyLogins

        public IDataReader GetMyLoginCommons(string SearchText)
        {
            return GetMyLoginCommons(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1);
        }//GetMyLoginCommons

        public IDataReader GetMyLoginCommons(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //ArrayList 'List(Of MyLoginInfo) '
        )
        {
            // Public Function GetMyLoginCommons(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = -1) As IDataReader 'ArrayList 'List(Of MyLoginInfo) '
            if ((!string.IsNullOrEmpty(SearchText) || (CategoryId > -1)))
            {
                return GetSearchedMyLogins(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope);
            }
            else
            {
                switch (ItemsScope)
                {
                    case 0:
                        if (ModuleId > -1)
                            return GetModuleMyLogins(ModuleId, NoOfItems);
                        else
                            return GetAllMyLogins(NoOfItems);
                    //break;
                    case 1:
                        if (PortalId > -1)
                            return GetPortalMyLogins(PortalId, NoOfItems);
                        else
                            return GetAllMyLogins(NoOfItems);
                    //break;
                    case 2:
                        return GetAllMyLogins(NoOfItems);
                    default://0
                        if (PortalId > -1)
                            return GetPortalMyLogins(PortalId, NoOfItems);
                        else if (ModuleId > -1)
                            return GetModuleMyLogins(ModuleId, NoOfItems);
                        else
                            return GetAllMyLogins(NoOfItems);
                    //break;
                }
            }
        }

        public IDataReader GetModuleMyLogins(int ModuleId)
        {
            return GetModuleMyLogins(ModuleId, 100);
        }//GetModuleMyLogins
        //ArrayList 'List(Of MyLoginInfo) '
        public IDataReader GetModuleMyLogins(int ModuleId, int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetModuleMyLogins"), ModuleId, NoOfItems);
        }

        public IDataReader GetPortalMyLogins(int PortalId)
        {
            return GetPortalMyLogins(PortalId, 100);
        } //GetPortalMyLogins
        //ArrayList 'List(Of MyLoginInfo) '
        public IDataReader GetPortalMyLogins(int PortalId, int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetPortalMyLogins"), PortalId, NoOfItems);
        }

        public IDataReader GetAllMyLogins()
        {
            return GetAllMyLogins(100);
        } //GetAllMyLogins
        //ArrayList 'List(Of MyLoginInfo) '
        public IDataReader GetAllMyLogins(int NoOfItems)
        {
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllMyLogins"), NoOfItems);
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


        public IDataReader GetSearchedMyLogins(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
            //ArrayList 'List(Of MyLoginInfo) ' '
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

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("MyLogins") + " AS x ");
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

            //ArrayList MyLogins = (ArrayList)GetModuleMyLogins(ModInfo.ModuleID);
            List<MyLoginInfo> lotMyLogins = GetModuleMyLogins(ModInfo.ModuleID).ToLOT();//CBO.FillCollection<MyLoginInfo>(GetModuleMyLogins(ModInfo.ModuleID));
            //MyLoginInfo objMyLogin;
            foreach (MyLoginInfo objMyLogin in lotMyLogins)
            {
                SearchItemInfo SearchItem;

                int UserId = objMyLogin.CreatedByUserId;

                string strContent = HttpUtility.HtmlDecode(((MyLoginInfo)objMyLogin).Title + " " + ((MyLoginInfo)objMyLogin).Description);
                string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((MyLoginInfo)objMyLogin).Description + " " + ((MyLoginInfo)objMyLogin).Details), false), 100, "...");

                SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((MyLoginInfo)objMyLogin).Title, strDescription, UserId, ((MyLoginInfo)objMyLogin).CreatedDate, ModInfo.ModuleID, ((MyLoginInfo)objMyLogin).ItemId.ToString(), strContent, "ItemId=" + ((MyLoginInfo)objMyLogin).ItemId.ToString(), Null.NullInteger);
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
            sbXML.Append("<MyLogins>");

            //Export each MyLogin Details
            //ArrayList arrMyLogins = (ArrayList)GetModuleMyLogins(ModuleID);
            List<MyLoginInfo> lotMyLogins = GetModuleMyLogins(ModuleID).ToLOT();//CBO.FillCollection<MyLoginInfo>(GetModuleMyLogins(ModuleID));
            if (lotMyLogins.Count != 0)
            {
                //MyLoginInfo objMyLogin;
                foreach (MyLoginInfo objMyLogin in lotMyLogins)
                {

                    sbXML.Append("<MyLogin>");
                    sbXML.Append("<Title>" + XmlUtils.XMLEncode(objMyLogin.Title) + "</Title>");
                    sbXML.Append("<CategoryId>" + XmlUtils.XMLEncode(objMyLogin.CategoryId.ToString()) + "</CategoryId>");
                    sbXML.Append("<Category>" + XmlUtils.XMLEncode(objMyLogin.Category) + "</Category>");
                    sbXML.Append("<MediaSrc>" + XmlUtils.XMLEncode(objMyLogin.MediaSrc) + "</MediaSrc>");
                    sbXML.Append("<MediaWidth>" + XmlUtils.XMLEncode(objMyLogin.MediaWidth.ToString()) + "</MediaWidth>");
                    sbXML.Append("<MediaHeight>" + XmlUtils.XMLEncode(objMyLogin.MediaHeight.ToString()) + "</MediaHeight>");
                    sbXML.Append("<MediaAlign>" + XmlUtils.XMLEncode(objMyLogin.MediaAlign) + "</MediaAlign>");
                    sbXML.Append("<Description>" + XmlUtils.XMLEncode(objMyLogin.Description) + "</Description>");

                    //Actual Fields

                    sbXML.Append("<Details>" + XmlUtils.XMLEncode(objMyLogin.Details) + "</Details>");
                    sbXML.Append("<MediaSrc2>" + XmlUtils.XMLEncode(objMyLogin.MediaSrc2) + "</MediaSrc2>");
                    sbXML.Append("<MediaWidth2>" + XmlUtils.XMLEncode(objMyLogin.MediaWidth2.ToString()) + "</MediaWidth2>");
                    sbXML.Append("<MediaHeight2>" + XmlUtils.XMLEncode(objMyLogin.MediaHeight2.ToString()) + "</MediaHeight2>");
                    sbXML.Append("<MediaAlign2>" + XmlUtils.XMLEncode(objMyLogin.MediaAlign2) + "</MediaAlign2>");
                    sbXML.Append("<NavURL>" + XmlUtils.XMLEncode(objMyLogin.NavURL) + "</NavURL>");
                    sbXML.Append("<PublishDate>" + XmlUtils.XMLEncode(objMyLogin.PublishDate.ToString()) + "</PublishDate>");
                    sbXML.Append("<ExpiryDate>" + XmlUtils.XMLEncode(objMyLogin.ExpiryDate.ToString()) + "</ExpiryDate>");
                    sbXML.Append("<ViewOrder>" + XmlUtils.XMLEncode(objMyLogin.ViewOrder.ToString()) + "</ViewOrder>");
                    sbXML.Append("</MyLogin>");

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



            sbXML.Append("</MyLogins>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlMyLogins = Globals.GetContent(Content, "MyLogins");

            foreach (XmlNode xmlMyLogin in xmlMyLogins.SelectNodes("MyLogin"))
            {
                MyLoginInfo objMyLogin = new MyLoginInfo();

                objMyLogin.ModuleId = ModuleID;

                objMyLogin.Title = xmlMyLogin["Title"].InnerText;
                try { objMyLogin.CategoryId = int.Parse(xmlMyLogin["CategoryId"].InnerText); }
                catch { }
                //try { objMyLogin.Category = xmlMyLogin["Category"].InnerText; }
                //catch { }
                try { objMyLogin.MediaSrc = Globals.ImportUrl(ModuleID, xmlMyLogin["MediaSrc"].InnerText); }
                catch { }
                try { objMyLogin.MediaWidth = xmlMyLogin["MediaWidth"].InnerText; }
                catch { }
                try { objMyLogin.MediaHeight = xmlMyLogin["MediaHeight"].InnerText; }
                catch { }
                try { objMyLogin.MediaAlign = xmlMyLogin["MediaAlign"].InnerText; }
                catch { }
                try { objMyLogin.Description = xmlMyLogin["Description"].InnerText; }
                catch { }

                //Actual Fields

                try { objMyLogin.Details = xmlMyLogin["Details"].InnerText; }
                catch { }
                try { objMyLogin.MediaSrc2 = Globals.ImportUrl(ModuleID, xmlMyLogin["MediaSrc2"].InnerText); }
                catch { }
                try { objMyLogin.MediaWidth2 = xmlMyLogin["MediaWidth2"].InnerText; }
                catch { }
                try { objMyLogin.MediaHeight2 = xmlMyLogin["MediaHeight2"].InnerText; }
                catch { }
                try { objMyLogin.MediaAlign2 = xmlMyLogin["MediaAlign2"].InnerText; }
                catch { }
                try { objMyLogin.NavURL = Globals.ImportUrl(ModuleID, xmlMyLogin["NavURL"].InnerText); }
                catch { }
                try { objMyLogin.PublishDate = DateTime.Parse(xmlMyLogin["PublishDate"].InnerText); }
                catch { }
                try { objMyLogin.ExpiryDate = DateTime.Parse(xmlMyLogin["ExpiryDate"].InnerText); }
                catch { }
                try { objMyLogin.ViewOrder = int.Parse(xmlMyLogin["ViewOrder"].InnerText); }
                catch { }

                objMyLogin.UpdatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objMyLogin.UpdatedDate = DateTime.Now;
                objMyLogin.CreatedByUserId = UserId;
                //User the UserId of the Current User who is Importing this data
                objMyLogin.CreatedDate = DateTime.Now;


                AddMyLogin(objMyLogin);
            }

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.ItemsScope = int.Parse(xmlMyLogins.SelectSingleNode("ItemsScope").InnerText); }
            catch { }
            try { objOI.ViewControl = xmlMyLogins.SelectSingleNode("ViewControl").InnerText; }
            catch { }
            try { objOI.AddDescription = bool.Parse(xmlMyLogins.SelectSingleNode("AddDescription").InnerText); }
            catch { }
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlMyLogins.SelectSingleNode("OnlyHostCanEdit").InnerText); }
            catch { }
            //try { objOI.BackColor = xmlMyLogins.SelectSingleNode("BackColor").InnerText; }
            //catch { }
            //try { objOI.AltColor = xmlMyLogins.SelectSingleNode("AltColor").InnerText; }
            //catch { }
            //try { objOI.HeaderBackColor = xmlMyLogins.SelectSingleNode("HeaderBackColor").InnerText; }
            //catch { }
            //try { objOI.PagerBackColor = xmlMyLogins.SelectSingleNode("PagerBackColor").InnerText; }
            //catch { }
            try { objOI.TabCss = xmlMyLogins.SelectSingleNode("TabCss").InnerText; }
            catch { }
            try { objOI.NoOfPages = int.Parse(xmlMyLogins.SelectSingleNode("NoOfPages").InnerText); }
            catch { }
            try { objOI.DeleteFromGrid = bool.Parse(xmlMyLogins.SelectSingleNode("DeleteFromGrid").InnerText); }
            catch { }
            try { objOI.ViewOption = xmlMyLogins.SelectSingleNode("ViewOption").InnerText; }
            catch { }
            try { objOI.AddDate = xmlMyLogins.SelectSingleNode("AddDate").InnerText; }
            catch { }
            try { objOI.ImagePosition = xmlMyLogins.SelectSingleNode("ImagePosition").InnerText; }
            catch { }
            try { objOI.DynamicThumb = bool.Parse(xmlMyLogins.SelectSingleNode("DynamicThumb").InnerText); }
            catch { }
            try { objOI.UpdateRedirection = xmlMyLogins.SelectSingleNode("UpdateRedirection").InnerText; }
            catch { }
            try { objOI.ScrollColumns = int.Parse(xmlMyLogins.SelectSingleNode("ScrollColumns").InnerText); }
            catch { }
            try { objOI.TextMode = bool.Parse(xmlMyLogins.SelectSingleNode("TextMode").InnerText); }
            catch { }
            try { objOI.DisplayInfo = bool.Parse(xmlMyLogins.SelectSingleNode("DisplayInfo").InnerText); }
            catch { }
            try { objOI.ThumbWidth = xmlMyLogins.SelectSingleNode("ThumbWidth").InnerText; }
            catch { }
            try { objOI.ThumbHeight = xmlMyLogins.SelectSingleNode("ThumbHeight").InnerText; }
            catch { }
            try { objOI.ThumbColumns = int.Parse(xmlMyLogins.SelectSingleNode("ThumbColumns").InnerText); }
            catch { }
            try { objOI.HideTextLink = bool.Parse(xmlMyLogins.SelectSingleNode("HideTextLink").InnerText); }
            catch { }
            try { objOI.InfoCssClass = xmlMyLogins.SelectSingleNode("InfoCssClass").InnerText; }
            catch { }
            try { objOI.ScrollBehavior = xmlMyLogins.SelectSingleNode("ScrollBehavior").InnerText; }
            catch { }
            try { objOI.ScrollDirection = xmlMyLogins.SelectSingleNode("ScrollDirection").InnerText; }
            catch { }
            try { objOI.ScrollAmount = xmlMyLogins.SelectSingleNode("ScrollAmount").InnerText; }
            catch { }
            try { objOI.ScrollDelay = xmlMyLogins.SelectSingleNode("ScrollDelay").InnerText; }
            catch { }
            try { objOI.ScrollWidth = xmlMyLogins.SelectSingleNode("ScrollWidth").InnerText; }
            catch { }
            try { objOI.ScrollHeight = xmlMyLogins.SelectSingleNode("ScrollHeight").InnerText; }
            catch { }
            try { objOI.CellPadding = xmlMyLogins.SelectSingleNode("CellPadding").InnerText; }
            catch { }
            try { objOI.CellSpacing = xmlMyLogins.SelectSingleNode("CellSpacing").InnerText; }
            catch { }
            try { objOI.RattleImage = bool.Parse(xmlMyLogins.SelectSingleNode("RattleImage").InnerText); }
            catch { }
            try { objOI.SSWidth = xmlMyLogins.SelectSingleNode("SSWidth").InnerText; }
            catch { }
            try { objOI.SSHeight = xmlMyLogins.SelectSingleNode("SSHeight").InnerText; }
            catch { }
            try { objOI.Delay = xmlMyLogins.SelectSingleNode("Delay").InnerText; }
            catch { }
            try { objOI.Transition = xmlMyLogins.SelectSingleNode("Transition").InnerText; }
            catch { }
            try { objOI.Thumbnail = bool.Parse(xmlMyLogins.SelectSingleNode("Thumbnail").InnerText); }
            catch { }
            try { objOI.ThumbnailWidth = xmlMyLogins.SelectSingleNode("ThumbnailWidth").InnerText; }
            catch { }
            try{objOI.Resizing = xmlMyLogins.SelectSingleNode("Resizing").InnerText;}
            catch { }
            try
            {
                objOI.OnlyEmbedTag = bool.Parse(xmlMyLogins.SelectSingleNode("OnlyEmbedTag").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowControls = bool.Parse(xmlMyLogins.SelectSingleNode("ShowControls").InnerText);
            }
            catch { }
            try
            {
                objOI.SSTitle = xmlMyLogins.SelectSingleNode("SSTitle").InnerText;
            }
            catch { }
            try
            {
                objOI.CaptionFont = xmlMyLogins.SelectSingleNode("CaptionFont").InnerText;
            }
            catch { }

            try
            {
                objOI.CaptionSize = int.Parse(xmlMyLogins.SelectSingleNode("CaptionSize").InnerText);
            }
            catch { }
            try
            {
                objOI.BgColor = xmlMyLogins.SelectSingleNode("BgColor").InnerText;
            }
            catch { }
            try
            {
                objOI.FSSTransition = xmlMyLogins.SelectSingleNode("FSSTransition").InnerText;
            }
            catch { }
            try
            {
                objOI.Repeat = bool.Parse(xmlMyLogins.SelectSingleNode("Repeat").InnerText);
            }
            catch { }
            try
            {
                objOI.Streaming = bool.Parse(xmlMyLogins.SelectSingleNode("Streaming").InnerText);
            }
            catch { }
            try
            {
                objOI.EffectTime = double.Parse(xmlMyLogins.SelectSingleNode("EffectTime").InnerText);
            }
            catch { }
            try
            {
                objOI.TransitionTime = int.Parse(xmlMyLogins.SelectSingleNode("TransitionTime").InnerText);
            }
            catch { }
            try
            {
                objOI.Volume = int.Parse(xmlMyLogins.SelectSingleNode("Volume").InnerText);
            }
            catch { }
            try
            {
                objOI.MusicUrl = xmlMyLogins.SelectSingleNode("MusicUrl").InnerText;
            }
            catch { }
            try
            {
                objOI.ShowMusicControls = bool.Parse(xmlMyLogins.SelectSingleNode("ShowMusicControls").InnerText);
            }
            catch { }
            try
            {
                objOI.ProgressColor = xmlMyLogins.SelectSingleNode("ProgressColor").InnerText;
            }
            catch { }
            try
            {
                objOI.TextColor = xmlMyLogins.SelectSingleNode("TextColor").InnerText;
            }
            catch { }
            try
            {
                objOI.ThumbFolder = xmlMyLogins.SelectSingleNode("ThumbFolder").InnerText;
            }
            catch { }
            try { objOI.ThumbnailPosition = xmlMyLogins.SelectSingleNode("ThumbnailPosition").InnerText; }
            catch { }
            try { objOI.ThumbnailRows = int.Parse(xmlMyLogins.SelectSingleNode("ThumbnailRows").InnerText); }
            catch { }
            try { objOI.ThumbnailColumns = int.Parse(xmlMyLogins.SelectSingleNode("ThumbnailColumns").InnerText); }
            catch { }
            try { objOI.NTWidth = xmlMyLogins.SelectSingleNode("NTWidth").InnerText; }
            catch { }
            try{objOI.NTHeight = xmlMyLogins.SelectSingleNode("NTHeight").InnerText;}
            catch { }
            try { objOI.Pause = xmlMyLogins.SelectSingleNode("Pause").InnerText; }
            catch { }
            try { objOI.Speed = xmlMyLogins.SelectSingleNode("Speed").InnerText; }
            catch { }
            try { objOI.InitialJuke = int.Parse(xmlMyLogins.SelectSingleNode("InitialJuke").InnerText); }
            catch { }
            try { objOI.AutoStart = bool.Parse(xmlMyLogins.SelectSingleNode("AutoStart").InnerText); }
            catch { }
            try
            {
                objOI.AutoRewind = bool.Parse(xmlMyLogins.SelectSingleNode("AutoRewind").InnerText);
            }
            catch { }
            try
            {
                objOI.JukeSelector = int.Parse(xmlMyLogins.SelectSingleNode("JukeSelector").InnerText);
            }
            catch { }
            try
            {
                objOI.ReferIt = xmlMyLogins.SelectSingleNode("ReferIt").InnerText;
            }
            catch { }
            try
            {
                objOI.AutoRefresh = int.Parse(xmlMyLogins.SelectSingleNode("AutoRefresh").InnerText);
            }
            catch { }
            try
            {
                objOI.JukePager = int.Parse(xmlMyLogins.SelectSingleNode("JukePager").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowJukePanel = bool.Parse(xmlMyLogins.SelectSingleNode("ShowJukePanel").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowReferJuke = bool.Parse(xmlMyLogins.SelectSingleNode("ShowReferJuke").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowAddToFavourite = bool.Parse(xmlMyLogins.SelectSingleNode("ShowAddToFavourite").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowDownload = bool.Parse(xmlMyLogins.SelectSingleNode("ShowDownload").InnerText);
            }
            catch { }
            try
            {
                objOI.ShowMusicDownload = bool.Parse(xmlMyLogins.SelectSingleNode("ShowMusicDownload").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowRatings = bool.Parse(xmlMyLogins.SelectSingleNode("ShowRatings").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.ShowSlotAvailability = bool.Parse(xmlMyLogins.SelectSingleNode("ShowSlotAvailability").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swSaveEnabled = bool.Parse(xmlMyLogins.SelectSingleNode("swSaveEnabled").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swVolume = bool.Parse(xmlMyLogins.SelectSingleNode("swVolume").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRestart = bool.Parse(xmlMyLogins.SelectSingleNode("swRestart").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swPausePlay = bool.Parse(xmlMyLogins.SelectSingleNode("swPausePlay").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swFastForward = bool.Parse(xmlMyLogins.SelectSingleNode("swFastForward").InnerText);
            }
            catch
            {
            }

            try
            {
                objOI.swContextMenu = bool.Parse(xmlMyLogins.SelectSingleNode("swContextMenu").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.swRemote = xmlMyLogins.SelectSingleNode("swRemote").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Speed = xmlMyLogins.SelectSingleNode("Speed").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.FlvSkinUrl = xmlMyLogins.SelectSingleNode("FlvSkinUrl").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.Palette = xmlMyLogins.SelectSingleNode("Palette").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.awWindow = xmlMyLogins.SelectSingleNode("awWindow").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.RatingsInNewWindow = bool.Parse(xmlMyLogins.SelectSingleNode("RatingsInNewWindow").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.DataFolder = xmlMyLogins.SelectSingleNode("DataFolder").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.PayPalId = xmlMyLogins.SelectSingleNode("PayPalId").InnerText;
            }
            catch
            {
            }
            try
            {
                objOI.SlotAdPrice = decimal.Parse(xmlMyLogins.SelectSingleNode("SlotAdPrice").InnerText);
            }
            catch
            {

            }

            try
            {
                objOI.UpdatedByUserId = int.Parse(xmlMyLogins.SelectSingleNode("UpdatedByUserId").InnerText);
            }
            catch
            {
            }
            try
            {
                objOI.UpdatedByUser = xmlMyLogins.SelectSingleNode("UpdatedByUser").InnerText;
            }
            catch
            {
            }
            try { objOI.UpdatedDate = DateTime.Parse(xmlMyLogins.SelectSingleNode("UpdatedDate").InnerText); }
            catch { }

            //Option1 Options
            try { objOI.PagerSize = int.Parse(xmlMyLogins.SelectSingleNode("PagerSize").InnerText); }
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
            string ModuleFriendlyName = "bhattji.MyLogins";
            string ModuleName = "bhattji.MyLogins";
            //string PathOfModule = "/DesktopModules/Feedback/";
            //string SharedResources = "~/" + PathOfModule + Localization.LocalResourceDirectory + "/SharedRescources.resx";

            //Permissions
            string Code = "bhattji.MyLogins_PERMISSION";
            //string ModerateFeedbackPosts = "MODERATEPOSTS";
            //string ManageFeedbackLists = "MANAGELISTS";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add MyLogin", "Alter MyLogin", "Approve MyLogin", "Configure MyLogin", "Delete MyLogin", "SelfEdit MyLogin" };
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
    } //MyLoginsController
} //bhattji.Modules.MyLogins
