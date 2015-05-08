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

    Public MustInherit Class rptXmission
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

        Private Sub BindUnXmit()

            With ddlXmissionFile
                .Items.Clear()
                .DataTextField = "XmissionFile"
                .DataValueField = "XmissionFile"
                '.DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems)
                .DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems, txtFrom.Text, txtTo.Text)
                .DataBind()
                .Items.Insert(0, New ListItem("<All Xmitted Loads>", ""))
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
                hyprptXmission.NavigateUrl = EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


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
                    BindUnXmit()
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

            If (Not ddlXmissionFile.SelectedValue Is Nothing) AndAlso (ddlXmissionFile.SelectedValue <> "") Then
                e.InputParameters("XmissionFile") = ddlXmissionFile.SelectedValue()
            Else
                e.InputParameters("XmissionFile") = ""
            End If

            If (Not ddlLoadStatus.SelectedValue Is Nothing) Then
                e.InputParameters("LoadStatus") = ddlLoadStatus.SelectedValue()
            Else
                e.InputParameters("LoadStatus") = ""
            End If

            'e.InputParameters("LoadStatus") = ddlLoadStatus.SelectedValue
            e.InputParameters("SearchText") = txtCustomerNumber.Text 'txtSearch.Text

            e.InputParameters("SortOn") = "LoadDate"
            e.InputParameters("SortDesc") = True

            e.InputParameters("SearchOn") = rblSearchOn.SelectedValue
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
                        .Cells(0).Text = "Total<br />" & LoadSheetsController.TotalLoadXmited.ToString
                        .Cells(10).Text = "Billing $<br />" & String.Format("{0:n}", LoadSheetsController.BCustBillTotal)
                        .Cells(11).Text = "Office $ Comm<br />" & String.Format("{0:n}", LoadSheetsController.JRCOffCommTotal)
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
                    Dim lblIOOffL1 As Label = CType(e.Row.FindControl("lblIOOffL1"), Label)
                    Dim hypLoadID As HyperLink = CType(e.Row.FindControl("hypLoadID"), HyperLink)

                    If Not hypLoadID Is Nothing Then
                        Try
                            With hypLoadID
                                If Not Null.IsNull(DataBinder.Eval(e.Row.DataItem, "LoadID")) Then
                                    .Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String)
                                    .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                    '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "LoadItemID"), String))
                                    'If Not Null.IsNull(DataBinder.Eval(e.Row.DataItem, "ItemID")) Then
                                    '    If (CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).ToUpper = "COMPLETE") OrElse (CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).ToUpper = "VOID") Then
                                    '        '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadItemId"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper)
                                    '        .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadItemId"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper)
                                    '        .Target = "_blank"
                                    '    Else
                                    '        .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                    '        '.Target = "_blank"
                                    '    End If
                                    'End If
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypLoadID
                        Catch
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

                    'If Not lblIOOffL1 Is Nothing Then
                    '    With lblIOOffL1
                    '        If .Visible Then
                    '            .Text = CType(DataBinder.Eval(e.Row.DataItem, "IOOffL1"), String).ToUpper 
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With 'lblRepDollar
                    'End If


                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Protected Sub ddlXmissionFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlXmissionFile.SelectedIndexChanged
            Dim str As String = ddlXmissionFile.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            ddlXmissionFile.SelectedValue = str
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
            BindUnXmit()
        End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "rptXmission", "Reports", "dnnprintmode=true") & "?LoadStatus=" & ddlLoadStatus.SelectedValue & "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
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
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            tblSearch.Visible = False 'not tblSearch.Visible
            'If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))
        End Sub

#End Region

    End Class 'rptXmission

End Namespace 'bhattji.Modules.LoadSheets
