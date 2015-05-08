Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.Brokers.Business

    Public Class BrokerInfo
        Implements IHydratable
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _brokerCode As String
        Private _brokerName As String
        Private _addressLine1 As String
        Private _addressLine2 As String
        Private _city As String
        Private _state As String
        Private _zipCode As String
        Private _phoneNo As String
        Private _ext As String
        Private _contactCode As String
        Private _vendorRef As String
        Private _countryCode As String
        Private _emailAddress As String
        Private _commRate As Double
        Private _adminExempt As String
        Private _status As String
        Private _loadType As String
        Private _favorite As String
        Private _sortSeq As String
        Private _brokerNotes As String
        Private _bkrType As String
        Private _corpUpd As DateTime
        Private _division As String
        Private _faxNo As String
        Private _jRCTrailer As String
        Private _bStatus As String
        Private _thirdPartyOK As String
        Private _tPPct As Double
        Private _tPAmt As Double

        Private _ViewOrder As Integer
        Private _UpdatedByUserId As Integer
        Private _UpdatedByUser As String
        Private _UpdatedDate As Date
        Private _CreatedByUserId As Integer
        Private _CreatedByUser As String
        Private _CreatedDate As Date

#End Region

#Region " Properties "

        Private Property KeyID() As Integer Implements IHydratable.KeyID
            Get
                Return _ItemId
            End Get
            Set(ByVal value As Integer)
                _ItemId = value
            End Set
        End Property

        Public Property ItemId() As Integer
            Get
                Return _ItemId
            End Get
            Set(ByVal Value As Integer)
                _ItemId = Value
            End Set
        End Property

        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property

        Public Property BrokerCode() As String
            Get
                Return _brokerCode
            End Get
            Set(ByVal Value As String)
                _brokerCode = Value
            End Set
        End Property

        Public Property BrokerName() As String
            Get
                Return _brokerName
            End Get
            Set(ByVal Value As String)
                _brokerName = Value
            End Set
        End Property

        Public Property AddressLine1() As String
            Get
                Return _addressLine1
            End Get
            Set(ByVal Value As String)
                _addressLine1 = Value
            End Set
        End Property

        Public Property AddressLine2() As String
            Get
                Return _addressLine2
            End Get
            Set(ByVal Value As String)
                _addressLine2 = Value
            End Set
        End Property

        Public Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal Value As String)
                _city = Value
            End Set
        End Property

        Public Property State() As String
            Get
                Return _state
            End Get
            Set(ByVal Value As String)
                _state = Value
            End Set
        End Property

        Public Property ZipCode() As String
            Get
                Return _zipCode
            End Get
            Set(ByVal Value As String)
                _zipCode = Value
            End Set
        End Property

        Public Property PhoneNo() As String
            Get
                Return _phoneNo
            End Get
            Set(ByVal Value As String)
                _phoneNo = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property Ext() As String
            Get
                Return _ext
            End Get
            Set(ByVal Value As String)
                _ext = Value
            End Set
        End Property

        Public Property ContactCode() As String
            Get
                Return _contactCode
            End Get
            Set(ByVal Value As String)
                _contactCode = Value
            End Set
        End Property

        Public Property VendorRef() As String
            Get
                Return _vendorRef
            End Get
            Set(ByVal Value As String)
                _vendorRef = Value
            End Set
        End Property

        Public Property CountryCode() As String
            Get
                Return _countryCode
            End Get
            Set(ByVal Value As String)
                _countryCode = Value
            End Set
        End Property

        Public Property EmailAddress() As String
            Get
                Return _emailAddress
            End Get
            Set(ByVal Value As String)
                _emailAddress = Value
            End Set
        End Property

        Public Property CommRate() As Double
            Get
                Return _commRate
            End Get
            Set(ByVal Value As Double)
                _commRate = Value
            End Set
        End Property

        Public Property AdminExempt() As String
            Get
                Return _adminExempt
            End Get
            Set(ByVal Value As String)
                _adminExempt = Value
            End Set
        End Property

        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal Value As String)
                _status = Value
            End Set
        End Property

        Public Property LoadType() As String
            Get
                Return _loadType
            End Get
            Set(ByVal Value As String)
                _loadType = Value
            End Set
        End Property

        Public Property Favorite() As String
            Get
                Return _favorite
            End Get
            Set(ByVal Value As String)
                _favorite = Value
            End Set
        End Property

        Public Property SortSeq() As String
            Get
                Return _sortSeq
            End Get
            Set(ByVal Value As String)
                _sortSeq = Value
            End Set
        End Property

        Public Property BrokerNotes() As String
            Get
                Return _brokerNotes
            End Get
            Set(ByVal Value As String)
                _brokerNotes = Value
            End Set
        End Property

        Public Property BkrType() As String
            Get
                Return _bkrType
            End Get
            Set(ByVal Value As String)
                _bkrType = Value
            End Set
        End Property

        Public Property CorpUpd() As DateTime
            Get
                Return _corpUpd
            End Get
            Set(ByVal Value As DateTime)
                _corpUpd = Value
            End Set
        End Property

        Public Property Division() As String
            Get
                Return _division
            End Get
            Set(ByVal Value As String)
                _division = Value
            End Set
        End Property

        Public Property FaxNo() As String
            Get
                Return _faxNo
            End Get
            Set(ByVal Value As String)
                _faxNo = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property JRCTrailer() As String
            Get
                Return _jRCTrailer
            End Get
            Set(ByVal Value As String)
                _jRCTrailer = Value
            End Set
        End Property

        Public Property BStatus() As String
            Get
                Return _bStatus
            End Get
            Set(ByVal Value As String)
                _bStatus = Value
            End Set
        End Property

        Public Property ThirdPartyOK() As String
            Get
                Return _thirdPartyOK
            End Get
            Set(ByVal Value As String)
                _thirdPartyOK = Value
            End Set
        End Property

        Public Property TPPct() As Double
            Get
                Return _tPPct
            End Get
            Set(ByVal Value As Double)
                _tPPct = Value
            End Set
        End Property

        Public Property TPAmt() As Double
            Get
                Return _tPAmt
            End Get
            Set(ByVal Value As Double)
                _tPAmt = Value
            End Set
        End Property

        Public Property ViewOrder() As Integer
            Get
                Return _ViewOrder
            End Get
            Set(ByVal Value As Integer)
                _ViewOrder = Value
            End Set
        End Property

        'Audit Control
        Public Property UpdatedByUserId() As Integer
            Get
                Return _UpdatedByUserId
            End Get
            Set(ByVal Value As Integer)
                _UpdatedByUserId = Value
            End Set
        End Property

        Public Property UpdatedByUser() As String
            Get
                Return _UpdatedByUser
            End Get
            Set(ByVal Value As String)
                _UpdatedByUser = Value
            End Set
        End Property

        Public Property UpdatedDate() As Date
            Get
                Return _UpdatedDate
            End Get
            Set(ByVal Value As Date)
                _UpdatedDate = Value
            End Set
        End Property

        Public Property CreatedByUserId() As Integer
            Get
                Return _CreatedByUserId
            End Get
            Set(ByVal Value As Integer)
                _CreatedByUserId = Value
            End Set
        End Property

        Public Property CreatedByUser() As String
            Get
                Return _CreatedByUser
            End Get
            Set(ByVal Value As String)
                _CreatedByUser = Value
            End Set
        End Property

        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property

