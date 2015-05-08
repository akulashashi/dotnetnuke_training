Imports System
Imports System.Data

Namespace bhattji.Modules.LoadSheets.Business

    Public Class ZipCodeInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ZipCode As String
        Private _Area As String
        Private _City As String
        Private _StateCode As String
        Private _State As String
        Private _Display As String

#End Region

#Region " Properties "

        Public Property ItemId() As Integer
            Get
                Return _ItemId
            End Get
            Set(ByVal Value As Integer)
                _ItemId = Value
            End Set
        End Property

        Public Property ZipCode() As String
            Get
                Return _ZipCode
            End Get
            Set(ByVal Value As String)
                _ZipCode = Value

            End Set
        End Property

        Public Property Area() As String
            Get
                Return _Area
            End Get
            Set(ByVal Value As String)
                _Area = Value

            End Set
        End Property

        Public Property City() As String
            Get
                Return _City
            End Get
            Set(ByVal Value As String)
                _City = Value

            End Set
        End Property

        Public Property StateCode() As String
            Get
                Return _StateCode
            End Get
            Set(ByVal Value As String)
                _StateCode = Value

            End Set
        End Property

        Public Property State() As String
            Get
                Return _State
            End Get
            Set(ByVal Value As String)
                _State = Value

            End Set
        End Property

        Public Property Display() As String
            Get
                Return _Display
            End Get
            Set(ByVal Value As String)
                _Display = Value

            End Set
        End Property

#End Region

#Region " Constructors "

#End Region

    End Class

    Public Class ZipCodesController
        'Implements Entities.Modules.ISearchable
        'Implements Entities.Modules.IPortable

