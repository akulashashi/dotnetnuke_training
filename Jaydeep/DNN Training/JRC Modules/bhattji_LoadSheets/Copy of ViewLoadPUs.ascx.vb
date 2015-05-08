' Copyright (c) 2002-2005
' by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, to the person obtaining a copy of this software legaly and associated
' documentation files (the "Software"), to deal in the Software with restriction, including with limitation
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
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

'Imports DotNetNuke

Imports System
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
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
    Public MustInherit Class ViewLoadPUs
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Dim objOI As OptionsInfo
        Private loadId As String
        Private PickupDate As Date
        'Private DropDate As Date

#End Region

#Region " Public Members "

        Public itemId As Integer
        'Public loadId As String
        Public Embeded As Boolean

#End Region

#Region " Public Methods "

        Private Sub ExpandPanel(Optional ByVal Expand As Boolean = True)
            secLoadPUs.IsExpanded = Not Expand
            secAddLoadPU.IsExpanded = Expand
            If lblItemId.Text <> "" Then
                secAddLoadPU.Text = "Update Load Pickup"
                cmdAdd.Text = "Save Pickup" '"Update Pickup"
                cmdAdd.ToolTip = secAddLoadPU.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/save.gif")
                imbAdd.ToolTip = cmdAdd.Text
            Else
                secAddLoadPU.Text = "Add Load Pickup"
                cmdAdd.Text = "Save Pickup" '"Add Pickup"
                cmdAdd.ToolTip = secAddLoadPU.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/add.gif")
                imbAdd.ToolTip = cmdAdd.Text
            End If
        End Sub

        Sub ShowHide(Optional ByVal InsertMode As Boolean = False)
            'trAddLoadPU.Visible = InsertMode
            'trManageLoadPUs.Visible = Not InsertMode

            secLoadPUs.IsExpanded = Not InsertMode
            secAddLoadPU.IsExpanded = InsertMode
            If Not InsertMode Then
                itemId = Null.NullInteger
            End If
            InitAddPanel()
            'lnkAddLoadPU.Visible = Not InsertMode
        End Sub 'ShowHide(Optional ByVal InsertMode As Boolean = False)

        Sub InitAddPanel()
            If itemId > 0 Then
                secAddLoadPU.Text = "Update Load Pickup"
                cmdAdd.Text = "Save Pickup" '"Update Pickup"
                cmdAdd.ToolTip = secAddLoadPU.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/save.gif")
                imbAdd.ToolTip = cmdAdd.Text
                Dim objLoadPU As LoadPUInfo = (New LoadPUsController).GetLoadPU(itemId)
                If Not objLoadPU Is Nothing Then
                    With objLoadPU
                        lblItemId.Text = .ItemId.ToString
                        txtSeq.Text = .Seq.ToString
                        txtPUName.Text = .PUName
                        txtPUAdd1.Text = .PUAdd1
                        txtPRONo.Text = .PRONo
                        txtPUCity.Text = .PUCity
                        txtPUState.Text = .PUState.ToUpper
                        txtZipCode.Text = .ZipCode
                        txtPUTel.Text = .PUTel
                        txtPUContact.Text = .PUContact
                        If Not (Null.IsNull(.PUDate) OrElse (.PUDate.ToShortDateString = "11/11/2222")) Then txtPUDate.Text = .PUDate.ToShortDateString Else txtPUDate.Text = "" '"11/11/2222"
                        If Not Null.IsNull(.PUTime) Then txtPUTime.Text = .PUTime.ToShortTimeString
                        txtPieces.Text = .Pieces
                        txtWeight.Text = .Weight
                        txtMiles.Text = .Miles.ToString
                    End With
                End If
            Else
                secAddLoadPU.Text = "Add Load Pickup"
                cmdAdd.Text = "Save Pickup" '"Add Pickup"
                cmdAdd.ToolTip = secAddLoadPU.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/add.gif")
                imbAdd.ToolTip = cmdAdd.Text
                lblItemId.Text = ""
                txtSeq.Text = (10 * gdvLoadPUs.Rows.Count + 10).ToString  '"10"
                'txtSeq.Text = (10 * rlLoadPUs.Items.Count + 10).ToString  '"10"
                txtPUName.Text = ""
                txtPUAdd1.Text = ""
                txtPRONo.Text = ""
                txtPUCity.Text = ""
                txtPUState.Text = ""
                txtZipCode.Text = ""
                txtPUTel.Text = ""
                txtPUContact.Text = ""
                txtPUDate.Text = "" '"11/11/2222"
                'If Null.IsNull(PickupDate) Then txtPUDate.Text = Now.ToShortDateString Else txtPUDate.Text = PickupDate.ToShortDateString
                Try
                    Dim LoadDate As Date = (New LoadSheetsController).GetLoadSheetByLoadId(loadId).LoadDate
                    If Null.IsNull(LoadDate) Then txtPUDate.Text = Now.ToShortDateString Else txtPUDate.Text = LoadDate.ToShortDateString
                Catch
                End Try
                txtPUTime.Text = "" 'Now.ToShortTimeString
                txtPieces.Text = ""
                txtWeight.Text = ""
                txtMiles.Text = "0"
            End If
        End Sub

        Sub SetGridView()
            With gdvLoadPUs
                '.PageSize = objOI.PagerSize
                '.AllowPaging = objOI.PagerSize > 0
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
            End With 'gdvLoadPUs

        End Sub

        'Sub SetrlLoadPUs()
        '    With rlLoadPUs
        '        .PageSize = objOI.PagerSize
        '        .AllowPaging = objOI.PagerSize > 0
        '        .Items(0).Visible = IsEditable 'Remove the First column if the User is not Admin
        '        Dim txtAjaxLoadId As TextBox = CType(.FindControl("txtAjaxLoadId"), TextBox)
        '        If Not txtAjaxLoadId Is Nothing Then
        '            txtAjaxLoadId.Text = loadId
        '        End If
        '    End With 'rlLoadPUs
        'End Sub

        Sub FixSeq()
            Dim objLoadPUInfo As New LoadPUInfo
            Dim objLoadPUsController As New LoadPUsController
            Dim al As New ArrayList
            al = objLoadPUsController.GetLoadPUByLoadId(loadId)
            Dim Inc As Integer = 0
            For Each objLoadPUInfo In al
                Inc += 10
                objLoadPUInfo.Seq = Inc
                objLoadPUsController.UpdateLoadPU(objLoadPUInfo)
            Next
        End Sub

        Sub ResetViewStates()
            ViewState.Remove("odsLoadPU")
            ViewState.Remove("gdvLoadPUs")
            'ViewState.Remove("rlLoadPUs")
            odsLoadPUs.DataBind()
            gdvLoadPUs.DataBind()
            'rlLoadPUs.DataBind()
        End Sub

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                Dim objLoad As LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)
                'loadId = (New Business.LoadSheetsController).GetLoadId(itemId)
                loadId = objLoad.LoadID
                'DropDate = objLoad.DeliveryDate
                PickupDate = objLoad.LoadDate

                'this needs to execute always to the client script code is registred in InvokePopupCal
                'cmdCalandarPUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPUDate)

                SetGridView()
                'SetrlLoadPUs()

                hypClose.Visible = Not Embeded
                hypImgClose.Visible = hypClose.Visible

                If hypClose.Visible Then
                    If (Not Request.Params("LoadID") Is Nothing) OrElse (Request.Params("LoadID") <> "") Then
                        hypClose.NavigateUrl = EditUrl("LoadID", Request.QueryString("LoadID"))
                    Else
                        hypClose.NavigateUrl = NavigateURL()
                    End If
                    hypImgClose.NavigateUrl = hypClose.NavigateUrl
                End If

                If Not Page.IsPostBack Then
                    ResetViewStates()
                    ShowHide()
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub lnkAddLoadPU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddLoadPU.Click
            itemId = Null.NullInteger
            'InitAddPanel()
            ShowHide(True)
        End Sub

        Private Sub gdvLoadPUs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadPUs.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim imbEditPU As ImageButton = CType(e.Row.FindControl("imbEditPU"), ImageButton)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    Dim imbDeletePU As ImageButton = CType(e.Row.FindControl("imbDeletePU"), ImageButton)
                    Dim cmdUp As ImageButton = CType(e.Row.FindControl("cmdUp"), ImageButton)
                    Dim cmdDown As ImageButton = CType(e.Row.FindControl("cmdDown"), ImageButton)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _PUDate As DateTime = Null.NullDate
                    _PUDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUDate"), _PUDate))

                    '        .PUName = (CType(e.Item.Cells(1).FindControl("txt_PUName"), TextBox)).Text
                    '(CType(gdvLoadPUs.FindControl("txt_PUName"), TextBox)).Text
                    'Try
                    '    Dim cmdCalandar_PUDate As HyperLink = (CType(e.Row.FindControl("cmdCalandar_PUDate"), HyperLink))
                    '    Dim txt_PUDate As TextBox = (CType(e.Row.FindControl("txt_PUDate"), TextBox))
                    '    cmdCalandar_PUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txt_PUDate)

                    'Catch
                    'End Try

                    If Not imbEditPU Is Nothing Then
                        With imbEditPU
                            .Visible = IsEditable
                            If .Visible Then
                                .CommandName = "EditPU" & _ItemId
                                .CommandArgument = _ItemId
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Edit Load Pickup"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'imbDelete
                    End If

                    If Not imbDelete Is Nothing Then
                        With imbDelete
                            .Visible = IsEditable
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                            End If
                        End With  'imbDelete
                    End If

                    If Not imbDeletePU Is Nothing Then
                        With imbDeletePU
                            .Visible = IsEditable
                            If .Visible Then
                                .CommandName = "DeletePU" & _ItemId
                                .CommandArgument = _ItemId
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete Load Pickup"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                            End If
                        End With  'imbDelete
                    End If

                    If Not cmdUp Is Nothing Then
                        cmdUp.Visible = (e.Row.RowIndex > 0)
                        If cmdUp.Visible Then
                            With cmdUp
                                .CommandName = "Up" & _ItemId
                                .ToolTip = "Move Up"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                '.Attributes.Add("onClick", "javascript:return confirm('Move this Item Up ?');")
                            End With 'cmdUp
                        End If
                    End If

                    If Not cmdDown Is Nothing Then
                        With cmdDown
                            .CommandName = "Down" & _ItemId
                            .ToolTip = "Move Down"
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            '.Attributes.Add("onClick", "javascript:return confirm('Move this Item Down ?');")
                        End With 'cmdDown
                    End If

                    If Not Null.IsNull(_PUDate) Then
                        'Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)
                        'lblPUDate.Text = _PUDate.ToShortDateString
                        Dim PUDate As Date = _PUDate
                        If PUDate.ToShortDateString <> "11/11/2222" Then 'If PUDate > #1/1/1950# Then
                            Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)
                            lblPUDate.Text = _PUDate.ToShortDateString
                        End If
                    End If

                ElseIf (e.Row.RowType = DataControlRowType.Footer) AndAlso (gdvLoadPUs.Rows.Count > 0) Then
                    Dim gvr As GridViewRow = gdvLoadPUs.Rows(gdvLoadPUs.Rows.Count - 1)
                    Dim cmdDown As ImageButton = DirectCast(gvr.FindControl("cmdDown"), ImageButton)
                    If Not cmdDown Is Nothing Then
                        cmdDown.Visible = False
                    End If
                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub gdvLoadPUs_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gdvLoadPUs.RowEditing
            itemId = gdvLoadPUs.DataKeys(e.NewEditIndex).Value
            'InitAddPanel()
            ShowHide(True)
        End Sub

        Private Sub gdvLoadPUs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvLoadPUs.RowCommand
            If e.CommandName = "Add" Then
                itemId = Null.NullInteger
                'InitAddPanel()
                ShowHide(True)

            ElseIf e.CommandName.StartsWith("EditPU") Then
                itemId = CInt(e.CommandName.Substring(6))
                'InitAddPanel()
                ShowHide(True)

            ElseIf e.CommandName.StartsWith("DeletePU") Then
                Dim objPUC As New LoadPUsController
                objPUC.DeleteLoadPU(CInt(e.CommandName.Substring(8)))
                ResetViewStates()

            ElseIf e.CommandName.StartsWith("Up") Then
                Dim S As String = e.CommandName
                'S = Replace(S, "Up", "")
                Dim I As Integer = CType(Replace(S, "Up", ""), Integer)

                Dim objLoadPUsController = New LoadPUsController
                Dim objLoadPU As LoadPUInfo = objLoadPUsController.GetLoadPU(I)
                If Not objLoadPU Is Nothing Then
                    objLoadPU.Seq -= 15

                    objLoadPUsController.UpdateLoadPU(objLoadPU)
                    FixSeq()
                End If
                ResetViewStates()

            ElseIf e.CommandName.StartsWith("Down") Then
                Dim S As String = e.CommandName
                'S = Replace(S, "Down", "")
                Dim I As Integer = CType(Replace(S, "Down", ""), Integer)

                Dim objLoadPUsController = New LoadPUsController
                Dim objLoadPU As LoadPUInfo = objLoadPUsController.GetLoadPU(I)
                If Not objLoadPU Is Nothing Then
                    objLoadPU.Seq += 15

                    objLoadPUsController.UpdateLoadPU(objLoadPU)
                    FixSeq()
                End If
                ResetViewStates()

            End If

        End Sub


        'Private Sub rlLoadPUs_ItemDataBound(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListItemEventArgs) Handles rlLoadPUs.ItemDataBound
        '    Try
        '        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '            Dim cmdEdit As ImageButton = CType(e.Item.FindControl("cmdEdit"), ImageButton)
        '            Dim imbDelete As ImageButton = CType(e.Item.FindControl("imbDelete"), ImageButton)
        '            Dim txtAjaxLoadId As TextBox = CType(e.Item.FindControl("txtAjaxLoadId"), TextBox)

        '            If Not txtAjaxLoadId Is Nothing Then
        '                txtAjaxLoadId.Text = loadId
        '            End If

        '            If Not cmdEdit Is Nothing Then
        '                With cmdEdit
        '                    .Visible = IsEditable
        '                    If .Visible Then
        '                        '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
        '                        .ToolTip = "Edit"
        '                        .CommandName = "EditLoadPU" & CType(DataBinder.Eval(e.Item.DataItem, "ItemID"), String)
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'imbDelete
        '            End If

        '            If Not imbDelete Is Nothing Then
        '                With imbDelete
        '                    .Visible = IsEditable
        '                    If .Visible Then
        '                        '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
        '                        .ToolTip = "Delete"
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                        .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
        '                    End If
        '                End With  'imbDelete
        '            End If

        '            If Not Null.IsNull(CType(DataBinder.Eval(e.Item.DataItem, "PUDate"), Date)) Then
        '                Dim lblPUDate As Label = CType(e.Item.FindControl("lblPUDate"), Label)
        '                lblPUDate.Text = CType(DataBinder.Eval(e.Item.DataItem, "PUDate"), Date).ToShortDateString
        '            End If
        '        End If
        '    Catch exc As Exception    'Module failed to RowDataBound
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

        'Private Sub rlLoadPUs_EditCommand(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListCommandEventArgs) Handles rlLoadPUs.EditCommand
        '    itemId = rlLoadPUs.DataKeys(e.Item.ItemIndex).Value
        '    InitAddPanel()
        '    ShowHide(True)
        'End Sub

        'Private Sub rlLoadPUs_ItemCommand(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListCommandEventArgs) Handles rlLoadPUs.ItemCommand
        '    If e.CommandName = "Add" Then
        '        itemId = Null.NullInteger
        '        InitAddPanel()
        '        ShowHide(True)
        '        'ElseIf e.CommandName = "AddLoadPU" Then
        '        '    Dim PUCity As String = CType(e.Item.FindControl("PUCity"), TextBox).Text
        '        '    Dim PUState As String = CType(e.Item.FindControl("PUState"), TextBox).Text
        '        '    Dim PUDate As Date
        '        '    Try
        '        '        PUDate = CType(CType(e.Item.FindControl("PUDate"), TextBox).Text, Date)
        '        '    Catch
        '        '        PUDate = Now
        '        '    End Try

        '        '    Dim Seq As Integer = rlLoadPUs.Items.Count * 10
        '        '    'Try
        '        '    '    Seq = CType(CType(e.Item.FindControl("txtAjaxSeq"), TextBox).Text, Integer)
        '        '    'Catch
        '        '    '    Seq = 1000
        '        '    'End Try

        '        '    'Dim ItemId As Integer = (New LoadPUsController).AddLoadPU(loadId, CType(DataBinder.Eval(e.Item.DataItem, "PUCity"), String), Now, 1000)
        '        '    itemId = (New LoadPUsController).AddLoadPU(loadId, PUCity, PUState, PUDate, Seq)
        '        '    ResetViewStates()
        '    ElseIf e.CommandName.StartsWith("EditLoadPU") Then
        '        itemId = Integer.Parse(e.CommandName.Substring(10)) 'rlLoadPUs.DataKeys(0).Value 'Null.NullInteger ' 
        '        InitAddPanel()
        '        ShowHide(True)

        '    ElseIf e.CommandName.StartsWith("Up") Then
        '        Dim S As String = e.CommandName
        '        'S = Replace(S, "Up", "")
        '        Dim I As Integer = CType(Replace(S, "Up", ""), Integer)

        '        Dim objLoadPUsController = New LoadPUsController
        '        Dim objLoadPU As LoadPUInfo = objLoadPUsController.GetLoadPU(I)
        '        If Not objLoadPU Is Nothing Then
        '            objLoadPU.Seq -= 15

        '            objLoadPUsController.UpdateLoadPU(objLoadPU)
        '            FixSeq()
        '        End If
        '        ResetViewStates()

        '    ElseIf e.CommandName.StartsWith("Down") Then
        '        Dim S As String = e.CommandName
        '        'S = Replace(S, "Down", "")
        '        Dim I As Integer = CType(Replace(S, "Down", ""), Integer)

        '        Dim objLoadPUsController = New LoadPUsController
        '        Dim objLoadPU As LoadPUInfo = objLoadPUsController.GetLoadPU(I)
        '        If Not objLoadPU Is Nothing Then
        '            objLoadPU.Seq += 15

        '            objLoadPUsController.UpdateLoadPU(objLoadPU)
        '            FixSeq()
        '        End If
        '        ResetViewStates()

        '    End If
        'End Sub

        Private Sub odsLoadPUs_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadPUs.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

        Private Sub txtPUCity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUCity.TextChanged
            'Dim objZipCodesController As New Business.ZipCodesController
            'objZipCodesController.GetStateZipCodeByCity(txtPUCity.Text, txtPUState.Text, txtZipCode.Text)
            txtPUState.Text = "" 'Seatch the city in all states
            imbSearchCity_Click(Nothing, Nothing)
        End Sub

        Private Sub imbSearchCity_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchCity.Click
            With ddlZipCodes
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtPUCity.Text, "City", txtPUState.Text)
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes_SelectedIndexChanged(Nothing, Nothing)
            End With
            ExpandPanel()
        End Sub

        Private Sub imbSearchZipCode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchZipCode.Click
            With ddlZipCodes
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtZipCode.Text, "ZipCode")
                .DataBind()

                If .Items.Count > 0 Then ddlZipCodes_SelectedIndexChanged(Nothing, Nothing)
            End With
            ExpandPanel()
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

        Private Sub imbAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Dim objLoadPU As New Business.LoadPUInfo
            'Initialise the ojbLoadPU object
            objLoadPU = CType(CBO.InitializeObject(objLoadPU, GetType(Business.LoadPUInfo)), Business.LoadPUInfo)

            'bind text values to object
            With objLoadPU
                .ItemId = Null.NullInteger
                Try
                    .ItemId = Integer.Parse(lblItemId.Text)
                Catch
                End Try
                '.LoadID = txtLoadID.Text
                .LoadID = (New Business.LoadSheetsController).GetLoadId(itemId)

                Try
                    .Seq = Integer.Parse(txtSeq.Text)
                Catch
                    .Seq = 10 + 10 * gdvLoadPUs.Rows.Count
                End Try
                .PUName = txtPUName.Text
                .PUAdd1 = txtPUAdd1.Text
                .PRONo = txtPRONo.Text
                .PUCity = txtPUCity.Text
                .PUState = txtPUState.Text
                .ZipCode = txtZipCode.Text
                .PUTel = txtPUTel.Text
                .PUContact = txtPUContact.Text
                Try
                    .PUDate = Date.Parse(txtPUDate.Text)
                Catch
                    .PUDate = #11/11/2222# 'Now
                End Try
                Try
                    .PUTime = Date.Parse(txtPUTime.Text)
                Catch
                    '.PUTime = Now
                End Try
                .Pieces = txtPieces.Text
                .Weight = txtWeight.Text
                Try
                    .Miles = Decimal.Parse(txtMiles.Text)
                Catch
                    .Miles = 0
                End Try

            End With 'objLoadPU


            Dim objLoadPUsController As New Business.LoadPUsController
            'objLoadPUsController.AddLoadPU(objLoadPU)
            objLoadPUsController.AddUpdateLoadPU(objLoadPU)

            ResetViewStates()
            ShowHide()
        End Sub

        Private Sub imbCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
            cmdCancel_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
            ShowHide()
        End Sub

#End Region

    End Class 'ViewAlts

End Namespace 'bhattji.Modules.LoadSheets