#End Region

#Region " Optional IHydratable Implementation "

        Private Sub Fill(ByVal dr As IDataReader) Implements IHydratable.Fill
            ''Following two Sections are created, so that those Items, which are not part of the Search may not be returned, in Try-Catch Block 
            _ItemId = Convert.ToInt32(Null.SetNull(dr("ItemID"), ItemId))
            _ModuleId = Convert.ToInt32(Null.SetNull(dr("ModuleID"), ModuleId))

            Try
                _brokerCode = Convert.ToString(Null.SetNull(dr("BrokerCode"), BrokerCode))
                _brokerName = Convert.ToString(Null.SetNull(dr("BrokerName"), BrokerName))
                _addressLine1 = Convert.ToString(Null.SetNull(dr("AddressLine1"), AddressLine1))
                _addressLine2 = Convert.ToString(Null.SetNull(dr("AddressLine2"), AddressLine2))
                _city = Convert.ToString(Null.SetNull(dr("City"), City))
                _state = Convert.ToString(Null.SetNull(dr("State"), State))
                _zipCode = Convert.ToString(Null.SetNull(dr("ZipCode"), ZipCode))
                _phoneNo = Convert.ToString(Null.SetNull(dr("PhoneNo"), PhoneNo))
                _ext = Convert.ToString(Null.SetNull(dr("Ext"), Ext))
                _contactCode = Convert.ToString(Null.SetNull(dr("ContactCode"), ContactCode))
                _vendorRef = Convert.ToString(Null.SetNull(dr("VendorRef"), VendorRef))
                _countryCode = Convert.ToString(Null.SetNull(dr("CountryCode"), CountryCode))
                _emailAddress = Convert.ToString(Null.SetNull(dr("EmailAddress"), EmailAddress))
                _commRate = Convert.ToDouble(Null.SetNull(dr("CommRate"), CommRate))
                _adminExempt = Convert.ToString(Null.SetNull(dr("AdminExempt"), AdminExempt))
                _status = Convert.ToString(Null.SetNull(dr("Status"), Status))
                _loadType = Convert.ToString(Null.SetNull(dr("LoadType"), LoadType))
                _favorite = Convert.ToString(Null.SetNull(dr("Favorite"), Favorite))
                _sortSeq = Convert.ToString(Null.SetNull(dr("SortSeq"), SortSeq))
                _brokerNotes = Convert.ToString(Null.SetNull(dr("BrokerNotes"), BrokerNotes))
                _bkrType = Convert.ToString(Null.SetNull(dr("BkrType"), BkrType))
                _corpUpd = Convert.ToDateTime(Null.SetNull(dr("CorpUpd"), CorpUpd))
                _faxNo = Convert.ToString(Null.SetNull(dr("FaxNo"), FaxNo))
                _jRCTrailer = Convert.ToString(Null.SetNull(dr("JRCTrailer"), JRCTrailer))
                _bStatus = Convert.ToString(Null.SetNull(dr("BStatus"), BStatus))
                _thirdPartyOK = Convert.ToString(Null.SetNull(dr("ThirdPartyOK"), ThirdPartyOK))
                _tPPct = Convert.ToDouble(Null.SetNull(dr("TPPct"), TPPct))
                _tPAmt = Convert.ToDouble(Null.SetNull(dr("TPAmt"), TPAmt))

                ' //Insert the Actual Fields above 

                _ViewOrder = Convert.ToInt32(Null.SetNull(dr("ViewOrder"), ViewOrder))
                _UpdatedByUserId = Convert.ToInt32(Null.SetNull(dr("UpdatedByUserId"), UpdatedByUserId))
                _UpdatedByUser = Convert.ToString(Null.SetNull(dr("UpdatedByUser"), UpdatedByUser))
                _UpdatedDate = Convert.ToDateTime(Null.SetNull(dr("UpdatedDate"), UpdatedDate))
                _CreatedByUserId = Convert.ToInt32(Null.SetNull(dr("CreatedByUserId"), CreatedByUserId))
                _CreatedByUser = Convert.ToString(Null.SetNull(dr("CreatedByUser"), CreatedByUser))
                _CreatedDate = Convert.ToDateTime(Null.SetNull(dr("CreatedDate"), CreatedDate))
            Catch

            End Try
        End Sub

