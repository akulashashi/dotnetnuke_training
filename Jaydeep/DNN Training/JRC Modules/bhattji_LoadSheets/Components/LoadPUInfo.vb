Imports System
Imports System.Data

Namespace bhattji.Modules.LoadSheets.Business

    Public Class LoadPUInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Dim _seq As Integer
        Dim _loadID As String
        Dim _pUName As String
        Dim _pUAdd1 As String
        Dim _pRONo As String
        Dim _pUCity As String
        Dim _pUState As String
        Dim _ZipCode As String
        Dim _pUTel As String
        Dim _pUContact As String
        Dim _pUDate As DateTime
        Dim _pUTime As DateTime
        Dim _pieces As String
        Dim _weight As String
        Dim _miles As Decimal

#End Region

#Region " Properties "

        Dim _ItemId As Integer
        Public Property ItemId() As Integer
            Get
                Return _ItemId
            End Get
            Set(ByVal Value As Integer)
                _ItemId = Value
            End Set
        End Property

        Public Property Seq() As Integer
            Get
                Return _seq
            End Get
            Set(ByVal Value As Integer)
                _seq = Value
            End Set
        End Property

        Public Property LoadID() As String
            Get
                Return _loadID
            End Get
            Set(ByVal Value As String)
                _loadID = Value
            End Set
        End Property

        Public Property PUName() As String
            Get
                Return _pUName
            End Get
            Set(ByVal Value As String)
                _pUName = Value
            End Set
        End Property

        Public Property PUAdd1() As String
            Get
                Return _pUAdd1
            End Get
            Set(ByVal Value As String)
                _pUAdd1 = Value
            End Set
        End Property

        Public Property PRONo() As String
            Get
                Return _pRONo
            End Get
            Set(ByVal Value As String)
                _pRONo = Value
            End Set
        End Property

        Public Property PUCity() As String
            Get
                Return _pUCity
            End Get
            Set(ByVal Value As String)
                _pUCity = Value
            End Set
        End Property

        Public Property PUState() As String
            Get
                Return _pUState
            End Get
            Set(ByVal Value As String)
                _pUState = Value
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

        Public Property PUTel() As String
            Get
                Return _pUTel
            End Get
            Set(ByVal Value As String)
                _pUTel = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property PUContact() As String
            Get
                Return _pUContact
            End Get
            Set(ByVal Value As String)
                _pUContact = Value
            End Set
        End Property

        Public Property PUDate() As DateTime
            Get
                Return _pUDate
            End Get
            Set(ByVal Value As DateTime)
                _pUDate = Value
            End Set
        End Property

        'Public Property strPUDate() As String
        '    Get
        '        Return _pUDate.ToShortDateString
        '    End Get
        '    Set(ByVal Value As String)
        '        Try
        '            _pUDate = Date.Parse(Value)
        '        Catch
        '            _pUDate = Null.NullDate
        '        End Try
        '    End Set
        'End Property

        Public Property PUTime() As DateTime
            Get
                Return _pUTime
            End Get
            Set(ByVal Value As DateTime)
                _pUTime = Value
            End Set
        End Property

        'Public Property strPUTime() As String
        '    Get
        '        Return _pUTime.ToShortTimeString
        '    End Get
        '    Set(ByVal Value As String)
        '        Try
        '            _pUTime = DateTime.Parse(Value)
        '        Catch
        '            _pUTime = Null.NullDate
        '        End Try
        '    End Set
        'End Property

        Public Property Pieces() As String
            Get
                Return _pieces
            End Get
            Set(ByVal Value As String)
                _pieces = Value
            End Set
        End Property

        Public Property Weight() As String
            Get
                Return _weight
            End Get
            Set(ByVal Value As String)
                _weight = Value
            End Set
        End Property

        Public Property Miles() As Decimal
            Get
                Return _miles
            End Get
            Set(ByVal Value As Decimal)
                _miles = Value
            End Set
        End Property

#End Region

#Region " Constructors "
        Public Sub New()
        End Sub
