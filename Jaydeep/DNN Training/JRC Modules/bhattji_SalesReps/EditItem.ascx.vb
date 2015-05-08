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
Imports bhattji.Modules.SalesReps.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#End Region

Namespace bhattji.Modules.SalesReps

    Public MustInherit Class EditItem
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo

#End Region

#Region " Public Methods "
        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objSalesRep As SalesRepInfo = (New SalesRepsController).GetSalesRep(ItemId)
                'Check for the Not-Null objSalesRep
                If Not objSalesRep Is Nothing Then ItemToPage(objSalesRep)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objSalesRep As SalesRepInfo)
            'Load objSalesRep data to the Page
            With objSalesRep

                txtRepNo.Text = .RepNo
                txtRepNo.ReadOnly = True
                txtRepNo.CssClass = "NormalBold"
                txtRepNo.Style.Add(HtmlTextWriterStyle.BorderWidth, "0")
                txtRepName.Text = .RepName

                If (Not Null.IsNull(.RepRate)) AndAlso (.RepRate > 0) Then
                    txtRepRate.Text = .RepRate.ToString
                End If
                If (Not Null.IsNull(.RepDollar)) AndAlso (.RepDollar > 0) Then
                    txtRepDollar.Text = .RepDollar.ToString
                End If

                If Not Null.IsNull(.SecPinA) Then
                    txtSecPinA.Text = .SecPinA.ToString
                End If
                If Not Null.IsNull(.SecPinB) Then
                    txtSecPinB.Text = .SecPinB.ToString
                End If

                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

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
                        .NavigateUrl = hypPrint.NavigateUrl
                        .Target = "_blank"
                        .ToolTip = Localization.GetString("Print", LocalResourceFile)
                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    End If
                End With  'hypImgPrint

                'Audit Control
                ctlAudit.CreatedByUser = .UpdatedByUser
                ctlAudit.CreatedDate = .UpdatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId
            End With 'objSalesRep

        End Sub

        Private Function PageToItem() As SalesRepInfo
            Dim objSalesRep As New SalesRepInfo
            'Initialise the ojbSalesRep object
            objSalesRep = CType(CBO.InitializeObject(objSalesRep, GetType(Business.SalesRepInfo)), SalesRepInfo)

            'bind text values to object
            With objSalesRep
                .ItemId = itemId
                .ModuleId = ModuleId

                .RepNo = txtRepNo.Text
                .RepName = txtRepName.Text

                If txtRepRate.Text <> String.Empty Then
                    Try
                        .RepRate = Decimal.Parse(txtRepRate.Text)
                    Catch
                        .RepRate = 0
                    End Try
                Else
                    .RepRate = 0
                End If

                If txtRepDollar.Text <> String.Empty Then
                    Try
                        .RepDollar = Decimal.Parse(txtRepDollar.Text)
                    Catch
                        .RepDollar = 0
                    End Try
                Else
                    .RepDollar = 0
                End If


                If txtSecPinA.Text <> String.Empty Then
                    Try
                        .SecPinA = Integer.Parse(txtSecPinA.Text)
                    Catch
                    End Try
                End If
                If txtSecPinB.Text <> String.Empty Then
                    Try
                        .SecPinB = Integer.Parse(txtSecPinB.Text)
                    Catch
                    End Try
                End If

                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .UpdatedByUserId = UserInfo.UserID
                .CreatedByUserId = .UpdatedByUserId

            End With 'objSalesRep
            Return objSalesRep
        End Function

        Private Sub InitControls()
            'cmdDelete.Visible = Not Null.IsNull(itemId)
            'imbDelete.Visible = cmdDelete.Visible
            'cmdUpdate.Visible = cmdDelete.Visible
            'imbUpdate.Visible = cmdUpdate.Visible
            'cmdAdd.Visible = Not cmdUpdate.Visible
            'imbAdd.Visible = cmdAdd.Visible

            'cvRepNo.Visible = cmdAdd.Visible

        End Sub

        Private Sub SetIconBar()
            'Give the ImageUrl
            imbAdd.ImageUrl = ModulePath & "img/bhattji_Add.jpg"
            imbUpdate.ImageUrl = ModulePath & "img/bhattji_Update.jpg"
            imbDelete.ImageUrl = ModulePath & "img/bhattji_Delete.jpg"
            imbCancel.ImageUrl = ModulePath & "img/bhattji_Cancel.jpg"
            hypImgPrint.ImageUrl = ModulePath & "img/bhattji_Print.jpg"

            'Give the Tooltip
            cmdAdd.ToolTip = Localization.GetString("Add") 'cmdAdd.Text
            cmdUpdate.ToolTip = Localization.GetString("cmdUpdate") 'cmdUpdate.Text
            cmdDelete.ToolTip = Localization.GetString("cmdDelete") 'cmdDelete.Text
            cmdCancel.ToolTip = Localization.GetString("cmdCancel") 'cmdCancel.Text
            hypPrint.ToolTip = hypPrint.Text

            'Make the ControlButtons Visible
            tdDelete.Visible = Not Null.IsNull(itemId)
            tdUpdate.Visible = Not Null.IsNull(itemId) 'tdDelete.Visible '
            tdPrint.Visible = Not Null.IsNull(itemId) 'tdDelete.Visible
            tdAdd.Visible = Not tdUpdate.Visible

            cvRepNo.Visible = cmdAdd.Visible

            If tdDelete.Visible Then tdDelete.Visible = Users.UserController.GetCurrentUserInfo.IsInRole("Administrators")
            If tdDelete.Visible Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If
        End Sub 'SetIconBar()

     
