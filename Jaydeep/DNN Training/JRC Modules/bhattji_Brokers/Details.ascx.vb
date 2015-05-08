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
Imports bhattji.Modules.Brokers.Business
#End Region

Namespace bhattji.Modules.Brokers

    Public MustInherit Class Details
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Private objOI As OptionsInfo

#End Region

#Region " Methods "
        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objBroker As Business.BrokerInfo = (New Business.BrokersController).GetBroker(ItemId)
                'Check for the Not-Null objBroker
                If Not objBroker Is Nothing Then ItemToPage(objBroker)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objBroker As Business.BrokerInfo)
            'Load objBroker data to the Page
            With objBroker
                txtBrokerCode.Text = .BrokerCode
                txtBrokerName.Text = .BrokerName
                txtAddressLine1.Text = .AddressLine1
                txtAddressLine2.Text = .AddressLine2
                txtCity.Text = .City
                txtState.Text = .State
                txtZipCode.Text = .ZipCode
                txtPhoneNo.Text = Phone.FormatPhoneNo(.PhoneNo)
                txtExt.Text = .Ext
                txtContactCode.Text = .ContactCode
                txtVendorRef.Text = .VendorRef
                txtCountryCode.Text = .CountryCode
                txtEmailAddress.Text = .EmailAddress
                If Not Null.IsNull(.CommRate) Then
                    txtCommRate.Text = .CommRate.ToString
                End If

                If .Status.ToUpper = "Y" Then
                    imgStatus.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgStatus.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If
                txtLoadType.Text = .LoadType
                txtFavorite.Text = .Favorite
                txtSortSeq.Text = .SortSeq
                txtBrokerNotes.Text = .BrokerNotes
                txtBkrType.Text = .BkrType
                If Not Null.IsNull(.CorpUpd) Then
                    txtCorpUpd.Text = .CorpUpd.ToShortDateString
                End If
                txtDivision.Text = .Division
                txtFaxNo.Text = Phone.FormatPhoneNo(.FaxNo)
                txtJRCTrailer.Text = .JRCTrailer

                If .AdminExempt.ToUpper = "Y" Then
                    imgAdminExempt.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgAdminExempt.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                If .BStatus.ToUpper = "ACTIVE" Then
                    imgBStatus.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgBStatus.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                If .ThirdPartyOK = "Y" Then
                    imgThirdPartyOK.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                Else
                    imgThirdPartyOK.ImageUrl = ResolveUrl("~/images/delete.gif")
                End If

                If Not Null.IsNull(.TPPct) Then
                    txtTPPct.Text = .TPPct.ToString
                End If
                If Not Null.IsNull(.TPAmt) Then
                    txtTPAmt.Text = .TPAmt.ToString
                End If

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                'Audit Control
                ctlAudit.CreatedByUser = .UpdatedByUser
                ctlAudit.CreatedDate = .UpdatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleID
            End With 'objBroker

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
                        Dim objBroker As BrokerInfo = (New BrokersController).GetBroker(itemId)

                        If Not objBroker Is Nothing Then
                            ItemToPage(objBroker)

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
                                .CreatedByUser = objBroker.UpdatedByUser
                                .CreatedDate = objBroker.UpdatedDate.ToString
                            End With 'ctlAudit

                            'Tracking Control
                            With ctlTracking
                                ' .URL = objBroker.NavURL
                                .ModuleID = objBroker.ModuleId
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
                    'With hypImgClose1
                    '    .NavigateUrl = NavigateURL()
                    '    .ToolTip = Localization.GetString("Close")
                    '    .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    'End With  'hypImgClose

                End If


            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class

End Namespace
