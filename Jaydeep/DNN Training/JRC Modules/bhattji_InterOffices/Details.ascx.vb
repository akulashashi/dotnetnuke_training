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
Imports bhattji.Modules.InterOffices.Business
#End Region

Namespace bhattji.Modules.InterOffices

    Public MustInherit Class Details
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Private objOI As OptionsInfo

#End Region

#Region " Methods "
        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objInterOffice As InterOfficeInfo = (New InterOfficesController).GetInterOffice(ItemId)
                'Check for the Not-Null objInterOffice
                If Not objInterOffice Is Nothing Then ItemToPage(objInterOffice)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objInterOffice As InterOfficeInfo)
            'Load objInterOffice data to the Page

            With objInterOffice
                txtJRCIOfficeCode.Text = .JRCIOfficeCode
                txtIOfficeCode.Text = .IOfficeCode
                txtIOName.Text = .IOName
                txtAbvrName.Text = .AbvrName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtCity.Text = .City
                txtState.Text = .State
                txtZipCode.Text = .ZipCode
                txtCountryCode.Text = .CountryCode
                txtPhoneNo.Text = .PhoneNo
                txtExt.Text = .Ext
                txtEmailAddress.Text = .EmailAddress
                txtCommRate.Text = .CommRate
                If .Status.ToUpper = "Y" Then
                    chkStatus.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkStatus.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                'chkStatus.Checked = (.Status.ToUpper = "Y")
                'txtLoadType.Text = .LoadType
                txtDivision.Text = .Division
                txtFaxNo.Text = .FaxNo
                If .OfficeOR.ToUpper = "Y" Then
                    chkOfficeOR.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkOfficeOR.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkOfficeOR.Checked = (.OfficeOR.ToUpper = "Y")
                txtOfficeORAcct.Text = .OfficeORAcct
                txtOfficeORPct.Text = .OfficeORPct.ToString
                'txtOfficeCodeNo.Text = .OfficeCodeNo
                txtLogOnPW.Text = .LogOnPW
                'txtOfficName.Text = .OfficName
                'txtOfficeAddr.Text = .OfficeAddr
                'txtOfficeAbrv.Text = .OfficeAbrv
                txtTempFile1.Text = .TempFile1
                txtOONo.Text = .OONo
                txtBKNo.Text = .BKNo
                txtAVNo.Text = .AVNo
                'chkUseDispatch.Checked = (.UseDispatch.ToUpper = "Y")
                txtOfficePct.Text = .OfficePct.ToString
                txtGenCode.Text = .LoadAcct
                txtLoadAcct.Text = .LoadAcct
                txtDiscAcct.Text = .DiscAcct
                txtDetenAcct.Text = .DetenAcct
                txtTollsAcct.Text = .TollsAcct
                txtFuelAcct.Text = .FuelAcct
                txtDropAcct.Text = .DropAcct
                txtReconAcct.Text = .ReconAcct
                txtTarpAcct.Text = .TarpAcct
                txtLumperAcct.Text = .LumperAcct
                txtUnloadAcct.Text = .UnloadAcct
                txtAdminMiscAcct.Text = .AdminMiscAcct
                txtBKOfficePct.Text = .BKOfficePct
                txtLastXferDate.Text = .LastXferDate.ToShortDateString
                txtLastXmission.Text = .LastXmission
                txtXfer.Text = .Xfer.ToString
                ddlNoOffChar.Text = .NoOffChar

                'chkAllowORide.Checked = (.AllowORide.ToUpper = "Y")
                'txtJRCAdminP.Text = .JRCAdminP.ToString
                'txtReminder.Text = .Reminder
                'txtDefDispNo.Text = .DefDispNo
                'txtDefDispName.Text = .DefDispName
                txtLoadAcctB.Text = .LoadAcctB
                txtDiscAcctB.Text = .DiscAcctB
                txtDetenAcctB.Text = .DetenAcctB
                txtTollsAcctB.Text = .TollsAcctB
                txtFuelAcctB.Text = .FuelAcctB
                txtDropAcctB.Text = .DropAcctB
                txtReconAcctB.Text = .ReconAcctB
                txtTarpAcctB.Text = .TarpAcctB
                txtLumperAcctB.Text = .LumperAcctB
                txtUnloadAcctB.Text = .UnloadAcctB
                txtAdminMiscAcctB.Text = .AdminMiscAcctB
                txtConfName.Text = .ConfName
                txtConfAddr.Text = .ConfAddr
                txtConfSTZ.Text = .ConfSTZ
                txtConfPNo.Text = .ConfPNo
                txtBWordsA.Text = .BWordsA
                txtBWordsB.Text = .BWordsB
                txtBWordsC.Text = .BWordsC
                If .PASplit.ToUpper = "Y" Then
                    chkPASplit.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkPASplit.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkPASplit.Checked = (.PASplit.ToUpper = "Y")

                If .CommAdj.ToUpper = "Y" Then
                    chkCommAdj.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkCommAdj.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkCommAdj.Checked = (.CommAdj.ToUpper = "Y")
                'chkMultiSing.Checked = (.MultiSing.ToUpper = "Y")
                If .BrokerOnly.ToUpper = "Y" Then
                    chkBrokerOnly.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkBrokerOnly.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkBrokerOnly.Checked = (.BrokerOnly.ToUpper = "Y")
                'chkAutoLoadSeq.Checked = (.AutoLoadSeq.ToUpper = "Y")

                ddlWhatDivision.Text = .WhatDivision
                If .IntraOComm.ToUpper = "Y" Then
                    chkIntraOComm.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkIntraOComm.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkIntraOComm.Checked = (.IntraOComm.ToUpper = "Y")
                'chkInitQForCust.Checked = (.InitQForCust.ToUpper = "Y")
                'txtDay0.Text = .Day0.ToString
                'txtDay7.Text = .Day7.ToString
                'txtDay15.Text = .Day15.ToString
                'txtDay30.Text = .Day30.ToString
                'txtAlumaPct.Text = .AlumaPct.ToString
                'If Not Null.IsNull(.Lastcorpbu) Then
                '    txtLastcorpbu.Text = .Lastcorpbu.ToShortDateString
                'End If
                If .XMissionSeq.ToUpper = "Y" Then
                    chkXMissionSeq.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkXMissionSeq.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                'chkXMissionSeq.Checked = (.XMissionSeq.ToUpper = "Y")
                'txtCNOfficName.Text = .CNOfficName
                'txtOffOrgin.Text = .OffOrgin
                If .DoABU.ToUpper = "Y" Then
                    chkDoABU.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkDoABU.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                'chkDoABU.Checked = (.DoABU.ToUpper = "Y")
                'txtTSL.Text = .TSL
                'txtTPBCalc.Text = .TPBCalc
                'If Not Null.IsNull(.LastCustUpd) Then
                '    txtLastCustUpd.Text = .LastCustUpd.ToShortDateString
                'End If
                'If Not Null.IsNull(.LastUpdTime) Then
                '    txtLastUpdTime.Text = .LastUpdTime.ToShortDateString
                'End If
                txtAPCodeFM.Text = .APCodeFM
                txtAbvrNameFM.Text = .AbvrNameFM
                If Not Null.IsNull(.CommRateFM) Then
                    txtCommRateFM.Text = .CommRateFM.ToString
                End If
                If Not Null.IsNull(.BKCommRateFM) Then
                    txtBKCommRateFM.Text = .BKCommRateFM.ToString
                End If
                If .SubOffComm.ToUpper = "Y" Then
                    chkSubOffComm.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkSubOffComm.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                'chkSubOffComm.Checked = (.SubOffComm.ToUpper = "Y")
                'If Not Null.IsNull(.UserOn) Then
                '    txtUserOn.Text = .UserOn.ToString
                'End If
                'txtMgrCode.Text = .MgrCode
                'txtMgrName.Text = .MgrName
                'If Not Null.IsNull(.CommRatex) Then
                '    txtCommRatex.Text = .CommRatex.ToString
                'End If
                'If Not Null.IsNull(.BKCommRate) Then
                '    txtBKCommRate.Text = .BKCommRate.ToString
                'End If

                'chkMGRSplit.Checked = (.MGRSplit.ToUpper = "Y")
                'txtIODiv.Text = .IODiv
                'txtLogDisp.Text = .LogDisp
                'txtLogDispName.Text = .LogDispName
                'txtLogonOffice.Text = .LogonOffice
                'txtJRCOfficeNo.Text = .JRCOfficeNo
                If .AllowCDed.ToUpper = "Y" Then
                    chkAllowCDed.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkAllowCDed.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                'chkAllowCDed.Checked = (.AllowCDed.ToUpper = "Y")
                txtDvrDAcct1.Text = .DvrDAcct1
                'txtDvrDAcct2.Text = .DvrDAcct2
                If Not Null.IsNull(.OOLoadNo) Then
                    txtOOLoadNo.Text = .OOLoadNo.ToString
                End If
                If Not Null.IsNull(.BKLoadNo) Then
                    txtBKLoadNo.Text = .BKLoadNo.ToString
                End If
                If Not Null.IsNull(.AVLoadNo) Then
                    txtAVLoadNo.Text = .AVLoadNo.ToString
                End If

                If .JRCActive.ToUpper = "Y" Then
                    chkJRCActive.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    chkJRCActive.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                'chkJRCActive.Checked = (.JRCActive.ToUpper = "Y")

                'If (.JRCActive.ToUpper = "Y") Then
                '    imgJRCActive.ImageUrl = ResolveUrl("~/images/icon_survey_32px.gif") 'FileManager/files/OK.gif
                'Else
                '    imgJRCActive.ImageUrl = ResolveUrl("~/images/delete.gif") 'unchecked.gif
                'End If

                'If Not Null.IsNull(.ViewOrder) Then
                '    txtViewOrder.Text = .ViewOrder.ToString
                'End If


                'With hypEditItem
                '    .Visible = IsEditable
                '    If .Visible Then
                '        .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                '        .Attributes.Add("onmouseover", "window.status=this.title; return true")
                '    End If
                'End With  'hypEditItem


                'Edit Authority
                'With hypEdit
                '    .Visible = IsEditable
                '    If .Visible Then
                '        .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                '        .ToolTip = Localization.GetString("Edit")
                '        .Attributes.Add("onmouseover", "window.status=this.title; return true")
                '    End If
                'End With  'hypEdit
                'With hypImgEdit
                '    .Visible = IsEditable
                '    If .Visible Then
                '        .NavigateUrl = EditUrl("ItemID", itemId.ToString)
                '        .ToolTip = Localization.GetString("Edit")
                '        .Attributes.Add("onmouseover", "window.status=this.title; return true")
                '    End If
                'End With  'hypImgEdit

                'Audit Control
                With ctlAudit
                    .CreatedByUser = objInterOffice.UpdatedByUser
                    .CreatedDate = objInterOffice.UpdatedDate.ToString
                End With 'ctlAudit

                'Tracking Control
                With ctlTracking
                    ' .URL = objInterOffice.NavURL
                    .ModuleID = objInterOffice.ModuleId
                End With 'ctlTracking

            End With 'objInterOffice

        End Sub
        Private Sub SetIconBar()
            'Give the ImageUrl
            hypImgEdit.ImageUrl = ModulePath & "img/bhattji_Edit.jpg"

            'Give Tooltip
            hypEdit.ToolTip = hypEdit.Text

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
                    .ImageUrl = ModulePath & "img/bhattji_Close.jpg"
                    .NavigateUrl = NavigateURL()
                    .ToolTip = Localization.GetString("Close")
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgClose

            'Print Authority
            With hypPrint
                .Visible = True
                If .Visible Then
                    .NavigateUrl = EditUrl("ItemID", itemId.ToString, "ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                    .Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypPrint
            With hypImgPrint
                .Visible = True
                If .Visible Then
                    .ImageUrl = ModulePath & "img/bhattji_Print.jpg"
                    .NavigateUrl = hypPrint.NavigateUrl
                    .Target = "_blank"
                    .ToolTip = Localization.GetString("Print", LocalResourceFile)
                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                End If
            End With  'hypImgPrint
        End Sub 'SetIconBar()
#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                End If

                If Not Page.IsPostBack Then
                    SetIconBar()
                    If Not Null.IsNull(itemId) Then
                        Dim objInterOffice As InterOfficeInfo = (New InterOfficesController).GetInterOffice(itemId)

                        If Not objInterOffice Is Nothing Then
                            ItemToPage(objInterOffice)

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

                            'Audit Control
                            With ctlAudit
                                .CreatedByUser = objInterOffice.UpdatedByUser
                                .CreatedDate = objInterOffice.UpdatedDate.ToString
                            End With 'ctlAudit

                            'Tracking Control
                            With ctlTracking
                                ' .URL = objInterOffice.NavURL
                                .ModuleID = objInterOffice.ModuleId
                            End With 'ctlTracking

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

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

#End Region

    End Class

End Namespace
