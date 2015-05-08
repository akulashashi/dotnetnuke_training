using System;
using System.Data;
using System.Xml;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using System.Text;
using System.Web;
using System.Collections;

//Imports Microsoft.ApplicationBlocks.Data
//Imports System.Collections.Generic
//Imports System.ComponentModel
//Imports System.Text

namespace bhattji.Modules.SalesReps.Business
{

	public class SalesRepInfo : DotNetNuke.Entities.Modules.IHydratable
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

        private string _repNo;
        private string _repName;
        private decimal _repRate;
        private decimal _repDollar;


		//private string _ActualFields;

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

        int DotNetNuke.Entities.Modules.IHydratable.KeyID
        {
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

		public string Title {
			get { return _Title; }
			set { _Title = value; }
		}

		public int CategoryId {
			get { return _CategoryId; }
			set { _CategoryId = value; }
		}

		public string Category {
			get { return _Category; }
			set { _Category = value; }
		}

		public string MediaSrc {
			get { return _MediaSrc; }
			set { _MediaSrc = value; }
		}

		public string MediaWidth {
			get { return _MediaWidth; }
			set { _MediaWidth = value; }
		}

		public string MediaHeight {
			get { return _MediaHeight; }
			set { _MediaHeight = value; }
		}

		public string MediaAlign {
			get { return _MediaAlign; }
			set { _MediaAlign = value; }
		}

		public string Description {
			get { return _Description; }
			set { _Description = value; }
		}


		//Insert the Actual Fields Below

        public string RepNo
        {
            get { return _repNo; }
            set { _repNo = value; }
        }

        public string RepName
        {
            get { return _repName; }
            set { _repName = value; }
        }

        public string RepRate
        {
            get { return _repRate; }
            set { _repRate = value; }
        }

        public string RepDollar
        {
            get { return _repDollar; }
            set { _repDollar = value; }
        }

		//Insert the Actual Fields above


		public string Details {
			get { return _Details; }
			set { _Details = value; }
		}

		public string MediaSrc2 {
			get { return _MediaSrc2; }
			set { _MediaSrc2 = value; }
		}

		public string MediaWidth2 {
			get { return _MediaWidth2; }
			set { _MediaWidth2 = value; }
		}

		public string MediaHeight2 {
			get { return _MediaHeight2; }
			set { _MediaHeight2 = value; }
		}

		public string MediaAlign2 {
			get { return _MediaAlign2; }
			set { _MediaAlign2 = value; }
		}


		public string NavURL {
			get { return _NavURL; }
			set { _NavURL = value; }
		}

		public bool NewWindow {
			get { return _NewWindow; }
			set { _NewWindow = value; }
		}

		public bool TrackClicks {
			get { return _TrackClicks; }
			set { _TrackClicks = value; }
		}


		public DateTime PublishDate {
			get { return _PublishDate; }
			set { _PublishDate = value; }
		}

		public DateTime ExpiryDate {
			get { return _ExpiryDate; }
			set { _ExpiryDate = value; }
		}

		public DateTime DisplayDate {
			get { return _DisplayDate; }
			set { _DisplayDate = value; }
		}


		public int ViewOrder {
			get { return _ViewOrder; }
			set { _ViewOrder = value; }
		}

		//Ratings
		public int RatingVotes {
			get { return _RatingVotes; }
			set { _RatingVotes = value; }
		}

		public int RatingTotal {
			get { return _RatingTotal; }
			set { _RatingTotal = value; }
		}

		//Public ReadOnly Property RatingAverage() As Integer
		//    Get
		//        Try
		//            Dim RA As Integer = CInt(RatingTotal / RatingVotes)
		//            If RA > 9 Then
		//                Return 10
		//            Else
		//                Return RA
		//            End If
		//        Catch
		//            Return 0
		//        End Try
		//    End Get
		//End Property

		public int RatingAverage {
			get { return _RatingAverage; }
			set { _RatingAverage = value; }
		}

		//Audit Control
		public int UpdatedByUserId {
			get { return _UpdatedByUserId; }
			set { _UpdatedByUserId = value; }
		}

		public string UpdatedByUser {
			get { return _UpdatedByUser; }
			set { _UpdatedByUser = value; }
		}

		public DateTime UpdatedDate {
			get { return _UpdatedDate; }
			set { _UpdatedDate = value; }
		}

		public int CreatedByUserId {
			get { return _CreatedByUserId; }
			set { _CreatedByUserId = value; }
		}

		public string CreatedByUser {
			get { return _CreatedByUser; }
			set { _CreatedByUser = value; }
		}

		public DateTime CreatedDate {
			get { return _CreatedDate; }
			set { _CreatedDate = value; }
		}

		#endregion

		#region " Optional IHydratable Implementation "

        void DotNetNuke.Entities.Modules.IHydratable.Fill(IDataReader dr)
		{
			//_ItemId = Convert.ToInt32(Null.SetNull(dr.Item("ItemID"), ItemId))
			//_ModuleId = Convert.ToInt32(Null.SetNull(dr.Item("ModuleID"), ModuleId))
			//_Title = Convert.ToString(Null.SetNull(dr.Item("Title"), Title))
			//_CategoryId = Convert.ToInt32(Null.SetNull(dr.Item("CategoryID"), CategoryId))
			//_Category = Convert.ToString(Null.SetNull(dr.Item("Category"), Category))
			//_MediaSrc = Convert.ToString(Null.SetNull(dr.Item("MediaSrc"), MediaSrc))
			//_MediaWidth = Convert.ToString(Null.SetNull(dr.Item("MediaWidth"), MediaWidth))
			//_MediaHeight = Convert.ToString(Null.SetNull(dr.Item("MediaHeight"), MediaHeight))
			//_MediaAlign = Convert.ToString(Null.SetNull(dr.Item("MediaAlign"), MediaAlign))
			//_Description = Convert.ToString(Null.SetNull(dr.Item("Description"), Description))

			//'Insert the Actual Fields Below

			//_ActualFields = Convert.ToString(Null.SetNull(dr.Item("ActualFields"), ActualFields))

			//'Insert the Actual Fields above

			//_Details = Convert.ToString(Null.SetNull(dr.Item("Details"), Details))
			//_MediaSrc2 = Convert.ToString(Null.SetNull(dr.Item("MediaSrc2"), MediaSrc2))
			//_MediaWidth2 = Convert.ToString(Null.SetNull(dr.Item("MediaWidth2"), MediaWidth2))
			//_MediaHeight2 = Convert.ToString(Null.SetNull(dr.Item("MediaHeight2"), MediaHeight2))
			//_MediaAlign2 = Convert.ToString(Null.SetNull(dr.Item("MediaAlign2"), MediaAlign2))

			//_NavURL = Convert.ToString(Null.SetNull(dr.Item("NavURL"), NavURL))
			//_NewWindow = Convert.ToBoolean(Null.SetNull(dr.Item("NewWindow"), NewWindow))
			//_TrackClicks = Convert.ToBoolean(Null.SetNull(dr.Item("TrackClicks"), TrackClicks))

			//_PublishDate = Convert.ToDateTime(Null.SetNull(dr.Item("PublishDate"), PublishDate))
			//_ExpiryDate = Convert.ToDateTime(Null.SetNull(dr.Item("ExpiryDate"), ExpiryDate))
			//_DisplayDate = Convert.ToDateTime(Null.SetNull(dr.Item("DisplayDate"), DisplayDate))

			//_ViewOrder = Convert.ToInt32(Null.SetNull(dr.Item("ViewOrder"), ViewOrder))
			//_UpdatedByUserId = Convert.ToInt32(Null.SetNull(dr.Item("UpdatedByUserId"), UpdatedByUserId))
			//_UpdatedByUser = Convert.ToString(Null.SetNull(dr.Item("UpdatedByUser"), UpdatedByUser))
			//_UpdatedDate = Convert.ToDateTime(Null.SetNull(dr.Item("UpdatedDate"), UpdatedDate))
			//_CreatedByUserId = Convert.ToInt32(Null.SetNull(dr.Item("CreatedByUserId"), CreatedByUserId))
			//_CreatedByUser = Convert.ToString(Null.SetNull(dr.Item("CreatedByUser"), CreatedByUser))
			//_CreatedDate = Convert.ToDateTime(Null.SetNull(dr.Item("CreatedDate"), CreatedDate))

			//_RatingVotes = Convert.ToInt32(Null.SetNull(dr.Item("RatingVotes"), RatingVotes))
			//_RatingTotal = Convert.ToInt32(Null.SetNull(dr.Item("RatingTotal"), RatingTotal))
			//_RatingAverage = Convert.ToInt32(Null.SetNull(dr.Item("RatingAverage"), RatingAverage))

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

			try {
				_CategoryId = Convert.ToInt32(Null.SetNull(dr["CategoryID"], CategoryId));
				_Category = Convert.ToString(Null.SetNull(dr["Category"], Category));

				_MediaWidth = Convert.ToString(Null.SetNull(dr["MediaWidth"], MediaWidth));
				_MediaHeight = Convert.ToString(Null.SetNull(dr["MediaHeight"], MediaHeight));

				//Insert the Actual Fields Below

     			_repNo = Convert.ToString(Null.SetNull(dr["RepNo"], RepNo ));
                _repName = Convert.ToString(Null.SetNull(dr["RepName"],RepName));
                _repRate = Convert.ToString(Null.SetNull(dr["RepRate"],RepRate ));
                _repDollar = Convert.ToString(Null.SetNull(dr["RepDollar"],RepDollar));

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

			catch {
			}
		}

		#endregion

	}
	//SalesRepInfo

    public class SalesRepsController : DotNetNuke.Entities.Modules.ISearchable, DotNetNuke.Entities.Modules.IPortable
	{

		#region " Public Methods "
		private object GetNull(object Field)
		{
			return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
		}
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


		public int AddUpdateSalesRep(SalesRepInfo objSalesRep)
		{
			if (objSalesRep.ItemId > 0)
			{
				UpdateSalesRep(objSalesRep);
				return objSalesRep.ItemId;
			}
			else
			{
				return AddSalesRep(objSalesRep);
			}
		}

		public int AddSalesRep(SalesRepInfo objSalesRep)
		{

            return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddSalesRep"), objSalesRep.ModuleId, GetNull(objSalesRep.Title), GetNull(objSalesRep.CategoryId), GetNull(objSalesRep.MediaSrc), GetNull(objSalesRep.MediaWidth), GetNull(objSalesRep.MediaHeight), GetNull(objSalesRep.MediaAlign), GetNull(objSalesRep.Description), GetNull(objSalesRep.RepNo), GetNull(objSalesRep.RepName ), GetNull(objSalesRep.RepRate), GetNull(objSalesRep.RepDollar), 
				GetNull(objSalesRep.Details), GetNull(objSalesRep.MediaSrc2), GetNull(objSalesRep.MediaWidth2), GetNull(objSalesRep.MediaHeight2), GetNull(objSalesRep.MediaAlign2), GetNull(objSalesRep.NavURL), GetNull(objSalesRep.PublishDate), GetNull(objSalesRep.ExpiryDate), GetNull(objSalesRep.ViewOrder), GetNull(objSalesRep.CreatedByUserId)
				));
			
		}

