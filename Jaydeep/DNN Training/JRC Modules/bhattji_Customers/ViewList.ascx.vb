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
Imports bhattji.Modules.Customers.Business

Namespace bhattji.Modules.Customers

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

        Sub BindStateCodes()
            With ddlStateCode
                .DataValueField = "StateCode"
                .DataTextField = "State"
                .DataSource = (New CustomersController).GetStateCodes
                .DataBind()

                .Items.Insert(0, New ListItem("<All States>", ""))
            End With 'ddlStateCode
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
            ViewState.Remove("odsCustomers")
            ViewState.Remove("gdvViewList")
            odsCustomers.DataBind()
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
                    'BindCategories()
                    'BindSearchData()
                    BindStateCodes()
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub odsCustomers_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsCustomers.Selecting
            e.InputParameters("SearchText") = txtSearch.Text

            If (Not ddlStateCode.SelectedValue Is Nothing) AndAlso (ddlStateCode.SelectedValue <> "") Then
                e.InputParameters("StateCode") = ddlStateCode.SelectedValue()
            Else
                e.InputParameters("StateCode") = ""
            End If

            e.InputParameters("SearchOn") = rblSearchOn.SelectedValue
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
                    Dim lblPhoneNumber As Label = CType(e.Row.FindControl("lblPhoneNumber"), Label)

                    Dim _ItemId As Integer = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _PhoneNumber As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PhoneNumber"), Null.NullString))

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

                                .NavigateUrl = EditUrl("ItemID", _ItemId, "ItemDetails", "Item=Customer")
                                .ToolTip = "View Details"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With 'hypThumb
                    End If

                    If Not lblPhoneNumber Is Nothing Then
                        With lblPhoneNumber
                            .Text = Phone.FormatPhoneNo(_PhoneNumber)
                            .ToolTip = .Text
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblPhoneNumber
                    End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub ddlStateCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStateCode.SelectedIndexChanged
            btnSearch_Click(sender, e)
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
        End Sub


#End Region

    End Class 'ViewList

End Namespace 'bhattji.Modules.Customers
