Imports System
Imports System.Data

Namespace bhattji.Modules.LoadSheets.Business

    Public Class LoadDropInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Dim _seq As Integer
        Dim _loadID As String
        Dim _dPName As String
        Dim _dPAddr As String
        Dim _dPCity As String
        Dim _dPState As String
        Dim _ZipCode As String
        Dim _dPPhone As String
        Dim _dPDate As DateTime
        Dim _dPContact As String
        Dim _jobno As String
        Dim _billOLay As String
        Dim _bOLSeq As String
        Dim _stime As DateTime
        Dim _etime As DateTime

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

        Public Property DPName() As String
            Get
                Return _dPName
            End Get
            Set(ByVal Value As String)
                _dPName = Value
            End Set
        End Property

        Public Property DPAddr() As String
            Get
                Return _dPAddr
            End Get
            Set(ByVal Value As String)
                _dPAddr = Value
            End Set
        End Property

        Public Property DPCity() As String
            Get
                Return _dPCity
            End Get
            Set(ByVal Value As String)
                _dPCity = Value
            End Set
        End Property

        Public Property DPState() As String
            Get
                Return _dPState
            End Get
            Set(ByVal Value As String)
                _dPState = Value
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

        Public Property DPPhone() As String
            Get
                Return _dPPhone
            End Get
            Set(ByVal Value As String)
                _dPPhone = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property DPDate() As DateTime
            Get
                Return _dPDate
            End Get
            Set(ByVal Value As DateTime)
                _dPDate = Value
            End Set
        End Property

        Public Property DPContact() As String
            Get
                Return _dPContact
            End Get
            Set(ByVal Value As String)
                _dPContact = Value
            End Set
        End Property

        Public Property Jobno() As String
            Get
                Return _jobno
            End Get
            Set(ByVal Value As String)
                _jobno = Value
            End Set
        End Property

        Public Property BillOLay() As String
            Get
                Return _billOLay
            End Get
            Set(ByVal Value As String)
                _billOLay = Value
            End Set
        End Property

        Public Property BOLSeq() As String
            Get
                Return _bOLSeq
            End Get
            Set(ByVal Value As String)
                _bOLSeq = Value
            End Set
        End Property

        Public Property Stime() As DateTime
            Get
                Return _stime
            End Get
            Set(ByVal Value As DateTime)
                _stime = Value
            End Set
        End Property

        Public Property Etime() As DateTime
            Get
                Return _etime
            End Get
            Set(ByVal Value As DateTime)
                _etime = Value
            End Set
        End Property

#End Region

#Region " Constructors "
        Public Sub New()
        End Sub
