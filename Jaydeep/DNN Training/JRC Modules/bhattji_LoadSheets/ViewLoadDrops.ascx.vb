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
    Public MustInherit Class ViewLoadDrops
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

        Sub SetGridView()
            With gdvLoadDrops
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
            End With 'gdvLoadDrops

        End Sub

        Function GetFullMsg(ByVal ShortMsg As String) As String
            Select Case ShortMsg
                Case "1Come1Serve"
                    Return "1st Come 1st Serve"
                Case "CallForApp"
                    Return "Call for Appointment"
                Case "AppMade"
                    Return "Appointment Made"
                Case Else
                    Return ShortMsg
            End Select
        End Function

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

                If Not Page.IsPostBack Then
                    
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub gdvLoadDrops_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvLoadDrops.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim lblDPDate As Label = CType(e.Row.FindControl("lblDPDate"), Label)

                    Dim lblAdditional As Label = CType(e.Row.FindControl("lblAdditional"), Label)
                    Dim lblAdditional2 As Label = CType(e.Row.FindControl("lblAdditional2"), Label)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    Dim _DPDate As DateTime = Null.NullDate
                    _DPDate = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPDate"), _DPDate))

                    Dim _Jobno As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Jobno"), Null.NullString))
                    Dim _BillOLay As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BillOLay"), Null.NullString))
                    Dim _BOLSeq As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BOLSeq"), Null.NullString))
                    Dim _Stime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Stime"), Null.NullDate))
                    Dim _Etime As DateTime = Convert.ToDateTime(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "Etime"), Null.NullDate))


                    Dim _DPName As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPName"), Null.NullString))
                    Dim _DPContact As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPContact"), Null.NullString))
                    Dim _DPPhone As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPPhone"), Null.NullString))
                    Dim _DPAddr As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DPAddr"), Null.NullString))

                    'Try
                    '    Dim cmdCalandar_DPDate As HyperLink = (CType(e.Row.FindControl("cmdCalandar_DPDate"), HyperLink))
                    '    Dim txt_DPDate As TextBox = (CType(e.Row.FindControl("txt_DPDate"), TextBox))
                    '    cmdCalandar_DPDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txt_DPDate)
                    'Catch
                    'End Try


                    If Not Null.IsNull(_DPDate) Then
                        Dim DPDate As Date = _DPDate
                        If DPDate.ToShortDateString <> "11/11/2222" Then 'If DPDate > #1/1/1950# Then
                            lblDPDate.Text = _DPDate.ToShortDateString
                        End If
                    End If
                    'Populate Addtional Details for lblAdditional2
                    If Not String.IsNullOrEmpty(_Jobno) Then
                        lblAdditional2.Text = "<b>JobNo</b>:" & _Jobno
                    End If
                    If Not String.IsNullOrEmpty(_BillOLay) Then
                        'lblAdditional2.Text &= "<br/><nobr><b>Msg</b>:" & _BillOLay & "</nobr>"
                        lblAdditional2.Text &= "<br/><nobr><b>Msg</b>:" & GetFullMsg(_BillOLay) & "</nobr>"
                    End If
                    If Not String.IsNullOrEmpty(_BOLSeq) Then
                        lblAdditional2.Text &= "<br/><b>Notes</b>:" & _BOLSeq
                    End If
                    If Not _Stime = Null.NullDate Then
                        lblAdditional2.Text &= "<br/><b>S Time</b>:" & _Stime.ToShortTimeString
                    End If
                    If Not _Etime = Null.NullDate Then
                        lblAdditional2.Text &= "<br/><b>E Time</b>:" & _Etime.ToShortTimeString
                    End If
                    'If String.IsNullOrEmpty(lblAdditional2.Text) Then 'OrElse (lblAdditional2.Text = "<br/><nobr><b>Msg</b>:1Come1Serve</nobr>") Then
                    '    Dim secMoreInfo2 As DotNetNuke.UI.UserControls.SectionHeadControl = CType(e.Row.FindControl("secMoreInfo2"), DotNetNuke.UI.UserControls.SectionHeadControl)
                    '    secMoreInfo2.Visible = False
                    'End If

                    'Populate Addtional Details for lblAdditional
                    If Not String.IsNullOrEmpty(_DPName) Then
                        lblAdditional.Text = "<b>" & _DPName & "</b>"
                    End If
                    If Not String.IsNullOrEmpty(_DPContact) Then
                        lblAdditional.Text &= "<br/><u>" & _DPContact & "</u>"
                    End If
                    If Not String.IsNullOrEmpty(_DPPhone) Then
                        lblAdditional.Text &= "<br/><nobr><b>T</b>:" & Phone.FormatPhoneNo(_DPPhone) & "</nobr>"
                    End If
                    If Not String.IsNullOrEmpty(_DPAddr) Then
                        lblAdditional.Text &= "<br/>" & _DPAddr
                    End If
                    If String.IsNullOrEmpty(lblAdditional.Text) AndAlso (String.IsNullOrEmpty(lblAdditional2.Text) OrElse (lblAdditional2.Text = "<br/><nobr><b>Msg</b>:1st Come 1st Serve</nobr>")) Then
                        Dim secMoreInfo1 As DotNetNuke.UI.UserControls.SectionHeadControl = CType(e.Row.FindControl("secMoreInfo1"), DotNetNuke.UI.UserControls.SectionHeadControl)
                        'Dim secMoreInfo1 As bhattji.Modules.LoadSheets.SectionHeadControl = CType(e.Row.FindControl("secMoreInfo1"), bhattji.Modules.LoadSheets.SectionHeadControl)
                        secMoreInfo1.Visible = False
                        Dim trMoreInfo1 As HtmlTableRow = CType(e.Row.FindControl("trMoreInfo1"), HtmlTableRow)
                        trMoreInfo1.Visible = False
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

        Private Sub odsLoadDrops_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadDrops.Selecting
            e.InputParameters("LoadID") = loadId.ToString
        End Sub

#End Region

    End Class 'ViewLoadDrops

End Namespace 'bhattji.Modules.LoadSheets