		public void UpdateSalesRep(SalesRepInfo objSalesRep)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateSalesRep"), objSalesRep.ItemId, GetNull(objSalesRep.Title), GetNull(objSalesRep.CategoryId), GetNull(objSalesRep.MediaSrc), GetNull(objSalesRep.MediaWidth), GetNull(objSalesRep.MediaHeight), GetNull(objSalesRep.MediaAlign), GetNull(objSalesRep.Description), GetNull(objSalesRep.RepNo),GetNull(objSalesRep.RepName),GetNull(objSalesRep.RepRate),GetNull(objSalesRep.RepDollar), 
				GetNull(objSalesRep.Details), GetNull(objSalesRep.MediaSrc2), GetNull(objSalesRep.MediaWidth2), GetNull(objSalesRep.MediaHeight2), GetNull(objSalesRep.MediaAlign2), GetNull(objSalesRep.NavURL), GetNull(objSalesRep.PublishDate), GetNull(objSalesRep.ExpiryDate), GetNull(objSalesRep.ViewOrder), GetNull(objSalesRep.UpdatedByUserId)
				);
			}
		}

		public void DeleteSalesRep(SalesRepInfo objSalesRep)
		{
			DeleteSalesRep(objSalesRep.ItemId);
		}

		public void DeleteSalesRep(int ItemID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteSalesRep"), ItemID);
		}
        
        public void FixSalesReps(int ModuleID,int UpdatedByUserId)
        {
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery(GetPrefixedDbObjectName("bhattji_FixSalesReps"), ModuleID, UpdatedByUserId);
        }

        public void SortSalesReps(int ModuleID)
        {
            DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("bhattji_SortSalesReps"), ModuleID);
        }

        public Boolean IsUniqueCode(string RepNo)
        {
            return(GetSalesRepId(RepNo) < 1);
        }

        public int GetSalesRepId(string RepNo)
        {
            return CType(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesRepId", RepNo), Integer);
        }

        public SalesRepInfo GetSalesRep(int ItemID)
        {
            return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRep", ItemID), GetType(SalesRepInfo)), SalesRepInfo);
        }
        

		public void SetViewOrderSalesReps(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderSalesReps"), ModuleID);
		}

		public void ClaimOrphanSalesReps(int ModuleID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanSalesReps"), ModuleID);
		}

		public void UpdateSalesRepRating(int ItemId, int RatingTotal)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateSalesRepRating"), ItemId, RatingTotal);
		}

		public SalesRepInfo GetSalesRep(int ItemID)
		{
			//Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRep", ItemID), GetType(SalesRepInfo)), SalesRepInfo)
			return CBO.FillObject<SalesRepInfo>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetSalesRep"), ItemID));
		}

        public DataTable GetSalesReps()
        {
            return GetSalesReps("", "Any", false, 100, "", "", -1, -1, -1, -1);
        }
        //GetSalesReps
		public DataTable GetSalesReps(string SearchText)
		{
			return GetSalesReps(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1);
		}
		//GetSalesReps

		//This function retreives the Items from Database,
		//depending upon the paramters supplied
		//If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
		//If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
		//If you dont suppliy any parameter it gets GetAllItems()
		public DataTable GetSalesReps(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
		//List(Of SalesRepInfo) 'ArrayList 'IDataReader '
		)
		{
			//Public Function GetSalesReps(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = -1) As DataTable 'List(Of SalesRepInfo) 'ArrayList 'IDataReader '
			//Return GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope), GetType(SalesRepInfo)
			//Return CBO.FillCollection(GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of SalesRepInfo)(GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope))

			DataTable dt = new DataTable();
			dt.Load(GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope
			));

			//'Dim dr As DataRow
			//For Each dr As DataRow In dt.Rows
			//    'Dim dc As New DataColumn
			//    For Each dc As DataColumn In dt.Columns
			//        If Null.IsNull(dr(dc)) Then
			//            dr(dc) = Null.SetNull(dr(dc), dc)
			//        End If
			//    Next
			//Next

			return dt;
		}

		public IDataReader GetSalesRepCommons(string SearchText)
		{
			return GetSalesRepCommons(SearchText, "Any", false, 100, "", "", -1, -1, -1, -1
			);
		}
		//GetSalesRepCommons
		public IDataReader GetSalesRepCommons(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
		//ArrayList 'List(Of SalesRepInfo) '
		)
		{
			// Public Function GetSalesRepCommons(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = -1) As IDataReader 'ArrayList 'List(Of SalesRepInfo) '
			if (SearchText != "" || CategoryId > -1)
			{
				//Return GetAllSalesReps(NoOfItems)
				return GetSearchedSalesReps(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, CategoryId, ModuleId, PortalId, ItemsScope
				);
			}
			else
			{
				switch (ItemsScope) {
					case 0:
						if (ModuleId > -1)
						{
							return GetModuleSalesReps(ModuleId, NoOfItems);
						}
						else
						{
							return GetAllSalesReps(NoOfItems);
						}

						//break;
					case 1:
						if (PortalId > -1)
						{
							return GetPortalSalesReps(PortalId, NoOfItems);
						}
						else
						{
							return GetAllSalesReps(NoOfItems);
						}

						//break;
					case 2:
						return GetAllSalesReps(NoOfItems);
					default:
						//0
						if (PortalId > -1)
						{
							return GetPortalSalesReps(PortalId, NoOfItems);
						}
else if (ModuleId > -1) {
							return GetModuleSalesReps(ModuleId, NoOfItems);
						}
						else
						{
							return GetAllSalesReps(NoOfItems);
						}

						//break;
				}
			}
		}

		public IDataReader GetModuleSalesReps(int ModuleId)
		{
			return GetModuleSalesReps(ModuleId, 100);
		}
		//GetModuleSalesReps
		//ArrayList 'List(Of SalesRepInfo) '
		public IDataReader GetModuleSalesReps(int ModuleId, int NoOfItems)
		{
			//Public Function GetModuleSalesReps(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList 'List(Of SalesRepInfo) '
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetModuleSalesReps"), ModuleId, NoOfItems);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesReps", ModuleId, NoOfItems), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesReps", ModuleId, NoOfItems))
		}

		public IDataReader GetPortalSalesReps(int PortalId)
		{
			return GetPortalSalesReps(PortalId, 100);
		}
		//GetPortalSalesReps
		//ArrayList 'List(Of SalesRepInfo) '
		public IDataReader GetPortalSalesReps(int PortalId, int NoOfItems)
		{
			//Public Function GetPortalSalesReps(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList 'List(Of SalesRepInfo) '
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetPortalSalesReps"), PortalId, NoOfItems);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesReps", PortalId, NoOfItems), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesReps", PortalId, NoOfItems))
		}

		public IDataReader GetAllSalesReps()
		{
			return GetAllSalesReps(100);
		}
		//GetAllSalesReps
		//ArrayList 'List(Of SalesRepInfo) '
		public IDataReader GetAllSalesReps(int NoOfItems)
		{
			// Public Function GetAllSalesReps(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList 'List(Of SalesRepInfo) '
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllSalesReps"), NoOfItems);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesReps", NoOfItems), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesReps", NoOfItems))
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

		//Public Function GetSearchedSalesRepFulls(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = 0) As IDataReader 'ArrayList 'List(Of SalesRepInfo) ' '
		//    Dim MyObjectQualifier As String = GetObjectQualifier()

		//    Dim CategoryFilter As String = IIf(CategoryId > -1, "AND (x.CategoryId = " & CategoryId.ToString() & ") ", "").ToString()
		//    Dim strSearchText As String = IIf(StartsWith, SearchText & "%", "%" & SearchText & "%").ToString()
		//    Dim DateFilter As String = GetDateFilter(FromDate, ToDate)

		//    'Set for Joining tables
		//    Dim ScopeJoins As String = ""
		//    Dim ScopeFilter As String = ""
		//    GetScopeFilter(ScopeFilter, ScopeJoins, ModuleId, PortalId, ItemsScope, MyObjectQualifier)

		//    Dim sbSql As String = String.Empty
		//    sbSql &= "SELECT TOP " & NoOfItems.ToString() & " "
		//    sbSql &= "x.[ItemID], "
		//    sbSql &= "x.[ModuleID], "

		//    sbSql &= "x.[Title], "
		//    sbSql &= "x.[CategoryId], "
		//    sbSql &= "ca.[Category], "
		//    sbSql &= "'MediaSrc' = CASE WHEN mf.FileName IS NULL THEN x.MediaSrc ELSE mf.Folder + mf.FileName END, "
		//    sbSql &= "x.[MediaWidth], "
		//    sbSql &= "x.[MediaHeight], "
		//    sbSql &= "x.[MediaAlign], "
		//    sbSql &= "x.[Description], "

		//    sbSql &= "x.[ActualFields], "

		//    sbSql &= "x.[Details], "
		//    sbSql &= "'MediaSrc2' = CASE WHEN mf2.FileName IS NULL THEN x.MediaSrc2 ELSE mf2.Folder + mf2.FileName END, "
		//    sbSql &= "x.[MediaWidth2], "
		//    sbSql &= "x.[MediaHeight2], "
		//    sbSql &= "x.[MediaAlign2], "

		//    sbSql &= "'NavURL' = CASE WHEN nf.FileName IS NULL THEN x.NavURL ELSE nf.Folder + nf.FileName END, "
		//    sbSql &= "nt.[NewWindow], "
		//    sbSql &= "nt.[TrackClicks], "

		//    sbSql &= "x.[PublishDate], "
		//    sbSql &= "x.[ExpiryDate], "
		//    sbSql &= "'DisplayDate' = CASE WHEN x.PublishDate IS NULL THEN x.CreatedDate ELSE x.PublishDate END, "

		//    sbSql &= "x.[ViewOrder], "

		//    sbSql &= "x.[UpdatedByUserId], "
		//    sbSql &= "'UpdatedByUser' = CASE WHEN uu.DisplayName IS NULL THEN uu.FirstName + ' ' + uu.LastName ELSE uu.DisplayName END, "
		//    sbSql &= "x.[UpdatedDate], "
		//    sbSql &= "x.[CreatedByUserId], "
		//    sbSql &= "'CreatedByUser' = CASE WHEN uc.DisplayName IS NULL THEN uc.FirstName + ' ' + uc.LastName ELSE uc.DisplayName END, "
		//    sbSql &= "x.[CreatedDate], "

		//    sbSql &= "x.[RatingVotes], "
		//    sbSql &= "x.[RatingTotal], "
		//    sbSql &= "'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END "

		//    sbSql &= "FROM " & MyObjectQualifier & "bhattji_SalesReps AS x "
		//    sbSql &= "JOIN [" & MyObjectQualifier & "Modules] As m ON x.ModuleId = m.ModuleId "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As mf ON x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As mf2 ON x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "UrlTracking] As nt ON x.NavURL = nt.Url and nt.ModuleId = x.ModuleId "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As nf ON x.NavURL = 'FileId=' + convert(varchar,nf.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Users] AS uu ON x.UpdatedByUserId = uu.UserId "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Users] AS uc ON x.CreatedByUserId = uc.UserId "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "bhattji_SalesRepCategories] AS ca ON x.CategoryId = ca.ItemId "


		//    Select Case SearchOn.ToUpper()
		//        Case "TITLE", "DESCRIPTION"
		//            sbSql &= "WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc "

		//        Case "DETAILS"
		//            sbSql &= "WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc "

		//        Case Else '"ANY"
		//            sbSql &= "WHERE ((x.Title LIKE '" & strSearchText & "') "
		//            sbSql &= "OR (x.Description LIKE '" & strSearchText & "') "
		//            sbSql &= "OR (x.Details LIKE '" & strSearchText & "')) "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc "

		//    End Select

		//    Return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql)
		//    'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), GetType(SalesRepInfo))
		//    'Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader(sbSql.ToString()))

		//End Function

		public IDataReader GetSearchedSalesReps(string SearchText, string SearchOn, bool StartsWith, int NoOfItems, string FromDate, string ToDate, int CategoryId, int ModuleId, int PortalId, int ItemsScope
		//ArrayList 'List(Of SalesRepInfo) ' '
		)
		{
			//Public Function GetSearchedSalesReps(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = 0) As IDataReader 'ArrayList 'List(Of SalesRepInfo) ' '
			string MyObjectQualifier = GetObjectQualifier();

			string CategoryFilter = (CategoryId > -1 ? "AND (x.CategoryId = " + CategoryId.ToString() + ") " : "").ToString();
			string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();
			string DateFilter = GetDateFilter(FromDate, ToDate);

			//Set for Joining tables
			string ScopeJoins = "";
			string ScopeFilter = "";
			GetScopeFilter(ref ScopeFilter,ref ScopeJoins, ModuleId, PortalId, ItemsScope, MyObjectQualifier);

			//Select Case ItemsScope
			//    Case 0
			//        If ModuleId > -1 Then
			//            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString() & ") " 'Return GetModuleSalesReps(ModuleId)
			//        End If
			//    Case 1
			//        If PortalId > -1 Then
			//            ScopeJoins = "INNER JOIN [" & MyObjectQualifier & "Modules] As m on x.ModuleId = m.ModuleId " 'Return GetPortalSalesReps(PortalId)
			//            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
			//        End If
			//    Case 2
			//        'Do Nothing
			//    Case Else '0
			//        If PortalId > -1 Then
			//            ScopeJoins = "INNER JOIN [" & MyObjectQualifier & "Modules] As m on x.ModuleId = m.ModuleId " 'Return GetPortalSalesReps(PortalId)
			//            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
			//        ElseIf ModuleId > -1 Then
			//            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString() & ") " 'Return GetModuleSalesReps(ModuleId)
			//        End If
			//End Select

			//Dim DateTo As Date = Now
			//If ToDate <> "" Then
			//    Try
			//        DateTo = Date.Parse(ToDate)
			//    Catch
			//        DateTo = Now
			//    End Try
			//End If
			//Dim DateFrom As Date = #1/1/1947#
			//If FromDate <> "" Then
			//    Try
			//        DateFrom = Date.Parse(FromDate)
			//    Catch
			//        DateFrom = #1/1/1947#
			//    End Try
			//End If

			//If DateFrom > DateTo Then
			//    Dim tDate As Date = DateFrom
			//    DateFrom = DateTo
			//    DateTo = tDate
			//End If

			//If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString() & "')) "
			//If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString() & "')) "

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

			sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("SalesReps") + " AS x ");
			sbSql.Append(ScopeJoins);
			sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) ");
			sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) ");
			sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "Files] As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) ");
			sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + "UrlTracking] As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId ");


			switch (SearchOn.ToUpper()) {
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

			return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString());
			//Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader(sbSql.ToString()))

		}

		//Public Function GetSearchedSalesReps(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal CategoryId As Integer = -1, Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal ItemsScope As Integer = 0) As IDataReader 'ArrayList 'List(Of SalesRepInfo) ' '
		//    Dim MyObjectQualifier As String = GetObjectQualifier()

		//    Dim CategoryFilter As String = IIf(CategoryId > -1, "AND (x.CategoryId = " & CategoryId.ToString() & ") ", "").ToString()
		//    Dim strSearchText As String = IIf(StartsWith, SearchText & "%", "%" & SearchText & "%").ToString()
		//    Dim DateFilter As String = GetDateFilter(FromDate, ToDate)

		//    'Set for Joining tables
		//    Dim ScopeJoins As String = ""
		//    Dim ScopeFilter As String = ""
		//    GetScopeFilter(ScopeFilter, ScopeJoins, ModuleId, PortalId, ItemsScope, MyObjectQualifier)

		//    'Select Case ItemsScope
		//    '    Case 0
		//    '        If ModuleId > -1 Then
		//    '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString() & ") " 'Return GetModuleSalesReps(ModuleId)
		//    '        End If
		//    '    Case 1
		//    '        If PortalId > -1 Then
		//    '            ScopeJoins = "INNER JOIN [" & MyObjectQualifier & "Modules] As m on x.ModuleId = m.ModuleId " 'Return GetPortalSalesReps(PortalId)
		//    '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
		//    '        End If
		//    '    Case 2
		//    '        'Do Nothing
		//    '    Case Else '0
		//    '        If PortalId > -1 Then
		//    '            ScopeJoins = "INNER JOIN [" & MyObjectQualifier & "Modules] As m on x.ModuleId = m.ModuleId " 'Return GetPortalSalesReps(PortalId)
		//    '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
		//    '        ElseIf ModuleId > -1 Then
		//    '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString() & ") " 'Return GetModuleSalesReps(ModuleId)
		//    '        End If
		//    'End Select

		//    'Dim DateTo As Date = Now
		//    'If ToDate <> "" Then
		//    '    Try
		//    '        DateTo = Date.Parse(ToDate)
		//    '    Catch
		//    '        DateTo = Now
		//    '    End Try
		//    'End If
		//    'Dim DateFrom As Date = #1/1/1947#
		//    'If FromDate <> "" Then
		//    '    Try
		//    '        DateFrom = Date.Parse(FromDate)
		//    '    Catch
		//    '        DateFrom = #1/1/1947#
		//    '    End Try
		//    'End If

		//    'If DateFrom > DateTo Then
		//    '    Dim tDate As Date = DateFrom
		//    '    DateFrom = DateTo
		//    '    DateTo = tDate
		//    'End If

		//    'If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString() & "')) "
		//    'If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString() & "')) "

		//    Dim sbSql As String = String.Empty
		//    sbSql &= "SELECT TOP " & NoOfItems.ToString() & " "
		//    ' sbSql &= "x.* "
		//    sbSql &= "x.ItemId, "
		//    sbSql &= "x.ModuleId, "
		//    sbSql &= "x.Title, "
		//    sbSql &= "'MediaSrc' = CASE WHEN mf.FileName IS NULL THEN x.MediaSrc ELSE mf.Folder + mf.FileName END, "
		//    sbSql &= "x.MediaAlign, "
		//    sbSql &= "'MediaSrc2' = CASE WHEN mf2.FileName IS NULL THEN x.MediaSrc2 ELSE mf2.Folder + mf2.FileName END, "
		//    sbSql &= "'DisplayDate' = CASE WHEN x.PublishDate IS NULL THEN x.CreatedDate ELSE x.PublishDate END, "
		//    sbSql &= "x.Description, "
		//    sbSql &= "x.Details, "
		//    sbSql &= "'NavURL' = CASE WHEN nf.FileName IS NULL THEN x.NavURL ELSE nf.Folder + nf.FileName END, "
		//    sbSql &= "nt.NewWindow, "
		//    sbSql &= "nt.TrackClicks, "
		//    sbSql &= "'RatingAverage' = CASE WHEN x.RatingVotes IS NULL OR x.RatingTotal IS NULL OR (x.RatingVotes < 1) THEN 0 WHEN (CAST((x.RatingTotal / x.RatingVotes) AS Integer) > 9) THEN 10 ELSE CAST((x.RatingTotal / x.RatingVotes) AS Integer) END "

		//    sbSql &= "FROM " & MyObjectQualifier & GetPrefixedDbObjectName("SalesReps") & " AS x "
		//    sbSql &= ScopeJoins
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As mf on x.MediaSrc = 'FileId=' + convert(varchar,mf.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As mf2 on x.MediaSrc2 = 'FileId=' + convert(varchar,mf2.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "Files] As nf on x.NavURL = 'FileId=' + convert(varchar,nf.FileID) "
		//    sbSql &= "LEFT OUTER JOIN [" & MyObjectQualifier & "UrlTracking] As nt on x.NavURL = nt.Url and nt.ModuleId = x.ModuleId "


		//    Select Case SearchOn.ToUpper()
		//        Case "TITLE", "DESCRIPTION"
		//            sbSql &= "WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc "

		//        Case "DETAILS"
		//            sbSql &= "WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc "

		//        Case Else '"ANY"
		//            sbSql &= "WHERE ((x.Title LIKE '" & strSearchText & "') "
		//            sbSql &= "OR (x.Description LIKE '" & strSearchText & "') "
		//            sbSql &= "OR (x.Details LIKE '" & strSearchText & "')) "
		//            sbSql &= DateFilter
		//            sbSql &= ScopeFilter
		//            sbSql &= CategoryFilter
		//            sbSql &= "ORDER BY x.Title, x.ViewOrder, x.UpdatedDate desc "

		//    End Select

		//    Return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql)
		//    'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), GetType(SalesRepInfo))
		//    'Return CBO.FillCollection(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader(sbSql.ToString()))

		//End Function


		#endregion

		#region " Optional Interfaces "

		DotNetNuke.Services.Search.SearchItemInfoCollection DotNetNuke.Entities.Modules.ISearchable.GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
		{
			SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

			ArrayList SalesReps = (ArrayList)GetModuleSalesReps(ModInfo.ModuleID);
			//Dim SalesReps As List(Of SalesRepInfo) = GetModuleSalesReps(ModInfo.ModuleID)

			//SalesRepInfo objSalesRep;
            foreach (SalesRepInfo objSalesRep in SalesReps)
            {
				SearchItemInfo SearchItem;
				{
                    //int UserId = Null.NullInteger;
                    int UserId = objSalesRep.CreatedByUserId;
                    //if (Information.IsNumeric(((SalesRepInfo)objSalesRep).CreatedByUser))
                    //{
                    //    UserId = int.Parse(((SalesRepInfo)objSalesRep).CreatedByUser);
                    //}

					string strContent = HttpUtility.HtmlDecode(((SalesRepInfo)objSalesRep).Title + " " + ((SalesRepInfo)objSalesRep).Description);
					string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((SalesRepInfo)objSalesRep).Description + " " + ((SalesRepInfo)objSalesRep).Details), false), 100, "...");

					SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((SalesRepInfo)objSalesRep).Title, strDescription, UserId, ((SalesRepInfo)objSalesRep).CreatedDate, ModInfo.ModuleID, ((SalesRepInfo)objSalesRep).ItemId.ToString(), strContent, "ItemId=" + ((SalesRepInfo)objSalesRep).ItemId.ToString(), Null.NullInteger);
					SearchItemCollection.Add(SearchItem);
				}
			}

			return SearchItemCollection;

		}

		string DotNetNuke.Entities.Modules.IPortable.ExportModule(int ModuleID)
		{
			Hashtable settings = DotNetNuke.Entities.Portals.PortalSettings.GetModuleSettings(ModuleID);
			string strXML = "";
			strXML += "<SalesReps>";

			//Export each SalesRep Details
			ArrayList arrSalesReps = (ArrayList)GetModuleSalesReps(ModuleID);
			//Dim arrSalesReps As List(Of SalesRepInfo) = GetModuleSalesReps(ModuleID)
			if (arrSalesReps.Count != 0)
			{
                //SalesRepInfo objSalesRep;
                foreach (SalesRepInfo objSalesRep in arrSalesReps)
                {
					{
						strXML += "<SalesRep>";
                        strXML += "<Title>" + XmlUtils.XMLEncode(objSalesRep.Title) + "</Title>";
						strXML += "<CategoryId>" + XmlUtils.XMLEncode(objSalesRep.CategoryId.ToString()) + "</CategoryId>";
						strXML += "<Category>" + XmlUtils.XMLEncode(objSalesRep.Category) + "</Category>";
						strXML += "<MediaSrc>" + XmlUtils.XMLEncode(objSalesRep.MediaSrc) + "</MediaSrc>";
						strXML += "<MediaWidth>" + XmlUtils.XMLEncode(objSalesRep.MediaWidth.ToString()) + "</MediaWidth>";
						strXML += "<MediaHeight>" + XmlUtils.XMLEncode(objSalesRep.MediaHeight.ToString()) + "</MediaHeight>";
						strXML += "<MediaAlign>" + XmlUtils.XMLEncode(objSalesRep.MediaAlign) + "</MediaAlign>";
						strXML += "<Description>" + XmlUtils.XMLEncode(objSalesRep.Description) + "</Description>";

                        //Actual Fields

                        strXML += "<RepNo>" + XmlUtils.XMLEncode(objSalesRep.RepNo) + "</RepNo>";
                        strXML += "<RepName>" + XmlUtils.XMLEncode(objSalesRep.RepName) + "</RepName>";
                        strXML += "<RepRate>" + XmlUtils.XMLEncode(objSalesRep.RepRate) + "</RepRate>";
                        strXML += "<RepDollar>" + XmlUtils.XMLEncode(objSalesRep.RepDollar) + "</RepDollar>";

						//Actual Fields

						strXML += "<Details>" + XmlUtils.XMLEncode(objSalesRep.Details) + "</Details>";
						strXML += "<MediaSrc2>" + XmlUtils.XMLEncode(objSalesRep.MediaSrc2) + "</MediaSrc2>";
						strXML += "<MediaWidth2>" + XmlUtils.XMLEncode(objSalesRep.MediaWidth2.ToString()) + "</MediaWidth2>";
						strXML += "<MediaHeight2>" + XmlUtils.XMLEncode(objSalesRep.MediaHeight2.ToString()) + "</MediaHeight2>";
						strXML += "<MediaAlign2>" + XmlUtils.XMLEncode(objSalesRep.MediaAlign2) + "</MediaAlign2>";
						strXML += "<NavURL>" + XmlUtils.XMLEncode(objSalesRep.NavURL) + "</NavURL>";
						strXML += "<PublishDate>" + XmlUtils.XMLEncode(objSalesRep.PublishDate.ToString()) + "</PublishDate>";
						strXML += "<ExpiryDate>" + XmlUtils.XMLEncode(objSalesRep.ExpiryDate.ToString()) + "</ExpiryDate>";
						strXML += "<ViewOrder>" + XmlUtils.XMLEncode(objSalesRep.ViewOrder.ToString()) + "</ViewOrder>";
						strXML += "</SalesRep>";
					}
				}
			}

			//Export the Module Settings
			OptionsInfo objOI = new OptionsInfo(ModuleID);
			{
				//Control Options
				strXML += "<ItemsScope>" + XmlUtils.XMLEncode(objOI.ItemsScope.ToString()) + "</ItemsScope>";
				strXML += "<ViewControl>" + XmlUtils.XMLEncode(objOI.ViewControl) + "</ViewControl>";
				strXML += "<AddDescription>" + XmlUtils.XMLEncode(objOI.AddDescription.ToString()) + "</AddDescription>";
				strXML += "<OnlyHostCanEdit>" + XmlUtils.XMLEncode(objOI.OnlyHostCanEdit.ToString()) + "</OnlyHostCanEdit>";
				strXML += "<BackColor>" + XmlUtils.XMLEncode(objOI.BackColor) + "</BackColor>";
				strXML += "<AltColor>" + XmlUtils.XMLEncode(objOI.AltColor) + "</AltColor>";
				strXML += "<HeaderBackColor>" + XmlUtils.XMLEncode(objOI.HeaderBackColor) + "</HeaderBackColor>";
				strXML += "<PagerBackColor>" + XmlUtils.XMLEncode(objOI.PagerBackColor) + "</PagerBackColor>";
				strXML += "<TabCss>" + XmlUtils.XMLEncode(objOI.TabCss) + "</TabCss>";
				strXML += "<NoOfPages>" + XmlUtils.XMLEncode(objOI.NoOfPages.ToString()) + "</NoOfPages>";
				strXML += "<DeleteFromGrid>" + XmlUtils.XMLEncode(objOI.DeleteFromGrid.ToString()) + "</DeleteFromGrid>";
				strXML += "<ViewOption>" + XmlUtils.XMLEncode(objOI.ViewOption) + "</ViewOption>";
				strXML += "<AddDate>" + XmlUtils.XMLEncode(objOI.AddDate) + "</AddDate>";
				strXML += "<ImagePosition>" + XmlUtils.XMLEncode(objOI.ImagePosition) + "</ImagePosition>";
				strXML += "<DynamicThumb>" + XmlUtils.XMLEncode(objOI.DynamicThumb.ToString()) + "</DynamicThumb>";
				strXML += "<UpdateRedirection>" + XmlUtils.XMLEncode(objOI.UpdateRedirection) + "</UpdateRedirection>";
				strXML += "<ScrollColumns>" + XmlUtils.XMLEncode(objOI.ScrollColumns.ToString()) + "</ScrollColumns>";
				strXML += "<TextMode>" + XmlUtils.XMLEncode(objOI.TextMode.ToString()) + "</TextMode>";
				strXML += "<DisplayInfo>" + XmlUtils.XMLEncode(objOI.DisplayInfo.ToString()) + "</DisplayInfo>";
				strXML += "<ThumbWidth>" + XmlUtils.XMLEncode(objOI.ThumbWidth) + "</ThumbWidth>";
				strXML += "<ThumbHeight>" + XmlUtils.XMLEncode(objOI.ThumbHeight) + "</ThumbHeight>";
				strXML += "<ThumbColumns>" + XmlUtils.XMLEncode(objOI.ThumbColumns.ToString()) + "</ThumbColumns>";
				strXML += "<HideTextLink>" + XmlUtils.XMLEncode(objOI.HideTextLink.ToString()) + "</HideTextLink>";
				strXML += "<InfoCssClass>" + XmlUtils.XMLEncode(objOI.InfoCssClass) + "</InfoCssClass>";
				strXML += "<ScrollBehavior>" + XmlUtils.XMLEncode(objOI.ScrollBehavior) + "</ScrollBehavior>";
				strXML += "<ScrollDirection>" + XmlUtils.XMLEncode(objOI.ScrollDirection) + "</ScrollDirection>";
				strXML += "<ScrollAmount>" + XmlUtils.XMLEncode(objOI.ScrollAmount) + "</ScrollAmount>";
				strXML += "<ScrollDelay>" + XmlUtils.XMLEncode(objOI.ScrollDelay) + "</ScrollDelay>";
				strXML += "<ScrollWidth>" + XmlUtils.XMLEncode(objOI.ScrollWidth) + "</ScrollWidth>";
				strXML += "<ScrollHeight>" + XmlUtils.XMLEncode(objOI.ScrollHeight) + "</ScrollHeight>";
				strXML += "<CellPadding>" + XmlUtils.XMLEncode(objOI.CellPadding) + "</CellPadding>";
				strXML += "<CellSpacing>" + XmlUtils.XMLEncode(objOI.CellSpacing) + "</CellSpacing>";
				strXML += "<RattleImage>" + XmlUtils.XMLEncode(objOI.RattleImage.ToString()) + "</RattleImage>";
				strXML += "<SSWidth>" + XmlUtils.XMLEncode(objOI.SSWidth) + "</SSWidth>";
				strXML += "<SSHeight>" + XmlUtils.XMLEncode(objOI.SSHeight) + "</SSHeight>";
				strXML += "<Delay>" + XmlUtils.XMLEncode(objOI.Delay) + "</Delay>";
				strXML += "<Transition>" + XmlUtils.XMLEncode(objOI.Transition) + "</Transition>";
				strXML += "<Thumbnail>" + XmlUtils.XMLEncode(objOI.Thumbnail.ToString()) + "</Thumbnail>";
				strXML += "<ThumbnailWidth>" + XmlUtils.XMLEncode(objOI.ThumbnailWidth) + "</ThumbnailWidth>";
				strXML += "<Resizing>" + XmlUtils.XMLEncode(objOI.Resizing) + "</Resizing>";
				strXML += "<OnlyEmbedTag>" + XmlUtils.XMLEncode(objOI.OnlyEmbedTag.ToString()) + "</OnlyEmbedTag>";
				strXML += "<ShowControls>" + XmlUtils.XMLEncode(objOI.ShowControls.ToString()) + "</ShowControls>";
				strXML += "<SSTitle>" + XmlUtils.XMLEncode(objOI.SSTitle) + "</SSTitle>";
				strXML += "<CaptionFont>" + XmlUtils.XMLEncode(objOI.CaptionFont) + "</CaptionFont>";
				strXML += "<CaptionSize>" + XmlUtils.XMLEncode(objOI.CaptionSize.ToString()) + "</CaptionSize>";
				strXML += "<BgColor>" + XmlUtils.XMLEncode(objOI.BgColor) + "</BgColor>";
				strXML += "<FSSTransition>" + XmlUtils.XMLEncode(objOI.FSSTransition) + "</FSSTransition>";
				strXML += "<Repeat>" + XmlUtils.XMLEncode(objOI.Repeat.ToString()) + "</Repeat>";
				strXML += "<Streaming>" + XmlUtils.XMLEncode(objOI.Streaming.ToString()) + "</Streaming>";
				strXML += "<EffectTime>" + XmlUtils.XMLEncode(objOI.EffectTime.ToString()) + "</EffectTime>";
				strXML += "<TransitionTime>" + XmlUtils.XMLEncode(objOI.TransitionTime.ToString()) + "</TransitionTime>";
				strXML += "<Volume>" + XmlUtils.XMLEncode(objOI.Volume.ToString()) + "</Volume>";
				strXML += "<MusicUrl>" + XmlUtils.XMLEncode(objOI.MusicUrl) + "</MusicUrl>";
				strXML += "<ShowMusicControls>" + XmlUtils.XMLEncode(objOI.ShowMusicControls.ToString()) + "</ShowMusicControls>";
				strXML += "<ProgressColor>" + XmlUtils.XMLEncode(objOI.ProgressColor) + "</ProgressColor>";
				strXML += "<TextColor>" + XmlUtils.XMLEncode(objOI.TextColor) + "</TextColor>";
				strXML += "<ThumbFolder>" + XmlUtils.XMLEncode(objOI.ThumbFolder) + "</ThumbFolder>";
				strXML += "<ThumbnailPosition>" + XmlUtils.XMLEncode(objOI.ThumbnailPosition) + "</ThumbnailPosition>";
				strXML += "<ThumbnailRows>" + XmlUtils.XMLEncode(objOI.ThumbnailRows.ToString()) + "</ThumbnailRows>";
				strXML += "<ThumbnailColumns>" + XmlUtils.XMLEncode(objOI.ThumbnailColumns.ToString()) + "</ThumbnailColumns>";
				strXML += "<NTWidth>" + XmlUtils.XMLEncode(objOI.NTWidth) + "</NTWidth>";
				strXML += "<NTHeight>" + XmlUtils.XMLEncode(objOI.NTHeight) + "</NTHeight>";
				strXML += "<Pause>" + XmlUtils.XMLEncode(objOI.Pause) + "</Pause>";
				strXML += "<Speed>" + XmlUtils.XMLEncode(objOI.Speed) + "</Speed>";
				strXML += "<InitialJuke>" + XmlUtils.XMLEncode(objOI.InitialJuke.ToString()) + "</InitialJuke>";
				strXML += "<AutoStart>" + XmlUtils.XMLEncode(objOI.AutoStart.ToString()) + "</AutoStart>";
				strXML += "<AutoRewind>" + XmlUtils.XMLEncode(objOI.AutoRewind.ToString()) + "</AutoRewind>";
				strXML += "<JukeSelector>" + XmlUtils.XMLEncode(objOI.JukeSelector.ToString()) + "</JukeSelector>";
				strXML += "<ReferIt>" + XmlUtils.XMLEncode(objOI.ReferIt) + "</ReferIt>";
				strXML += "<AutoRefresh>" + XmlUtils.XMLEncode(objOI.AutoRefresh.ToString()) + "</AutoRefresh>";
				strXML += "<JukePager>" + XmlUtils.XMLEncode(objOI.JukePager.ToString()) + "</JukePager>";
				strXML += "<ShowJukePanel>" + XmlUtils.XMLEncode(objOI.ShowJukePanel.ToString()) + "</ShowJukePanel>";
				strXML += "<ShowReferJuke>" + XmlUtils.XMLEncode(objOI.ShowReferJuke.ToString()) + "</ShowReferJuke>";
				strXML += "<ShowAddToFavourite>" + XmlUtils.XMLEncode(objOI.ShowAddToFavourite.ToString()) + "</ShowAddToFavourite>";
				strXML += "<ShowDownload>" + XmlUtils.XMLEncode(objOI.ShowDownload.ToString()) + "</ShowDownload>";
				strXML += "<ShowMusicDownload>" + XmlUtils.XMLEncode(objOI.ShowMusicDownload.ToString()) + "</ShowMusicDownload>";
				strXML += "<ShowRatings>" + XmlUtils.XMLEncode(objOI.ShowRatings.ToString()) + "</ShowRatings>";
				strXML += "<ShowSlotAvailability>" + XmlUtils.XMLEncode(objOI.ShowSlotAvailability.ToString()) + "</ShowSlotAvailability>";
				strXML += "<swSaveEnabled>" + XmlUtils.XMLEncode(objOI.swSaveEnabled.ToString()) + "</swSaveEnabled>";
				strXML += "<swVolume>" + XmlUtils.XMLEncode(objOI.swVolume.ToString()) + "</swVolume>";
				strXML += "<swRestart>" + XmlUtils.XMLEncode(objOI.swRestart.ToString()) + "</swRestart>";
				strXML += "<swPausePlay>" + XmlUtils.XMLEncode(objOI.swPausePlay.ToString()) + "</swPausePlay>";
				strXML += "<swFastForward>" + XmlUtils.XMLEncode(objOI.swFastForward.ToString()) + "</swFastForward>";
				strXML += "<swContextMenu>" + XmlUtils.XMLEncode(objOI.swContextMenu.ToString()) + "</swContextMenu>";

				strXML += "<swRemote>" + XmlUtils.XMLEncode(objOI.swRemote) + "</swRemote>";
				strXML += "<swStretchStyle>" + XmlUtils.XMLEncode(objOI.swStretchStyle) + "</swStretchStyle>";
				strXML += "<FlvSkinUrl>" + XmlUtils.XMLEncode(objOI.FlvSkinUrl) + "</FlvSkinUrl>";
				strXML += "<Palette>" + XmlUtils.XMLEncode(objOI.Palette) + "</Palette>";

				strXML += "<awWindow>" + XmlUtils.XMLEncode(objOI.awWindow) + "</awWindow>";
				strXML += "<RatingsInNewWindow>" + XmlUtils.XMLEncode(objOI.RatingsInNewWindow.ToString()) + "</RatingsInNewWindow>";
				strXML += "<DataFolder>" + XmlUtils.XMLEncode(objOI.DataFolder) + "</DataFolder>";
				strXML += "<PayPalId>" + XmlUtils.XMLEncode(objOI.PayPalId) + "</PayPalId>";

				strXML += "<SlotAdPrice>" + XmlUtils.XMLEncode(objOI.SlotAdPrice.ToString()) + "</SlotAdPrice>";

				strXML += "<UpdatedByUserId>" + XmlUtils.XMLEncode(objOI.UpdatedByUserId.ToString()) + "</UpdatedByUserId>";
				strXML += "<UpdatedByUser>" + XmlUtils.XMLEncode(objOI.UpdatedByUser) + "</UpdatedByUser>";
				strXML += "<UpdatedDate>" + XmlUtils.XMLEncode(objOI.UpdatedDate.ToString()) + "</UpdatedDate>";

				//Option1 Options
				strXML += "<PagerSize>" + XmlUtils.XMLEncode(objOI.PagerSize.ToString()) + "</PagerSize>";
			}


			strXML += "</SalesReps>";

			return strXML;

		}

		void DotNetNuke.Entities.Modules.IPortable.ImportModule(int ModuleID, string Content, string Version, int UserId)
		{
            XmlNode xmlSalesReps = DotNetNuke.Common.Globals.GetContent(Content, "SalesReps");

			//Import each SalesRep Details
            //XmlNode xmlSalesRep;
            foreach (XmlNode xmlSalesRep in xmlSalesReps.SelectNodes("SalesRep"))
            {
				SalesRepInfo objSalesRep = new SalesRepInfo();
				{
					objSalesRep.ModuleId = ModuleID;
					//Import into the Current Module, hence use ModuleId and not from the xml file

					objSalesRep.Title = xmlSalesRep["Title"].InnerText;
					try {
						objSalesRep.CategoryId = int.Parse(xmlSalesRep["CategoryId"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.Category = xmlSalesRep["Category"].InnerText;
					}
					catch {
					}
					try {
                        objSalesRep.MediaSrc = DotNetNuke.Common.Globals.ImportUrl(ModuleID, xmlSalesRep["MediaSrc"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.MediaWidth = xmlSalesRep["MediaWidth"].InnerText;
					}
					catch {
					}
					try {
						objSalesRep.MediaHeight = xmlSalesRep["MediaHeight"].InnerText;
					}
					catch {
					}
					try {
						objSalesRep.MediaAlign = xmlSalesRep["MediaAlign"].InnerText;
					}
					catch {
					}
					try {
						objSalesRep.Description = xmlSalesRep["Description"].InnerText;
					}
					catch {
					}

                    ///Actual Fields
                    try
                    {
                        objSalesRep.RepNo = xmlSalesRep["RepNo"].InnerText;
                    }
                    catch
                    {
                    }

                    try
                    {
                        objSalesRep.RepName = xmlSalesRep["RepName"].InnerText;
                    }
                    catch
                    {
                    }

                    try
                    {
                        objSalesRep.RepRate = xmlSalesRep["RepRate"].InnerText;
                    }
                    catch
                    {
                    }
                    try
                    {
                        objSalesRep.RepDollar = xmlSalesRep["RepDollar"].InnerText;
                    }
                    catch
                    {```````````````````                                                                                                                                
                    }



					//Actual Fields

					try {
						objSalesRep.Details = xmlSalesRep["Details"].InnerText;
					}
					catch {
					}
					try {
                        objSalesRep.MediaSrc2 = DotNetNuke.Common.Globals.ImportUrl(ModuleID, xmlSalesRep["MediaSrc2"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.MediaWidth2 = xmlSalesRep["MediaWidth2"].InnerText;
					}
					catch {
					}
					try {
						objSalesRep.MediaHeight2 = xmlSalesRep["MediaHeight2"].InnerText;
					}
					catch {
					}
					try {
						objSalesRep.MediaAlign2 = xmlSalesRep["MediaAlign2"].InnerText;
					}
					catch {
					}
					try {
                        objSalesRep.NavURL = DotNetNuke.Common.Globals.ImportUrl(ModuleID, xmlSalesRep["NavURL"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.PublishDate = DateTime.Parse(xmlSalesRep["PublishDate"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.ExpiryDate = DateTime.Parse(xmlSalesRep["ExpiryDate"].InnerText);
					}
					catch {
					}
					try {
						objSalesRep.ViewOrder = int.Parse(xmlSalesRep["ViewOrder"].InnerText);
					}
					catch {
					}

					objSalesRep.UpdatedByUserId = UserId;
					//User the UserId of the Current User who is Importing this data
					objSalesRep.UpdatedDate = DateTime.Now;
					objSalesRep.CreatedByUserId = UserId;
					//User the UserId of the Current User who is Importing this data
                    objSalesRep.CreatedDate = DateTime.Now;
				}

				AddSalesRep(objSalesRep);
			}

			//Import the Module Settings
			DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
			OptionsInfo objOI = new OptionsInfo();
			{
				//.ModuleID = ModuleID

				//Control Options
				try {
					objOI.ItemsScope = int.Parse(xmlSalesReps.SelectSingleNode("ItemsScope").InnerText);
				}
				catch {
				}
				try {
					objOI.ViewControl = xmlSalesReps.SelectSingleNode("ViewControl").InnerText;
				}
				catch {
				}
				try {
					objOI.AddDescription = bool.Parse(xmlSalesReps.SelectSingleNode("AddDescription").InnerText);
				}
				catch {
				}

				try {
					objOI.OnlyHostCanEdit = bool.Parse(xmlSalesReps.SelectSingleNode("OnlyHostCanEdit").InnerText);
				}
				catch {
				}
				try {
					objOI.BackColor = xmlSalesReps.SelectSingleNode("BackColor").InnerText;
				}
				catch {
				}
				try {
					objOI.AltColor = xmlSalesReps.SelectSingleNode("AltColor").InnerText;
				}
				catch {
				}

				try {
					objOI.HeaderBackColor = xmlSalesReps.SelectSingleNode("HeaderBackColor").InnerText;
				}
				catch {
				}


				try {
					objOI.PagerBackColor = xmlSalesReps.SelectSingleNode("PagerBackColor").InnerText;
				}
				catch {
				}

				try {
					objOI.TabCss = xmlSalesReps.SelectSingleNode("TabCss").InnerText;
				}
				catch {
				}
				try {
					objOI.NoOfPages = int.Parse(xmlSalesReps.SelectSingleNode("NoOfPages").InnerText);
				}
				catch {
				}
				try {
					objOI.DeleteFromGrid = bool.Parse(xmlSalesReps.SelectSingleNode("DeleteFromGrid").InnerText);
				}
				catch {
				}

				try {
					objOI.ViewOption = xmlSalesReps.SelectSingleNode("ViewOption").InnerText;
				}
				catch {
				}
				try {
					objOI.AddDate = xmlSalesReps.SelectSingleNode("AddDate").InnerText;
				}
				catch {
				}


				try {
					objOI.ImagePosition = xmlSalesReps.SelectSingleNode("ImagePosition").InnerText;
				}
				catch {
				}

				try {
					objOI.DynamicThumb = bool.Parse(xmlSalesReps.SelectSingleNode("DynamicThumb").InnerText);
				}
				catch {
				}

				try {
					objOI.UpdateRedirection = xmlSalesReps.SelectSingleNode("UpdateRedirection").InnerText;
				}
				catch {
				}

				try {
					objOI.ScrollColumns = int.Parse(xmlSalesReps.SelectSingleNode("ScrollColumns").InnerText);
				}
				catch {
				}
				try {
					objOI.TextMode = bool.Parse(xmlSalesReps.SelectSingleNode("TextMode").InnerText);
				}
				catch {
				}
				try {
					objOI.DisplayInfo = bool.Parse(xmlSalesReps.SelectSingleNode("DisplayInfo").InnerText);
				}
				catch {
				}
				try {
					objOI.ThumbWidth = xmlSalesReps.SelectSingleNode("ThumbWidth").InnerText;
				}
				catch {
				}
				try {
					objOI.ThumbHeight = xmlSalesReps.SelectSingleNode("ThumbHeight").InnerText;
				}
				catch {
				}

				try {
					objOI.ThumbColumns = int.Parse(xmlSalesReps.SelectSingleNode("ThumbColumns").InnerText);
				}
				catch {
				}
				try {
					objOI.HideTextLink = bool.Parse(xmlSalesReps.SelectSingleNode("HideTextLink").InnerText);
				}
				catch {
				}

				try {
					objOI.InfoCssClass = xmlSalesReps.SelectSingleNode("InfoCssClass").InnerText;
				}
				catch {
				}

				try {
					objOI.ScrollBehavior = xmlSalesReps.SelectSingleNode("ScrollBehavior").InnerText;
				}
				catch {
				}

				try {
					objOI.ScrollDirection = xmlSalesReps.SelectSingleNode("ScrollDirection").InnerText;
				}
				catch {
				}
				try {
					objOI.ScrollAmount = xmlSalesReps.SelectSingleNode("ScrollAmount").InnerText;
				}
				catch {
				}
				try {
					objOI.ScrollDelay = xmlSalesReps.SelectSingleNode("ScrollDelay").InnerText;
				}
				catch {
				}
				try {
					objOI.ScrollWidth = xmlSalesReps.SelectSingleNode("ScrollWidth").InnerText;
				}
				catch {
				}
				try {
					objOI.ScrollHeight = xmlSalesReps.SelectSingleNode("ScrollHeight").InnerText;
				}
				catch {
				}
				try {
					objOI.CellPadding = xmlSalesReps.SelectSingleNode("CellPadding").InnerText;
				}
				catch {
				}
				try {
					objOI.CellSpacing = xmlSalesReps.SelectSingleNode("CellSpacing").InnerText;
				}
				catch {
				}
				try {
					objOI.RattleImage = bool.Parse(xmlSalesReps.SelectSingleNode("RattleImage").InnerText);
				}
				catch {
				}
				try {
					objOI.SSWidth = xmlSalesReps.SelectSingleNode("SSWidth").InnerText;
				}
				catch {
				}
				try {
					objOI.SSHeight = xmlSalesReps.SelectSingleNode("SSHeight").InnerText;
				}
				catch {
				}
				try {
					objOI.Delay = xmlSalesReps.SelectSingleNode("Delay").InnerText;
				}
				catch {
				}
				try {
					objOI.Transition = xmlSalesReps.SelectSingleNode("Transition").InnerText;
				}
				catch {
				}
				try {
					objOI.Thumbnail = bool.Parse(xmlSalesReps.SelectSingleNode("Thumbnail").InnerText);
				}
				catch {
				}
				try {
					objOI.ThumbnailWidth = xmlSalesReps.SelectSingleNode("ThumbnailWidth").InnerText;
				}
				catch {
				}
				try {
					objOI.Resizing = xmlSalesReps.SelectSingleNode("Resizing").InnerText;
				}
				catch {
				}

				try {
					objOI.OnlyEmbedTag = bool.Parse(xmlSalesReps.SelectSingleNode("OnlyEmbedTag").InnerText);
				}
				catch {
				}
				try {
					objOI.ShowControls = bool.Parse(xmlSalesReps.SelectSingleNode("ShowControls").InnerText);
				}
				catch {
				}
				try {
					objOI.SSTitle = xmlSalesReps.SelectSingleNode("SSTitle").InnerText;
				}
				catch {
				}
				try {
					objOI.CaptionFont = xmlSalesReps.SelectSingleNode("CaptionFont").InnerText;
				}
				catch {
				}

				try {
					objOI.CaptionSize = int.Parse(xmlSalesReps.SelectSingleNode("CaptionSize").InnerText);
				}
				catch {
				}
				try {
					objOI.BgColor = xmlSalesReps.SelectSingleNode("BgColor").InnerText;
				}
				catch {
				}
				try {
					objOI.FSSTransition = xmlSalesReps.SelectSingleNode("FSSTransition").InnerText;
				}
				catch {
				}

				try {
					objOI.Repeat = bool.Parse(xmlSalesReps.SelectSingleNode("Repeat").InnerText);
				}
				catch {
				}


				try {
					objOI.Streaming = bool.Parse(xmlSalesReps.SelectSingleNode("Streaming").InnerText);
				}
				catch {
				}

				try {
					objOI.EffectTime = double.Parse(xmlSalesReps.SelectSingleNode("EffectTime").InnerText);
				}
				catch {
				}

				try {
					objOI.TransitionTime = int.Parse(xmlSalesReps.SelectSingleNode("TransitionTime").InnerText);
				}
				catch {
				}

				try {
					objOI.Volume = int.Parse(xmlSalesReps.SelectSingleNode("Volume").InnerText);
				}
				catch {
				}
				try {
					objOI.MusicUrl = xmlSalesReps.SelectSingleNode("MusicUrl").InnerText;
				}
				catch {
				}
				try {
					objOI.ShowMusicControls = bool.Parse(xmlSalesReps.SelectSingleNode("ShowMusicControls").InnerText);
				}
				catch {
				}
				try {
					objOI.ProgressColor = xmlSalesReps.SelectSingleNode("ProgressColor").InnerText;
				}
				catch {
				}
				try {
					objOI.TextColor = xmlSalesReps.SelectSingleNode("TextColor").InnerText;
				}
				catch {
				}
				try {
					objOI.ThumbFolder = xmlSalesReps.SelectSingleNode("ThumbFolder").InnerText;
				}
				catch {
				}
				try {
					objOI.ThumbnailPosition = xmlSalesReps.SelectSingleNode("ThumbnailPosition").InnerText;
				}
				catch {
				}
				try {
					objOI.ThumbnailRows = int.Parse(xmlSalesReps.SelectSingleNode("ThumbnailRows").InnerText);
				}
				catch {
				}
				try {
					objOI.ThumbnailColumns = int.Parse(xmlSalesReps.SelectSingleNode("ThumbnailColumns").InnerText);
				}
				catch {
				}
				try {
					objOI.NTWidth = xmlSalesReps.SelectSingleNode("NTWidth").InnerText;
				}
				catch {
				}
				try {
					objOI.NTHeight = xmlSalesReps.SelectSingleNode("NTHeight").InnerText;
				}
				catch {
				}
				try {
					objOI.Pause = xmlSalesReps.SelectSingleNode("Pause").InnerText;
				}
				catch {
				}
				try {
					objOI.Speed = xmlSalesReps.SelectSingleNode("Speed").InnerText;
				}
				catch {
				}
				try {
					objOI.InitialJuke = int.Parse(xmlSalesReps.SelectSingleNode("InitialJuke").InnerText);
				}
				catch {
				}
				try {
					objOI.AutoStart = bool.Parse(xmlSalesReps.SelectSingleNode("AutoStart").InnerText);
				}
				catch {
				}
				try {
					objOI.AutoRewind = bool.Parse(xmlSalesReps.SelectSingleNode("AutoRewind").InnerText);
				}
				catch {
				}
				try {
					objOI.JukeSelector = int.Parse(xmlSalesReps.SelectSingleNode("JukeSelector").InnerText);
				}
				catch {
				}

				try {
					objOI.ReferIt = xmlSalesReps.SelectSingleNode("ReferIt").InnerText;
				}
				catch {
				}
				try {
					objOI.AutoRefresh = int.Parse(xmlSalesReps.SelectSingleNode("AutoRefresh").InnerText);
				}
				catch {
				}

				try {
					objOI.JukePager = int.Parse(xmlSalesReps.SelectSingleNode("JukePager").InnerText);
				}
				catch {
				}

				try {
					objOI.ShowJukePanel = bool.Parse(xmlSalesReps.SelectSingleNode("ShowJukePanel").InnerText);
				}
				catch {
				}
				try {
					objOI.ShowReferJuke = bool.Parse(xmlSalesReps.SelectSingleNode("ShowReferJuke").InnerText);
				}
				catch {
				}
				try {
					objOI.ShowAddToFavourite = bool.Parse(xmlSalesReps.SelectSingleNode("ShowAddToFavourite").InnerText);
				}
				catch {
				}
				try {
					objOI.ShowDownload = bool.Parse(xmlSalesReps.SelectSingleNode("ShowDownload").InnerText);
				}
				catch {
				}
				try {
					objOI.ShowMusicDownload = bool.Parse(xmlSalesReps.SelectSingleNode("ShowMusicDownload").InnerText);
				}
				catch {
				}

				try {
					objOI.ShowRatings = bool.Parse(xmlSalesReps.SelectSingleNode("ShowRatings").InnerText);
				}
				catch {
				}

				try {
					objOI.ShowSlotAvailability = bool.Parse(xmlSalesReps.SelectSingleNode("ShowSlotAvailability").InnerText);
				}
				catch {
				}

				try {
					objOI.swSaveEnabled = bool.Parse(xmlSalesReps.SelectSingleNode("swSaveEnabled").InnerText);
				}
				catch {
				}

				try {
					objOI.swVolume = bool.Parse(xmlSalesReps.SelectSingleNode("swVolume").InnerText);
				}
				catch {
				}
				try {
					objOI.swRestart = bool.Parse(xmlSalesReps.SelectSingleNode("swRestart").InnerText);
				}
				catch {
				}

				try {
					objOI.swPausePlay = bool.Parse(xmlSalesReps.SelectSingleNode("swPausePlay").InnerText);
				}
				catch {
				}

				try {
					objOI.swFastForward = bool.Parse(xmlSalesReps.SelectSingleNode("swFastForward").InnerText);
				}
				catch {
				}

				try {
					objOI.swContextMenu = bool.Parse(xmlSalesReps.SelectSingleNode("swContextMenu").InnerText);
				}
				catch {
				}
				try {
					objOI.swRemote = xmlSalesReps.SelectSingleNode("swRemote").InnerText;
				}
				catch {
				}
				try {
					objOI.Speed = xmlSalesReps.SelectSingleNode("Speed").InnerText;
				}
				catch {
				}
				try {
					objOI.FlvSkinUrl = xmlSalesReps.SelectSingleNode("FlvSkinUrl").InnerText;
				}
				catch {
				}
				try {
					objOI.Palette = xmlSalesReps.SelectSingleNode("Palette").InnerText;
				}
				catch {
				}
				try {
					objOI.awWindow = xmlSalesReps.SelectSingleNode("awWindow").InnerText;
				}
				catch {
				}
				try {
					objOI.RatingsInNewWindow = bool.Parse(xmlSalesReps.SelectSingleNode("RatingsInNewWindow").InnerText);
				}
				catch {
				}
				try {
					objOI.DataFolder = xmlSalesReps.SelectSingleNode("DataFolder").InnerText;
				}
				catch {
				}
				try {
					objOI.PayPalId = xmlSalesReps.SelectSingleNode("PayPalId").InnerText;
				}
				catch {
				}
				try {
					objOI.SlotAdPrice = decimal.Parse(xmlSalesReps.SelectSingleNode("SlotAdPrice").InnerText);
				}
				catch {

				}

				try {
					objOI.UpdatedByUserId = int.Parse(xmlSalesReps.SelectSingleNode("UpdatedByUserId").InnerText);
				}
				catch {
				}
				try {
					objOI.UpdatedByUser = xmlSalesReps.SelectSingleNode("UpdatedByUser").InnerText;
				}
				catch {
				}
				try {
					objOI.UpdatedDate = DateTime.Parse(xmlSalesReps.SelectSingleNode("UpdatedDate").InnerText);
				}
				catch {
				}

				//Option1 Options
				try {
					objOI.PagerSize = int.Parse(xmlSalesReps.SelectSingleNode("PagerSize").InnerText);
				}
				catch {
				}


				objOI.Update(ModuleID);
			}

		}

		#endregion

	}
	//SalesRepsController

}
//bhattji.Modules.SalesReps.Business