#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                If objOI.OnlyHostCanEdit AndAlso (Not Users.UserController.GetCurrentUserInfo.IsSuperUser) Then
                    Response.Redirect(NavigateURL(), True)
                End If


                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    itemId = Null.NullInteger()
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))
                    cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                    imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                End If

                'Initilise the Controls and set its properties as well as Visiblity
                InitControls()

                If Not Page.IsPostBack Then
                    SetIconBar()
                    'Bind the Categories
                    'BindCategories()

                    If Not Null.IsNull(itemId) Then
                        Dim objSalesRep As SalesRepInfo = (New SalesRepsController).GetSalesRep(itemId)

                        If Not objSalesRep Is Nothing Then
                            'Load data
                            ItemToPage(objSalesRep)

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If

                    End If
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub txtRepRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepRate.TextChanged, txtRepDollar.TextChanged
            If (txtRepRate.Text <> "") AndAlso (txtRepDollar.Text <> "") Then
                txtRepRate.Enabled = True
                txtRepDollar.Enabled = True
                'Controls.Add(objOI.Popup("Failure", "Enter either RepRate or RepDollar only"))
                lblMsg.Text = "<font color='red'>Failure<br/>Enter either RepRate or RepDollar only</font>"
            ElseIf (txtRepRate.Text = "") AndAlso (txtRepDollar.Text = "") Then
                txtRepRate.Enabled = True
                txtRepDollar.Enabled = True
                'Controls.Add(objOI.Popup("Warning", "You have neither selected RepRate nor RepDollar"))
                lblMsg.Text = "<font color='blue'>Warning<br/>You have neither selected RepRate nor RepDollar</font>"
            ElseIf (txtRepRate.Text <> "") Then
                txtRepDollar.Enabled = False
                'Controls.Add(objOI.Popup("Success", "You have selected SalesRepresentative Rate = " & txtRepRate.Text))
                lblMsg.Text = "<font color='green'>Success<br/>You have selected SalesRepresentative Rate = " & txtRepRate.Text & "</font>"
            ElseIf (txtRepDollar.Text <> "") Then
                txtRepRate.Enabled = False
                'Controls.Add(objOI.Popup("Success", "You have selected SalesRepresentative Dollar = " & txtRepDollar.Text))
                lblMsg.Text = "<font color='green'>Success<br/>You have selected SalesRepresentative Dollar = " & txtRepDollar.Text & "</font>"
            End If
        End Sub

        Private Sub imbAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAdd.Click
            cmdAdd_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
            'If (New Business.SalesRepsController).IsUniqueCode(txtRepNo.Text) Then
            '    cmdUpdate_Click(sender, New EventArgs)
            'Else
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "RepNumber must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "RepNumber must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If

            If (New Business.SalesRepsController).IsUniqueCode(txtRepNo.Text) Then
                cmdUpdate_Click(sender, New EventArgs)
                'Controls.Add(objOI.Popup("Success", "New SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " added successfully", "New SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " added successfully in the Database."))
                lblMsgId.Text = "<font color='green'>Success<br/>New SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " added successfully"
            Else
                'Controls.Add(objOI.Popup("Failure", "SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " already exists", "SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " already exists in the Database. Please choose another SalesRepresentative Code"))
                lblMsgId.Text = "<font color='red'>Failure<br/>SalesRepresentative with SalesRepresentative Code " & txtRepNo.Text & " already exists.<br/> Please choose another SalesRepresentative Code"
                DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Failure", "SalesRepresentativeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "SalesRepresentativeCode must be Unique", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click ', imbAdd.Click
            cmdUpdate_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click ', cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objSalesRep As New SalesRepInfo
                    ''Initialise the ojbSalesRep object
                    'objSalesRep = CType(CBO.InitializeObject(objSalesRep, GetType(Business.SalesRepInfo)), SalesRepInfo)

                    'bind text values to object
                    Dim objSalesRep As SalesRepInfo = PageToItem()


                    Dim objSalesRepsController As New SalesRepsController
                    If Null.IsNull(itemId) Then
                        itemId = objSalesRepsController.AddSalesRep(objSalesRep)
                    Else
                        objSalesRepsController.UpdateSalesRep(objSalesRep)
                    End If

                    ' url tracking
                    Dim objUrls As New UrlController
                    ' url tracking for MediaSrc
                    'With ctlMediaSrc
                    '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
                    'End With 'ctlMediaSrc  


                    'Redirect to the page as selected by the User in DropdownList
                    Select Case ddlUpdateRedirection.SelectedValue.ToUpper
                        Case "NEWITEM"
                            'Redirect back to the Edit Page of the Item for Add
                            Response.Redirect(EditUrl(), True)
                        Case "EDITITEM"
                            'Redirect back to this same Edit Page with same ItemId to Edit & Continue
                            Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                        Case "ITEMDETAILS"
                            'Redirect to the Detail Page of this Item for Viewing the details of this Item
                            Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
                        Case Else '"LISTING"
                            'Redirect back to the portal home page
                            Response.Redirect(NavigateURL(), True)
                    End Select
                End If
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
           cmdCancel_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            'Redirect to the page as selected by the User in DropdownList
            Select Case ddlUpdateRedirection.SelectedValue.ToUpper
                Case "NEWITEM"
                    'Redirect back to the Edit Page of the Item for Add
                    Response.Redirect(EditUrl(), True)
                Case "EDITITEM"
                    If Not Null.IsNull(itemId) Then
                        'Redirect back to this same Edit Page with same ItemId to Edit & Continue
                        Response.Redirect(EditUrl("ItemId", itemId.ToString), True)
                    Else
                        'Redirect back to the Edit Page of the Item for Add
                        Response.Redirect(EditUrl(), True)
                    End If
                Case "ITEMDETAILS"
                    If Not Null.IsNull(itemId) Then
                        'Redirect to the Detail Page of this Item for Viewing the details of this Item
                        Response.Redirect(EditUrl("ItemId", itemId.ToString, "ItemDetails"), True)
                    Else
                        'Redirect back to the portal home page
                        Response.Redirect(NavigateURL(), True)
                    End If
                Case Else '"LISTING"
                    'Redirect back to the portal home page
                    Response.Redirect(NavigateURL(), True)
            End Select
        End Sub

        Private Sub imbDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDelete.Click
            cmdDelete_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Try
                If Not Null.IsNull(itemId) Then
                    Dim objSalesRepsController As New SalesRepsController
                    objSalesRepsController.DeleteSalesRep(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

    End Class 'EditItem

End Namespace 'bhattji.Modules.SalesReps
