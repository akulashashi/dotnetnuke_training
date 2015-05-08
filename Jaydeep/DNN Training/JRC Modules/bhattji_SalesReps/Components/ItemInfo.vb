Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.SalesReps.Business

    Public Class SalesRepInfo
        Implements IHydratable
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _repNo As String
        Private _repName As String
        Private _repRate As Decimal
        Private _repDollar As Decimal

        Private _SecPinA As Integer
        Private _SecPinB As Integer

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

        Public Property RepRate() As Decimal
            Get
                Return _repRate
            End Get
            Set(ByVal Value As Decimal)
                _repRate = Value
            End Set
        End Property

        Public Property RepDollar() As Decimal
            Get
                Return _repDollar
            End Get
            Set(ByVal Value As Decimal)
                _repDollar = Value
            End Set
        End Property

        Public Property SecPinA() As Integer
            Get
                Return _SecPinA
            End Get
            Set(ByVal Value As Integer)
                _SecPinA = Value
            End Set
        End Property

        Public Property SecPinB() As Integer
            Get
                Return _SecPinB
            End Get
            Set(ByVal Value As Integer)
                _SecPinB = Value
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
                'Insert the Actual Fields Below 

                _repNo = Convert.ToString(Null.SetNull(dr("RepNo"), RepNo))
                _repName = Convert.ToString(Null.SetNull(dr("RepName"), RepName))
                _repRate = Convert.ToDecimal(Null.SetNull(dr("RepRate"), RepRate))
                _repDollar = Convert.ToDecimal(Null.SetNull(dr("RepDollar"), RepDollar))

                _SecPinA = Convert.ToInt32(Null.SetNull(dr("SecPinA"), SecPinA))
                _SecPinB = Convert.ToInt32(Null.SetNull(dr("SecPinB"), SecPinB))

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

    Public Class SalesRepsController
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
        Public Function AddSalesRep(ByVal objSalesRep As SalesRepInfo) As Integer
            With objSalesRep
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddSalesRep", .ModuleId, GetNull(.RepNo), GetNull(.RepName), GetNull(.RepRate), GetNull(.RepDollar), GetNull(.SecPinA), GetNull(.SecPinB), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateSalesRep(ByVal objSalesRep As SalesRepInfo)
            With objSalesRep
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateSalesRep", .ItemId, GetNull(.RepNo), GetNull(.RepName), GetNull(.RepRate), GetNull(.RepDollar), GetNull(.SecPinA), GetNull(.SecPinB), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub DeleteSalesRep(ByVal objSalesRep As SalesRepInfo)
            DeleteSalesRep(objSalesRep.ItemId)
        End Sub

        Public Sub DeleteSalesRep(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteSalesRep", ItemID)
        End Sub

        Public Sub FixSalesReps(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixSalesReps", ModuleID, UpdatedByUserId)
        End Sub

        Public Sub SortSalesReps(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortSalesReps", ModuleID)
        End Sub

        Public Function IsUniqueCode(ByVal RepNo As String) As Boolean
            Return GetSalesRepId(RepNo) < 1
        End Function

        Public Function GetSalesRepId(ByVal RepNo As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesRepId", RepNo))
        End Function

        Public Function GetSalesRepByRepNo(ByVal RepNo As String) As SalesRepInfo
            Return GetSalesRep(GetSalesRepId(RepNo))
        End Function
        Public Function GetSalesRep(ByVal ItemID As Integer) As SalesRepInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRep", ItemID), GetType(SalesRepInfo)), SalesRepInfo)
            Return CBO.FillObject(Of SalesRepInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetSalesRep", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetSalesReps(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetSalesRepsCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetSalesRepsCommons(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If SearchText <> "" Then
                Return GetSearchedSalesReps(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleSalesReps(ModuleId, NoOfItems)
                        Else
                            Return GetAllSalesReps(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalSalesReps(PortalId, NoOfItems)
                        Else
                            Return GetAllSalesReps(NoOfItems)
                        End If
                    Case 2
                        Return GetAllSalesReps(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalSalesReps(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleSalesReps(ModuleId, NoOfItems)
                        Else
                            Return GetAllSalesReps(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleSalesReps(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesReps", ModuleId, NoOfItems), GetType(SalesRepInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesReps", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalSalesReps(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesReps", PortalId, NoOfItems), GetType(SalesRepInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesReps", PortalId, NoOfItems)
        End Function

        Public Function GetAllSalesReps(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesReps", NoOfItems), GetType(SalesRepInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesReps", NoOfItems)
        End Function

        Public Function GetSearchedSalesReps(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleSalesReps(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalSalesReps(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalSalesReps(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleSalesReps(ModuleId)
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
            ' MySqlString &= "x.* "
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.ModuleId, ")
            sbSql.Append("x.RepName, ")
            sbSql.Append("x.RepNo, ")
            sbSql.Append("x.RepRate, ")
            sbSql.Append("x.RepDollar ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_SalesRepMasterfile AS x ")


            Select Case SearchOn.ToUpper
                Case "REPNAME", "REPNO"
                    sbSql.Append("WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("WHERE ((x.RepName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.RepNo LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x.RepName, x.ViewOrder, x.UpdatedDate desc ")

            End Select


            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(SalesRepInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function


#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            Dim lotSalesReps As List(Of SalesRepInfo) = CBO.FillCollection(Of SalesRepInfo)(GetModuleSalesReps(ModInfo.ModuleID))

            Dim objSalesRep As Object
            For Each objSalesRep In lotSalesReps
                Dim SearchItem As SearchItemInfo
                With CType(objSalesRep, SalesRepInfo)
                    '
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.RepName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.RepName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .RepName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<SalesReps>"

            'Export each SalesRep Details
            Dim lotSalesReps As List(Of SalesRepInfo) = CBO.FillCollection(Of SalesRepInfo)(GetModuleSalesReps(ModuleID))

            If lotSalesReps.Count <> 0 Then
                Dim objSalesRep As SalesRepInfo
                For Each objSalesRep In lotSalesReps
                    With objSalesRep
                        strXML += "<SalesRep>"

                        strXML += "<RepNo>" & XMLEncode(.RepNo.ToString) & "</RepNo>"
                        strXML += "<RepName>" & XMLEncode(.RepName.ToString) & "</RepName>"
                        strXML += "<RepRate>" & XMLEncode(.RepRate.ToString) & "</RepRate>"
                        strXML += "<RepDollar>" & XMLEncode(.RepDollar.ToString) & "</RepDollar>"

                        strXML += "<SecPinA>" & XMLEncode(.SecPinA.ToString) & "</SecPinA>"
                        strXML += "<SecPinB>" & XMLEncode(.SecPinB.ToString) & "</SecPinB>"

                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</SalesRep>"
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

            strXML += "</SalesReps>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlSalesReps As System.Xml.XmlNode = GetContent(Content, "SalesReps")

            'Import each SalesRep Details
            Dim xmlSalesRep As System.Xml.XmlNode
            For Each xmlSalesRep In xmlSalesReps.SelectNodes("SalesRep")
                Dim objSalesRep As New SalesRepInfo
                With objSalesRep
                    .ModuleId = ModuleID

                    .RepNo = xmlSalesRep.Item("RepNo").InnerText
                    .RepName = xmlSalesRep.Item("RepName").InnerText
                    Try
                        .RepRate = Decimal.Parse(xmlSalesRep.Item("RepRate").InnerText)
                    Catch
                    End Try
                    Try
                        .RepDollar = Decimal.Parse(xmlSalesRep.Item("RepDollar").InnerText)
                    Catch
                    End Try

                    Try
                        .SecPinA = Integer.Parse(xmlSalesRep.Item("SecPinA").InnerText)
                    Catch
                    End Try
                    Try
                        .SecPinB = Integer.Parse(xmlSalesRep.Item("SecPinB").InnerText)
                    Catch
                    End Try

                    Try
                        .ViewOrder = Integer.Parse(xmlSalesRep.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddSalesRep(objSalesRep)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlSalesReps.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlSalesReps.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlSalesReps.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'SalesRepsController


End Namespace
