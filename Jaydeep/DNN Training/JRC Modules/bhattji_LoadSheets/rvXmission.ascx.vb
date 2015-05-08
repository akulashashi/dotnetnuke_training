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

    Public MustInherit Class rvXmission
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

            ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/Xmission.rdlc")
            'Dim dt As New DataTable
            'If IsPostBack Then
            '    dt = (New LoadSheetsController).GetReportXmission(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, "", ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
            'Else
            '    dt = (New LoadSheetsController).GetReportXmission(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, ddlXmissionFile.SelectedValue, ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
            'End If
            Dim dt As DataTable = (New LoadSheetsController).GetReportXmission(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, ddlXmissionFile.SelectedValue, ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)

            Dim ReportDataSource1 As New ReportDataSource("DataSet1_DataTable1", dt)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            ' Create the prmCopyright ReportParameter 
            Dim prmCopyright As New ReportParameter("prmCopyright", "Copyrighted by JRC Transportation")
            'prmCopyright.Name = "prmCopyright"; 
            'prmCopyright.Values.Add("Copyrighted by Jaydeep Bhatt"); 
            ' Create the prmCopyright ReportParameter 
            'Dim prmCompanyName As New ReportParameter("prmCompanyName", "Xmission File: " + ddlXmissionFile.SelectedItem.Text)
            Dim prmCompanyName As New ReportParameter("prmCompanyName", ddlJRCIOfficeCode.SelectedItem.Text + ": " + ddlXmissionFile.SelectedItem.Text)
            Dim strXmissionDate As String = ""
            If ddlXmissionFile.SelectedIndex > 0 Then
                strXmissionDate = "Xmission Date: " + CType(dt.Rows(0)("XMissionDate"), DateTime).ToShortDateString
            End If
            Dim prmXmisionDate As New ReportParameter("prmXmisionDate", strXmissionDate)

            ' Set the report parameters for the report 
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {prmCopyright, prmCompanyName, prmXmisionDate})
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
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (LoginName = "") Then
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

        Private Sub BindUnXmit()

            With ddlXmissionFile
                .Items.Clear()
                .DataTextField = "XmissionFile"
                .DataValueField = "XmissionFile"
                '.DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems)
                .DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems, txtFrom.Text, txtTo.Text)
                .DataBind()
                .Items.Insert(0, New ListItem("<All Xmitted>", ""))
            End With 'ddlXmissionFile


            ''Dim valfld, txtfld As String
            'Dim valfld As String
            'Dim dr As IDataReader = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, XmissionFile, 25)
            'With ddlXmissionFile
            '    .Items.Clear()
            '    .Items.Add(New ListItem("<WIP Xmission>"))
            '    'If dr("XmissionFile").ToString <> String.Empty Then
            '    While dr.Read
            '        valfld = dr("XmissionFile").ToString
            '        'txtfld = dr("XmissionFile").ToString
            '        '.Items.Add(New ListItem(txtfld.ToUpper, valfld))
            '        .Items.Add(New ListItem(valfld))
            '    End While
            '    'tdUnXmission.Visible = True
            '    'tdXmission.Visible = False
            '    'Else
            '    '.Items.Clear()
            '    '.Items.Add(New ListItem("<WIP Xmission>"))
            '    'tdUnXmission.Visible = False
            '    'tdXmission.Visible = True
            '    'End If
            'End With 'ddlXmissionFile

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
                hyprvXmission.NavigateUrl = EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


                If Not Page.IsPostBack Then
                    'Removed this filter to get all the files in the list without the initial data filter
                    If (Not Request.QueryString("FromDate") Is Nothing) AndAlso (Request.QueryString("FromDate") <> "") Then
                        txtFrom.Text = Request.QueryString("FromDate")
                    Else
                        txtFrom.Text = Now.AddMonths(-6).ToShortDateString
                    End If
                    If (Not Request.QueryString("ToDate") Is Nothing) AndAlso (Request.QueryString("ToDate") <> "") Then
                        txtTo.Text = Request.QueryString("ToDate")
                    Else
                        txtTo.Text = Now.ToShortDateString
                    End If
                    tdNoOfItems.Visible = objOI.ShowNoOfItems
                    txtNoOfItems.Text = objOI.rptNoOfItems.ToString
                    BindUserIOs()
                    BindUnXmit()
                    If (Not Request.QueryString("JRCIOfficeCode") Is Nothing) AndAlso (Request.QueryString("JRCIOfficeCode") <> "") Then
                        ddlJRCIOfficeCode.SelectedValue = Request.QueryString("JRCIOfficeCode")
                    End If
                    If Not String.IsNullOrEmpty(Request.QueryString("XmissionFile")) Then
                        Try
                            If ddlXmissionFile.Items.IndexOf(ddlXmissionFile.Items.FindByValue(Request.QueryString("XmissionFile"))) > -1 Then
                                ddlXmissionFile.SelectedValue = Request.QueryString("XmissionFile")
                            End If
                        Catch
                        End Try
                    End If
                    If (Not Request.QueryString("LoadStatus") Is Nothing) AndAlso (Request.QueryString("LoadStatus") <> "") Then
                        ddlLoadStatus.SelectedValue = Request.QueryString("LoadStatus")
                    End If

                    'BindSearchData()
                    btnSearch_Click(Nothing, Nothing)
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            If IsPostBack Then ddlXmissionFile.ClearSelection()
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Protected Sub ddlXmissionFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlXmissionFile.SelectedIndexChanged
            Dim str As String = ddlXmissionFile.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            Try
                If ddlXmissionFile.Items.IndexOf(ddlXmissionFile.Items.FindByValue(str)) > -1 Then
                    ddlXmissionFile.SelectedValue = str
                End If
            Catch
            End Try
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

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            RunReport()
            BindUnXmit()
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        Private Sub ddlSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSort.SelectedIndexChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub chkSortDesc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSortDesc.CheckedChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub txtFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged, txtTo.TextChanged
            If IsPostBack Then ddlXmissionFile.ClearSelection()
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "rvXmission", "Reports", "dnnprintmode=true") & "?LoadStatus=" & ddlLoadStatus.SelectedValue & "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Dim strUrl As String = EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text)
            If ddlJRCIOfficeCode.SelectedValue <> "" AndAlso ddlJRCIOfficeCode.SelectedValue <> "000000000" Then
                strUrl &= "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue
            End If
            If ddlLoadStatus.SelectedValue <> "" Then
                strUrl &= "&LoadStatus=" & ddlLoadStatus.SelectedValue
            End If

            strUrl &= "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "','ReportXmission', 'location=0,toolbar=1,resizable=1,scrollbars=1,status=1');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print('" & strUrl & "','ReportXmission', 'location=0,resizable=1,scrollbars=1,status=1');</script>")
        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            ''txtNoOfItems.Text = "0"
            ''gdvViewList.AllowPaging = False
            ''ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            ''If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            ''Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))

            Dim strFileName As String = Server.MapPath("~/Documentation/Xmission.PDF")
            'First delete existing file
            System.IO.File.Delete(strFileName)
            'Then create new pdf file
            Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim fsFileStream As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
            fsFileStream.Write(bytes, 0, bytes.Length)
            fsFileStream.Close()
            'Write to Browser
            ResponseHelper.Redirect(ResolveUrl("~/Documentation/Xmission.PDF"))
        End Sub
#End Region

    End Class 'rvXmission

End Namespace 'bhattji.Modules.LoadSheets
