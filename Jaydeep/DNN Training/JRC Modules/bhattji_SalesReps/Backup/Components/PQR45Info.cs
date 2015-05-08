//Imports System
using System.Data;
using System;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
//Imports DotNetNuke.Data

namespace bhattji.Modules.SalesReps.Business
{

    public partial class PQR45Info : DotNetNuke.Entities.Modules.IHydratable
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "
        private int _ItemId;
        private int _SalesRepId;
        private string _SalesRepTitle;

        private string _PQR45;

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

		public int SalesRepId {
			get { return _SalesRepId; }
			set { _SalesRepId = value; }
		}

		public string SalesRepTitle {
			get { return _SalesRepTitle; }
			set { _SalesRepTitle = value; }
		}

		public string PQR45 {
			get { return _PQR45; }
			set { _PQR45 = value; }
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
			_SalesRepId = Convert.ToInt32(Null.SetNull(dr["SalesRepId"], SalesRepId));
			_SalesRepTitle = Convert.ToString(Null.SetNull(dr["SalesRepTitle"], SalesRepTitle));
			_PQR45 = Convert.ToString(Null.SetNull(dr["PQR45"], PQR45));

			_ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
		}

		#endregion

	}
	//PQR45Info

    public partial class PQR45sController
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
		public int AddUpdatePQR45(PQR45Info objPQR45)
		{
			if (objPQR45.ItemId > 0)
			{
				UpdatePQR45(objPQR45);
				return objPQR45.ItemId;
			}
			else
			{
				return AddPQR45(objPQR45);
			}
		}

		public int AddPQR45(PQR45Info objPQR45)
		{
			{
                return Convert.ToInt32(DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddSalesRepPQR45"), objPQR45.SalesRepId, objPQR45.PQR45, GetNull(objPQR45.ViewOrder)));
			}
		}

		public void UpdatePQR45(PQR45Info objPQR45)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateSalesRepPQR45"), objPQR45.ItemId, objPQR45.SalesRepId, objPQR45.PQR45, GetNull(objPQR45.ViewOrder));
			}
		}

		public void DeletePQR45(PQR45Info objPQR45)
		{
			DeletePQR45(objPQR45.ItemId);
		}

		public void DeletePQR45(int ItemID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteSalesRepPQR45"), ItemID);
		}

		public void SetViewOrderPQR45s(int SalesRepId)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderSalesRepPQR45s"), SalesRepId);
		}

		public void ClaimOrphanPQR45s(int SalesRepId)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanSalesRepPQR45s"), SalesRepId);
		}



		public PQR45Info GetPQR45(int ItemID)
		{
			//Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRepPQR45", ItemID), GetType(PQR45Info)), PQR45Info)
			return CBO.FillObject<PQR45Info>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetSalesRepPQR45"), ItemID));
		}

		//This function retreives the Items from Database,
		//depending upon the paramters supplied
		//If you supplied SalesRepId only, it gets GetSalesRepItems(SalesRepId)
		//If you supplied any SalesRepId, with PortalID only, it gets GetPortalItems(PortalID)
		//If you dont suppliy any parameter it gets GetAllItems()

		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s()
		{
			return GetPQR45s("");
		}
		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s(int SalesRepId)
		{
			return GetPQR45s("", false, SalesRepId);
		}
		public DataTable GetPQR45s(string SearchText)
		{
			return GetPQR45s(SearchText, false, -1);
		}
		//GetPQR45s
		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s(string SearchText, bool StartsWith, int SalesRepId)
		{
			// Public Function GetPQR45s(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal SalesRepId As Integer = -1) As DataTable 'List(Of PQR45Info) 'ArrayList 'IDataReader '
			//Return GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, PQR45Id, SalesRepId, PortalId, ItemsScope), GetType(SalesRepInfo)
			//Return CBO.FillCollection(GetSalesRepCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, PQR45Id, SalesRepId, PortalId, ItemsScope), GetType(SalesRepInfo))
			//Return CBO.FillCollection(Of PQR45Info)(GetPQR45sCommon(SearchText, StartsWith, SalesRepId))

			DataTable dt = new DataTable();
			dt.Load(GetPQR45sCommon(SearchText, StartsWith, SalesRepId));
			return dt;
		}
		//GetPQR45s

		public IDataReader GetPQR45sCommon(string SearchText)
		{
			return GetPQR45sCommon(SearchText, false, -1);
		}
		//GetPQR45sCommon

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetPQR45sCommon(string SearchText, bool StartsWith, int SalesRepId)
		{
			//Public Function GetPQR45sCommon(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal SalesRepId As Integer = -1) As IDataReader 'ArrayList 'List(Of PQR45Info) '
			if (SearchText != "")
			{
				return GetSearchedPQR45s(SearchText, StartsWith, SalesRepId);
			}
			else
			{
				if (SalesRepId > -1)
				{
					return GetSalesRepPQR45s(SalesRepId);
				}
				else
				{
					return GetAllPQR45s();
				}
			}
		}
		//GetPQR45sCommon

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetSalesRepPQR45s(int SalesRepId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetSalesRepPQR45s"), SalesRepId);
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRepPQR45s", SalesRepId), GetType(PQR45Info))
			//Return CBO.FillCollection(Of PQR45Info)(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRepPQR45s", SalesRepId))
		}

		//Public Function GetPortalPQR45s(ByVal PortalId As Integer) As IDataReader 'ArrayList 'List(Of PQR45Info) '
		//    Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesRepPQR45s", PortalId)
		//    'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesRepPQR45s", PortalId), GetType(PQR45Info))
		//    'Return CBO.FillCollection(Of PQR45Info)(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesRepPQR45s", PortalId))
		//End Function

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetAllPQR45s()
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllSalesRepPQR45s"));
			//Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesRepPQR45s"), GetType(PQR45Info))
			//Return CBO.FillCollection(Of PQR45Info)(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesRepPQR45s"))
		}


		//Private Sub GetScopeFilter(ByRef ScopeFilter As String, ByRef ScopeJoins As String, ByVal SalesRepId As Integer, ByVal PortalId As Integer, ByVal ItemsScope As Integer, ByVal ObjectQualifier As String)
		//    Select Case ItemsScope
		//        Case 0
		//            If SalesRepId > -1 Then
		//                ScopeFilter = "AND (x.SalesRepId = " & SalesRepId.ToString() & ") " 'Return GetSalesReps(SalesRepId)
		//            End If
		//        Case 1
		//            If PortalId > -1 Then
		//                ScopeJoins = "INNER JOIN [" & ObjectQualifier & "Modules] As m on x.SalesRepId = m.SalesRepId " 'Return GetPortalSalesReps(PortalId)
		//                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
		//            End If
		//        Case 2
		//            'Do Nothing
		//        Case Else '0
		//            If PortalId > -1 Then
		//                ScopeJoins = "INNER JOIN [" & ObjectQualifier & "Modules] As m on x.SalesRepId = m.SalesRepId " 'Return GetPortalSalesReps(PortalId)
		//                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString() & ") " 'Return GetPortalSalesReps(PortalId)
		//            ElseIf SalesRepId > -1 Then
		//                ScopeFilter = "AND (x.SalesRepId = " & SalesRepId.ToString() & ") " 'Return GetModuleSalesReps(SalesRepId)
		//            End If
		//    End Select
		//End Sub 'GetScopeFilter

		//Private Function GetDateFilter(ByVal FromDate As String, ByVal ToDate As String) As String
		//    Dim DateFilter As String = ""
		//    Dim DateTo As Date = Now
		//    If ToDate <> "" Then
		//        Try
		//            DateTo = Date.Parse(ToDate)
		//        Catch
		//            DateTo = Now
		//        End Try
		//    End If
		//    Dim DateFrom As Date = #1/1/1947#
		//    If FromDate <> "" Then
		//        Try
		//            DateFrom = Date.Parse(FromDate)
		//        Catch
		//            DateFrom = #1/1/1947#
		//        End Try
		//    End If

		//    If DateFrom > DateTo Then
		//        Dim tDate As Date = DateFrom
		//        DateFrom = DateTo
		//        DateTo = tDate
		//    End If

		//    If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString() & "')) "
		//    If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString() & "')) "

		//    Return DateFilter
		//End Function 'GetDateFilter


		public IDataReader GetSearchedPQR45s(string SearchText)
		{
			return GetSearchedPQR45s(SearchText, false, -1);
		}
		//GetSearchedPQR45s

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetSearchedPQR45s(string SearchText, bool StartsWith, int SalesRepId)
		{
			//Public Function GetSearchedPQR45s(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False, Optional ByVal SalesRepId As Integer = -1) As IDataReader 'ArrayList 'List(Of PQR45Info) '
			string MyObjectQualifier = GetObjectQualifier();

			string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();


            StringBuilder sbSql = new StringBuilder();

                sbSql.Append("SELECT ");
                //sbSql.Append("x.* " 
                sbSql.Append("x.ItemId, ");
                sbSql.Append("x.SalesRepId, ");
                sbSql.Append("'SalesRepTitle' = p.Title, ");
                sbSql.Append("x.PQR45, ");
                sbSql.Append("x.ViewOrder ");

                sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("SalesRepPQR45s") + " AS x ");
                sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + GetPrefixedDbObjectName("SalesReps") + "] As p on x.SalesRepId = p.ItemId ");

                sbSql.Append("WHERE (x.PQR45 LIKE '" + strSearchText + "') ");
                if (SalesRepId > 0)
                    sbSql.Append("AND (x.SalesRepId = " + SalesRepId.ToString() + ") ");

                sbSql.Append("ORDER BY x.SalesRepId, x.ViewOrder, x.PQR45 ");

                return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString());
        
			//Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), GetType(PQR45Info))
			//Return CBO.FillCollection(Of PQR45Info)(DataProvider.Instance().ExecuteReader(sbSql.ToString()))

		}
		//GetSearchedPQR45s


		#endregion

	}
	//PQR45sController

}
//bhattji.Modules.SalesReps.Business