#Region " Public Methods "

        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

        Public Function AddZipCode(ByVal objZipCode As ZipCodeInfo) As Integer
            With objZipCode
                Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddZipCode", GetNull(.ZipCode), GetNull(.Area), GetNull(.City), GetNull(.State)))
            End With
        End Function

        Public Sub UpdateZipCode(ByVal objZipCode As ZipCodeInfo)
            With objZipCode
                DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UpdateZipCode", .ItemId, GetNull(.ZipCode), GetNull(.Area), GetNull(.City), GetNull(.State))
            End With
        End Sub

        Public Sub DeleteZipCode(ByVal objZipCode As ZipCodeInfo)
            DeleteZipCode(objZipCode.ItemId)
        End Sub

        Public Sub DeleteZipCode(ByVal ItemId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteZipCode", ItemId)
        End Sub


        Public Function GetZipCode(ByVal ItemId As Integer) As ZipCodeInfo
            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetZipCode", ItemId), GetType(ZipCodeInfo)), ZipCodeInfo)
        End Function


        Public Function GetZipCodes() As ArrayList
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetZipCodes"), GetType(ZipCodeInfo))
        End Function

        Public Function GetCityList(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Dim los As New List(Of String)
            Try
                Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetCityList", prefixText, count)
                If Not dr Is Nothing Then
                    While (dr.Read)
                        los.Add(dr("City").ToString())
                    End While
                End If
            Catch ex As Exception
                los.Add(ex.Message)
            End Try

            Return los
        End Function

        Public Function GetCityNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Dim los As New List(Of String)
            Try
                'Dim sql As String = "SELECT DISTINCT TOP 25  City " & _
                '                    "FROM bhattji_ZipCodes " & _
                '                    "WHERE City LIKE  '" & prefixText & "%' " & _
                '                    "ORDER BY City"

                'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sql)
                Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetCityNames", prefixText, count)
                If Not dr Is Nothing Then
                    While (dr.Read)
                        los.Add(dr("City").ToString() & " | " & dr("StateCode").ToString() & " | " & dr("ZipCode").ToString())
                    End While
                End If
            Catch ex As Exception
                los.Add(ex.Message)
            End Try

            Return los
        End Function

        Public Function GetCustomerNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Dim los As New List(Of String)
            Try
                Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetCustomerNames", prefixText, count)
                If Not dr Is Nothing Then
                    While (dr.Read)
                        los.Add(dr("CustomerName").ToString() & " | " & dr("CustomerNumber").ToString() & " | " & dr("City").ToString() & " | " & dr("State").ToString())
                    End While
                End If
            Catch ex As Exception
                los.Add(ex.Message)
            End Try

            Return los
        End Function

        Public Function GetBrokerNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Dim los As New List(Of String)
            Try
                Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetBrokerNames", prefixText, count)
                If Not dr Is Nothing Then
                    While (dr.Read)
                        los.Add(dr("BrokerName").ToString() & " | " & dr("BrokerCode").ToString() & " | " & dr("City").ToString() & " | " & dr("State").ToString())
                    End While
                End If
            Catch ex As Exception
                los.Add(ex.Message)
            End Try

            Return los
        End Function

        Public Function GetDriverNames(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As List(Of String)
            Dim los As New List(Of String)
            Try
                Dim Sql As String = "SELECT DISTINCT TOP " & count.ToString() & " " & _
                                    "DriverName " & _
                                    "FROM ARD_SalesPersonMasterfile " & _
                                    "WHERE (OfficeOwner='" & contextKey & "')" & _
                                    "AND (Status = 'N') " & _
                                    "AND ((DFirstName LIKE '" & prefixText & "%') OR (DLastName LIKE '" & prefixText & "%')) " & _
                                    "ORDER BY DriverName"

                Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(Sql)

                'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetDriverNames", prefixText, contextKey)
                If Not dr Is Nothing Then
                    While (dr.Read)
                        los.Add(dr("DriverName").ToString())
                    End While
                End If
            Catch ex As Exception
                los.Add(ex.Message)
            End Try

            Return los
        End Function

        Public Sub GetStateZipCodeByCity(ByVal City As String, ByRef StateCode As String, ByRef ZipCode As String)
            Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetStateZipCodeByCity", City)
            If (Not dr Is Nothing) AndAlso dr.Read() Then
                StateCode = dr("StateCode").ToString()
                ZipCode = dr("ZipCode").ToString()
            End If
        End Sub

        Public Function GetSearchedZipCodes(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal SearchState As String = "", Optional ByVal NoOfItems As Integer = 100) As ArrayList 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT TOP " & NoOfItems.ToString & " "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.ZipCode, "
            MySqlString &= "x.Area, "
            MySqlString &= "x.City, "
            MySqlString &= "x.StateCode, "
            MySqlString &= "sc.State, "
            MySqlString &= "'Display'=x.City + ', ' + x.StateCode + ' ' + x.ZipCode "

            MySqlString &= "FROM " & MyOjectQualifier & "bhattji_ZipCodes AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "bhattji_StateCodes AS sc ON x.StateCode=sc.StateCode "

            Select Case SearchOn.ToUpper
                Case "ZIPCODE"
                    MySqlString &= "WHERE (x.ZipCode LIKE '%" & SearchText & "%') "
                    MySqlString &= "ORDER BY x.ZipCode "

                Case "AREA"
                    MySqlString &= "WHERE (x.Area LIKE '" & SearchText & "%') "
                    MySqlString &= "ORDER BY x.Area, x.City "

                Case "CITY"
                    If SearchState = "" Then
                        MySqlString &= "WHERE (x.City LIKE '" & SearchText & "%') "
                        MySqlString &= "ORDER BY x.StateCode, x.City, x.Area "
                    Else
                        MySqlString &= "WHERE ((x.City LIKE '" & SearchText & "%') AND (x.StateCode LIKE '" & SearchState & "%')) "
                        MySqlString &= "ORDER BY x.City, x.Area "
                    End If

                Case "SATAE"
                    MySqlString &= "WHERE (sc.State LIKE '" & SearchText & "%') "
                    MySqlString &= "ORDER BY sc.State, x.City, x.Area "

                Case Else '"ANY"
                    MySqlString &= "WHERE (x.ZipCode LIKE '%" & SearchText & "%') "
                    MySqlString &= "OR (x.Area LIKE '" & SearchText & "%') "
                    MySqlString &= "OR (x.City LIKE '" & SearchText & "%') "
                    MySqlString &= "OR (sc.State LIKE '" & SearchText & "%') "
                    MySqlString &= "ORDER BY sc.State, x.City, x.Area "

            End Select


            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(ZipCodeInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

        End Function
#End Region

#Region " Optional Interfaces "

        'Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
        '    Dim SearchItemCollection As New SearchItemInfoCollection

        '    Dim ZipCodes As ArrayList = GetZipCodes(ModInfo.ModuleID)

        '    Dim objZipCode As Object
        '    For Each objZipCode In ZipCodes
        '        Dim SearchItem As SearchItemInfo
        '        With CType(objZipCode, ZipCodeInfo)
        '            '
        '            Dim UserId As Integer = Null.NullInteger
        '            If IsNumeric(.CreatedByUser) Then
        '                UserId = Integer.Parse(.CreatedByUser)
        '            End If
        '            SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .Title, .Description, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, .Description, "ItemId=" & .ItemId.ToString, Null.NullInteger)
        '            SearchItemCollection.Add(SearchItem)
        '        End With
        '    Next

        '    Return SearchItemCollection

        'End Function

        'Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
        '    Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
        '    Dim strXML As String = ""
        '    strXML += "<ZipCodes>"

        '    'Export the Module Settings
        '    Dim objOI As New OptionsInfo(ModuleID)
        '    With objOI
        '        'Control Options
        '        strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
        '        strXML += "<ControlOption>" & XMLEncode(.ControlOption) & "</ControlOption>"

        '        'Option1 Options

        '        'Option2 Options

        '    End With

        '    'Export each ZipCode Details
        '    Dim arrZipCodes As ArrayList = GetZipCodes(ModuleID)
        '    If arrZipCodes.Count <> 0 Then
        '        Dim objZipCode As ZipCodeInfo
        '        For Each objZipCode In arrZipCodes
        '            With objZipCode
        '                strXML += "<ZipCode>"
        '                strXML += "<Title>" & XMLEncode(.Title) & "</Title>"
        '                strXML += "<NavURL>" & XMLEncode(.NavURL) & "</NavURL>"
        '                strXML += "<ImgSrc>" & XMLEncode(.ImgSrc) & "</ImgSrc>"
        '                strXML += "<ImgMoSrc>" & XMLEncode(.ImgMoSrc) & "</ImgMoSrc>"
        '                strXML += "<ImgBgSrc>" & XMLEncode(.ImgBgSrc) & "</ImgBgSrc>"
        '                strXML += "<ImgWidth>" & XMLEncode(.ImgWidth) & "</ImgWidth>"
        '                strXML += "<ImgHeight>" & XMLEncode(.ImgHeight) & "</ImgHeight>"
        '                strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
        '                strXML += "<Description>" & XMLEncode(.Description) & "</Description>"
        '                strXML += "<NewWindow>" & XMLEncode(.NewWindow.ToString) & "</NewWindow>"
        '                strXML += "</ZipCode>"
        '            End With
        '        Next
        '    End If

        '    strXML += "</ZipCodes>"

        '    Return strXML

        'End Function

        'Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
        '    Dim xmlZipCodes As XmlNode = GetContent(Content, "ZipCodes")

        '    'Import the Module Settings
        '    Dim objModules As New Entities.Modules.ModuleController
        '    Dim objOI As New OptionsInfo
        '    With objOI
        '        'Control Options
        '        .GetItems = Integer.Parse(xmlZipCodes.SelectSingleNode("GetItems").InnerText)
        '        .ControlOption = xmlZipCodes.SelectSingleNode("ControlOption").InnerText

        '        'Option1 Options

        '        'Option2 Options


        '        .SaveOptionsInfo(ModuleID)
        '    End With

        '    'Import each ZipCode Details
        '    Dim xmlZipCode As XmlNode
        '    For Each xmlZipCode In xmlZipCodes.SelectNodes("ZipCode")
        '        Dim objZipCode As New ZipCodeInfo
        '        With objZipCode
        '            .ModuleId = ModuleID
        '            .Title = xmlZipCode.Item("title").InnerText
        '            .NavURL = ImportUrl(ModuleID, xmlZipCode.Item("NavURL").InnerText)
        '            .ImgSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgSrc").InnerText)
        '            .ImgMoSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgMoSrc").InnerText)
        '            .ImgBgSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgBgSrc").InnerText)
        '            .ImgWidth = ImportUrl(ModuleID, xmlZipCode.Item("ImgWidth").InnerText)
        '            .ImgHeight = ImportUrl(ModuleID, xmlZipCode.Item("ImgHeight").InnerText)
        '            .ViewOrder = Integer.Parse(xmlZipCode.Item("ViewOrder").InnerText)
        '            .Description = xmlZipCode.Item("Description").InnerText
        '            .NewWindow = Boolean.Parse(xmlZipCode.Item("NewWindow").InnerText)
        '            .CreatedByUser = UserId.ToString
        '        End With

        '        AddZipCode(objZipCode)
        '    Next

        'End Sub

#End Region

    End Class 'ZipCodesController


End Namespace
