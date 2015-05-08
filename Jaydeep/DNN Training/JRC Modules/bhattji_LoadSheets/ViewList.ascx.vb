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

    Public MustInherit Class ViewList
        Inherits Entities.Modules.PortalModuleBase


#Region " Private Members "

        Private objOI As OptionsInfo

#End Region

#Region " Methods "

        Private Sub BindUserIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") AndAlso Request.IsAuthenticated Then
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
                Dim objLC As New Business.LoadSheetsController
                Dim valfld, txtfld As String
                Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (LoginName = "") Then
                    dr = objLC.GetAllInterOffices
                Else
                    dr = objLC.GetUserIOs(LoginName)
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

                If (Session.Item("JRCIOfficeCode") Is Nothing) OrElse (Session.Item("JRCIOfficeCode").ToString = "") OrElse (Session.Item("JRCIOfficeCode").ToString = "000000000") Then
                    Session.Item("JRCIOfficeCode") = objLC.GetUserDefaultIO(LoginName)
                End If

                Try
                    .Items.FindByValue(Session.Item("JRCIOfficeCode").ToString.Substring(0, 9)).Selected = True
                    SetSearchOn(.SelectedValue)
                Catch
                End Try

                'If Not Session.Item("JRCIOfficeCode") Is Nothing Then Response.Write("IOCode=" & Session.Item("JRCIOfficeCode").ToString.Substring(0, 9))

            End With
        End Sub
        Sub SetSearchOn(ByVal JRCIOfficeCode As String)
            If (New Business.LoadSheetsController).IsBrokerOnlyOffice(JRCIOfficeCode) Then
                'If (Not Page.IsPostBack) AndAlso objLC.IsBrokerOnlyOffice(.SelectedValue) Then
                rblSearchOn.SelectedValue = "BK"
            Else
                rblSearchOn.SelectedValue = "OO"
            End If
        End Sub
        Sub SetGridView()
            With gdvViewList
                .PageSize = objOI.PagerSize
                .AllowPaging = objOI.PagerSize > 0
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
        Private Function ShortenString(ByVal str As String, ByVal len As Integer, Optional ByVal suffix As String = "...") As String
            If (str.Length > len + 1) Then
                Return HtmlUtils.Shorten(str, len, suffix)
            Else
                Return str
            End If
        End Function
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
                'hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                'hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)

                hypReport1.NavigateUrl = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport2Driver.NavigateUrl = EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport2Broker.NavigateUrl = EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport3.NavigateUrl = EditUrl("ReportType", "Report3", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypDriverStatus.NavigateUrl = EditUrl("ReportType", "DriverStatus", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypXmission.NavigateUrl = EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")

                If Not Page.IsPostBack Then
                    BindUserIOs()
                    'BindSearchData()
                    SetProbDrivers()

                    Try
                        rblSearchOn.SelectedValue = Session.Item("SearchOn").ToString
                    Catch
                        rblSearchOn.SelectedValue = "ANY"
                    End Try
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

            If (Not ddlLoadStatus.SelectedValue Is Nothing) Then
                e.InputParameters("LoadStatus") = ddlLoadStatus.SelectedValue()
            Else
                e.InputParameters("LoadStatus") = ""
            End If

            e.InputParameters("SearchText") = txtSearch.Text
            e.InputParameters("SearchOn") = rblSearchOn.SelectedValue
            e.InputParameters("FromDate") = txtFrom.Text
            e.InputParameters("ToDate") = txtTo.Text

            e.InputParameters("StartsWith") = (rblSearchType.SelectedIndex < 1).ToString
            e.InputParameters("Datewise") = chkDatewise.Checked
            e.InputParameters("NoOfItems") = objOI.NoOfItems.ToString


            e.InputParameters("ModuleId") = ModuleId.ToString
            e.InputParameters("PortalId") = PortalId.ToString
            e.InputParameters("GetItems") = objOI.GetItems.ToString
        End Sub

        Private Sub gdvViewList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowCreated
            Try
                If e.Row.RowType = DataControlRowType.Header Then
                    Dim hypAddItem As HyperLink = CType(e.Row.FindControl("hypAddItem"), HyperLink)
                    If Not hypAddItem Is Nothing Then
                        With hypAddItem
                            .Visible = IsEditable
                            If .Visible Then
                                .NavigateUrl = EditUrl()
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypAddItem
                    End If

                    Dim lblLoadTypeHead As Label = CType(e.Row.FindControl("lblLoadTypeHead"), Label)
                    If Not lblLoadTypeHead Is Nothing Then
                        With lblLoadTypeHead
                            Select Case rblSearchOn.SelectedValue.ToUpper 'CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
                                Case "IO"
                                    .Text = "InterOffice"
                                    .ToolTip = "JRCIOCode"
                                Case "BK"
                                    .Text = "BrokerName"
                                    .ToolTip = "BrokerCode"
                                Case "OO"
                                    .Text = "DriverName"
                                    .ToolTip = "DriverCode"
                                Case Else
                                    .Text = "Name"
                                    .ToolTip = "Code"
                            End Select
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblLoadTypeHead
                    End If
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
                    Dim hypPUDrops As HyperLink = CType(e.Row.FindControl("hypPUDrops"), HyperLink)
                    'Dim hypThumb As HyperLink = CType(e.Row.FindControl("hypThumb"), HyperLink)
                    Dim hypEditAcct As HyperLink = CType(e.Row.FindControl("hypEditAcct"), HyperLink)
                    Dim hypLoadReport As HyperLink = CType(e.Row.FindControl("hypLoadReport"), HyperLink)
                    Dim hypPrintLoadReport As HyperLink = CType(e.Row.FindControl("hypPrintLoadReport"), HyperLink)
                    Dim imgIsPrinted As Image = CType(e.Row.FindControl("imgIsPrinted"), Image)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    'Dim lblLoadStatus As Label = CType(e.Row.FindControl("lblLoadStatus"), Label)
                    Dim hypLoadStatus As HyperLink = CType(e.Row.FindControl("hypLoadStatus"), HyperLink)
                    Dim lblCustomerName As Label = CType(e.Row.FindControl("lblCustomerName"), Label)
                    Dim lblLoadTypeName As Label = CType(e.Row.FindControl("lblLoadTypeName"), Label)
                    'Dim lblLoadTypeCode As Label = CType(e.Row.FindControl("lblLoadTypeCode"), Label)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    'int _ModuleId = Null.NullInteger; _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ModuleID"), _ModuleId)); 
                    Dim _JRCActive As String = Null.NullString
                    _JRCActive = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "JRCActive"), _JRCActive))
                    Dim _LoadId As String = Null.NullString
                    _LoadId = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadId"), _LoadId))
                    Dim _JRCIOCode As String = Null.NullString
                    _JRCIOCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "JRCIOCode"), _JRCIOCode))
                    Dim _LoadType As String = Null.NullString
                    _LoadType = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadType"), _LoadType)).ToUpper
                    Dim _LoadStatus As String = Null.NullString
                    _LoadStatus = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), _LoadStatus))
                    Dim _CustomerName As String = Null.NullString
                    _CustomerName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "CustomerName"), _CustomerName))
                    Dim _CustomerNumber As String = Null.NullString
                    _CustomerNumber = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "CustomerNumber"), _CustomerNumber))

                    Dim _IOName As String = Null.NullString
                    _IOName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "IOName"), _IOName))
                    Dim _BrokerCode As String = Null.NullString
                    _BrokerCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BrokerCode"), _BrokerCode))
                    Dim _BrokerName As String = Null.NullString
                    _BrokerName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BrokerName"), _BrokerName))
                    Dim _BStatus As String = Null.NullString
                    _BStatus = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BStatus"), _BStatus)).ToUpper
                    Dim _BrokerNotes As String = Null.NullString
                    _BrokerNotes = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BrokerNotes"), _BrokerNotes)).ToUpper
                    Dim _DriverName As String = Null.NullString
                    _DriverName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DriverName"), _DriverName))
                    Dim _DriverCode As String = Null.NullString
                    _DriverCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DriverCode"), _DriverCode))
                    Dim _XMissionSave As Boolean = Null.NullBoolean
                    _XMissionSave = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "XMissionSave"), _XMissionSave))
                    Dim _IsPrinted As String = Null.NullString
                    _IsPrinted = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "IsPrinted"), _IsPrinted))
                    Dim _IORecovery As Double = Null.NullDouble
                    _IORecovery = Convert.ToDouble(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "IORecovery"), _IORecovery))



                    'If Not lblLoadStatus Is Nothing Then
                    '    Try
                    '        lblLoadStatus.Text = _LoadStatus.Substring(0, 3)
                    '        lblLoadStatus.Text = _LoadStatus.Substring(0, 4)
                    '    Catch
                    '    End Try
                    'End If

                    If (Not hypLoadStatus Is Nothing) AndAlso (_LoadStatus <> "") Then
                        With hypLoadStatus
                            .ImageUrl = "~/images/" & _LoadStatus.ToLower & ".gif"
                            .ToolTip = _LoadStatus
                            If (_LoadType = "BK") AndAlso (_BStatus = "HOLD") Then
                                .ToolTip &= " : " & _BrokerNotes
                            End If
                        End With
                    End If

                    If Not lblCustomerName Is Nothing Then
                        'Try
                        'If (_CustomerName.Length > 21) Then
                        '    lblCustomerName.Text = HtmlUtils.Shorten(_CustomerName, 20, "...")
                        'Else
                        '    lblCustomerName.Text = _CustomerName
                        'End If
                        lblCustomerName.Text = ShortenString(_CustomerName, 20)
                        'If (_CustomerNumber <> "") Then
                        '    lblCustomerName.ToolTip = _CustomerName & ": " & _CustomerNumber
                        'Else
                        '    lblCustomerName.ToolTip = _CustomerName
                        'End If
                        lblCustomerName.ToolTip = _CustomerName
                        'Catch
                        'End Try
                    End If

                    If Not hypEditItem Is Nothing Then
                        With hypEditItem
                            .Visible = IsEditable AndAlso (_JRCActive.ToUpper = "Y") 'AndAlso (lblLoadStatus.Text <> "COMP")
                            If .Visible Then
                                If (_LoadStatus.ToUpper = "COMPLETE") Then
                                    .ImageUrl = ResolveUrl("~/images/checked.gif")
                                    .ToolTip = "Completed Load"
                                    '.ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    '.Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    '.Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    .ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                ElseIf (_LoadStatus.ToUpper = "VOIDED") Then
                                    .ImageUrl = ResolveUrl("~/images/action_delete.gif")
                                    .ToolTip = "Voided Load"
                                    .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                Else
                                    If _XMissionSave Then
                                        .ImageUrl = ResolveUrl("~/images/icon_sitesettings_16px.gif")
                                        .ToolTip = "Marked For Xmission"
                                        '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                    Else
                                        .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                        .ToolTip = Localization.GetString("Edit")
                                    End If
                                End If
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditItem
                    End If

                    If Not hypPUDrops Is Nothing Then
                        With hypPUDrops
                            .Visible = hypEditItem.Visible AndAlso hypEditItem.ImageUrl.ToLower.EndsWith("edit.gif")
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "Edit", "EditLoadType=EditPUDrops")
                                .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditPUDrops", "dnnprintmode=true")
                                .ToolTip = "Add/Edit Pickups/Drops"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditItem
                    End If

                    If Not hypCopyLoad Is Nothing Then
                        With hypCopyLoad
                            '.Visible = IsEditable AndAlso (lblLoadStatus.Text <> "COMP") AndAlso (lblLoadStatus.Text <> "VOID") AndAlso (_JRCActive.ToUpper = "Y")
                            .Visible = IsEditable AndAlso (_IORecovery < 1) AndAlso (_LoadStatus.ToUpper <> "VOIDED") AndAlso (_JRCActive.ToUpper = "Y")

                            If .Visible Then
                                .NavigateUrl = EditUrl("FromLoadId", _LoadId, "Edit", "OType=CopyLoad")
                                .ToolTip = Localization.GetString("copy_load", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypCopyLoad
                    End If

                    If Not imgIsPrinted Is Nothing Then
                        With imgIsPrinted
                            .Visible = True
                            If .Visible Then
                                If (_IsPrinted.ToUpper = "Y") OrElse (_IsPrinted.ToUpper = "PRINTED") Then
                                    .ImageUrl = "~/images/print.gif"
                                    .ToolTip = "Already Printed"
                                Else
                                    .ImageUrl = "~/images/NotPrinted.gif"
                                    .ToolTip = "Not Printed"
                                End If
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'imbDelete
                    End If

                    If Not imbDelete Is Nothing Then
                        With imbDelete
                            .Visible = IsEditable AndAlso objOI.DeleteFromGrid AndAlso (_JRCActive.ToUpper = "Y")
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
                            Select Case _LoadType.ToUpper
                                Case "IO"
                                    Dim Office As String = Replace(_IOName, "JRC - ", "")
                                    Office = Replace(Office, "JRC ", "")
                                    .Text = Office.ToUpper
                                    .ToolTip = "JRCIOCode: " & _JRCIOCode
                                Case "BK"
                                    .Text = _BrokerName
                                    .ToolTip = "BrokerCode: " & _BrokerCode
                                Case Else '"OO"
                                    .Text = _DriverName
                                    .ToolTip = "DriverCode: " & _DriverCode
                            End Select
                            '.ToolTip = .Text & ": " & .ToolTip
                            '.Text = ShortenString(.Text, 12)
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblLoadTypeName
                    End If

                    If Not hypEditAcct Is Nothing Then
                        With hypEditAcct
                            .Visible = IsEditable AndAlso (_JRCActive.ToUpper = "Y") AndAlso (Not _XMissionSave) 'AndAlso (lblLoadStatus.Text.ToUpper <> "COMP")
                            If .Visible Then
                                If (_LoadStatus.ToUpper = "COMPLETE") OrElse (_LoadStatus.ToUpper = "VOIDED") Then
                                    .ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    .Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    .Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    '.ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                    '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ComCheck", "Item=ComCheckLoad")
                                Else
                                    .ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                    .NavigateUrl = EditUrl("LoadID", _LoadId, "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                End If
                                '.ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                '.NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    'Dim strLoadType As String = _LoadType.ToUpper
                    If Not hypLoadReport Is Nothing Then
                        With hypLoadReport
                            .Visible = (_LoadType <> "BK") OrElse ((_LoadType = "BK") AndAlso (_BStatus = "ACTIVE")) 'True
                            If .Visible Then
                                .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & _ItemId, "LoadType=" & _LoadType)
                                .Target = "_blank"
                                .ToolTip = Localization.GetString("LoadReport", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    If Not hypPrintLoadReport Is Nothing Then
                        With hypPrintLoadReport
                            .Visible = (_LoadType = "OO") OrElse ((_LoadType = "BK") AndAlso (_BStatus = "ACTIVE"))
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                                '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & _ItemId, "LoadType=" & strLoadType)
                                .NavigateUrl = EditUrl("ReportType", "LoadConfirm", "Reports", "ItemId=" & _ItemId, "LoadType=" & _LoadType)
                                .Target = "_blank"
                                Select Case _LoadType
                                    Case "OO"
                                        .ToolTip = "Driver Confirm"
                                    Case "BK"
                                        .ToolTip = "Broker Confirm"
                                        'Case "IO"
                                        '    .ToolTip = "IO Confirm"
                                        'Case Else '"OO"
                                        '    .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                                End Select
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    'If Not hypPrintLoadReport Is Nothing Then
                    '    With hypPrintLoadReport
                    '        .Visible = True
                    '        If .Visible Then
                    '            .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
                    '            .Target = "_blank"
                    '            .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With  'hypEditAcct
                    'End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub SetProbDrivers()
            Dim objIOC As New bhattji.Modules.InterOffices.Business.InterOfficesController()
            imgHasProbDrivers.Visible = (ddlJRCIOfficeCode.SelectedValue <> "") AndAlso (ddlJRCIOfficeCode.SelectedValue <> "000000000") AndAlso objIOC.DoesHaveProbDrivers(ddlJRCIOfficeCode.SelectedValue)
            imgHasProbDrivers.ToolTip = "The Selected Office '" & ddlJRCIOfficeCode.SelectedItem.Text & "' has Problematic Drivers"
        End Sub
        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            SetProbDrivers()
            'Session.Clear()
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            SetSearchOn(ddlJRCIOfficeCode.SelectedValue)
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub rblSearchOn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSearchOn.SelectedIndexChanged
            Session.Item("SearchOn") = rblSearchOn.SelectedValue
        End Sub

        'Private Sub ddlCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategories.SelectedIndexChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
        End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub

#End Region

    End Class 'ViewList

End Namespace 'bhattji.Modules.LoadSheets
