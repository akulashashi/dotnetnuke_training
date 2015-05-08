' Copyright (c) 2002-2005
' by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, to the person obtaining a copy of this software legaly and associated
' documentation files (the "Software"), to deal in the Software with restriction, including with limitation
' the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
'

Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports bhattji.Modules.LoadSheets.Business
Imports Microsoft.Reporting.WebForms

Namespace bhattji.Modules.LoadSheets

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Links Class provides the UI for displaying the Links
    ''' </summary>
    '''
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[bhattji]	9/23/2004	Moved Links to a separate Project
    '''		[bhattji]	10/20/2004	Removed ViewOptions from Action menu
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '''

    Public MustInherit Class rvLoadStatusDriver
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private objOI As OptionsInfo

#End Region

#Region " Methods "


        Private Sub RunReport()
            ' Set the processing mode for the ReportViewer to Local 
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.ShowToolBar = False
            'ReportViewer1.ShowRefreshButton = True
            'ReportViewer1.ShowZoomControl = True
            'ReportViewer1.ShowPrintButton = True

            'ReportViewer1.ShowExportControls = False
            'ReportViewer1.ShowFindControls = False
            'ReportViewer1.ShowPageNavigationControls = False

            ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/LoadStatusDriver.rdlc")

            Dim dt As DataTable = (New LoadSheetsController).GetReport2Driver(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, ddlLoadStatus.SelectedValue, rblStatus.SelectedValue, "OO", ddlDriverCode.SelectedValue, "Any", (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)

            Dim ReportDataSource1 As New ReportDataSource("DataSet1_DataTable1", dt)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            ' Create the prmCopyright ReportParameter 
            Dim prmCopyright As New ReportParameter("prmCopyright", "Copyrighted by JRC Transportation")
            'prmCopyright.Name = "prmCopyright"; 
            'prmCopyright.Values.Add("Copyrighted by Jaydeep Bhatt"); 
            ' Create the prmCopyright ReportParameter 
            Dim prmCompanyName As New ReportParameter("prmCompanyName", "JRC Office: " + ddlJRCIOfficeCode.SelectedItem.Text)

            ' Set the report parameters for the report 
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {prmCopyright, prmCompanyName})
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCopyright}); 
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCompanyName }); 
        End Sub

        Private Sub BindUserIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") And Request.IsAuthenticated Then
                LoginName = Users.UserController.GetCurrentUserInfo.Username
            End If
            With ddlJRCIOfficeCode
                '.DataTextField = "IOName"
                '.DataValueField = "IOfficeCode"
                'If LoginName = "" Then
                '    .DataSource = (New Business.LoadSheetsController).GetAllInterOffices
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                'End If
                '.DataBind()

                Dim valfld, txtfld As String
                Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (Users.UserController.GetCurrentUserInfo.IsInRole("Sales - Admin")) OrElse (LoginName = "") Then
                    dr = (New Business.LoadSheetsController).GetAllInterOffices
                Else
                    dr = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                End If
                .Items.Clear()
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (Users.UserController.GetCurrentUserInfo.IsInRole("Admin - REPORTS")) Then
                    .Items.Insert(0, New ListItem("<All Offices>", "999999999"))
                End If

                Dim objLC As New Business.LoadSheetsController
                If (Session.Item("JRCIOfficeCode") Is Nothing) OrElse (Session.Item("JRCIOfficeCode").ToString = "") OrElse (Session.Item("JRCIOfficeCode").ToString = "000000000") Then
                    Session.Item("JRCIOfficeCode") = objLC.GetUserDefaultIO(LoginName)
                End If

                Try
                    .Items.FindByValue(Session.Item("JRCIOfficeCode").ToString.Substring(0, 9)).Selected = True
                Catch
                End Try

                'Try
                '    .Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
                'Catch
                'End Try

            End With
        End Sub

#End Region

