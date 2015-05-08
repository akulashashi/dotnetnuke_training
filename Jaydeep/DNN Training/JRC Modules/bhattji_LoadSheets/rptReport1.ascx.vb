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

    Public MustInherit Class rptReport1
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private objOI As OptionsInfo

#End Region

#Region " Methods "


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

        Sub SetGridView()
            With gdvViewList
                .PageSize = objOI.PagerSize
                .AllowPaging = False 'objOI.PagerSize > 0
                '.Columns(.Columns.Count - 1).Visible = IsEditable 'Remove the last column if the User is not Admin
                .Columns(0).Visible = IsEditable 'Remove the First column if the User is not Admin

                If objOI.BackColor <> String.Empty Then
                    Try
                        .RowStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(objOI.BackColor), Drawing.Color)
                    Catch
                    End Try
                End If
                If objOI.AltColor <> String.Empty Then
                    Try
                        .AlternatingRowStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(objOI.AltColor), Drawing.Color)
                    Catch
                    End Try
                End If

                If objOI.HeaderBackColor <> String.Empty Then
                    Try
                        .HeaderStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(objOI.HeaderBackColor), Drawing.Color)
                        .FooterStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(objOI.HeaderBackColor), Drawing.Color)
                    Catch
                    End Try
                End If
                If objOI.PagerBackColor <> String.Empty Then
                    Try
                        .PagerStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(objOI.PagerBackColor), Drawing.Color)
                    Catch
                    End Try
                End If
            End With 'gdvViewList

        End Sub

        Sub ResetViewStates()
            ViewState.Remove("odsLoadSheets")
            ViewState.Remove("gdvViewList")
            odsLoadSheets.DataBind()
            gdvViewList.DataBind()
            'SetTotals()
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
                SetGridView()

                'this needs to execute always to the client script code is registred in InvokePopupCal
                hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)
                'hypReport1.NavigateUrl = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


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
                    'BindSearchData()
                End If

                If (Not Request.QueryString("SkinSrc") Is Nothing) AndAlso (Request.QueryString("SkinSrc") <> "") Then
                    txtNoOfItems.Text = "0"
                    gdvViewList.AllowPaging = False
                    ResetViewStates()
                    tblSearch.Visible = False 'not tblSearch.Visible
                    'If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
                    Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub odsLoadSheets_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadSheets.Selecting

            If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") Then
                e.InputParameters("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue()
            Else
                e.InputParameters("JRCIOfficeCode") = ""
            End If

            If (Not ddlCustomerNumber.SelectedValue Is Nothing) AndAlso (ddlCustomerNumber.SelectedValue <> "") Then
                e.InputParameters("CustomerNumber") = ddlCustomerNumber.SelectedValue()
            Else
                e.InputParameters("CustomerNumber") = ""
            End If
            If (Not ddlLoadStatus.SelectedValue Is Nothing) Then
                e.InputParameters("LoadStatus") = ddlLoadStatus.SelectedValue()
            Else
                e.InputParameters("LoadStatus") = ""
            End If

            e.InputParameters("SearchText") = txtCustomerNumber.Text 'txtSearch.Text
            e.InputParameters("SearchOn") = rblSearchOn.SelectedValue
            e.InputParameters("FromDate") = txtFrom.Text
            e.InputParameters("ToDate") = txtTo.Text

            e.InputParameters("StartsWith") = (rblSearchType.SelectedIndex < 1).ToString
            e.InputParameters("NoOfItems") = txtNoOfItems.Text 'objOI.NoOfItems.ToString


            e.InputParameters("ModuleId") = ModuleId.ToString
            e.InputParameters("PortalId") = PortalId.ToString
            e.InputParameters("GetItems") = objOI.GetItems.ToString
        End Sub

        Private Sub gdvViewList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowCreated
            Try
                If e.Row.RowType = DataControlRowType.Footer Then
                    'Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport1Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text) ', rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
                    'If (Not dr Is Nothing) AndAlso dr.Read Then
                    With e.Row
                        '' .Cells(0).Text = "Records<br />" & String.Format("{0:#,#}", LoadSheetsController.TotalRecords) 'LoadSheetsController.TotalRecords.ToString
                        '.Cells(2).Text = "Billing<br />" & String.Format("{0:n}", LoadSheetsController.BBaseLoadTotal)
                        '.Cells(3).Text = "Rep<br />" & String.Format("{0:n}", LoadSheetsController.RepDlrTotal)
                        '.Cells(4).Text = "Carrier<br />" & String.Format("{0:n}", LoadSheetsController.DRTotDueTotal)
                        ''.Cells(5).Text = String.Format("{0:0.00}", dr("IOOffL1Total"))
                        '.Cells(6).Text = "IO $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.IOCommTotTotal)
                        ''.Cells(7).Text = String.Format("{0:0.00}", dr("IOOffN3Total"))
                        '.Cells(8).Text = "Mgr $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.IOComm3Total)
                        '.Cells(9).Text = "Office $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.JRCOffCommTotal)
                        '.Cells(10).Text = "JRC Total<br />" & String.Format("{0:n}", LoadSheetsController.JRCTotalTotal)

                        ' .Cells(0).Text = "Records<br />" & String.Format("{0:#,#}", LoadSheetsController.TotalRecords) 'LoadSheetsController.TotalRecords.ToString
                        .Cells(3).Text = "Billing<br />" & String.Format("{0:n}", LoadSheetsController.BBaseLoadTotal)
                        .Cells(4).Text = "Rep<br />" & String.Format("{0:n}", LoadSheetsController.RepDlrTotal)
                        .Cells(5).Text = "Carrier<br />" & String.Format("{0:n}", LoadSheetsController.DRTotDueTotal)
                        '.Cells(5).Text = String.Format("{0:0.00}", dr("IOOffL1Total"))
                        .Cells(7).Text = "IO $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.IOCommTotTotal)
                        '.Cells(7).Text = String.Format("{0:0.00}", dr("IOOffN3Total"))
                        .Cells(9).Text = "Mgr $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.IOComm3Total)
                        .Cells(10).Text = "Office $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.JRCOffCommTotal)
                        .Cells(11).Text = "JRC Total<br />" & String.Format("{0:n}", LoadSheetsController.JRCTotalTotal)

                    End With


                    'End If
                End If
            Catch exc As Exception    'Module failed to RowCreated
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'Private Sub SetTotals()
        '    Try

        '        Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport1Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
        '        'Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport1Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
        '        If (Not dr Is Nothing) AndAlso dr.Read Then
        '            With gdvViewList.FooterRow
        '                .Cells(2).Text = String.Format("{0:0.00}", dr("BBaseLoadTotal"))
        '                .Cells(3).Text = String.Format("{0:0.00}", dr("RepDlrTotal"))
        '                .Cells(4).Text = String.Format("{0:0.00}", dr("DRTotDueTotal"))
        '                '.Cells(5).Text = String.Format("{0:0.00}", dr("IOOffL1Total"))
        '                .Cells(6).Text = String.Format("{0:0.00}", dr("IOCommTotTotal"))
        '                '.Cells(7).Text = String.Format("{0:0.00}", dr("IOOffN3Total"))
        '                .Cells(8).Text = String.Format("{0:0.00}", dr("IOComm3Total"))
        '                .Cells(9).Text = String.Format("{0:0.00}", dr("JRCOffCommTotal"))
        '                .Cells(10).Text = String.Format("{0:0.00}", dr("JRCTotalTotal"))
        '            End With


        '        End If

        '    Catch exc As Exception    'Module failed to RowCreated
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

        'Private Sub gdvViewList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowDataBound
        '    Try
        '        If e.Row.RowType = DataControlRowType.Footer Then
        '            'Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport1Totals(ddlJRCIOfficeCode.SelectedValue, ModuleId, PortalId, CType(txtNoOfItems.Text, Integer))
        '            'If dr.read Then
        '            '    e.Row.Cells(2).Text = dr("BBaseLoadTotal").ToString


        '            'End If
        '            e.Row.Cells(2).Text = "BBaseLoadTotal"
        '        End If
        '    Catch exc As Exception    'Module failed to RowDataBound
        '        ProcessModuleLoadException(Me, exc)
        '    End Try

        'End Sub

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

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub
        'Protected Sub ddlOOSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlOOSearch.SelectedIndexChanged
        '    btnSearch_Click(Nothing,Nothing)
        'End Sub
        'Private Sub btnOOSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '    'BindSearchData()
        '    ResetViewStates()
        'End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            ' txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            'Dim strUrl As String = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true") & "?JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"


            Dim strUrl As String = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text)
            If ddlJRCIOfficeCode.SelectedValue <> "" AndAlso ddlJRCIOfficeCode.SelectedValue <> "000000000" Then
                strUrl &= "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue
            End If
            If ddlLoadStatus.SelectedValue <> "" Then
                strUrl &= "&LoadStatus=" & ddlLoadStatus.SelectedValue
            End If

            strUrl &= "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "','rptReport1', 'location=0,toolbar=1,resizable=1,scrollbars=1,status=1');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "');</script>")
            'ResponseHelper.Redirect(strUrl, "rptReport1", "location=0,resizable=1,scrollbars=1,status=1")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print('" & strUrl & "','rptReport1', 'location=0,resizable=1,scrollbars=1,status=1');</script>")

        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            tblSearch.Visible = False 'not tblSearch.Visible
            'If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))
        End Sub

#End Region

    End Class 'rptReport1

End Namespace 'bhattji.Modules.LoadSheets
