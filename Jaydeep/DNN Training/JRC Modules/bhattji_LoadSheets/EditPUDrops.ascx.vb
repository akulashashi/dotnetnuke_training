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

#Region " Namespaces "
Imports System
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.LoadSheets.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class EditPUDrops
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        'Private objOI As OptionsInfo
        'Private PickupDate As Date
        Private loadId As String

        'Shared IsCopiedLoad As Boolean

        'Shared IsNeverUpdated As Boolean
#End Region

#Region " Public Methods "

#End Region

#Region " Event Handlers "

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            If AJAX.IsInstalled Then
                'AJAX.WrapUpdatePanelControl(tblLoadPUs, True)
                'AJAX.WrapUpdatePanelControl(tblLoadDrops, True)
                AJAX.WrapUpdatePanelControl(phtLoadPUs, True)
                AJAX.WrapUpdatePanelControl(phtLoadDrops, True)
            End If
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    itemId = Null.NullInteger()
                    loadId = ""
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))
                    loadId = (New Business.LoadSheetsController).GetLoadId(itemId)

                    If Not IsPostBack Then
                        Dim objLoad As LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)

                        If Not objLoad Is Nothing Then
                            'loadId = objLoad.LoadID
                            lblCustomer.Text = objLoad.CustomerName & " (" & objLoad.CustomerNumber & ")"
                            'lblDriver.Text = IIf(objLoad.LoadType = "BK", objLoad.BKDriver, objLoad.DriverName)
                            If (objLoad.LoadType = "BK") Then
                                lblDriver.Text = objLoad.BKDriver
                            Else
                                lblDriver.Text = objLoad.DriverName
                            End If
                            lblCustPO.Text = objLoad.CustPO
                            'Else
                            'loadId = (New Business.LoadSheetsController).GetLoadId(itemId)
                        End If

                        lblLoadId.Text = loadId
                    End If

                    Dim MyEditLoadPUs As EditLoadPUs = CType(LoadControl(ModulePath & "EditLoadPUs.ascx"), EditLoadPUs)
                    With MyEditLoadPUs
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditLoadPUs.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditLoadPUs.ascx")
                        .itemId = itemId
                        .Embeded = True
                    End With 'MyEditLoadPUs
                    phtLoadPUs.Controls.Add(MyEditLoadPUs)

                    Dim MyEditLoadDrops As EditLoadDrops = CType(LoadControl(ModulePath & "EditLoadDrops.ascx"), EditLoadDrops)
                    With MyEditLoadDrops
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditLoadDrops.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditLoadDrops.ascx")
                        .itemId = itemId
                        .Embeded = True
                    End With 'MyEditLoadDrops
                    phtLoadDrops.Controls.Add(MyEditLoadDrops)


                End If

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        'Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click, imbAdd.Click
        '    cmdUpdate_Click(sender, New EventArgs)
        'End Sub
        'Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click, cmdAdd.Click
        '    Try
        '        ' Only Update if the Entered Data is Valid
        '        If Page.IsValid Then
        '            'Dim objLoadSheet As New LoadSheetInfo
        '            ''Initialise the ojbLoadSheet object
        '            'objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(Business.LoadSheetInfo)), LoadSheetInfo)

        '            'bind text values to object
        '            Dim objLoadSheet As LoadSheetInfo = PageToItem()


        '            Dim objLoadSheetsController As New LoadSheetsController
        '            If Null.IsNull(itemId) Then
        '                itemId = objLoadSheetsController.AddLoadSheet(objLoadSheet)
        '            Else
        '                objLoadSheetsController.UpdateLoadSheet(objLoadSheet)
        '            End If

        '            ' url tracking
        '            Dim objUrls As New UrlController
        '            ' url tracking for MediaSrc
        '            'With ctlMediaSrc
        '            '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
        '            'End With 'ctlMediaSrc


        '            'Redirect to the page as selected by the User in DropdownList
        '            Select Case ddlUpdateRedirection.SelectedValue.ToUpper
        '                Case "NEWITEM"
        '                    'Redirect back to the Edit Page of the Item for Add
        '                    Response.Redirect(EditUrl(), True)
        '                Case "EDITITEM"
        '                    'Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '                    Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        '                Case "ITEMDETAILS"
        '                    'Redirect to the Detail Page of this Item for Viewing the details of this Item
        '                    Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
        '                Case "ACCOUNTING"
        '                    'Redirect to the Accounting Page of this Item for Viewing the details of this Item
        '                    Response.Redirect(EditUrl("LoadID", objLoadSheet.LoadID, "EditAcct"), True)
        '                Case Else '"LISTING"
        '                    'Redirect back to the portal home page
        '                    Response.Redirect(NavigateURL(), True)
        '            End Select
        '        End If
        '    Catch exc As Exception
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

        'Private Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        '    cmdCancel_Click(sender, New EventArgs)
        'End Sub
        'Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        '    'Redirect to the page as selected by the User in DropdownList
        '    Select Case ddlUpdateRedirection.SelectedValue.ToUpper
        '        Case "NEWITEM"
        '            'Redirect back to the Edit Page of the Item for Add
        '            Response.Redirect(EditUrl(), True)
        '        Case "EDITITEM"
        '            If Not Null.IsNull(itemId) Then
        '                'Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '                Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        '            Else
        '                'Redirect back to the Edit Page of the Item for Add
        '                Response.Redirect(EditUrl(), True)
        '            End If
        '        Case "ITEMDETAILS"
        '            If Not Null.IsNull(itemId) Then
        '                'Redirect to the Detail Page of this Item for Viewing the details of this Item
        '                Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
        '            Else
        '                'Redirect back to the portal home page
        '                Response.Redirect(NavigateURL(), True)
        '            End If
        '        Case "ACCOUNTING"
        '            If Not Null.IsNull(itemId) Then
        '                ''Redirect to the Accounting Page of this Item for Viewing the details of this Item
        '                'Response.Redirect(hypLoadAccounting.NavigateUrl, True)
        '            Else
        '                'Redirect back to the portal home page
        '                Response.Redirect(NavigateURL(), True)
        '            End If
        '        Case Else '"LISTING"
        '            'Redirect back to the portal home page
        '            Response.Redirect(NavigateURL(), True)
        '    End Select
        'End Sub

        'Private Sub imbDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDelete.Click
        '    cmdDelete_Click(sender, New EventArgs)
        'End Sub
        'Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        '    Try
        '        If Not Null.IsNull(itemId) Then
        '            Dim objLoadSheetsController As New LoadSheetsController
        '            objLoadSheetsController.DeleteLoadSheet(itemId)
        '        End If

        '        ' Redirect back to the portal home page
        '        Response.Redirect(NavigateURL(), True)
        '    Catch exc As Exception
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

