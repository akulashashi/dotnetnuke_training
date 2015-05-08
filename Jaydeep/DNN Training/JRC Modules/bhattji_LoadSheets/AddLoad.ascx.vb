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

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.LoadSheets.Business

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class AddLoad
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
        Shared IsCopyLoadDiffLoadType As Boolean = False
#End Region

#Region " Public Methods "

        Private Function PageToItem() As Business.LoadSheetInfo
            Dim objLoadSheet As New Business.LoadSheetInfo
            'Initialise the ojbLoadSheet object
            objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(Business.LoadSheetInfo)), Business.LoadSheetInfo)

            'bind text values to object
            With objLoadSheet
                .ItemId = itemId
                .ModuleId = ModuleId

                'Actual Fields
                Try
                    .JRCIOfficeCode = rblOfficeVendorNO.SelectedValue
                Catch
                End Try

                .CustomerNumber = ddlCustomerNumber.SelectedValue
                ' .CustomerName = txtCustomerName.Text
                .DriverCode = ddlDriverCode.SelectedValue
                .DriverName = txtDriverName.Text
                .BrokerCode = ddlBrokerCode.SelectedValue
                '.BrokerName = txtBrokerName.Text
                .IOCode = ddlIOCode.SelectedValue
                .IOName = txtIOName.Text

                Try
                    .LoadType = rblLoadType.SelectedValue
                Catch
                End Try



                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = UserInfo.UserID

            End With 'objLoadSheet
            Return objLoadSheet
        End Function

        Private Sub BindBkrDrivers()
            With ddlBkrDriverNo
                'If (DriverCode = "") AndAlso (.Items.Count > 1) Then
                '    DriverCode = .SelectedValue
                'End If
                .DataValueField = "DriverCode"
                .DataTextField = "DriverName"
                .DataSource = (New Business.LoadSheetsController).GetBkrDrivers(rblOfficeVendorNO.SelectedValue, ddlBrokerCode.SelectedValue)
                .DataBind()

                .Items.Insert(0, New ListItem("To be assigned", "ZXZX"))
                'If .Items.Count > 1 Then
                '    .SelectedIndex = 1
                '    'If (DriverCode <> "") Then
                '    '    Try
                '    '        .Items.FindByValue(DriverCode).Selected = True
                '    '    Catch
                '    '    End Try
                '    'End If
                'End If
            End With
        End Sub
#End Region

