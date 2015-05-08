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

    Public MustInherit Class rptReport2Broker
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

        'Private Sub SetTotals()
        '    Try
        '        Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport2Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
        '        'Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport2Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text) ', rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
        '        If (Not dr Is Nothing) AndAlso dr.Read Then
        '            With gdvViewList.FooterRow
        '                .Cells(6).Text = String.Format("{0:0.00}", dr("LoadMileageTotal"))
        '                .Cells(7).Text = String.Format("{0:0.00}", dr("DRTotDueTotal"))
        '                .Cells(8).Text = String.Format("{0:0.00}", dr("ExTotTotal"))
        '                '.Cells(9).Text = String.Format("{0:0.00}", dr("CalcRateTotal"))
        '                .Cells(10).Text = String.Format("{0:0.00}", dr("ComCheckAmtTotal"))

        '            End With


        '        End If

        '    Catch 'exc As Exception    'Module failed to RowCreated
        '        '    ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

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
                hypReport2Broker.NavigateUrl = EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")

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
                    If (Not Request.QueryString("BrokerCode") Is Nothing) AndAlso (Request.QueryString("BrokerCode") <> "") Then
                        ddlBrokerCode.Items.Insert(0, Request.QueryString("BrokerCode"))
                        ddlBrokerCode.SelectedValue = Request.QueryString("BrokerCode")
                    End If
                    'BindSearchData()
                    'rblLoadType_SelectedIndexChanged(Nothing, Nothing)
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

            e.InputParameters("Status") = rblStatus.SelectedValue
            e.InputParameters("SearchText") = txtCustomerNumber.Text 'txtSearch.Text

            e.InputParameters("LoadType") = "BK" 'rblLoadType.SelectedValue

            'If rblLoadType.SelectedValue = "BK" Then
            '    e.InputParameters("CarrierCode") = ddlBrokerCode.SelectedValue
            'Else '"OO"
            '    e.InputParameters("CarrierCode") = ddlDriverCode.SelectedValue
            'End If
            e.InputParameters("CarrierCode") = ddlBrokerCode.SelectedValue

            'Following Line was remarked, I guess we need to pass some value here
            e.InputParameters("SearchOn") = "Any" 'rblSearchOn.SelectedValue

            e.InputParameters("FromDate") = txtFrom.Text
            e.InputParameters("ToDate") = txtTo.Text

            e.InputParameters("StartsWith") = (rblSearchType.SelectedIndex < 1).ToString
            e.InputParameters("NoOfItems") = txtNoOfItems.Text 'objOI.NoOfItems.ToString


            e.InputParameters("ModuleId") = ModuleId.ToString
            e.InputParameters("PortalId") = PortalId.ToString
            e.InputParameters("GetItems") = objOI.GetItems.ToString
        End Sub

        'Private Sub gdvViewList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowCreated
        '    Try
        '        If e.Row.RowType = DataControlRowType.Header Then
        '            Dim hypAddItem As HyperLink = CType(e.Row.FindControl("hypAddItem"), HyperLink)
        '            If Not hypAddItem Is Nothing Then
        '                With hypAddItem
        '                    .Visible = IsEditable
        '                    If .Visible Then
        '                        .NavigateUrl = EditUrl()
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypAddItem
        '            End If

        '            Dim lblLoadTypeHead As Label = CType(e.Row.FindControl("lblLoadTypeHead"), Label)
        '            If Not lblLoadTypeHead Is Nothing Then
        '                With lblLoadTypeHead
        '                    Select Case rblSearchOn.SelectedValue.ToUpper 'CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
        '                        Case "IO"
        '                            .Text = "InterOffice"
        '                            .ToolTip = "JRCIOCode"
        '                        Case "BK"
        '                            .Text = "BrokerName"
        '                            .ToolTip = "BrokerCode"
        '                        Case "OO"
        '                            .Text = "DriverName"
        '                            .ToolTip = "DriverCode"
        '                        Case Else
        '                            .Text = "Name"
        '                            .ToolTip = "Code"
        '                    End Select
        '                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                End With  'lblLoadTypeHead
        '            End If
        '        End If
        '    Catch exc As Exception    'Module failed to RowCreated
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

        Private Sub gdvViewList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowCreated

            Try
                If e.Row.RowType = DataControlRowType.Footer Then
                    'Dim dr As IDataReader = (New Business.LoadSheetsController).GetReport1Totals(ddlJRCIOfficeCode.SelectedValue, txtSearch.Text) ', rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 2), CType(txtNoOfItems.Text, Integer), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
                    'If (Not dr Is Nothing) AndAlso dr.Read Then
                    With e.Row
                        '.Cells(0).Text = "Records<br />" & String.Format("{0:#,#}", LoadSheetsController.TotalRecords) 'LoadSheetsController.TotalRecords.ToString
                        .Cells(8).Text = "Miles<br />" & String.Format("{0:#,#}", LoadSheetsController.LoadMileageTotal)
                        .Cells(9).Text = "Carrier $<br />" & String.Format("{0:n}", LoadSheetsController.DRTotDueTotal)
                        .Cells(10).Text = "Ded $<br />" & String.Format("{0:n}", LoadSheetsController.ExTotTotal)
                        .Cells(13).Text = "Check Amt<br />" & String.Format("{0:n}", LoadSheetsController.ComCheckAmtTotal)

                    End With


                    'End If
                End If
            Catch exc As Exception    'Module failed to RowCreated
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub gdvViewList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim hypCopyLoad As HyperLink = CType(e.Row.FindControl("hypCopyLoad"), HyperLink)
                    Dim hypEditItem As HyperLink = CType(e.Row.FindControl("hypEditItem"), HyperLink)
                    'Dim hypThumb As HyperLink = CType(e.Row.FindControl("hypThumb"), HyperLink)
                    Dim hypEditAcct As HyperLink = CType(e.Row.FindControl("hypEditAcct"), HyperLink)
                    Dim hypLoadReport As HyperLink = CType(e.Row.FindControl("hypLoadReport"), HyperLink)
                    Dim hypPrintLoadReport As HyperLink = CType(e.Row.FindControl("hypPrintLoadReport"), HyperLink)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    Dim lblLoadStatus As Label = CType(e.Row.FindControl("lblLoadStatus"), Label)
                    Dim lblLoadTypeName As Label = CType(e.Row.FindControl("lblLoadTypeName"), Label)
                    'Dim lblLoadTypeCode As Label = CType(e.Row.FindControl("lblLoadTypeCode"), Label)
                    Dim lblPerMile As Label = CType(e.Row.FindControl("lblPerMile"), Label)

                    If Not lblPerMile Is Nothing Then
                        Try
                            If CType(DataBinder.Eval(e.Row.DataItem, "LoadMileage"), Integer) > 0 Then
                                Dim DRTotDue As Double = 0
                                Dim LoadMileage As Integer = 0

                                Try
                                    DRTotDue = CType(DataBinder.Eval(e.Row.DataItem, "DRTotDue"), Double)
                                Catch
                                End Try

                                Try
                                    LoadMileage = CType(DataBinder.Eval(e.Row.DataItem, "LoadMileage"), Integer)
                                Catch
                                End Try

                                lblPerMile.Text = String.Format("{0:n}", DRTotDue / LoadMileage)
                            Else
                                lblPerMile.Text = ""
                            End If
                        Catch
                            lblPerMile.Text = ""
                        End Try
                    End If

                    If Not lblLoadStatus Is Nothing Then
                        Try
                            lblLoadStatus.Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).Substring(0, 3)
                            lblLoadStatus.Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).Substring(0, 4)
                        Catch
                        End Try
                    End If

                    If Not hypEditItem Is Nothing Then
                        With hypEditItem
                            .Visible = IsEditable AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'AndAlso (lblLoadStatus.Text <> "COMP")
                            If .Visible Then
                                If lblLoadStatus.Text = "COMP" Then
                                    .ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    .Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    .Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    '.ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                Else
                                    .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                    .ToolTip = Localization.GetString("Edit")
                                End If
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditItem
                    End If

                    If Not hypCopyLoad Is Nothing Then
                        With hypCopyLoad
                            .Visible = IsEditable AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y")
                            If .Visible Then
                                .NavigateUrl = EditUrl("FromLoadId", CType(DataBinder.Eval(e.Row.DataItem, "LoadId"), String), "Edit", "OType=CopyLoad")
                                .ToolTip = Localization.GetString("copy_load", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypCopyLoad
                    End If

                    If Not imbDelete Is Nothing Then
                        With imbDelete
                            .Visible = IsEditable AndAlso objOI.DeleteFromGrid AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y")
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                            End If
                        End With  'imbDelete
                    End If

                    'If Not hypThumb Is Nothing Then
                    '    With hypThumb
                    '        .Visible = (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
                    '        If .Visible Then

                    '            .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ItemDetails", "Item=LoadSheet")
                    '            .ToolTip = "View Details"
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With 'hypThumb
                    'End If

                    If Not lblLoadTypeName Is Nothing Then
                        With lblLoadTypeName
                            Select Case CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
                                Case "IO"
                                    Dim Office As String = Replace(CType(DataBinder.Eval(e.Row.DataItem, "IOName"), String), "JRC - ", "")
                                    Office = Replace(Office, "JRC ", "")
                                    .Text = Office.ToUpper
                                    .ToolTip = "JRCIOCode: " & CType(DataBinder.Eval(e.Row.DataItem, "JRCIOCode"), String)
                                Case "BK"
                                    .Text = CType(DataBinder.Eval(e.Row.DataItem, "BrokerName"), String)
                                    .ToolTip = "BrokerCode: " & CType(DataBinder.Eval(e.Row.DataItem, "BrokerCode"), String)
                                Case Else '"OO"
                                    .Text = CType(DataBinder.Eval(e.Row.DataItem, "DriverName"), String)
                                    .ToolTip = "DriverCode: " & CType(DataBinder.Eval(e.Row.DataItem, "DriverCode"), String)
                            End Select
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblLoadTypeName
                    End If

                    If Not hypEditAcct Is Nothing Then
                        With hypEditAcct
                            .Visible = IsEditable AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'AndAlso (lblLoadStatus.Text.ToUpper <> "COMP")
                            If .Visible Then
                                If lblLoadStatus.Text = "COMP" Then
                                    .ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    .Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    .Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    '.ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                    '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ComCheck", "Item=ComCheckLoad")
                                Else
                                    .ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                    .NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                End If
                                '.ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                '.NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    If Not hypLoadReport Is Nothing Then
                        With hypLoadReport
                            .Visible = True
                            If .Visible Then
                                .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
                                .Target = "_blank"
                                .ToolTip = Localization.GetString("LoadReport", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    'If Not hypPrintLoadReport Is Nothing Then
                    '    With hypPrintLoadReport
                    '        Dim strLoadType As String = CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
                    '        .Visible = (strLoadType = "OO") OrElse (strLoadType = "BK")
                    '        If .Visible Then
                    '            '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                    '            .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType)
                    '            .Target = "_blank"
                    '            Select Case strLoadType
                    '                Case "OO"
                    '                    .ToolTip = "Driver Confirm"
                    '                Case "BK"
                    '                    .ToolTip = "Broker Confirm"
                    '                    'Case "IO"
                    '                    '    .ToolTip = "IO Confirm"
                    '                    'Case Else '"OO"
                    '                    '    .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                    '            End Select
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With  'hypEditAcct
                    'End If

                    If Not hypPrintLoadReport Is Nothing Then
                        With hypPrintLoadReport
                            .Visible = True
                            If .Visible Then
                                .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
                                .Target = "_blank"
                                .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            btnSearch_Click(Nothing, Nothing)
        End Sub

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

        'Private Sub ddlCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategories.SelectedIndexChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true") & "?BrokerCode=" & ddlBrokerCode.SelectedValue & "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Dim strUrl As String = EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text)
            If ddlJRCIOfficeCode.SelectedValue <> "" AndAlso ddlJRCIOfficeCode.SelectedValue <> "000000000" Then
                strUrl &= "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue
            End If
            If ddlLoadStatus.SelectedValue <> "" Then
                strUrl &= "&LoadStatus=" & ddlLoadStatus.SelectedValue
            End If
            If ddlBrokerCode.SelectedValue <> "" AndAlso ddlBrokerCode.SelectedValue <> "0000000" Then
                strUrl &= "&BrokerCode=" & ddlBrokerCode.SelectedValue
            End If

            strUrl &= "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "','rptReport2Broker', 'location=0,toolbar=1,resizable=1,scrollbars=1,status=1');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print('" & strUrl & "','rptReport2Broker', 'location=0,resizable=1,scrollbars=1,status=1');</script>")

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

        'Private Sub btnDriverSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDriverSearch.Click
        '    With ddlDriverCode
        '        'Dim txt As String = "" '= .Items(0).Text '.SelectedItem.Text
        '        'Dim val As String = "" '= .Items(0).Value '.SelectedValue
        '        'If .Items.Count > 0 Then
        '        '    txt = .Items(0).Text  '.SelectedItem.Text
        '        '    val = .Items(0).Value  '.SelectedValue
        '        'End If

        '        ''.DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
        '        'If rblOfficeVendorNO.SelectedIndex > -1 Then
        '        '    .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO(txtDriverName.Text, rblOfficeVendorNO.SelectedValue, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
        '        'Else
        '        '    .DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
        '        'End If
        '        .Items.Clear()
        '        .DataValueField = "DriverCode"
        '        .DataTextField = "DriverName"
        '        If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") AndAlso (ddlJRCIOfficeCode.SelectedValue <> "000000000") Then
        '            .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO2(txtDriverCode.Text, ddlJRCIOfficeCode.SelectedValue)
        '        Else
        '            .DataSource = (New Business.LoadSheetsController).GetDriverSearch2(txtDriverCode.Text)
        '        End If
        '        .DataBind()

        '        ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
        '        'If val <> "" Then .Items.Insert(0, (New ListItem(txt, val)))
        '        ''If (val <> String.Empty) AndAlso (Not ((.Items.Count > 0) AndAlso (val = .Items(0).Value))) Then .Items.Insert(0, (New ListItem(txt, val)))
        '        'If (val <> String.Empty) Then
        '        '    If ((.Items.Count = 0) OrElse (.Items(0).Value <> val)) Then
        '        '        .Items.Insert(0, (New ListItem(txt, val)))
        '        '    End If
        '        'End If
        '        'If val <> "" Then
        '        '    .Items.Insert(0, (New ListItem(txt, val)))
        '        '    If (.Items.Count > 1) Then
        '        '        If (.Items(0).Value = .Items(1).Value) Then
        '        '            .Items.RemoveAt(0)
        '        '        End If
        '        '    End If
        '        'End If
        '        'Try
        '        'Catch
        '        'End Try

        '        If .Items.Count < 1 Then
        '            .Items.Insert(0, (New ListItem("<All Drivers>", "")))
        '        End If
        '        txtDriverCode.Text = .SelectedValue
        '    End With 'ddlDriverName

        '    btnSearch_Click(Nothing,Nothing)
        'End Sub


        'Private Sub ddlDriverCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDriverCode.SelectedIndexChanged
        '    'Dim dr As IDataReader = (New Business.LoadSheetsController).GetBrokerByCode(ddlBrokerCode.SelectedValue)
        '    'If Not dr Is Nothing Then
        '    '    dr.Read()
        '    '    lblBroker.Text = "<br />Status: "
        '    '    If dr("BStatus").ToString.ToUpper = "ACTIVE" Then
        '    '        lblBroker.Text &= "<font color='green'>ACTIVE</font><br />"
        '    '    Else
        '    '        lblBroker.Text &= "<font color='red'>INACTIVE</font><br />"
        '    '    End If

        '    '    If dr("ContactCode").ToString <> String.Empty Then lblBroker.Text &= dr("ContactCode").ToString & ", "
        '    '    lblBroker.Text &= "Phone: " & dr("PhoneNo").ToString
        '    '    lblBroker.Text &= "<br />"

        '    '    If dr("AddressLine1").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine1").ToString & "<br />"
        '    '    If dr("AddressLine2").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine2").ToString & "<br />"

        '    '    lblBroker.Text &= dr("City").ToString & ", "
        '    '    lblBroker.Text &= dr("State").ToString & " "
        '    '    lblBroker.Text &= dr("ZipCode").ToString

        '    'End If 'Not dr Is Nothing Then

        '    txtDriverCode.Text = ddlDriverCode.SelectedValue
        '    ' txtBrokerCode.Text = ddlBrokerCode.SelectedItem.Text
        'End Sub


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

        Private Sub btnBrokerSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCode
                'Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                'Dim val As String '= .Items(0).Value '.SelectedValue
                'If .Items.Count > 0 Then
                '    txt = .Items(0).Text  '.SelectedItem.Text
                '    val = .Items(0).Value  '.SelectedValue
                'End If

                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataSource = (New Business.LoadSheetsController).GetBrokerSearch2(txtBrokerCode.Text, rblStatus.SelectedItem.Text)

                'If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") AndAlso (ddlJRCIOfficeCode.SelectedValue <> "000000000") Then
                '    .DataSource = (New Business.LoadSheetsController).GetBrokerSearchByIO2(txtBrokerCode.Text, ddlJRCIOfficeCode.SelectedValue)
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetBrokerSearch2(txtBrokerCode.Text)
                'End If

                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count < 1 Then
                    .Items.Add(New ListItem("<All Brokers>", ""))
                    'lblBroker.Text = ""
                End If
                txtBrokerCode.Text = "" '.SelectedValue
            End With 'ddlBrokerCode

            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub ddlBrokerCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBrokerCode.SelectedIndexChanged
            'Dim dr As IDataReader = (New Business.LoadSheetsController).GetBrokerByCode(ddlBrokerCode.SelectedValue)
            'If Not dr Is Nothing Then
            '    dr.Read()
            '    lblBroker.Text = "<br />Status: "
            '    If dr("BStatus").ToString.ToUpper = "ACTIVE" Then
            '        lblBroker.Text &= "<font color='green'>ACTIVE</font><br />"
            '    Else
            '        lblBroker.Text &= "<font color='red'>INACTIVE</font><br />"
            '    End If

            '    If dr("ContactCode").ToString <> String.Empty Then lblBroker.Text &= dr("ContactCode").ToString & ", "
            '    lblBroker.Text &= "Phone: " & dr("PhoneNo").ToString
            '    lblBroker.Text &= "<br />"

            '    If dr("AddressLine1").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine1").ToString & "<br />"
            '    If dr("AddressLine2").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine2").ToString & "<br />"

            '    lblBroker.Text &= dr("City").ToString & ", "
            '    lblBroker.Text &= dr("State").ToString & " "
            '    lblBroker.Text &= dr("ZipCode").ToString

            'End If 'Not dr Is Nothing Then

            txtBrokerCode.Text = "" 'ddlBrokerCode.SelectedValue
            ' txtBrokerCode.Text = ddlBrokerCode.SelectedItem.Text
            'btnBrokerSearch_Click(Nothing,Nothing)
            btnSearch_Click(Nothing, Nothing)

        End Sub

        Private Sub rblStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblStatus.SelectedIndexChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        'Private Sub rblLoadType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblLoadType.SelectedIndexChanged
        '    tblDriver.Visible = (rblLoadType.SelectedValue.ToUpper = "OO")
        '    tblBroker.Visible = (rblLoadType.SelectedValue.ToUpper = "BK")

        '    btnSearch_Click(Nothing, Nothing)
        'End Sub


#End Region

    End Class 'rptReport2Broker

End Namespace 'bhattji.Modules.LoadSheets