#End Region

    End Class

    Public Class LoadDropsController

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

        Public Function AddUpdateLoadDrop(ByVal objLoadDrop As LoadDropInfo) As Integer
            If objLoadDrop.ItemId > 0 Then
                UpdateLoadDrop(objLoadDrop)
                Return objLoadDrop.ItemId
            Else
                Return AddLoadDrop(objLoadDrop)
            End If
        End Function

        Public Function AddLoadDrop(ByVal objLoadDrop As LoadDropInfo) As Integer
            With objLoadDrop
                Dim ItemId As Integer = Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddLoadDrop", GetNull(.Seq), .LoadID, GetNull(.DPName), GetNull(.DPAddr), GetNull(.DPCity), GetNull(.DPState), GetNull(.ZipCode), GetNull(.DPPhone), GetNull(.DPDate), GetNull(.DPContact), GetNull(.Jobno), GetNull(.BillOLay), GetNull(.BOLSeq), GetNull(.Stime), GetNull(.Etime)))
                SetDPCityST(.LoadID)
                Return ItemId
                'Return DataProvider.Instance().AddLoadDrop(.ModuleId, .CreatedByUser, .Title, .NavURL, .ImgSrc, .ImgMoSrc, .ImgBgSrc, .ImgWidth, .ImgHeight, .ViewOrder, .Description, .AltText, .Player, .uiMode, .RepeatCount)
            End With
        End Function

        Public Sub UpdateLoadDrop(ByVal objLoadDrop As LoadDropInfo)
            With objLoadDrop
                DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UpdateLoadDrop", .ItemId, GetNull(.Seq), .LoadID, GetNull(.DPName), GetNull(.DPAddr), GetNull(.DPCity), GetNull(.DPState), GetNull(.ZipCode), GetNull(.DPPhone), GetNull(.DPDate), GetNull(.DPContact), GetNull(.Jobno), GetNull(.BillOLay), GetNull(.BOLSeq), GetNull(.Stime), GetNull(.Etime))
                SetDPCityST(.LoadID)
            End With
        End Sub

        Public Sub SetDPCityST(ByVal LoadId As String)
            Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadDropByLoadId", LoadId)
            Dim objLSC As New LoadSheetsController
            Dim objLS As LoadSheetInfo = objLSC.GetLoadSheet(objLSC.GetItemId(LoadId))
            If Not objLS Is Nothing Then
                Dim DPCityST As String = objLS.DPCityST
                Dim LastLoadDeliv As Date = objLS.DeliveryDate
                While dr.Read
                    DPCityST = dr("DPCity").ToString & ", " & dr("DPState").ToString.ToUpper
                    Try
                        If Not Null.IsNull(dr("DPDate")) Then LastLoadDeliv = CType(dr("DPDate"), Date)
                    Catch
                    End Try
                End While
                objLS.DPCityST = DPCityST
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


                '            'objSalePerson.LastPU = objLS.PUCityST
                '            objSalePerson.LastDP = DPCityST
                '            If Not Null.IsNull(LastLoadDeliv) Then objSalePerson.LastLoadDeliv = LastLoadDeliv

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


                '            'objSalePerson.LastPU = objLS.PUCityST
                '            objSalePerson.LastDP = DPCityST
                '            objSalePerson.LastLoadDeliv = LastLoadDeliv

                '            'objSalePerson.LastTrailerUsed = objLoadSheet.TrailerNumber

                '            objSC.UpdateSalesPerson(objSalePerson)
                '        End If
                'End Select
            End If
        End Sub

        Public Sub DeleteLoadDrop(ByVal objLoadDrop As LoadDropInfo)
            DeleteLoadDrop(objLoadDrop.ItemId)
        End Sub

        Public Sub DeleteLoadDrop(ByVal ItemId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteLoadDrop", ItemId)
            'DataProvider.Instance().DeleteLoadDrop(ItemID)
        End Sub

        Public Function GetLoadDrop(ByVal ItemId As Integer) As LoadDropInfo
            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadDrop", ItemId), GetType(LoadDropInfo)), LoadDropInfo)
        End Function

        Public Function AddLoadDropByLoadId(ByVal objLoadDrop As LoadDropInfo) As String
            With objLoadDrop
                Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddLoadDrop", GetNull(.Seq), .LoadID, GetNull(.DPName), GetNull(.DPAddr), GetNull(.DPCity), GetNull(.DPState), GetNull(.ZipCode), GetNull(.DPPhone), GetNull(.DPDate), GetNull(.DPContact), GetNull(.Jobno), GetNull(.BillOLay), GetNull(.BOLSeq), GetNull(.Stime), GetNull(.Etime)))
                'Return DataProvider.Instance().AddLoadDrop(.ModuleId, .CreatedByUser, .Title, .NavURL, .ImgSrc, .ImgMoSrc, .ImgBgSrc, .ImgWidth, .ImgHeight, .ViewOrder, .Description, .AltText, .Player, .uiMode, .RepeatCount)
            End With
        End Function

        Public Sub UpdateLoadDropByLoadId(ByVal objLoadDrop As LoadDropInfo)
            With objLoadDrop
                DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UpdateLoadDropByLoadId", GetNull(.Seq), .LoadID, GetNull(.DPName), GetNull(.DPAddr), GetNull(.DPCity), GetNull(.DPState), GetNull(.ZipCode), GetNull(.DPPhone), GetNull(.DPDate), GetNull(.DPContact), GetNull(.Jobno), GetNull(.BillOLay), GetNull(.BOLSeq), GetNull(.Stime), GetNull(.Etime))
            End With
        End Sub

        Public Sub DeleteLoadDropByLoadId(ByVal LoadId As String)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteLoadDrop", LoadId)
            'DataProvider.Instance().DeleteLoadDrop(ItemID)
        End Sub

        Public Function GetLoadDropByLoadId(ByVal LoadId As String) As ArrayList
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadDropByLoadId", LoadId), GetType(LoadDropInfo))
        End Function
        Public Function GetReportLoadDropByLoadId(ByVal LoadId As String) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("DPPhone", GetType(String))
            dt.Columns.Add("strStime", GetType(String))
            dt.Columns.Add("strEtime", GetType(String))
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadDropByLoadId", LoadId))

            For Each dtr3 As DataRow In dt.Rows
                dtr3("DPPhone") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr3("DPPhone"), Null.NullString))) '& IIf(Null.IsNull(dtr("CarrierExt")), "", " Ext: " & dtr("CarrierExt").ToString).ToString
                Try
                    dtr3("strStime") = IIf(Null.IsNull(dtr3("Stime")), "", CDate(dtr3("Stime")).ToShortTimeString).ToString
                Catch
                End Try
                Try
                    dtr3("strEtime") = IIf(Null.IsNull(dtr3("Etime")), "", CDate(dtr3("Etime")).ToShortTimeString).ToString
                Catch
                End Try
            Next

            Return dt
        End Function

        Public Function GetDPCitySTByLoadId(ByVal LoadID As String) As String
            Try
                Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetDPCitySTByLoadId", LoadID))
            Catch
                Return ""
            End Try
        End Function


        Public Function GetLastLoadDP(ByVal LoadId As String) As LoadDropInfo
            Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLastLoadDP", LoadId), GetType(LoadDropInfo)), LoadDropInfo)
        End Function