#End Region

    End Class

    Public Class BrokersController
        Implements Entities.Modules.ISearchable
        Implements Entities.Modules.IPortable

#Region " Public Methods "
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function

        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------
        Public Function AddBroker(ByVal objBroker As BrokerInfo) As Integer
            With objBroker
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddBroker", .ModuleId, GetNull(.BrokerCode), GetNull(.BrokerName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.ContactCode), GetNull(.VendorRef), GetNull(.CountryCode), GetNull(.EmailAddress), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.LoadType), GetNull(.Favorite), GetNull(.SortSeq), GetNull(.BrokerNotes), GetNull(.BkrType), GetNull(.CorpUpd), GetNull(.Division), GetNull(.FaxNo), GetNull(.JRCTrailer), GetNull(.BStatus), GetNull(.ThirdPartyOK), GetNull(.TPPct), GetNull(.TPAmt), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateBroker(ByVal objBroker As BrokerInfo)
            With objBroker
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateBroker", .ItemId, GetNull(.BrokerCode), GetNull(.BrokerName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.ContactCode), GetNull(.VendorRef), GetNull(.CountryCode), GetNull(.EmailAddress), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.LoadType), GetNull(.Favorite), GetNull(.SortSeq), GetNull(.BrokerNotes), GetNull(.BkrType), GetNull(.CorpUpd), GetNull(.Division), GetNull(.FaxNo), GetNull(.JRCTrailer), GetNull(.BStatus), GetNull(.ThirdPartyOK), GetNull(.TPPct), GetNull(.TPAmt), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub DeleteBroker(ByVal objBroker As BrokerInfo)
            DeleteBroker(objBroker.ItemId)
        End Sub

        Public Sub DeleteBroker(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteBroker", ItemID)
        End Sub

        Public Sub FixBrokers(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixBrokers", ModuleID, UpdatedByUserId)
        End Sub


        Public Sub SortBrokers(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortBrokers", ModuleID)
        End Sub

        Public Function IsUniqueVendorRef(ByVal VendorRef As String) As Boolean
            Return GetBrokerIdByVendorRef(VendorRef) < 1
        End Function

        Public Function GetBrokerIdByVendorRef(ByVal VendorRef As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetBrokerIdByVendorRef", VendorRef))
        End Function

        Public Function IsUniqueCode(ByVal BrokerCode As String) As Boolean
            Return GetBrokerId(BrokerCode) < 1
        End Function

        Public Function GetBrokerId(ByVal BrokerCode As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetBrokerId", BrokerCode))
        End Function

        Public Function GetBroker(ByVal ItemID As Integer) As BrokerInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetBroker", ItemID), GetType(BrokerInfo)), BrokerInfo)
            Return CBO.FillObject(Of BrokerInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetBroker", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetBrokers(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetBrokersCommons(SearchText, StateCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetBrokersCommons(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If (SearchText <> "") OrElse (StateCode <> "") Then
                Return GetSearchedBrokers(SearchText, StateCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleBrokers(ModuleId, NoOfItems)
                        Else
                            Return GetAllBrokers(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalBrokers(PortalId, NoOfItems)
                        Else
                            Return GetAllBrokers(NoOfItems)
                        End If
                    Case 2
                        Return GetAllBrokers(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalBrokers(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleBrokers(ModuleId, NoOfItems)
                        Else
                            Return GetAllBrokers(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleBrokers(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleBrokers", ModuleId, NoOfItems), GetType(BrokerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleBrokers", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalBrokers(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalBrokers", PortalId, NoOfItems), GetType(BrokerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalBrokers", PortalId, NoOfItems)
        End Function

        Public Function GetAllBrokers(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllBrokers", NoOfItems), GetType(BrokerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllBrokers", NoOfItems)
        End Function

        Public Function GetSearchedBrokers(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleBrokers(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalBrokers(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalBrokers(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleBrokers(ModuleId)
                    End If
            End Select

            Dim strSearchText As String
            ' If StartsWith AndAlso (SearchOn.ToUpper <> "STATE") Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Dim DateFilter As String = ""
            Dim DateTo As Date = Now
            If ToDate <> "" Then
                Try
                    DateTo = Date.Parse(ToDate)
                Catch
                    DateTo = Now
                End Try
            End If
            Dim DateFrom As Date = #1/1/1947#
            If FromDate <> "" Then
                Try
                    DateFrom = Date.Parse(FromDate)
                Catch
                    DateFrom = #1/1/1947#
                End Try
            End If

            If DateFrom > DateTo Then
                Dim tDate As Date = DateFrom
                DateFrom = DateTo
                DateTo = tDate
            End If

            If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")
            ' MySqlString &= "x.* ")
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.ModuleId, ")
            sbSql.Append("x.BrokerName, ")
            sbSql.Append("x.BrokerCode, ")
            sbSql.Append("x.Status, ")
            sbSql.Append("x.BStatus, ")

            sbSql.Append("x.BkrType, ")
            sbSql.Append("x.PhoneNo, ")
            sbSql.Append("x.FaxNo, ")
            sbSql.Append("x.EmailAddress, ")

            sbSql.Append("x.City, ")
            sbSql.Append("x.State, ")
            sbSql.Append("x.VendorRef ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x ")

            sbSql.Append("WHERE (x.State LIKE '%" & StateCode & "%') ")

            Select Case SearchOn.ToUpper
                Case "BROKERNAME", "BROKERCODE", "STATE"
                    sbSql.Append("AND (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("AND ((x.BrokerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.BrokerCode LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x.BrokerName, x.ViewOrder, x.UpdatedDate desc ")

            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(BrokerInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        Public Function GetStateCodes() As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetStateCodes")
        End Function

#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            'Dim Brokers As ArrayList = GetModuleBrokers(ModInfo.ModuleID)
            Dim Brokers As List(Of BrokerInfo) = CBO.FillCollection(Of BrokerInfo)(GetModuleBrokers(ModInfo.ModuleID))
            Dim objBroker As Object
            For Each objBroker In Brokers
                Dim SearchItem As SearchItemInfo
                With CType(objBroker, BrokerInfo)
                    '
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.BrokerName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.BrokerName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .BrokerName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<Brokers>"

            'Export each Broker Details
            'Dim arrBrokers As ArrayList = GetModuleBrokers(ModuleID)
            Dim arrBrokers As List(Of BrokerInfo) = CBO.FillCollection(Of BrokerInfo)(GetModuleBrokers(ModuleID))
            If arrBrokers.Count <> 0 Then
                Dim objBroker As BrokerInfo
                For Each objBroker In arrBrokers
                    With objBroker
                        strXML += "<Broker>"

                        strXML &= "<BrokerCode>" & XMLEncode(.BrokerCode) & "</BrokerCode>"
                        strXML &= "<BrokerName>" & XMLEncode(.BrokerName) & "</BrokerName>"
                        strXML &= "<AddressLine1>" & XMLEncode(.AddressLine1) & "</AddressLine1>"
                        strXML &= "<AddressLine2>" & XMLEncode(.AddressLine2) & "</AddressLine2>"
                        strXML &= "<City>" & XMLEncode(.City) & "</City>"
                        strXML &= "<State>" & XMLEncode(.State) & "</State>"
                        strXML &= "<ZipCode>" & XMLEncode(.ZipCode) & "</ZipCode>"
                        strXML &= "<PhoneNo>" & XMLEncode(.PhoneNo) & "</PhoneNo>"
                        strXML &= "<Ext>" & XMLEncode(.Ext) & "</Ext>"
                        strXML &= "<ContactCode>" & XMLEncode(.ContactCode) & "</ContactCode>"
                        strXML &= "<VendorRef>" & XMLEncode(.VendorRef) & "</VendorRef>"
                        strXML &= "<CountryCode>" & XMLEncode(.CountryCode) & "</CountryCode>"
                        strXML &= "<EmailAddress>" & XMLEncode(.EmailAddress) & "</EmailAddress>"
                        strXML &= "<CommRate>" & XMLEncode(.CommRate.ToString) & "</CommRate>"
                        strXML &= "<AdminExempt>" & XMLEncode(.AdminExempt) & "</AdminExempt>"
                        strXML &= "<Status>" & XMLEncode(.Status) & "</Status>"
                        strXML &= "<LoadType>" & XMLEncode(.LoadType) & "</LoadType>"
                        strXML &= "<Favorite>" & XMLEncode(.Favorite) & "</Favorite>"
                        strXML &= "<SortSeq>" & XMLEncode(.SortSeq) & "</SortSeq>"
                        strXML &= "<BrokerNotes>" & XMLEncode(.BrokerNotes) & "</BrokerNotes>"
                        strXML &= "<BkrType>" & XMLEncode(.BkrType) & "</BkrType>"
                        strXML &= "<CorpUpd>" & XMLEncode(.CorpUpd.ToString) & "</CorpUpd>"
                        strXML &= "<Division>" & XMLEncode(.Division) & "</Division>"
                        strXML &= "<FaxNo>" & XMLEncode(.FaxNo) & "</FaxNo>"
                        strXML &= "<JRCTrailer>" & XMLEncode(.JRCTrailer) & "</JRCTrailer>"
                        strXML &= "<BStatus>" & XMLEncode(.BStatus) & "</BStatus>"
                        strXML &= "<ThirdPartyOK>" & XMLEncode(.ThirdPartyOK) & "</ThirdPartyOK>"
                        strXML &= "<TPPct>" & XMLEncode(.TPPct.ToString) & "</TPPct>"
                        strXML &= "<TPAmt>" & XMLEncode(.TPAmt.ToString) & "</TPAmt>"

                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</Broker>"
                    End With
                Next
            End If

            'Export the Module Settings
            Dim objOI As New OptionsInfo(ModuleID)
            With objOI
                'Control Options
                strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
                strXML += "<ViewControl>" & XMLEncode(.ViewControl) & "</ViewControl>"

                'Option1 Options
                strXML += "<PagerSize>" & XMLEncode(.PagerSize.ToString) & "</PagerSize>"

            End With

            strXML += "</Brokers>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlBrokers As System.Xml.XmlNode = GetContent(Content, "Brokers")

            'Import each Broker Details
            Dim xmlBroker As System.Xml.XmlNode
            For Each xmlBroker In xmlBrokers.SelectNodes("Broker")
                Dim objBroker As New BrokerInfo
                With objBroker
                    .ModuleId = ModuleID

                    Try
                        .BrokerCode = xmlBroker.Item("BrokerCode").InnerText
                    Catch
                    End Try
                    Try
                        .BrokerName = xmlBroker.Item("BrokerName").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine1 = xmlBroker.Item("AddressLine1").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine2 = xmlBroker.Item("AddressLine2").InnerText
                    Catch
                    End Try
                    Try
                        .City = xmlBroker.Item("City").InnerText
                    Catch
                    End Try
                    Try
                        .State = xmlBroker.Item("State").InnerText
                    Catch
                    End Try
                    Try
                        .ZipCode = xmlBroker.Item("ZipCode").InnerText
                    Catch
                    End Try
                    Try
                        .PhoneNo = xmlBroker.Item("PhoneNo").InnerText
                    Catch
                    End Try
                    Try
                        .Ext = xmlBroker.Item("Ext").InnerText
                    Catch
                    End Try
                    Try
                        .ContactCode = xmlBroker.Item("ContactCode").InnerText
                    Catch
                    End Try
                    Try
                        .VendorRef = xmlBroker.Item("VendorRef").InnerText
                    Catch
                    End Try
                    Try
                        .CountryCode = xmlBroker.Item("CountryCode").InnerText
                    Catch
                    End Try
                    Try
                        .EmailAddress = xmlBroker.Item("EmailAddress").InnerText
                    Catch
                    End Try
                    Try
                        .CommRate = Double.Parse(xmlBroker.Item("CommRate").InnerText)
                    Catch
                    End Try
                    Try
                        .AdminExempt = xmlBroker.Item("AdminExempt").InnerText
                    Catch
                    End Try
                    Try
                        .Status = xmlBroker.Item("Status").InnerText
                    Catch
                    End Try
                    Try
                        .LoadType = xmlBroker.Item("LoadType").InnerText
                    Catch
                    End Try
                    Try
                        .Favorite = xmlBroker.Item("Favorite").InnerText
                    Catch
                    End Try
                    Try
                        .SortSeq = xmlBroker.Item("SortSeq").InnerText
                    Catch
                    End Try
                    Try
                        .BrokerNotes = xmlBroker.Item("BrokerNotes").InnerText
                    Catch
                    End Try
                    Try
                        .BkrType = xmlBroker.Item("BkrType").InnerText
                    Catch
                    End Try
                    Try
                        .CorpUpd = Date.Parse(xmlBroker.Item("CorpUpd").InnerText)
                    Catch
                    End Try
                    Try
                        .Division = xmlBroker.Item("Division").InnerText
                    Catch
                    End Try
                    Try
                        .FaxNo = xmlBroker.Item("FaxNo").InnerText
                    Catch
                    End Try
                    Try
                        .JRCTrailer = xmlBroker.Item("JRCTrailer").InnerText
                    Catch
                    End Try
                    Try
                        .BStatus = xmlBroker.Item("BStatus").InnerText
                    Catch
                    End Try
                    Try
                        .ThirdPartyOK = xmlBroker.Item("ThirdPartyOK").InnerText
                    Catch
                    End Try
                    Try
                        .TPPct = Double.Parse(xmlBroker.Item("TPPct").InnerText)
                    Catch
                    End Try
                    Try
                        .TPAmt = Double.Parse(xmlBroker.Item("TPAmt").InnerText)
                    Catch
                    End Try

                    Try
                        .ViewOrder = Integer.Parse(xmlBroker.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddBroker(objBroker)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlBrokers.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlBrokers.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlBrokers.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'BrokersController


End Namespace
