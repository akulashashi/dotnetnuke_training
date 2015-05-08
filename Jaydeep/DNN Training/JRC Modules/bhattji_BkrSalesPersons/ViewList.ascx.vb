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
Imports bhattji.Modules.BkrSalesPersons.Business

Namespace bhattji.Modules.BkrSalesPersons

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

        Private Sub BindUserIOs1()

            With ddlJRCIOfficeCode

                Dim valfld, txtfld As String
                Dim dr As IDataReader = (New SalesPersonsController).GetAllInterOffices

                .Items.Clear()
                .Items.Add(New ListItem("<All Offices>", "000000000"))
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While

            End With 'ddlJRCIOfficeCode

        End Sub

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

                Dim valfld, txtfld As String
                Dim dr As IDataReader '= (New Business.SalesPersonsController).GetAllInterOffices
                If (LoginName = "") OrElse Users.UserController.GetCurrentUserInfo.IsSuperUser Then
                    dr = (New Business.SalesPersonsController).GetAllInterOffices
                Else
                    dr = (New Business.SalesPersonsController).GetUserIOs(LoginName)
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

                Try
                    If (LoginName = "") OrElse Users.UserController.GetCurrentUserInfo.IsSuperUser Then
                        .Items.Insert(0, New ListItem("<All Offices>", "000000000"))
                    Else
                        .Items.FindByValue((New Business.SalesPersonsController).GetUserDefaultIO(LoginName)).Selected = True
                    End If
                Catch
                End Try
            End With
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
            ViewState.Remove("odsSalesPersons")
            ViewState.Remove("gdvViewList")
            odsSalesPersons.DataBind()
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
                'hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                'hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)

                If Not Page.IsPostBack Then
                    BindUserIOs()
                    'BindCategories()
                    'BindSearchData()
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub odsSalesPersons_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSalesPersons.Selecting
            If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") Then
                e.InputParameters("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue()
            Else
                e.InputParameters("JRCIOfficeCode") = ""
            End If

            If (Not ddlBrokerCode.SelectedValue Is Nothing) AndAlso (ddlBrokerCode.SelectedValue <> "") Then
                e.InputParameters("BrokerCode") = ddlBrokerCode.SelectedValue()
            Else
                e.InputParameters("BrokerCode") = ""
            End If

            e.InputParameters("SearchText") = txtSearch.Text
            e.InputParameters("SearchOn") = rblSearchOn.SelectedValue
            e.InputParameters("Status") = rblStatus.SelectedValue
            e.InputParameters("FromDate") = txtFrom.Text
            e.InputParameters("ToDate") = txtTo.Text

            e.InputParameters("StartsWith") = (rblSearchType.SelectedIndex < 1).ToString
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
                End If
            Catch exc As Exception    'Module failed to RowCreated
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub gdvViewList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim hypEditItem As HyperLink = CType(e.Row.FindControl("hypEditItem"), HyperLink)
                    Dim hypThumb As HyperLink = CType(e.Row.FindControl("hypThumb"), HyperLink)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    Dim lblPhoneNo As Label = CType(e.Row.FindControl("lblPhoneNo"), Label)
                    Dim lblCellPhone As Label = CType(e.Row.FindControl("lblCellPhone"), Label)

                    Dim _ItemId As Integer = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _PhoneNo As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PhoneNo"), Null.NullString)) 'CType(DataBinder.Eval(e.Row.DataItem, "PhoneNo"), String) '
                    Dim _CellPhone As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "CellPhone"), Null.NullString)) 'CType(DataBinder.Eval(e.Row.DataItem, "CellPhone"), String) '

                    If Not hypEditItem Is Nothing Then
                        With hypEditItem
                            .Visible = IsEditable
                            If .Visible Then
                                .NavigateUrl = EditUrl("ItemID", _ItemId)
                                .ToolTip = Localization.GetString("Edit")
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditItem
                    End If

                    If Not imbDelete Is Nothing Then
                        With imbDelete
                            .Visible = IsEditable And objOI.DeleteFromGrid
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                            End If
                        End With  'imbDelete
                    End If

                    If Not hypThumb Is Nothing Then
                        With hypThumb
                            .Visible = True 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
                            If .Visible Then

                                .NavigateUrl = EditUrl("ItemID", _ItemId, "ItemDetails", "Item=SalesPerson")
                                .ToolTip = "View Details"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With 'hypThumb
                    End If

                    If Not lblPhoneNo Is Nothing Then
                        With lblPhoneNo
                            .Visible = True 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
                            If .Visible Then
                                .Text = Phone.FormatPhoneNo(_PhoneNo)
                                .ToolTip = .Text
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With 'hypThumb
                    End If

                    If Not lblCellPhone Is Nothing Then
                        With lblCellPhone
                            .Visible = True 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
                            If .Visible Then
                                .Text = Phone.FormatPhoneNo(_CellPhone)
                                .ToolTip = .Text
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With 'hypThumb
                    End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub rblStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblStatus.SelectedIndexChanged
            btnSearch_Click(sender, New System.EventArgs)
        End Sub

        Private Sub btnBrokerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBrokerSearch.Click
            With ddlBrokerCode

                .DataValueField = "BrokerCode"
                .DataTextField = "BrokerName"
                .DataSource = (New Business.SalesPersonsController).GetBrokerSearch2(txtBrokerCode.Text)
                .DataBind()

                .Items.Insert(0, New ListItem("<All Brokers>", ""))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
                ddlBrokerCode_SelectedIndexChanged(sender, New System.EventArgs)
            End With 'ddlBrokerCode

        End Sub

        Private Sub ddlBrokerCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrokerCode.SelectedIndexChanged
            txtBrokerCode.Text = ddlBrokerCode.SelectedValue
            btnSearch_Click(sender, New System.EventArgs)
        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged
            btnSearch_Click(sender, New System.EventArgs)
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
        End Sub


#End Region

    End Class 'ViewList

End Namespace 'bhattji.Modules.BkrSalesPersons
