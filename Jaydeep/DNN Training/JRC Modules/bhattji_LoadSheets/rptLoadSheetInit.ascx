<%@ Control Language="vb" AutoEventWireup="False" CodeBehind="rptLoadSheetInit.ascx.vb" Inherits="bhattji.Modules.LoadSheets.rptLoadSheetInit" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <div id="divButtons" runat="server">
                <table>
                    <tr>
                        <td id="tdEdit" class="DisplayNone" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgEdit" ImageUrl="~/images/update_and_list.png" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /><br />
                            <asp:HyperLink ID="hypEdit" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /></td>
                        <td class="DisplayNone" align="center" valign="bottom"><asp:HyperLink ID="hypImgClose" ImageUrl="~/images/cancel_changes.png" resourcekey="Close" CssClass="CommandButton" runat="server" /><br />
                            <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" runat="server" /></td>
                        <td class="SubHead" align="center" valign="bottom"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print_this.png" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                            <asp:HyperLink ID="hypPrint" resourcekey="Print" CssClass="CommandButton" runat="server" /></td>
                            
                            
                            <td id="tdIOeMail" runat="server">
                                <table>
                                    <tr>
                                        <td nowrap class="SubHead" valign="bottom"><asp:label ID="pleMailTo" Text="eMail To" runat="server" CssClass="SubHead" /></td>
                                        <td nowrap class="Normal" valign="bottom"><asp:TextBox ID="txteMailTo" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valeMailTo" runat="server" ErrorMessage="Valid eMail required" CssClass="NormalRed" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txteMailTo" /></td>
                                        <td nowrap class="Normal" valign="bottom"><asp:ImageButton ID="imbeMailTo" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('Are you Sure ?')" /></td>
                                    </tr>
                                </table>
                            </td>
                    </tr>
                </table>
                <br />
                <br />
                <Portal:Audit ID="ctlAudit" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <table width="600" border="0" cellspacing="0" cellpadding="2">
                <tr>
                    <td><h1><asp:Label ID="lblReportHeading" CssClass="Head" runat="server" Text="Load Sheet" /></h1>
                    </td>
                    <td colspan="3"><asp:Label ID="lblOOMsg" CssClass="SubHead" runat="server" /></td>
                </tr>
                <tr>
                    <td>Load Date :</td>
                    <td><asp:Label ID="lblLoadDate" CssClass="SubHead" runat="server" /></td>
                    <td>JRCIOffice Code :</td>
                    <td><asp:Label ID="lblJRCIOfficeCode" CssClass="SubHead" runat="server" /></td>
                </tr>
            </table>
            <table width="700" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td width="39%" valign="top">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0" class="style2">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="height: 42px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                                <tr>
                                                                    <td align="center" bgcolor="#000000" class="style1">BILL TO</td>
                                                                    <td><asp:Label ID="lblCustomerNumber" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                            </table>
                                                            <asp:Label ID="lblCustomer" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table1" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Payments :</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td><strong>Pro/Job</strong></td>
                                                        <td><asp:Label ID="lblProJob" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>Cust P/O#</strong></td>
                                                        <td><asp:Label ID="lblCustPO" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>Carrier Paid in $$</strong></td>
                                                        <td><asp:Label ID="lblOffOrgin" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>Office Paid in $$</strong></td>
                                                        <td><asp:Label ID="lblOffFunds" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="38%" valign="top">
                                    <table id="tblDriver" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td align="center" bgcolor="#000000" class="style1">Driver</td>
                                                        <td><asp:Label ID="lblDriverCode" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" runat="server" border="1" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td width="45%"><strong>Driver Name</strong></td>
                                                        <td width="55%"><asp:Label ID="lblDriverName" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr id="trAdminExempt" runat="server">
                                                        <td>Admin Exempt</td>
                                                        <td>
                                                            <asp:Image ID="imgAdminExempt" runat="server" ImageUrl="~/images/FileManager/files/OK.gif" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="tblIOffice" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td align="center" bgcolor="#000000" class="style1">IO Code</td>
                                                        <td><asp:Label ID="lblJRCIOCode" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="1" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td width="45%"><strong>Inter Office</strong></td>
                                                        <td width="55%"><asp:Label ID="lblIOName" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="tblBroker" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" runat="server" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td align="center" bgcolor="#000000" class="style1">Broker</td>
                                                        <td><asp:Label ID="lblBrokerCode" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td width="45%"><strong>Broker Name</strong></td>
                                                        <td width="55%"><asp:Label ID="lblBrokerName" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="45%">Broker Driver</td>
                                                        <td width="55%"><asp:Label ID="lblBrokerDriver" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td align="center" bgcolor="#000000" class="style1">Trailer</td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td>Trailer No</td>
                                                        <td><asp:Label ID="lblTrailerNumber" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Total Load Miles</td>
                                                        <td><asp:Label ID="lblLoadMI" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Trailer Type</td>
                                                        <td><asp:Label ID="lblTrailerType" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Trailer Due</td>
                                                        <td><asp:Label ID="lblTrailerDue" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td>Container1</td>
                                                        <td><asp:Label ID="lblContainer1" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Container1Due</td>
                                                        <td><asp:Label ID="lblContainer1Due" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Container2</td>
                                                        <td><asp:Label ID="lblContainer2" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Container2Due</td>
                                                        <td><asp:Label ID="lblContainer2Due" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1" align="right">LoadId</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3" align="right"><asp:Label ID="lblLoadId" CssClass="Head" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Tarp Message</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3"><asp:Label ID="lblTarpMessage" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="50%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Load Notes</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3"><asp:Label ID="lblLoadNotes" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Special Customer Instructions</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3"><asp:Label ID="lblSpCustInst" CssClass="SubHead" runat="server" /></td>
                                                        <td><asp:Label ID="lblInvComment" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="29%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Customer Billing</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="2" class="style3">
                                                                <tr>
                                                                    <td width="16%" height="20">
                                                                        <div align="center">
                                                                            <strong>Show</strong></div>
                                                                    </td>
                                                                    <td nowrap><strong>Acct #</strong> </td>
                                                                    <td nowrap></td>
                                                                    <td nowrap align="right"><strong>$ Amt</strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td><asp:Label ID="lblLoadAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>BaseLoad</td>
                                                                    <td align="right"><asp:Label ID="lblBBaseLoad" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td><asp:Label ID="lblDiscAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Discount</td>
                                                                    <td align="right"><asp:Label ID="lblDiscountDlr" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC3" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblDetenAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Detension</td>
                                                                    <td align="right"><asp:Label ID="lblBDeten" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC4" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblTollsAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Tolls</td>
                                                                    <td align="right"><asp:Label ID="lblBTolls" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC5" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblFuelAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Fuel</td>
                                                                    <td align="right"><asp:Label ID="lblBFuel" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC6" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblDropAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Drop</td>
                                                                    <td align="right"><asp:Label ID="lblBDrop" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC7" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblReconAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Recon</td>
                                                                    <td align="right"><asp:Label ID="lblBRecon" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC8" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblTarpAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Tarp</td>
                                                                    <td align="right"><asp:Label ID="lblBTarp" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC9" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblLumperAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Lumper</td>
                                                                    <td align="right"><asp:Label ID="lblBLumper" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC10" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblUnloadAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Unload</td>
                                                                    <td align="right"><asp:Label ID="lblBUnload" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><asp:Label ID="lblBINC11" runat="server" CssClass="SubHead" /></td>
                                                                    <td><asp:Label ID="lblAdminMiscAcct" runat="server" CssClass="SubHead" /></td>
                                                                    <td>Misc</td>
                                                                    <td align="right"><asp:Label ID="lblBAdminMisc" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td><asp:Label ID="LabelBCustBill" Text="Total" runat="server" CssClass="SubHead" /></td>
                                                                    <td align="right"><asp:Label ID="lblBCustBill" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Miles & Rates</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                    <tr>
                                                        <td width="34%"><strong>Miles</strong></td>
                                                        <td width="66%"><asp:Label ID="lblCalcMI" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>Rate</strong></td>
                                                        <td><asp:Label ID="lblCalcRate" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>Total</strong></td>
                                                        <td><asp:Label ID="lblCalcTot" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="display: none" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Special Invoice Comments</td>
                                                    </tr>
                                                    <tr>
                                                        <%--<td>
                                                            <asp:Label ID="lblInvComment" runat="server" CssClass="SubHead" /></td>--%>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td width="38%" valign="top" rowspan="2"  valign="top">
                                                <table id="tblDriverPayables" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Driver Payables</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                                <tr>
                                                                    <td><strong>Tolls</strong></td>
                                                                    <td><asp:Label ID="lblDRTolls" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Misc</strong></td>
                                                                    <td><asp:Label ID="lblDRMisc" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Comm %</strong></td>
                                                                    <td><asp:Label ID="lblCommRate" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Comm $</strong></td>
                                                                    <td><asp:Label ID="lblDRCommBase" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Driver A/c#</strong></td>
                                                                    <td><asp:Label ID="lblDriverAcct" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="tblIOPayables" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">IO Payables</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                                <tr>
                                                                    <td><strong>IO Payable</strong></td>
                                                                    <td><asp:Label ID="lblIODlr" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="tblBrokerPayables" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Broker Payables</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                                <tr>
                                                                    <td><strong>A/P Code</strong></td>
                                                                    <td><asp:Label ID="lblProNox" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Payment</strong></td>
                                                                    <td><asp:Label ID="lblPDAmt" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Comm %</strong></td>
                                                                    <td><asp:Label ID="lblOverrideComm" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Comm $</strong></td>
                                                                    <td><asp:Label ID="lblBkrDlr" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="32%" valign="top">
                                                <table width="100%" border="1" cellpadding="2" cellspacing="2" class="style3">
                                                    <tr>
                                                        <td colspan="2" bgcolor="#000000" class="style1">Com Check</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                                <tr>
                                                                    <td><strong>ComCheck#</strong></td>
                                                                    <td><asp:Label ID="lblComCheckSeq" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>ComCheck$</strong></td>
                                                                    <td><asp:Label ID="lblComCheckAmt" CssClass="SubHead" runat="server" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="30%" valign="top">
                                                <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Exclusions</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                                <tr>
                                                                    <td><strong>Permits</strong></td>
                                                                    <td><asp:Label ID="lblExPermits" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Trailer</strong></td>
                                                                    <td><asp:Label ID="lblExTrailer" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Misc</strong></td>
                                                                    <td><asp:Label ID="lblExMisc" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="2" valign="top">
                                        <table id="tblXmission" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">Xmission</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                                <tr>
                                                                    <td><strong>Xmission File</strong></td>
                                                                    <td><asp:Label ID="lblXmissionFile" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Xmission Date</strong></td>
                                                                    <td><asp:Label ID="lblXmissionDate" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                        </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td id="tdIoCommission" runat="server" bgcolor="#000000" class="style1">I/O Commissions</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                    <tr>
                                                        <td><strong>Office</strong></td>
                                                        <td></td>
                                                        <td align="right"><strong>$ Amt</strong></td>
                                                        <td align="right"><strong>Admin</strong></td>
                                                        <td><strong>Load #</strong></td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td nowrap><asp:Label ID="lblJRCIOOffC1" runat="server" CssClass="SubHead" /></td>
                                                        <td nowrap><asp:Label ID="lblIOOffN1" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOComm1" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOAdmin1" runat="server" CssClass="SubHead" /></td>
                                                        <td><asp:Label ID="lblIOOffL1" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    <tr id="trHeading2" runat="server">
                                                        <td colspan="5" bgcolor="#000000" class="style1">Suboffice / Mgt Override</td>
                                                    </tr>
                                                    <tr id="trSubHeading2" runat="server">
                                                        <td><strong>Office</strong></td>
                                                        <td></td>
                                                        <td align="right"><strong>$ Amt</strong></td>
                                                        <td align="right"><strong></strong></td>
                                                        <td><strong></strong></td>
                                                    </tr>
                                                    <tr id="trLine1" runat="server">
                                                        <td nowrap><asp:Label ID="lblJRCIOOffC2" runat="server" CssClass="SubHead" /></td>
                                                        <td nowrap><asp:Label ID="lblIOOffN2" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOComm2" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOAdmin2" runat="server" CssClass="SubHead" /></td>
                                                        <td><asp:Label ID="lblIOOffL2" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap><asp:Label ID="lblIOOffC4" runat="server" CssClass="SubHead" /></td>
                                                        <td nowrap><asp:Label ID="lblIOOffN4" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOComm4" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOAdmin4" runat="server" CssClass="SubHead" /></td>
                                                        <td><asp:Label ID="lblIOOffL4" runat="server" CssClass="SubHead" /></td>
                                                    </tr>                                                    
                                                    <%--<tr>
                                                        <td nowrap><asp:Label ID="lblIOOffC3" runat="server" CssClass="SubHead" /></td>
                                                        <td nowrap><asp:Label ID="lblIOOffN3" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOComm3" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblIOAdmin3" runat="server" CssClass="SubHead" /></td>
                                                        <td><asp:Label ID="lblIOOffL3" runat="server" CssClass="SubHead" /></td>
                                                    </tr>
                                                    --%>
                                                    <%--
                                                    <tr id="trLineMgr" runat="server">
                                                        <td nowrap><asp:Label ID="lblManagerOverrideAccount" runat="server" CssClass="SubHead" /></td>
                                                        <td nowrap><asp:Label ID="lblManagerOverride" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"><asp:Label ID="lblJRCOffCommM" runat="server" CssClass="SubHead" /></td>
                                                        <td align="right"></td>
                                                        <td></td>
                                                    </tr>
                                                    --%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Sales Rep</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                    <tr>
                                                        <td><asp:Label ID="lblRepNo" CssClass="SubHead" runat="server" /> <asp:Label ID="lblRepName" CssClass="SubHead" runat="server" /></td>
                                                        <td><asp:Label ID="lblRepOverriden" CssClass="NormalRed" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Dispatcher</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style3">
                                                    <tr>
                                                        <td><asp:Label ID="lblDispatchCode" CssClass="SubHead" runat="server" /> <asp:Label ID="lblDispName" CssClass="SubHead" runat="server" /></td>
                                                        <td><asp:Label ID="lblAdjustJrcTotal" CssClass="NormalRed" runat="server" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="21%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1">FINANCIAL BREAKDOWN</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="2" class="style3">
                                                                <tr>
                                                                    <td nowrap><strong>Customer $</strong> </td>
                                                                    <td align="right"><asp:Label ID="lblCustBill" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="tdSalesRepDollors" runat="server" nowrap><strong>Sales Reps</strong> </td>
                                                                    <td align="right"><asp:Label ID="lblRep" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="tdIOCommDollors" runat="server" nowrap><strong>I/O Comm $</strong></td>
                                                                    <td align="right"><asp:Label ID="lblIOCommTot" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="tdIOAdminDollors" runat="server" nowrap><strong>I/O Admin $</strong></td>
                                                                    <td align="right"><asp:Label ID="lblIOAdminTot" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Exclusions</strong></td>
                                                                    <td align="right"><asp:Label ID="lblExTot" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Driver Payables</strong></td>
                                                                    <td align="right"><asp:Label ID="lblDRTotDue" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>
                                                                        <asp:Literal ID="ltrOCommPlus" runat="server" /><br />
                                                                        <asp:Literal ID="ltrAPComm4" runat="server" /></strong></td>
                                                                    <td align="right"><asp:Label ID="lblOCommPlus" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong></strong></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Com Splits<br />
                                                                        <asp:Literal ID="ltrAPComm3" runat="server" /></strong></td>
                                                                    <td align="right"><asp:Label ID="lblAPComm3" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong></strong></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Office Comm$<br />
                                                                        <asp:Literal ID="ltrJRCOffComm" runat="server" /></strong></td>
                                                                    <td align="right"><asp:Label ID="lblJRCOffComm" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong></strong></td>
                                                                    <td align="right"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><strong>Office Comm<br />
                                                                        Adjustment</strong></td>
                                                                    <td align="right"><asp:Label ID="lblOCommNeg" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="2" class="style3">
                                                                <tr>
                                                                    <td width="55%">
                                                                        <div align="right">
                                                                            <strong>1% admin</strong>
                                                                        </div>
                                                                    </td>
                                                                    <td width="45%" align="right"><asp:Label ID="lblJRCOnePct" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right">
                                                                            <strong>JRC Total</strong>
                                                                        </div>
                                                                    </td>
                                                                    <td align="right"><asp:Label ID="lblJRCTotal" runat="server" CssClass="SubHead" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="50%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1"> Load Pickups</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gdvLoadPUs" DataSourceID="odsLoadPUs" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="Horizontal" Width="100%" EmptyDataText="<center class='NormalRed'>No Data Defined</center>">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="<nobr>Name & Address</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%--<nobr><asp:Label ID="lblPUCity" runat="server" CssClass="Normal" Text='<%# Eval("PUCity") %>' />/<asp:Label ID="lblPUState" runat="server" CssClass="Normal" Text='<%# Eval("PUState") %>' />/<asp:Label ID="lblZipCode" runat="server" CssClass="Normal" Text='<%# Eval("ZipCode") %>' /></nobr>--%>
                                                                            <asp:Literal ID="ltrAditional1" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<nobr>Pickup Details</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%--
                                                                            <asp:Label ID="lblPUDate" runat="server" Text='<%# Eval("PUDate", "{0:d}") %>' CssClass="Normal" />
                                                                            <asp:Label ID="lblPUTime" runat="server" Text='<%# Eval("PUTime", "{0:t}") %>' CssClass="Normal" />
                                                                            <nobr><asp:Label ID="lblPUDate" runat="server" CssClass="Normal" /> <asp:Label ID="lblPUTime" runat="server" CssClass="Normal" /></nobr>
                                                                            --%>
                                                                            <asp:Literal ID="ltrAditional2" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                                                                <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                <EmptyDataTemplate>
                                                                    <p class="NormalRed" align="center">No Load-Pickup Defined</p>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="odsLoadPUs" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadPUInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadPUsController" SelectMethod="GetLoadPUByLoadId">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="LoadID" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" valign="top">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td bgcolor="#000000" class="style1"> Load Drops</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gdvLoadDrops" DataSourceID="odsLoadDrops" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="Horizontal" Width="100%" EmptyDataText="<center class='NormalRed'>No Data Defined</center>">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="<nobr>Name & Address</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%--<nobr><asp:Label ID="lblDPCity" runat="server" CssClass="Normal" Text='<%# Eval("DPCity") %>' />/<asp:Label ID="lblDPState" runat="server" CssClass="Normal" Text='<%# Eval("DPState") %>' />/<asp:Label ID="lblZipCode" runat="server" CssClass="Normal" Text='<%# Eval("ZipCode") %>' /></nobr>--%>
                                                                            <asp:Literal ID="ltrAditional1" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="<nobr>Drop Details</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%--
                                                                            <asp:Label ID="lblDPDate" runat="server" Text='<%# Eval("DPDate", "{0:d}") %>' CssClass="Normal" />
                                                                            <asp:Label ID="lblStime" runat="server" Text='<%# Eval("Stime", "{0:t}") %>' CssClass="Normal" />
                                                                            <asp:Label ID="lblEtime" runat="server" Text='<%# Eval("Etime", "{0:t}") %>' CssClass="Normal" />
                                                                            <nobr><asp:Label ID="lblDPDate" runat="server" CssClass="Normal" /> <asp:Label ID="lblStime" runat="server" CssClass="Normal" /> <asp:Label ID="lblEtime" runat="server" CssClass="Normal" /></nobr>
                                                                            --%>
                                                                            <asp:Literal ID="ltrAditional2" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                                                                <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                                <EmptyDataTemplate>
                                                                    <p class="NormalRed" align="center">No Load-Drop Defined</p>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="odsLoadDrops" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadDropInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadDropsController" SelectMethod="GetLoadDropByLoadId">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="LoadID" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