#End Region

#Region " Optional Interfaces "

        'Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
        '    Dim SearchItemCollection As New SearchItemInfoCollection

        '    Dim LoadDrops As ArrayList = GetLoadDrops(ModInfo.ModuleID)

        '    Dim objLoadDrop As Object
        '    For Each objLoadDrop In LoadDrops
        '        Dim SearchItem As SearchItemInfo
        '        With CType(objLoadDrop, LoadDropInfo)
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
        '    strXML += "<LoadDrops>"

        '    'Export the Module Settings
        '    Dim objOI As New OptionsInfo(ModuleID)
        '    With objOI
        '        'Control Options
        '        strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
        '        strXML += "<ControlOption>" & XMLEncode(.ControlOption) & "</ControlOption>"

        '        'Option1 Options

        '        'Option2 Options

        '    End With

        '    'Export each LoadDrop Details
        '    Dim arrLoadDrops As ArrayList = GetLoadDrops(ModuleID)
        '    If arrLoadDrops.Count <> 0 Then
        '        Dim objLoadDrop As LoadDropInfo
        '        For Each objLoadDrop In arrLoadDrops
        '            With objLoadDrop
        '                strXML += "<LoadDrop>"
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
        '                strXML += "</LoadDrop>"
        '            End With
        '        Next
        '    End If

        '    strXML += "</LoadDrops>"

        '    Return strXML

        'End Function

        'Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
        '    Dim xmlLoadDrops As XmlNode = GetContent(Content, "LoadDrops")

        '    'Import the Module Settings
        '    Dim objModules As New Entities.Modules.ModuleController
        '    Dim objOI As New OptionsInfo
        '    With objOI
        '        'Control Options
        '        .GetItems = Integer.Parse(xmlLoadDrops.SelectSingleNode("GetItems").InnerText)
        '        .ControlOption = xmlLoadDrops.SelectSingleNode("ControlOption").InnerText

        '        'Option1 Options

        '        'Option2 Options


        '        .SaveOptionsInfo(ModuleID)
        '    End With

        '    'Import each LoadDrop Details
        '    Dim xmlLoadDrop As XmlNode
        '    For Each xmlLoadDrop In xmlLoadDrops.SelectNodes("LoadDrop")
        '        Dim objLoadDrop As New LoadDropInfo
        '        With objLoadDrop
        '            .ModuleId = ModuleID
        '            .Title = xmlLoadDrop.Item("title").InnerText
        '            .NavURL = ImportUrl(ModuleID, xmlLoadDrop.Item("NavURL").InnerText)
        '            .ImgSrc = ImportUrl(ModuleID, xmlLoadDrop.Item("ImgSrc").InnerText)
        '            .ImgMoSrc = ImportUrl(ModuleID, xmlLoadDrop.Item("ImgMoSrc").InnerText)
        '            .ImgBgSrc = ImportUrl(ModuleID, xmlLoadDrop.Item("ImgBgSrc").InnerText)
        '            .ImgWidth = ImportUrl(ModuleID, xmlLoadDrop.Item("ImgWidth").InnerText)
        '            .ImgHeight = ImportUrl(ModuleID, xmlLoadDrop.Item("ImgHeight").InnerText)
        '            .ViewOrder = Integer.Parse(xmlLoadDrop.Item("ViewOrder").InnerText)
        '            .Description = xmlLoadDrop.Item("Description").InnerText
        '            .NewWindow = Boolean.Parse(xmlLoadDrop.Item("NewWindow").InnerText)
        '            .CreatedByUser = UserId.ToString
        '        End With

        '        AddLoadDrop(objLoadDrop)
        '    Next

        'End Sub

#End Region

    End Class 'LoadDropsController

End Namespace
