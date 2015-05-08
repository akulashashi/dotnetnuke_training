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
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.LoadSheets.Business
#End Region

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class Details
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Private objOI As OptionsInfo

#End Region

#Region " Methods "

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objLoadSheet As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(ItemId)
                'Check for the Not-Null objXYZ
                If Not objLoadSheet Is Nothing Then ItemToPage(objLoadSheet)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objLoadSheet As LoadSheetInfo)
            With objLoadSheet
                Dim I As Integer 'Variable defined for the finding out the Index Value
                'hypLoadAccounting.NavigateUrl = EditUrl("LoadID", .LoadID, "EditAcct")
                'hypLoadAccounting.ToolTip = "Go to Load Accounting for Load '" & .LoadID & "'"
                'hypLoadAccounting.Attributes.Add("onmouseover", "window.status=this.title; return true")

                txtLoadID.Text = .LoadID
                txtOfficeVendorNO.Text = .OfficeVendorNO
                txtJRCIOfficeCode.Text = .JRCIOfficeCode
                If Not Null.IsNull(.LoadDate) Then
                    txtLoadDate.Text = .LoadDate.ToShortDateString
                End If
                If Not Null.IsNull(.DeliveryDate) Then
                    txtDeliveryDate.Text = .DeliveryDate.ToShortDateString
                End If
                chkCompletedLoad.Checked = .CompletedLoad

                If Not Null.IsNull(.CompletedDate) Then
                    txtCompletedDate.Text = .CompletedDate.ToShortDateString
                End If
                txtOfficeCode.Text = .OfficeCode


                ddlCustomerNumber.Text = .CustomerNumber
                txtCustomerName.Text = .CustomerName
                txtCustPO.Text = .CustPO
                txtTrailerNumber.Text = .TrailerNumber


                ddlDriverCode.Text = .DriverCode
                txtDriverName.Text = .DriverName


                ddlBrokerCode.Text = .BrokerCode
                txtBrokerName.Text = .BrokerName

                txtJRCIOCode.Text = .JRCIOCode
                ddlIOCode.Text = .IOCode
                txtIOName.Text = .IOName

                If Not Null.IsNull(.OverrideComm) Then
                    txtOverrideComm.Text = .OverrideComm.ToString
                End If
                If Not Null.IsNull(.DriverPct) Then
                    txtDriverPct.Text = .DriverPct.ToString
                End If
                txtFOB.Text = .FOB
                txtLoadNotes.Text = .LoadNotes
                txtComCheckSeq.Text = .ComCheckSeq
                If Not Null.IsNull(.ComCheckAmt) Then
                    txtComCheckAmt.Text = .ComCheckAmt.ToString
                End If
                txtTarpMessage.Text = .TarpMessage
                txtDispatchCode.Text = .DispatchCode
                txtDispName.Text = .DispName
                'txtLoadStatus.Text = .LoadStatus
                ddlLoadStatus.Text = .LoadStatus
                If Not Null.IsNull(.DispOverride) Then
                    txtDispOverride.Text = .DispOverride.ToString
                End If
                ddlRepNo.Text = .RepNo
                txtRepName.Text = .RepName
                If Not Null.IsNull(.LastUpdate) Then
                    txtLastUpdate.Text = .LastUpdate.ToShortDateString
                End If
                If Not Null.IsNull(.XmissionSeq) Then
                    txtXmissionSeq.Text = .XmissionSeq.ToString
                End If

                I = rblLoadType.Items.IndexOf(rblLoadType.Items.FindByValue(.LoadType.ToString.ToUpper))
                If I > -1 Then
                    rblLoadType.Items(I).Selected = True
                Else
                    rblLoadType.Items(0).Selected = True
                End If
                'Try
                '    ddlLoadType.Items.FindByValue(.LoadType).Selected = True
                'Catch
                'End Try

                If Not Null.IsNull(.DriverComm) Then
                    txtDriverComm.Text = .DriverComm.ToString
                End If
                If Not Null.IsNull(.BrokerComm) Then
                    txtBrokerComm.Text = .BrokerComm.ToString
                End If
                txtLoadWeight.Text = .LoadWeight
                txtLoadPieces.Text = .LoadPieces
                If Not Null.IsNull(.LoadMileage) Then
                    txtLoadMileage.Text = .LoadMileage.ToString
                End If
                'chkAdminExempt.Checked = .AdminExempt
                'chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")

                If .AdminExempt.ToUpper = "Y" Then
                    imgAdminExempt.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgAdminExempt.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkTarpLoad.Checked = (.TarpLoad.ToUpper = "Y")

                If .TarpLoad.ToUpper = "Y" Then
                    imgTarpLoad.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgTarpLoad.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                txtProNox.Text = .ProNox
                txtXMissionFile.Text = .XMissionFile
                If Not Null.IsNull(.XMissionDate) Then
                    txtXMissionDate.Text = .XMissionDate.ToShortDateString
                End If
                If Not Null.IsNull(.EntryDate) Then
                    txtEntryDate.Text = .EntryDate.ToShortDateString
                End If
                If Not Null.IsNull(.RepDlrM) Then
                    txtRepDlrM.Text = .RepDlrM.ToString
                End If
                If Not Null.IsNull(.RepPctM) Then
                    txtRepPctM.Text = .RepPctM.ToString
                End If
                txtRepOverride.Text = .RepOverride
                If Not Null.IsNull(.RepDlrStd) Then
                    txtRepDlrStd.Text = .RepDlrStd.ToString
                End If
                If Not Null.IsNull(.RepPctStd) Then
                    txtRepPctStd.Text = .RepPctStd.ToString
                End If
                txtCorpTo.Text = .CorpTo
                txtTrailerType.Text = .TrailerType
                ddlBrokerType.Text = .BrokerType
                chkOfficePaid.Checked = (.OfficePaid.ToUpper = "Y")

                txtPDCkNo.Text = .PDCkNo
                If Not Null.IsNull(.PDDate) Then
                    txtPDDate.Text = .PDDate.ToShortDateString
                End If
                If Not Null.IsNull(.PDAmt) Then
                    txtPDAmt.Text = .PDAmt.ToString
                End If
                txtProJob.Text = .ProJob
                txtInvCommentA.Text = .InvCommentA
                txtInvCommentB.Text = .InvCommentB
                txtInvCommentC.Text = .InvCommentC
                txtInvCommentD.Text = .InvCommentD
                txtBkrInvNo.Text = .BkrInvNo
                txtReasonFor.Text = .ReasonFor
                If Not Null.IsNull(.BkrInvDate) Then
                    txtBkrInvDate.Text = .BkrInvDate.ToShortDateString
                End If
                chkIOAvail.Checked = (.IOAvail.ToUpper = "Y")
                'chkIsPrinted.Checked = (.IsPrinted.ToUpper = "Y")

                If (.IsPrinted.ToUpper = "Y") OrElse (.IsPrinted.ToUpper = "PRINTED") Then
                    imgIsPrinted.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgIsPrinted.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                txtAcctNull.Text = .AcctNull
                chkBkrFunds.Checked = (.BkrFunds.ToUpper = "I")
                chkOffFunds.Checked = (.OffFunds.ToUpper = "I")
                chkOffOrgin.Checked = (.OffOrgin.ToUpper = "I")
                txtCNOfficeVendorNO.Text = .CNOfficeVendorNO
                If Not Null.IsNull(.PUSEQ) Then
                    txtPUSEQ.Text = .PUSEQ.ToString
                End If
                txtPUCityST.Text = .PUCityST
                txtDPCityST.Text = .DPCityST
                If Not Null.IsNull(.DPSEQ) Then
                    txtDPSEQ.Text = .DPSEQ.ToString
                End If
                chkIsIODiv.Checked = (.IsIODiv.ToUpper = "Y")
                If Not Null.IsNull(.OLPUDate) Then
                    txtOLPUDate.Text = .OLPUDate.ToShortDateString
                End If
                txtOLNoStops.Text = .OLNoStops
                txtCarrierName.Text = .CarrierName
                txtBkrIOName.Text = .BkrIOName
                txtBkrDriverNo.Text = .BkrDriverNo
                txtBKDriver.Text = .BKDriver
                chkCommPaid.Checked = .CommPaid
                txtLDNotesA.Text = .LDNotesA
                txtLDNotesB.Text = .LDNotesB
                txtLDNotesC.Text = .LDNotesC
                txtLDNotesD.Text = .LDNotesD
                'Try
                '    ddlLoadMo.Items.FindByValue(.LoadMo.ToString).Selected = True
                'Catch
                'End Try

                ddlLoadMo.Text = .LoadMo
                ddlLoadYR.Text = .LoadYR
                chkCalc85.Checked = (.Calc85.ToUpper = "Y")
                If Not Null.IsNull(.DvrDedPct) Then
                    txtDvrDedPct.Text = .DvrDedPct.ToString
                End If
                txtDvrDedResn.Text = .DvrDedResn


                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                'Audit Control
                ctlAudit.CreatedByUser = .CreatedByUser
                ctlAudit.CreatedDate = .CreatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId
            End With 'objLoadSheet

        End Sub

        Private Sub ItemToPage(ByVal objLoadPU As LoadPUInfo)
            With objLoadPU

                If Not Null.IsNull(.Seq) Then
                    txtSeq.Text = .Seq.ToString
                End If
                txtPUName.Text = .PUName
                txtPUAdd1.Text = .PUAdd1
                txtPRONo.Text = .PRONo
                txtPUCity.Text = .PUCity
                txtPUState.Text = .PUState
                txtPUTel.Text = .PUTel
                txtPUContact.Text = .PUContact
                If Not Null.IsNull(.PUTime) Then
                    txtPUDate.Text = .PUDate.ToShortDateString
                End If
                If Not Null.IsNull(.PUTime) Then
                    txtPUTime.Text = .PUTime.ToShortTimeString
                End If
                txtPieces.Text = .Pieces
                txtWeight.Text = .Weight
                If Not Null.IsNull(.Miles) Then
                    txtMiles.Text = .Miles.ToString
                End If

            End With 'objLoadPU
        End Sub

        Private Sub ItemToPage(ByVal objLoadDrop As LoadDropInfo)
            With objLoadDrop

                If Not Null.IsNull(.Seq) Then
                    txtSeq.Text = .Seq.ToString
                End If
                txtDPName.Text = .DPName
                txtDPAddr.Text = .DPAddr
                txtDPCity.Text = .DPCity
                txtDPState.Text = .DPState
                txtDPPhone.Text = .DPPhone
                If Not Null.IsNull(.DPDate) Then
                    txtDPDate.Text = .DPDate.ToShortDateString
                End If
                txtDPContact.Text = .DPContact
                txtJobno.Text = .Jobno
                txtBillOLay.Text = .BillOLay
                txtBOLSeq.Text = .BOLSeq
                If Not Null.IsNull(.Stime) Then
                    txtStime.Text = .Stime.ToShortDateString
                End If
                If Not Null.IsNull(.Etime) Then
                    txtEtime.Text = .Etime.ToShortDateString
                End If

            End With 'objLoadDrop
        End Sub


