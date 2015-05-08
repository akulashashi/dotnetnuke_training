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
        

        Sub SetGridView()
            With gdvLoadPUs
                '.PageSize = objOI.PagerSize
                '.AllowPaging = objOI.PagerSize > 0
                '.Columns(0).Visible = IsEditable 'Remove the First column if the User is not Admin

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

   

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                Dim objLoad As LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheet(itemId)
                'loadId = (New Business.LoadSheetsController).GetLoadId(itemId)
                loadId = objLoad.LoadID
                'DropDate = objLoad.DeliveryDate

                'PickupDate = objLoad.LoadDate
                If Null.IsNull(objLoad.LoadDate) Then PickupDate = Now Else PickupDate = objLoad.LoadDate

                'this needs to execute always to the client script code is registred in InvokePopupCal
                'cmdCalandarPUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPUDate)

                SetGridView()
                'SetrlLoadPUs()

               

                If Not Page.IsPostBack Then
                   
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub gdvLoadPUs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadPUs.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)

                    Dim lblAdditional As Label = CType(e.Row.FindControl("lblAdditional"), Label)
                    Dim lblAdditional2 As Label = CType(e.Row.FindControl("lblAdditional2"), Label)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _PUDate As DateTime = Null.NullDate
                    _PUDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUDate"), _PUDate))

                    Dim _PUName As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUName"), Null.NullString))
                    Dim _PUContact As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUContact"), Null.NullString))
                    Dim _PUTel As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUTel"), Null.NullString))
                    Dim _PUAdd1 As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUAdd1"), Null.NullString))

                    Dim _PRONo As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PRONo"), Null.NullString))
                    Dim _PUTime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "PUTime"), Null.NullDate))
                    Dim _Pieces As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Pieces"), Null.NullString))
                    Dim _Weight As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Weight"), Null.NullString))
                    Dim _Miles As Decimal = Convert.ToDecimal(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Miles"), Null.NullDecimal))

                    '        .PUName = (CType(e.Item.Cells(1).FindControl("txt_PUName"), TextBox)).Text
                    '(CType(gdvLoadPUs.FindControl("txt_PUName"), TextBox)).Text
                    'Try
                    '    Dim cmdCalandar_PUDate As HyperLink = (CType(e.Row.FindControl("cmdCalandar_PUDate"), HyperLink))
                    '    Dim txt_PUDate As TextBox = (CType(e.Row.FindControl("txt_PUDate"), TextBox))
                    '    cmdCalandar_PUDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txt_PUDate)

                    'Catch
                    'End Try



                    If Not Null.IsNull(_PUDate) Then
                        'Dim lblPUDate As Label = CType(e.Row.FindControl("lblPUDate"), Label)
                        'lblPUDate.Text = _PUDate.ToShortDateString
                        Dim PUDate As Date = _PUDate
                        If PUDate.ToShortDateString <> "11/11/2222" Then 'If PUDate > #1/1/1950# Then
                            lblPUDate.Text = _PUDate.ToShortDateString
                        End If
                    End If
                    'Populate Addtional Details for lblAdditional2
                    If Not String.IsNullOrEmpty(_PRONo) Then
                        lblAdditional2.Text &= "<b>PRONo</b>:" & _PRONo
                    End If
                    If Not _PUTime = Null.NullDate Then
                        lblAdditional2.Text &= "<br/><b>Time</b>:" & _PUTime.ToShortTimeString
                    End If
                    If Not String.IsNullOrEmpty(_Pieces) Then
                        lblAdditional2.Text &= "<br/><b>Pieces</b>:" & _Pieces
                    End If
                    If Not String.IsNullOrEmpty(_Weight) Then
                        lblAdditional2.Text &= "<br/><b>Weight</b>:" & _Weight
                    End If
                    If (Not _Miles = Null.NullDecimal) AndAlso (_Miles > 0) Then
                        lblAdditional2.Text &= "<br/><b>Miles</b>:" & _Miles.ToString
                    End If
                    'If String.IsNullOrEmpty(lblAdditional2.Text) Then
                    '    Dim secMoreInfo2 As DotNetNuke.UI.UserControls.SectionHeadControl = CType(e.Row.FindControl("secMoreInfo2"), DotNetNuke.UI.UserControls.SectionHeadControl)
                    '    secMoreInfo2.Visible = False
                    'End If

                    'Populate Addtional Details for lblAdditional
                    If Not String.IsNullOrEmpty(_PUName) Then
                        lblAdditional.Text = "<b>" & _PUName & "</b>"
                    End If
                    If Not String.IsNullOrEmpty(_PUContact) Then
                        lblAdditional.Text &= "<br/><u>" & _PUContact & "</u>"
                    End If
                    If Not String.IsNullOrEmpty(_PUTel) Then
                        lblAdditional.Text &= "<br/><nobr><b>T</b>:" & Phone.FormatPhoneNo(_PUTel) & "</nobr>"
                    End If
                    If Not String.IsNullOrEmpty(_PUAdd1) Then
                        lblAdditional.Text &= "<br/>" & _PUAdd1
                    End If
                    If String.IsNullOrEmpty(lblAdditional.Text) AndAlso String.IsNullOrEmpty(lblAdditional2.Text) Then
                        Dim secMoreInfo1 As DotNetNuke.UI.UserControls.SectionHeadControl = CType(e.Row.FindControl("secMoreInfo1"), DotNetNuke.UI.UserControls.SectionHeadControl)
                        secMoreInfo1.Visible = False
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

        Private Sub odsLoadPUs_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadPUs.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

#End Region

    End Class 'ViewAlts

End Namespace 'bhattji.Modules.LoadSheets