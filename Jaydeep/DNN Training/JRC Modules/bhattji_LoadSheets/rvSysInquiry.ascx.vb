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

    Public MustInherit Class rvSysInquiry
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

            ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/SysInquiry.rdlc")

            'Dim dt As DataTable = (New LoadSheetsController).GetSysInquiry(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, ddlLoadStatus.SelectedValue, "Any", False, 1000, txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
            Dim dt As DataTable = (New LoadSheetsController).GetSysInquiry(ddlJRCIOfficeCode.SelectedValue, rblLoadType.SelectedValue, ddlDriverCode.SelectedValue, ddlBrokerCode.SelectedValue, ddlJRCIOCode.SelectedValue, ddlLoadStatus.SelectedValue, ddlCustomerNumber.SelectedValue, txtCustPO.Text, txtProJob.Text, txtBkrInvNo.Text, txtPUCity.Text, txtDPCity.Text, txtFrom.Text, txtTo.Text, txtFrom2.Text, txtTo2.Text, txtFrom3.Text, txtTo3.Text, ModuleId, PortalId, objOI.GetItems)

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
                BindDrivers()
            End With

            'With ddlOOSearch
            '    '.DataTextField = "IOName"
            '    '.DataValueField = "IOfficeCode"
            '    'If LoginName = "" Then
            '    '    .DataSource = (New Business.LoadSheetsController).GetAllInterOffices
            '    'Else
            '    '    .DataSource = (New Business.LoadSheetsController).GetUserIOs(LoginName)
            '    'End If
            '    '.DataBind()

            '    Dim valfld, txtfld As String
            '    Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
            '    If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (LoginName = "") Then
            '        dr = (New Business.LoadSheetsController).GetAllSalesPersons
            '    Else
            '        dr = (New Business.LoadSheetsController).GetUserIOs(LoginName)
            '    End If
            '    .Items.Clear()
            '    While dr.Read
            '        If dr("JRCActive").ToString.ToUpper = "Y" Then
            '            valfld = dr("DriverCode").ToString
            '            txtfld = Replace(dr("DriverName").ToString, "JRC - ", "")
            '            txtfld = Replace(txtfld, "JRC ", "")
            '            .Items.Add(New ListItem(txtfld.ToUpper, valfld))
            '        End If
            '    End While

            '    Try
            '        .Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
            '    Catch
            '    End Try

            'End With
        End Sub

        Private Sub BindUserJRCIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") And Request.IsAuthenticated Then
                LoginName = Users.UserController.GetCurrentUserInfo.Username
            End If
            With ddlJRCIOCode
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

                .Items.Insert(0, New ListItem("<All I/Os>", ""))
                'If .Items.Count > 1 Then
                '    .SelectedIndex = 1
                'End If
            End With

        End Sub

        Private Sub BindDrivers()
            With ddlDriverCode
                .DataSource = (New LoadSheetsController).GetAllSalesPersonsByJRCIOCode(ddlJRCIOfficeCode.SelectedValue)
                .DataValueField = "DriverCode"
                .DataTextField = "DriverName"
                .DataBind()

                .Items.Insert(0, New ListItem("<All Drivers>", ""))
                'If .Items.Count > 1 Then
                '    .SelectedIndex = 1
                'End If
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

                hypCalandarFromDate2.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom2)
                hypCalandarToDate2.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo2)

                hypCalandarFromDate3.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom3)
                hypCalandarToDate3.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo3)
                'hypReport1.NavigateUrl = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


                If Not Page.IsPostBack Then
                    'Removed this filter to get all the files in the list without the initial data filter
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

                    'tdNoOfItems.Visible = objOI.ShowNoOfItems
                    'txtNoOfItems.Text = objOI.rptNoOfItems.ToString

                    BindUserIOs()
                    BindUserJRCIOs()
                    If (Not Request.QueryString("JRCIOfficeCode") Is Nothing) AndAlso (Request.QueryString("JRCIOfficeCode") <> "") Then
                        ddlJRCIOfficeCode.SelectedValue = Request.QueryString("JRCIOfficeCode")
                    End If
                    If (Not Request.QueryString("LoadStatus") Is Nothing) AndAlso (Request.QueryString("LoadStatus") <> "") Then
                        ddlLoadStatus.SelectedValue = Request.QueryString("LoadStatus")
                    End If
                    'BindSearchData()
                    rblLoadType_SelectedIndexChanged(Nothing, Nothing)
                    btnSearch_Click(Nothing, Nothing)
                End If



            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub rblLoadType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblLoadType.SelectedIndexChanged
            tblOO.Visible = rblLoadType.SelectedValue = "OO"
            tblBK.Visible = rblLoadType.SelectedValue = "BK"
            tblIO.Visible = rblLoadType.SelectedValue = "IO"
            If rblLoadType.SelectedValue = "All" Then
                lblLoadType.Text = "Selecting 'ALL'<br/>may result in<br/>excessive data"

                If txtFrom.Text = "" Then txtFrom.Text = Now.AddMonths(-1).ToShortDateString
                If txtTo.Text = "" Then txtTo.Text = Now.ToShortDateString
            End If
        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            BindDrivers()
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub btnCustomerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCustomerSearch.Click
            With ddlCustomerNumber
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerName"
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearchForReports(txtCustomerNumber.Text, ddlJRCIOfficeCode.SelectedValue, True, txtFrom.Text, txtTo.Text)
                .DataBind()

                .Items.Insert(0, New ListItem("<All Customers>", ""))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
                ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
            End With 'ddlBrokerCode
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        Private Sub btnBrokerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCode
                .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "BrokerName", False)
                '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, False)
                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataBind()

                .Items.Insert(0, New ListItem("<All Brokers>", ""))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
                'ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
            End With
        End Sub

        Private Sub ddlBrokerCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrokerCode.SelectedIndexChanged
            txtBrokerCode.Text = "" 'ddlBrokerCode.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub
        'Private Sub txtFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged, txtTo.TextChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub



        Private Sub imbSearchCity_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchCity.Click
            With ddlZipCodes
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtPUCity.Text, "City", txtPUState.Text)
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes_SelectedIndexChanged(Nothing, Nothing)
            End With
        End Sub

        Private Sub imbSearchZipCode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchZipCode.Click
            With ddlZipCodes
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtZipCode.Text, "ZipCode")
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes_SelectedIndexChanged(Nothing, Nothing)
            End With
        End Sub

        Private Sub ddlZipCodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlZipCodes.SelectedIndexChanged
            Try
                Dim objZip As ZipCodeInfo = (New ZipCodesController).GetZipCode(Integer.Parse(ddlZipCodes.SelectedValue))
                txtPUCity.Text = objZip.City
                txtPUState.Text = objZip.StateCode
                txtZipCode.Text = objZip.ZipCode
            Catch
            End Try
        End Sub



        Private Sub imbSearchCity2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchCity2.Click
            With ddlZipCodes2
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtDPCity.Text, "City", txtDPState.Text)
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes2_SelectedIndexChanged(Nothing, Nothing)
            End With
        End Sub

        Private Sub imbSearchZipCode2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchZipCode2.Click
            With ddlZipCodes2
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtZipCode2.Text, "ZipCode")
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes2_SelectedIndexChanged(Nothing, Nothing)
            End With
        End Sub

        Private Sub ddlZipCodes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlZipCodes2.SelectedIndexChanged
            Try
                Dim objZip As ZipCodeInfo = (New ZipCodesController).GetZipCode(Integer.Parse(ddlZipCodes2.SelectedValue))
                txtDPCity.Text = objZip.City
                txtDPState.Text = objZip.StateCode
                txtZipCode2.Text = objZip.ZipCode
            Catch
            End Try
        End Sub

        'Private Sub imbRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbRefresh.Click
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            RunReport()
            ''Open PDF for preview/Print everytime
            'If Page.IsPostBack Then imbPrintSelection_Click(Nothing, Nothing)
        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            ''txtNoOfItems.Text = "0"
            ''gdvViewList.AllowPaging = False
            ''ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            ''If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            ''Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))

            Dim strFileName As String = Server.MapPath("~/Documentation/SysInquiry.PDF")
            'First delete existing file
            System.IO.File.Delete(strFileName)
            'Then create new pdf file
            Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim fsFileStream As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
            fsFileStream.Write(bytes, 0, bytes.Length)
            fsFileStream.Close()
            'Write to Browser
            ResponseHelper.Redirect(ResolveUrl("~/Documentation/SysInquiry.PDF"), "SysInquiry")
        End Sub

#End Region

    End Class 'rvSysInquiry

End Namespace 'bhattji.Modules.LoadSheets