#End Region

#Region " Event Handlers "

        Private Sub Page_Load1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)

                'Put user code to initialize the page here
                Dim RattleImageJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JbRattleImage.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "RattleImageJS", RattleImageJS)
                End If
                Dim JB_ActiveContentJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JB_ActiveContent.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS)
                End If

                ' Determine ItemId of Announcement to Display
                If Not (Request.QueryString("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.QueryString("ItemId"))
                Else
                    itemId = Convert.ToInt32(DotNetNuke.Common.Utilities.Null.NullInteger)

                    Dim MyViewLoadPUs As ViewLoadPUs = CType(LoadControl(ModulePath & "ViewLoadPUs.ascx"), ViewLoadPUs)
                    With MyViewLoadPUs
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .itemId = itemId
                    End With 'MyViewLoadPUs
                    phtLoadPUs.Controls.Add(MyViewLoadPUs)

                    Dim MyViewLoadDrops As ViewLoadDrops = CType(LoadControl(ModulePath & "ViewLoadDrops.ascx"), ViewLoadDrops)
                    With MyViewLoadDrops
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .itemId = itemId
                    End With 'MyViewLoadDrops
                    phtLoadDrops.Controls.Add(MyViewLoadDrops)


                End If

                rblLoadType.Enabled = Null.IsNull(itemId)

                If Not Page.IsPostBack Then
                    If Not Null.IsNull(itemId) Then
                        Dim objLoadSheet As LoadSheetInfo = (New LoadSheetsController).GetLoadSheet(itemId)

                        If Not objLoadSheet Is Nothing Then
                            ItemToPage(objLoadSheet)

                            'LoadPU
                            Dim objLoadPU As New LoadPUInfo

                            objLoadPU = (New LoadPUsController).GetLoadPU(objLoadSheet.ItemId)
                            If Not objLoadPU Is Nothing Then
                                'Load data
                                ItemToPage(objLoadPU)
                            Else ' security violation attempt to access item not related to this Module
                                'Response.Redirect(NavigateURL(), True)
                            End If


                            'LoadDrop
                            Dim objLoadDrop As New LoadDropInfo
                            objLoadDrop = (New LoadDropsController).GetLoadDrop(objLoadSheet.ItemId)

                            If Not objLoadDrop Is Nothing Then
                                'Load data
                                ItemToPage(objLoadDrop)
                            Else ' security violation attempt to access item not related to this Module
                                'Response.Redirect(NavigateURL(), True)
                            End If


                            'Audit Control
                            With ctlAudit
                                .CreatedByUser = objLoadSheet.UpdatedByUser
                                .CreatedDate = objLoadSheet.UpdatedDate.ToString
                            End With 'ctlAudit


                            'Tracking Control
                            With ctlTracking
                                '.URL = objLoadSheet.NavURL
                                .ModuleID = objLoadSheet.ModuleId
                            End With 'ctlTracking

                            'Edit Authority
                            With hypEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypEdit
                            With hypImgEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypImgEdit

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    Else
                        'Set the default LoadType as Driver(0)
                        Try
                            Dim lt As String = Request.QueryString("EditLoadType").ToUpper
                            If lt <> String.Empty Then
                                rblLoadType.Items.FindByValue(lt).Selected = True
                            Else
                                rblLoadType.SelectedIndex = 0
                            End If
                        Catch
                            rblLoadType.SelectedIndex = 0
                        End Try

                        txtOfficeVendorNO.Text = Request.QueryString("IOCode")
                        txtJRCIOfficeCode.Text = txtOfficeVendorNO.Text & "10"

                    End If

                    'Close Authority
                    With hypClose
                        .Visible = True
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypClose
                    With hypImgClose
                        .Visible = True
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypImgClose

                End If


            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim objOI As New OptionsInfo(ModuleId)
                If objOI.OnlyHostCanEdit Then
                    'Dim objUC As New Users.UserController
                    Dim objHostUser As Users.UserInfo = Users.UserController.GetUser(PortalId, UserId, True)
                    If Not objHostUser.IsSuperUser Then
                        ' security violation attempt to access item not related to this Module
                        'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "<a href=""" & NavigateURL() & """ title=""Click to go back"" onmouseover""window.status=this.title; return true"">Requires Host rights</a>", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                        Response.Redirect(NavigateURL(), True)
                    End If
                End If


                'Dim objLoadSheetsController As New Business.LoadSheetsController
                'Dim objLoadSheet As New Business.LoadSheetInfo

                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    itemId = Null.NullInteger()
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))

                    Dim MyViewLoadPUs As ViewLoadPUs = CType(LoadControl(ModulePath & "ViewLoadPUs.ascx"), ViewLoadPUs)
                    With MyViewLoadPUs
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadPUs.ascx")
                        .itemId = itemId
                    End With 'MyViewLoadPUs
                    phtLoadPUs.Controls.Add(MyViewLoadPUs)

                    Dim MyViewLoadDrops As ViewLoadDrops = CType(LoadControl(ModulePath & "ViewLoadDrops.ascx"), ViewLoadDrops)
                    With MyViewLoadDrops
                        '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .ModuleConfiguration = ModuleConfiguration
                        .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewLoadDrops.ascx")
                        .itemId = itemId
                    End With 'MyViewLoadDrops
                    phtLoadDrops.Controls.Add(MyViewLoadDrops)

                End If



                rblLoadType.Enabled = Null.IsNull(itemId)

                If Not Page.IsPostBack Then



                    If Not Null.IsNull(itemId) Then
                        Dim objLoadSheet As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)

                        If Not objLoadSheet Is Nothing Then
                            'Load data
                            ItemToPage(objLoadSheet)

                            'LoadPU
                            Dim objLoadPU As New LoadPUInfo

                            objLoadPU = (New LoadPUsController).GetLoadPU(objLoadSheet.ItemId)
                            If Not objLoadPU Is Nothing Then
                                'Load data
                                ItemToPage(objLoadPU)
                            Else ' security violation attempt to access item not related to this Module
                                'Response.Redirect(NavigateURL(), True)
                            End If


                            'LoadDrop
                            Dim objLoadDrop As New LoadDropInfo
                            objLoadDrop = (New LoadDropsController).GetLoadDrop(objLoadSheet.ItemId)

                            If Not objLoadDrop Is Nothing Then
                                'Load data
                                ItemToPage(objLoadDrop)
                            Else ' security violation attempt to access item not related to this Module
                                'Response.Redirect(NavigateURL(), True)
                            End If


                            'Audit Control
                            With ctlAudit
                                .CreatedByUser = objLoadSheet.UpdatedByUser
                                .CreatedDate = objLoadSheet.UpdatedDate.ToString
                            End With 'ctlAudit


                            'Tracking Control
                            With ctlTracking
                                '.URL = objLoadSheet.NavURL
                                .ModuleID = objLoadSheet.ModuleId
                            End With 'ctlTracking

                            'Edit Authority
                            With hypEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypEdit
                            With hypImgEdit
                                .Visible = IsEditable
                                If .Visible Then
                                    .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                                    .ToolTip = Localization.GetString("Edit")
                                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                End If
                            End With  'hypImgEdit




                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    Else
                        'Set the default LoadType as Driver(0)
                        Try
                            Dim lt As String = Request.QueryString("EditLoadType").ToUpper
                            If lt <> String.Empty Then
                                rblLoadType.Items.FindByValue(lt).Selected = True
                            Else
                                rblLoadType.SelectedIndex = 0
                            End If
                        Catch
                            rblLoadType.SelectedIndex = 0
                        End Try

                        txtOfficeVendorNO.Text = Request.QueryString("IOCode")
                        txtJRCIOfficeCode.Text = txtOfficeVendorNO.Text & "10"

                    End If

                    'Edit Authority
                    With hypClose
                        .Visible = IsEditable
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypClose
                    With hypImgClose
                        .Visible = IsEditable
                        If .Visible Then
                            .NavigateUrl = NavigateURL()
                            .ToolTip = Localization.GetString("Close")
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End If
                    End With  'hypImgClose



                End If

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


#End Region

    End Class

End Namespace
