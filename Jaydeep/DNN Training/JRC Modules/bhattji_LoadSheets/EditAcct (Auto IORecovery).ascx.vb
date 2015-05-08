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
Imports System
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.InterOffices.Business
'Imports Microsoft.ScalableHosting.Security
'Imports AspNetSecurity = Microsoft.ScalableHosting.Security

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class EditAcct
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
        Private itemId As Integer
        Private objOI As OptionsInfo
        'Private strLoadType As String
#End Region

#Region " Public Methods "

        Private Sub BindReps()
            With ddlRepNo
                .DataValueField = "RepNo"
                .DataTextField = "RepName"
                .DataSource = (New Business.LoadSheetsController).GetAllSalesReps
                .DataBind()
            End With
        End Sub

        Private Sub BindIOOffs()
            'Private Sub BindIOOffs(ByVal sender As Object, ByVal e As System.EventArgs)

            With ddlIOOffN1
                Dim objLC As New Business.LoadSheetsController
                Dim valfld, txtfld As String
                Dim dr As IDataReader = objLC.GetAllInterOffices
                .Items.Clear()
                'If .SelectedValue <> "" Then ddlIOOffN1_SelectedIndexChanged(Nothing,Nothing)
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While
                .Items.Insert(0, (New ListItem("No Office assigned", "000000000")))
            End With

            With ddlIOOffN2
                Dim objLC As New Business.LoadSheetsController
                Dim valfld, txtfld As String
                Dim dr As IDataReader = objLC.GetAllInterOffices
                .Items.Clear()
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While
                .Items.Insert(0, (New ListItem("No Office assigned", "000000000")))
            End With
        End Sub

        Private Sub InitControls()

            cmdDelete.Visible = Not Null.IsNull(itemId)
            If cmdDelete.Visible Then
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" & Localization.GetString("DeleteItem") & "');")
            End If

            imbDelete.Visible = cmdDelete.Visible
            cmdUpdate.Visible = cmdDelete.Visible
            imbUpdate.Visible = cmdUpdate.Visible
            cmdAdd.Visible = Not cmdUpdate.Visible
            imbAdd.Visible = cmdAdd.Visible

            If Not Page.IsPostBack Then
                BindIOOffs()
                BindReps()
            End If

        End Sub

        Private Sub ItemToPage(ByVal ItemId As Integer)
            If Not Null.IsNull(ItemId) Then 'Check for the Not-Null ItemId
                Dim objLoadAcct As Business.LoadAcctInfo = (New Business.LoadAcctsController).GetLoadAcct(ItemId)
                'Check for the Not-Null objLoadAcct
                If Not objLoadAcct Is Nothing Then ItemToPage(objLoadAcct)
            End If
        End Sub

        Private Sub ItemToPage(ByVal objLoadAcct As Business.LoadAcctInfo)
            'Load objLoadAcct data to the Page
            With objLoadAcct
                'From LoadSheet
                hypLoadID.Text = .LoadID
                hypLoadID.NavigateUrl = EditUrl("ItemId", (New Business.LoadSheetsController).GetItemId(.LoadID))
                hypLoadID1.NavigateUrl = hypLoadID.NavigateUrl
                lblJRCOffComm.Text = .OfficeOverride '.JRCIOfficeCode
                lblAPcomm4.Text = Left(.JRCIOfficeCode, 7)
                lblAPcomm3.Text = .IOOffC3 '& "<br />" & .IOOffN3 'SubOffice Name & Number
                lblAPcomm2.Text = .IOOffC4 '& "<br />" & .IOOffN4 'SubOffice Name & Number
                'If lblAPcomm2.Text.Length > 7 Then
                '    lblAPcomm2.Text = lblAPcomm2.Text.Substring(0, 7) '& "<br />" & .IOOffN4 'SubOffice Name & Number
                'End If


                txtComCheckSeq.Text = .ComCheckSeq
                If Not Null.IsNull(.ComCheckAmt) Then
                    txtComCheckAmt.Text = String.Format("{0:0.00}", .ComCheckAmt)
                End If
                txtCodCheckSeq.Text = .CodCheckSeq
                If Not Null.IsNull(.CodCheckAmt) Then
                    txtCodCheckAmt.Text = String.Format("{0:0.00}", .CodCheckAmt)
                End If

                lblDriverCode.Text = .DriverCode

                lblIOCode.Text = .IOCode '.JRCIOCode
                ddleMailTo.DataSource = (New Business.LoadAcctsController).GetDispatchersByJRCIOfficeCode(.IOCode)
                ddleMailTo.DataBind()

                lblBrokerCode.Text = .BrokerCode
                lblRepNo.Text = .RepNo


                'From SalesPerson
                lblDriverName.Text = .DriverName
                If Not Null.IsNull(.CommRate) Then
                    If .CommRate > 93 Then .CommRate = 93 '% increaded from 90 to 93
                    txtCommRate.Text = .CommRate.ToString
                End If


                'From InterOffice
                chkSubOffComm.Checked = (.SubOffComm.ToUpper = "Y")
                lblIOName.Text = .IOName

                txtJRCIOOffC2.Text = .JRCIOOffC2
                txtIOOffN2.Text = .IOOffN2
                If Not Null.IsNull(.IOComm2) Then txtIOComm2.Text = String.Format("{0:0.00}", .IOComm2)

                'From Broker
                lblBrokerName.Text = .BrokerName

                'From SalesRep
                lblRepName.Text = .RepName

                If Not Null.IsNull(.BBaseLoad) Then
                    txtBBaseLoad.Text = .BBaseLoad.ToString
                End If
                If Not Null.IsNull(.DiscountPCT) Then
                    txtDiscountPCT.Text = String.Format("{0:0.00}", .DiscountPCT)
                End If
                If Not Null.IsNull(.DiscountDlr) Then
                    txtDiscountDlr.Text = String.Format("{0:0.00}", .DiscountDlr)
                End If
                If Not Null.IsNull(.BDeten) Then
                    txtBDeten.Text = String.Format("{0:0.00}", .BDeten)
                End If
                If Not Null.IsNull(.BTolls) Then
                    txtBTolls.Text = String.Format("{0:0.00}", .BTolls)
                End If
                If Not Null.IsNull(.BFuel) Then
                    txtBFuel.Text = String.Format("{0:0.00}", .BFuel)
                End If
                If Not Null.IsNull(.BDrop) Then
                    txtBDrop.Text = String.Format("{0:0.00}", .BDrop)
                End If
                If Not Null.IsNull(.BRecon) Then
                    txtBRecon.Text = String.Format("{0:0.00}", .BRecon)
                End If
                If Not Null.IsNull(.BTarp) Then
                    txtBTarp.Text = String.Format("{0:0.00}", .BTarp)
                End If
                If Not Null.IsNull(.BLumper) Then
                    txtBLumper.Text = String.Format("{0:0.00}", .BLumper)
                End If
                If Not Null.IsNull(.BUnload) Then
                    txtBUnload.Text = String.Format("{0:0.00}", .BUnload)
                End If
                If Not Null.IsNull(.BAdminMisc) Then
                    txtBAdminMisc.Text = String.Format("{0:0.00}", .BAdminMisc)
                End If
                If Not Null.IsNull(.BCustBill) Then
                    txtBCustBill.Text = String.Format("{0:0.00}", .BCustBill)
                    txtCustBill.Text = txtBCustBill.Text
                End If
                If Not Null.IsNull(.DRCommBase) Then
                    txtDRCommBase.Text = .DRCommBase.ToString
                End If
                If Not Null.IsNull(.DRRebur) Then
                    txtDRRebur.Text = .DRRebur.ToString
                End If
                If Not Null.IsNull(.DRPermits) Then
                    txtDRPermits.Text = .DRPermits.ToString
                End If
                If Not Null.IsNull(.DRTolls) Then
                    txtDRTolls.Text = .DRTolls.ToString
                End If
                If Not Null.IsNull(.DRMisc) Then
                    txtDRMisc.Text = .DRMisc.ToString
                End If
                If Not Null.IsNull(.DRTotDue) Then
                    txtDRTotDue.Text = String.Format("{0:0.00}", .DRTotDue)
                End If
                If Not Null.IsNull(.APCommTot) Then
                    txtAPCommTot.Text = String.Format("{0:0.00}", .APCommTot)
                End If
                If Not Null.IsNull(.CalcMI) Then
                    txtCalcMI.Text = .CalcMI.ToString
                End If
                If Not Null.IsNull(.CalcRate) Then
                    txtCalcRate.Text = .CalcRate.ToString
                End If
                If Not Null.IsNull(.CalcTot) Then
                    txtCalcTot.Text = .CalcTot.ToString
                End If
                If Not Null.IsNull(.JRCIOOffC1) Then
                    txtJRCIOOffC1.Text = .JRCIOOffC1
                End If

                txtIOOffC1.Text = .IOOffC1
                txtIOOffC2.Text = .IOOffC2
                txtIOOffC3.Text = .IOOffC3
                txtIOOffC4.Text = .IOOffC4
                Try
                    ddlIOOffC4.SelectedValue = .IOOffC4 '& "10"
                Catch
                End Try

                Try
                    'ddlIOOffN1.Items.Insert(0, (New ListItem("No Office assigned", "0000000")))
                    ddlIOOffN1.SelectedValue = .IOOffN1
                Catch
                End Try
                txtIOOffN1.Text = .IOOffN1
                Try
                    'ddlIOOffN2.Items.Insert(0, (New ListItem("No Office assigned", "0000000")))
                    ddlIOOffN2.SelectedValue = .IOOffN2
                Catch
                End Try

                txtIOOffN3.Text = .IOOffN3
                txtIOOffN4.Text = .IOOffN4
                If Not Null.IsNull(.IOComm1) Then
                    txtIOComm1.Text = String.Format("{0:0.00}", .IOComm1)
                End If

                If Not Null.IsNull(.IOComm3) Then
                    txtIOComm3.Text = .IOComm3.ToString
                End If
                If Not Null.IsNull(.IOComm4) Then
                    txtIOComm4.Text = String.Format("{0:0.00}", .IOComm4)
                End If
                txtIOOffL1.Text = .IOOffL1.ToUpper  'String.Format("{0:0.00}", .IOOffL1)
                txtIOOffL2.Text = .IOOffL2.ToUpper  'String.Format("{0:0.00}", .IOOffL2)
                txtIOOffL3.Text = .IOOffL3
                txtIOOffL4.Text = .IOOffL4
                If Not Null.IsNull(.IOCommTot) Then
                    txtIOCommTot.Text = String.Format("{0:0.00}", .IOCommTot)
                End If
                If Not Null.IsNull(.IOAdmin1) Then
                    txtIOAdmin1.Text = String.Format("{0:0.00}", .IOAdmin1)
                End If
                If Not Null.IsNull(.IOAdmin2) Then
                    txtIOAdmin2.Text = String.Format("{0:0.00}", .IOAdmin2)
                End If
                If Not Null.IsNull(.IOAdmin3) Then
                    txtIOAdmin3.Text = .IOAdmin3.ToString
                End If
                If Not Null.IsNull(.IOAdmin4) Then
                    txtIOAdmin4.Text = .IOAdmin4.ToString
                End If
                'tblCommissionsSplit3.Visible = (.IOAdmin3 > 0)
                'tblCommissionsSplit4.Visible = (.IOAdmin4 > 0)
                'tblCommissionsSplit.Visible = tblCommissionsSplit3.Visible OrElse tblCommissionsSplit4.Visible

                If Not Null.IsNull(.IOAdminTot) Then
                    txtIOAdminTot.Text = String.Format("{0:0.00}", .IOAdminTot)
                End If
                If Not Null.IsNull(.ExPermits) Then
                    txtExPermits.Text = .ExPermits.ToString
                End If
                If Not Null.IsNull(.ExTrailer) Then
                    txtExTrailer.Text = .ExTrailer.ToString
                End If
                If Not Null.IsNull(.ExMisc) Then
                    txtExMisc.Text = .ExMisc.ToString
                End If
                If Not Null.IsNull(.ExTot) Then
                    txtExTot.Text = String.Format("{0:0.00}", .ExTot)
                End If
                'txtAdminExempt.Text = .AdminExempt
                chkAdminExempt.Checked = (.AdminExempt.ToUpper = "Y")
                chkBKAdminExempt.Checked = chkAdminExempt.Checked
                If Not Null.IsNull(.JRCOnePct) Then
                    txtJRCOnePct.Text = String.Format("{0:0.00}", .JRCOnePct)
                End If
                If Not Null.IsNull(.JRCOffComm) Then
                    txtJRCOffComm.Text = String.Format("{0:0.00}", .JRCOffComm)
                End If
                If Not Null.IsNull(.JRCTotal) Then
                    txtJRCTotal.Text = String.Format("{0:0.00}", .JRCTotal)
                End If

                chkBINC3.Checked = (.BINC3.ToUpper = "Y")
                chkBINC4.Checked = (.BINC4.ToUpper = "Y")
                chkBINC5.Checked = (.BINC5.ToUpper = "Y")
                chkBINC6.Checked = (.BINC6.ToUpper = "Y")
                chkBINC7.Checked = (.BINC7.ToUpper = "Y")
                chkBINC8.Checked = (.BINC8.ToUpper = "Y")
                chkBINC9.Checked = (.BINC9.ToUpper = "Y")
                chkBINC10.Checked = (.BINC10.ToUpper = "Y")
                chkBINC11.Checked = (.BINC11.ToUpper = "Y")
                If Not Null.IsNull(.JRCOffPct) Then
                    txtJRCOffPct.Text = .JRCOffPct.ToString
                End If
                If Not Null.IsNull(.JRCBkrPct) Then
                    txtJRCBkrPct.Text = .JRCBkrPct.ToString
                End If
                If Not Null.IsNull(.BkrPct) Then
                    txtBkrPct.Text = .BkrPct.ToString
                End If
                If Not Null.IsNull(.BkrDlr) Then
                    txtBkrDlr.Text = String.Format("{0:0.00}", .BkrDlr)
                End If
                If Not Null.IsNull(.IODlr) Then
                    txtIODlr.Text = .IODlr.ToString
                End If
                If Not Null.IsNull(.IOPct) Then
                    txtIOPct.Text = .IOPct.ToString
                End If
                If Not Null.IsNull(.DCPCT) Then
                    txtDCPCT.Text = .DCPCT.ToString
                End If
                If Not Null.IsNull(.ONEPCT) Then
                    txtONEPCT.Text = .ONEPCT.ToString
                End If
                chkRepFixed.Checked = .RepFixed
                If .RepPct > 0 Then
                    txtRepPct.Text = String.Format("{0:0.00}", .RepPct)
                    'lblRepPct.Text = txtRepPct.Text
                End If
                If .RepDlr > 0 Then
                    txtRepDlr.Text = String.Format("{0:0.00}", .RepDlr)
                    'lblRepDlr.Text = txtRepDlr.Text

                    txtRep.Text = txtRepDlr.Text 'Update the RepDue
                End If
                If Not Null.IsNull(.DispPct) Then
                    txtDispPct.Text = .DispPct.ToString
                End If
                If Not Null.IsNull(.DispDlr) Then
                    txtDispDlr.Text = .DispDlr.ToString
                End If
                If Not Null.IsNull(.IOXPct1) Then
                    txtIOXPct1.Text = .IOXPct1.ToString
                End If
                If Not Null.IsNull(.IOXPct2) Then
                    txtIOXPct2.Text = .IOXPct2.ToString
                End If
                If Not Null.IsNull(.IOXPct3) Then
                    txtIOXPct3.Text = .IOXPct3.ToString
                End If
                If Not Null.IsNull(.IOXPct4) Then
                    txtIOXPct4.Text = .IOXPct4.ToString
                End If
                If Not Null.IsNull(.JRCAdminP) Then
                    txtJRCAdminP.Text = .JRCAdminP.ToString
                End If
                txtAPOffC1.Text = .APOffC1
                txtAPOffC2.Text = .APOffC2
                txtAPOffC3.Text = .APOffC3
                txtAPOffC4.Text = .APOffC4
                txtAPOffN1.Text = .APOffN1
                txtAPOffN2.Text = .APOffN2
                txtAPOffN3.Text = .APOffN3
                txtAPOffN4.Text = .APOffN4
                If Not Null.IsNull(.APComm1) Then
                    txtAPComm1.Text = String.Format("{0:0.00}", .APComm1)
                End If
                If Not Null.IsNull(.APComm2) Then
                    txtAPComm2.Text = String.Format("{0:0.00}", .APComm2)
                End If
                If Not Null.IsNull(.APComm3) Then
                    txtAPComm3.Text = String.Format("{0:0.00}", .APComm3)
                End If
                If Not Null.IsNull(.APComm4) Then
                    txtAPComm4.Text = String.Format("{0:0.00}", .APComm4)
                End If
                If Not Null.IsNull(.APCPct1) Then
                    txtAPCPct1.Text = .APCPct1.ToString
                End If
                If Not Null.IsNull(.APCPct2) Then
                    txtAPCPct2.Text = .APCPct2.ToString
                End If
                If Not Null.IsNull(.APCPct3) Then
                    txtAPCPct3.Text = .APCPct3.ToString
                End If
                If Not Null.IsNull(.APCPct4) Then
                    txtAPCPct4.Text = .APCPct4.ToString
                End If
                chkAllowORide.Checked = (.AllowORide.ToUpper = "Y")

                txtBType.Text = .BType
                If Not Null.IsNull(.OCommPlus) Then
                    txtOCommPlus.Text = .OCommPlus.ToString
                End If
                If Not Null.IsNull(.OCommNeg) Then
                    txtOCommNeg.Text = .OCommNeg.ToString
                End If
                If Not Null.IsNull(.AlumaPct) Then
                    txtAlumaPct.Text = .AlumaPct.ToString
                End If
                If Not Null.IsNull(.AlumaDlrDisc) Then
                    txtAlumaDlrDisc.Text = .AlumaDlrDisc.ToString
                End If
                chkBKFixed.Checked = (.BKFixed.ToUpper = "Y")
                chkOOFixed.Checked = (.BKFixed.ToUpper = "Y") 'chkBKFixed.Checked
                chkIOFixed.Checked = (.IOFixed.ToUpper = "Y")

                If Not Null.IsNull(.GPPct) Then
                    txtGPPct.Text = String.Format("{0:0.000}", .GPPct)
                End If
                txtTPName.Text = .TPName.ToString
                If Not Null.IsNull(.TPAmt) Then
                    txtTPAmt.Text = .TPAmt.ToString
                End If
                txtTPDesc.Text = .TPDesc
                If Not Null.IsNull(.TPPaidDate) Then
                    txtTPPaidDate.Text = .TPPaidDate.ToShortDateString
                End If
                txtTPCkNo.Text = .TPCkNo
                chkJRC5050.Checked = (.JRC5050.ToUpper = "Y")
                chkCalc85.Checked = (.Calc85.ToUpper = "Y")
                If Not Null.IsNull(.DvrDedPct) Then
                    txtDvrDedPct.Text = .DvrDedPct.ToString
                End If
                txtDvrDedResn.Text = .DvrDedResn


                If Not Null.IsNull(.ViewOrder) Then
                    txtViewOrder.Text = .ViewOrder.ToString
                End If

                'Audit Control
                ctlAudit.CreatedByUser = .UpdatedByUser
                ctlAudit.CreatedDate = .UpdatedDate.ToString

                'Tracking Control
                'ctlTracking.URL = .NavURL
                ctlTracking.ModuleID = .ModuleId
            End With 'objLoadAcct

            ''UnRemark Following Code for Hiding IORecovery table(s) After John's Confirmation 
            ''Hide the tblIORecovery table 
            tblIORecovery1.Visible = objLoadAcct.IsIORecoveredLoad OrElse (objLoadAcct.IOComm1 > 0) OrElse (objLoadAcct.IOAdmin1 > 0)
            tblIORecovery2.Visible = (objLoadAcct.IOComm2 > 0) OrElse (objLoadAcct.IOAdmin2 > 0)
            'Hide the IORecovery Section for IO Load, since IO Load cannot be sold to IO
            tblIORecovery.Visible = (objLoadAcct.LoadType.ToUpper <> "IO") AndAlso (tblIORecovery1.Visible OrElse tblIORecovery2.Visible)
            'tblIORecovery.Visible = objLoadAcct.IsIORecoveredLoad OrElse (objLoadAcct.IOComm1 > 0) OrElse (objLoadAcct.IOAdmin1 > 0)

            'Disable the tblIORecovery1 if no Data
            'Remark the following line since now no manual entry is permitted
            ddlIOOffN1_SelectedIndexChanged(Nothing, Nothing)
            'Hide the tblIORecovery2 if no Data           
            'chkManagementOverride.Checked = (txtJRCIOOffC2.Text <> "") OrElse (txtIOOffN2.Text <> "") OrElse (txtIOComm2.Text <> "")
            'chkManagementOverride_CheckedChanged(Nothing, Nothing)



            'Hide the Driver Dedution table if no data
            tblDriverDeduction.Visible = (objLoadAcct.DvrDedPct > 0) OrElse (objLoadAcct.OCommPlus > 0)

            'Show the RepNo Selection if no Rep
            ddlRepNo.SelectedValue = objLoadAcct.RepNo
            ddlRepNo.Visible = (objLoadAcct.RepNo = "0000000") OrElse (objLoadAcct.RepNo = "#######") OrElse (objLoadAcct.RepNo = "")
            'txtRepDlr.Visible = ddlRepNo.Visible
            'lblRepDlr.Visible = Not txtRepDlr.Visible
            'txtRepPct.Visible = ddlRepNo.Visible
            'lblRepPct.Visible = Not txtRepPct.Visible

            If ddlRepNo.Visible Then
                'With ddlRepNo
                '    .DataValueField = "RepNo"
                '    .DataTextField = "RepName"
                '    .DataSource = (New Business.LoadSheetsController).GetAllSalesReps
                '    .DataBind()
                'End With
                Try
                    ddlRepNo.SelectedValue = "0000000"
                    txtRepPct.Text = "0"
                    txtRepDlr.Text = "0.00"

                    'txtRepPct.Enabled = False
                    'txtRepDlr.Enabled = False
                    txtRepPct.ReadOnly = True
                    txtRepDlr.ReadOnly = True
                Catch
                End Try
            End If

            ''Remarked the below code and ran the CalcButton on 09 Jan 2009
            'Fill the Boxes that are not saved
            txtBase.Text = String.Format("{0:0.00}", GetDollarBase)
            If (objLoadAcct.LoadType.ToUpper = "OO") Then
                txtBaseOO.Text = String.Format("{0:0.00}", GetDollarBaseOO)
            End If

            'Hide the Accounting Table at the Bottom for the first tiem
            trAccountingSummary.Visible = (objLoadAcct.JRCOnePct > 0)
        End Sub

        Private Function PageToItem() As Business.LoadAcctInfo
            Dim objLoadAcct As New Business.LoadAcctInfo
            'Initialise the ojbLoadAcct object
            objLoadAcct = CType(CBO.InitializeObject(objLoadAcct, GetType(Business.LoadAcctInfo)), Business.LoadAcctInfo)

            'bind text values to object
            With objLoadAcct
                .ItemId = itemId
                .ModuleId = ModuleId

                'Actual Fields

                .LoadID = hypLoadID.Text
                Try
                    .BBaseLoad = Decimal.Parse(txtBBaseLoad.Text)
                Catch
                End Try
                Try
                    .DiscountPCT = Double.Parse(txtDiscountPCT.Text)
                Catch
                End Try
                Try
                    .DiscountDlr = Decimal.Parse(txtDiscountDlr.Text)
                Catch
                End Try
                Try
                    .BDeten = Double.Parse(txtBDeten.Text)
                Catch
                End Try
                Try
                    .BTolls = Double.Parse(txtBTolls.Text)
                Catch
                End Try
                Try
                    .BFuel = Double.Parse(txtBFuel.Text)
                Catch
                End Try
                Try
                    .BDrop = Double.Parse(txtBDrop.Text)
                Catch
                End Try
                Try
                    .BRecon = Double.Parse(txtBRecon.Text)
                Catch
                End Try
                Try
                    .BTarp = Double.Parse(txtBTarp.Text)
                Catch
                End Try
                Try
                    .BLumper = Double.Parse(txtBLumper.Text)
                Catch
                End Try
                Try
                    .BUnload = Double.Parse(txtBUnload.Text)
                Catch
                End Try
                Try
                    .BAdminMisc = Double.Parse(txtBAdminMisc.Text)
                Catch
                End Try
                Try
                    .BCustBill = Decimal.Parse(txtBCustBill.Text)
                Catch
                End Try
                Try
                    .DRCommBase = Decimal.Parse(txtDRCommBase.Text)
                Catch
                End Try
                Try
                    .DRRebur = Double.Parse(txtDRRebur.Text)
                Catch
                End Try
                Try
                    .DRPermits = Double.Parse(txtDRPermits.Text)
                Catch
                End Try
                Try
                    .DRTolls = Double.Parse(txtDRTolls.Text)
                Catch
                End Try
                Try
                    .DRMisc = Double.Parse(txtDRMisc.Text)
                Catch
                End Try
                Try
                    .DRTotDue = Double.Parse(txtDRTotDue.Text)
                Catch
                End Try
                Try
                    .APCommTot = Double.Parse(txtAPCommTot.Text)
                Catch
                End Try
                Try
                    .CalcMI = Double.Parse(txtCalcMI.Text)
                Catch
                End Try
                Try
                    .CalcRate = Double.Parse(txtCalcRate.Text)
                Catch
                End Try
                Try
                    .CalcTot = Decimal.Parse(txtCalcTot.Text)
                Catch
                End Try

                Try
                    .JRCIOOffC1 = txtJRCIOOffC1.Text
                Catch
                End Try
                Try
                    .JRCIOOffC2 = txtJRCIOOffC2.Text
                Catch
                End Try
                .IOOffC1 = txtIOOffC1.Text
                .IOOffC2 = txtIOOffC2.Text
                .IOOffC3 = txtIOOffC3.Text
                .IOOffC4 = ddlIOOffC4.SelectedValue 'txtIOOffC4.Text

                .IOOffN1 = ddlIOOffN1.SelectedValue 'txtIOOffN1.Text
                .IOOffN2 = txtIOOffN2.Text 'ddlIOOffN2.SelectedValue

                .IOOffN3 = txtIOOffN3.Text
                .IOOffN4 = txtIOOffN4.Text
                Try
                    .IOComm1 = Double.Parse(txtIOComm1.Text)
                Catch
                End Try
                Try
                    .IOComm2 = Double.Parse(txtIOComm2.Text)
                Catch
                End Try
                Try
                    .IOComm3 = Double.Parse(txtIOComm3.Text)
                Catch
                End Try
                Try
                    .IOComm4 = Double.Parse(txtIOComm4.Text)
                Catch
                End Try
                .IOOffL1 = txtIOOffL1.Text.ToUpper
                .IOOffL2 = txtIOOffL2.Text.ToUpper
                .IOOffL3 = txtIOOffL3.Text.ToUpper
                .IOOffL4 = txtIOOffL4.Text.ToUpper
                Try
                    .IOCommTot = Double.Parse(txtIOCommTot.Text)
                Catch
                End Try
                Try
                    .IOAdmin1 = Double.Parse(txtIOAdmin1.Text)
                Catch
                End Try
                Try
                    .IOAdmin2 = Double.Parse(txtIOAdmin2.Text)
                Catch
                End Try
                Try
                    .IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
                Catch
                End Try
                Try
                    .IOAdmin4 = Double.Parse(txtIOAdmin4.Text)
                Catch
                End Try
                Try
                    .IOAdminTot = Double.Parse(txtIOAdminTot.Text)
                Catch
                End Try
                Try
                    .ExPermits = Double.Parse(txtExPermits.Text)
                Catch
                End Try
                Try
                    .ExTrailer = Double.Parse(txtExTrailer.Text)
                Catch
                End Try
                Try
                    .ExMisc = Double.Parse(txtExMisc.Text)
                Catch
                End Try
                Try
                    .ExTot = Double.Parse(txtExTot.Text)
                Catch
                End Try
                '.AdminExempt = txtAdminExempt.Text
                If chkAdminExempt.Checked Then
                    .AdminExempt = "Y"
                Else
                    .AdminExempt = "N"
                End If
                Try
                    .JRCOnePct = Decimal.Parse(txtJRCOnePct.Text)
                Catch
                End Try
                Try
                    .JRCOffComm = Decimal.Parse(txtJRCOffComm.Text)
                Catch
                End Try
                Try
                    .JRCTotal = Decimal.Parse(txtJRCTotal.Text)
                Catch
                End Try
                If chkBINC3.Checked Then
                    .BINC3 = "Y"
                Else
                    .BINC3 = "N"
                End If
                If chkBINC4.Checked Then
                    .BINC4 = "Y"
                Else
                    .BINC4 = "N"
                End If
                If chkBINC5.Checked Then
                    .BINC5 = "Y"
                Else
                    .BINC5 = "N"
                End If
                If chkBINC6.Checked Then
                    .BINC6 = "Y"
                Else
                    .BINC6 = "N"
                End If
                If chkBINC7.Checked Then
                    .BINC7 = "Y"
                Else
                    .BINC7 = "N"
                End If
                If chkBINC8.Checked Then
                    .BINC8 = "Y"
                Else
                    .BINC8 = "N"
                End If
                If chkBINC9.Checked Then
                    .BINC9 = "Y"
                Else
                    .BINC9 = "N"
                End If

                If chkBINC10.Checked Then
                    .BINC10 = "Y"
                Else
                    .BINC10 = "N"
                End If
                If chkBINC11.Checked Then
                    .BINC11 = "Y"
                Else
                    .BINC11 = "N"
                End If

                Try
                    .JRCOffPct = Double.Parse(txtJRCOffPct.Text)
                Catch
                End Try
                Try
                    .JRCBkrPct = Double.Parse(txtJRCBkrPct.Text)
                Catch
                End Try
                Try
                    .BkrPct = Double.Parse(txtBkrPct.Text)
                Catch
                End Try
                Try
                    .BkrDlr = Double.Parse(txtBkrDlr.Text)
                Catch
                End Try
                Try
                    .IODlr = Double.Parse(txtIODlr.Text)
                Catch
                End Try
                Try
                    .IOPct = Double.Parse(txtIOPct.Text)
                Catch
                End Try
                Try
                    .DCPCT = Double.Parse(txtDCPCT.Text)
                Catch
                End Try
                Try
                    .ONEPCT = Double.Parse(txtONEPCT.Text)
                Catch
                End Try
                .RepFixed = chkRepFixed.Checked
                Try
                    .RepPct = Double.Parse(txtRepPct.Text)
                Catch
                End Try
                Try
                    .RepDlr = Double.Parse(txtRepDlr.Text)
                Catch
                End Try
                Try
                    .DispPct = Double.Parse(txtDispPct.Text)
                Catch
                End Try
                Try
                    .DispDlr = Double.Parse(txtDispDlr.Text)
                Catch
                End Try
                Try
                    .IOXPct1 = Double.Parse(txtIOXPct1.Text)
                Catch
                End Try
                Try
                    .IOXPct2 = Double.Parse(txtIOXPct2.Text)
                Catch
                End Try
                Try
                    .IOXPct3 = Double.Parse(txtIOXPct3.Text)
                Catch
                End Try
                Try
                    .IOXPct4 = Double.Parse(txtIOXPct4.Text)
                Catch
                End Try
                Try
                    .JRCAdminP = Double.Parse(txtJRCAdminP.Text)
                Catch
                End Try
                .APOffC1 = txtAPOffC1.Text
                .APOffC2 = txtAPOffC2.Text
                .APOffC3 = txtAPOffC3.Text
                .APOffC4 = txtAPOffC4.Text
                .APOffN1 = txtAPOffN1.Text
                .APOffN2 = txtAPOffN2.Text
                .APOffN3 = txtAPOffN3.Text
                .APOffN4 = txtAPOffN4.Text
                Try
                    .APComm1 = Double.Parse(txtAPComm1.Text)
                Catch
                End Try
                Try
                    .APComm2 = Double.Parse(txtAPComm2.Text)
                Catch
                End Try
                Try
                    .APComm3 = Double.Parse(txtAPComm3.Text)
                Catch
                End Try
                Try
                    .APComm4 = Double.Parse(txtAPComm4.Text)
                Catch
                End Try
                Try
                    .APCPct1 = Double.Parse(txtAPCPct1.Text)
                Catch
                End Try
                Try
                    .APCPct2 = Double.Parse(txtAPCPct2.Text)
                Catch
                End Try
                Try
                    .APCPct3 = Double.Parse(txtAPCPct3.Text)
                Catch
                End Try
                Try
                    .APCPct4 = Double.Parse(txtAPCPct4.Text)
                Catch
                End Try
                If chkAllowORide.Checked Then
                    .AllowORide = "Y"
                Else
                    .AllowORide = "N"
                End If
                .BType = txtBType.Text
                Try
                    .OCommPlus = Double.Parse(txtOCommPlus.Text)
                Catch
                End Try
                Try
                    .OCommNeg = Double.Parse(txtOCommNeg.Text)
                Catch
                End Try
                Try
                    .AlumaPct = Double.Parse(txtAlumaPct.Text)
                Catch
                End Try
                Try
                    .AlumaDlrDisc = Double.Parse(txtAlumaDlrDisc.Text)
                Catch
                End Try

                ' If .LoadType.ToUpper = "OO" Then chkBKFixed.Checked = chkOOFixed.Checked
                If tblDriver.Visible Then chkBKFixed.Checked = chkOOFixed.Checked

                If chkBKFixed.Checked Then
                    .BKFixed = "Y"
                Else
                    .BKFixed = "N"
                End If
                If chkIOFixed.Checked Then
                    .IOFixed = "Y"
                Else
                    .IOFixed = "N"
                End If

                Try
                    .GPPct = Double.Parse(txtGPPct.Text)
                Catch
                End Try
                .TPName = txtTPName.Text
                Try
                    .TPAmt = Double.Parse(txtTPAmt.Text)
                Catch
                End Try
                .TPDesc = txtTPDesc.Text
                Try
                    .TPPaidDate = Date.Parse(txtTPPaidDate.Text)
                Catch
                End Try
                .TPCkNo = txtTPCkNo.Text
                If chkJRC5050.Checked Then
                    .JRC5050 = "Y"
                Else
                    .JRC5050 = "N"
                End If
                If chkCalc85.Checked Then
                    .Calc85 = "Y"
                Else
                    .Calc85 = "N"
                End If
                Try
                    .DvrDedPct = Double.Parse(txtDvrDedPct.Text)
                Catch
                End Try
                .DvrDedResn = txtDvrDedResn.Text


                If txtViewOrder.Text <> String.Empty Then
                    Try
                        .ViewOrder = Integer.Parse(txtViewOrder.Text)
                    Catch
                    End Try
                End If

                'Audit Control
                .CreatedByUserId = UserInfo.UserID
                .UpdatedByUserId = UserInfo.UserID
            End With 'objLoadAcct

            Return objLoadAcct
        End Function

        'Private Sub SendNotification(ByVal eMail As String, Optional ByVal Name As String = "")
        '    Try
        '        If eMail <> "" Then
        '            Dim objRecipients As New ArrayList
        '            objRecipients.Add(New ListItem(eMail, Name))
        '            objRecipients.Add(New ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
        '            objRecipients.Add(New ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
        '            objRecipients.Add(New ListItem("john@mediainfocus.com", "John Hubbard"))
        '            ' create object
        '            ' Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendBulkEmail(objRecipients, "2", "HTML", PortalSettings.PortalAlias.HTTPAlias)
        '            'Dim objSendBulkEMail As  DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRecipients, "2", "HTML", PortalSettings.PortalAlias.HTTPAlias)

        '            Dim objLoadSheetsController As New Business.LoadSheetsController
        '            Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(hypLoadID.Text))
        '            ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
        '            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
        '            'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper), True)
        '            Dim ReportLink As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper)
        '            Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

        '            'With objSendBulkEMail
        '            '    .Subject = "Load Report for the Load " & objLoadSheetInfo.LoadID
        '            '    .Body &= "Please see " & .Subject & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer

        '            '    .SendMethod = "BCC"
        '            '    .SMTPServer = Convert.ToString(PortalSettings.HostSettings("SMTPServer"))
        '            '    .SMTPAuthentication = Convert.ToString(PortalSettings.HostSettings("SMTPAuthentication"))
        '            '    .SMTPUsername = Convert.ToString(PortalSettings.HostSettings("SMTPUsername"))
        '            '    .SMTPPassword = Convert.ToString(PortalSettings.HostSettings("SMTPPassword"))
        '            '    .Administrator = PortalSettings.Email
        '            '    .Heading = Localization.GetString("Heading", Me.LocalResourceFile)
        '            'End With
        '            '' send mail
        '            'If optSendAction.SelectedItem.Value = "S" Then
        '            '    objSendBulkEMail.Send()
        '            'Else    ' ansynchronous uses threading
        '            'Dim objThread As New Threading.Thread(AddressOf objSendBulkEMail.Send)
        '            'objThread.Start()
        '            'End If

        '            ' completed
        '            DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, Localization.GetString("MessageSent", Me.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
        '        Else
        '            DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, Localization.GetString("MessageNotSent", Me.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
        '        End If

        '    Catch exc As Exception    'Module failed to load
        '        ProcessModuleLoadException(Me, exc)
        '    End Try
        'End Sub
        Private Sub SendNotification(ByVal eMail As String, Optional ByVal Name As String = "", Optional ByVal SendAction As String = "S")
            Try
                ' load all user emails based on roles selected
                Dim objRoleNames As New System.Collections.Generic.List(Of String)
                'objRoleNames.Add("Administrators")

                ''Create the List of Recipients
                'Dim objRecipients As New ArrayList
                'If Name = "" Then
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, eMail))
                'Else
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, Name))
                'End If
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("john@mediainfocus.com", "John Hubbard"))

                '' load emails specified in email distribution list
                'Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                'For Each li As System.Web.UI.WebControls.ListItem In objRecipients
                '    Dim objUser As New Users.UserInfo
                '    objUser.UserID = Null.NullInteger
                '    objUser.Email = li.Text
                '    objUser.DisplayName = li.Value
                '    objUsers.Add(objUser)
                'Next
                Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                Dim objUser As New Users.UserInfo
                objUser.UserID = Null.NullInteger
                objUser.Email = eMail
                If Name = "" Then Name = eMail
                objUser.DisplayName = Name
                objUsers.Add(objUser)

                Dim objLoadSheetInfo As Business.LoadSheetInfo = (New Business.LoadSheetsController).GetLoadSheetByLoadId(hypLoadID.Text)
                'Dim ReportLink As String = EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & Request.QueryString("ItemId"), "LoadType=" & Request.QueryString("LoadType").ToUpper)
                Dim ReportLink As String = EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper)
                If ReportLink.StartsWith("/") Then ReportLink = ApplicationPath & ReportLink

                Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

                Dim Subject As String = "Load Report for the Load " & objLoadSheetInfo.LoadID
                Dim Body As String = "Please see " & Subject & "<br/><br/>" & ReportLink & "<br/><br/><hr/>" & Disclaimer

                'Create object
                Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRoleNames, objUsers, True, Subject, Body)
                objSendBulkEMail.BodyFormat = DotNetNuke.Services.Mail.MailFormat.Html
                objSendBulkEMail.Priority = DotNetNuke.Services.Mail.MailPriority.High
                objSendBulkEMail.SendingUser = Users.UserController.GetCurrentUserInfo
                objSendBulkEMail.ReplyTo = objSendBulkEMail.SendingUser
                objSendBulkEMail.AddressMethod = DotNetNuke.Services.Mail.SendTokenizedBulkEmail.AddressMethods.Send_TO

                ' send mail
                'Dim SendAction As String = "S" '"A"
                Dim strResult As String
                Dim msgResult As DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType
                If SendAction = "S" Then
                    Dim intMailsSent As Integer = objSendBulkEMail.SendMails()
                    If intMailsSent > 0 Then
                        strResult = "eMails sent to " & intMailsSent.ToString & "Recipients" 'String.Format(DotNetNuke.Services.Localization.Localization.GetString("MessagesSentCount", Me.LocalResourceFile), intMailsSent)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                    Else
                        strResult = "eMails could not be sent" 'DotNetNuke.Services.Localization.Localization.GetString("NoMessagesSent", Me.LocalResourceFile)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning
                    End If
                Else    ' ansynchronous uses threading
                    Dim objThread As New Threading.Thread(AddressOf objSendBulkEMail.Send)
                    objThread.Start()
                    strResult = "eMails are scheduled to be sent Asynchornously" 'DotNetNuke.Services.Localization.Localization.GetString("MessageSent", Me.LocalResourceFile)
                    msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                End If
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, strResult, msgResult)

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub LoadStatusForCustBill()
            Dim CustBill As Double = 0
            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Dim objLoadSheetsController As New Business.LoadSheetsController
            Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(hypLoadID.Text))

            If CustBill > 0 Then
                If objLoadSheetInfo.LoadStatus.ToUpper = "SUSPENSE" Then
                    objLoadSheetInfo.LoadStatus = "WIP"
                    objLoadSheetsController.UpdateLoadSheet(objLoadSheetInfo)
                End If
            Else
                If objLoadSheetInfo.LoadStatus.ToUpper = "WIP" Then
                    objLoadSheetInfo.LoadStatus = "SUSPENSE"
                    objLoadSheetsController.UpdateLoadSheet(objLoadSheetInfo)
                End If
            End If

        End Sub

        'Accounting Methods