#Region " Event Handlers "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Page_Load runs when the control is loaded
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[bhattji]	9/23/2004	Moved Links to a separate Project
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '''
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId) 'This is must since it is being used in RowBound Method


                'this needs to execute always to the client script code is registred in InvokePopupCal
                hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)
                'hypReport2Driver.NavigateUrl = EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")

                If Not Page.IsPostBack Then
                    If (Not Request.QueryString("FromDate") Is Nothing) AndAlso (Request.QueryString("FromDate") <> "") Then
                        txtFrom.Text = Request.QueryString("FromDate")
                    Else
                        txtFrom.Text = Now.AddMonths(-1).ToShortDateString
                    End If
                    If (Not Request.QueryString("ToDate") Is Nothing) AndAlso (Request.QueryString("ToDate") <> "") Then
                        txtTo.Text = Request.QueryString("ToDate")
                    Else
                        txtTo.Text = Now.ToShortDateString
                    End If
                    tdNoOfItems.Visible = objOI.ShowNoOfItems
                    txtNoOfItems.Text = objOI.rptNoOfItems.ToString
                    BindUserIOs()
                    If (Not Request.QueryString("JRCIOfficeCode") Is Nothing) AndAlso (Request.QueryString("JRCIOfficeCode") <> "") Then
                        ddlJRCIOfficeCode.SelectedValue = Request.QueryString("JRCIOfficeCode")
                    End If
                    If (Not Request.QueryString("LoadStatus") Is Nothing) AndAlso (Request.QueryString("LoadStatus") <> "") Then
                        ddlLoadStatus.SelectedValue = Request.QueryString("LoadStatus")
                    End If
                    If (Not Request.QueryString("DriverCode") Is Nothing) AndAlso (Request.QueryString("DriverCode") <> "") Then
                        ddlDriverCode.Items.Insert(0, Request.QueryString("DriverCode"))
                        ddlDriverCode.SelectedValue = Request.QueryString("DriverCode")
                    End If

                    'BindSearchData()
                    RunReport()
                End If
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            btnSearch_Click(Nothing, Nothing)
        End Sub

        'Private Sub ddlCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategories.SelectedIndexChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub btnCustomerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCustomerSearch.Click
            With ddlCustomerNumber
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerName"
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearchForReports(txtCustomerNumber.Text, ddlJRCIOfficeCode.SelectedValue, (rblSearchType.SelectedIndex < 1), txtFrom.Text, txtTo.Text)
                .DataBind()

                .Items.Insert(0, New ListItem("<All Customers>", ""))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
                ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
            End With 'ddlBrokerCode
        End Sub

        Private Sub imbRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbRefresh.Click
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        Private Sub txtFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged, txtTo.TextChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub


        Private Sub ddlDriverCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDriverCode.SelectedIndexChanged

            If ddlDriverCode.SelectedValue <> "" Then
                Dim dr As IDataReader = (New Business.LoadSheetsController).GetDriverByCode(ddlDriverCode.SelectedValue)
                If dr Is Nothing Then
                    lblDriverCode.Text = "<font color='red'><b>Failure</b><br/>The Driver, with Driver Code='" & ddlDriverCode.SelectedValue & "' cannot be processed</font>"
                Else
                    dr.Read()
                    lblDriverCode.Text = "<br />Status: "
                    If dr("Status").ToString.ToUpper = "N" Then
                        lblDriverCode.Text &= "<font color='green'>ACTIVE</font><br />"
                    Else
                        lblDriverCode.Text &= "<font color='red'>INACTIVE</font><br />"
                    End If
                    lblDriverCode.Text &= "City: "
                    If dr("City").ToString <> String.Empty Then lblDriverCode.Text &= dr("City").ToString & ", "
                    lblDriverCode.Text &= "<br />State: "
                    If dr("State").ToString <> String.Empty Then lblDriverCode.Text &= dr("State").ToString

                End If 'dr Is Nothing Then

            Else
                lblDriverCode.Text = "<br/><font color='red'>Not a Valid Driver</font>"
            End If
            txtDriverCode.Text = "" 'ddlDriverCode.SelectedValue
            btnSearch_Click(Nothing, Nothing)

        End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            RunReport()
            ''Open PDF for preview/Print everytime
            'If Page.IsPostBack Then imbPrintSelection_Click(Nothing, Nothing)
        End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true") & "?DriverCode=" & ddlDriverCode.SelectedValue & "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Dim strUrl As String = EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text)

            If ddlJRCIOfficeCode.SelectedValue <> "" AndAlso ddlJRCIOfficeCode.SelectedValue <> "000000000" Then
                strUrl &= "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue
            End If
            If ddlLoadStatus.SelectedValue <> "" Then
                strUrl &= "&LoadStatus=" & ddlLoadStatus.SelectedValue
            End If
            If ddlDriverCode.SelectedValue <> "" AndAlso ddlDriverCode.SelectedValue <> "ZXZX" Then
                strUrl &= "&DriverCode=" & ddlDriverCode.SelectedValue
            End If

            strUrl &= "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "','report2Driver', 'location=0,toolbar=1,resizable=1,scrollbars=1,status=1');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print('" & strUrl & "','report2Driver', 'location=0,resizable=1,scrollbars=1,status=1');</script>")

        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            ''txtNoOfItems.Text = "0"
            ''gdvViewList.AllowPaging = False
            ''ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            ''If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            ''Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))

            Dim strFileName As String = Server.MapPath("~/Documentation/LoadStatusDriver.PDF")
            'First delete existing file
            System.IO.File.Delete(strFileName)
            'Then create new pdf file
            Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim fsFileStream As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
            fsFileStream.Write(bytes, 0, bytes.Length)
            fsFileStream.Close()
            'Write to Browser
            ResponseHelper.Redirect(ResolveUrl("~/Documentation/LoadStatusDriver.PDF"), "LoadStatusDriver")
        End Sub

        'Private Sub txtDriverCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDriverCode.TextChanged

        '    With ddlDriverCode
        '        Dim txt As String '= .Items(0).Text '.SelectedItem.Text
        '        Dim val As String '= .Items(0).Value '.SelectedValue
        '        If .Items.Count > 0 Then
        '            txt = .Items(0).Text  '.SelectedItem.Text
        '            val = .Items(0).Value  '.SelectedValue
        '        End If

        '        '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "DriverCode", (rblBrokerSearchType.SelectedIndex < 1))
        '        .DataSource = (New Business.LoadSheetsController).Getrpt2Driver(txtDriverCode.Text) ', "DriverCode")
        '        .DataValueField = "DriverCode"
        '        .DataTextField = "DriverName"
        '        .DataBind()

        '        ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
        '        'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
        '        ''.Items.Insert(0, (New ListItem("", "0000000")))

        '        If .Items.Count > 0 Then
        '            ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
        '        Else
        '            .Items.Add(New ListItem("No Driver", ""))
        '            'lblDriver.Text = ""
        '        End If

        '    End With 'ddlDriverName

        'End Sub

        Private Sub btnDriverSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDriverSearch.Click

            'Dim dr As IDataReader = (New Business.LoadSheetsController).GetDriverByCode(txtDriverCode.Text) '(ddlDriverCode.SelectedValue)
            'If dr Is Nothing Then
            '    lblDriverCode.Text = "<font color='red'><b>Failure</b><br/>The Driver, with Driver Code='" & txtDriverCode.Text & "' cannot be processed</font>"
            'End If

            With ddlDriverCode
                Dim txt As String = "" '= .Items(0).Text '.SelectedItem.Text
                Dim val As String = "" '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                ''.DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
                'If rblOfficeVendorNO.SelectedIndex > -1 Then
                '    .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO(txtDriverName.Text, rblOfficeVendorNO.SelectedValue, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
                'End If

                .Items.Clear()
                .DataValueField = "DriverCode"
                .DataTextField = "DriverName"
                If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") AndAlso (ddlJRCIOfficeCode.SelectedValue <> "000000000") Then
                    .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO2(txtDriverCode.Text, ddlJRCIOfficeCode.SelectedValue, rblStatus.SelectedValue)
                Else
                    .DataSource = (New Business.LoadSheetsController).GetDriverSearch2(txtDriverCode.Text, rblStatus.SelectedValue)
                End If
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> "" Then .Items.Insert(0, (New ListItem(txt, val)))
                ''If (val <> String.Empty) AndAlso (Not ((.Items.Count > 0) AndAlso (val = .Items(0).Value))) Then .Items.Insert(0, (New ListItem(txt, val)))
                'If (val <> String.Empty) Then
                '    If ((.Items.Count = 0) OrElse (.Items(0).Value <> val)) Then
                '        .Items.Insert(0, (New ListItem(txt, val)))
                '    End If
                'End If
                'If val <> "" Then
                '    .Items.Insert(0, (New ListItem(txt, val)))
                '    If (.Items.Count > 1) Then
                '        If (.Items(0).Value = .Items(1).Value) Then
                '            .Items.RemoveAt(0)
                '        End If
                '    End If
                'End If
                'Try
                'Catch
                'End Try
                'If .Items.Count < 1 Then

                .Items.Insert(0, (New ListItem("<All Drivers>", "")))
                'End If
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                    ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
                End If

                txtDriverCode.Text = "" '.SelectedValue
            End With 'ddlDriverName
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub rblStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblStatus.SelectedIndexChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        'Private Sub txtBrokerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrokerCode.TextChanged

        '    With ddlBrokerCode
        '        Dim txt As String '= .Items(0).Text '.SelectedItem.Text
        '        Dim val As String '= .Items(0).Value '.SelectedValue
        '        If .Items.Count > 0 Then
        '            txt = .Items(0).Text  '.SelectedItem.Text
        '            val = .Items(0).Value  '.SelectedValue
        '        End If

        '        '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "BrokerCode", (rblBrokerSearchType.SelectedIndex < 1))
        '        .DataSource = (New Business.LoadSheetsController).Getrpt2Broker(txtBrokerCode.Text) ', "BrokerCode")
        '        .DataValueField = "BrokerCode"
        '        .DataTextField = "BrokerName"
        '        .DataBind()

        '        ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
        '        'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
        '        ''.Items.Insert(0, (New ListItem("", "0000000")))

        '        If .Items.Count > 0 Then
        '            ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
        '        Else
        '            .Items.Add(New ListItem("No Broker", ""))
        '            'lblBroker.Text = ""
        '        End If

        '    End With 'ddlBrokerCode

        'End Sub

#End Region

    End Class 'rvLoadStatusDriver

End Namespace 'bhattji.Modules.LoadSheets