#Region " Private Methods "

        'Private Sub BindUserIOs(Optional ByVal Username As String = "")
        '    Dim LoginName As String = Username
        '    If (LoginName = "") And Request.IsAuthenticated Then
        '        LoginName = UserController.GetCurrentUserInfo.Username
        '    End If
        '    With rblOfficeVendorNO
        '        .DataTextField = "IOName"
        '        .DataValueField = "IOfficeCode"
        '        'If (LoginName = "") Or UserController.GetCurrentUserInfo.IsSuperUser Then
        '        If LoginName = "" Then
        '            .DataSource = (New Business.LoadSheetsController).GetAllInterOffices
        '        Else
        '            .DataSource = (New Business.LoadSheetsController).GetUserIOs(LoginName)
        '        End If
        '        .DataBind()

        '        Try
        '            .Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
        '        Catch
        '        End Try

        '    End With
        'End Sub

        Private Function GetCustomerName(ByVal CustomerName As String) As String
            Try
                Dim s() As String = CustomerName.Split(" | ")
                Return s(0)
            Catch
                Return CustomerName
            End Try
        End Function
        Private Sub BindUserIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") And Request.IsAuthenticated Then
                LoginName = Users.UserController.GetCurrentUserInfo.Username
            End If
            With rblOfficeVendorNO
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
                If (LoginName = "") OrElse Users.UserController.GetCurrentUserInfo.IsSuperUser Then
                    dr = (New Business.LoadSheetsController).GetAllInterOffices
                Else
                    dr = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                End If
                .Items.Clear()
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        'If (Not (rblLoadType.SelectedValue.ToUpper = "OO") AndAlso (dr("BrokerOnly").ToString.ToUpper = "Y")) Then
                        '    valfld = dr("JRCIOfficeCode").ToString
                        '    txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        '    txtfld = Replace(txtfld, "JRC ", "")
                        '    .Items.Add(New ListItem(txtfld.ToUpper, valfld))

                        'End If

                        If rblLoadType.SelectedValue.ToUpper = "OO" Then
                            If dr("BrokerOnly").ToString.ToUpper <> "Y" Then
                                valfld = dr("JRCIOfficeCode").ToString
                                txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                                txtfld = Replace(txtfld, "JRC ", "")
                                .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                            End If
                        Else
                            valfld = dr("JRCIOfficeCode").ToString
                            txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                            txtfld = Replace(txtfld, "JRC ", "")
                            .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                        End If
                    End If
                End While
               
                If (Session.Item("JRCIOfficeCode") Is Nothing) OrElse (Session.Item("JRCIOfficeCode").ToString = "") OrElse (Session.Item("JRCIOfficeCode").ToString = "000000000") Then
                    Session.Item("JRCIOfficeCode") = (New Business.LoadSheetsController).GetUserDefaultIO(LoginName)
                End If

                Try
                    .Items.FindByValue(Session.Item("JRCIOfficeCode").ToString.Substring(0, 9)).Selected = True
                    '.Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
                    If .SelectedIndex < 0 Then .SelectedIndex = 0
                Catch
                    .SelectedIndex = 0
                End Try

            End With
        End Sub

        Private Sub FillIOs(ByVal dr As IDataReader)
            With ddlIOCode
                .Items.Clear()
                If Not dr Is Nothing Then
                    Dim txtfld As String
                    While dr.Read
                        If dr("JRCActive").ToString.ToUpper = "Y" Then
                            txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                            txtfld = Replace(txtfld, "JRC ", "")
                            .Items.Add(New ListItem(txtfld.ToUpper, dr("JRCIOfficeCode").ToString))
                        End If
                    End While
                End If
                .Items.Insert(0, New ListItem("To be Selected", "000000000"))
            End With 'ddlIOCode
        End Sub

        Private Sub FillIoRecoveredLoadSheet(ByVal FromLoadId As String, ByVal ToLoadId As String)
            Dim objLoadPUsController As New LoadPUsController
            Dim objLoadPUInfo As New LoadPUInfo

            Dim PUs As New ArrayList
            PUs = objLoadPUsController.GetLoadPUByLoadId(FromLoadId)
            For Each objLoadPUInfo In PUs
                'Dim objNewLoadPUInfo As New LoadPUInfo
                'objNewLoadPUInfo = objLoadPUInfo
                'objNewLoadPUInfo.LoadID = objLoadSheet.LoadID
                'objLoadPUsController.AddLoadPU(objNewLoadPUInfo)

                objLoadPUInfo.LoadID = ToLoadId
                objLoadPUsController.AddLoadPU(objLoadPUInfo)
            Next

            Dim objLoadDropsController As New LoadDropsController
            Dim objLoadDropInfo As New LoadDropInfo

            Dim Drops As New ArrayList
            Drops = objLoadDropsController.GetLoadDropByLoadId(FromLoadId)
            For Each objLoadDropInfo In Drops
                'Dim objNewLoadDropInfo As New LoadDropInfo
                'objNewLoadDropInfo = objLoadDropInfo
                'objNewLoadDropInfo.LoadID = objLoadSheet.LoadID
                'objLoadDropsController.AddLoadDrop(objNewLoadDropInfo)

                objLoadDropInfo.LoadID = ToLoadId
                objLoadDropsController.AddLoadDrop(objLoadDropInfo)
            Next

            Dim objLoadAcctsController As New LoadAcctsController
            'Dim objLoadAcctInfo As New LoadAcctInfo
            'Dim objIoRecoveryLoadAcctInfo As New LoadAcctInfo
            Dim objIoRecoveryLoadAcctInfo As LoadAcctInfo
            'Dim FromLoadType As String = "OO"

            objIoRecoveryLoadAcctInfo = objLoadAcctsController.GetLoadAcct(objLoadAcctsController.GetLoadAcctId(FromLoadId))
            If Not objIoRecoveryLoadAcctInfo Is Nothing Then
                'FromLoadType = objIoRecoveryLoadAcctInfo.LoadType

                'Get these Three Values from the objIoRecoveryLoadSheet
                objIoRecoveryLoadAcctInfo.JRCIOOffC1 = objIoRecoveryLoadAcctInfo.OfficeOverride 'objIoRecoveryLoadAcctInfo.JRCIOfficeCode
                objIoRecoveryLoadAcctInfo.IOOffN1 = Replace(objLoadAcctsController.GetIOName(objIoRecoveryLoadAcctInfo.JRCIOfficeCode), "JRC - ", "") 'we will get name late on here
                objIoRecoveryLoadAcctInfo.IOOffC1 = objIoRecoveryLoadAcctInfo.JRCIOfficeCode 'Added this to get Code 'we will get name late on here
                ''Trying to get values from FromLoadId User
                'objIoRecoveryLoadAcctInfo.JRCIOOffC1 = objIoRecoveryLoadAcctInfo.OfficeOverride 'objIoRecoveryLoadAcctInfo.JRCIOfficeCode
                'objIoRecoveryLoadAcctInfo.IOOffN1 = objIoRecoveryLoadAcctInfo.JRCIOOffC1
                'objIoRecoveryLoadAcctInfo.IOOffC1 = objIoRecoveryLoadAcctInfo.JRCIOOffC1

                If rblOperationType.SelectedIndex = 1 Then 'It is an IoRecovery Load
                    'Get these Two Values from the objIoRecoveryLoadAcctInfo
                    objIoRecoveryLoadAcctInfo.IOComm1 = objIoRecoveryLoadAcctInfo.JRCOffComm
                    objIoRecoveryLoadAcctInfo.IOAdmin1 = objIoRecoveryLoadAcctInfo.JRCOnePct

                    'Adding following Code specially to add the second line
                    objIoRecoveryLoadAcctInfo.IOComm2 = objIoRecoveryLoadAcctInfo.APComm3
                    objIoRecoveryLoadAcctInfo.APComm3 = Null.NullDouble

                    'Trying to make %Admin to zero to force the Accounting Line to go Invisible
                    objIoRecoveryLoadAcctInfo.JRCOnePct = Null.NullDecimal

                    'Force the Office Pcts to get values from the new Office
                    objIoRecoveryLoadAcctInfo.JRCOffPct = Null.NullDouble 'For the New IoRecovered OO Loads
                    objIoRecoveryLoadAcctInfo.JRCBkrPct = Null.NullDouble 'For the New IoRecovered BK Loads

                End If

                'Adding following Code specially to add the second line
                objIoRecoveryLoadAcctInfo.IOOffL1 = FromLoadId
                objIoRecoveryLoadAcctInfo.IOOffL2 = FromLoadId

                '.IOOffC3 & "<br />" & .IOOffN3
                '=================================================================================================
                'objIoRecoveryLoadAcctInfo.JRCIOOffC2 = objIoRecoveryLoadAcctInfo.IOOffC3
                'objIoRecoveryLoadAcctInfo.IOOffN2 = objIoRecoveryLoadAcctInfo.IOOffN3 'Replace(objLoadAcctsController.GetIOName(objIoRecoveryLoadAcctInfo.JRCIOfficeCode), "JRC - ", "") 'we will get name late on here
                'objIoRecoveryLoadAcctInfo.IOOffC2 = objIoRecoveryLoadAcctInfo.IOOffC3 'Replace(objLoadAcctsController.GetIOName(objIoRecoveryLoadAcctInfo.JRCIOfficeCode), "JRC - ", "") 'we will get name late on here
                'Patched above as per the Eric's eMail 12 Aug 2009
                objIoRecoveryLoadAcctInfo.JRCIOOffC2 = objIoRecoveryLoadAcctInfo.OverrideCode
                objIoRecoveryLoadAcctInfo.IOOffN2 = objIoRecoveryLoadAcctInfo.OverrideCode 'Replace(objLoadAcctsController.GetIOName(objIoRecoveryLoadAcctInfo.JRCIOfficeCode), "JRC - ", "") 'we will get name late on here
                objIoRecoveryLoadAcctInfo.IOOffC2 = objIoRecoveryLoadAcctInfo.OverrideCode 'Replace(objLoadAcctsController.GetIOName(objIoRecoveryLoadAcctInfo.JRCIOfficeCode), "JRC - ", "") 'we will get name late on here
                '=================================================================================================

                objIoRecoveryLoadAcctInfo.IOAdmin3 = Null.NullDouble 'This will force the LoadAcct to get the Data from IOffice, depending upon the LoadType


                objIoRecoveryLoadAcctInfo.LoadID = ToLoadId
                If IsCopyLoadDiffLoadType Then 'It is a CopyLoad
                    'SetLoadAcctForCopyLoadDiffLoadType(objIoRecoveryLoadAcctInfo, FromLoadType)
                    SetLoadAcctForCopyLoadDiffLoadType(objIoRecoveryLoadAcctInfo)
                End If

                'Change the Old Override Code with New Override Code
                If objIoRecoveryLoadAcctInfo.OverrideCode > 0 Then
                    objIoRecoveryLoadAcctInfo.OverrideCode = GetNewOverrideCode(objIoRecoveryLoadAcctInfo.OverrideCode, FromLoadId, ToLoadId)
                End If
                objLoadAcctsController.AddLoadAcct(objIoRecoveryLoadAcctInfo)
            End If
        End Sub 'FillIoRecoveredLoadSheet
        Function GetNewOverrideCode(ByVal OldOverrideCode As Integer, ByVal OldLoadId As String, ByVal NewLoadId As String) As Integer
            Try
                Return OldOverrideCode / Convert.ToInt32(OldLoadId.Substring(3)) * Convert.ToInt32(NewLoadId.Substring(3))
            Catch
                Return OldOverrideCode
            End Try
        End Function

        'Sub SetLoadAcctForCopyLoadDiffLoadType(ByRef objLoadAcct As LoadAcctInfo, ByVal FromLoadType As String)
        Sub SetLoadAcctForCopyLoadDiffLoadType(ByRef objLoadAcct As LoadAcctInfo)
            With objLoadAcct
                .DRTotDue = Null.NullDouble
                .JRCTotal = Null.NullDecimal
                .JRCBkrPct = Null.NullDouble
                .OCommPlus = Null.NullDouble
                .BkrDlr = Null.NullDouble
                .OCommNeg = Null.NullDouble
                .BType = Null.NullString
                .GPPct = Null.NullDouble
                .JRCOffComm = Null.NullDecimal
                .DRCommBase = Null.NullDecimal
                .DRRebur = Null.NullDouble
                .DRPermits = Null.NullDouble
                .DRTolls = Null.NullDouble
                .DRMisc = Null.NullDouble

                ''Removing IOOffL1 & IOOffL2 because of John's Remark, dont know what will happen because of this since it was specifically added by Jaydeep for second line
                'If FromLoadType <> "IO" Then
                If rblOperationType.SelectedIndex <> 1 Then 'For IoRecovery Operation and we need IOOffL1
                    .IOOffL1 = Null.NullString
                    .IOOffL2 = Null.NullString
                End If
            End With
        End Sub

        'Private Sub FillFromIoRecoveryLoadSheet(ByVal objLoadSheet As LoadSheetInfo, ByVal objIoRecoveryLoadSheet As LoadSheetInfo)
        '    Dim objLoadPUsController As New LoadPUsController
        '    Dim objLoadPUInfo As New LoadPUInfo

        '    Dim PUs As New ArrayList
        '    PUs = objLoadPUsController.GetLoadPUByLoadId(objIoRecoveryLoadSheet.LoadID)
        '    For Each objLoadPUInfo In PUs
        '        'Dim objNewLoadPUInfo As New LoadPUInfo
        '        'objNewLoadPUInfo = objLoadPUInfo
        '        'objNewLoadPUInfo.LoadID = objLoadSheet.LoadID
        '        'objLoadPUsController.AddLoadPU(objNewLoadPUInfo)

        '        objLoadPUInfo.LoadID = objLoadSheet.LoadID
        '        objLoadPUsController.AddLoadPU(objLoadPUInfo)
        '    Next

        '    Dim objLoadDropsController As New LoadDropsController
        '    Dim objLoadDropInfo As New LoadDropInfo

        '    Dim Drops As New ArrayList
        '    Drops = objLoadDropsController.GetLoadDropByLoadId(objIoRecoveryLoadSheet.LoadID)
        '    For Each objLoadDropInfo In Drops
        '        'Dim objNewLoadDropInfo As New LoadDropInfo
        '        'objNewLoadDropInfo = objLoadDropInfo
        '        'objNewLoadDropInfo.LoadID = objLoadSheet.LoadID
        '        'objLoadDropsController.AddLoadDrop(objNewLoadDropInfo)

        '        objLoadDropInfo.LoadID = objLoadSheet.LoadID
        '        objLoadDropsController.AddLoadDrop(objLoadDropInfo)
        '    Next

        '    Dim objLoadAcctsController As New LoadAcctsController
        '    Dim objLoadAcctInfo As New LoadAcctInfo
        '    Dim objIoRecoveryLoadAcctInfo As New LoadAcctInfo

        '    objIoRecoveryLoadAcctInfo = objLoadAcctsController.GetLoadAcct(objLoadAcctsController.GetLoadAcctId(objIoRecoveryLoadSheet.LoadID))
        '    If Not objIoRecoveryLoadAcctInfo Is Nothing Then

        '        'Get these Three Values from the objIoRecoveryLoadSheet
        '        objIoRecoveryLoadAcctInfo.JRCIOOffC1 = objIoRecoveryLoadSheet.JRCIOfficeCode
        '        objIoRecoveryLoadAcctInfo.IOOffN1 = objIoRecoveryLoadSheet.JRCIOfficeCode 'we will get name late on here

        '        'Get these Two Values from the objIoRecoveryLoadAcctInfo
        '        objIoRecoveryLoadAcctInfo.IOComm1 = objIoRecoveryLoadAcctInfo.JRCOffComm
        '        objIoRecoveryLoadAcctInfo.IOAdmin1 = objIoRecoveryLoadAcctInfo.JRCOnePct

        '        objIoRecoveryLoadAcctInfo.LoadID = objLoadSheet.LoadID
        '        objLoadAcctsController.AddLoadAcct(objIoRecoveryLoadAcctInfo)
        '    End If

        '    'If Not objIoRecoveryLoadAcctInfo Is Nothing Then
        '    '    objLoadAcctInfo = objIoRecoveryLoadAcctInfo

        '    '    'Get these Three Values from the objIoRecoveryLoadSheet
        '    '    objLoadAcctInfo.JRCIOOffC1 = objIoRecoveryLoadSheet.JRCIOfficeCode
        '    '    objLoadAcctInfo.IOOffN1 = objIoRecoveryLoadSheet.JRCIOfficeCode 'we will get name late on here

        '    '    'Get these Two Values from the objIoRecoveryLoadAcctInfo
        '    '    objLoadAcctInfo.IOComm1 = objIoRecoveryLoadAcctInfo.JRCOffComm
        '    '    objLoadAcctInfo.IOAdmin1 = objIoRecoveryLoadAcctInfo.
        '    'End If

        '    'objLoadAcctInfo.LoadID = objLoadSheet.LoadID
        '    'objLoadAcctsController.AddLoadAcct(objLoadAcctInfo)

        'End Sub 'FillFromIoRecoveryLoadSheet

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                'Dim s As String = ResolveUrl("~")

                cmdCalendarTrailerDue.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTrailerDue)
                'hypLoadDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtLoadDate)

                If Not Page.IsPostBack Then
                    txtLoadDate.Text = Now.ToShortDateString
                    With valLoadDate
                        .MaximumValue = Now.AddDays(90).ToShortDateString
                        .MinimumValue = Now.AddDays(-90).ToShortDateString
                        .ErrorMessage = "<b>Out Of Range</b><br/>Load Date must be within " & .MinimumValue & " & " & .MaximumValue
                    End With

                    ViewState.Add("OfficeVendorNO", rblOfficeVendorNO.SelectedValue)
                    ViewState("RepNo") = "0000000"
                    ViewState("RepName") = "No Rep Assigned"
                    ViewState("RepDlr") = 0
                    ViewState("RepPct") = 0

                    'BindUserIOs()
                    FillIOs((New Business.LoadSheetsController).GetIOSearch("", "IOName", (rblIOSearchType.SelectedIndex < 1)))
                    If ddlIOCode.Items.Count > 0 Then ddlIOCode_SelectedIndexChanged(Nothing, Nothing)

                    'Check if the Operation Type and FromLoadId defined in QueryString
                    If Not Request.QueryString("FromLoadId") Is Nothing AndAlso Request.QueryString("FromLoadId") <> "" Then
                        txtIoRecoveryLoadId.Text = Request.QueryString("FromLoadId")
                        Try
                            rblOperationType.SelectedValue = Request.QueryString("OType")
                            btnIoRecovery_Click(Nothing, Nothing)
                        Catch
                        End Try
                    End If
                End If
                rblLoadType_SelectedIndexChanged(Nothing, Nothing)

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub rblLoadType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLoadType.SelectedIndexChanged
            jrcdrivertable.Visible = rblLoadType.SelectedValue.ToUpper = "OO"
            'jrcdrivertable.Visible = False 'Hide the table permenanly so that the DriverLoad is always "Suspense" to start with
            jrcIOtable.Visible = rblLoadType.SelectedValue.ToUpper = "IO"
            jrcbrokertable.Visible = rblLoadType.SelectedValue.ToUpper = "BK"
            tblTrailerDetails.Visible = (rblLoadType.SelectedValue.ToUpper = "OO") OrElse (rblLoadType.SelectedValue.ToUpper = "BK")

            'If LoadType is IO then Disable the IoRecovery Option
            rblOperationType.Items.FindByValue("IoRecovery").Enabled = (rblLoadType.SelectedValue.ToUpper <> "IO")
            If rblLoadType.SelectedValue.ToUpper = "IO" Then
                'Try
                '    If rblOperationType.Items.FindByValue("IoRecovery").Selected Then rblOperationType.Items.FindByValue("NewLoad").Selected = True
                'Catch
                'End Try
                'rblOperationType.Items.FindByValue("NewLoad").Selected = True
                If (rblOperationType.SelectedIndex < 2) Then rblOperationType.SelectedIndex = 0
                'rblOperationType.Items.FindByValue("IoRecovery").Enabled = False
            Else
                'rblOperationType.Items.FindByValue("IoRecovery").Enabled = True
            End If

            'rblOperationType.Visible = rblLoadType.SelectedValue.ToUpper <> "IO"
            tdIoRecovery.Visible = rblOperationType.SelectedIndex > 0
            'If Not chkIoRecovery.Visible Then chkIoRecovery.Checked = False

            rblOfficeVendorNO.AutoPostBack = rblLoadType.SelectedValue.ToUpper <> "BK"

            'Remove/Add Brokeronly Offices, by rebinding
            BindUserIOs()

            'Populated the DriverDropDown for the Office
            If rblLoadType.SelectedValue.ToUpper <> "BK" Then
                rblOfficeVendorNO_SelectedIndexChanged(Nothing, Nothing)
            End If

            'Press the IO recovery button
            'chkIoRecovery_CheckedChanged(Nothing,Nothing)
            rblOperationType_SelectedIndexChanged(Nothing, Nothing)
        End Sub

        'Private Sub chkIoRecovery_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIoRecovery.CheckedChanged
        '    txtIoRecoveryLoadId.Enabled = chkIoRecovery.Checked
        '    btnIoRecovery.Visible = chkIoRecovery.Checked

        '    btnCustomerSearch.Visible = Not chkIoRecovery.Checked
        '    txtCustomerNumber.Enabled = Not chkIoRecovery.Checked
        '    txtCustomerName.Enabled = Not chkIoRecovery.Checked
        '    ddlCustomerNumber.Enabled = Not chkIoRecovery.Checked
        'End Sub

        Private Sub rblOperationType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblOperationType.SelectedIndexChanged
            tdIoRecovery.Visible = rblOperationType.SelectedIndex > 0
            rblLoadType.Items.FindByValue("IO").Enabled = rblOperationType.SelectedIndex <> 1
            'txtIoRecoveryLoadId.Enabled = rblOperationType.SelectedIndex > 0
            'btnIoRecovery.Visible = rblOperationType.SelectedIndex > 0

            btnCustomerSearch.Visible = rblOperationType.SelectedIndex < 1
            txtCustomerNumber.Enabled = rblOperationType.SelectedIndex < 1
            ' txtCustomerName.Enabled = rblOperationType.SelectedIndex < 1
            ddlCustomerNumber.Enabled = rblOperationType.SelectedIndex < 1

            btnIoRecovery.ImageUrl = "~/images/" & rblOperationType.SelectedValue & ".png"
            Select Case rblOperationType.SelectedIndex
                Case 1
                    imbAdd.OnClientClick = "return confirm('The Original load would be marked COMPLETE. Are you sure you want to proceed ?')"
                    cmdAdd.OnClientClick = "return confirm('The Original load would be marked COMPLETE. Are you sure you want to proceed ?')"
                Case 2
                    imbAdd.OnClientClick = "return confirm('The Original load would be marked VOIDED. Are you sure you want to proceed ?')"
                    cmdAdd.OnClientClick = "return confirm('The Original load would be marked VOIDED. Are you sure you want to proceed ?')"
                Case Else '0,3
                    imbAdd.OnClientClick = ""
                    cmdAdd.OnClientClick = ""
            End Select

        End Sub

        Private Sub rblOfficeVendorNO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblOfficeVendorNO.SelectedIndexChanged
            ClearTrailerDetails()
            If rblOfficeVendorNO.SelectedValue <> ViewState("OfficeVendorNO").ToString Then
                If rblLoadType.SelectedValue.ToUpper = "OO" Then
                    'If txtDriverName.Text <> "" Then
                    '    btnDriverSearch_Click(Nothing, Nothing)
                    'ElseIf txtDriverCode.Text <> "" Then
                    '    txtDriverCode_TextChanged(Nothing, Nothing)
                    'Else
                    '    ddlDriverCode.Items.Clear()
                    '    ddlDriverCode.Items.Insert(0, (New ListItem("No Driver Selected", "ZXZX")))
                    '    lblDriver.Text = ""
                    'End If
                    btnDriverSearch_Click(Nothing, Nothing)
                ElseIf rblLoadType.SelectedValue.ToUpper = "IO" Then
                    valIOCode.InitialValue = rblOfficeVendorNO.SelectedValue
                End If
            End If

            'Session.Clear()
            Session.Item("JRCIOfficeCode") = rblOfficeVendorNO.SelectedValue & rblOfficeVendorNO.SelectedItem.Text
            'Select Case rblLoadType.SelectedValue.ToUpper
            '    Case "BK"
            '        If txtBrokerName.Text <> "" Then
            '            btnBrokerSearch_Click(Nothing,Nothing)
            '        Else
            '            ddlBrokerCode.Items.Clear()
            '        End If
            '    Case "IO"
            '        If txtIOName.Text <> "" Then
            '            btnIOSearch_Click(Nothing,Nothing)
            '        Else
            '            ddlIOCode.Items.Clear()
            '        End If
            '    Case Else '"OO"
            '        If txtDriverName.Text <> "" Then
            '            btnDriverSearch_Click(Nothing,Nothing)
            '        Else
            '            ddlDriverCode.Items.Clear()
            '        End If
            'End Select
        End Sub

        'Private Sub Add()
        '    'Only Add if the Entered Data is Valid
        '    Dim itemId As Integer
        '    Dim objLoadSheetsController As New LoadSheetsController
        '    Dim objLoadSheet As New LoadSheetInfo
        '    Dim objIoRecoveryLoadSheet As New LoadSheetInfo

        '    Dim FromLoadId As String = txtIoRecoveryLoadId.Text
        '    Dim ToLoadId As String = ""
        '    objIoRecoveryLoadSheet.LoadID = ""
        '    'Initialise the ojbLoadSheet object
        '    objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(LoadSheetInfo)), LoadSheetInfo)

        '    If (rblOperationType.SelectedIndex > 0) AndAlso FromLoadId <> "" Then
        '        Try
        '            objIoRecoveryLoadSheet = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(FromLoadId))
        '            If Not objIoRecoveryLoadSheet Is Nothing Then
        '                objLoadSheet = objIoRecoveryLoadSheet

        '                txtCustomerNumber.Text = objIoRecoveryLoadSheet.CustomerNumber
        '                txtCustomerNumber_TextChanged(New System.Object, New System.EventArgs)
        '            End If
        '        Catch
        '        End Try
        '    End If

        '    With objLoadSheet
        '        'Dim strLoadType As String = objLoadSheet.LoadType

        '        If (rblOperationType.SelectedIndex < 3) OrElse (objIoRecoveryLoadSheet Is Nothing) Then 'Templating
        '            If (rblOperationType.SelectedIndex = 2) AndAlso (Not objIoRecoveryLoadSheet Is Nothing) Then 'Conversion
        '                'Put the Original Load Under Suspense
        '                objIoRecoveryLoadSheet.LoadStatus = "SUSPENSE"
        '                objLoadSheetsController.UpdateLoadSheet(objIoRecoveryLoadSheet)
        '            Else
        '                'JRC Office Details
        '                .JRCIOfficeCode = rblOfficeVendorNO.SelectedValue '9 Digit Code
        '                .OfficeVendorNO = .JRCIOfficeCode ' 7 Digit Code & "10"
        '            End If


        '            'Select Case rblLoadType.SelectedValue.ToUpper
        '            '    Case "BK"
        '            '        ViewState.Add("OfficeCode", dr("BKNo"))
        '            '    Case "IO"
        '            '        ViewState.Add("OfficeCode", dr("AVNo"))
        '            '    Case Else '"OO"
        '            '        ViewState.Add("OfficeCode", dr("OONo"))
        '            'End Select
        '            '.OfficeCode = ViewState.Item("OfficeCode").ToString

        '            'Customer Details with Rep Details
        '            .CustomerNumber = ddlCustomerNumber.SelectedValue
        '            .CustomerName = ddlCustomerNumber.SelectedItem.Text
        '            .RepNo = ViewState.Item("RepNo").ToString
        '            .RepName = ViewState.Item("RepName").ToString
        '            .RepDlrStd = CType(IIf(Null.IsNull(ViewState.Item("RepDlr")), 0, ViewState.Item("RepDlr")), Decimal) 'CType(ViewState.Item("RepDlr"), Double)
        '            .RepDlrM = .RepDlrStd
        '            .RepPctStd = CType(IIf(Null.IsNull(ViewState.Item("RepPct")), 0, ViewState.Item("RepPct")), Decimal) 'CType(ViewState.Item("RepPct"), Double)
        '            .RepPctM = .RepPctStd

        '            'Driver Details with Trailer Details
        '            .DriverCode = "ZXZX"
        '            .DriverName = "N/A"
        '            .TrailerType = ddlTrailerType.SelectedValue
        '            .TrailerNumber = txtTrailerNumber.Text
        '            Try
        '                .TrailerDue = Date.Parse(txtTrailerDue.Text)
        '            Catch
        '            End Try

        '            'Transacting InterOffice Details
        '            .JRCIOCode = "000000000"
        '            .IOCode = "0000000"
        '            .IOName = "N/A"

        '            'Broker Details
        '            .BrokerCode = "0000000"
        '            .BrokerName = "N/A"

        '            .LoadType = rblLoadType.SelectedValue.ToUpper
        '            .LoadDate = Now
        '            Select Case .LoadType.ToUpper
        '                Case "BK"
        '                    'strLoadType = "BK"
        '                    .BrokerCode = ddlBrokerCode.SelectedValue
        '                    .BrokerName = ddlBrokerCode.SelectedItem.Text
        '                Case "IO"
        '                    'strLoadType = "AV" '"IO"
        '                    .JRCIOCode = ddlIOCode.SelectedValue
        '                    .IOCode = ddlIOCode.SelectedValue
        '                    .IOName = ddlIOCode.SelectedItem.Text
        '                Case Else '"OO"
        '                    'strLoadType = "OO"
        '                    .DriverCode = ddlDriverCode.SelectedValue
        '                    .DriverName = ddlDriverCode.SelectedItem.Text
        '            End Select

        '        End If

        '        ''Set the Initial Status of the New Load as "WIP"
        '        '.LoadStatus = "WIP"
        '        'Set the Initial Status of the New Load as "SUSPENSE"
        '        .LoadStatus = "SUSPENSE"

        '        'Set Today's Date
        '        .LoadDate = Now
        '        .DeliveryDate = Null.NullDate 'Now
        '        .LoadID = objLoadSheetsController.GetNewLoadId(.JRCIOfficeCode, .LoadType.ToUpper)
        '        ToLoadId = .LoadID
        '        'objLoadSheet.LoadID = objLoadSheetsController.GetNewLoadId(ddlIOCode.SelectedValue, strLoadType)
        '        itemId = objLoadSheetsController.AddLoadSheet(objLoadSheet)
        '        .ItemId = itemId
        '    End With 'objLoadSheet

        '    'objIoRecoveryLoadSheet.LoadID = txtIoRecoveryLoadId.Text
        '    'If objIoRecoveryLoadSheet.LoadID <> "" Then FillFromIoRecoveryLoadSheet(objLoadSheet, objIoRecoveryLoadSheet)
        '    'If chkIoRecovery.Checked AndAlso txtIoRecoveryLoadId.Text <> "" Then FillFromIoRecoveryLoadSheet(objLoadSheet, objIoRecoveryLoadSheet)
        '    'If chkIoRecovery.Checked AndAlso FromLoadId <> "" AndAlso ToLoadId <> "" Then FillIoRecoveredLoadSheet(FromLoadId, ToLoadId)
        '    If (rblOperationType.SelectedIndex > 0) AndAlso FromLoadId <> "" AndAlso ToLoadId <> "" Then FillIoRecoveredLoadSheet(FromLoadId, ToLoadId)


        '    'Dim strParams As String = "IOCode=" & rblOfficeVendorNO.SelectedValue & "&ItemId=" & itemId.ToString
        '    ''If txtCustomerName.Text <> String.Empty Then strParams &= "&Customer=" & txtCustomerName.Text
        '    'strParams &= "&Customer=" & ddlCustomerNumber.SelectedItem.Text
        '    ''If (rblLoadType.SelectedValue.ToUpper = "BK") AndAlso (txtBrokerName.Text <> String.Empty) Then strParams &= "&Broker=" & txtBrokerName.Text
        '    'If rblLoadType.SelectedValue.ToUpper = "BK" Then strParams &= "&Broker=" & ddlBrokerCode.SelectedItem.Text
        '    'Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", strParams), True)

        '    Response.Redirect(EditUrl("ItemId", itemId.ToString), True)

        '    'Response.Redirect(EditUrl("EditType", "EditLoad" & rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
        '    'If txtCustomerName.Text <> String.Empty Then
        '    '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue & "&Customer=" & txtCustomerName.Text), True)
        '    'Else
        '    '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
        '    'End If
        'End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            'Try
            '    ' Only Add if the Entered Data is Valid
            '    If Page.IsValid Then Add()
            'Catch exc As Exception
            '    ProcessModuleLoadException(Me, exc)
            'End Try
            cmdAdd_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            Try
                ' Only Add if the Entered Data is Valid
                If Page.IsValid Then
                    'Only Add if the Entered Data is Valid
                    Dim itemId As Integer
                    Dim objLoadSheetsController As New LoadSheetsController
                    Dim objLoadSheet As New LoadSheetInfo
                    Dim objIoRecoveryLoadSheet As New LoadSheetInfo

                    Dim FromLoadId As String = txtIoRecoveryLoadId.Text
                    Dim ToLoadId As String = ""
                    objIoRecoveryLoadSheet.LoadID = ""
                    'Initialise the ojbLoadSheet object
                    objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(LoadSheetInfo)), LoadSheetInfo)

                    If (rblOperationType.SelectedIndex > 0) AndAlso FromLoadId <> "" Then
                        Try
                            'objIoRecoveryLoadSheet = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(FromLoadId))
                            objIoRecoveryLoadSheet = objLoadSheetsController.GetLoadSheetByLoadId(FromLoadId)
                            If Not objIoRecoveryLoadSheet Is Nothing Then
                                'If objIoRecoveryLoadSheet.LoadStatus.ToUpper = "COMPLETE" Then
                                '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "This Load is already Complete", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                                '    Exit Sub
                                'End If
                                'If Not ((objIoRecoveryLoadSheet.LoadStatus.ToUpper = "WIP") OrElse (objIoRecoveryLoadSheet.LoadStatus.ToUpper = "SUSPENSE")) Then
                                If (objIoRecoveryLoadSheet.LoadStatus.ToUpper = "VOIDED") Then
                                    'If ((objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "WIP") AndAlso (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "SUSPENSE") AndAlso (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "COMPLETE")) Then
                                    'If (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "WIP") OrElse ((objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "SUSPENSE")) Then
                                    'If (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "WIP") Then

                                    lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Load, with LoadStatus='" & objIoRecoveryLoadSheet.LoadStatus & "' cannot be processed</font>"
                                    'Controls.Add(objOI.Popup("Failure", "The Load, with LoadStatus='" & objIoRecoveryLoadSheet.LoadStatus & "' cannot be processed"))
                                    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "The Load, with LoadStatus='" & objIoRecoveryLoadSheet.LoadStatus & "' cannot be processed", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "The Load, with LoadStatus='" & objIoRecoveryLoadSheet.LoadStatus & "' cannot be processed", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                                    Exit Sub
                                End If
                                objLoadSheet = objIoRecoveryLoadSheet

                                txtCustomerNumber.Text = objIoRecoveryLoadSheet.CustomerNumber
                                txtCustomerNumber_TextChanged(Nothing, Nothing)
                            End If
                        Catch
                        End Try
                    End If

                    With objLoadSheet
                        'Dim strLoadType As String = objLoadSheet.LoadType

                        If (objIoRecoveryLoadSheet Is Nothing) OrElse (rblOperationType.SelectedIndex < 3) Then '' Templating 
                            'If (rblOperationType.SelectedIndex = 2) AndAlso (Not objIoRecoveryLoadSheet Is Nothing) Then 'Conversion
                            '    'Put the Original Load Under Suspense
                            '    objIoRecoveryLoadSheet.LoadStatus = "SUSPENSE"
                            '    objLoadSheetsController.UpdateLoadSheet(objIoRecoveryLoadSheet)
                            'ElseIf (rblOperationType.SelectedIndex = 1) AndAlso (Not objIoRecoveryLoadSheet Is Nothing) Then 'IORecovery
                            '    'Put the Original Load Under Suspense
                            '    objIoRecoveryLoadSheet.LoadStatus = "COMPLETE"
                            '    objLoadSheetsController.UpdateLoadSheet(objIoRecoveryLoadSheet)
                            'Else
                            '    ''JRC Office Details
                            '    '.JRCIOfficeCode = rblOfficeVendorNO.SelectedValue '9 Digit Code
                            '    '.OfficeVendorNO = .JRCIOfficeCode ' 7 Digit Code & "10"
                            'End If
                            If (rblOperationType.SelectedIndex = 1) AndAlso (Not objIoRecoveryLoadSheet Is Nothing) Then 'IORecovery
                                'Put the Original Load Under "COMPLETE"
                                objIoRecoveryLoadSheet.LoadStatus = "COMPLETE"
                                objLoadSheetsController.UpdateLoadSheet(objIoRecoveryLoadSheet)
                            ElseIf (rblOperationType.SelectedIndex = 2) AndAlso (Not objIoRecoveryLoadSheet Is Nothing) Then 'IORecovery
                                'Put the Original Load Under "COMPLETE"
                                objIoRecoveryLoadSheet.LoadStatus = "VOIDED"
                                objLoadSheetsController.UpdateLoadSheet(objIoRecoveryLoadSheet)
                            End If


                            'JRC Office Details
                            .JRCIOfficeCode = rblOfficeVendorNO.SelectedValue '9 Digit Code
                            .OfficeVendorNO = .JRCIOfficeCode ' 7 Digit Code & "10"

                            'Select Case rblLoadType.SelectedValue.ToUpper
                            '    Case "BK"
                            '        ViewState.Add("OfficeCode", dr("BKNo"))
                            '    Case "IO"
                            '        ViewState.Add("OfficeCode", dr("AVNo"))
                            '    Case Else '"OO"
                            '        ViewState.Add("OfficeCode", dr("OONo"))
                            'End Select
                            '.OfficeCode = ViewState.Item("OfficeCode").ToString

                            'Customer Details with Rep Details
                            If (ddlCustomerNumber.SelectedValue = "") OrElse (ddlCustomerNumber.SelectedValue = "0000000") Then
                                .CustomerNumber = "0000000"
                                .CustomerName = "CUSTOMER TO BE ASSIGNED"
                            Else
                                .CustomerNumber = ddlCustomerNumber.SelectedValue
                                '.CustomerName = ddlCustomerNumber.SelectedItem.Text
                                .CustomerName = GetCustomerName(ddlCustomerNumber.SelectedItem.Text)
                            End If
                            .RepNo = ViewState.Item("RepNo").ToString
                            .RepName = ViewState.Item("RepName").ToString
                            .RepDlrStd = CType(IIf(Null.IsNull(ViewState.Item("RepDlr")), 0, ViewState.Item("RepDlr")), Decimal) 'CType(ViewState.Item("RepDlr"), Decimal)
                            .RepDlrM = .RepDlrStd
                            .RepPctStd = CType(IIf(Null.IsNull(ViewState.Item("RepPct")), 0, ViewState.Item("RepPct")), Decimal) 'CType(ViewState.Item("RepPct"), Decimal)
                            .RepPctM = .RepPctStd

                            'Driver Details with Trailer Details
                            .DriverCode = "ZXZX"
                            .DriverName = "N/A"

                            'Transacting InterOffice Details
                            .JRCIOCode = "000000000"
                            .IOCode = "0000000"
                            .IOName = "N/A"

                            'Broker Details
                            .BrokerCode = "0000000"
                            .BrokerName = "N/A"

                            '.LoadDate = Null.NullDate 'Now
                            '.DeliveryDate = Null.NullDate '.LoadDate

                            'Dim CopyOperator = (rblOperationType.SelectedIndex > 0) AndAlso (.LoadType = objIoRecoveryLoadSheet.LoadType)
                            'Select Case .LoadType.ToUpper
                            '    Case "BK"
                            '        'strLoadType = "BK"
                            '        If CopyOperator Then
                            '            .BrokerCode = objIoRecoveryLoadSheet.BrokerCode
                            '            .BrokerName = objIoRecoveryLoadSheet.BrokerName
                            '        ElseIf ddlBrokerCode.SelectedValue = "" Then
                            '            .BrokerCode = "0000000"
                            '            .BrokerName = "To be assigned"
                            '        Else
                            '            .BrokerCode = ddlBrokerCode.SelectedValue
                            '            .BrokerName = ddlBrokerCode.SelectedItem.Text
                            '        End If
                            '    Case "IO"
                            '        'strLoadType = "AV" '"IO"
                            '        If ddlIOCode.SelectedValue = "" Then
                            '            .JRCIOCode = "000000000"
                            '            .IOCode = "0000000"
                            '            .IOName = "To be assigned"
                            '        Else
                            '            .JRCIOCode = ddlIOCode.SelectedValue
                            '            .IOCode = ddlIOCode.SelectedValue
                            '            .IOName = ddlIOCode.SelectedItem.Text
                            '        End If
                            '    Case Else '"OO"
                            '        'strLoadType = "OO"
                            '        If CopyOperator Then
                            '            .DriverCode = objIoRecoveryLoadSheet.DriverCode
                            '            .DriverName = objIoRecoveryLoadSheet.DriverName
                            '        ElseIf ddlDriverCode.SelectedValue = "" Then
                            '            .DriverCode = "ZXZX"
                            '            .DriverName = "To be assigned"
                            '        Else
                            '            .DriverCode = ddlDriverCode.SelectedValue
                            '            .DriverName = ddlDriverCode.SelectedItem.Text
                            '        End If
                            'End Select

                        Else 'The Operation type is 3, CopyLoad
                            If objIoRecoveryLoadSheet.LoadType.ToUpper <> rblLoadType.SelectedValue.ToUpper Then
                                IsCopyLoadDiffLoadType = True

                                'Driver Details with Trailer Details
                                .DriverCode = "ZXZX"
                                .DriverName = "N/A"

                                'Transacting InterOffice Details
                                .JRCIOCode = "000000000"
                                .IOCode = "0000000"
                                .IOName = "N/A"

                                'Broker Details
                                .BrokerCode = "0000000"
                                .BrokerName = "N/A"
                            End If
                        End If


                        .LoadType = rblLoadType.SelectedValue.ToUpper
                        Select Case .LoadType.ToUpper 'newLoadType '
                            Case "IO"
                                'strLoadType = "AV" '"IO"
                                If ddlIOCode.SelectedValue = "" Then
                                    .JRCIOCode = "000000000"
                                    .IOCode = "0000000"
                                    .IOName = "To be assigned"
                                Else
                                    .JRCIOCode = ddlIOCode.SelectedValue
                                    .IOCode = ddlIOCode.SelectedValue
                                    .IOName = ddlIOCode.SelectedItem.Text
                                End If

                                'Set the Initial Status of the New IO Load as "WIP"
                                .LoadStatus = "WIP"
                                .CanRecover = ddlCanRecover.SelectedValue

                            Case "BK"
                                'strLoadType = "BK"
                                If ddlBrokerCode.SelectedValue = "" Then
                                    .BrokerCode = "0000000"
                                    .BrokerName = "To be assigned"
                                Else
                                    .BrokerCode = ddlBrokerCode.SelectedValue
                                    .BrokerName = ddlBrokerCode.SelectedItem.Text
                                End If

                                If ddlBkrDriverNo.SelectedIndex > 0 Then .BkrDriverNo = ddlBkrDriverNo.SelectedValue
                                '.BkrInvNo = txtBkrInvNo.Text

                                'Set the Initial Status of the New OO or BK Load as "SUSPENSE"
                                .LoadStatus = "SUSPENSE"

                            Case Else '"OO"
                                'strLoadType = "OO"
                                If ddlDriverCode.SelectedValue = "" Then
                                    .DriverCode = "ZXZX"
                                    .DriverName = "To be assigned"
                                Else
                                    .DriverCode = ddlDriverCode.SelectedValue
                                    .DriverName = ddlDriverCode.SelectedItem.Text
                                End If

                                'Set the Initial Status of the New OO or BK Load as "SUSPENSE"
                                .LoadStatus = "SUSPENSE"

                        End Select

                        'Set only in AddLoadSheet whether the Load was Copied From some Load
                        .CreationSource = rblOperationType.SelectedIndex '= 3(CopiedLoad)

                        If rblOperationType.SelectedIndex < 1 Then
                            'Set the Default TarpLoad needed
                            .TarpLoad = "Y"
                            .TarpMessage = "THIS LOAD MUST BE TARPED"
                        End If

                        'Get the Values for the Trailer
                        .TrailerType = ddlTrailerType.SelectedValue
                        .TrailerNumber = txtTrailerNumber.Text
                        Try
                            .TrailerDue = Date.Parse(txtTrailerDue.Text)
                        Catch
                        End Try

                        ''.LoadStatus = "SUSPENSE"

                        'Set the OffFunds & OffOrgin to US
                        .OffFunds = "US"
                        .OffOrgin = "US"

                        'Set the LoadReport Printed to "Not Printed"
                        .IsPrinted = "N"

                        'Remove Xmission Details
                        .XMissionDate = Null.NullDate
                        .XMissionFile = ""
                        .XMissionSave = False
                        .XmissionSeq = Null.NullDouble

                        .CompletedDate = Null.NullDate
                        .CompletedLoad = Null.NullBoolean

                        'Remove COD/ComCheck details
                        .ComCheckSeq = ""
                        .ComCheckAmt = Null.NullDecimal
                        .CodCheckSeq = ""
                        .CodCheckAmt = Null.NullDecimal

                        'Set the current user as the Dispatch Code
                        .DispatchCode = Users.UserController.GetCurrentUserInfo.Username


                        'Set Load Date to Null for all loads except the IORecovery Load
                        If rblOperationType.SelectedIndex = 1 Then
                            .LoadDate = objIoRecoveryLoadSheet.LoadDate
                        Else
                            '.LoadDate = Null.NullDate
                            Try
                                .LoadDate = Date.Parse(txtLoadDate.Text)
                            Catch
                                .LoadDate = Now 'Null.NullDate '
                            End Try
                        End If

                        '.DeliveryDate = Null.NullDate '.LoadDate
                        .LoadID = objLoadSheetsController.GetNewLoadId(.JRCIOfficeCode, .LoadType.ToUpper)
                        ToLoadId = .LoadID

                        'Set Broker Inv # & Date
                        If .LoadType.ToUpper = "BK" Then
                            If txtBkrInvNo.Text <> "" Then
                                .BkrInvNo = txtBkrInvNo.Text
                            Else
                                .BkrInvNo = .LoadID
                            End If
                        Else
                            .BkrInvNo = ""
                        End If
                        .BkrInvDate = Null.NullDate
                        .EntryDate = Null.NullDate
                        .LastUpdate = Null.NullDate
                        .DeliveryDate = Null.NullDate

                        'objLoadSheet.LoadID = objLoadSheetsController.GetNewLoadId(ddlIOCode.SelectedValue, strLoadType)
                        itemId = objLoadSheetsController.AddLoadSheet(objLoadSheet)
                        .ItemId = itemId
                    End With 'objLoadSheet

                    'objIoRecoveryLoadSheet.LoadID = txtIoRecoveryLoadId.Text
                    'If objIoRecoveryLoadSheet.LoadID <> "" Then FillFromIoRecoveryLoadSheet(objLoadSheet, objIoRecoveryLoadSheet)
                    'If chkIoRecovery.Checked AndAlso txtIoRecoveryLoadId.Text <> "" Then FillFromIoRecoveryLoadSheet(objLoadSheet, objIoRecoveryLoadSheet)
                    'If chkIoRecovery.Checked AndAlso FromLoadId <> "" AndAlso ToLoadId <> "" Then FillIoRecoveredLoadSheet(FromLoadId, ToLoadId)
                    If (rblOperationType.SelectedIndex > 0) AndAlso (FromLoadId <> "") AndAlso (ToLoadId <> "") Then FillIoRecoveredLoadSheet(FromLoadId, ToLoadId)


                    'Dim strParams As String = "IOCode=" & rblOfficeVendorNO.SelectedValue & "&ItemId=" & itemId.ToString
                    ''If txtCustomerName.Text <> String.Empty Then strParams &= "&Customer=" & txtCustomerName.Text
                    'strParams &= "&Customer=" & ddlCustomerNumber.SelectedItem.Text
                    ''If (rblLoadType.SelectedValue.ToUpper = "BK") AndAlso (txtBrokerName.Text <> String.Empty) Then strParams &= "&Broker=" & txtBrokerName.Text
                    'If rblLoadType.SelectedValue.ToUpper = "BK" Then strParams &= "&Broker=" & ddlBrokerCode.SelectedItem.Text
                    'Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", strParams), True)

                    If rblOperationType.SelectedIndex = 3 Then
                        Response.Redirect(EditUrl("ItemId", itemId.ToString, "EditPUDrops", "dnnprintmode=true"), True)
                    Else
                        Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                    End If

                    'Response.Redirect(EditUrl("EditType", "EditLoad" & rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
                    'If txtCustomerName.Text <> String.Empty Then
                    '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue & "&Customer=" & txtCustomerName.Text), True)
                    'Else
                    '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
                    'End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'Private Sub cmdAddWithOutId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddWithOutId.Click
        '    Try
        '        ' Only Add if the Entered Data is Valid
        '        If Page.IsValid = True Then
        '            Dim strParams As String = "OfficeVendorNO=" & rblOfficeVendorNO.SelectedValue
        '            If txtCustomerName.Text <> String.Empty Then strParams &= "&Customer=" & txtCustomerName.Text
        '            If (rblLoadType.SelectedValue.ToUpper = "BK") AndAlso (txtBrokerName.Text <> String.Empty) Then strParams &= "&Broker=" & txtBrokerName.Text
        '            Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", strParams), True)

        '            'Response.Redirect(EditUrl("EditType", "EditLoad" & rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
        '            'If txtCustomerName.Text <> String.Empty Then
        '            '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue & "&Customer=" & txtCustomerName.Text), True)
        '            'Else
        '            '    Response.Redirect(EditUrl("EditLoadType", rblLoadType.SelectedValue, "Edit", "IOCode=" & rblIOCode.SelectedValue), True)
        '            'End If
        '        End If

        '    Catch exc As Exception
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub

        Private Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
            cmdCancel_Click(Nothing, Nothing)
        End Sub
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Try
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub btnIoRecovery_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIoRecovery.Click
            Dim LoadSheetId As Integer = (New LoadSheetsController).GetItemId(txtIoRecoveryLoadId.Text)
            If LoadSheetId > 0 Then
                Dim objIoRecoveryLoadSheet As LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(LoadSheetId)
                If Not objIoRecoveryLoadSheet Is Nothing Then
                    If objIoRecoveryLoadSheet.IORecovery > 0 Then
                        lblMsg.Text = "<font color='red'><b>Failure</b><br/>Cannot Copy IO recovery Load, From Load with LoadId='" & txtIoRecoveryLoadId.Text & "'</font>"
                    Else
                        If rblOperationType.SelectedIndex = 1 Then
                            If (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "COMPLETE") Then
                                If (objIoRecoveryLoadSheet.LoadStatus.ToUpper <> "VOIDED") Then
                                    'If String.IsNullOrEmpty(objIoRecoveryLoadSheet.CanRecover) OrElse objIoRecoveryLoadSheet.CanRecover = Users.UserController.GetCurrentUserInfo.Username Then
                                    If rblOfficeVendorNO.SelectedValue = objIoRecoveryLoadSheet.JRCIOCode Then 'The Office is changed to check that only the intended offfice can convert this load
                                        'If rblOfficeVendorNO.Items.IndexOf(rblOfficeVendorNO.Items.FindByValue(objIoRecoveryLoadSheet.JRCIOfficeCode)) < 0 Then
                                        '    Controls.Add(objOI.Popup("Failure", " You don't have authority over the Load, with LoadId='" & txtIoRecoveryLoadId.Text & "'"))
                                        'Else
                                        txtCustomerNumber.Text = objIoRecoveryLoadSheet.CustomerNumber
                                        txtCustomerNumber_TextChanged(Nothing, Nothing)
                                        'End If
                                    Else
                                        'lblMsg.Text = "<font color='red'><b>Failure</b><br/>You can only convert Load from '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not from '" & objIoRecoveryLoadSheet.JRCIOfficeCode & "'</font>"
                                        lblMsg.Text = "<font color='red'><b>Failure</b><br/>You can only convert Load intended for '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not intended for '" & objIoRecoveryLoadSheet.JRCIOCode & "'</font>"
                                        'Controls.Add(objOI.Popup("Failure", " You can only convert Load from '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not from '" & objIoRecoveryLoadSheet.JRCIOfficeCode & "'"))
                                    End If
                                    'Else
                                    '    lblMsg.Text = "<font color='red'><b>Failure</b><br/>Only User '" & objIoRecoveryLoadSheet.CanRecover & "', can recover this Load </font>"
                                    'End If
                                Else
                                    lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Voided Load cannot be recovered</font>"
                                End If
                            Else
                                lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Load has already been recovered</font>"
                            End If
                        Else
                            If rblOfficeVendorNO.SelectedValue = objIoRecoveryLoadSheet.JRCIOfficeCode Then 'The Office is changed to check that only the intended offfice can convert this load
                                'If rblOfficeVendorNO.Items.IndexOf(rblOfficeVendorNO.Items.FindByValue(objIoRecoveryLoadSheet.JRCIOfficeCode)) < 0 Then
                                '    Controls.Add(objOI.Popup("Failure", " You don't have authority over the Load, with LoadId='" & txtIoRecoveryLoadId.Text & "'"))
                                'Else
                                txtCustomerNumber.Text = objIoRecoveryLoadSheet.CustomerNumber
                                txtCustomerNumber_TextChanged(Nothing, Nothing)
                                'End If

                                'Bring Driver/Broker Details from IoRecoveryLoadSheet
                                'If (objIoRecoveryLoadSheet.LoadType.ToUpper <> "IO") AndAlso (objIoRecoveryLoadSheet.LoadType.ToUpper = rblLoadType.SelectedValue) Then
                                If objIoRecoveryLoadSheet.LoadType.ToUpper = "BK" Then
                                    ddlBrokerCode.Items.Add(New ListItem(objIoRecoveryLoadSheet.BrokerName, objIoRecoveryLoadSheet.BrokerCode))
                                    ddlBrokerCode.SelectedValue = objIoRecoveryLoadSheet.BrokerCode
                                    ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                                ElseIf objIoRecoveryLoadSheet.LoadType.ToUpper = "OO" Then
                                    ddlDriverCode.Items.Add(New ListItem(objIoRecoveryLoadSheet.DriverName, objIoRecoveryLoadSheet.DriverCode))
                                    ddlDriverCode.SelectedValue = objIoRecoveryLoadSheet.DriverCode
                                    ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
                                    Try
                                        txtTrailerNumber.Text = objIoRecoveryLoadSheet.TrailerNumber
                                        ddlTrailerType.SelectedValue = objIoRecoveryLoadSheet.TrailerType
                                    Catch
                                    End Try
                                End If
                                'End If
                            Else
                                'lblMsg.Text = "<font color='red'><b>Failure</b><br/>You can only convert Load from '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not from '" & objIoRecoveryLoadSheet.JRCIOfficeCode & "'</font>"
                                lblMsg.Text = "<font color='red'><b>Failure</b><br/>You can only convert Load from '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not from '" & objIoRecoveryLoadSheet.JRCIOfficeCode & "'</font>"
                                'Controls.Add(objOI.Popup("Failure", " You can only convert Load from '" & rblOfficeVendorNO.SelectedItem.Text & "(" & rblOfficeVendorNO.SelectedValue & ")', not from '" & objIoRecoveryLoadSheet.JRCIOfficeCode & "'"))
                            End If
                        End If
                    End If
                Else
                    lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Load, with LoadId='" & txtIoRecoveryLoadId.Text & "' cannot be processed</font>"
                    'Controls.Add(objOI.Popup("Failure", "The Load, with LoadId='" & txtIoRecoveryLoadId.Text & "' cannot be processed"))
                End If
            Else
                lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Load, with LoadId='" & txtIoRecoveryLoadId.Text & "' not found</font>"
                'Controls.Add(objOI.Popup("Failure", "The Load, with LoadId='" & txtIoRecoveryLoadId.Text & "' not found"))
            End If

        End Sub

        'Private Sub txtCustomerNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerNumber.TextChanged
        '    If txtCustomerNumber.Text.Length > 0 Then
        '        Try
        '            txtCustomerName.Text = (New LoadSheetsController).GetCustomerName(txtCustomerNumber.Text)
        '        Catch
        '        End Try
        '    End If
        'End Sub


        Private Sub txtCustomerNumber_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerNumber.TextChanged
            If Not String.IsNullOrEmpty(txtCustomerNumber.Text) Then
                'Dim CityStateZip As String() = Strings.Split(txtCustomerNumber.Text, "|")
                Dim CityStateZip() As String = Split(txtCustomerNumber.Text, " | ")
                If CityStateZip.Length > 0 Then
                    If CityStateZip.Length > 1 Then
                        txtCustomerNumber.Text = CityStateZip(1)
                    Else
                        txtCustomerNumber.Text = CityStateZip(0)
                    End If
                    btnCustomerSearch_Click(Nothing, Nothing)

                    Dim sm As ScriptManager = AJAX.ScriptManagerControl(Me.Page)
                    sm.SetFocus(ddlCustomerNumber)
                End If
            End If
        End Sub

        Private Sub txtCustomerNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles txtCustomerNumber.TextChanged
            With ddlCustomerNumber
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerNumber.Text, "CustomerNumber", (rblCustomerSearchType.SelectedIndex < 1))
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerNumber.Text, "CustomerNumber")
                .DataValueField = "CustomerNumber" '"CustomerNumber"
                .DataTextField = "CustomerNameNumber"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
                Else
                    .Items.Add(New ListItem("No Customer", ""))
                    lblCustomer.Text = ""
                End If
            End With 'ddlCustomerName

        End Sub

        Private Sub btnCustomerSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCustomerSearch.Click
            With ddlCustomerNumber
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                .DataSource = (New Business.LoadSheetsController).GetCustomerSearch(txtCustomerNumber.Text, "Any", (rblCustomerSearchType.SelectedIndex < 1))
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerNameNumber"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
                Else
                    .Items.Add(New ListItem("No Customer", ""))
                    lblCustomer.Text = ""
                End If
            End With 'ddlCustomerName
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            Dim dr As IDataReader = (New Business.LoadSheetsController).GetCustomerByNumber(ddlCustomerNumber.SelectedValue)
            If dr Is Nothing Then
                lblMsg.Text = "<font color='red'><b>Failure</b><br/>The Customer, with CustomerNumber='" & ddlCustomerNumber.SelectedValue & "' cannot be processed</font>"
                'Controls.Add(objOI.Popup("Failure", "The Customer, with CustomerNumber='" & ddlCustomerNumber.SelectedValue & "' cannot be processed"))
            Else
                dr.Read()
                lblCustomer.Text = "<br />Status: "
                Dim CS As String = dr("CustomerStatus").ToString.ToUpper
                Select Case CS
                    Case "A"
                        lblCustomer.Text &= "<font color='green'>ACTIVE</font><br />"
                    Case "I"
                        lblCustomer.Text &= "<font color='red'>INACTIVE</font><br />"
                    Case "H"
                        lblCustomer.Text &= "<font color='red'>CREDIT HOLD</font><br />"
                    Case Else '"COD"
                        lblCustomer.Text &= "<font color='blue'>CASH ON DELIVERY</font><br />"
                End Select
                lblCustomer.Text &= "Customer Number: " & dr("CustomerNumber").ToString & "<br />"
                If dr("ContactCode").ToString <> String.Empty Then lblCustomer.Text &= dr("ContactCode").ToString & ", "
                lblCustomer.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNumber").ToString)
                If dr("Extension").ToString <> String.Empty Then lblCustomer.Text &= " - " & dr("Extension").ToString
                lblCustomer.Text &= "<br />"
                If dr("FaxNumber").ToString <> String.Empty Then lblCustomer.Text &= "Fax: " & Phone.FormatPhoneNo(dr("FaxNumber").ToString) & "<br />"
                If dr("AddressLine1").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine1").ToString & "<br />"
                If dr("AddressLine2").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine2").ToString & "<br />"
                If dr("AddressLine3").ToString <> String.Empty Then lblCustomer.Text &= dr("AddressLine3").ToString & "<br />"
                lblCustomer.Text &= dr("City").ToString & ", "
                lblCustomer.Text &= dr("State").ToString & " "
                lblCustomer.Text &= dr("ZipCode").ToString
                'ViewState.Add("RepNo", dr("RepNo"))
                'ViewState.Add("RepName", dr("RepName"))
                'ViewState.Add("RepDlr", dr("RepDlr"))
                'ViewState.Add("RepPct", dr("RepPct"))
                ViewState("RepNo") = dr("RepNo")
                ViewState("RepName") = dr("RepName")
                If Null.IsNull(dr("RepDlr")) Then
                    ViewState("RepDlr") = 0
                Else
                    ViewState("RepDlr") = dr("RepDlr")
                End If
                If Null.IsNull(dr("RepPct")) Then
                    ViewState("RepPct") = 0
                Else
                    ViewState("RepPct") = dr("RepPct")
                End If

                If dr("RepName").ToString <> String.Empty Then lblCustomer.Text &= "<br /><br />RepName: " & dr("RepName").ToString & "<br />"

            End If 'Not dr Is Nothing Then

            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            'txtCustomerName.Text = ddlCustomerNumber.SelectedItem.Text
        End Sub

        Private Sub txtDriverCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDriverCode.TextChanged
            With ddlDriverCode
                Dim txt As String = "" '= .Items(0).Text '.SelectedItem.Text
                Dim val As String = "" '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If
                If rblOfficeVendorNO.SelectedIndex > -1 Then
                    .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO(txtDriverCode.Text, rblOfficeVendorNO.SelectedValue, "DriverCode", (rblDriverSearchType.SelectedIndex < 1))
                    '.DataSource = (New Business.LoadSheetsController).GetAllSalesPersonsByJRCIOCode(rblOfficeVendorNO.SelectedValue)
                Else
                    .DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverCode.Text, "DriverCode", (rblDriverSearchType.SelectedIndex < 1))
                End If
                .DataValueField = "DriverCode"
                .DataTextField = "DriverName"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> "" Then .Items.Insert(0, (New ListItem(txt, val)))
                ''If (val <> String.Empty) AndAlso (Not ((.Items.Count > 0) AndAlso (val = .Items(0).Value))) Then .Items.Insert(0, (New ListItem(txt, val)))
                'If val <> "" Then
                '    .Items.Insert(0, (New ListItem(txt, val)))
                '    If (.Items.Count > 1) Then
                '        If (.Items(0).Value = .Items(1).Value) Then
                '            .Items.RemoveAt(0)
                '        End If
                '    End If
                'End If
                .Items.Insert(0, (New ListItem("No Driver Selected", "ZXZX")))
                ClearTrailerDetails()

                If .Items.Count > 1 Then
                    ddlDriverCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    lblDriver.Text = ""
                    txtDriverCode.Text = "ZXZX"
                    txtDriverName.Text = "No Driver Selected"
                End If
            End With 'ddlDriverName

            ViewState("OfficeVendorNO") = rblOfficeVendorNO.SelectedValue
        End Sub
        Private Sub ClearTrailerDetails()
            txtTrailerNumber.Text = ""
            ddlTrailerType.ClearSelection()
        End Sub

        Private Sub btnDriverSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDriverSearch.Click
            With ddlDriverCode
                Dim txt As String = "" '= .Items(0).Text '.SelectedItem.Text
                Dim val As String = "" '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
                If rblOfficeVendorNO.SelectedIndex < 0 Then
                    .Items.Clear()
                    '.DataSource = (New Business.LoadSheetsController).GetDriverSearch(txtDriverName.Text, "DriverName", (rblDriverSearchType.SelectedIndex < 1))
                Else
                    .DataSource = (New Business.LoadSheetsController).GetDriverSearchByIO(txtDriverName.Text, rblOfficeVendorNO.SelectedValue, "DriverName", (rblDriverSearchType.SelectedIndex < 1), 0)
                End If
                .DataValueField = "DriverCode"
                .DataTextField = "DriverName"
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
                .Items.Insert(0, (New ListItem("No Driver Selected", "ZXZX")))

                'If .Items.Count > 1 Then
                '    ddlDriverCode_SelectedIndexChanged(Nothing,Nothing)
                'Else
                '    lblDriver.Text = ""
                '    txtDriverCode.Text = "ZXZX"
                '    txtDriverName.Text = "No Driver Selected"
                'End If
            End With 'ddlDriverName

            ViewState("OfficeVendorNO") = rblOfficeVendorNO.SelectedValue
        End Sub

        Private Sub ddlDriverCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDriverCode.SelectedIndexChanged
            Dim dr As IDataReader = (New Business.LoadSheetsController).GetDriverByCode(ddlDriverCode.SelectedValue)
            Try
                If Not dr Is Nothing Then
                    dr.Read()
                    lblDriver.Text = "<br />Account No: " & dr("AccountNo").ToString
                    lblDriver.Text &= "<br />Status: "
                    If dr("Status").ToString.ToUpper = "N" Then
                        lblDriver.Text &= "<font color='green'>ACTIVE</font><br />"
                    Else
                        lblDriver.Text &= "<font color='red'>INACTIVE</font><br />"
                    End If
                    If dr("OfficeOwner").ToString <> String.Empty Then lblDriver.Text &= "Office: " & dr("OfficeOwner").ToString & "<br />"
                    ' If dr("ContactCode").ToString <> String.Empty Then lblDriver.Text &= dr("ContactCode").ToString & ", "
                    lblDriver.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNo").ToString)
                    If dr("Ext").ToString <> String.Empty Then lblDriver.Text &= " Ext: " & dr("Ext").ToString
                    lblDriver.Text &= "<br />"
                    'If dr("FaxNumber").ToString <> String.Empty Then lblDriver.Text &= "Fax: " & dr("FaxNumber").ToString & "<br />"
                    If dr("AddressLine1").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine1").ToString & "<br />"
                    If dr("AddressLine2").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine2").ToString & "<br />"
                    If dr("AddressLine3").ToString <> String.Empty Then lblDriver.Text &= dr("AddressLine3").ToString & "<br />"
                    lblDriver.Text &= dr("City").ToString & ", "
                    lblDriver.Text &= dr("State").ToString & " "
                    lblDriver.Text &= dr("ZipCode").ToString
                    'If dr("RepName").ToString <> String.Empty Then lblDriver.Text &= "<br /><br />RepName: " & dr("RepName").ToString & "<br />"

                    'lblDriver.Text &= "<br/><font color='red' size='+1'>LastTrailer on Record: " & dr("LastTrailerUsed").ToString & "</font>"
                    Dim strLastTrailer As String = dr("LastTrailerUsed").ToString
                    If String.IsNullOrEmpty(strLastTrailer) Then
                        txtTrailerNumber.Text = String.Empty
                        ddlTrailerType.ClearSelection()
                    Else
                        'Dim arrLastTrailer() As String = Split(strLastTrailer, ",")
                        'If arrLastTrailer.Length > 0 Then
                        '    lblDriver.Text &= "<br/><font color='red' size='+1'>LastTrailer on Record: " & arrLastTrailer(0) & "</font>"
                        '    txtTrailerNumber.Text = arrLastTrailer(0)
                        '    Try
                        '        ddlTrailerType.ClearSelection()
                        '        If Not String.IsNullOrEmpty(arrLastTrailer(1)) Then
                        '            ddlTrailerType.SelectedValue = arrLastTrailer(1).Replace("Type:", "").Trim()
                        '        End If
                        '    Catch
                        '    End Try
                        'End If
                        Dim TrailerNo As String = GetTrailerDetails(strLastTrailer)
                        If TrailerNo <> String.Empty Then
                            lblDriver.Text &= "<br/><font color='red' size='+1'>LastTrailer on Record: " & TrailerNo & "</font>"
                        End If
                    End If
                End If 'Not dr Is Nothing Then

                txtDriverCode.Text = ddlDriverCode.SelectedValue
                txtDriverName.Text = ddlDriverCode.SelectedItem.Text
            Catch
            End Try
        End Sub
        Private Function GetTrailerDetails(ByVal TrailerDetail As String) As String
            If String.IsNullOrEmpty(TrailerDetail) Then Return String.Empty
            Dim arrLastTrailer() As String = Split(TrailerDetail, ",")
            If arrLastTrailer.Length > 0 Then
                txtTrailerNumber.Text = arrLastTrailer(0).Trim()
                Try
                    ddlTrailerType.ClearSelection()
                    If Not String.IsNullOrEmpty(arrLastTrailer(1)) Then
                        ddlTrailerType.SelectedValue = arrLastTrailer(1).Replace("Type:", "").Trim()
                    End If
                Catch
                End Try
                Return arrLastTrailer(0).Trim()
            Else
                Return String.Empty
            End If

        End Function
        Private Sub ddlBkrDriverNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBkrDriverNo.SelectedIndexChanged
            If ddlBkrDriverNo.SelectedValue = "" OrElse ddlBkrDriverNo.SelectedValue = "ZXZX" Then
                lblBkrDriver.Text = ""
                ClearTrailerDetails()
            Else
                Dim BkrDriverCtrl As New bhattji.Modules.BkrSalesPersons.Business.SalesPersonsController
                Dim BkrDriver As bhattji.Modules.BkrSalesPersons.Business.SalesPersonInfo = BkrDriverCtrl.GetSalesPerson(BkrDriverCtrl.GetSalesPersonId(ddlBkrDriverNo.SelectedValue))
                If BkrDriver.LastTrailerUsed = "" Then
                    lblBkrDriver.Text = ""
                    ClearTrailerDetails()
                Else
                    Dim TrailerNo As String = GetTrailerDetails(BkrDriver.LastTrailerUsed)
                    If Not String.IsNullOrEmpty(TrailerNo) Then
                        lblBkrDriver.Text = "<br/><font color='red' size='+1'>LastTrailer on Record: " & TrailerNo & "</font>"
                    End If
                End If
            End If
        End Sub

        Private Sub txtIOCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOCode.TextChanged

            With ddlIOCode
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetIOSearch(txtIOCode.Text, "JRCIOfficeCode", (rblIOSearchType.SelectedIndex < 1))
                '.DataValueField = "JRCIOfficeCode"
                '.DataTextField = "IOName"
                '.DataBind()

                FillIOs((New Business.LoadSheetsController).GetIOSearch(txtIOCode.Text, "JRCIOfficeCode", (rblIOSearchType.SelectedIndex < 1)))

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlIOCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    lblIO.Text = ""
                End If
            End With 'ddlIOCode
        End Sub

        Private Sub btnIOSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIOSearch.Click
            With ddlIOCode
                Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                Dim val As String '= .Items(0).Value '.SelectedValue
                If .Items.Count > 0 Then
                    txt = .Items(0).Text  '.SelectedItem.Text
                    val = .Items(0).Value  '.SelectedValue
                End If

                '.DataSource = (New Business.LoadSheetsController).GetIOSearch(txtIOName.Text, "IOName", (rblIOSearchType.SelectedIndex < 1))
                '.DataValueField = "JRCIOfficeCode"
                '.DataTextField = "IOName"
                '.DataBind()

                FillIOs((New Business.LoadSheetsController).GetIOSearch(txtIOName.Text, "IOName", (rblIOSearchType.SelectedIndex < 1)))

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                If .Items.Count > 0 Then
                    ddlIOCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    lblIO.Text = ""
                End If
            End With 'ddlIOCode

        End Sub

        Private Sub ddlIOCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIOCode.SelectedIndexChanged
            If ddlIOCode.SelectedValue <> "" AndAlso ddlIOCode.SelectedValue <> "000000000" Then
                Dim dr As IDataReader = (New Business.LoadSheetsController).GetIOByCode(ddlIOCode.SelectedValue)
                If Not dr Is Nothing Then
                    dr.Read()
                    lblIO.Text = "<br />"

                    lblIO.Text &= "JRCIOfficeCode: " & dr("JRCIOfficeCode").ToString & ", Active: " & dr("JRCActive").ToString & "<br />"

                    lblIO.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNo").ToString) & "<br />"
                    If dr("FaxNo").ToString <> String.Empty Then lblIO.Text &= "Fax: " & Phone.FormatPhoneNo(dr("FaxNo").ToString) & "<br />"
                    If dr("AddressLine1").ToString <> String.Empty Then lblIO.Text &= dr("AddressLine1").ToString & "<br />"
                    If dr("AddressLine2").ToString <> String.Empty Then lblIO.Text &= dr("AddressLine2").ToString & "<br />"

                    lblIO.Text &= dr("City").ToString & ", "
                    lblIO.Text &= dr("State").ToString & " "
                    lblIO.Text &= dr("ZipCode").ToString

                End If 'Not dr Is Nothing Then

                txtIOCode.Text = ddlIOCode.SelectedValue
                txtIOName.Text = ddlIOCode.SelectedItem.Text

                ddlCanRecover.DataSource = (New Business.LoadAcctsController).GetDispatchersByJRCIOfficeCode9(ddlIOCode.SelectedValue)
                ddlCanRecover.DataBind()
                ddlCanRecover.Items.Insert(0, New ListItem("<Any One>", ""))
            Else
                lblIO.Text = ""
            End If
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
        '        .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "BrokerCode")
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
        '            lblBroker.Text = ""
        '        End If

        '    End With 'ddlDriverName

        'End Sub

        Private Sub txtBrokerCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrokerCode.TextChanged
            If Not String.IsNullOrEmpty(txtBrokerCode.Text) Then
                'Dim CityStateZip As String() = Strings.Split(txtBrokerCode.Text, "|")
                Dim CityStateZip() As String = Split(txtBrokerCode.Text, " | ")
                If CityStateZip.Length > 0 Then
                    If CityStateZip.Length > 1 Then
                        txtBrokerCode.Text = CityStateZip(1)
                    Else
                        txtBrokerCode.Text = CityStateZip(0)
                    End If
                    btnBrokerSearch_Click(Nothing, Nothing)

                    Dim sm As ScriptManager = AJAX.ScriptManagerControl(Me.Page)
                    sm.SetFocus(ddlBrokerCode)
                End If
            End If
        End Sub

        Private Sub btnBrokerSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCode
                'Dim txt As String '= .Items(0).Text '.SelectedItem.Text
                'Dim val As String '= .Items(0).Value '.SelectedValue
                'If .Items.Count > 0 Then
                '    txt = .Items(0).Text  '.SelectedItem.Text
                '    val = .Items(0).Value  '.SelectedValue
                'End If

                '.DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, (rblBrokerSearchType.SelectedIndex < 1))
                .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "Any", (rblBrokerSearchType.SelectedIndex < 1))
                'If rblBrokerSearchType.SelectedIndex < 1 Then
                '    .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "Any", True)
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetBrokerSearch(txtBrokerCode.Text, "Any", False)
                'End If
                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataBind()

                ''If CC <> String.Empty Then .Items.Insert(0, (New ListItem(CN, CC)))
                'If val <> String.Empty Then .Items.Insert(0, (New ListItem(txt, val)))
                ''.Items.Insert(0, (New ListItem("", "0000000")))

                .Items.Insert(0, (New ListItem("No Broker", "0000000")))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                    ddlBrokerCode_SelectedIndexChanged(Nothing, Nothing)
                Else
                    '.Items.Add(New ListItem("No Broker", ""))
                    lblBroker.Text = ""
                End If
            End With 'ddlDriverName

        End Sub

        Private Sub ddlBrokerCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBrokerCode.SelectedIndexChanged
            Dim dr As IDataReader = (New Business.LoadSheetsController).GetBrokerByCode(ddlBrokerCode.SelectedValue)
            If Not dr Is Nothing Then
                dr.Read()
                lblBroker.Text = "<br />BrokerCode: " & dr("BrokerCode").ToString
                lblBroker.Text &= "<br />Status: "
                If dr("BStatus").ToString.ToUpper = "ACTIVE" Then
                    lblBroker.Text &= "<font color='green'>ACTIVE</font><br />"
                Else
                    'lblBroker.Text &= "<font color='red'>INACTIVE</font><br />"
                    lblBroker.Text &= "<font color='red'>" & dr("BStatus").ToString.ToUpper & "</font><br />"
                End If
                lblBroker.Text &= "Broker Code: " & dr("BrokerCode").ToString & "<br />"
                If dr("ContactCode").ToString <> String.Empty Then lblBroker.Text &= dr("ContactCode").ToString & ", "
                lblBroker.Text &= "Phone: " & Phone.FormatPhoneNo(dr("PhoneNo").ToString)
                lblBroker.Text &= "<br />"

                If dr("AddressLine1").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine1").ToString & "<br />"
                If dr("AddressLine2").ToString <> String.Empty Then lblBroker.Text &= dr("AddressLine2").ToString & "<br />"

                lblBroker.Text &= dr("City").ToString & ", "
                lblBroker.Text &= dr("State").ToString & " "
                lblBroker.Text &= dr("ZipCode").ToString

                BindBkrDrivers()
            End If 'Not dr Is Nothing Then

            txtBrokerCode.Text = "" 'ddlBrokerCode.SelectedValue
            'txtBrokerName.Text = ddlBrokerCode.SelectedItem.Text

        End Sub

#End Region

    End Class 'AddLoad

End Namespace 'bhattji.Modules.LoadSheets