#End Region

    End Class

    Public Class LoadPUsController

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

        Public Function AddUpdateLoadPU(ByVal objLoadPU As LoadPUInfo) As Integer
            If objLoadPU.ItemId > 0 Then
                UpdateLoadPU(objLoadPU)
                Return objLoadPU.ItemId
            Else
                Return AddLoadPU(objLoadPU)
            End If
        End Function

        Public Function AddLoadPU(ByVal objLoadPU As LoadPUInfo) As Integer
            With objLoadPU
                Dim ItemId As Integer = Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddLoadPU", GetNull(.Seq), .LoadID, GetNull(.PUName), GetNull(.PUAdd1), GetNull(.PRONo), GetNull(.PUCity), GetNull(.PUState), GetNull(.ZipCode), GetNull(.PUTel), GetNull(.PUContact), GetNull(.PUDate), GetNull(.PUTime), GetNull(.Pieces), GetNull(.Weight), GetNull(.Miles)))
                SetPUCityST(.LoadID)
                Return ItemId
            End With
        End Function

        Public Sub UpdateLoadPU(ByVal objLoadPU As LoadPUInfo)
            With objLoadPU
                DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UpdateLoadPU", .ItemId, GetNull(.Seq), .LoadID, GetNull(.PUName), GetNull(.PUAdd1), GetNull(.PRONo), GetNull(.PUCity), GetNull(.PUState), GetNull(.ZipCode), GetNull(.PUTel), GetNull(.PUContact), GetNull(.PUDate), GetNull(.PUTime), GetNull(.Pieces), GetNull(.Weight), GetNull(.Miles))
                SetPUCityST(.LoadID)
            End With
        End Sub

        Public Sub SetPUCityST(ByVal LoadId As String)
            Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadPUByLoadId", LoadId)
            If dr.Read Then
                Dim objLSC As New LoadSheetsController
                Dim objLS As LoadSheetInfo = objLSC.GetLoadSheet(objLSC.GetItemId(LoadId))
                If Not objLS Is Nothing Then
                    objLS.PUCityST = dr("PUCity").ToString & ", " & dr("PUState").ToString.ToUpper
                    objLSC.UpdateLoadSheet(objLS)

                    ''Following Line was commented for Eric on May 31, 2010
                    'Select Case objLS.LoadType.ToUpper
                    '    Case "OO"
                    '        Dim DriverId As Integer = (New LoadSheetsController).GetSalesPersonId(objLS.DriverCode)
                    '        Dim objSC As New bhattji.Modules.SalesPersons.Business.SalesPersonsController
                    '        Dim objSalePerson As bhattji.Modules.SalesPersons.Business.SalesPersonInfo = objSC.GetSalesPerson(DriverId)
                    '        If Not objSalePerson Is Nothing Then
                    '            'objSalePerson.LastLoadID = objLoadSheet.LoadID
                    '            'objSalePerson.LastLoad = objLoadSheet.LoadDate


                    '            objSalePerson.LastPU = objLS.PUCityST
                    '            'objSalePerson.LastDP = objLoadSheet.DPCityST
                    '            'objSalePerson.LastLoadDeliv = objLoadSheet.LoadDate

                    '            'objSalePerson.LastTrailerUsed = objLoadSheet.TrailerNumber

                    '            objSC.UpdateSalesPerson(objSalePerson)
                    '        End If
                    '    Case "BK"
                    '        Dim DriverId As Integer = (New LoadSheetsController).GetBkrSalesPersonId(objLS.BkrDriverNo)
                    '        Dim objSC As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
                    '        Dim objSalePerson As bhattji.Modules.BkrSalesPersons.Business.SalesPersonInfo = objSC.GetSalesPerson(DriverId)
                    '        If Not objSalePerson Is Nothing Then
                    '            'objSalePerson.LastLoadID = objLoadSheet.LoadID
                    '            'objSalePerson.LastLoad = objLoadSheet.LoadDate


                    '            objSalePerson.LastPU = objLS.PUCityST
                    '            'objSalePerson.LastDP = objLoadSheet.DPCityST
                    '            'objSalePerson.LastLoadDeliv = objLoadSheet.LoadDate

                    '            'objSalePerson.LastTrailerUsed = objLoadSheet.TrailerNumber

                    '            objSC.UpdateSalesPerson(objSalePerson)
                    '        End If
                    'End Select
                End If
            End If
        End Sub

        Public Sub DeleteLoadPU(ByVal objLoadPU As LoadPUInfo)
            DeleteLoadPU(objLoadPU.ItemId)
        End Sub

        Public Sub DeleteLoadPU(ByVal ItemId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteLoadPU", ItemId)
        End Sub

        Public Function GetLoadPU(ByVal ItemId As Integer) As LoadPUInfo
            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadPU", ItemId), GetType(LoadPUInfo)), LoadPUInfo)
        End Function

        Public Function AddLoadPUByLoadId(ByVal objLoadPU As LoadPUInfo) As String
            With objLoadPU
                Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddLoadPU", GetNull(.Seq), .LoadID, GetNull(.PUName), GetNull(.PUAdd1), GetNull(.PRONo), GetNull(.PUCity), GetNull(.PUState), GetNull(.ZipCode), GetNull(.PUTel), GetNull(.PUContact), GetNull(.PUDate), GetNull(.PUTime), GetNull(.Pieces), GetNull(.Weight), GetNull(.Miles)))
            End With
        End Function

        Public Sub UpdateLoadPUByLoadId(ByVal objLoadPU As LoadPUInfo)
            With objLoadPU
                DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UpdateLoadPUByLoadId", GetNull(.Seq), .LoadID, GetNull(.PUName), GetNull(.PUAdd1), GetNull(.PRONo), GetNull(.PUCity), GetNull(.PUState), GetNull(.ZipCode), GetNull(.PUTel), GetNull(.PUContact), GetNull(.PUDate), GetNull(.PUTime), GetNull(.Pieces), GetNull(.Weight), GetNull(.Miles))
            End With
        End Sub

        Public Sub DeleteLoadPUByLoadId(ByVal LoadId As String)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteLoadPU", LoadId)
        End Sub

        Public Function GetLoadPUByLoadId(ByVal LoadId As String) As ArrayList
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadPUByLoadId", LoadId), GetType(LoadPUInfo))
        End Function
        Public Function GetReportLoadPUByLoadId(ByVal LoadId As String) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("PUTel", GetType(String))
            dt.Columns.Add("strPUTime", GetType(String))
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadPUByLoadId", LoadId))

            For Each dtr2 As DataRow In dt.Rows
                dtr2("PUTel") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr2("PUTel"), Null.NullString))) '& IIf(Null.IsNull(dtr("CarrierExt")), "", " Ext: " & dtr("CarrierExt").ToString).ToString
                Try
                    dtr2("strPUTime") = IIf(Null.IsNull(dtr2("PUTime")), "", CDate(dtr2("PUTime")).ToShortTimeString).ToString
                Catch
                End Try
            Next
            Return dt
        End Function

        Public Function GetPUCitySTByLoadId(ByVal LoadID As String) As String
            Try
                Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetPUCitySTByLoadId", LoadID))
            Catch
                Return ""
            End Try
        End Function

        Public Function GetFirstLoadPU(ByVal LoadId As String) As LoadPUInfo
            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetFirstLoadPU", LoadId), GetType(LoadPUInfo)), LoadPUInfo)
        End Function

