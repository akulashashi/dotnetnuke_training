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
    Public MustInherit Class ViewDrops
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Dim objOI As OptionsInfo
        Private loadId As String
        'Private PickupDate As Date
        Private DropDate As Date

#End Region

#Region " Public Members "

        Public itemId As Integer
        'Public loadId As String
        Public Embeded As Boolean

#End Region

#Region " Public Methods "

        Private Sub ExpandPanel()
            secLoadDPs.IsExpanded = False
            secAddLoadDrop.IsExpanded = True
            If lblItemId.Text <> "" Then
                secAddLoadDrop.Text = "Update Load Drop"
                cmdAdd.Text = "Save Drop" '"Update Drop"
                cmdAdd.ToolTip = secAddLoadDrop.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/save.gif")
                imbAdd.ToolTip = cmdAdd.Text
                imbAdd.ToolTip = cmdAdd.Text
            Else
                secAddLoadDrop.Text = "Add Load Drop"
                cmdAdd.Text = "Save Drop" '"Add Drop"
                cmdAdd.ToolTip = secAddLoadDrop.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/add.gif")
                imbAdd.ToolTip = cmdAdd.Text
            End If
        End Sub

        Sub ShowHide(Optional ByVal InsertMode As Boolean = False)
            'trAddLoadDrop.Visible = InsertMode
            'trManageLoadDrops.Visible = Not InsertMode

            secLoadDPs.IsExpanded = Not InsertMode
            secAddLoadDrop.IsExpanded = InsertMode
            If Not InsertMode Then
                itemId = Null.NullInteger
            End If
            InitAddPanel()
            'lnkAddLoadPU.Visible = Not InsertMode
        End Sub 'ShowHide(Optional ByVal InsertMode As Boolean = False)

        Sub InitAddPanel()
            If itemId > 0 Then
                secAddLoadDrop.Text = "Update Load Drop"
                cmdAdd.Text = "Save Drop" '"Update Drop"
                cmdAdd.ToolTip = secAddLoadDrop.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/save.gif")
                imbAdd.ToolTip = cmdAdd.Text
                Dim objLoadDrop As LoadDropInfo = (New LoadDropsController).GetLoadDrop(itemId)
                If Not objLoadDrop Is Nothing Then
                    With objLoadDrop
                        lblItemId.Text = .ItemId.ToString
                        txtSeq.Text = .Seq.ToString
                        txtDPName.Text = .DPName
                        txtDPAddr.Text = .DPAddr
                        txtDPCity.Text = .DPCity
                        txtDPState.Text = .DPState.ToUpper
                        txtZipCode.Text = .ZipCode
                        txtDPPhone.Text = .DPPhone
                        If Not (Null.IsNull(.DPDate) OrElse (.DPDate.ToShortDateString = "11/11/2222")) Then txtDPDate.Text = .DPDate.ToShortDateString Else txtDPDate.Text = "" '"11/11/2222"
                        txtDPContact.Text = .DPContact
                        txtJobno.Text = .Jobno
                        'txtBillOLay.Text = .BillOLay
                        Try
                            ddlBillOLay.SelectedValue = .BillOLay
                        Catch
                        End Try
                        txtBOLSeq.Text = .BOLSeq
                        If Not Null.IsNull(.Stime) Then txtStime.Text = .Stime.ToShortTimeString
                        If Not Null.IsNull(.Etime) Then txtEtime.Text = .Etime.ToShortTimeString
                    End With
                End If
            Else
                secAddLoadDrop.Text = "Add Load Drop"
                cmdAdd.Text = "Save Drop" '"Add Drop"
                cmdAdd.ToolTip = secAddLoadDrop.Text 'cmdAdd.Text
                imbAdd.ImageUrl = ResolveUrl("~/images/add.gif")
                imbAdd.ToolTip = cmdAdd.Text
                lblItemId.Text = ""
                txtSeq.Text = (10 * gdvLoadDrops.Rows.Count + 10).ToString  '"10"
                'txtSeq.Text = (10 * rlLoadDPs.Items.Count + 10).ToString  '"10"
                txtDPName.Text = ""
                txtDPAddr.Text = ""
                txtDPCity.Text = ""
                txtDPState.Text = ""
                txtZipCode.Text = ""
                txtDPPhone.Text = ""
                'If Null.IsNull(DropDate) Then txtDPDate.Text = Now.ToShortDateString Else txtDPDate.Text = DropDate.ToShortDateString
                txtDPDate.Text = "" '"11/11/2222"
                txtDPContact.Text = ""
                txtJobno.Text = ""
                'txtBillOLay.Text = ""
                txtBOLSeq.Text = ""
                txtStime.Text = "" 'Now.ToShortTimeString
                txtEtime.Text = "" 'Now.ToShortTimeString
            End If
        End Sub

        Sub SetGridView()
            With gdvLoadDrops
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
            End With 'gdvLoadDrops

        End Sub

        'Sub SetrlLoadDPs()
        '    With rlLoadDPs
        '        '.PageSize = objOI.PagerSize
        '        '.AllowPaging = objOI.PagerSize > 0
        '        '.Items(0).Visible = IsEditable 'Remove the First column if the User is not Admin
        '        Dim txtAjaxLoadId As TextBox = CType(.FindControl("txtAjaxLoadId"), TextBox)
        '        If Not txtAjaxLoadId Is Nothing Then
        '            txtAjaxLoadId.Text = loadId
        '        End If
        '    End With 'rlLoadDPs
        'End Sub

        Sub FixSeq()
            Dim objLoadDropInfo As New LoadDropInfo
            Dim objLoadDropsController As New LoadDropsController
            Dim al As New ArrayList
            al = objLoadDropsController.GetLoadDropByLoadId(loadId)
            Dim Inc As Integer = 0
            For Each objLoadDropInfo In al
                Inc += 10
                objLoadDropInfo.Seq = Inc
                objLoadDropsController.UpdateLoadDrop(objLoadDropInfo)
            Next
        End Sub

        Sub ResetViewStates()
            ViewState.Remove("odsLoadDrops")
            ViewState.Remove("gdvLoadDrops")
            'ViewState.Remove("rlLoadDPs")
            odsLoadDrops.DataBind()
            gdvLoadDrops.DataBind()
            'rlLoadDPs.DataBind()
        End Sub

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                Dim objLoad As LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)
                'loadId = (New Business.LoadSheetsController).GetLoadId(itemId)
                loadId = objLoad.LoadID
                DropDate = objLoad.DeliveryDate
                'PickupDate = objLoad.LoadDate

                'this needs to execute always to the client script code is registred in InvokePopupCal
                'cmdCalandarDPDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtDPDate)
                SetGridView()
                'SetrlLoadDPs()

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

        Private Sub lnkAddLoadDrop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddLoadDrop.Click
            itemId = Null.NullInteger
            'InitAddPanel()
            ShowHide(True)
        End Sub

        Private Sub gdvLoadDrops_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadDrops.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim imbEditDP As ImageButton = CType(e.Row.FindControl("imbEditDP"), ImageButton)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    Dim imbDeleteDP As ImageButton = CType(e.Row.FindControl("imbDeleteDP"), ImageButton)
                    Dim cmdUp As ImageButton = CType(e.Row.FindControl("cmdUp"), ImageButton)
                    Dim cmdDown As ImageButton = CType(e.Row.FindControl("cmdDown"), ImageButton)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _DPDate As DateTime = Null.NullDate
                    _DPDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPDate"), _DPDate))

                    'Try
                    '    Dim cmdCalandar_DPDate As HyperLink = (CType(e.Row.FindControl("cmdCalandar_DPDate"), HyperLink))
                    '    Dim txt_DPDate As TextBox = (CType(e.Row.FindControl("txt_DPDate"), TextBox))
                    '    cmdCalandar_DPDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txt_DPDate)
                    'Catch
                    'End Try

                    If Not imbEditDP Is Nothing Then
                        With imbEditDP
                            .Visible = IsEditable
                            If .Visible Then
                                .CommandName = "EditDP" & _ItemId
                                .CommandArgument = _ItemId
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Edit Load Drop"
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

                    If Not imbDeleteDP Is Nothing Then
                        With imbDeleteDP
                            .Visible = IsEditable
                            If .Visible Then
                                .CommandName = "DeleteDP" & _ItemId
                                .CommandArgument = _ItemId
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete Load Drop"
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

                    If Not Null.IsNull(_DPDate) Then
                        Dim DPDate As Date = _DPDate
                        If DPDate.ToShortDateString <> "11/11/2222" Then 'If DPDate > #1/1/1950# Then
                            Dim lblDPDate As Label = CType(e.Row.FindControl("lblDPDate"), Label)
                            lblDPDate.Text = _DPDate.ToShortDateString
                        End If
                    End If

                ElseIf (e.Row.RowType = DataControlRowType.Footer) AndAlso (gdvLoadDrops.Rows.Count > 0) Then
                    Dim gvr As GridViewRow = gdvLoadDrops.Rows(gdvLoadDrops.Rows.Count - 1)
                    Dim cmdDown As ImageButton = DirectCast(gvr.FindControl("cmdDown"), ImageButton)
                    If Not cmdDown Is Nothing Then
                        cmdDown.Visible = False
                    End If
                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub gdvLoadDrops_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdvLoadDrops.RowCommand
            If e.CommandName = "Add" Then
                itemId = Null.NullInteger
                'InitAddPanel()
                ShowHide(True)

            ElseIf e.CommandName.StartsWith("EditDP") Then
                itemId = CInt(e.CommandName.Substring(6))
                'InitAddPanel()
                ShowHide(True)

            ElseIf e.CommandName.StartsWith("DeleteDP") Then
                Dim objDPC As New LoadDropsController
                objDPC.DeleteLoadDrop(CInt(e.CommandName.Substring(8)))
                ResetViewStates()

            ElseIf e.CommandName.StartsWith("Up") Then
                Dim S As String = e.CommandName
                'S = Replace(S, "Up", "")
                Dim I As Integer = CType(Replace(S, "Up", ""), Integer)

                Dim objLoadDropsController = New LoadDropsController
                Dim objLoadDrop As LoadDropInfo = objLoadDropsController.GetLoadDrop(I)
                If Not objLoadDrop Is Nothing Then
                    objLoadDrop.Seq -= 15

                    objLoadDropsController.UpdateLoadDrop(objLoadDrop)
                    FixSeq()
                End If
                ResetViewStates()

            ElseIf e.CommandName.StartsWith("Down") Then
                Dim S As String = e.CommandName
                'S = Replace(S, "Down", "")
                Dim I As Integer = CType(Replace(S, "Down", ""), Integer)

                Dim objLoadDropsController = New LoadDropsController
                Dim objLoadDrop As LoadDropInfo = objLoadDropsController.GetLoadDrop(I)
                If Not objLoadDrop Is Nothing Then
                    objLoadDrop.Seq += 15

                    objLoadDropsController.UpdateLoadDrop(objLoadDrop)
                    FixSeq()
                End If
                ResetViewStates()

            End If
        End Sub

        Private Sub gdvLoadDrops_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gdvLoadDrops.RowEditing
            itemId = gdvLoadDrops.DataKeys(e.NewEditIndex).Value
            'InitAddPanel()
            ShowHide(True)
        End Sub

        'Private Sub rlLoadDPs_ItemDataBound(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListItemEventArgs) Handles rlLoadDPs.ItemDataBound
        '    Try
        '        If e.Item.ItemType = DataControlRowType.DataRow Then
        '            Dim cmdEdit As ImageButton = CType(e.Item.FindControl("cmdEdit"), ImageButton)
        '            Dim imbDelete As ImageButton = CType(e.Item.FindControl("imbDelete"), ImageButton)
        '            Dim cmdUp As ImageButton = CType(e.Item.FindControl("cmdUp"), ImageButton)
        '            Dim cmdDown As ImageButton = CType(e.Item.FindControl("cmdDown"), ImageButton)
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
        '                        .CommandName = "EditLoadDP" & CType(DataBinder.Eval(e.Item.DataItem, "ItemID"), String)
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

        '            If Not Null.IsNull(CType(DataBinder.Eval(e.Item.DataItem, "DPDate"), Date)) Then
        '                Dim lblDPDate As Label = CType(e.Item.FindControl("lblDPDate"), Label)
        '                lblDPDate.Text = CType(DataBinder.Eval(e.Item.DataItem, "DPDate"), Date).ToShortDateString
        '            End If

        '        End If
        '    Catch exc As Exception    'Module failed to RowDataBound
        '        ProcessModuleLoadException(Me, exc)
        '    End Try

        'End Sub

        'Private Sub rlLoadDPs_EditCommand(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListCommandEventArgs) Handles rlLoadDPs.EditCommand
        '    itemId = rlLoadDPs.DataKeys(ListItemType.EditItem).Value
        '    InitAddPanel()
        '    ShowHide(True)
        'End Sub

        'Private Sub rlLoadDPs_ItemCommand(ByVal sender As Object, ByVal e As AjaxControlToolkit.ReorderListCommandEventArgs) Handles rlLoadDPs.ItemCommand
        '    If e.CommandName = "Add" Then
        '        itemId = Null.NullInteger
        '        InitAddPanel()
        '        ShowHide(True)
        '        'ElseIf e.CommandName = "AddLoadDrop" Then
        '        '    Dim DPCity As String = CType(e.Item.FindControl("DPCity"), TextBox).Text
        '        '    Dim DPState As String = CType(e.Item.FindControl("DPState"), TextBox).Text
        '        '    Dim DPDate As Date
        '        '    Try
        '        '        DPDate = CType(CType(e.Item.FindControl("DPDate"), TextBox).Text, Date)
        '        '    Catch
        '        '        DPDate = Now
        '        '    End Try

        '        '    Dim Seq As Integer = rlLoadDPs.Items.Count * 10
        '        '    'Try
        '        '    '    Seq = CType(CType(e.Item.FindControl("txtAjaxSeq"), TextBox).Text, Integer)
        '        '    'Catch
        '        '    '    Seq = 1000
        '        '    'End Try

        '        '    'Dim ItemId As Integer = (New LoadPUsController).AddLoadPU(loadId, CType(DataBinder.Eval(e.Item.DataItem, "PUCity"), String), Now, 1000)
        '        '    itemId = (New LoadDropsController).AddLoadDrop(loadId, DPCity, DPState, DPDate, Seq)
        '        '    ResetViewStates()
        '    ElseIf e.CommandName.StartsWith("EditLoadDP") Then
        '        itemId = Integer.Parse(e.CommandName.Substring(10)) 'rlLoadPUs.DataKeys(0).Value 'Null.NullInteger ' 
        '        InitAddPanel()
        '        ShowHide(True)

        '    ElseIf e.CommandName.StartsWith("Up") Then
        '        Dim S As String = e.CommandName
        '        'S = Replace(S, "Up", "")
        '        Dim I As Integer = CType(Replace(S, "Up", ""), Integer)

        '        Dim objLoadDropsController = New LoadDropsController
        '        Dim objLoadDrop As LoadDropInfo = objLoadDropsController.GetLoadDrop(I)
        '        If Not objLoadDrop Is Nothing Then
        '            objLoadDrop.Seq -= 15

        '            objLoadDropsController.UpdateLoadDrop(objLoadDrop)
        '            FixSeq()
        '        End If
        '        ResetViewStates()

        '    ElseIf e.CommandName.StartsWith("Down") Then
        '        Dim S As String = e.CommandName
        '        'S = Replace(S, "Down", "")
        '        Dim I As Integer = CType(Replace(S, "Down", ""), Integer)

        '        Dim objLoadDropsController = New LoadDropsController
        '        Dim objLoadDrop As LoadDropInfo = objLoadDropsController.GetLoadDrop(I)
        '        If Not objLoadDrop Is Nothing Then
        '            objLoadDrop.Seq += 15

        '            objLoadDropsController.UpdateLoadDrop(objLoadDrop)
        '            FixSeq()
        '        End If
        '        ResetViewStates()

        '    End If
        'End Sub

        'Private Sub odsLoadDrops_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles odsLoadDrops.Inserting

        '    Dim txt_Seq As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_Seq"), TextBox))
        '    Dim txt_DPContact As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPContact"), TextBox))
        '    Dim txt_DPPhone As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPPhone"), TextBox))
        '    Dim txt_DPName As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPName"), TextBox))
        '    Dim txt_DPAddr As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPAddr"), TextBox))
        '    Dim txt_DPCity As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPCity"), TextBox))
        '    Dim txt_DPState As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPState"), TextBox))
        '    Dim txt_ZipCode As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_ZipCode"), TextBox))

        '    Dim txt_DPDate As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_DPDate"), TextBox))
        '    Dim txt_Jobno As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_Jobno"), TextBox))
        '    Dim txt_BillOLay As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_BillOLay"), TextBox))
        '    Dim txt_BOLSeq As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_BOLSeq"), TextBox))
        '    Dim txt_Stime As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_Stime"), TextBox))
        '    Dim txt_Etime As TextBox = (CType(gdvLoadDrops.Rows(gdvLoadDrops.EditIndex).FindControl("txt_Etime"), TextBox))

        '    e.InputParameters("LoadID") = loadId
        '    e.InputParameters("Seq") = (txt_Seq.Text)
        '    e.InputParameters("DPContact") = (txt_DPContact.Text)
        '    e.InputParameters("DPPhone") = (txt_DPPhone.Text)
        '    e.InputParameters("DPName") = (txt_DPName.Text)
        '    e.InputParameters("DPAddr") = (txt_DPAddr.Text)
        '    e.InputParameters("DPCity") = (txt_DPCity.Text)
        '    e.InputParameters("DPState") = (txt_DPState.Text)
        '    e.InputParameters("ZipCode") = (txt_ZipCode.Text)
        '    Try
        '        e.InputParameters("DPDate") = String.Format("{0:d}", Date.Parse(txt_DPDate.Text)) '(txt_DPDate.Text)
        '    Catch
        '    End Try
        '    e.InputParameters("Jobno") = (txt_Jobno.Text) 'String.Format("{0:d}", Date.Parse(txt_Jobno.Text))
        '    e.InputParameters("BillOLay") = (txt_BillOLay.Text) 'String.Format("{0:t}", Date.Parse(txt_BillOLay.Text))
        '    e.InputParameters("BOLSeq") = (txt_BOLSeq.Text)
        '    Try
        '        e.InputParameters("Stime") = String.Format("{0:t}", Date.Parse(txt_Stime.Text)) '(txt_Stime.Text)
        '    Catch
        '    End Try
        '    Try
        '        e.InputParameters("Etime") = String.Format("{0:t}", Date.Parse(txt_Etime.Text)) '(txt_Etime.Text)
        '    Catch
        '    End Try

        'End Sub

        'Private Sub odsLoadDrops_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles odsLoadDrops.Deleting
        '    e.InputParameters("AltId") = gdvLoadDrops.DataKeys(0).Value
        'End Sub

        Private Sub odsLoadDrops_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadDrops.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

        Private Sub txtDPCity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPCity.TextChanged
            'Dim objZipCodesController As New Business.ZipCodesController
            'objZipCodesController.GetStateZipCodeByCity(txtDPCity.Text, txtDPState.Text, txtZipCode.Text)
            txtDPState.Text = "" 'Seatch the city in all states
            imbSearchCity_Click(Nothing, Nothing)
        End Sub

        Private Sub imbSearchCity_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearchCity.Click
            With ddlZipCodes
                .DataValueField = "ItemId"
                .DataTextField = "Display"

                .DataSource = (New ZipCodesController).GetSearchedZipCodes(txtDPCity.Text, "City", txtDPState.Text)
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
                txtDPCity.Text = objZip.City
                txtDPState.Text = objZip.StateCode
                txtZipCode.Text = objZip.ZipCode
            Catch
            End Try
        End Sub

        Private Sub imbAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Dim objLoadDrop As New Business.LoadDropInfo
            'Initialise the ojbLoadDrop object
            objLoadDrop = CType(CBO.InitializeObject(objLoadDrop, GetType(Business.LoadDropInfo)), Business.LoadDropInfo)

            'bind text values to object
            With objLoadDrop
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
                    .Seq = 10 + 10 * gdvLoadDrops.Rows.Count
                End Try
                .DPName = txtDPName.Text
                .DPAddr = txtDPAddr.Text
                .DPCity = txtDPCity.Text
                .DPState = txtDPState.Text
                .ZipCode = txtZipCode.Text
                .DPPhone = txtDPPhone.Text
                Try
                    .DPDate = Date.Parse(txtDPDate.Text)
                Catch
                    .DPDate = #11/11/2222# 'Now
                End Try
                .DPContact = txtDPContact.Text
                .Jobno = txtJobno.Text
                '.BillOLay = txtBillOLay.Text
                .BillOLay = ddlBillOLay.SelectedValue
                .BOLSeq = txtBOLSeq.Text
                Try
                    .Stime = Date.Parse(txtStime.Text)
                Catch
                    '.Stime = Now
                End Try
                Try
                    .Etime = Date.Parse(txtEtime.Text)
                Catch
                    '.Etime = Now
                End Try

            End With 'objLoadDrop


            Dim objLoadDropsController As New Business.LoadDropsController

            'objLoadDropsController.AddLoadDrop(objLoadDrop)
            objLoadDropsController.AddUpdateLoadDrop(objLoadDrop)
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

    End Class 'ViewDrops

End Namespace 'bhattji.Modules.LoadSheets