#End Region

#Region " Icon Bar "

        Private Sub UpdateDriverStatus(ByVal LoadSheetId As Integer)
            Dim objLoadSheet As LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(LoadSheetId)
            If Not objLoadSheet Is Nothing Then
                Select Case objLoadSheet.LoadType.ToUpper
                    Case "OO"
                        'Dim DriverId As Integer = objLC.GetSalesPersonId(objLoadSheet.DriverCode)
                        Dim objSC As New bhattji.Modules.SalesPersons.Business.SalesPersonsController
                        objSC.ClearLastLoadData(objLoadSheet.LoadID)
                        objSC.RefreshForNullLoadId()
                        'objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
                        objSC.RefreshLastLoadData(objLoadSheet.DriverCode)
                    Case "BK"
                        'Dim DriverId As Integer = objLC.GetBkrSalesPersonId(objLoadSheet.BkrDriverNo)
                        Dim objSC As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
                        objSC.ClearLastLoadData(objLoadSheet.LoadID)
                        objSC.RefreshForNullLoadId()
                        'objSC.RefreshForLastLoadId(objLoadSheet.LoadID)
                        objSC.RefreshLastLoadData(objLoadSheet.BkrDriverNo)
                End Select
            End If
        End Sub

        Private Sub imbHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbHome.Click
            lnbHome_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbHome.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            UpdateDriverStatus(itemId)
            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
            Response.Redirect(ResolveUrl("~/Default.aspx") & "?tabname=Home", True)
        End Sub

        Private Sub imbUpdateLoadsheet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateLoadsheet.Click
            lnbUpdateLoadsheet_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateLoadsheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateLoadsheet.Click
            'If Page.IsValid Then
            '    If Not IsJrcTotalOk() Then
            '        DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '        Exit Sub
            '    End If
            '    Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
            UpdateDriverStatus(itemId)
            '    'Redirect to the Loadsheet Page of this Item for Viewing the details of this Item
            Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
            'Else
            '    errJRCTotal.Text = "Check Summary Totals"
            'End If
        End Sub

        Private Sub imbUpdateAccounting_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateAccounting.Click
            lnbUpdateAccounting_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateAccounting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateAccounting.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            UpdateDriverStatus(itemId)
            'Redirect to the Accounting Page of this Item for Viewing the details of this Item
            Response.Redirect(EditUrl("LoadID", loadId, "EditAcct"), True)
        End Sub

        Private Sub imbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateAddNew.Click
            lnbUpdateAddNew_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateAddNew.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            UpdateDriverStatus(itemId)
            'Redirect back to the Edit Page of the Item for Add
            Response.Redirect(EditUrl(), True)
        End Sub

        Private Sub imbUpdateToList_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateToList.Click
            lnbUpdateToList_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateToList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateToList.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            UpdateDriverStatus(itemId)
            'Redirect back to the portal home page
            Response.Redirect(NavigateURL(), True)
        End Sub

        'Private Sub imbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles imbUpdateToViewer.Click
        '    lnbUpdateToViewer_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles lnbUpdateToViewer.Click
        '    Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
        '    'Redirect to the Detail Page of this Item for Viewing the details of this Item
        '    Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
        'End Sub

        Private Sub imbPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrint.Click
            lnbPrint_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrint.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            Dim strLoadType As String = (New LoadSheetsController).GetLoadSheet(itemId).LoadType
            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
            'Dim NavUrl As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper), True)

            UpdateDriverStatus(itemId)

            ResponseHelper.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & strLoadType.ToUpper))
            'ResponseHelper.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString), True)
        End Sub

        Private Sub imbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintConfirm.Click
            lnbPrintConfirm_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrintConfirm.Click
            'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
            'Dim NavUrl As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper), True)
            'ResponseHelper.Redirect(EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & itemId.ToString, "LoadType=" & ddlLoadType.SelectedValue.ToUpper))

            UpdateDriverStatus(itemId)

            'New PDF Confirm Report
            ResponseHelper.Redirect(EditUrl("ReportType", "LoadConfirm", "Reports", "ItemId=" & itemId.ToString), True)
        End Sub

        'Private Sub imbCancelReload_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancelReload.Click
        '    lnbCancelReload_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbCancelReload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCancelReload.Click
        '    'Redirect back to the Edit Page of the Item for Add
        '    Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        'End Sub

        'Private Sub imbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles imbUpdateContinueEdit.Click
        '    lnbUpdateContinueEdit_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles lnbUpdateContinueEdit.Click
        '    Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
        '    'Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '    Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        'End Sub

        'Private Sub imbEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmail.Click
        '    lnbEmail_Click(Nothing,Nothing)
        'End Sub
        'Private Sub lnbEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmail.Click
        '    'Dim objLoadSheet As LoadSheetInfo = UpdateLoad()
        '    ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '    'Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        'End Sub

        'Private Sub ddleMailTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddleMailTo.SelectedIndexChanged
        '    txteMailTo.Visible = (ddleMailTo.SelectedValue = "")
        'End Sub
        'Private Sub imbEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmail.Click, imbeMailTo.Click
        '    lnbEmail_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmail.Click
        '    If ddleMailTo.SelectedValue <> "" Then
        '        Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, ddleMailTo.SelectedValue)
        '        txteMailTo.Text = Dispatcher.Email
        '    End If
        '    'ResponseHelper.Redirect("mailto:" & Dispatcher.Email & ";" & Dispatcher.Membership.Email & "&Subject=IO Load Sold&Body=The IO Load has been sold to the Office")
        '    If txteMailTo.Text <> "" Then
        '        SendNotification(txteMailTo.Text, ddleMailTo.SelectedValue) 'Dispatcher.DisplayName)
        '    End If
        'End Sub
        'Private Sub imbEmailCanRecover_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmailCanRecover.Click
        '    If ddlCanRecover.SelectedValue <> "" Then
        '        Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, ddlCanRecover.SelectedValue)
        '        SendNotification(Dispatcher.Email, ddlCanRecover.SelectedValue) 'Dispatcher.DisplayName)
        '    End If
        'End Sub

        'Private Sub imbVoidLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbVoidLoad.Click
        '    lnbVoidLoad_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbVoidLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbVoidLoad.Click
        '    Try
        '        ''If ddlLoadStatus.Items.FindByValue("VOIDED").Selected Then
        '        ''    lnbVoid.Text = "<br/><font size='+1' color='red'>LOAD VOIDED</font>"
        '        ''Else
        '        ''    ddlLoadStatus.ClearSelection()
        '        ''    ddlLoadStatus.Items.FindByValue("VOIDED").Selected = True
        '        ''    'ddlLoadStatus.SelectedValue = "VOIDED"
        '        ''End If
        '        ''ddlLoadStatus.Items.FindByValue("VOIDED").Selected = True
        '        'ddlLoadStatus.SelectedValue = "VOIDED"
        '        'SetLoadStatusText(ddlLoadStatus.SelectedItem.Text)
        '        ''SetLoadStatus()
        '        'HideWhenLoadIsVoid()
        '        ''lnbUpdateToList_Click(Nothing, Nothing)
        '        ''lnbUpdateContinueEdit_Click(Nothing, Nothing)
        '        Dim objLSC As New LoadSheetsController
        '        objLSC.VoidLoad(txtLoadID.Text)

        '        'Set the OffLoad to WIP if the Load Is IORecovered
        '        'Dim objLSC As New LoadSheetsController
        '        Dim objLAC As New LoadAcctsController
        '        Dim objLoadAcct As LoadAcctInfo = objLAC.GetLoadAcctByLoadId(txtLoadID.Text)
        '        If (Not objLoadAcct Is Nothing) AndAlso objLoadAcct.IsIORecoveredLoad AndAlso (objLoadAcct.IOOffL1 <> "") Then '
        '            Dim objOriginalLoad As LoadSheetInfo = objLSC.GetLoadSheetByLoadId(objLoadAcct.IOOffL1)
        '            If Not objOriginalLoad Is Nothing Then
        '                objOriginalLoad.LoadStatus = "WIP"
        '                objLSC.UpdateLoadSheet(objOriginalLoad)
        '            End If
        '        End If

        '        'Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
        '        Response.Redirect(NavigateURL, True)
        '    Catch
        '    End Try
        'End Sub

        'Private Sub imbUnVoidLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUnVoidload.Click
        '    lnbUnVoidLoad_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbUnVoidLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles inbUnVoidLoad.Click
        '    Try
        '        'If ddlLoadStatus.Items.FindByValue("VOIDED").Selected Then
        '        '    ddlLoadStatus.ClearSelection()
        '        '    'ddlLoadStatus.Items.FindByValue("SUSPENSE").Selected = True
        '        '    ddlLoadStatus.SelectedValue = "SUSPENSE"
        '        'End If
        '        ddlLoadStatus.SelectedValue = "SUSPENSE"
        '        SetLoadStatus()
        '        HideWhenLoadIsVoid(True)

        '        lnbUpdateContinueEdit_Click(Nothing, Nothing)
        '    Catch
        '    End Try
        'End Sub

        'Private Sub imbCopyLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCopyLoad.Click
        '    lnbCopyLoad_Click(Nothing, Nothing)
        'End Sub
        'Private Sub lnbCopyLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCopyLoad.Click
        '    Response.Redirect(EditUrl("FromLoadId", txtLoadID.Text, "Edit", "OType=CopyLoad"), True)
        'End Sub


#End Region

    End Class 'EditPUDrops

End Namespace 'bhattji.Modules.LoadSheets