Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.Customers.Business

    Public Class CustomerInfo
        Implements IHydratable

        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _customerNumber As String
        Private _customerName As String
        Private _addressLine1 As String
        Private _addressLine2 As String
        Private _addressLine3 As String
        Private _city As String
        Private _state As String
        Private _zipCode As String
        Private _phoneNumber As String
        Private _extension As String
        Private _faxNumber As String
        Private _contactCode As String
        Private _billingInfo As String
        Private _favor As String
        Private _repNo As String
        Private _repName As String
        Private _sortSeq As String
        Private _repDlr As Decimal
        Private _repPct As Decimal
        Private _cowner As String
        Private _corpUpd As DateTime
        Private _division As String
        Private _oldCustNo As String
        Private _gSMStatus As String
        Private _customerStatus As String
        Private _cStatus As String
        Private _mCNO As String
        Private _whoDoneIT As String

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

        Public Property CustomerNumber() As String
            Get
                Return _customerNumber
            End Get
            Set(ByVal Value As String)
                _customerNumber = Value
            End Set
        End Property

        Public Property CustomerName() As String
            Get
                Return _customerName
            End Get
            Set(ByVal Value As String)
                _customerName = Value
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

        Public Property AddressLine3() As String
            Get
                Return _addressLine3
            End Get
            Set(ByVal Value As String)
                _addressLine3 = Value
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

        Public Property PhoneNumber() As String
            Get
                Return _phoneNumber
            End Get
            Set(ByVal Value As String)
                _phoneNumber = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property Extension() As String
            Get
                Return _extension
            End Get
            Set(ByVal Value As String)
                _extension = Value
            End Set
        End Property

        Public Property FaxNumber() As String
            Get
                Return _faxNumber
            End Get
            Set(ByVal Value As String)
                _faxNumber = Phone.StripPhoneNo(Value)
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

        Public Property BillingInfo() As String
            Get
                Return _billingInfo
            End Get
            Set(ByVal Value As String)
                _billingInfo = Value
            End Set
        End Property

        Public Property Favor() As String
            Get
                Return _favor
            End Get
            Set(ByVal Value As String)
                _favor = Value
            End Set
        End Property

        Public Property RepNo() As String
            Get
                Return _repNo
            End Get
            Set(ByVal Value As String)
                _repNo = Value
            End Set
        End Property

        Public Property RepName() As String
            Get
                Return _repName
            End Get
            Set(ByVal Value As String)
                _repName = Value
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

        Public Property RepDlr() As Decimal
            Get
                Return _repDlr
            End Get
            Set(ByVal Value As Decimal)
                _repDlr = Value
            End Set
        End Property

        Public Property RepPct() As Decimal
            Get
                Return _repPct
            End Get
            Set(ByVal Value As Decimal)
                _repPct = Value
            End Set
        End Property

        Public Property Cowner() As String
            Get
                Return _cowner
            End Get
            Set(ByVal Value As String)
                _cowner = Value
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

        Public Property OldCustNo() As String
            Get
                Return _oldCustNo
            End Get
            Set(ByVal Value As String)
                _oldCustNo = Value
            End Set
        End Property

        Public Property GSMStatus() As String
            Get
                Return _gSMStatus
            End Get
            Set(ByVal Value As String)
                _gSMStatus = Value
            End Set
        End Property

        Public Property CustomerStatus() As String
            Get
                Return _customerStatus
            End Get
            Set(ByVal Value As String)
                _customerStatus = Value
            End Set
        End Property

        Public Property CStatus() As String
            Get
                Return _cStatus
            End Get
            Set(ByVal Value As String)
                _cStatus = Value
            End Set
        End Property

        Public Property MCNO() As String
            Get
                Return _mCNO
            End Get
            Set(ByVal Value As String)
                _mCNO = Value
            End Set
        End Property

        Public Property WhoDoneIT() As String
            Get
                Return _whoDoneIT
            End Get
            Set(ByVal Value As String)
                _whoDoneIT = Value
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

                _customerNumber = Convert.ToString(Null.SetNull(dr("CustomerNumber"), CustomerNumber))
                _customerName = Convert.ToString(Null.SetNull(dr("CustomerName"), CustomerName))
                _addressLine1 = Convert.ToString(Null.SetNull(dr("AddressLine1"), AddressLine1))
                _addressLine2 = Convert.ToString(Null.SetNull(dr("AddressLine2"), AddressLine2))
                _addressLine3 = Convert.ToString(Null.SetNull(dr("AddressLine3"), AddressLine3))
                _city = Convert.ToString(Null.SetNull(dr("City"), City))
                _state = Convert.ToString(Null.SetNull(dr("State"), State))
                _zipCode = Convert.ToString(Null.SetNull(dr("ZipCode"), ZipCode))
                _phoneNumber = Convert.ToString(Null.SetNull(dr("PhoneNumber"), PhoneNumber))
                _extension = Convert.ToString(Null.SetNull(dr("Extension"), Extension))
                _faxNumber = Convert.ToString(Null.SetNull(dr("FaxNumber"), FaxNumber))
                _contactCode = Convert.ToString(Null.SetNull(dr("ContactCode"), ContactCode))
                _billingInfo = Convert.ToString(Null.SetNull(dr("BillingInfo"), BillingInfo))
                _favor = Convert.ToString(Null.SetNull(dr("Favor"), Favor))
                _repNo = Convert.ToString(Null.SetNull(dr("RepNo"), RepNo))
                _repName = Convert.ToString(Null.SetNull(dr("RepName"), RepName))
                _sortSeq = Convert.ToString(Null.SetNull(dr("SortSeq"), SortSeq))
                _repDlr = Convert.ToDecimal(Null.SetNull(dr("RepDlr"), RepDlr))
                _repPct = Convert.ToDecimal(Null.SetNull(dr("RepPct"), RepPct))
                _cowner = Convert.ToString(Null.SetNull(dr("Cowner"), Cowner))
                _corpUpd = Convert.ToDateTime(Null.SetNull(dr("CorpUpd"), CorpUpd))
                _division = Convert.ToString(Null.SetNull(dr("Division"), Division))
                _oldCustNo = Convert.ToString(Null.SetNull(dr("OldCustNo"), OldCustNo))
                _gSMStatus = Convert.ToString(Null.SetNull(dr("GSMStatus"), GSMStatus))
                _customerStatus = Convert.ToString(Null.SetNull(dr("CustomerStatus"), CustomerStatus))
                _cStatus = Convert.ToString(Null.SetNull(dr("CStatus"), CStatus))
                _mCNO = Convert.ToString(Null.SetNull(dr("MCNO"), MCNO))
                _whoDoneIT = Convert.ToString(Null.SetNull(dr("WhoDoneIT"), WhoDoneIT))

                'ActualFields = Convert.ToString()(Null.SetNull(dr["ActualFields"], ActualFields)); 

                'Insert the Actual Fields above 

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

    Public Class CustomersController
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
        Public Function AddCustomer(ByVal objCustomer As CustomerInfo) As Integer
            With objCustomer
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddCustomer", .ModuleId, GetNull(.CustomerNumber), GetNull(.CustomerName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.AddressLine3), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.PhoneNumber), GetNull(.Extension), GetNull(.FaxNumber), GetNull(.ContactCode), GetNull(.BillingInfo), GetNull(.Favor), GetNull(.RepNo), GetNull(.RepName), GetNull(.SortSeq), GetNull(.RepDlr), GetNull(.RepPct), GetNull(.Cowner), GetNull(.CorpUpd), GetNull(.Division), GetNull(.OldCustNo), GetNull(.GSMStatus), GetNull(.CustomerStatus), GetNull(.CStatus), GetNull(.MCNO), GetNull(.WhoDoneIT), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateCustomer(ByVal objCustomer As CustomerInfo)
            With objCustomer
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateCustomer", .ItemId, GetNull(.CustomerNumber), GetNull(.CustomerName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.AddressLine3), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.PhoneNumber), GetNull(.Extension), GetNull(.FaxNumber), GetNull(.ContactCode), GetNull(.BillingInfo), GetNull(.Favor), GetNull(.RepNo), GetNull(.RepName), GetNull(.SortSeq), GetNull(.RepDlr), GetNull(.RepPct), GetNull(.Cowner), GetNull(.CorpUpd), GetNull(.Division), GetNull(.OldCustNo), GetNull(.GSMStatus), GetNull(.CustomerStatus), GetNull(.CStatus), GetNull(.MCNO), GetNull(.WhoDoneIT), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub DeleteCustomer(ByVal objCustomer As CustomerInfo)
            DeleteCustomer(objCustomer.ItemId)
        End Sub

        Public Sub DeleteCustomer(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteCustomer", ItemID)
        End Sub

        Public Sub FixCustomers(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixCustomers", ModuleID, UpdatedByUserId)
        End Sub

        Public Sub SortCustomers(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortCustomers", ModuleID)
        End Sub

        Public Function IsUniqueCode(ByVal CustomerNumber As String) As Boolean
            Return GetCustomerId(CustomerNumber) < 1
        End Function

        Public Function GetCustomerId(ByVal CustomerNumber As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetCustomerId", CustomerNumber))
        End Function

        Public Function GetCustomer(ByVal ItemID As Integer) As CustomerInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetCustomer", ItemID), GetType(CustomerInfo)), CustomerInfo)
            Return CBO.FillObject(Of CustomerInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetCustomer", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetCustomers(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetCustomersCommons(SearchText, StateCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetCustomersCommons(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If (SearchText <> "") OrElse (StateCode <> "") Then
                Return GetSearchedCustomers(SearchText, StateCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleCustomers(ModuleId, NoOfItems)
                        Else
                            Return GetAllCustomers(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalCustomers(PortalId, NoOfItems)
                        Else
                            Return GetAllCustomers(NoOfItems)
                        End If
                    Case 2
                        Return GetAllCustomers(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalCustomers(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleCustomers(ModuleId, NoOfItems)
                        Else
                            Return GetAllCustomers(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleCustomers(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleCustomers", ModuleId, NoOfItems), GetType(CustomerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleCustomers", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalCustomers(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalCustomers", PortalId, NoOfItems), GetType(CustomerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalCustomers", PortalId, NoOfItems)
        End Function

        Public Function GetAllCustomers(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllCustomers", NoOfItems), GetType(CustomerInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllCustomers", NoOfItems)
        End Function

        Public Function GetSearchedCustomers(ByVal SearchText As String, Optional ByVal StateCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList 
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleCustomers(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalCustomers(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalCustomers(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleCustomers(ModuleId)
                    End If
            End Select

            Dim strSearchText As String
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
            sbSql.Append("x.CustomerName, ")
            sbSql.Append("x.CustomerNumber, ")

            sbSql.Append("x.RepNo, ")
            sbSql.Append("sr.RepName, ")
            sbSql.Append("x.RepPct, ")
            sbSql.Append("x.RepDlr, ")

            sbSql.Append("x.PhoneNumber, ")
            sbSql.Append("x.City, ")
            sbSql.Append("x.State ")

            sbSql.Append("FROM " & MyOjectQualifier & "AR1_CustomerMaster AS x ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesRepMasterfile AS sr on x.RepNo = sr.RepNo ")

            sbSql.Append("WHERE (x.State LIKE '%" & StateCode & "%') ")

            Select Case SearchOn.ToUpper
                Case "CUSTOMERNAME", "CUSTOMERNUMBER", "STATE"
                    sbSql.Append("AND (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("AND ((x.CustomerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.CustomerNumber LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x.CustomerName, x.ViewOrder, x.UpdatedDate desc ")

            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(CustomerInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        Public Function GetStateCodes() As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetStateCodes")
        End Function

        Public Function GetSalesRepId(ByVal RepNo As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesRepId", RepNo))
        End Function

        Public Function GetSalesRep(ByVal RepNo As String) As IDataReader
            Return GetSalesRep(GetSalesRepId(RepNo))
        End Function

        Public Function GetSalesRep(ByVal SalesRepId As Integer) As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetSalesRep", SalesRepId)
        End Function

        Public Function GetAllSalesReps(Optional ByVal NoOfItems As Integer = 1000) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllSalesReps", NoOfItems)
        End Function

        Public Function GetAllInterOffices(Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllInterOffices", NoOfItems)
        End Function

#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            'Dim Customers As ArrayList = GetCustomers(ModInfo.ModuleID)

            Dim Customers As List(Of CustomerInfo) = CBO.FillCollection(Of CustomerInfo)(GetModuleCustomers(ModInfo.ModuleID))

            Dim objCustomer As Object
            For Each objCustomer In Customers
                Dim SearchItem As SearchItemInfo
                With CType(objCustomer, CustomerInfo)
                    '
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.CustomerName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.CustomerName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .CustomerName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<Customers>"

            'Export each Customer Details
            'Dim arrCustomers As ArrayList = GetCustomers(ModuleID)
            Dim arrCustomers As List(Of CustomerInfo) = CBO.FillCollection(Of CustomerInfo)(GetModuleCustomers(ModuleID))
            If arrCustomers.Count <> 0 Then
                Dim objCustomer As CustomerInfo
                For Each objCustomer In arrCustomers
                    With objCustomer
                        strXML += "<Customer>"

                        strXML += "<customerNumber>" & XMLEncode(.CustomerNumber.ToString) & "</customerNumber>"
                        strXML += "<customerName>" & XMLEncode(.CustomerName.ToString) & "</customerName>"
                        strXML += "<addressLine1>" & XMLEncode(.AddressLine1.ToString) & "</addressLine1>"
                        strXML += "<addressLine2>" & XMLEncode(.AddressLine2.ToString) & "</addressLine2>"
                        strXML += "<addressLine3>" & XMLEncode(.AddressLine3.ToString) & "</addressLine3>"
                        strXML += "<city>" & XMLEncode(.City.ToString) & "</city>"
                        strXML += "<state>" & XMLEncode(.State.ToString) & "</state>"
                        strXML += "<zipCode>" & XMLEncode(.ZipCode.ToString) & "</zipCode>"
                        strXML += "<phoneNumber>" & XMLEncode(.PhoneNumber.ToString) & "</phoneNumber>"
                        strXML += "<extension>" & XMLEncode(.Extension.ToString) & "</extension>"
                        strXML += "<faxNumber>" & XMLEncode(.FaxNumber.ToString) & "</faxNumber>"
                        strXML += "<contactCode>" & XMLEncode(.ContactCode.ToString) & "</contactCode>"
                        strXML += "<billingInfo>" & XMLEncode(.BillingInfo.ToString) & "</billingInfo>"
                        strXML += "<favor>" & XMLEncode(.Favor.ToString) & "</favor>"
                        strXML += "<repNo>" & XMLEncode(.RepNo.ToString) & "</repNo>"
                        strXML += "<repName>" & XMLEncode(.RepName.ToString) & "</repName>"
                        strXML += "<sortSeq>" & XMLEncode(.SortSeq.ToString) & "</sortSeq>"
                        strXML += "<repDlr>" & XMLEncode(.RepDlr.ToString) & "</repDlr>"
                        strXML += "<repPct>" & XMLEncode(.RepPct.ToString) & "</repPct>"
                        strXML += "<cowner>" & XMLEncode(.Cowner.ToString) & "</cowner>"
                        strXML += "<corpUpd>" & XMLEncode(.CorpUpd.ToString) & "</corpUpd>"
                        strXML += "<division>" & XMLEncode(.Division.ToString) & "</division>"
                        strXML += "<oldCustNo>" & XMLEncode(.OldCustNo.ToString) & "</oldCustNo>"
                        strXML += "<gSMStatus>" & XMLEncode(.GSMStatus.ToString) & "</gSMStatus>"
                        strXML += "<customerStatus>" & XMLEncode(.CustomerStatus.ToString) & "</customerStatus>"
                        strXML += "<cStatus>" & XMLEncode(.CStatus.ToString) & "</cStatus>"
                        strXML += "<mCNO>" & XMLEncode(.MCNO.ToString) & "</mCNO>"
                        strXML += "<whoDoneIT>" & XMLEncode(.WhoDoneIT.ToString) & "</whoDoneIT>"

                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</Customer>"
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

            strXML += "</Customers>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlCustomers As System.Xml.XmlNode = GetContent(Content, "Customers")

            'Import each Customer Details
            Dim xmlCustomer As System.Xml.XmlNode
            For Each xmlCustomer In xmlCustomers.SelectNodes("Customer")
                Dim objCustomer As New CustomerInfo
                With objCustomer
                    .ModuleId = ModuleID
                    .CustomerNumber = xmlCustomer.Item("CustomerNumber").InnerText
                    .CustomerName = xmlCustomer.Item("CustomerName").InnerText
                    .AddressLine1 = xmlCustomer.Item("addressLine1").InnerText
                    .AddressLine2 = xmlCustomer.Item("addressLine2").InnerText
                    .AddressLine3 = xmlCustomer.Item("addressLine3").InnerText
                    .City = xmlCustomer.Item("city").InnerText
                    .State = xmlCustomer.Item("state").InnerText
                    .ZipCode = xmlCustomer.Item("zipCode").InnerText
                    .PhoneNumber = xmlCustomer.Item("phoneNumber").InnerText
                    .Extension = xmlCustomer.Item("extension").InnerText
                    .FaxNumber = xmlCustomer.Item("faxNumber").InnerText
                    .ContactCode = xmlCustomer.Item("contactCode").InnerText
                    .BillingInfo = xmlCustomer.Item("billingInfo").InnerText
                    .Favor = xmlCustomer.Item("favor").InnerText
                    .RepNo = xmlCustomer.Item("repNo").InnerText
                    .RepName = xmlCustomer.Item("repName").InnerText
                    .SortSeq = xmlCustomer.Item("sortSeq").InnerText
                    Try
                        .RepDlr = Decimal.Parse(xmlCustomer.Item("repDlr").InnerText)
                    Catch
                    End Try
                    Try
                        .RepPct = Decimal.Parse(xmlCustomer.Item("repPct").InnerText)
                    Catch
                    End Try

                    .Cowner = xmlCustomer.Item("cowner").InnerText
                    Try
                        .CorpUpd = Date.Parse(xmlCustomer.Item("corpUpd").InnerText)
                    Catch
                    End Try
                    .Division = xmlCustomer.Item("division").InnerText
                    .OldCustNo = xmlCustomer.Item("oldCustNo").InnerText.ToLower
                    .GSMStatus = xmlCustomer.Item("gSMStatus").InnerText
                    .CustomerStatus = xmlCustomer.Item("customerStatus").InnerText
                    .CStatus = xmlCustomer.Item("cStatus").InnerText
                    .MCNO = xmlCustomer.Item("mCNO").InnerText
                    .WhoDoneIT = xmlCustomer.Item("whoDoneIT").InnerText

                    Try
                        .ViewOrder = Integer.Parse(xmlCustomer.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddCustomer(objCustomer)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlCustomers.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlCustomers.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlCustomers.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'CustomersController


End Namespace