#Region " Calculate Load "

        Private Sub CalcualteLoad()
            CalcualteLoad(1)
        End Sub
        Private Sub CalcualteLoad(ByVal StartAt As Integer)
            If StartAt < 1 Then
                'Calcualte MilesTotal and Base load amount 
                txtCalcTot.Text = String.Format("{0:0.00}", GetBBaseLoad())
                txtBBaseLoad.Text = txtBBaseLoad.Text
            End If
            If StartAt < 2 Then
                'Calcualte Cust Billing 
                txtBCustBill.Text = String.Format("{0:0.00}", GetCustBill())
                txtCustBill.Text = txtBCustBill.Text
            End If
            If StartAt < 3 Then
                txtIOCommTot.Text = String.Format("{0:0.00}", GetIOCommTot())
            End If
            If StartAt < 4 Then
                txtIOAdminTot.Text = String.Format("{0:0.00}", GetIOAdminTot())
            End If
            If StartAt < 5 Then
                txtExTot.Text = String.Format("{0:0.00}", GetExTot())
            End If
            If StartAt < 6 Then
                txtJRCOnePct.Text = String.Format("{0:0.00}", GetJRCOnePct())
            End If
            If StartAt < 7 Then
                txtRep.Text = String.Format("{0:0.00}", GetRep())
            End If
            If StartAt < 8 Then
                txtDRTotDue.Text = String.Format("{0:0.00}", GetDRTotDue())
            End If
            If StartAt < 9 Then
                txtAPComm4.Text = String.Format("{0:0.00}", GetAPComm4())
            End If
            If StartAt < 10 Then
                txtAPComm3.Text = String.Format("{0:0.00}", GetAPComm3())
            End If
            If StartAt < 11 Then
                txtAPComm2.Text = String.Format("{0:0.00}", GetAPComm2())
            End If
            If StartAt < 12 Then

                txtJRCOffComm.Text = String.Format("{0:0.00}", GetJRCOffComm())
            End If
            If StartAt < 13 Then
                txtJRCTotal.Text = String.Format("{0:0.00}", GetJrcTotal())
            End If
            If StartAt < 14 Then
                txtGPPct.Text = String.Format("{0:0.00}", GetGPPct())
            End If
        End Sub
        Private Function GetBBaseLoad() As Double
            'CalcualteLoad 
            Dim BBaseLoad As Double = 0

            Dim CalcMI As Double = 0
            Dim CalcRate As Double = 0

            Try
                CalcMI = Convert.ToDouble(txtCalcMI.Text)
            Catch
            End Try

            Try
                CalcRate = Convert.ToDouble(txtCalcRate.Text)
            Catch
            End Try
            BBaseLoad = CalcMI * CalcRate

            Return BBaseLoad
        End Function
        Private Function GetCustBill() As Double
            Dim CustBill As Double = 0

            Dim BBaseLoad As Double = 0
            Dim DiscountDlr As Double = 0
            Dim BDeten As Double = 0
            Dim BTolls As Double = 0
            Dim BFuel As Double = 0
            Dim BDrop As Double = 0
            Dim BRecon As Double = 0
            Dim BTarp As Double = 0
            Dim BLumper As Double = 0
            Dim BUnload As Double = 0
            Dim BAdminMisc As Double = 0

            Try
                BBaseLoad = Convert.ToDouble(txtBBaseLoad.Text)
            Catch
            End Try

            Try
                DiscountDlr = Convert.ToDouble(txtDiscountDlr.Text)
            Catch
            End Try

            Try
                If chkBINC3.Checked Then BDeten = Convert.ToDouble(txtBDeten.Text)
            Catch
            End Try

            Try
                If chkBINC4.Checked Then BTolls = Convert.ToDouble(txtBTolls.Text)
            Catch
            End Try

            Try
                If chkBINC5.Checked Then BFuel = Convert.ToDouble(txtBFuel.Text)
            Catch
            End Try

            Try
                If chkBINC6.Checked Then BDrop = Convert.ToDouble(txtBDrop.Text)
            Catch
            End Try

            Try
                If chkBINC7.Checked Then BRecon = Convert.ToDouble(txtBRecon.Text)
            Catch
            End Try

            Try
                If chkBINC8.Checked Then BTarp = Convert.ToDouble(txtBTarp.Text)
            Catch
            End Try

            Try
                If chkBINC9.Checked Then BLumper = Convert.ToDouble(txtBLumper.Text)
            Catch
            End Try

            Try
                If chkBINC10.Checked Then BUnload = Convert.ToDouble(txtBUnload.Text)
            Catch
            End Try

            Try
                If chkBINC11.Checked Then BAdminMisc = Convert.ToDouble(txtBAdminMisc.Text)
            Catch
            End Try

            CustBill = BBaseLoad - DiscountDlr + BDeten + BTolls + BFuel + BDrop + BRecon + BTarp + BLumper + BUnload + BAdminMisc

            'txtBCustBill.Text = String.Format("{0:0.00}", CustBill)
            'txtCustBill.Text = txtBCustBill.Text
            Return CustBill
        End Function
        Private Function GetIOCommTot() As Double
            Dim IOCommTot As Double = 0

            Dim IOComm1 As Double = 0
            Dim IOComm2 As Double = 0
            'Dim IOComm3 As Double = 0
            Dim IOComm4 As Double = 0

            Try
                IOComm1 = Convert.ToDouble(txtIOComm1.Text)
            Catch
            End Try

            Try
                IOComm2 = Convert.ToDouble(txtIOComm2.Text)
            Catch
            End Try

            'Try
            '    IOComm3 = Convert.ToDouble(txtIOComm3.Text)
            'Catch
            'End Try

            Try
                IOComm4 = Convert.ToDouble(txtIOComm4.Text)
            Catch
            End Try

            'IOCommTot = IOComm1 + IOComm2 + IOComm3 + IOComm4
            IOCommTot = IOComm1 + IOComm2 + IOComm4
            Return IOCommTot
        End Function
        Private Function GetIOAdminTot() As Double
            Dim IOAdminTot As Double = 0

            Dim IOAdmin1 As Double = 0
            Dim IOAdmin2 As Double = 0
            Try
                IOAdmin1 = Convert.ToDouble(txtIOAdmin1.Text)
            Catch
            End Try

            Try
                IOAdmin2 = Convert.ToDouble(txtIOAdmin2.Text)
            Catch
            End Try

            IOAdminTot = IOAdmin1 + IOAdmin2
            'txtIOAdminTot.Text = String.Format("{0:0.00}", IOAdminTot) 
            Return IOAdminTot
        End Function
        Private Function GetExTot() As Double
            Dim ExTot As Double = 0

            Dim ExPermits As Double = 0
            Dim ExTrailer As Double = 0
            Dim ExMisc As Double = 0

            Try
                ExPermits = Convert.ToDouble(txtExPermits.Text)
            Catch
            End Try
            Try
                ExTrailer = Convert.ToDouble(txtExTrailer.Text)
            Catch
            End Try
            Try
                ExMisc = Convert.ToDouble(txtExMisc.Text)
            Catch
            End Try

            ExTot = ExPermits + ExTrailer + ExMisc
            'txtExTot.Text = String.Format("{0:0.00}", ExTot) 
            Return ExTot
        End Function
        Private Function GetJRCOnePct() As Double
            Dim JRCOnePct As Double = 0

            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0

            Try
                CustBill = Convert.ToDouble(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Convert.ToDouble(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Convert.ToDouble(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Convert.ToDouble(txtExTot.Text)
            Catch
            End Try

            JRCOnePct = (CustBill - IOCommTot - IOAdminTot - ExTot) * 0.01
            'txtJRCOnePct.Text = String.Format("{0:0.00}", JRCOnePct) 

            Return JRCOnePct
        End Function
        Private Function GetRep() As Double

            Dim RepDlr As Double = 0

            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0
            Dim RepPct As Double = 0

            Try
                CustBill = Convert.ToDouble(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Convert.ToDouble(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Convert.ToDouble(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Convert.ToDouble(txtExTot.Text)
            Catch
            End Try

            Try
                RepPct = Convert.ToDouble(txtRepPct.Text)
            Catch
            End Try

            RepDlr = ((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) * RepPct / 100
            Return RepDlr

        End Function
        Private Function GetDRTotDue() As Double

            Dim DRTolls As Double = 0
            Dim DRMisc As Double = 0
            Dim DRCommBase As Double = 0

            Try
                DRTolls = Convert.ToDouble(txtDRTolls.Text)
            Catch
            End Try

            Try
                DRMisc = Convert.ToDouble(txtDRMisc.Text)
            Catch
            End Try

            Try
                DRCommBase = Convert.ToDouble(txtDRCommBase.Text)
            Catch
            End Try

            Return DRCommBase + DRTolls + DRMisc
        End Function
        Private Function GetAPComm4() As Double
            Return 0
        End Function
        Private Function GetAPComm3() As Double

            Return 0
        End Function
        Private Function GetAPComm2() As Double

            Return 0
        End Function
        Private Function GetJRCOffComm() As Double

            Dim LoadType As String = "OO"
            Try
                LoadType = ViewState("LoadType").ToString().ToUpper()
            Catch
            End Try
            Select Case LoadType
                Case "BK"
                    Return GetJRCOffCommBK()
                Case "IO"
                    Return GetJRCOffCommIO()
                Case Else '"OO" 
                    Return GetJRCOffCommOO()
            End Select
        End Function
        Private Function GetJRCOffCommOO() As Double

        End Function
        Private Function GetJRCOffCommBK() As Double

        End Function
        Private Function GetJRCOffCommIO() As Double

        End Function

        Private Function GetJrcTotal() As Double
            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0
            Dim Rep As Double = 0
            Dim DRTotDue As Double = 0
            Dim APComm4 As Double = 0
            Dim APComm3 As Double = 0
            Dim APComm2 As Double = 0
            Dim JRCOffComm As Double = 0
            Dim JRCOnePct As Double = 0
            'Dim JRCTotal As Double = 0

            'If SubOffice
            'Dim IOComm3 As Double = 0
            'Dim IOComm4 As Double = 0



            Try
                CustBill = Convert.ToDouble(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Convert.ToDouble(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Convert.ToDouble(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Convert.ToDouble(txtExTot.Text)
            Catch
            End Try

            Try
                Rep = Convert.ToDouble(txtRep.Text)
            Catch
            End Try


            Try
                DRTotDue = Convert.ToDouble(txtDRTotDue.Text)
            Catch
            End Try

            Try
                APComm4 = Convert.ToDouble(txtAPComm4.Text)
            Catch
            End Try
            Try
                APComm3 = Convert.ToDouble(txtAPComm3.Text)
            Catch
            End Try
            Try
                APComm2 = Convert.ToDouble(txtAPComm2.Text)
            Catch
            End Try

            Try
                JRCOffComm = Convert.ToDouble(txtJRCOffComm.Text)
            Catch
            End Try
            Try
                JRCOnePct = Convert.ToDouble(txtJRCOnePct.Text)
            Catch
            End Try

            Return CustBill - IOCommTot - IOAdminTot - ExTot - Rep - DRTotDue - APComm4 - APComm3 - APComm2 - JRCOffComm - JRCOnePct

        End Function
        Private Function GetGPPct() As Double
            Return 0
        End Function

#End Region


        Private Function GetBaseLoad() As Double
            Dim CalcTot As Double = 0
            Try
                CalcTot = Double.Parse(txtCalcTot.Text)
                'txtBBaseLoad.Text = String.Format("{0:0.00}", CalcTot)
            Catch
            End Try

            Try
                txtCalcRate.Text = String.Format("{0:0.00}", CalcTot / Double.Parse(txtCalcMI.Text))
            Catch
            End Try

            Return CalcTot
        End Function

        Private Function GetCustomerBill() As Double
            Dim BCustBill As Double = 0
            Try
                BCustBill = Double.Parse(txtBCustBill.Text)
                txtCustBill.Text = String.Format("{0:0.00}", BCustBill)
            Catch
            End Try
            Return BCustBill
        End Function

        Private Function GetIOComm() As Double
            Dim IOCommTot As Double = 0
            Dim IOComm1 As Double = 0
            Dim IOComm2 As Double = 0
            'Dim IOComm3 As Double = 0
            Dim IOComm4 As Double = 0

            Try
                IOComm1 = Convert.ToDouble(txtIOComm1.Text)
            Catch
            End Try

            Try
                IOComm2 = Convert.ToDouble(txtIOComm2.Text)
            Catch
            End Try

            'Try
            '    IOComm3 = Convert.ToDouble(txtIOComm3.Text)
            'Catch
            'End Try

            Try
                IOComm4 = Convert.ToDouble(txtIOComm4.Text)
            Catch
            End Try

            'IOCommTot = IOComm1 + IOComm2 + IOComm3 + IOComm4
            IOCommTot = IOComm1 + IOComm2 + IOComm4
            'txtIOCommTot.Text = String.Format("{0:0.00}", IOCommTot)
            Return IOCommTot
        End Function

        Private Function GetIOAdmin() As Double
            Dim IOAdminTot As Double = 0
            Dim IOAdmin1 As Double = 0
            Dim IOAdmin2 As Double = 0
            Try
                IOAdmin1 = Double.Parse(txtIOAdmin1.Text)
            Catch
            End Try

            Try
                IOAdmin2 = Double.Parse(txtIOAdmin2.Text)
            Catch
            End Try

            IOAdminTot = IOAdmin1 + IOAdmin2
            'txtIOAdminTot.Text = String.Format("{0:0.00}", IOAdminTot)
            Return IOAdminTot
        End Function

        Private Function GetExPermits() As Double
            Dim ExTot As Double = 0
            Dim ExPermits As Double = 0
            Dim ExTrailer As Double = 0
            Dim ExMisc As Double = 0

            Try
                ExPermits = Double.Parse(txtExPermits.Text)
            Catch
            End Try
            Try
                ExTrailer = Double.Parse(txtExTrailer.Text)
            Catch
            End Try
            Try
                ExMisc = Double.Parse(txtExMisc.Text)
            Catch
            End Try

            ExTot = ExPermits + ExTrailer + ExMisc
            'txtExTot.Text = String.Format("{0:0.00}", ExTot)
            Return ExTot
        End Function

        Private Function GetAdminPct() As Double
            Dim JRCOnePct As Double = 0

            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0

            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Double.Parse(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Double.Parse(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Double.Parse(txtExTot.Text)
            Catch
            End Try

            JRCOnePct = (CustBill - IOCommTot - IOAdminTot - ExTot) * 0.01
            'txtJRCOnePct.Text = String.Format("{0:0.00}", JRCOnePct)

            Return JRCOnePct
        End Function

        Private Function GetRepAmount() As Double
            Dim RepDlr As Double = 0
            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0
            Dim RepPct As Double = 0

            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Double.Parse(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Double.Parse(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Double.Parse(txtExTot.Text)
            Catch
            End Try

            Try
                RepPct = Double.Parse(txtRepPct.Text)
            Catch
            End Try

            RepDlr = ((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) * RepPct / 100
            'txtRepDlr.Text = String.Format("{0:0.00}", RepDlr)
            Return RepDlr
        End Function

        Private Function GetDollarBase(Optional ByVal Type As Integer = 0) As Double
            'Type=0 for Standard Office
            'Type=1 for Sub Office
            'Type=2 for JRC Office

            Dim DollarBase As Double = 0
            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0
            Dim Rep As Double = 0

            'If SubOffice
            Dim IOComm3 As Double = 0
            'Dim IOComm4 As Double = 0



            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Double.Parse(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Double.Parse(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Double.Parse(txtExTot.Text)
            Catch
            End Try

            Try
                Rep = Double.Parse(txtRep.Text)
            Catch
            End Try


            'If SubOffice
            Try
                IOComm3 = Double.Parse(txtIOComm3.Text)
            Catch
            End Try

            'Try
            '    IOComm4 = Double.Parse(txtIOComm4.Text)
            'Catch
            'End Try

            'Select Case Type
            '    Case 1
            '        DollarBase = ((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) - Rep - IOComm3

            '    Case Else '0
            '        DollarBase = ((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) - Rep '- IOComm3 - IOComm4

            'End Select

            DollarBase = ((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) - Rep '- IOComm3 - IOComm4
            'Controls.Add(objOI.Popup("Failure", "chkSubOffComm.UnChecked, " & "IOComm3=" & IOComm3.ToString & ", DollarBase=" & DollarBase.ToString))

            'Temporarily, remarked below code on 08 Jan 2009
            If chkSubOffComm.Checked Then
                'If Not tblBroker.Visible Then DollarBase = DollarBase - IOComm3 '- IOComm4
                DollarBase = DollarBase - IOComm3 '- IOComm4
                'Controls.Add(objOI.Popup("Failure", "chkSubOffComm.Checked, " & "IOComm3=" & IOComm3.ToString & ", DollarBase=" & DollarBase.ToString))
            End If

            'txtBase.Text = String.Format("{0:0.00}", DollarBase)
            Return DollarBase
        End Function

        Private Function GetDollarBaseOO() As Double
            Dim DRTolls As Double = 0
            Dim DRMisc As Double = 0

            Try
                DRTolls = Double.Parse(txtDRTolls.Text)
            Catch
            End Try

            Try
                DRMisc = Double.Parse(txtDRMisc.Text)
            Catch
            End Try

            Return GetDollarBase() - DRTolls - DRMisc
        End Function

        Private Function GetDriverCommission() As Double
            Dim CommRate As Double = 0
            Dim BaseOO As Double = 0
            Try
                CommRate = Double.Parse(txtCommRate.Text)
            Catch
            End Try
            Try
                BaseOO = Double.Parse(txtBaseOO.Text)
            Catch
            End Try

            Return BaseOO * CommRate / 100
        End Function

        Private Function GetCarrierDue() As Double
            Dim DRTolls As Double = 0
            Dim DRMisc As Double = 0
            Dim DRCommBase As Double = 0

            Try
                DRTolls = Double.Parse(txtDRTolls.Text)
            Catch
            End Try

            Try
                DRMisc = Double.Parse(txtDRMisc.Text)
            Catch
            End Try

            Try
                DRCommBase = Double.Parse(txtDRCommBase.Text)
            Catch
            End Try

            Return DRCommBase + DRTolls + DRMisc
        End Function

        Private Function GetDriverCommissionAdj() As Double
            Dim CommRate As Double = 0
            Dim BaseOO As Double = 0
            Try
                CommRate = Double.Parse(txtCommRate.Text)
            Catch
            End Try
            Try
                BaseOO = Double.Parse(txtBaseOO.Text)
            Catch
            End Try

            Return BaseOO * (87 - CommRate) / 100
        End Function

        Private Function GetDriverDeduction() As Double
            Dim DvrDedPct As Double = 0
            Dim BaseOO As Double = 0
            Try
                DvrDedPct = Double.Parse(txtDvrDedPct.Text)
            Catch
            End Try
            Try
                BaseOO = Double.Parse(txtBaseOO.Text)
            Catch
            End Try

            Return BaseOO * DvrDedPct / 100
        End Function

        Private Function GetJrcOfficeCommission() As Double
            'Select Case strLoadType
            '    Case "IO"
            '        'Return GetJrcOfficeCommissionIO()
            '    Case "BK"
            '        Return GetJrcOfficeCommissionBK()
            '    Case Else '"OO"
            '        Return GetJrcOfficeCommissionOO()
            'End Select

            Dim JRCOffPct As Double = 0
            Dim BaseOO As Double = 0
            Try
                JRCOffPct = Double.Parse(txtJRCOffPct.Text)
            Catch
            End Try
            Try
                BaseOO = Double.Parse(txtBaseOO.Text)
            Catch
            End Try

            Return BaseOO * JRCOffPct / 100
        End Function

        'Private Function GetJrcOfficeCommissionOO() As Double

        '    Dim JRCOffPct As Double = 0
        '    Dim BaseOO As Double = 0
        '    Try
        '        JRCOffPct = Double.Parse(txtJRCOffPct.Text)
        '    Catch
        '    End Try
        '    Try
        '        BaseOO = Double.Parse(txtBaseOO.Text)
        '    Catch
        '    End Try

        '    Return BaseOO * JRCOffPct / 100
        'End Function

        Private Sub SetJrcOfficeCommissionBK()

            Dim JRCBkrPct As Double = 0
            Dim BkrDlr As Double = 0
            Dim Base As Double = 0
            Try
                JRCBkrPct = Double.Parse(txtJRCBkrPct.Text)
            Catch
            End Try
            Try
                BkrDlr = Double.Parse(txtBkrDlr.Text)
            Catch
            End Try
            Try
                Base = Double.Parse(txtBase.Text)
            Catch
            End Try


            Dim IOAdmin3 As Double = 0
            Try
                IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
            Catch
            End Try
            Dim TotComm As Double = (Base - BkrDlr) * JRCBkrPct / 100
            If IOAdmin3 > 5 Then
                'split the commision with dispatcher
                'Get Dispatcher's Commission
                txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm * (100 - IOAdmin3) / 100)

                'Get Office's Commission
                txtIOComm3.Text = String.Format("{0:0.00}", TotComm * IOAdmin3 / 100)
                txtAPComm3.Text = txtIOComm3.Text 'txtIOComm3_TextChanged(Nothing,Nothing)
            Else
                'Get Dispatcher's Commission
                txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm)
            End If

            imbJrcTotal_Click(New System.Object, New System.Web.UI.ImageClickEventArgs(0, 0))
        End Sub

        'Private Sub SetJrcOfficeCommissionIO()
        '    Dim Base As Double = 0
        '    Dim IOPct As Double = 0
        '    Dim IODlr As Double = 0
        '    Dim Rep As Double = 0

        '    Try
        '        Base = Double.Parse(txtBase.Text)
        '    Catch
        '    End Try

        '    Try
        '        IOPct = Double.Parse(txtIOPct.Text)
        '    Catch
        '    End Try

        '    Try
        '        IODlr = Double.Parse(txtIODlr.Text)
        '    Catch
        '    End Try

        '    Try
        '        Rep = Double.Parse(txtRep.Text)
        '    Catch
        '    End Try


        '    Try
        '        If chkIOFixed.Checked Then
        '            If Base > 0 Then IOPct = 100 * IODlr / Base
        '        Else
        '            IODlr = Base * IOPct / 100
        '        End If
        '    Catch
        '    End Try

        '    txtIOPct.Text = String.Format("{0:0.00}", IOPct)
        '    txtIODlr.Text = String.Format("{0:0.00}", IODlr)
        '    txtNetIODlr.Text = String.Format("{0:0.00}", IODlr - Rep)
        '    txtDRTotDue.Text = txtIODlr.Text
        '    'txtDRTotDue.Text = txtNetIODlr.Text


        '    Dim IOAdmin3 As Double = 0
        '    Try
        '        IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
        '    Catch
        '    End Try
        '    Dim TotComm As Double = (Base - IODlr + Rep) ' * IOPct / 100
        '    If IOAdmin3 > 5 Then
        '        'split the commision with dispatcher
        '        'Get Dispatcher's Commission
        '        txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm * (100 - IOAdmin3) / 100)

        '        'Get Office's Commission
        '        txtIOComm3.Text = String.Format("{0:0.00}", TotComm * IOAdmin3 / 100)
        '        txtAPComm3.Text = txtIOComm3.Text 'txtIOComm3_TextChanged(Nothing,Nothing)
        '    Else
        '        'Get Dispatcher's Commission
        '        txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm)
        '    End If
        '    'txtJRCOffComm.Text = String.Format("{0:0.00}", Base - IODlr - Rep)


        '    Dim JRCTotal As Double = GetJrcTotal()
        '    If JRCTotal <> 0 Then
        '        txtJRCOffComm.Text = String.Format("{0:0.00}", Double.Parse(txtJRCOffComm.Text) + JRCTotal)
        '    End If

        '    imbJrcTotal_Click(Nothing, Nothing)
        'End Sub

        Private Sub SetJrcOfficeCommissionIO()
            Dim Base As Double = 0
            Dim IOPct As Double = 0
            Dim IODlr As Double = 0
            Dim Rep As Double = 0

            Try
                Base = Double.Parse(txtBase.Text)
            Catch
            End Try

            Try
                IOPct = Double.Parse(txtIOPct.Text)
            Catch
            End Try

            Try
                IODlr = Double.Parse(txtIODlr.Text)
            Catch
            End Try

            Try
                Rep = Double.Parse(txtRep.Text)
            Catch
            End Try


            Try
                If chkIOFixed.Checked Then
                    If Base > 0 Then IOPct = 100 * IODlr / Base
                Else
                    IODlr = Base * IOPct / 100
                End If
            Catch
            End Try

            txtIOPct.Text = String.Format("{0:0.00}", IOPct)
            txtIODlr.Text = String.Format("{0:0.00}", IODlr)
            txtNetIODlr.Text = String.Format("{0:0.00}", IODlr - Rep)
            txtDRTotDue.Text = txtIODlr.Text
            'txtDRTotDue.Text = txtNetIODlr.Text


            Dim IOAdmin3 As Double = 0
            Try
                IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
            Catch
            End Try
            Dim TotComm As Double = (Base - IODlr) ' * IOPct / 100
            If IOAdmin3 > 5 Then
                'split the commision with dispatcher
                'Get Dispatcher's Commission
                txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm * (100 - IOAdmin3) / 100)

                'Get Office's Commission
                txtIOComm3.Text = String.Format("{0:0.00}", TotComm * IOAdmin3 / 100)
                txtAPComm3.Text = txtIOComm3.Text 'txtIOComm3_TextChanged(Nothing,Nothing)
            Else
                'Get Dispatcher's Commission
                txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm)
            End If
            'txtJRCOffComm.Text = String.Format("{0:0.00}", Base - IODlr - Rep)


            Dim JRCTotal As Double = GetJrcTotal()
            If JRCTotal <> 0 Then
                txtJRCOffComm.Text = String.Format("{0:0.00}", Double.Parse(txtJRCOffComm.Text) + JRCTotal)
            End If

            imbJrcTotal_Click(Nothing, Nothing)
        End Sub
        Private Sub CustBillInfoState(Optional ByVal State As Boolean = False)
            'txtBBaseLoad.Enabled = State
            'txtDiscountPCT.Enabled = State
            'txtDiscountDlr.Enabled = State
            'txtBDeten.Enabled = State
            'txtBTolls.Enabled = State
            'txtBFuel.Enabled = State
            'txtBDrop.Enabled = State
            'txtBRecon.Enabled = State
            'txtBTarp.Enabled = State
            'txtBLumper.Enabled = State
            'txtBUnload.Enabled = State
            'txtBAdminMisc.Enabled = State
            txtBBaseLoad.ReadOnly = Not State
            txtDiscountPCT.ReadOnly = Not State
            txtDiscountDlr.ReadOnly = Not State
            txtBDeten.ReadOnly = Not State
            txtBTolls.ReadOnly = Not State
            txtBFuel.ReadOnly = Not State
            txtBDrop.ReadOnly = Not State
            txtBRecon.ReadOnly = Not State
            txtBTarp.ReadOnly = Not State
            txtBLumper.ReadOnly = Not State
            txtBUnload.ReadOnly = Not State
            txtBAdminMisc.ReadOnly = Not State

            chkBINC3.Enabled = State
            chkBINC4.Enabled = State
            chkBINC5.Enabled = State
            chkBINC6.Enabled = State
            chkBINC7.Enabled = State
            chkBINC8.Enabled = State
            chkBINC9.Enabled = State
            chkBINC10.Enabled = State
            chkBINC11.Enabled = State

            'DisableCopyLoadIcon(State)
        End Sub

        Sub DisableCopyLoadIcon(ByVal Disable As Boolean)
            ''Copy Load should not be visible for the Loads that are IORecovred
            'imbCopyLoad.Visible = State
            'lnbCopyLoad.Visible = State
            'Copy Load should not be enabled for the Loads that are IORecovred

            'Temp Enable the Icon
            Disable = True

            imbCopyLoad.Enabled = Not Disable
            lnbCopyLoad.Enabled = Not Disable
            If imbCopyLoad.Enabled Then
                imbCopyLoad.ImageUrl = ResolveUrl("~/images/icon_lists_32px.gif")
                imbCopyLoad.ToolTip = "Copy, Convert or Template this Load"
            Else
                imbCopyLoad.ImageUrl = ResolveUrl("~/images/icon_lists_32px-disabled.gif")
                imbCopyLoad.ToolTip = "Cannot Copy, Convert or Template the IORecovered Load"
            End If
            lnbCopyLoad.ToolTip = imbCopyLoad.ToolTip
        End Sub
        Private Function IsCopyLoadEnabled() As Boolean
            Dim CopyLoadEnabled As Boolean = False
            If txtIOAdmin1.Text = "" AndAlso txtIOComm1.Text = "" Then
                CopyLoadEnabled = True
            Else
                Dim IOAdmin1 As Double = 0
                Try
                    IOAdmin1 = Convert.ToDouble(txtIOAdmin1.Text)
                Catch
                End Try
                If Not (IOAdmin1 > 0) Then
                    Dim IOComm1 As Double = 0
                    Try
                        IOComm1 = Convert.ToDouble(txtIOComm1.Text)
                    Catch
                    End Try
                    If Not (IOComm1 > 0) Then
                        CopyLoadEnabled = True
                    End If
                End If
            End If
            Return CopyLoadEnabled
        End Function

        Private Function GetSubOffComm() As Double
            'Dim SubOffComm As Double = 0
            Dim DollarBase As Double = 0
            Dim CustBill As Double = 0
            Dim IOCommTot As Double = 0
            Dim IOAdminTot As Double = 0
            Dim ExTot As Double = 0
            Dim Rep As Double = 0
            Dim IOAdmin3 As Double = 0

            'If SubOffice
            'Dim IOComm3 As Double = 0
            'Dim IOComm4 As Double = 0



            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Try
                IOCommTot = Double.Parse(txtIOCommTot.Text)
            Catch
            End Try

            Try
                IOAdminTot = Double.Parse(txtIOAdminTot.Text)
            Catch
            End Try

            Try
                ExTot = Double.Parse(txtExTot.Text)
            Catch
            End Try

            Try
                Rep = Double.Parse(txtRep.Text)
            Catch
            End Try

            Try
                IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
            Catch
            End Try

            Return (((CustBill - IOCommTot - IOAdminTot - ExTot) * 0.99) - Rep) * IOAdmin3 / 100

        End Function

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
            Try
                objOI = New OptionsInfo(ModuleId)
                'If objOI.OnlyHostCanEdit Then
                '    'Dim objUC As New UserController
                '    Dim objHostUser As UserInfo = UserController.GetUser(PortalId, UserId, True)
                '    If Not objHostUser.IsSuperUser Then
                '        ' security violation attempt to access item not related to this Module
                '        'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "<a href=""" & NavigateURL() & """ title=""Click to go back"" onmouseover""window.status=this.title; return true"">Requires Host rights</a>", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                '        Response.Redirect(NavigateURL(), True)
                '    End If
                'End If


                'Dim objLoadAcctsController As New Business.LoadAcctsController
                'Dim objLoadAcct As New Business.LoadAcctInfo

                ' Determine ItemId
                If Request.Params("ItemId") Is Nothing Then
                    Dim i As Integer = -1
                    If Not Request.Params("LoadId") Is Nothing Then
                        hypLoadID.Text = Request.Params("LoadId")
                        hypLoadID.NavigateUrl = EditUrl("ItemId", (New Business.LoadSheetsController).GetItemId(hypLoadID.Text))
                        hypLoadID1.NavigateUrl = hypLoadID.NavigateUrl

                        Dim objLoadAcctsController As New Business.LoadAcctsController
                        i = objLoadAcctsController.GetLoadAcctId(Request.Params("LoadId"))

                        If i > 0 Then
                            itemId = i
                        Else
                            Dim objLoadAcct As Business.LoadAcctInfo = PageToItem()
                            objLoadAcct.LoadID = Request.Params("LoadId")
                            ''objLoadAcct.Moduleid = ModuleId

                            Dim objLoadSheetsController As New Business.LoadSheetsController
                            Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(Request.Params("LoadId")))
                            If objLoadSheetInfo.LoadType.ToUpper = "OO" Then
                                objLoadAcct.BKFixed = "N"
                            End If
                            'If .BKCommRate > 85 Then
                            '    txtDvrDedPct.Text = "0.00"
                            'Else
                            '    txtDvrDedPct.Text = .DvrDedPct
                            'End If

                            itemId = objLoadAcctsController.AddLoadAcct(objLoadAcct)
                            'itemId = objLoadAcctsController.GetLoadAcctId(Request.Params("LoadId"))
                            'itemId = Null.NullInteger()

                            'Reload the objLoadAcct for getting the setting of BkrPct
                            If objLoadSheetInfo.LoadType.ToUpper = "BK" Then
                                objLoadAcct = objLoadAcctsController.GetLoadAcct(itemId)
                                'objLoadAcct.BKFixed = Not (objLoadAcct.BkrPct > 0)
                                If objLoadAcct.BkrPct > 0 Then
                                    objLoadAcct.BKFixed = "N"
                                Else
                                    objLoadAcct.BKFixed = "Y"
                                    'chkBKFixed.Enabled = False
                                End If
                                objLoadAcctsController.UpdateLoadAcct(objLoadAcct)
                            End If

                            chkBKFixed.Checked = (objLoadAcct.BKFixed = "Y")

                        End If
                    End If
                Else
                    itemId = Int32.Parse(Request.Params("ItemId"))
                End If

                'this needs to execute always to the client script code is registred in InvokePopupCal
                'hypCalendarPublishDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate)

                InitControls()

                If Not Page.IsPostBack Then

                    If Not Null.IsNull(itemId) Then
                        Dim objLoadAcct As Business.LoadAcctInfo = (New Business.LoadAcctsController).GetLoadAcct(itemId)
                        If (Not objLoadAcct Is Nothing) AndAlso ((New Business.LoadSheetsController).GetLoadSheetByLoadId(objLoadAcct.LoadID).LoadStatus.ToUpper <> "VOIDED") Then
                            'Load data
                            ItemToPage(objLoadAcct)
                            'BindIOOffs(Nothing,Nothing)

                            'Make the appropriate table visible
                            tblDriver.Visible = objLoadAcct.LoadType.ToUpper = "OO"
                            tblBroker.Visible = objLoadAcct.LoadType.ToUpper = "BK"
                            tblInterOffice.Visible = objLoadAcct.LoadType.ToUpper = "IO"
                            'tblExclusion.Visible = Not tblInterOffice.Visible
                            tblComCheck.Visible = tblDriver.Visible
                            tblCodCheck.Visible = (objLoadAcct.CustomerStatus.ToUpper = "C")
                            tblComCod.Visible = tblComCheck.Visible OrElse tblCodCheck.Visible

                            'For IORecovery Load (objLoadAcct.IOAdminTot > 0) Disable the CustBillInfo
                            'Temporary Remarked this 
                            CustBillInfoState(Not ((objLoadAcct.IOAdmin1 > 0) OrElse (objLoadAcct.IOComm1 > 0)))
                            'DisableCopyLoadIcon(Not ((objLoadAcct.IOAdmin1 > 0) OrElse (objLoadAcct.IOComm1 > 0)))
                            DisableCopyLoadIcon(objLoadAcct.IsIORecoveredLoad)

                            lblLoadType.Text = "Load Accounting"

                            'With valJRCTotal
                            '    .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.0485))
                            '    .ControlToCompare = ""
                            '    .ErrorMessage = "JRC Total should be greater than " & .ValueToCompare & "(4.85% of Dollor Base)"
                            'End With

                            Dim strLoadType As String = objLoadAcct.LoadType.ToUpper
                            Select Case strLoadType
                                Case "OO"
                                    lblLoadType.Text &= " (Driver)"
                                    With valDRCommBase
                                        .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.93))
                                        .ControlToCompare = ""
                                        .ErrorMessage = "Driver Commision should be Less than " & .ValueToCompare & "(93% of Dollor Base)"
                                    End With

                                    'If .BKCommRate > 85 Then
                                    '    txtDvrDedPct.Text = "0.00"
                                    'Else
                                    '    txtDvrDedPct.Text = .DvrDedPct
                                    'End If

                                    chkOOFixed_CheckedChanged(Nothing, Nothing)
                                Case "IO"
                                    lblLoadType.Text &= " (Inter Office)"
                                    lblCarrierDue.Text = "I/O Office"
                                    'With valGPPct
                                    '    .ValueToCompare = "0"
                                    '    .ControlToCompare = ""
                                    '    .Operator = ValidationCompareOperator.Equal
                                    '    .ErrorMessage = "JRC Total should be zero"
                                    'End With
                                    'With valGPPct1
                                    '    .ValueToCompare = "0"
                                    '    .ControlToCompare = ""
                                    '    .Operator = ValidationCompareOperator.Equal
                                    '    .ErrorMessage = "JRC Total should be zero"
                                    'End With
                                    imbPrintConfirm.Style.Add("display", "none")
                                    lnbPrintConfirm.Style.Add("display", "none")
                                    chkIOFixed_CheckedChanged(Nothing, Nothing)
                                Case "BK"
                                    lblLoadType.Text &= " (Broker)"
                                    lblCarrierDue.Text = "Broker Due"
                                    'If objLoadAcct.BKCommRate > 0 Then
                                    '    objLoadAcct.BKFixed = "N"
                                    '    chkBKFixed.Checked = False
                                    '    'chkBKFixed.Enabled = False
                                    'End If
                                    With valBkrDlr
                                        .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.9))
                                        .ControlToCompare = ""
                                        .ErrorMessage = "Broker Commision should be Less than " & .ValueToCompare & "(90% of Dollor Base)"
                                    End With
                                    chkBKFixed_CheckedChanged(Nothing, Nothing)
                            End Select
                            'ViewState("RepNoC") = objLoadAcct.RepNoC
                            'chkRepFixed.Enabled = ((ViewState("RepNoC") <> "") OrElse (ViewState("RepNoC") <> "0000000") OrElse (ViewState("RepNoC") <> objLoadAcct.RepNo))
                            ViewState("RepNoEnabled") = (objLoadAcct.CustomerNumber <> "") AndAlso (objLoadAcct.CustomerNumber <> "0000000") AndAlso ((objLoadAcct.RepNoC = "") OrElse (objLoadAcct.RepNoC = "0000000") OrElse (objLoadAcct.RepNoC <> objLoadAcct.RepNo))
                            chkRepFixed.Checked = Not ((objLoadAcct.RepPctC > 0) AndAlso (objLoadAcct.RepDlrC < 1))
                            'chkRepFixed.Enabled = CType(ViewState("RepNoEnabled"), Boolean)
                            chkRepFixed_CheckedChanged(Nothing, Nothing)
                            trIOeMail.Visible = (strLoadType = "IO")
                            ViewState.Add("LoadType", strLoadType)

                            'Run the Calculation once
                            txtDiscountPCT_TextChanged(Nothing, Nothing)
                            'Hide the Accounting Table at the Bottom for the first tiem
                            trAccountingSummary.Visible = (objLoadAcct.JRCOnePct > 0)

                        Else ' security violation attempt to access item not related to this Module
                            Response.Redirect(NavigateURL(), True)
                        End If
                        'ElseIf Not Request.Params("LoadId") Is Nothing Then
                        '    txtLoadID.Text = Request.Params("LoadId")
                    End If
                End If
                'lblCalMsg.Text = "<br/><font color='red'>Remember to calculate every time you make a change</font>"

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub imbUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdate.Click, imbAdd.Click
            cmdUpdate_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click, cmdAdd.Click
            Try
                ' Only Update if the Entered Data is Valid
                If Page.IsValid Then
                    'Dim objLoadAcct As New Business.LoadAcctInfo
                    ''Initialise the ojbLoadAcct object
                    'objLoadAcct = CType(CBO.InitializeObject(objLoadAcct, GetType(Business.LoadAcctInfo)), Business.LoadAcctInfo)

                    'bind text values to object
                    Dim objLoadAcct As Business.LoadAcctInfo = PageToItem()


                    Dim objLoadAcctsController As New Business.LoadAcctsController
                    If Null.IsNull(itemId) Then
                        objLoadAcctsController.AddLoadAcct(objLoadAcct)
                    Else
                        objLoadAcctsController.UpdateLoadAcct(objLoadAcct)
                    End If

                    '' url tracking
                    'Dim objUrls As New UrlController
                    '' url tracking for MediaSrc
                    'With ctlMediaSrc
                    '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
                    'End With 'ctlMediaSrc
                    'With ctlNavURL
                    '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
                    'End With 'ctlNavURL

                    'If chkRepeatAdd.Checked Then
                    '    'Redirect back to the Edit Page of the Item for Add
                    '    Response.Redirect(EditUrl(), True)
                    'Else
                    '    'Redirect back to the portal home page
                    '    Response.Redirect(NavigateURL(), True)
                    'End If



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
                        Case "LOADSHEET"
                            'Redirect to the Detail Page of this Item for Viewing the details of this Item
                            Response.Redirect(hypLoadID.NavigateUrl, True)
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
                Case "LOADSHEET"
                    If Not Null.IsNull(itemId) Then
                        'Redirect to the Detail Page of this Item for Viewing the details of this Item
                        Response.Redirect(hypLoadID.NavigateUrl, True)
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
                    Dim objLoadAcctsController As New Business.LoadAcctsController
                    objLoadAcctsController.DeleteLoadAcct(itemId)
                End If

                ' Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        'Load Accounting Events
        Private Sub imbMasterCalc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMasterCalc.Click, imbMasterCalc1.Click
            cmdMasterCalc_Click(sender, New EventArgs)
        End Sub
        Private Sub cmdMasterCalc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMasterCalc.Click, cmdMasterCalc1.Click
            'txtCalcRate_TextChanged(Nothing,Nothing)
            txtDiscountPCT_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtCalcRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCalcRate.TextChanged, txtCalcMI.TextChanged
            'Dim CalcMI As Double = 0
            'Dim CalcRate As Double = 0
            ''Dim CalcTot As Double = 0
            'Try
            '    CalcMI = Double.Parse(txtCalcMI.Text)
            'Catch
            'End Try
            'Try
            '    CalcRate = Double.Parse(txtCalcRate.Text)
            'Catch
            'End Try
            ''Try
            ''    CalcTot = Double.Parse(txtCalcTot.Text)
            ''Catch
            ''End Try

            ''If tot < 0.01 Then
            Try
                Dim CalcTot As Double = Double.Parse(txtCalcMI.Text) * Double.Parse(txtCalcRate.Text)
                txtCalcTot.Text = String.Format("{0:0.00}", CalcTot)
            Catch
            End Try
            'End If
            txtCalcTot_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtCalcTot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCalcTot.TextChanged
            'txtBBaseLoad.Text = String.Format("{0:0.00}", GetBaseLoad())

            'Ripple through Code
            txtDiscountPCT_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtDiscountPCT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPCT.TextChanged, txtBBaseLoad.TextChanged
            'Show the Accounting Summary Table
            trAccountingSummary.Visible = True

            Dim BBaseLoad As Double = 0
            Dim DiscountPCT As Double = 0
            Try
                BBaseLoad = Double.Parse(txtBBaseLoad.Text)
            Catch
            End Try
            Try
                DiscountPCT = Double.Parse(txtDiscountPCT.Text)
            Catch
            End Try

            txtDiscountDlr.Text = String.Format("{0:0.00}", BBaseLoad * DiscountPCT / 100)

            'Ripple through Code
            imbCalculate_Click(Nothing, Nothing)
        End Sub

        Private Sub imbCalculate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCalculate.Click
            txtBCustBill.Text = String.Format("{0:0.00}", GetCustBill)
            txtCustBill.Text = txtBCustBill.Text

            ''Make the LoadStatus WIP/Suspense
            'LoadStatusForCustBill()

            'Calucate IOComm
            txtIOComm1_TextChanged(Nothing, Nothing)

            'Calucate IOAdmin
            txtIOAdmin1_TextChanged(Nothing, Nothing)

            'Calucate Exclusion
            txtExPermits_TextChanged(Nothing, Nothing)

            'Calculate the Admin 1%
            If chkAdminExempt.Checked Then
                txtJRCOnePct.Text = "0.00"
            Else
                txtJRCOnePct.Text = String.Format("{0:0.00}", GetAdminPct())
            End If

            'Ripple through Code
            imbBaseCalculate_Click(Nothing, Nothing)
        End Sub

        Private Sub txtIOComm1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOComm1.TextChanged, txtIOComm2.TextChanged
            txtIOCommTot.Text = String.Format("{0:0.00}", GetIOComm)
            'For IORecovery Load DisableCopyLoadIcon
            'DisableCopyLoadIcon(IsCopyLoadEnabled)
        End Sub

        Private Sub txtIOAdmin1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOAdmin1.TextChanged, txtIOAdmin2.TextChanged
            txtIOAdminTot.Text = String.Format("{0:0.00}", GetIOAdmin)
            'For IORecovery Load DisableCopyLoadIcon            
            'DisableCopyLoadIcon(IsCopyLoadEnabled)
        End Sub

        Private Sub imbExclusion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbExclusion.Click
            txtExPermits_TextChanged(sender, New System.Object)
        End Sub

        Private Sub txtExPermits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExPermits.TextChanged, txtExTrailer.TextChanged, txtExMisc.TextChanged
            txtExTot.Text = String.Format("{0:0.00}", GetExPermits)
            txtRepPct_TextChanged(Nothing, Nothing) 'Let us bypass this
            'txtRepDlr_TextChanged(Nothing,Nothing)
        End Sub

        Private Sub ddlRepNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRepNo.SelectedIndexChanged
            lblRepNo.Text = ddlRepNo.SelectedValue
            lblRepName.Text = ddlRepNo.SelectedItem.Text
            If (lblRepNo.Text = "0000000") OrElse (lblRepNo.Text = "#######") OrElse (lblRepNo.Text = "") Then
                txtRepPct.Text = "0"
                txtRepDlr.Text = "0.00"

                'txtRepPct.ReadOnly = True
                'txtRepDlr.ReadOnly = True
                chkRepFixed.Enabled = False
                'txtRepPct.Enabled = False
                'txtRepDlr.Enabled = False
                txtRepPct.ReadOnly = True
                txtRepDlr.ReadOnly = True
            Else
                'txtRepPct.ReadOnly = False
                'txtRepDlr.ReadOnly = False
                'chkRepFixed.Enabled = CType(ViewState("RepNoEnabled"), Boolean) 'True
                'txtRepPct.Enabled = chkRepFixed.Enabled 'True
                'txtRepDlr.Enabled = chkRepFixed.Enabled 'True
                chkRepFixed_CheckedChanged(Nothing, Nothing)
                Dim BCustBill As Double = 0
                Try
                    BCustBill = Double.Parse(txtBCustBill.Text)
                Catch
                End Try
                If BCustBill > 1 Then
                    With valRepDlr
                        Dim MaxRepPct As Double = 5
                        Try
                            MaxRepPct = Double.Parse(valRepPct.ValueToCompare) / 100
                        Catch
                        End Try
                        .ValueToCompare = String.Format("{0:0.00}", (BCustBill * MaxRepPct))
                        .ControlToCompare = ""
                        .ErrorMessage = "Sales Rep Commision should be Less than " & .ValueToCompare & "(" & valRepPct.ValueToCompare & "% of Customer Billing)"
                    End With
                End If
            End If
        End Sub

        Private Sub ddlIOOffN1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIOOffN1.SelectedIndexChanged
            If ddlIOOffN1.SelectedValue <> "" AndAlso ddlIOOffN1.SelectedValue <> "000000000" Then
                txtJRCIOOffC1.Text = ddlIOOffN1.SelectedValue '.Substring(0, 7)
                'txtIOOffN1.Text = ddlIOOffN1.SelectedItem.Text
            Else
                txtJRCIOOffC1.Text = ""
                'txtIOOffN1.Text = ""

                txtIOComm1.Text = ""
                txtIOAdmin1.Text = ""
                txtIOOffL1.Text = ""
            End If

            txtIOComm1.ReadOnly = (txtJRCIOOffC1.Text = "")
            txtIOAdmin1.ReadOnly = (txtJRCIOOffC1.Text = "")
            txtIOOffL1.ReadOnly = (txtJRCIOOffC1.Text = "")

            ''UnRemark below for Manual IORecovery
            'valIOOffL1.Visible = Not txtIOOffL1.ReadOnly
            'vlxReqIOOffL1.Enabled = valIOOffL1.Visible

            PopulateManagementOverride(ddlIOOffN1.SelectedValue)
        End Sub
        Private Sub PopulateManagementOverride(ByVal JRCIOfficeCode As String)
            Dim PayManagementOverride As Boolean = (JRCIOfficeCode <> "") AndAlso (JRCIOfficeCode <> "000000000")
            Dim SubOffAssigned As Boolean = True
            'tblIORecovery2.Visible = PayManagementOverride'(JRCIOfficeCode <> "") AndAlso (JRCIOfficeCode <> "000000000")
            If PayManagementOverride Then
                Dim objInterOfficesController As New InterOfficesController
                Dim O2 As InterOfficeInfo = objInterOfficesController.GetInterOffice(objInterOfficesController.GetInterOfficeId(JRCIOfficeCode))
                SubOffAssigned = (O2.SubOffComm.ToUpper = "Y") AndAlso (O2.APCodeFM <> "") AndAlso (O2.AbvrNameFM <> "")
                'If O2.SubOffComm.ToUpper = "Y" Then
                txtJRCIOOffC2.Text = O2.APCodeFM
                txtIOOffN2.Text = O2.AbvrNameFM
                'End If
            End If
            If Not PayManagementOverride Then
                txtJRCIOOffC2.Text = ""
                txtIOOffN2.Text = ""
                txtIOComm2.Text = ""

                txtIOAdmin2.Text = ""
                txtIOOffL2.Text = ""

                ddlIOOffC4.SelectedValue = ""
                txtIOOffC4.Text = ""
                txtIOOffN4.Text = ""
                txtIOComm4.Text = "0.00"
            End If

            txtJRCIOOffC2.Enabled = PayManagementOverride
            txtIOOffN2.Enabled = PayManagementOverride
            txtIOComm2.Enabled = PayManagementOverride

            txtIOAdmin2.Enabled = PayManagementOverride
            txtIOOffL2.Enabled = PayManagementOverride

            'Third Row to be enable/disabled
            ddlIOOffC4.Enabled = PayManagementOverride
            'txtIOOffN4.ReadOnly = Not PayManagementOverride
            txtIOComm4.ReadOnly = Not PayManagementOverride

            valJRCIOOffC2.Visible = PayManagementOverride AndAlso SubOffAssigned
            valIOOffN2.Visible = PayManagementOverride AndAlso SubOffAssigned
            valIOComm2.Visible = PayManagementOverride AndAlso SubOffAssigned
        End Sub
        Private Sub ddlIOOffN2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIOOffN2.SelectedIndexChanged
            If ddlIOOffN2.SelectedValue <> "" AndAlso ddlIOOffN2.SelectedValue <> "0000000" Then
                txtJRCIOOffC2.Text = ddlIOOffN2.SelectedValue.Substring(0, 7)
                txtIOOffN2.Text = ddlIOOffN2.SelectedItem.Text
            Else
                txtJRCIOOffC2.Text = ""
                txtIOOffN2.Text = ""
            End If
        End Sub

        Private Sub ddlIOOffC4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlIOOffC4.SelectedIndexChanged
            txtIOOffC4.Text = ddlIOOffC4.SelectedValue
            If ddlIOOffC4.SelectedValue <> "" Then
                If ddlIOOffC4.SelectedValue = "0008865" Then
                    txtIOOffN4.Text = "Darrell Newby" 'ddlIOOffC4.SelectedItem.Text
                Else
                    Dim objInterOfficesController As New InterOfficesController
                    'Dim O4 As InterOfficeInfo = objInterOfficesController.GetInterOffice(objInterOfficesController.GetInterOfficeId(ddlIOOffC4.SelectedValue & "10"))
                    Dim O4 As InterOfficeInfo = objInterOfficesController.GetInterOffice(objInterOfficesController.GetInterOfficeId(ddlIOOffC4.SelectedItem.Text))
                    txtIOOffN4.Text = O4.IOName
                End If
            Else
                txtIOOffN4.Text = ""
                txtIOComm4.Text = "0.00"
            End If
        End Sub

        'Private Sub chkManagementOverride_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkManagementOverride.CheckedChanged
        '    If Not chkManagementOverride.Checked Then
        '        txtJRCIOOffC2.Text = ""
        '        txtIOOffN2.Text = ""
        '        txtIOComm2.Text = ""
        '    End If
        '    tblIORecovery2.Visible = chkManagementOverride.Checked
        'End Sub

        Private Sub chkRepFixed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRepFixed.CheckedChanged
            If CType(ViewState("RepNoEnabled"), Boolean) Then
                chkRepFixed.Enabled = True
                'txtRepDlr.Enabled = chkRepFixed.Checked
                'txtRepPct.Enabled = Not chkRepFixed.Checked
                txtRepDlr.ReadOnly = Not chkRepFixed.Checked
                txtRepPct.ReadOnly = chkRepFixed.Checked
            Else
                ddlRepNo.Style.Add("display", "none")
                chkRepFixed.Enabled = False
                'txtRepDlr.Enabled = False
                'txtRepPct.Enabled = False
                txtRepDlr.ReadOnly = True
                txtRepPct.ReadOnly = True
            End If
        End Sub


        'Private Sub txtRepPct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepPct.TextChanged
        '    'If ViewState("LoadType").ToString.ToUpper <> "IO" Then
        '    '    txtRepDlr.Text = String.Format("{0:0.00}", GetRepAmount)
        '    'Else
        '    '    txtRepDlr.Text = "0.00"
        '    'End If

        '    If chkRepPct.Checked Then txtRepDlr.Text = String.Format("{0:0.00}", GetRepAmount)

        '    'If (lblRepNo.Text = "0000000") OrElse (lblRepNo.Text = "#######") OrElse (lblRepNo.Text = "") Then
        '    '    txtRepPct.Text = "0"
        '    '    txtRepDlr.Text = "0.00"
        '    'Else
        '    '    txtRepDlr.Text = String.Format("{0:0.00}", GetRepAmount)
        '    'End If


        '    txtRepDlr_TextChanged(Nothing,Nothing)
        'End Sub

        'Private Sub txtRepDlr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepDlr.TextChanged
        '    If (lblRepNo.Text = "0000000") OrElse (lblRepNo.Text = "#######") OrElse (lblRepNo.Text = "") Then
        '        txtRepPct.Text = "0"
        '        txtRepDlr.Text = "0.00"

        '        'txtRepPct.ReadOnly = True
        '        'txtRepDlr.ReadOnly = True
        '        txtRepPct.Enabled = False
        '        txtRepDlr.Enabled = False
        '    Else
        '        'txtRepPct.ReadOnly = False
        '        'txtRepDlr.ReadOnly = False
        '        txtRepPct.Enabled = True
        '        txtRepDlr.Enabled = True
        '        With valRepDlr
        '            .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.05))
        '            .ControlToCompare = ""
        '            .ErrorMessage = "Sales Rep Commision should be Less than " & .ValueToCompare & "(5% of Dollor Base)"
        '        End With
        '    End If

        Private Sub txtRepPct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepPct.TextChanged, txtRepDlr.TextChanged

            If (lblRepNo.Text = "0000000") OrElse (lblRepNo.Text = "#######") OrElse (lblRepNo.Text = "") Then
                txtRepPct.Text = "0"
                txtRepDlr.Text = "0.00"

                'txtRepPct.Enabled = False
                'txtRepDlr.Enabled = False
                txtRepPct.ReadOnly = True
                txtRepDlr.ReadOnly = True
            Else
                If chkRepFixed.Checked Then
                    Try
                        'Dim RepPct As Double = 100 * Double.Parse(txtRepDlr.Text) / (Double.Parse(txtBase.Text) + Double.Parse(txtRepDlr.Text)) 'Added RepDlr since it is subtracted for getting the $Base
                        Dim RepPct As Double = 100 * Double.Parse(txtRepDlr.Text) / (Double.Parse(txtJRCOnePct.Text) * 99) 'Added RepDlr since it is subtracted for getting the $Base
                        If RepPct > 0 Then txtRepPct.Text = String.Format("{0:0.00}", RepPct) Else txtRepPct.Text = ""
                    Catch
                        txtRepPct.Text = "0"
                    End Try
                Else
                    txtRepDlr.Text = String.Format("{0:0.00}", GetRepAmount)
                End If
                chkRepFixed_CheckedChanged(Nothing, Nothing)
                ''txtRepPct.ReadOnly = False
                ''txtRepDlr.ReadOnly = False
                'txtRepPct.Enabled = True
                'txtRepDlr.Enabled = True
                Dim BCustBill As Double = 0
                Try
                    BCustBill = Double.Parse(txtBCustBill.Text)
                Catch
                End Try
                If BCustBill > 1 Then
                    With valRepDlr
                        Dim MaxRepPct As Double = 5
                        Try
                            MaxRepPct = Double.Parse(valRepPct.ValueToCompare) / 100
                        Catch
                        End Try
                        .ValueToCompare = String.Format("{0:0.00}", (BCustBill * MaxRepPct))
                        .ControlToCompare = ""
                        .ErrorMessage = "Sales Rep Commision should be Less than " & .ValueToCompare & "(" & valRepPct.ValueToCompare & "% of Customer Billing)"
                    End With
                End If
            End If

            '    lblRepPct.Text = txtRepPct.Text
            '    lblRepDlr.Text = txtRepDlr.Text

            txtRep.Text = String.Format("{0:0.00}", Double.Parse(txtRepDlr.Text))
            imbJrcTotal_Click(Nothing, Nothing)
        End Sub

        Private Sub imbBaseCalculate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbBaseCalculate.Click
            ''First Run the Customer Billing Button
            'imbCalculate_Click(Nothing,Nothing)

            txtIOAdmin3_TextChanged(Nothing, Nothing) 'txtIOComm3.Text = String.Format("{0:0.00}", GetSubOffComm)
            txtBase.Text = String.Format("{0:0.00}", GetDollarBase)

            'If chkSubOffComm.Checked Then
            '    'Controls.Add(objOI.Popup("Failure", "chkSubOffComm.Checked, " & "IOComm3=" & txtIOComm3.Text & ", DollarBase=" & txtBase.Text))
            'Else
            '    'Controls.Add(objOI.Popup("Failure", "chkSubOffComm.UnChecked, " & "IOComm3=" & txtIOComm3.Text & ", DollarBase=" & txtBase.Text))
            'End If
            'With valJRCTotal
            '    .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.0485))
            '    .ControlToCompare = ""
            '    .ErrorMessage = "JRC Total should be greater than " & .ValueToCompare & "(4.85% of Dollor Base)"
            'End With

            'Ripple through Code
            Dim strLoadType As String = ViewState("LoadType").ToString.ToUpper
            Select Case strLoadType
                Case "OO"
                    'Change Compare Value for val
                    With valDRCommBase
                        .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.93))
                        .ControlToCompare = ""
                        .ErrorMessage = "Driver Commision should be Less than " & .ValueToCompare & "(93% of Dollor Base)"
                    End With
                    txtDRTolls_TextChanged(Nothing, Nothing)
                Case "BK"
                    'If chkBKFixed.Checked Then
                    '    txtBkrDlr_TextChanged(Nothing,Nothing)
                    'Else
                    '    txtBkrPct_TextChanged(Nothing,Nothing)
                    'End If
                    With valBkrDlr
                        .ValueToCompare = String.Format("{0:0.00}", (Double.Parse(txtBase.Text) * 0.9))
                        .ControlToCompare = ""
                        .ErrorMessage = "Broker Commision should be Less than " & .ValueToCompare & "(90% of Dollor Base)"
                    End With
                    txtBkrPct_TextChanged(Nothing, Nothing)
                Case "IO"
                    'With valGPPct
                    '    .ValueToCompare = "0"
                    '    '.ControlToCompare = ""
                    '    '.ErrorMessage = "JRC Total should be greater than " & .ValueToCompare & "(4.85% of Dollor Base)"
                    'End With
                    txtIOPct_TextChanged(Nothing, Nothing)
            End Select
        End Sub

        Private Sub txtIOAdmin3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOAdmin3.TextChanged
            Dim IOAdmin3 As Double = 0
            Try
                IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
            Catch
            End Try
            If IOAdmin3 > 5 Then
                txtIOComm3.Text = "0.00"
            Else
                txtIOComm3.Text = String.Format("{0:0.00}", GetSubOffComm)
            End If
            'txtIOComm3.Text = String.Format("{0:0.00}", GetSubOffComm)
            txtIOComm3_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtIOComm3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOComm3.TextChanged
            txtAPComm3.Text = txtIOComm3.Text
        End Sub

        'Private Sub txtIOAdmin4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOAdmin4.TextChanged
        '    Dim IOAdmin4 As Double = 0
        '    Try
        '        IOAdmin4 = Double.Parse(txtIOAdmin4.Text)
        '    Catch
        '    End Try
        '    'If IOAdmin4 > 5 Then
        '    '    txtIOComm4.Text = "0.00"
        '    'Else
        '    '    txtIOComm4.Text = String.Format("{0:0.00}", GetSubOffComm2)
        '    'End If
        '    txtIOComm4.Text = "0.00"
        '    txtIOComm4_TextChanged(Nothing,Nothing)
        'End Sub

        'Private Sub txtIOComm4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIOComm4.TextChanged
        '    txtAPComm2.Text = txtIOComm4.Text
        'End Sub

        Private Sub imbDriver_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDriver.Click
            txtDRTolls_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtDRTolls_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRTolls.TextChanged, txtDRMisc.TextChanged
            txtBaseOO.Text = String.Format("{0:0.00}", GetDollarBaseOO)
            txtBaseOO_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtBaseOO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBaseOO.TextChanged
            txtOCommPlus.Text = String.Format("{0:0.00}", GetDriverDeduction)
            txtOCommPlus_TextChanged(Nothing, Nothing)

        End Sub

        Private Sub txtOCommPlus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOCommPlus.TextChanged
            Dim CommRate As Double = 0
            Try
                CommRate = Convert.ToDouble(txtCommRate.Text)
            Catch
            End Try

            If CommRate > 85 Then
                txtOCommPlus.Text = "0.00"
            End If
            txtAPComm4.Text = txtOCommPlus.Text


            'Ripple through Code
            txtCommRate_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub chkOOFixed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOOFixed.CheckedChanged
            'txtDRCommBase.Enabled = chkOOFixed.Checked
            'txtCommRate.Enabled = Not txtDRCommBase.Enabled
            txtDRCommBase.ReadOnly = Not chkOOFixed.Checked
            txtCommRate.ReadOnly = chkOOFixed.Checked 'Not txtDRCommBase.ReadOnly
        End Sub

        Private Sub txtCommRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommRate.TextChanged, txtDRCommBase.TextChanged
            Dim CommRate As Double = 0
            Dim OCommNeg As Double = 0

            Try
                If chkOOFixed.Checked Then
                    CommRate = 100 * Double.Parse(txtDRCommBase.Text) / Double.Parse(txtBaseOO.Text)
                    txtCommRate.Text = String.Format("{0:0.00}", CommRate)
                Else
                    CommRate = Double.Parse(txtCommRate.Text)
                End If
            Catch
            End Try

            If CommRate > 93 Then '% increaded from 90 to 93
                CommRate = 93
                txtCommRate.Text = "93"
            End If

            If CommRate > 87 Then
                OCommNeg = GetDriverCommissionAdj()
                txtOCommNeg.Text = String.Format("{0:0.00}", OCommNeg)
            Else
                txtOCommNeg.Text = ""
            End If

            Dim IOAdmin3 As Double = 0
            Try
                IOAdmin3 = Double.Parse(txtIOAdmin3.Text)
            Catch
            End Try

            Dim TotComm As Double = GetJrcOfficeCommission()
            If IOAdmin3 > 5 Then
                'split the commision with dispatcher
                Dim adjTotComm As Double = TotComm + OCommNeg
                'Get Dispatcher's Commission
                'txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm * (100 - IOAdmin3) / 100) 'Check this with Eric too
                txtJRCOffComm.Text = String.Format("{0:0.00}", adjTotComm * (100 - IOAdmin3) / 100) 'As disucssed with John

                'Get Office's Commission
                txtIOComm3.Text = String.Format("{0:0.00}", adjTotComm * IOAdmin3 / 100)
                txtIOComm3_TextChanged(Nothing, Nothing)
            Else
                'Get Dispatcher's Commission
                'txtJRCOffComm.Text = String.Format("{0:0.00}", TotComm) 'Check this with Eric too
                txtJRCOffComm.Text = String.Format("{0:0.00}", OCommNeg + TotComm) 'As disucssed with John
            End If

            If Not chkOOFixed.Checked Then txtDRCommBase.Text = String.Format("{0:0.00}", GetDriverCommission)

            txtDRTotDue.Text = String.Format("{0:0.00}", GetCarrierDue)

            'Ripple through Code
            'txtDRCommBase_TextChanged(Nothing,Nothing)
            imbJrcTotal_Click(Nothing, Nothing)
        End Sub

        'Private Sub txtDRCommBase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRCommBase.TextChanged
        '    txtDRTotDue.Text = String.Format("{0:0.00}", GetCarrierDue)

        '    'Ripple through Code
        '    imbJrcTotal_Click(Nothing,Nothing)
        'End Sub

        Private Sub imbJrcTotal_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbJrcTotal.Click
            Dim JRCTotal As Double = GetJrcTotal()
            txtJRCTotal.Text = String.Format("{0:0.00}", JRCTotal)

            Dim CustBill As Double = 0
            Try
                CustBill = Double.Parse(txtCustBill.Text)
            Catch
            End Try

            Dim GPPct As Double = 0
            Try
                If CustBill > 0 Then GPPct = 100 * JRCTotal / CustBill
            Catch
            End Try
            txtGPPct.Text = String.Format("{0:0.000}", GPPct)
            Dim dGPPct As Double = Convert.ToDouble(txtGPPct.Text)
            If tblInterOffice.Visible Then
                If dGPPct = 0 Then
                    errJRCTotal.Text = ""
                Else
                    errJRCTotal.Text = "GPPct must be 0 for IO Loads"
                End If
            Else
                If dGPPct < 4.85 Then
                    errJRCTotal.Text = "GPPct (" & txtGPPct.Text & ") is less than 4.85%"
                Else
                    errJRCTotal.Text = ""
                End If
            End If
            'If (Not tblInterOffice.Visible) AndAlso (GPPct < 4.85) Then
            '    errJRCTotal.Text = "GPPct (" & txtGPPct.Text & ") is less than 4.85%"
            'Else
            '    errJRCTotal.Text = ""
            'End If
        End Sub

        'Broker Events
        Private Sub chkBKFixed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBKFixed.CheckedChanged
            'txtBkrDlr.Enabled = chkBKFixed.Checked
            'txtBkrPct.Enabled = Not txtBkrDlr.Enabled
            txtBkrDlr.ReadOnly = Not chkBKFixed.Checked
            txtBkrPct.ReadOnly = chkBKFixed.Checked 'Not txtBkrDlr.ReadOnly
        End Sub

        Private Sub txtBkrPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkrPct.TextChanged, txtBkrDlr.TextChanged
            Dim DollarBase As Double = 0
            Dim BkrPct As Double = 0
            Dim BkrDlr As Double = 0

            Try
                DollarBase = Double.Parse(txtBase.Text)
            Catch
            End Try

            Try
                BkrPct = Double.Parse(txtBkrPct.Text)
            Catch
            End Try

            Try
                BkrDlr = Double.Parse(txtBkrDlr.Text)
            Catch
            End Try

            If chkBKFixed.Checked Then
                txtBkrDlr.Text = String.Format("{0:0.00}", BkrDlr)
                If DollarBase > 0 Then
                    txtBkrPct.Text = String.Format("{0:0.00}", 100 * BkrDlr / DollarBase)
                Else
                    txtBkrPct.Text = "0.00"
                End If
            Else
                txtBkrPct.Text = String.Format("{0:0.00}", BkrPct)
                txtBkrDlr.Text = String.Format("{0:0.00}", DollarBase * BkrPct / 100)
            End If

            txtDRTotDue.Text = txtBkrDlr.Text

            SetJrcOfficeCommissionBK()

        End Sub

        'IO Events
        Private Sub txtIOPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIOPct.TextChanged
            SetJrcOfficeCommissionIO()
        End Sub

        Private Sub chkIOFixed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIOFixed.CheckedChanged
            'txtIODlr.Enabled = chkIOFixed.Checked
            'txtIOPct.Enabled = Not txtIODlr.Enabled
            txtIODlr.ReadOnly = Not chkIOFixed.Checked
            txtIOPct.ReadOnly = chkIOFixed.Checked 'Not txtIODlr.ReadOnly
        End Sub

#End Region

#Region " Icon Bar "

        Private Sub imbAbandon_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAbandon.Click
            Response.Redirect(NavigateURL())
        End Sub

        Private Function IsJrcTotalOk() As Boolean
            Dim JRCTotal As Decimal = 0
            Dim Base As Decimal = 0
            Try
                JRCTotal = Decimal.Parse(txtJRCTotal.Text)
            Catch
            End Try
            Try
                Base = Decimal.Parse(txtBase.Text)
            Catch
            End Try

            Dim strLoadType As String = (New Business.LoadAcctsController).GetLoadAcct(itemId).LoadType.ToUpper
            If strLoadType = "IO" Then
                Return (JRCTotal = 0)
            Else '"OO","BK"
                Return (JRCTotal >= (0.048 * Base))
            End If

        End Function

        Private Function GetLoadStatus(ByVal dr As IDataReader) As String

            Dim LS As String = "SUSPENSE"
            If Not dr Is Nothing Then
                dr.Read()
                LS = Convert.ToString(Null.SetNull(dr("LoadStatus"), LS)).ToUpper() '"SUSPENSE"


                If (LS <> "VOIDED") AndAlso (LS <> "COMPLETE") Then
                    Dim dtLoadDate As Date = Convert.ToDateTime(Null.SetNull(dr("LoadDate"), Null.NullDate))
                    Dim LoadType As String = "OO"
                    LoadType = Convert.ToString(Null.SetNull(dr("LoadType"), LoadType)).ToUpper()

                    Dim BBaseLoad As Decimal = 0
                    BBaseLoad = Convert.ToDecimal(Null.SetNull(dr("BBaseLoad"), BBaseLoad))

                    Dim BCustBill As Decimal = 0
                    BCustBill = Convert.ToDecimal(Null.SetNull(dr("BCustBill"), BCustBill))

                    Dim GPPct As Decimal = 0
                    Try
                        GPPct = Decimal.Parse(txtGPPct.Text)
                    Catch
                    End Try


                    Dim CustomerStatus As String = "I"
                    CustomerStatus = Convert.ToString(Null.SetNull(dr("CustomerStatus"), CustomerStatus)).ToUpper()
                    Dim BrokerStatus As String = "INACTIVE"
                    BrokerStatus = Convert.ToString(Null.SetNull(dr("BrokerStatus"), BrokerStatus)).ToUpper()
                    Dim JRCActive As String = "N"
                    JRCActive = Convert.ToString(Null.SetNull(dr("JRCActive"), JRCActive)).ToUpper()
                    Dim DriverStatus As String = "Y"
                    DriverStatus = Convert.ToString(Null.SetNull(dr("DriverStatus"), DriverStatus)).ToUpper()
                    Dim SafetyAuth As String = "HOLD"
                    SafetyAuth = Convert.ToString(Null.SetNull(dr("SafetyAuth"), SafetyAuth)).ToUpper()

                    'Dim BCustBill As Double = 0
                    'Try
                    '    BCustBill = Double.Parse(txtBCustBill.Text)
                    'Catch
                    'End Try
                    'If BCustBill > 0 Then
                    'Else
                    '    LS = "SUSPENSE"
                    'End If
                    Dim bLS As Boolean = (dtLoadDate <> Null.NullDate) AndAlso (BBaseLoad > 0) AndAlso (BCustBill > 0) AndAlso ((CustomerStatus = "A") OrElse (CustomerStatus = "C"))
                    Select Case LoadType
                        Case "BK"
                            If bLS AndAlso (GPPct >= 4.85) AndAlso (BrokerStatus = "ACTIVE") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                                LS = "WIP"
                            Else
                                LS = "SUSPENSE"
                            End If
                        Case "IO"
                            If bLS AndAlso (JRCActive = "Y") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                                LS = "WIP"
                            Else
                                LS = "SUSPENSE"
                            End If
                        Case Else '"OO"
                            If bLS AndAlso (GPPct >= 4.85) AndAlso (DriverStatus = "N") AndAlso (SafetyAuth <> "HOLD") Then 'AndAlso (ddlCustomerNumber.SelectedValue <> "000000000")
                                LS = "WIP"
                            Else
                                LS = "SUSPENSE"
                            End If
                    End Select

                End If
            End If

            Return LS
        End Function

        Private Function UpdateLoadAcct() As Business.LoadAcctInfo
            'Run the Calculate on every SAVE
            txtDiscountPCT_TextChanged(Nothing, Nothing)

            Dim objLoadAcct As New Business.LoadAcctInfo
            ' Only Update if the Entered Data is Valid
            'If Page.IsValid Then
            'Dim objLoadSheet As New LoadSheetInfo
            ''Initialise the ojbLoadSheet object
            'objLoadSheet = CType(CBO.InitializeObject(objLoadSheet, GetType(Business.LoadSheetInfo)), LoadSheetInfo)

            'bind text values to object
            objLoadAcct = PageToItem()

            Dim objLoadAcctsController As New Business.LoadAcctsController
            If Null.IsNull(itemId) Then
                itemId = objLoadAcctsController.AddLoadAcct(objLoadAcct)
                objLoadAcct.ItemId = itemId
            Else
                objLoadAcctsController.UpdateLoadAcct(objLoadAcct)
            End If

            ' url tracking
            Dim objUrls As New UrlController
            ' url tracking for MediaSrc
            'With ctlMediaSrc
            '    objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
            'End With 'ctlMediaSrc

            'Update LoadSheetInfo
            'If ddlRepNo.Visible AndAlso (ddlRepNo.SelectedValue <> "0000000") Then
            'End If
            Dim objLoadSheetsController As New Business.LoadSheetsController
            Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(hypLoadID.Text))

            If Not objLoadSheetInfo Is Nothing Then
                Try
                    objLoadSheetInfo.OverrideComm = Convert.ToDouble(txtCommRate.Text)
                Catch
                End Try
                objLoadSheetInfo.RepNo = lblRepNo.Text
                objLoadSheetInfo.RepName = lblRepName.Text

                'Make the LoadStatus WIP/Suspense
                If (objLoadAcct.BCustBill > 0) AndAlso (objLoadAcct.BBaseLoad > 0) Then
                    Dim dr As IDataReader = objLoadSheetsController.GetInfoForLoadStatus(objLoadSheetInfo.LoadID)
                    objLoadSheetInfo.LoadStatus = GetLoadStatus(dr)
                    'If Not dr Is Nothing Then
                    '    objLoadSheetInfo.LoadStatus = GetLoadStatus(dr)
                    'Else
                    '    If objLoadSheetInfo.LoadStatus.ToUpper = "SUSPENSE" Then
                    '        objLoadSheetInfo.LoadStatus = "WIP"
                    '    End If
                    'End If
                Else
                    If objLoadSheetInfo.LoadStatus.ToUpper = "WIP" Then 'need to check since we need not modify the Voided or complete load
                        objLoadSheetInfo.LoadStatus = "SUSPENSE"
                    End If
                End If

                objLoadSheetInfo.ComCheckSeq = txtComCheckSeq.Text
                Try
                    If Not String.IsNullOrEmpty(txtComCheckAmt.Text) Then objLoadSheetInfo.ComCheckAmt = txtComCheckAmt.Text
                Catch
                End Try
                objLoadSheetInfo.CodCheckSeq = txtCodCheckSeq.Text
                Try
                    If Not String.IsNullOrEmpty(txtCodCheckAmt.Text) Then objLoadSheetInfo.CodCheckAmt = Convert.ToDecimal(txtCodCheckAmt.Text)
                Catch
                End Try

                objLoadSheetsController.UpdateLoadSheet(objLoadSheetInfo)
            End If
            'End If


            'If (objLoadAcct.LoadType.ToUpper = "IO") OrElse IsJrcTotalOk() Then
            '    errJRCTotal.Text = "Update Sucess"
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Sucess", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Update Sucess", "Updated the JRC Total Succesfully", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
            'Else
            '    errJRCTotal.Text = "Update Failure: JRC Total is less than 5% of Base"
            '    DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: JRC Total is less than 5% of Base", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            '    DotNetNuke.UI.Skins.Skin.AddPageMessage(Me.Page, "Update Failure", "JRC Total is less than 5% of Base", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            'End If

            Return objLoadAcct
        End Function

        Private Sub imbUpdateLoadsheet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateLoadsheet.Click
            lnbUpdateLoadsheet_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateLoadsheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateLoadsheet.Click
            If Not IsJrcTotalOk() Then
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
                Exit Sub
            End If
            Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
            'Redirect to the Loadsheet Page of this Item for Viewing the details of this Item
            Response.Redirect(hypLoadID.NavigateUrl, True)
        End Sub

        Private Sub imbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateAddNew.Click
            lnbUpdateAddNew_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateAddNew.Click
            If IsJrcTotalOk() Then
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
                'Redirect back to the Edit Page of the Item for Add
                Response.Redirect(EditUrl(), True)
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateContinueEdit.Click, imbUpdateContinueEdit1.Click
            lnbUpdateContinueEdit_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateContinueEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateContinueEdit.Click, lnbUpdateContinueEdit1.Click
            If IsJrcTotalOk() Then
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
                'Redirect back to this same Edit Page with same ItemId to Edit & Continue
                Response.Redirect(EditUrl("LoadID", objLoadAcct.LoadID, "EditAcct"), True)
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbUpdateToList_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateToList.Click
            lnbUpdateToList_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateToList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateToList.Click
            If IsJrcTotalOk() Then
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
                'Redirect back to the portal home page
                Response.Redirect(NavigateURL(), True)
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbUpdateToViewer.Click
            lnbUpdateToViewer_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbUpdateToViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbUpdateToViewer.Click
            If IsJrcTotalOk() Then
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()
                'Redirect to the Detail Page of this Item for Viewing the details of this Item
                Response.Redirect(NavigateURL(), True)
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbCancelReload_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancelReload.Click
            lnbCancelReload_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbCancelReload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCancelReload.Click
            'Redirect back to this same Edit Page with same ItemId to Edit & Continue
            Response.Redirect(EditUrl("LoadID", hypLoadID.Text, "EditAcct"), True)
        End Sub

        Private Sub imbPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrint.Click
            lnbPrint_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrint.Click
            'Calculate before saving
            cmdMasterCalc_Click(Nothing, Nothing)

            If IsJrcTotalOk() Then
                'Update before saving
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()

                Dim objLoadSheetsController As New Business.LoadSheetsController
                Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(hypLoadID.Text))
                ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
                'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
                'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper), True)
                ResponseHelper.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper))

                ''Open Print in new Window
                'Response.Write("<script>window.open('" & EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") & "')</script>")
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintConfirm.Click
            lnbPrintConfirm_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbPrintConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbPrintConfirm.Click
            'Calculate before saving
            cmdMasterCalc_Click(Nothing, Nothing)

            If IsJrcTotalOk() Then
                'Update before saving
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()

                Dim objLoadSheetsController As New Business.LoadSheetsController
                Dim objLoadSheetInfo As Business.LoadSheetInfo = objLoadSheetsController.GetLoadSheet(objLoadSheetsController.GetItemId(hypLoadID.Text))
                ''Redirect back to this same Edit Page with same ItemId to Edit & Continue
                'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"), True)
                'Response.Redirect(EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper), True)
                'ResponseHelper.Redirect(EditUrl("ReportType", "ConfirmReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper))

                'New PDF Report
                ResponseHelper.Redirect(EditUrl("ReportType", "LoadConfirm", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "dnnprintmode=true"))

                ''Open Print in new Window
                'Response.Write("<script>window.open('" & EditUrl("ReportType", "LoadReport", "Reports", "ItemId=" & objLoadSheetInfo.ItemId.ToString, "LoadType=" & objLoadSheetInfo.LoadType.ToUpper, "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") & "')</script>")
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmail.Click, imbeMailTo.Click
            lnbEmail_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmail.Click
            'Calculate before saving
            cmdMasterCalc_Click(Nothing, Nothing)

            If IsJrcTotalOk() Then
                'Update before saving
                Dim objLoadAcct As Business.LoadAcctInfo = UpdateLoadAcct()

                Dim Dispatcher As Users.UserInfo = Users.UserController.GetUserByName(PortalId, ddleMailTo.SelectedValue)
                'ResponseHelper.Redirect("mailto:" & Dispatcher.Email & ";" & Dispatcher.Membership.Email & "&Subject=IO Load Sold&Body=The IO Load has been sold to the Office")

                SendNotification(Dispatcher.Email, ddleMailTo.SelectedValue) 'Dispatcher.DisplayName)
            Else
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "Update Failure: Please check the JRC Total", Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Private Sub imbVoidLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbVoidLoad.Click
            lnbVoidLoad_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbVoidLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbVoidLoad.Click
            Try
                'If ddlLoadStatus.Items.FindByValue("VOIDED").Selected Then
                '    lnbVoid.Text = "<br/><font size='+1' color='red'>LOAD VOIDED</font>"
                'Else
                '    ddlLoadStatus.ClearSelection()
                '    ddlLoadStatus.Items.FindByValue("VOIDED").Selected = True
                'End If
                'HideWhenLoadIsVoid()
                Dim objLSC As New Business.LoadSheetsController
                objLSC.VoidLoad(hypLoadID.Text)
                'Response.Redirect(hypLoadID.NavigateUrl, True)
                Response.Redirect(NavigateURL, True)
            Catch
            End Try
        End Sub

        Private Sub imbCopyLoad_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCopyLoad.Click
            lnbCopyLoad_Click(Nothing, Nothing)
        End Sub
        Private Sub lnbCopyLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbCopyLoad.Click
            Response.Redirect(EditUrl("FromLoadId", hypLoadID.Text, "Edit", "OType=CopyLoad"), True)
        End Sub

        'Private Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        '    cmdMasterCalc_Click(Nothing,Nothing)
        'End Sub

#End Region

    End Class 'EditAcct

End Namespace 'bhattji.Modules.LoadSheets