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

Imports System.IO
Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports bhattji.Modules.LoadSheets.Business
Imports bhattji.Modules.Brokers.Business
Imports bhattji.Modules.InterOffices.Business
Imports DotNetNuke.Entities.Users

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

    Partial Public Class Xmission
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private objOI As OptionsInfo

#End Region

#Region " Methods "


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
                Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (LoginName = "") Then
                    dr = (New Business.LoadSheetsController).GetAllInterOffices
                Else
                    dr = (New Business.LoadSheetsController).GetUserIOs(LoginName)
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

                Dim objLC As New Business.LoadSheetsController
                If (Session.Item("JRCIOfficeCode") Is Nothing) OrElse (Session.Item("JRCIOfficeCode").ToString = "") OrElse (Session.Item("JRCIOfficeCode").ToString = "000000000") Then
                    Session.Item("JRCIOfficeCode") = objLC.GetUserDefaultIO(LoginName)
                End If

                Try
                    .Items.FindByValue(Session.Item("JRCIOfficeCode").ToString.Substring(0, 9)).Selected = True
                Catch
                End Try


                'Try
                '    .Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
                'Catch
                'End Try

            End With
        End Sub

        Private Sub BindUnXmit()

            With ddlXmissionFile
                .Items.Clear()
                .DataTextField = "XmissionFile"
                .DataValueField = "XmissionFile"
                '.DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems)
                .DataSource = (New Business.LoadSheetsController).GetForUnXmit(ddlJRCIOfficeCode.SelectedValue, objOI.NoOfItems, txtFrom.Text, txtTo.Text)
                .DataBind()
                .Items.Insert(0, New ListItem("<Xmission: Xmit WIP Loads>", ""))
            End With 'ddlXmissionFile

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
            ViewState.Remove("odsLoadSheets")
            ViewState.Remove("gdvViewList")
            odsLoadSheets.DataBind()
            gdvViewList.DataBind()
        End Sub

        Private Sub SelectAll(ByVal SelectAll As Boolean)
            Dim c As CheckBox
            For Each r As GridViewRow In gdvViewList.Rows
                c = CType(r.FindControl("chkXMissionSave"), CheckBox)
                If (Not c Is Nothing) Then
                    c.Checked = SelectAll AndAlso c.Enabled
                End If
            Next
        End Sub

        Private Sub UpdateXMission()
            Dim sb As New StringBuilder
            Dim c As CheckBox
            'Dim txtCustPO As TextBox
            'Dim txtBkrInvNo As TextBox
            Dim strCustPO As String = ""
            Dim strBkrInvNo As String = ""

            Dim objLC As New LoadSheetsController
            Dim strLoadId As String
            'Dim objLoad As LoadSheetInfo

            For Each r As GridViewRow In gdvViewList.Rows
                strLoadId = CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text

                c = CType(r.FindControl("chkXMissionSave"), CheckBox)
                If (Not c Is Nothing) Then
                    objLC.UpdateXMissionSave(strLoadId, c.Checked)
                    If c.Checked Then
                        sb.Append("<font color='green' size='+1'>Selected LoadId " & strLoadId & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
                    Else
                        sb.Append("<font color='red' class='NormalRed'>NOT Selected LoadId " & strLoadId & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
                    End If
                End If

                If chkCodOnly.Checked Then
                    objLC.UpdateCodCheckSeq(strLoadId, CType(gdvViewList.Rows(r.RowIndex).FindControl("txtCodCheckSeq"), TextBox).Text)
                    sb.Append("<font color='navy' class='SubHead'>Updated COD Check Sel for LoadId " & strLoadId & " at " & r.RowIndex.ToString() & "</font><br />")
                End If

                Try
                    strCustPO = CType(r.FindControl("txtCustPO"), TextBox).Text
                Catch
                    strCustPO = ""
                End Try
                Try
                    strBkrInvNo = CType(r.FindControl("txtBkrInvNo"), TextBox).Text
                Catch
                    strBkrInvNo = ""
                End Try

                objLC.UpdateBkrInvNoCustPO(strLoadId, strBkrInvNo, strCustPO)
                sb.Append("<font color='blue' class='SubHead'>Updated BkrInvNo & CustPO for LoadId " & strLoadId & " at " & r.RowIndex.ToString() & "</font><br />")

            Next
            'Controls.Add(objOI.Popup("Xmission", "Xmission Processed For Save<br/>Click here for details", sb.ToString()))
            sb.Append("Xmission Processed For Save")
            'Dim InterOfficeOOCode As String = "OO"
            'If ddlJRCIOfficeCode.SelectedValue <> "" Then InterOfficeOOCode = objLC.GetInterOfficeOOCode(ddlJRCIOfficeCode.SelectedValue)
            'Dim XmissionFileName As String = InterOfficeOOCode & String.Format("{0:00}", Now.Month) & String.Format("{0:00}", Now.Day) & String.Format("{0:00}", Now.Year Mod 100)

            'sb.Append("<br/>" & XmissionFileName)

            hypXmission.Text = sb.ToString()
            hypXmission.NavigateUrl = "" 'Remove NavigateUrl

            'Reset the Grid Forview
            btnSearch_Click(Nothing, Nothing)

            btnSave.Enabled = True
        End Sub
        Private Function CodCheckOK() As Boolean
            CodCheckOK = True
            If chkCodOnly.Checked Then
                Dim c As CheckBox
                Dim t As TextBox

                For Each r As GridViewRow In gdvViewList.Rows
                    c = CType(r.FindControl("chkXMissionSave"), CheckBox)
                    t = CType(r.FindControl("txtCodCheckSeq"), TextBox)
                    If (Not c Is Nothing) AndAlso c.Checked Then
                        If (Not t Is Nothing) AndAlso (t.Text = "") Then
                            CodCheckOK = False
                            Exit For
                        End If
                    End If
                Next
            End If
        End Function
        Private Function NoOfXmits() As Integer
            NoOfXmits = 0
            Dim c As CheckBox

            For Each r As GridViewRow In gdvViewList.Rows
                c = CType(r.FindControl("chkXMissionSave"), CheckBox)
                If (Not c Is Nothing) AndAlso c.Checked Then NoOfXmits += 1
            Next
        End Function

        Private Function GetHDR(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo, ByRef objBroker As BrokerInfo, ByRef LoadDPs As ArrayList) As String
            Dim sbHDR As New StringBuilder
            'Dim ProNox As String = objLoadSheet.DriverCode
            'If objLoadSheet.LoadType.ToUpper = "BK" Then
            '    ProNox = objBroker.VendorRef
            'End If

            'Dim HDR As String = """HDR"",""" & objLoadSheet.LoadID & """,""" & String.Format("{0:MM/dd/yy}", Now) & """,""S"",""00"",""" & objLoadSheet.CustomerNumber & """,""" & ProNox & """,""" & String.Format("{0:MM/dd/yy}", objLoadSheet.DeliveryDate) & """,""" & objLoadSheet.CustPO & " "",""A"",""" & String.Format("{0:MM/dd/yy}", objLoadSheet.LoadDate) & """," & String.Format("{0:0}", objLoadSheetAcct.BCustBill) & ",""" & ProNox & " "",""" & objLoadSheet.ProJob & ""","""
            sbHDR.Append("""HDR""")
            sbHDR.Append(",""" & objLoadSheet.LoadID & """")
            sbHDR.Append(",""" & String.Format("{0:MM/dd/yy}", Now) & """")
            sbHDR.Append(",""S"",""00""")
            sbHDR.Append(",""" & objLoadSheet.CustomerNumber & """")
            sbHDR.Append(",""" & objLoadSheet.ProNox & """")
            sbHDR.Append(",""" & String.Format("{0:MM/dd/yy}", objLoadSheet.DeliveryDate) & """")
            sbHDR.Append(",""" & objLoadSheet.CustPO & " """)
            sbHDR.Append(",""A""")
            sbHDR.Append(",""" & String.Format("{0:MM/dd/yy}", objLoadSheet.LoadDate) & """")
            sbHDR.Append("," & String.Format("{0:0.00}", objLoadAcct.BCustBill))
            sbHDR.Append(",""" & objLoadSheet.ProNox & " """)
            sbHDR.Append(",""" & objLoadSheet.ProJob.Replace("""", "") & " """)
            sbHDR.Append(",""" & objLoadAcct.IOOffL1.ToUpper)

            'Dim LoadDPs As ArrayList = (New LoadDropsController).GetLoadDropByLoadId(LoadId)
            If (objLoadSheet.LoadType.ToUpper = "BK") AndAlso (objBroker.BkrType = "30") Then
                'HDR &= "" & objLoadSheetAcct.JRCIOOffC1.ToUpper & " "",""" & objLoadSheet.BkrInvNo.ToUpper & "&-"""
                'sbHDR.Append(",""" & objLoadAcct.JRCIOOffC1.ToUpper & " """)
                sbHDR.Append(" " & objLoadSheet.BkrInvNo.ToUpper & "-")
                'sbHDR.Append("-")
            Else
                'HDR &= objLoadSheetAcct.JRCIOOffC1.ToUpper
                'sbHDR.Append(objLoadAcct.JRCIOOffC1.ToUpper)
                'sbHDR.Append(" ")
            End If
            If LoadDPs.Count > 0 Then
                sbHDR.Append(" " & LoadDPs(0).DPCity.ToUpper & ", " & LoadDPs(0).DPState.ToUpper & " """)
            Else
                sbHDR.Append(" ,  """)
            End If

            For I As Integer = 1 To 3
                'Each LoadDP As LoadDropInfo In LoadDPs
                If I < LoadDPs.Count Then
                    'HDR &= ""","" " & LoadDPs(I).DPCity.ToUpper & "," & LoadDPs(I).DPState.ToUpper & " """
                    sbHDR.Append(","" " & LoadDPs(I).DPCity.ToUpper & ", " & LoadDPs(I).DPState.ToUpper & " """)
                Else
                    'HDR &= ","" """
                    sbHDR.Append(","" """)
                End If
            Next

            Return sbHDR.ToString
        End Function
        Private Function GetFirstLoadPU(ByRef objLoadPU As LoadPUInfo) As String
            Dim sbFirstLoadPU As New StringBuilder
            'sb.Append("""DT4"",""" & LoadPU.LoadID & """,4,""01"",""** PICK-UP " & LoadPU.PUCity.ToUpper & "," & LoadPU.PUState.ToUpper & ", """ & vbCrLf)
            sbFirstLoadPU.Append("""DT4""")
            sbFirstLoadPU.Append(",""" & objLoadPU.LoadID & """")
            sbFirstLoadPU.Append(",4,")
            sbFirstLoadPU.Append("""01"",")
            sbFirstLoadPU.Append("""** PICK-UP   ")
            sbFirstLoadPU.Append(objLoadPU.PUCity.ToUpper)
            sbFirstLoadPU.Append("," & objLoadPU.PUState.ToUpper & ", """)
            Return sbFirstLoadPU.ToString
        End Function
        'Private Function GetLoadDP(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo) As String
        '    Dim sbFirstLoadDP As New StringBuilder
        '    'sb.Append("""DT5"",""" & LoadId & """,5,""" & objLoadSheet.JRCIOfficeCode.Substring(0, 7) & """,0,0,0,""" & objLoadSheetAcct.JRCOffComm & """" & vbCrLf)
        '    sbFirstLoadDP.Append("""DT5""")
        '    sbFirstLoadDP.Append(",""" & objLoadSheet.LoadID & """")
        '    sbFirstLoadDP.Append(",5,")
        '    sbFirstLoadDP.Append("""" & objLoadSheet.JRCIOfficeCode.Substring(0, 7) & """")
        '    sbFirstLoadDP.Append(",0,0,0,")
        '    sbFirstLoadDP.Append("""" & objLoadAcct.JRCOffComm & """")
        '    Return sbFirstLoadDP.ToString
        'End Function
        Private Function GetIOComm(ByVal LoadID As String, ByVal IOOffC As String, ByVal IOComm As Double) As String
            Dim sbIOComm As New StringBuilder
            'sb.Append("""DT5"",""" & LoadId & """,5,""" & objLoadSheet.JRCIOfficeCode.Substring(0, 7) & """,0,0,0,""" & objLoadSheetAcct.IOComm1 & """" & vbCrLf)
            sbIOComm.Append("""DT5""")
            sbIOComm.Append(",""" & LoadID & """")
            sbIOComm.Append(",5,")
            If IOOffC.Length > 7 Then
                sbIOComm.Append("""" & IOOffC.Substring(0, 7) & """")
            Else
                sbIOComm.Append("""" & IOOffC & """")
            End If
            sbIOComm.Append(",0,0,0,")
            sbIOComm.Append("""" & String.Format("{0:0.00}", IOComm) & """")
            Return sbIOComm.ToString
        End Function
        Private Function GetDriverComm(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo, ByVal LoadAcct As String) As String
            Dim sbDriverComm As New StringBuilder
            'sb.Append("""DT5"",""" & LoadId & """,5,""" & objIOOffice.LoadAcct & " "",1,""" & objLoadSheetAcct.BBaseLoad & """,""" & objLoadSheetAcct.BBaseLoad & """,""" & objLoadSheetAcct.DRTotDue & """" & vbCrLf)
            sbDriverComm.Append("""DT5""")
            sbDriverComm.Append(",""" & objLoadSheet.LoadID & """")
            sbDriverComm.Append(",5,")

            sbDriverComm.Append("""" & LoadAcct & " """)
            sbDriverComm.Append(",1")
            sbDriverComm.Append(",""" & objLoadAcct.BBaseLoad & """")
            sbDriverComm.Append(",""" & objLoadAcct.BBaseLoad & """")
            sbDriverComm.Append(",""" & String.Format("{0:0.00}", objLoadAcct.DRTotDue) & """")
            Return sbDriverComm.ToString
        End Function
        Private Function GetInvoiceItem(ByRef objLoadSheet As LoadSheetInfo, ByVal AcctHead As String, ByVal Amount As Double) As String
            Dim sbInvoiceItem As New StringBuilder
            'sb.Append("""DT5"",""" & LoadId & """,5,""" & objIOOffice.DetenAcctB & " "",1," & objLoadSheetAcct.BDeten & "," & objLoadSheetAcct.BDeten & ",0" & vbCrLf)
            sbInvoiceItem.Append("""DT5""")
            sbInvoiceItem.Append(",""" & objLoadSheet.LoadID & """")
            sbInvoiceItem.Append(",5")
            sbInvoiceItem.Append(",""" & AcctHead & " """)
            sbInvoiceItem.Append(",1")
            sbInvoiceItem.Append(",""" & String.Format("{0:0.00}", Amount.ToString) & """")
            sbInvoiceItem.Append(",""" & String.Format("{0:0.00}", Amount.ToString) & """")
            sbInvoiceItem.Append(",0")
            Return sbInvoiceItem.ToString
        End Function
        Private Function GetDiscount(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo, ByRef objIOOffice As InterOfficeInfo) As String
            Dim sbBeginDiscount As New StringBuilder
            sbBeginDiscount.Append("""DT5""")
            sbBeginDiscount.Append(",""" & objLoadSheet.LoadID & """")
            sbBeginDiscount.Append(",5")
            sbBeginDiscount.Append(",""" & objIOOffice.DiscAcct & " "",1")
            sbBeginDiscount.Append(",""-" & String.Format("{0:0.00}", objLoadAcct.DiscountDlr) & """")
            sbBeginDiscount.Append(",""-" & String.Format("{0:0.00}", objLoadAcct.DiscountDlr) & """,0")
            Return sbBeginDiscount.ToString
        End Function
        Private Function GetRepDollar(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo) As String
            Dim sbRepDollar As New StringBuilder
            sbRepDollar.Append("""DT5""")
            sbRepDollar.Append(",""" & objLoadSheet.LoadID & """")
            sbRepDollar.Append(",5")
            sbRepDollar.Append(",""" & objLoadAcct.RepNo & " """) 'The space was moved before Quotation Mark from after Quoatation mart on 06/04/2009
            sbRepDollar.Append(",0,0,0")
            sbRepDollar.Append(",""" & String.Format("{0:0.00}", objLoadAcct.RepDlr) & """")
            Return sbRepDollar.ToString
        End Function
        Private Function GetJrcAdmin(ByRef objLoadSheet As LoadSheetInfo, ByRef objLoadAcct As LoadAcctInfo) As String
            Dim sbJrcAdmin As New StringBuilder
            sbJrcAdmin.Append("""DT5""")
            sbJrcAdmin.Append(",""" & objLoadSheet.LoadID & """")
            sbJrcAdmin.Append(",5,""999"",0,0,0")
            If Not Null.IsNull(objLoadAcct.JRCOnePct) Then
                sbJrcAdmin.Append("," & objLoadAcct.JRCOnePct & "")
            Else
                sbJrcAdmin.Append(",0")
            End If
            Return sbJrcAdmin.ToString
        End Function
        Private Function GetInvoiceComment(ByRef objLoadSheet As LoadSheetInfo, ByVal InvComment1 As String, ByVal InvComment2 As String) As String
            Dim sbInvoiceComment As New StringBuilder
            sbInvoiceComment.Append("""DT4""")
            sbInvoiceComment.Append(",""" & objLoadSheet.LoadID & """")
            sbInvoiceComment.Append(",4")
            sbInvoiceComment.Append(",""01""") 'Added as per Eric on 23rd May 2010
            sbInvoiceComment.Append(",""" & InvComment1.Replace("""", "") & " """)
            sbInvoiceComment.Append(",""" & InvComment2.Replace("""", "") & " """)
            Return sbInvoiceComment.ToString
        End Function
        Private Function GetXmissionSeq(ByRef objIOOffice As InterOfficeInfo) As Integer
            Dim XmissionSeq As Integer = 1 'objIOOffice.Xfer
            If objIOOffice.LastXferDate.ToShortDateString <> Now.ToShortDateString Then
                objIOOffice.LastXferDate = Now
                objIOOffice.Xfer = 0
            End If
            XmissionSeq = CInt(objIOOffice.Xfer) + 1
            objIOOffice.Xfer = XmissionSeq
            Return XmissionSeq
        End Function


        Private Sub Xmit()

            Dim objLC As New LoadSheetsController
            Dim objAcct As New LoadAcctsController
            Dim objBkr As New BrokersController
            Dim objIO As New InterOfficesController

            Dim InterOfficeOOCode As String = "OO"
            Dim objIOOffice As InterOfficeInfo = objIO.GetInterOffice(objIO.GetInterOfficeId(ddlJRCIOfficeCode.SelectedValue))
            If ddlJRCIOfficeCode.SelectedValue <> "" Then InterOfficeOOCode = objLC.GetInterOfficeOOCode(ddlJRCIOfficeCode.SelectedValue)
            '****************************************
            Dim XmissionDate As Date = Convert.ToDateTime(Now.ToShortDateString) 'objIOOffice.LastXferDate
            'Dim XmissionSeq As Integer = GetXmissionSeq(objIOOffice)
            'Dim XmissionSeq As Integer = 1 objIOOffice.Xfer
            If objIOOffice.LastXferDate.ToShortDateString <> XmissionDate.ToShortDateString Then
                objIOOffice.LastXferDate = XmissionDate
                objIOOffice.Xfer = 0
            End If
            Dim Xfer As Integer = CInt(objIOOffice.Xfer) + 1
            objIOOffice.Xfer = CType(Xfer, Double)
            'objIO.UpdateInterOffice(objIOOffice)
            '****************************************
            Dim XMissionFile As String = InterOfficeOOCode & String.Format("{0:00}", Now.Month) & String.Format("{0:00}", Now.Day) & String.Format("{0:00}", Now.Year Mod 100) & String.Format("{0:00}", Xfer) '& ".TXT"


            Dim sb As New StringBuilder
            Dim TotalLoadXmited As Integer = 0
            For Each r As GridViewRow In gdvViewList.Rows
                Dim c As CheckBox = CType(r.FindControl("chkXMissionSave"), CheckBox)
                If (Not c Is Nothing) AndAlso c.Enabled AndAlso c.Checked Then
                    Dim LoadId As String = CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text

                    Dim objLoadSheet As LoadSheetInfo = objLC.GetLoadSheet(objLC.GetItemId(LoadId))
                    Dim objLoadAcct As LoadAcctInfo = objAcct.GetLoadAcct(objAcct.GetLoadAcctId(LoadId))
                    'Dim BrokerCode As Integer = (New BrokersController).GetBrokerId(objLoadSheet.BrokerCode)
                    Dim objBroker As BrokerInfo = objBkr.GetBroker(objBkr.GetBrokerId(objLoadSheet.BrokerCode))
                    Dim LoadPUs As ArrayList = (New LoadPUsController).GetLoadPUByLoadId(LoadId)
                    Dim LoadDPs As ArrayList = (New LoadDropsController).GetLoadDropByLoadId(LoadId)

                    '************************** Create HDR

                    sb.Append(GetHDR(objLoadSheet, objLoadAcct, objBroker, LoadDPs) & vbCrLf)

                    '**************************  create a loop for loadpickup DT4

                    If (LoadPUs.Count > 0) Then
                        'Dim objLoadPU As LoadPUInfo = LoadPUs(0)
                        sb.Append(GetFirstLoadPU(LoadPUs(0)) & vbCrLf)
                    End If

                    '**************************  create for loaddrop DT5
                    'sb.Append(GetLoadDP(objLoadSheet, objLoadAcct) & vbCrLf)

                    '************************** Get JRCOffComm
                    'sb.Append(GetIOComm(LoadId, objLoadSheet.JRCIOfficeCode.Substring(0, 7), objLoadAcct.JRCOffComm) & vbCrLf)

                    sb.Append(GetIOComm(LoadId, objLoadAcct.OfficeOverride, objLoadAcct.JRCOffComm) & vbCrLf)
                    ''Split JRCOffComm into JRCOffCommO and JRCOffCommM
                    'sb.Append(GetIOComm(LoadId, objLoadAcct.OfficeOverride, objLoadAcct.JRCOffCommO) & vbCrLf)
                    'If objLoadAcct.JRCOffCommM > 0 Then
                    '    sb.Append(GetIOComm(LoadId, objLoadAcct.ManagerOverrideAccount, objLoadAcct.JRCOffCommM) & vbCrLf)
                    'End If

                    '************************** Get IOComm
                    If (objLoadAcct.IOComm1 > 0) Then
                        'sb.Append(GetIOComm(LoadId, objLoadAcct.JRCIOOffC1, objLoadAcct.IOComm1) & vbCrLf)
                        If objLoadAcct.IsIORecoveredLoad Then
                            sb.Append(GetIOComm(LoadId, objLoadAcct.IoRecoveryCode, objLoadAcct.IOComm1) & vbCrLf)
                        Else
                            sb.Append(GetIOComm(LoadId, objLoadAcct.JRCIOOffC1, objLoadAcct.IOComm1) & vbCrLf)
                        End If
                    End If
                    If (objLoadAcct.IOComm2 > 0) Then
                        sb.Append(GetIOComm(LoadId, objLoadAcct.JRCIOOffC2, objLoadAcct.IOComm2) & vbCrLf)
                    End If

                    If objLoadAcct.AdjustJrcTotal Then objLoadAcct.IOComm3 = objLoadAcct.APComm3 'Use Adjusted IOComm3a 26 July 2010
                    If objLoadSheet.LoadType.ToUpper = "OO" Then
                        'OCommPlus is added to consider the Fuel Tax
                        If (objLoadAcct.IOComm3 + objLoadAcct.OCommPlus > 0) Then
                            sb.Append(GetIOComm(LoadId, objLoadAcct.IOOffC3, objLoadAcct.IOComm3 + objLoadAcct.OCommPlus) & vbCrLf)
                        End If
                    Else
                        'OCommPlus is not added to since the Fuel Tax is only for the Driver Load
                        If (objLoadAcct.IOComm3 > 0) Then
                            sb.Append(GetIOComm(LoadId, objLoadAcct.IOOffC3, objLoadAcct.IOComm3) & vbCrLf)
                        End If
                    End If

                    If (objLoadAcct.IOComm4 > 0) Then
                        sb.Append(GetIOComm(LoadId, objLoadAcct.IOOffC4, objLoadAcct.IOComm4) & vbCrLf)
                    End If

                    '**************************  Driver Commission

                    If (objLoadSheet.LoadType.ToUpper = "BK") Then
                        sb.Append(GetDriverComm(objLoadSheet, objLoadAcct, objIOOffice.LoadAcctB) & vbCrLf)
                    Else
                        sb.Append(GetDriverComm(objLoadSheet, objLoadAcct, objIOOffice.LoadAcct) & vbCrLf)
                    End If

                    '**************************  Invoice Items

                    If (objLoadSheet.LoadType.ToUpper = "BK") Then
                        If (objLoadAcct.BINC3.ToUpper = "Y") AndAlso (objLoadAcct.BDeten > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.DetenAcctB, objLoadAcct.BDeten) & vbCrLf)
                        If (objLoadAcct.BINC4.ToUpper = "Y") AndAlso (objLoadAcct.BTolls > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.TollsAcctB, objLoadAcct.BTolls) & vbCrLf)
                        If (objLoadAcct.BINC5.ToUpper = "Y") AndAlso (objLoadAcct.BFuel > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.FuelAcctB, objLoadAcct.BFuel) & vbCrLf)
                        If (objLoadAcct.BINC6.ToUpper = "Y") AndAlso (objLoadAcct.BDrop > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.DropAcctB, objLoadAcct.BDrop) & vbCrLf)
                        If (objLoadAcct.BINC7.ToUpper = "Y") AndAlso (objLoadAcct.BRecon > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.ReconAcctB, objLoadAcct.BRecon) & vbCrLf)
                        If (objLoadAcct.BINC8.ToUpper = "Y") AndAlso (objLoadAcct.BTarp > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.TarpAcctB, objLoadAcct.BTarp) & vbCrLf)
                        If (objLoadAcct.BINC9.ToUpper = "Y") AndAlso (objLoadAcct.BLumper > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.LumperAcctB, objLoadAcct.BLumper) & vbCrLf)
                        If (objLoadAcct.BINC10.ToUpper = "Y") AndAlso (objLoadAcct.BUnload > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.UnloadAcctB, objLoadAcct.BUnload) & vbCrLf)
                        If (objLoadAcct.BINC11.ToUpper = "Y") AndAlso (objLoadAcct.BAdminMisc > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.AdminMiscAcctB, objLoadAcct.BAdminMisc) & vbCrLf)
                    Else
                        If (objLoadAcct.BINC3.ToUpper = "Y") AndAlso (objLoadAcct.BDeten > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.DetenAcct, objLoadAcct.BDeten) & vbCrLf)
                        If (objLoadAcct.BINC4.ToUpper = "Y") AndAlso (objLoadAcct.BTolls > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.TollsAcct, objLoadAcct.BTolls) & vbCrLf)
                        If (objLoadAcct.BINC5.ToUpper = "Y") AndAlso (objLoadAcct.BFuel > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.FuelAcct, objLoadAcct.BFuel) & vbCrLf)
                        If (objLoadAcct.BINC6.ToUpper = "Y") AndAlso (objLoadAcct.BDrop > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.DropAcct, objLoadAcct.BDrop) & vbCrLf)
                        If (objLoadAcct.BINC7.ToUpper = "Y") AndAlso (objLoadAcct.BRecon > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.ReconAcct, objLoadAcct.BRecon) & vbCrLf)
                        If (objLoadAcct.BINC8.ToUpper = "Y") AndAlso (objLoadAcct.BTarp > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.TarpAcct, objLoadAcct.BTarp) & vbCrLf)
                        If (objLoadAcct.BINC9.ToUpper = "Y") AndAlso (objLoadAcct.BLumper > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.LumperAcct, objLoadAcct.BLumper) & vbCrLf)
                        If (objLoadAcct.BINC10.ToUpper = "Y") AndAlso (objLoadAcct.BUnload > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.UnloadAcct, objLoadAcct.BUnload) & vbCrLf)
                        If (objLoadAcct.BINC11.ToUpper = "Y") AndAlso (objLoadAcct.BAdminMisc > 0) Then sb.Append(GetInvoiceItem(objLoadSheet, objIOOffice.AdminMiscAcct, objLoadAcct.BAdminMisc) & vbCrLf)
                    End If

                    '**************************  Begin Discount

                    If (objLoadAcct.DiscountDlr > 0) Then
                        sb.Append(GetDiscount(objLoadSheet, objLoadAcct, objIOOffice) & vbCrLf)
                    End If

                    '**************************  Begin Rep Dollar

                    If (objLoadAcct.RepDlr > 0) Then
                        sb.Append(GetRepDollar(objLoadSheet, objLoadAcct) & vbCrLf)
                    End If

                    '**************************  Begin JRC Admin

                    sb.Append(GetJrcAdmin(objLoadSheet, objLoadAcct) & vbCrLf)

                    '**************************  Begin Invoice Comment

                    sb.Append(GetInvoiceComment(objLoadSheet, objLoadSheet.InvCommentA, objLoadSheet.InvCommentB) & vbCrLf)
                    sb.Append(GetInvoiceComment(objLoadSheet, objLoadSheet.InvCommentC, objLoadSheet.InvCommentD) & vbCrLf)

                    '** Mark the Load as Xmitted  **
                    objLoadSheet.CompletedLoad = True
                    objLoadSheet.CompletedDate = XmissionDate

                    objLoadSheet.LoadStatus = "COMPLETE"
                    objLoadSheet.XMissionFile = XMissionFile
                    objLoadSheet.XMissionDate = XmissionDate
                    ''objLoadSheet.XmissionSeq += 1
                    c.Enabled = False
                    TotalLoadXmited += 1

                    objLC.UpdateLoadSheet(objLoadSheet)

                    'If c.Checked Then
                    '    'imgXmission.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                    '    'objOI.Popup("Success", "Record " & r.RowIndex.ToString() & " is Selected")
                    '    sb.Append("<font color='green' size='+1'>Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />" & vbCrLf)
                    '    'hypXmission.Text = "Success: Record " & r.RowIndex.ToString() & " is Selected"
                    'Else
                    '    'imgXmission.ImageUrl = ResolveUrl("~/images/delete.gif")
                    '    'objOI.Popup("Failure", "Record " & r.RowIndex.ToString() & " is NOT Selected")
                    '    sb.Append("<font color='red' class='NormalRed'>NOT Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />" & vbCrLf)
                    '    'hypXmission.Text = "Failure: Record " & r.RowIndex.ToString() & " is NOT Selected"
                    'End If
                End If
            Next

            '**************************  End of Entire Datafile
            sb.Append("""End of Data File"",""" & String.Format("{0:MM/dd/yyyy}", XmissionDate) & """,""Xmission no. " & String.Format("{0:00}", Xfer) & """" & vbCrLf)
            objLC.UpdateInterOfficeXmission(ddlJRCIOfficeCode.SelectedValue, Xfer, XmissionDate, XMissionFile)

            hypXmission.Text = "" 'Clear the Msg Text
            Try
                'Save to File
                Dim XmissionPath As String = PortalSettings.HomeDirectoryMapPath 'objIOOffice.TempFile1
                'If XmissionPath = "" Then XmissionPath = 
                If Not XmissionPath.EndsWith("\") Then XmissionPath &= "\"

                XMissionFile &= ".TXT"
                Dim objStream As StreamWriter
                objStream = File.CreateText(XmissionPath & XMissionFile)
                objStream.WriteLine(sb.ToString())
                objStream.Close()
                hypXmission.Text = "<span class='NormalBold' color='green'>Xmission Processed For Xmission File: " & XMissionFile & "</span>"
                hypXmission.NavigateUrl = ResolveUrl(PortalSettings.HomeDirectory & XMissionFile) 'Give the Link to Uploaded File

                'Write the File to P drive too
                XmissionPath = objIOOffice.TempFile1
                If XmissionPath <> "" Then
                    If Not XmissionPath.EndsWith("\") Then XmissionPath &= "\"
                    If Directory.Exists(XmissionPath) Then
                        objStream = File.CreateText(XmissionPath & XMissionFile)
                        objStream.WriteLine(sb.ToString())
                        objStream.Close()
                        hypXmission.Text &= "<br/><span class='NormalBold' color='green'>Success: Xmitted Total " & TotalLoadXmited.ToString & " Load and created " & XmissionPath & XMissionFile & " File</span>"
                    Else
                        hypXmission.Text &= "<br/><span class='NormalRed'>Error: " & XmissionPath & " does not exists</span>"
                    End If
                Else
                    hypXmission.Text &= "<br/><span class='NormalRed'>No Xmission Folder specified</span>"
                End If



                'Write the File to FailSafe Location too
                XmissionPath = (New OptionsInfo(ModuleId)).XmissionFileBackupFolder  '"C:\INETPUB\WWWROOT\VINCE_XMISSIONBU\" 'objIOOffice.TempFile1
                If XmissionPath <> "" Then
                    If Not XmissionPath.EndsWith("\") Then XmissionPath &= "\"
                    'If Not Directory.Exists(XmissionPath) Then
                    '    Try

                    '        'Dim ds As System.Security.AccessControl.DirectorySecurity
                    '        'Dim sid As New System.Security.Principal.SecurityIdentifier(WellKnowSitType.CreatorOwnerSid, Nothing)
                    '        'Dim ace = New System.Security.AccessControl.FileSystemAccessRule(sid, FileSystemAccessRights.FullControl, AccessControlType.Allow)
                    '        'ds.AddAccessRule(ace)
                    '        'Directory.CreateDirectory(XmissionPath, ds)
                    '        Directory.CreateDirectory(XmissionPath)
                    '    Catch
                    '    End Try
                    'End If
                    If Directory.Exists(XmissionPath) Then
                        objStream = File.CreateText(XmissionPath & XMissionFile)
                        objStream.WriteLine(sb.ToString())
                        objStream.Close()
                        hypXmission.Text &= "<br/><span class='NormalBold' color='green'>Success: Xmitted Total " & TotalLoadXmited.ToString & " Load and created " & XmissionPath & XMissionFile & " File</span>"
                    Else
                        hypXmission.Text &= "<br/><span class='NormalRed'>Error: " & XmissionPath & " does not exists</span>"
                    End If
                Else
                    hypXmission.Text &= "<br/><span class='NormalRed'>No FailSafe Xmission Folder specified</span>"
                End If


                'Redirect to Xmission Report
                If chkRedirect2Report.Checked Then
                    hypXmission.NavigateUrl = EditUrl("ReportType", "rvXmission", "Reports", "XmissionFile=" + XMissionFile.Replace(".TXT", ""), "dnnprintmode=true")
                    Response.Redirect(hypXmission.NavigateUrl)
                End If
            Catch ex As Exception
                hypXmission.Text = "<span class='NormalRed'>Error: Xmission Could not be Processed For Xmission File: " & XMissionFile & "</span><br/>" & ex.ToString
            End Try


            'Controls.Add(objOI.Popup("Xmission", "Xmission Processed<br/>Click here for details", sb.ToString()))
        End Sub
        Private Sub UnXmit()
            Dim objLC As New LoadSheetsController
            'For Each r As GridViewRow In gdvViewList.Rows
            '    Dim c As CheckBox = CType(r.FindControl("chkXMissionSave"), CheckBox)
            '    If (Not c Is Nothing) AndAlso (Not c.Enabled) Then
            '        Dim objLoadSheet As LoadSheetInfo = objLC.GetLoadSheet(objLC.GetItemId(CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text))

            '        objLoadSheet.CompletedLoad = False
            '        objLoadSheet.CompletedDate = Null.NullDate

            '        objLoadSheet.LoadStatus = "WIP"
            '        objLoadSheet.XMissionFile = ""
            '        objLoadSheet.XMissionDate = Null.NullDate
            '        objLC.UpdateLoadSheet(objLoadSheet)
            '        c.Enabled = True
            '    End If
            'Next
            objLC.UnXmit(ddlXmissionFile.SelectedValue)
            hypXmission.Text = "Un-Xmission Processed For Successfully"
        End Sub

        Private Function GetCodLoadNo() As Integer
            'Dim dt As DataTable = (New LoadSheetsController).GetSearchedLoadSheetsX(ddlJRCIOfficeCode.SelectedValue, "", "", True, "Any", False, 100, txtFrom.Text, txtTo.Text)
            Dim dt As DataTable = (New LoadSheetsController).GetSearchedLoadSheetsX(ddlJRCIOfficeCode.SelectedValue, "", "", True)
            Return dt.Rows.Count
        End Function

        Private Sub SetCodCheckBox()
            chkCodOnly.Visible = ((UserController.GetCurrentUserInfo.IsSuperUser) OrElse (UserController.GetCurrentUserInfo.IsInRole("Administrator")) OrElse (UserController.GetCurrentUserInfo.IsInRole("COD Xmission"))) AndAlso (GetCodLoadNo() > 0)
            If Not chkCodOnly.Visible Then
                If chkCodOnly.Checked Then
                    chkCodOnly.Checked = False

                    ResetViewStates()
                    BindUnXmit()
                End If
            End If
            SetMissingCodCheckBox()
        End Sub

        Private Sub SetMissingCodCheckBox()
            chkMissingCodOnly.Visible = chkCodOnly.Visible AndAlso chkCodOnly.Checked
            If Not chkMissingCodOnly.Visible Then chkMissingCodOnly.Checked = False
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
                hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)

                hypReport1.NavigateUrl = EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport2Driver.NavigateUrl = EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport2Broker.NavigateUrl = EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypReport3.NavigateUrl = EditUrl("ReportType", "Report3", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                hypDriverStatus.NavigateUrl = EditUrl("ReportType", "DriverStatus", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


                If Not Page.IsPostBack Then
                    BindUserIOs()
                    BindUnXmit()
                    'BindSearchData()

                    'Dim sm As ScriptManager = CType(Me.Page.FindControl("ScriptManager1"), ScriptManager)
                    'If Not sm Is Nothing Then
                    '    sm.AsyncPostBackTimeout = 3600
                    '    hypXmission.Text = "ScriptManager1 time out " & sm.AsyncPostBackTimeout.ToString()
                    'Else
                    '    hypXmission.Text = "ScriptManager1 not Found"
                    'End If

                    'hypXmission.Text = "ScriptManager1 Timeouts "
                    'For Each ctl As Control In Me.Page.Controls
                    '    If ctl.ID.Contains("ScriptManager") Then
                    '        Try
                    '            Dim sm As ScriptManager = CType(ctl, ScriptManager)
                    '            sm.AsyncPostBackTimeout = 3600
                    '            hypXmission.Text = "<br/>" & ctl.ID & ".AsyncPostBackTimeout = " & sm.AsyncPostBackTimeout.ToString()
                    '        Catch

                    '        End Try
                    '    End If
                    'Next

                    'Removed this filter to get all the files in the list without the initial data filter
                    If (Not Request.QueryString("FromDate") Is Nothing) AndAlso (Request.QueryString("FromDate") <> "") Then
                        txtFrom.Text = Request.QueryString("FromDate")
                    Else
                        txtFrom.Text = Now.AddMonths(-6).ToShortDateString
                    End If
                    If (Not Request.QueryString("ToDate") Is Nothing) AndAlso (Request.QueryString("ToDate") <> "") Then
                        txtTo.Text = Request.QueryString("ToDate")
                    Else
                        txtTo.Text = Now.ToShortDateString
                    End If
                    Try
                        rblSearchOn.SelectedValue = Session.Item("SearchOn").ToString
                    Catch
                        rblSearchOn.SelectedValue = "ANY"
                    End Try
                    SetCodCheckBox()
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Private Sub odsLoadSheets_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsLoadSheets.Selecting

            If (Not ddlJRCIOfficeCode.SelectedValue Is Nothing) AndAlso (ddlJRCIOfficeCode.SelectedValue <> "") Then
                e.InputParameters("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue()
            Else
                e.InputParameters("JRCIOfficeCode") = ""
            End If
            If (Not ddlXmissionFile.SelectedValue Is Nothing) AndAlso (ddlXmissionFile.SelectedValue <> "") Then
                e.InputParameters("XmissionFile") = ddlXmissionFile.SelectedValue()
            Else
                e.InputParameters("XmissionFile") = ""
            End If
            e.InputParameters("SearchText") = txtSearch.Text

            e.InputParameters("CodOnly") = chkCodOnly.Checked
            e.InputParameters("MissingCodOnly") = chkMissingCodOnly.Checked

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

                    Dim lblCodCheckSeqHead As Label = CType(e.Row.FindControl("lblCodCheckSeqHead"), Label)
                    If Not lblCodCheckSeqHead Is Nothing Then
                        lblCodCheckSeqHead.Visible = chkCodOnly.Checked AndAlso (Not tdUnXmission.Visible)
                    End If

                    Dim lblCustPOHead As Label = CType(e.Row.FindControl("lblCustPOHead"), Label)
                    If Not lblCustPOHead Is Nothing Then
                        lblCustPOHead.Visible = Not tdUnXmission.Visible
                    End If

                    Dim lblBkrInvNoHead As Label = CType(e.Row.FindControl("lblBkrInvNoHead"), Label)
                    If Not lblBkrInvNoHead Is Nothing Then
                        lblBkrInvNoHead.Visible = Not tdUnXmission.Visible
                    End If

                    Dim lblLoadTypeHead As Label = CType(e.Row.FindControl("lblLoadTypeHead"), Label)
                    If Not lblLoadTypeHead Is Nothing Then
                        With lblLoadTypeHead
                            Select Case rblSearchOn.SelectedValue.ToUpper 'CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
                                Case "IO"
                                    .Text = "InterOffice"
                                    .ToolTip = "JRCIOCode"
                                Case "BK"
                                    .Text = "BrokerName"
                                    .ToolTip = "BrokerCode"
                                Case "OO"
                                    .Text = "DriverName"
                                    .ToolTip = "DriverCode"
                                Case Else
                                    .Text = "Name"
                                    .ToolTip = "Code"
                            End Select
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblLoadTypeHead
                    End If
                End If
            Catch exc As Exception    'Module failed to RowCreated
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'Private Sub gdvViewList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowDataBound
        '    Try
        '        If e.Row.RowType = DataControlRowType.DataRow Then
        '            Dim hypCopyLoad As HyperLink = CType(e.Row.FindControl("hypCopyLoad"), HyperLink)
        '            Dim hypEditItem As HyperLink = CType(e.Row.FindControl("hypEditItem"), HyperLink)
        '            'Dim hypThumb As HyperLink = CType(e.Row.FindControl("hypThumb"), HyperLink)
        '            Dim hypEditAcct As HyperLink = CType(e.Row.FindControl("hypEditAcct"), HyperLink)
        '            Dim hypLoadID As HyperLink = CType(e.Row.FindControl("hypLoadID"), HyperLink)
        '            Dim hypLoadReport As HyperLink = CType(e.Row.FindControl("hypLoadReport"), HyperLink)
        '            Dim hypPrintLoadReport As HyperLink = CType(e.Row.FindControl("hypPrintLoadReport"), HyperLink)
        '            Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
        '            Dim lblLoadStatus As Label = CType(e.Row.FindControl("lblLoadStatus"), Label)
        '            Dim lblLoadTypeName As Label = CType(e.Row.FindControl("lblLoadTypeName"), Label)
        '            Dim imgXmission As Image = CType(e.Row.FindControl("imgXmission"), Image)
        '            Dim chkXMissionSave As CheckBox = CType(e.Row.FindControl("chkXMissionSave"), CheckBox)

        '            'Dim lblLoadTypeCode As Label = CType(e.Row.FindControl("lblLoadTypeCode"), Label)


        '            If Not lblLoadStatus Is Nothing Then
        '                Try
        '                    lblLoadStatus.Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).Substring(0, 3)
        '                    lblLoadStatus.Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), String).Substring(0, 4)
        '                Catch
        '                End Try
        '            End If

        '            'Dim dr As IDataReader = New Business.LoadSheetInfo
        '            If (CType(DataBinder.Eval(e.Row.DataItem, "XMissionFile"), String) = "") Then
        '                imgXmission.ImageUrl = ResolveUrl("~/images/delete.gif")
        '            Else
        '                imgXmission.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
        '            End If
        '            If Not chkXMissionSave Is Nothing Then
        '                chkXMissionSave.Checked = CType(DataBinder.Eval(e.Row.DataItem, "XMissionSave"), Boolean)
        '            End If

        '            If Not hypEditItem Is Nothing Then
        '                With hypEditItem
        '                    .Visible = IsEditable AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'AndAlso (lblLoadStatus.Text <> "COMP")
        '                    If .Visible Then
        '                        If (lblLoadStatus.Text = "COMP") OrElse (lblLoadStatus.Text = "VOID") Then
        '                            .ImageUrl = ResolveUrl("~/images/1x1.gif")
        '                            .Style.Add(HtmlTextWriterStyle.Height, "0px")
        '                            .Style.Add(HtmlTextWriterStyle.Width, "16px")

        '                            '.ToolTip = "Completed Load"
        '                            '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
        '                        Else
        '                            .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
        '                            .ToolTip = Localization.GetString("Edit")
        '                        End If
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypEditItem
        '            End If

        '            If Not hypCopyLoad Is Nothing Then
        '                With hypCopyLoad
        '                    .Visible = IsEditable AndAlso (lblLoadStatus.Text <> "COMP") AndAlso (lblLoadStatus.Text <> "VOID") AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y")
        '                    If .Visible Then
        '                        .NavigateUrl = EditUrl("FromLoadId", CType(DataBinder.Eval(e.Row.DataItem, "LoadId"), String), "Edit", "OType=CopyLoad")
        '                        .ToolTip = Localization.GetString("copy_load", LocalResourceFile)
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypCopyLoad
        '            End If

        '            If Not imbDelete Is Nothing Then
        '                With imbDelete
        '                    .Visible = IsEditable AndAlso objOI.DeleteFromGrid AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y")
        '                    If .Visible Then
        '                        '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
        '                        .ToolTip = "Delete"
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                        .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
        '                    End If
        '                End With  'imbDelete
        '            End If

        '            'If Not hypThumb Is Nothing Then
        '            '    With hypThumb
        '            '        .Visible = (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
        '            '        If .Visible Then

        '            '            .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ItemDetails", "Item=LoadSheet")
        '            '            .ToolTip = "View Details"
        '            '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '            '        End If
        '            '    End With 'hypThumb
        '            'End If

        '            If Not hypLoadId Is Nothing Then
        '                With hypLoadID
        '                    .Visible = True
        '                    If .Visible Then
        '                        .Text = CType(DataBinder.Eval(e.Row.DataItem, "LoadId"), String).ToUpper
        '                        .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
        '                        .ToolTip = Localization.GetString("Edit")

        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypLoadId
        '            End If

        '            If Not lblLoadTypeName Is Nothing Then
        '                With lblLoadTypeName
        '                    Select Case CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
        '                        Case "IO"
        '                            Dim Office As String = Replace(CType(DataBinder.Eval(e.Row.DataItem, "IOName"), String), "JRC - ", "")
        '                            Office = Replace(Office, "JRC ", "")
        '                            .Text = Office.ToUpper
        '                            .ToolTip = "JRCIOCode: " & CType(DataBinder.Eval(e.Row.DataItem, "JRCIOCode"), String)
        '                        Case "BK"
        '                            .Text = CType(DataBinder.Eval(e.Row.DataItem, "BrokerName"), String)
        '                            .ToolTip = "BrokerCode: " & CType(DataBinder.Eval(e.Row.DataItem, "BrokerCode"), String)
        '                        Case Else '"OO"
        '                            .Text = CType(DataBinder.Eval(e.Row.DataItem, "DriverName"), String)
        '                            .ToolTip = "DriverCode: " & CType(DataBinder.Eval(e.Row.DataItem, "DriverCode"), String)
        '                    End Select
        '                    .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                End With  'lblLoadTypeName
        '            End If

        '            If Not hypEditAcct Is Nothing Then
        '                With hypEditAcct
        '                    .Visible = IsEditable AndAlso (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'AndAlso (lblLoadStatus.Text.ToUpper <> "COMP")
        '                    If .Visible Then
        '                        If (lblLoadStatus.Text = "COMP") OrElse (lblLoadStatus.Text = "VOID") Then
        '                            .ImageUrl = ResolveUrl("~/images/1x1.gif")
        '                            .Style.Add(HtmlTextWriterStyle.Height, "0px")
        '                            .Style.Add(HtmlTextWriterStyle.Width, "16px")

        '                            '.ToolTip = "Completed Load"
        '                            '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
        '                            '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ComCheck", "Item=ComCheckLoad")
        '                        Else
        '                            .ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
        '                            .NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
        '                        End If
        '                        '.ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
        '                        '.NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypEditAcct
        '            End If

        '            If Not hypLoadReport Is Nothing Then
        '                With hypLoadReport
        '                    .Visible = True
        '                    If .Visible Then
        '                        .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
        '                        .Target = "_blank"
        '                        .ToolTip = Localization.GetString("LoadReport", LocalResourceFile)
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypEditAcct
        '            End If

        '            If Not hypPrintLoadReport Is Nothing Then
        '                With hypPrintLoadReport
        '                    Dim strLoadType As String = CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String).ToUpper
        '                    .Visible = (strLoadType = "OO") OrElse (strLoadType = "BK")
        '                    If .Visible Then
        '                        '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
        '                        .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType)
        '                        .Target = "_blank"
        '                        Select Case strLoadType
        '                            Case "OO"
        '                                .ToolTip = "Driver Confirm"
        '                            Case "BK"
        '                                .ToolTip = "Broker Confirm"
        '                                'Case "IO"
        '                                '    .ToolTip = "IO Confirm"
        '                                'Case Else '"OO"
        '                                '    .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
        '                        End Select
        '                        .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '                    End If
        '                End With  'hypEditAcct
        '            End If

        '            'If Not hypPrintLoadReport Is Nothing Then
        '            '    With hypPrintLoadReport
        '            '        .Visible = True
        '            '        If .Visible Then
        '            '            .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
        '            '            .Target = "_blank"
        '            '            .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
        '            '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
        '            '        End If
        '            '    End With  'hypEditAcct
        '            'End If

        '        End If
        '    Catch exc As Exception    'Module failed to RowDataBound
        '        ProcessModuleLoadException(Me, exc)
        '    End Try

        'End Sub

        Private Sub gdvViewList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvViewList.RowDataBound
            Try
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim hypCopyLoad As HyperLink = CType(e.Row.FindControl("hypCopyLoad"), HyperLink)
                    Dim hypEditItem As HyperLink = CType(e.Row.FindControl("hypEditItem"), HyperLink)
                    'Dim hypThumb As HyperLink = CType(e.Row.FindControl("hypThumb"), HyperLink)
                    Dim hypEditAcct As HyperLink = CType(e.Row.FindControl("hypEditAcct"), HyperLink)
                    Dim hypLoadID As HyperLink = CType(e.Row.FindControl("hypLoadID"), HyperLink)
                    Dim hypLoadReport As HyperLink = CType(e.Row.FindControl("hypLoadReport"), HyperLink)
                    Dim hypPrintLoadReport As HyperLink = CType(e.Row.FindControl("hypPrintLoadReport"), HyperLink)
                    Dim imbDelete As ImageButton = CType(e.Row.FindControl("imbDelete"), ImageButton)
                    Dim lblLoadStatus As Label = CType(e.Row.FindControl("lblLoadStatus"), Label)
                    Dim lblLoadTypeName As Label = CType(e.Row.FindControl("lblLoadTypeName"), Label)
                    Dim imgXmission As Image = CType(e.Row.FindControl("imgXmission"), Image)
                    Dim chkXMissionSave As CheckBox = CType(e.Row.FindControl("chkXMissionSave"), CheckBox)
                    Dim txtCodCheckSeq As TextBox = CType(e.Row.FindControl("txtCodCheckSeq"), TextBox)

                    Dim txtCustPO As TextBox = CType(e.Row.FindControl("txtCustPO"), TextBox)
                    Dim txtBkrInvNo As TextBox = CType(e.Row.FindControl("txtBkrInvNo"), TextBox)

                    'Dim lblLoadTypeCode As Label = CType(e.Row.FindControl("lblLoadTypeCode"), Label)

                    Dim _ItemId As Integer = Null.NullInteger
                    _ItemId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ItemID"), _ItemId))
                    'int _ModuleId = Null.NullInteger; _ModuleId = Convert.ToInt32(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "ModuleID"), _ModuleId)); 
                    Dim _JRCActive As String = Null.NullString
                    _JRCActive = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "JRCActive"), _JRCActive))
                    Dim _LoadId As String = Null.NullString
                    _LoadId = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadId"), _LoadId))
                    Dim _JRCIOCode As String = Null.NullString
                    _JRCIOCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "JRCIOCode"), _JRCIOCode))
                    Dim _LoadType As String = Null.NullString
                    _LoadType = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadType"), _LoadType))
                    Dim _LoadStatus As String = Null.NullString
                    _LoadStatus = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "LoadStatus"), _LoadStatus))
                    Dim _IOName As String = Null.NullString
                    _IOName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "IOName"), _IOName))
                    Dim _BrokerName As String = Null.NullString
                    _BrokerName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BrokerName"), _BrokerName))
                    Dim _BrokerCode As String = Null.NullString
                    _BrokerCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BrokerCode"), _BrokerCode))
                    Dim _DriverName As String = Null.NullString
                    _DriverName = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DriverName"), _DriverName))
                    Dim _DriverCode As String = Null.NullString
                    _DriverCode = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "DriverCode"), _DriverCode))

                    Dim _CodCheckSeq As String = Null.NullString
                    _CodCheckSeq = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "CodCheckSeq"), _CodCheckSeq))

                    Dim _XMissionFile As String = Null.NullString
                    _XMissionFile = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "XMissionFile"), _XMissionFile))

                    Dim _XMissionSave As Boolean = Null.NullBoolean
                    _XMissionSave = Convert.ToBoolean(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "XMissionSave"), _XMissionSave))

                    Dim _CustPO As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "CustPO"), Null.NullString))
                    Dim _BkrInvNo As String = Convert.ToString(Null.SetNull(DataBinder.Eval(e.Row.DataItem, "BkrInvNo"), Null.NullString))


                    If Not lblLoadStatus Is Nothing Then
                        Try
                            'lblLoadStatus.Text = _LoadStatus.Substring(0, 3)
                            'lblLoadStatus.Text = _LoadStatus.Substring(0, 4)
                            If _LoadStatus.Length > 4 Then
                                lblLoadStatus.Text = _LoadStatus.Substring(0, 4).ToUpper
                            Else
                                lblLoadStatus.Text = _LoadStatus.ToUpper
                            End If
                        Catch
                        End Try
                    End If



                    If Not txtCustPO Is Nothing Then
                        txtCustPO.Visible = (Not tdUnXmission.Visible)
                        If txtCustPO.Visible Then txtCustPO.Text = _CustPO
                    End If
                    If Not txtBkrInvNo Is Nothing Then
                        txtBkrInvNo.Visible = (_LoadType.ToUpper = "BK") AndAlso (Not tdUnXmission.Visible)
                        If txtBkrInvNo.Visible Then txtBkrInvNo.Text = _BkrInvNo
                    End If

                    If Not txtCodCheckSeq Is Nothing Then
                        txtCodCheckSeq.Visible = chkCodOnly.Checked AndAlso (Not tdUnXmission.Visible)
                        If txtCodCheckSeq.Visible Then
                            txtCodCheckSeq.Text = _CodCheckSeq
                        End If
                    End If

                    'Dim dr As IDataReader = New Business.LoadSheetInfo
                    imgXmission.Visible = _XMissionFile <> ""

                    'If (_XMissionFile = "") Then
                    '    imgXmission.ImageUrl = ResolveUrl("~/images/delete.gif")
                    'Else
                    '    imgXmission.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
                    'End If
                    If Not chkXMissionSave Is Nothing Then
                        'chkXMissionSave.Visible = Not imgXmission.Visible
                        If imgXmission.Visible Then
                            chkXMissionSave.Checked = True
                            chkXMissionSave.Style.Add("display", "none")
                        Else
                            If chkXMissionSave.Visible Then chkXMissionSave.Checked = _XMissionSave
                        End If

                        Dim chkToolTip As String = ""
                        If chkCodOnly.Checked AndAlso (_CodCheckSeq = "") Then
                            chkToolTip = "COD Check Number Can't be Null "
                        End If
                        If (_LoadType = "BK") AndAlso (_BkrInvNo = "") Then
                            chkToolTip &= "Broker Invoice Number Can't be Null "
                        End If

                        'chkXMissionSave.Enabled = Not (chkCodOnly.Checked AndAlso (_CodCheckSeq = ""))
                        chkXMissionSave.Enabled = (chkToolTip = "")
                        If Not chkXMissionSave.Enabled Then
                            chkXMissionSave.Checked = False
                            chkXMissionSave.ToolTip = chkToolTip '"COD Check Number Can't be Null"
                        End If
                    End If

                    If Not hypEditItem Is Nothing Then
                        With hypEditItem
                            .Visible = IsEditable AndAlso (_JRCActive.ToUpper = "Y") 'AndAlso (lblLoadStatus.Text <> "COMP")
                            If .Visible Then
                                If (lblLoadStatus.Text = "COMP") OrElse (lblLoadStatus.Text = "VOID") Then
                                    .ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    .Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    .Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    '.ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                Else
                                    .NavigateUrl = EditUrl("ItemID", _ItemId)
                                    .ToolTip = Localization.GetString("Edit")
                                End If
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditItem
                    End If

                    If Not hypCopyLoad Is Nothing Then
                        With hypCopyLoad
                            .Visible = IsEditable AndAlso (lblLoadStatus.Text <> "COMP") AndAlso (lblLoadStatus.Text <> "VOID") AndAlso (_JRCActive.ToUpper = "Y")
                            If .Visible Then
                                .NavigateUrl = EditUrl("FromLoadId", _LoadId, "Edit", "OType=Templating")
                                .ToolTip = Localization.GetString("copy_load", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypCopyLoad
                    End If

                    If Not imbDelete Is Nothing Then
                        With imbDelete
                            .Visible = IsEditable AndAlso objOI.DeleteFromGrid AndAlso (_JRCActive.ToUpper = "Y")
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
                                .ToolTip = "Delete"
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                                .Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                            End If
                        End With  'imbDelete
                    End If

                    'If Not hypThumb Is Nothing Then
                    '    With hypThumb
                    '        .Visible = (CType(DataBinder.Eval(e.Row.DataItem, "JRCActive"), String).ToUpper = "Y") 'CType(DataBinder.Eval(e.Row.DataItem, "MediaSrc"), String) <> String.Empty 'Not objOI.ShowListingOnly
                    '        If .Visible Then

                    '            .NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ItemDetails", "Item=LoadSheet")
                    '            .ToolTip = "View Details"
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With 'hypThumb
                    'End If

                    If Not hypLoadID Is Nothing Then
                        With hypLoadID
                            .Visible = True
                            If .Visible Then
                                .Text = _LoadId.ToUpper
                                .NavigateUrl = EditUrl("ItemID", _ItemId)
                                .ToolTip = Localization.GetString("Edit")

                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypLoadId
                    End If

                    If Not lblLoadTypeName Is Nothing Then
                        With lblLoadTypeName
                            Select Case _LoadType.ToUpper
                                Case "IO"
                                    Dim Office As String = Replace(_IOName, "JRC - ", "")
                                    Office = Replace(Office, "JRC ", "")
                                    .Text = Office.ToUpper
                                    .ToolTip = "JRCIOCode: " & _JRCIOCode
                                Case "BK"
                                    .Text = _BrokerName
                                    .ToolTip = "BrokerCode: " & _BrokerCode
                                Case Else '"OO"
                                    .Text = _DriverName
                                    .ToolTip = "DriverCode: " & _DriverCode
                            End Select
                            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                        End With  'lblLoadTypeName
                    End If

                    If Not hypEditAcct Is Nothing Then
                        With hypEditAcct
                            .Visible = IsEditable AndAlso (_JRCActive.ToUpper = "Y") 'AndAlso (lblLoadStatus.Text.ToUpper <> "COMP")
                            If .Visible Then
                                If (lblLoadStatus.Text = "COMP") OrElse (lblLoadStatus.Text = "VOID") Then
                                    .ImageUrl = ResolveUrl("~/images/1x1.gif")
                                    .Style.Add(HtmlTextWriterStyle.Height, "0px")
                                    .Style.Add(HtmlTextWriterStyle.Width, "16px")

                                    '.ToolTip = "Completed Load"
                                    '.NavigateUrl = "javascript:alert('Completed Load cannot be Edited')"
                                    '.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "ComCheck", "Item=ComCheckLoad")
                                Else
                                    .ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                    .NavigateUrl = EditUrl("LoadID", _LoadId, "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                End If
                                '.ToolTip = Localization.GetString("EditAccounts", LocalResourceFile)
                                '.NavigateUrl = EditUrl("LoadID", CType(DataBinder.Eval(e.Row.DataItem, "LoadID"), String), "EditAcct", "Item=LoadAccount") 'EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "EditAcct", "Item=LoadAccount")
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    If Not hypLoadReport Is Nothing Then
                        With hypLoadReport
                            .Visible = True
                            If .Visible Then
                                .NavigateUrl = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & _ItemId, "LoadType=" & _LoadType)
                                .Target = "_blank"
                                .ToolTip = Localization.GetString("LoadReport", LocalResourceFile)
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    If Not hypPrintLoadReport Is Nothing Then
                        With hypPrintLoadReport
                            Dim strLoadType As String = _LoadType.ToUpper
                            .Visible = (strLoadType = "OO") OrElse (strLoadType = "BK")
                            If .Visible Then
                                '.NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & strLoadType, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
                                .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & _ItemId, "LoadType=" & strLoadType)
                                .Target = "_blank"
                                Select Case strLoadType
                                    Case "OO"
                                        .ToolTip = "Driver Confirm"
                                    Case "BK"
                                        .ToolTip = "Broker Confirm"
                                        'Case "IO"
                                        '    .ToolTip = "IO Confirm"
                                        'Case Else '"OO"
                                        '    .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                                End Select
                                .Attributes.Add("onmouseover", "window.status=this.title; return true")
                            End If
                        End With  'hypEditAcct
                    End If

                    'If Not hypPrintLoadReport Is Nothing Then
                    '    With hypPrintLoadReport
                    '        .Visible = True
                    '        If .Visible Then
                    '            .NavigateUrl = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String), "LoadType=" & CType(DataBinder.Eval(e.Row.DataItem, "LoadType"), String))
                    '            .Target = "_blank"
                    '            .ToolTip = Localization.GetString("PrintLoadReport", LocalResourceFile)
                    '            .Attributes.Add("onmouseover", "window.status=this.title; return true")
                    '        End If
                    '    End With  'hypEditAcct
                    'End If

                End If
            Catch exc As Exception    'Module failed to RowDataBound
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            'BindUnXmit()
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Protected Sub ddlXmissionFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlXmissionFile.SelectedIndexChanged
            tdXmission.Visible = (ddlXmissionFile.SelectedValue = "")

            Dim AllowedToUnXmit As Boolean = UserController.GetCurrentUserInfo.IsSuperUser OrElse UserController.GetCurrentUserInfo.IsInRole("Administrators") OrElse UserController.GetCurrentUserInfo.IsInRole("Admin - JRC")

            tdUnXmission.Visible = (AllowedToUnXmit AndAlso (Not tdXmission.Visible))
            'Dim XFile As String = ddlXmissionFile.SelectedValue
            'btnSearch_Click(Nothing, Nothing)
            'ddlXmissionFile.SelectedValue = XFile
            ResetViewStates()
        End Sub

        'Private Sub ddlCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategories.SelectedIndexChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub chkCodOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCodOnly.CheckedChanged, chkMissingCodOnly.CheckedChanged
            SetMissingCodCheckBox()
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub rblSearchOn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSearchOn.SelectedIndexChanged
            Session.Item("SearchOn") = rblSearchOn.SelectedValue
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            'BindSearchData()
            ResetViewStates()
            BindUnXmit()

            SetCodCheckBox()
        End Sub

        'Private Sub imbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSearch.Click
        '    ResetViewStates()
        'End Sub


        'Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '    If objOI.AsyncXmission Then
        '        btnSave.Enabled = False
        '        Dim objThread As New Threading.Thread(AddressOf UpdateXMission)
        '        objThread.Start()
        '        Controls.Add(objOI.Popup("Xmission", "Xmission Save Started for Save ..."))
        '    Else
        '        UpdateXMission()
        '    End If
        'End Sub

        'Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '    Dim sb As New StringBuilder
        '    Dim c As CheckBox
        '    Dim objLC As New LoadSheetsController
        '    Dim objLoad As LoadSheetInfo

        '    For Each r As GridViewRow In gdvViewList.Rows
        '        c = CType(r.FindControl("chkXMissionSave"), CheckBox)
        '        If Not c Is Nothing Then
        '            objLoad = objLC.GetLoadSheet(objLC.GetItemId(CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text))
        '            objLoad.XMissionSave = c.Checked
        '            objLC.UpdateLoadSheet(objLoad)
        '            If c.Checked Then
        '                sb.Append("<font color='green' size='+1'>Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
        '            Else
        '                sb.Append("<font color='red' class='NormalRed'>NOT Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
        '            End If
        '        End If
        '    Next
        '    Controls.Add(objOI.Popup("Xmission", "Xmission Processed For Save<br/>Click here for details", sb.ToString()))
        'End Sub

        'Private Sub btnXmission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnXmission.Click
        '    Dim sb As New StringBuilder

        '    For Each r As GridViewRow In gdvViewList.Rows
        '        Dim c As CheckBox = CType(r.FindControl("chkXMissionSave"), CheckBox)
        '        If Not c Is Nothing Then
        '            If c.Checked Then
        '                'imgXmission.ImageUrl = ResolveUrl("~/images/FileManager/files/OK.gif")
        '                'objOI.Popup("Success", "Record " & r.RowIndex.ToString() & " is Selected")
        '                sb.Append("<font color='green' size='+1'>Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
        '                'hypXmission.Text = "Success: Record " & r.RowIndex.ToString() & " is Selected"
        '            Else
        '                'imgXmission.ImageUrl = ResolveUrl("~/images/delete.gif")
        '                'objOI.Popup("Failure", "Record " & r.RowIndex.ToString() & " is NOT Selected")
        '                sb.Append("<font color='red' class='NormalRed'>NOT Selected LoadId " & CType(gdvViewList.Rows(r.RowIndex).FindControl("hypLoadID"), HyperLink).Text & " at " & r.RowIndex.ToString() & " for Xmission</font><br />")
        '                'hypXmission.Text = "Failure: Record " & r.RowIndex.ToString() & " is NOT Selected"
        '            End If
        '        End If
        '    Next
        '    'hypXmission.Text = sb.ToString()
        '    Controls.Add(objOI.Popup("Xmission", "Xmission Processed<br/>Click here for details", sb.ToString()))
        'End Sub

        Private Sub imbSelectAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSelectAll.Click
            lnbSelectAll_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbSelectAll.Click
            SelectAll(True)
        End Sub

        Private Sub imbUnSelectAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUnSelectAll.Click
            lnbUnSelectAll_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUnSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUnSelectAll.Click
            SelectAll(False)
        End Sub

        Private Sub imbSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSave.Click
            lnbSave_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbSave.Click
            If objOI.AsyncXmission Then
                btnSave.Enabled = False
                Dim objThread As New Threading.Thread(AddressOf UpdateXMission)
                objThread.Start()
                'Controls.Add(objOI.Popup("Xmission", "Xmission Save Started for Save ..."))
                hypXmission.Text = "Xmission Save Started for Save ..."
            Else
                UpdateXMission()
            End If
        End Sub

        Private Sub imbXmission_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbXmission.Click
            lnbXmission_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbXmission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbXmission.Click
            If NoOfXmits() > 0 Then
                If CodCheckOK() Then
                    If chkCodOnly.Checked Then lnbSave_Click(Nothing, Nothing)
                    Xmit()
                    btnSearch_Click(Nothing, Nothing)
                Else
                    hypXmission.Text = "<font color='red' class='NormalRed'>COD Check Number Cannot be Null for Selected Loads for Xmission</font>"
                End If
            Else
                hypXmission.Text = "<font color='red' class='NormalRed'>No Loads Selected for Xmission</font>"
            End If
        End Sub

        Private Sub imbUnXmission_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgUnXmission.Click
            lnbUnXmission_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUnXmission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUnXmission.Click
            UnXmit()
            btnSearch_Click(Nothing, Nothing)
        End Sub

#End Region

    End Class 'Xmission

End Namespace 'bhattji.Modules.LoadSheets
