Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.Dispatchs.Business

    Public Class DispatchInfo
        Implements IHydratable
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _dispatchCode As String
        Private _dispatchName As String
        Private _office As String
        Private _OfficeOverride As String
        Private _ManagerOverride As String

        Private _IOName As String
        Private _commRate As Double
        Private _defDisp As String
        Private _dispPassw As String
        Private _status As String
        Private _offLogNo As String
        Private _dOffLogNo As String
        Private _allowXM As String
        Private _logonLink As String
        Private _logDate As DateTime
        Private _logTime As DateTime
        Private _clearCode As String
        Private _whatProcess As String
        Private _xMProc As String


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

        Public Property DispatchCode() As String
            Get
                Return _dispatchCode
            End Get
            Set(ByVal Value As String)
                _dispatchCode = Value
            End Set
        End Property

        Public Property DispatchName() As String
            Get
                Return _dispatchName
            End Get
            Set(ByVal Value As String)
                _dispatchName = Value
            End Set
        End Property

        Public Property Office() As String
            Get
                Return _office
            End Get
            Set(ByVal Value As String)
                _office = Value
            End Set
        End Property

        Public Property OfficeOverride() As String
            Get
                Return _OfficeOverride
            End Get
            Set(ByVal Value As String)
                _OfficeOverride = Value
            End Set
        End Property

        Public Property ManagerOverride() As String
            Get
                Return _ManagerOverride
            End Get
            Set(ByVal Value As String)
                _ManagerOverride = Value
            End Set
        End Property

        Public Property IOName() As String
            Get
                Return _IOName
            End Get
            Set(ByVal Value As String)
                _IOName = Value
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

        Public Property DefDisp() As String
            Get
                Return _defDisp
            End Get
            Set(ByVal Value As String)
                _defDisp = Value
            End Set
        End Property

        Public Property DispPassw() As String
            Get
                Return _dispPassw
            End Get
            Set(ByVal Value As String)
                _dispPassw = Value
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

        Public Property OffLogNo() As String
            Get
                Return _offLogNo
            End Get
            Set(ByVal Value As String)
                _offLogNo = Value
            End Set
        End Property

        Public Property DOffLogNo() As String
            Get
                Return _dOffLogNo
            End Get
            Set(ByVal Value As String)
                _dOffLogNo = Value
            End Set
        End Property

        Public Property AllowXM() As String
            Get
                Return _allowXM
            End Get
            Set(ByVal Value As String)
                _allowXM = Value
            End Set
        End Property

        Public Property LogonLink() As String
            Get
                Return _logonLink
            End Get
            Set(ByVal Value As String)
                _logonLink = Value
            End Set
        End Property

        Public Property LogDate() As DateTime
            Get
                Return _logDate
            End Get
            Set(ByVal Value As DateTime)
                _logDate = Value
            End Set
        End Property

        Public Property LogTime() As DateTime
            Get
                Return _logTime
            End Get
            Set(ByVal Value As DateTime)
                _logTime = Value
            End Set
        End Property

        Public Property ClearCode() As String
            Get
                Return _clearCode
            End Get
            Set(ByVal Value As String)
                _clearCode = Value
            End Set
        End Property

        Public Property WhatProcess() As String
            Get
                Return _whatProcess
            End Get
            Set(ByVal Value As String)
                _whatProcess = Value
            End Set
        End Property

        Public Property XMProc() As String
            Get
                Return _xMProc
            End Get
            Set(ByVal Value As String)
                _xMProc = Value
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
                
                '_ActualFields = Convert.ToString()(Null.SetNull(dr["ActualFields"], ActualFields)); 

                _dispatchCode = Convert.ToString(Null.SetNull(dr("DispatchCode"), DispatchCode))
                _dispatchName = Convert.ToString(Null.SetNull(dr("DispatchName"), DispatchName))
                _office = Convert.ToString(Null.SetNull(dr("Office"), Office))
                _OfficeOverride = Convert.ToString(Null.SetNull(dr("OfficeOverride"), OfficeOverride))
                _ManagerOverride = Convert.ToString(Null.SetNull(dr("ManagerOverride"), ManagerOverride))
                _commRate = Convert.ToDouble(Null.SetNull(dr("CommRate"), CommRate))
                _defDisp = Convert.ToString(Null.SetNull(dr("DefDisp"), DefDisp))
                _dispPassw = Convert.ToString(Null.SetNull(dr("DispPassw"), DispPassw))
                _status = Convert.ToString(Null.SetNull(dr("Status"), Status))
                _offLogNo = Convert.ToString(Null.SetNull(dr("OffLogNo"), OffLogNo))
                _dOffLogNo = Convert.ToString(Null.SetNull(dr("DOffLogNo"), DOffLogNo))
                _allowXM = Convert.ToString(Null.SetNull(dr("AllowXM"), AllowXM))
                _logonLink = Convert.ToString(Null.SetNull(dr("LogonLink"), LogonLink))
                _logDate = Convert.ToDateTime(Null.SetNull(dr("LogDate"), LogDate))
                _logTime = Convert.ToDateTime(Null.SetNull(dr("LogTime"), LogTime))
                _clearCode = Convert.ToString(Null.SetNull(dr("ClearCode"), ClearCode))
                _whatProcess = Convert.ToString(Null.SetNull(dr("WhatProcess"), WhatProcess))
                _xMProc = Convert.ToString(Null.SetNull(dr("_XMProc"), XMProc))


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

    Public Class DispatchsController
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
        Public Function AddDispatch(ByVal objDispatch As DispatchInfo) As Integer
            With objDispatch
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddDispatch", .ModuleId, GetNull(.DispatchCode), GetNull(.DispatchName), GetNull(.Office), GetNull(.OfficeOverride), GetNull(.ManagerOverride), GetNull(.CommRate), GetNull(.DefDisp), GetNull(.DispPassw), GetNull(.Status), GetNull(.OffLogNo), GetNull(.DOffLogNo), GetNull(.AllowXM), GetNull(.LogonLink), GetNull(.LogDate), GetNull(.LogTime), GetNull(.ClearCode), GetNull(.WhatProcess), GetNull(.XMProc), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateDispatch(ByVal objDispatch As DispatchInfo)
            With objDispatch
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateDispatch", .ItemId, GetNull(.DispatchCode), GetNull(.DispatchName), GetNull(.Office), GetNull(.OfficeOverride), GetNull(.ManagerOverride), GetNull(.CommRate), GetNull(.DefDisp), GetNull(.DispPassw), GetNull(.Status), GetNull(.OffLogNo), GetNull(.DOffLogNo), GetNull(.AllowXM), GetNull(.LogonLink), GetNull(.LogDate), GetNull(.LogTime), GetNull(.ClearCode), GetNull(.WhatProcess), GetNull(.XMProc), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub DeleteDispatch(ByVal objDispatch As DispatchInfo)
            DeleteDispatch(objDispatch.ItemId)
        End Sub

        Public Sub DeleteDispatch(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteDispatch", ItemID)
        End Sub

        Public Sub FixDispatchs(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixDispatchs", ModuleID, UpdatedByUserId)
        End Sub


        Public Sub SortDispatchs(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortDispatchs", ModuleID)
        End Sub

        Public Function IsUniqueCode(ByVal DispatchCode As String) As Boolean
            Return GetDispatcherId(DispatchCode) < 1
        End Function

        Public Function GetDispatcherId(ByVal DispatchCode As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetDispatcherId", DispatchCode))
        End Function

        Public Function GetDispatch(ByVal ItemID As Integer) As DispatchInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetDispatch", ItemID), GetType(DispatchInfo)), DispatchInfo)
            Return CBO.FillObject(Of DispatchInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetDispatch", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetDispatchs(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetDispatchsCommons(SearchText, JRCIOfficeCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetDispatchsCommons(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If (SearchText <> "") OrElse ((JRCIOfficeCode <> "000000000") AndAlso (JRCIOfficeCode <> "")) Then
                Return GetSearchedDispatchs(SearchText, JRCIOfficeCode, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleDispatchs(ModuleId, NoOfItems)
                        Else
                            Return GetAllDispatchs(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalDispatchs(PortalId, NoOfItems)
                        Else
                            Return GetAllDispatchs(NoOfItems)
                        End If
                    Case 2
                        Return GetAllDispatchs(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalDispatchs(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleDispatchs(ModuleId, NoOfItems)
                        Else
                            Return GetAllDispatchs(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleDispatchs(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleDispatchs", ModuleId, NoOfItems), GetType(DispatchInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleDispatchs", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalDispatchs(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalDispatchs", PortalId, NoOfItems), GetType(DispatchInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalDispatchs", PortalId, NoOfItems)
        End Function

        Public Function GetAllDispatchs(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllDispatchs", NoOfItems), GetType(DispatchInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllDispatchs", NoOfItems)
        End Function

        Public Function GetAllInterOffices(Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllInterOffices", NoOfItems)
        End Function

        Public Function GetSearchedDispatchs(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""
            Dim OfficeFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleDispatchs(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalDispatchs(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalDispatchs(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleDispatchs(ModuleId)
                    End If
            End Select

            If (JRCIOfficeCode <> "") AndAlso (JRCIOfficeCode <> "000000000") Then
                OfficeFilter = "AND (x.Office = '" & JRCIOfficeCode & "') "
            End If

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
            sbSql.Append("x.ModuleId, ")
            sbSql.Append("x.DispatchCode, ")
            sbSql.Append("x.DispatchName, ")
            sbSql.Append("x.Office, ")
            sbSql.Append("io.IOName, ")

            sbSql.Append("x.OfficeOverride, ")
            sbSql.Append("x.ManagerOverride, ")

            sbSql.Append("x.CommRate ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_DispatchMasterfile AS x ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io on x.Office = io.JRCIOfficeCode ")


            Select Case SearchOn.ToUpper
                Case "DISPATCHNAME", "DISPATCHCODE"
                    sbSql.Append("WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append(OfficeFilter)
                    'MySqlString &= "ORDER BY x.Office, x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc "
                    sbSql.Append("ORDER BY x.DispatchName, x.Office, x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("WHERE ((x.DispatchName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.DispatchCode LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append(OfficeFilter)
                    sbSql.Append("ORDER BY x.DispatchName, x.Office, x.ViewOrder, x.UpdatedDate desc ")

            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(DispatchInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function


#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            'Dim Dispatchs As ArrayList = GetDispatchs(ModInfo.ModuleID)
            Dim Dispatchs As List(Of DispatchInfo) = CBO.FillCollection(Of DispatchInfo)(GetModuleDispatchs(ModInfo.ModuleID))
            Dim objDispatch As Object
            For Each objDispatch In Dispatchs
                Dim SearchItem As SearchItemInfo
                With CType(objDispatch, DispatchInfo)
                    '
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.DispatchName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.DispatchName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .DispatchName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<Dispatchs>"

            'Export each Dispatch Details
            'Dim arrDispatchs As ArrayList = GetDispatchs(ModuleID)
            Dim arrDispatchs As List(Of DispatchInfo) = CBO.FillCollection(Of DispatchInfo)(GetModuleDispatchs(ModuleID))
            If arrDispatchs.Count <> 0 Then
                Dim objDispatch As DispatchInfo
                For Each objDispatch In arrDispatchs
                    With objDispatch
                        strXML += "<Dispatch>"

                        strXML += "<DispatchCode>" & XMLEncode(.DispatchCode.ToString) & "</DispatchCode>"
                        strXML += "<DispatchName>" & XMLEncode(.DispatchName.ToString) & "</DispatchName>"
                        strXML += "<Office>" & XMLEncode(.Office.ToString) & "</Office>"
                        strXML += "<OfficeOverride>" & XMLEncode(.OfficeOverride.ToString) & "</OfficeOverride>"
                        strXML += "<ManagerOverride>" & XMLEncode(.ManagerOverride.ToString) & "</ManagerOverride>"
                        strXML += "<CommRate>" & XMLEncode(.CommRate.ToString) & "</CommRate>"
                        strXML += "<DefDisp>" & XMLEncode(.DefDisp.ToString) & "</DefDisp>"
                        strXML += "<DispPassw>" & XMLEncode(.DispPassw.ToString) & "</DispPassw>"
                        strXML += "<Status>" & XMLEncode(.Status.ToString) & "</Status>"
                        strXML += "<OffLogNo>" & XMLEncode(.OffLogNo.ToString) & "</OffLogNo>"
                        strXML += "<DOffLogNo>" & XMLEncode(.DOffLogNo.ToString) & "</DOffLogNo>"
                        strXML += "<AllowXM>" & XMLEncode(.AllowXM.ToString) & "</AllowXM>"
                        strXML += "<LogonLink>" & XMLEncode(.LogonLink.ToString) & "</LogonLink>"
                        strXML += "<LogDate>" & XMLEncode(.LogDate.ToString) & "</LogDate>"
                        strXML += "<LogTime>" & XMLEncode(.LogTime.ToString) & "</LogTime>"
                        strXML += "<ClearCode>" & XMLEncode(.ClearCode.ToString) & "</ClearCode>"
                        strXML += "<WhatProcess>" & XMLEncode(.WhatProcess.ToString) & "</WhatProcess>"
                        strXML += "<XMProc>" & XMLEncode(.XMProc.ToString) & "</XMProc>"


                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</Dispatch>"
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

            strXML += "</Dispatchs>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlDispatchs As System.Xml.XmlNode = GetContent(Content, "Dispatchs")

            'Import each Dispatch Details
            Dim xmlDispatch As System.Xml.XmlNode
            For Each xmlDispatch In xmlDispatchs.SelectNodes("Dispatch")
                Dim objDispatch As New DispatchInfo
                With objDispatch
                    .ModuleId = ModuleID

                    .DispatchCode = xmlDispatch.Item("DispatchCode").InnerText
                    .DispatchName = xmlDispatch.Item("DispatchName").InnerText
                    .Office = xmlDispatch.Item("Office").InnerText
                    .OfficeOverride = xmlDispatch.Item("OfficeOverride").InnerText
                    .ManagerOverride = xmlDispatch.Item("ManagerOverride").InnerText
                    Try
                        .CommRate = Double.Parse(xmlDispatch.Item("CommRate").InnerText)
                    Catch
                    End Try

                    .DefDisp = xmlDispatch.Item("DefDisp").InnerText
                    .DispPassw = xmlDispatch.Item("DispPassw").InnerText
                    .Status = xmlDispatch.Item("Status").InnerText
                    .OffLogNo = xmlDispatch.Item("OffLogNo").InnerText
                    .DOffLogNo = xmlDispatch.Item("DOffLogNo").InnerText
                    .AllowXM = xmlDispatch.Item("AllowXM").InnerText
                    .LogonLink = xmlDispatch.Item("LogonLink").InnerText
                    Try
                        .LogDate = Date.Parse(xmlDispatch.Item("LogDate").InnerText)
                    Catch
                    End Try
                    Try
                        .LogTime = Date.Parse(xmlDispatch.Item("LogTime").InnerText)
                    Catch
                    End Try

                    .ClearCode = xmlDispatch.Item("ClearCode").InnerText
                    .WhatProcess = xmlDispatch.Item("WhatProcess").InnerText
                    .XMProc = xmlDispatch.Item("XMProc").InnerText

                    Try
                        .ViewOrder = Integer.Parse(xmlDispatch.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddDispatch(objDispatch)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlDispatchs.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlDispatchs.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlDispatchs.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'DispatchsController


End Namespace