#End Region

#Region " Optional Interfaces "

        'Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
        '    Dim SearchItemCollection As New SearchItemInfoCollection

        '    Dim LoadPUs As ArrayList = GetLoadPUs(ModInfo.ModuleID)

        '    Dim objLoadPU As Object
        '    For Each objLoadPU In LoadPUs
        '        Dim SearchItem As SearchItemInfo
        '        With CType(objLoadPU, LoadPUInfo)
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
        '    strXML += "<LoadPUs>"

        '    'Export the Module Settings
        '    Dim objOI As New OptionsInfo(ModuleID)
        '    With objOI
        '        'Control Options
        '        strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
        '        strXML += "<ControlOption>" & XMLEncode(.ControlOption) & "</ControlOption>"

        '        'Option1 Options

        '        'Option2 Options

        '    End With

        '    'Export each LoadPU Details
        '    Dim arrLoadPUs As ArrayList = GetLoadPUs(ModuleID)
        '    If arrLoadPUs.Count <> 0 Then
        '        Dim objLoadPU As LoadPUInfo
        '        For Each objLoadPU In arrLoadPUs
        '            With objLoadPU
        '                strXML += "<LoadPU>"
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
        '                strXML += "</LoadPU>"
        '            End With
        '        Next
        '    End If

        '    strXML += "</LoadPUs>"

        '    Return strXML

        'End Function

        'Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
        '    Dim xmlLoadPUs As XmlNode = GetContent(Content, "LoadPUs")

        '    'Import the Module Settings
        '    Dim objModules As New Entities.Modules.ModuleController
        '    Dim objOI As New OptionsInfo
        '    With objOI
        '        'Control Options
        '        .GetItems = Integer.Parse(xmlLoadPUs.SelectSingleNode("GetItems").InnerText)
        '        .ControlOption = xmlLoadPUs.SelectSingleNode("ControlOption").InnerText

        '        'Option1 Options

        '        'Option2 Options


        '        .SaveOptionsInfo(ModuleID)
        '    End With

        '    'Import each LoadPU Details
        '    Dim xmlLoadPU As XmlNode
        '    For Each xmlLoadPU In xmlLoadPUs.SelectNodes("LoadPU")
        '        Dim objLoadPU As New LoadPUInfo
        '        With objLoadPU
        '            .ModuleId = ModuleID
        '            .Title = xmlLoadPU.Item("title").InnerText
        '            .NavURL = ImportUrl(ModuleID, xmlLoadPU.Item("NavURL").InnerText)
        '            .ImgSrc = ImportUrl(ModuleID, xmlLoadPU.Item("ImgSrc").InnerText)
        '            .ImgMoSrc = ImportUrl(ModuleID, xmlLoadPU.Item("ImgMoSrc").InnerText)
        '            .ImgBgSrc = ImportUrl(ModuleID, xmlLoadPU.Item("ImgBgSrc").InnerText)
        '            .ImgWidth = ImportUrl(ModuleID, xmlLoadPU.Item("ImgWidth").InnerText)
        '            .ImgHeight = ImportUrl(ModuleID, xmlLoadPU.Item("ImgHeight").InnerText)
        '            .ViewOrder = Integer.Parse(xmlLoadPU.Item("ViewOrder").InnerText)
        '            .Description = xmlLoadPU.Item("Description").InnerText
        '            .NewWindow = Boolean.Parse(xmlLoadPU.Item("NewWindow").InnerText)
        '            .CreatedByUser = UserId.ToString
        '        End With

        '        AddLoadPU(objLoadPU)
        '    Next

        'End Sub

#End Region

    End Class 'LoadPUsController

End Namespace
