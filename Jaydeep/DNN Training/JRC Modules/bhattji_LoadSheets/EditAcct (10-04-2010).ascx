<%@ Control Language="VB" AutoEventWireup="False" CodeBehind="EditAcct.ascx.vb" Inherits="bhattji.Modules.LoadSheets.EditAcct" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<script type="text/javascript">
function ClientValidate4char(source, clientside_arguments)
{
//    if (clientside_arguments.Value.length  == 4)
//        {clientside_arguments.IsValid=true;}
//    else
//        {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 4);        
}
function ClientValidate7char(source, clientside_arguments)
{
//    if (clientside_arguments.Value.length  == 7)
//        {clientside_arguments.IsValid=true;}
//    else
//        {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 7);
}
function ClientValidate9char(source, clientside_arguments)
{
//    if (clientside_arguments.Value.length  == 9)
//        {clientside_arguments.IsValid=true;}
//    else
//        {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 9);
}
</script>
<asp:UpdateProgress ID="uprEditAccts" runat="server">
    <progresstemplate>
    <table width="100%" class="UpdateProgressClass"><tr><td></td></tr></table>
        <center style="position:absolute;width:100%;height:1000px;vertical-align:middle;z-index:2000;"><asp:Image ID="imgUpdateProgress" ImageUrl="~/images/under_construction.gif" runat="server" Width="200" /><br /><asp:Image ID="Image5" ImageUrl="~/images/progressbar.gif" runat="server" Width="200" /></center>
    </progresstemplate>
</asp:UpdateProgress>
<div id="menucenterloadedit">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="loadeditnav2">
        <tr>
            <td><img src="/images/superior_16.gif" /></td>
            <td width="100%" background="/images/superior_17.gif">
                <table width="750" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="70" align="center" valign="top" class="DisplayNone">
                            <asp:ImageButton ID="imbMasterCalc" ImageUrl="~/images/update_accounting.png" resourcekey="Calculate" BorderStyle="none" CausesValidation="False" runat="server" /></td>
                        <td width="71" align="center" valign="middle" class="DisplayNone"><asp:LinkButton ID="cmdMasterCalc" resourcekey="Calculate" BorderStyle="none" CausesValidation="False" runat="server" /></td>
                        <td valign="middle" class="menu32"><asp:LinkButton ID="lnbHome" Text="Home" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbHome" ImageUrl="~/images/home.png" resourcekey="lnbHome" BorderStyle="none" runat="server" /></td>
                        
                        <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbPUDrops" Text="PU Drops" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td width="32"><asp:ImageButton ID="imbPUDrops" ImageUrl="~/images/PUDrops.gif" resourcekey="lnbPUDrops" BorderStyle="none" runat="server" /></td>
                            
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:LinkButton ID="lnbUpdateLoadsheet" Text="Load Edit" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbUpdateLoadsheet" ImageUrl="~/images/update_to_load.png" resourcekey="update_to_accounting" BorderStyle="none" runat="server" AlternateText="Save, then go to loadsheet" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle" class="topikons"><asp:LinkButton ID="lnbUpdateAddNew" Text="Add Load" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbUpdateAddNew" ImageUrl="~/images/update_and_add.png" resourcekey="update_and_add" BorderStyle="none" runat="server" AlternateText="Save, then add new" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:LinkButton ID="lnbUpdateToList" Text="View Loads" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbUpdateToList" ImageUrl="~/images/update_and_list.png" resourcekey="update_and_list" BorderStyle="none" runat="server" AlternateText="Save, then bring back to list" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:LinkButton ID="lnbPrint" resourcekey="print_this" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbPrint" ImageUrl="~/images/print_this.png" resourcekey="print_this" BorderStyle="none" runat="server" AlternateText="Print Confirm" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:LinkButton ID="lnbPrintConfirm" resourcekey="print_Confirm" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                        <td width="16"><asp:ImageButton ID="imbPrintConfirm" ImageUrl="~/images/print_this.png" resourcekey="print_Confirm" BorderStyle="none" runat="server" AlternateText="Print Loadsheet" /></td>
                        <td class="DisplayNone menu32" valign="middle"><asp:LinkButton ID="lnbEmail" Text="eMail" CssClass="topikons" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" /></td>
                        <td class="DisplayNone menu32"><asp:ImageButton ID="imbEmail" ImageUrl="~/images/email_this.png" resourcekey="email_this" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" AlternateText="Email this load" /></td>
                        <td class="DisplayNone" align="center" valign="middle" width="16"><asp:LinkButton ID="lnbCopyLoad" Text="Copy" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" ToolTip="Copy, Convert or Template this Load" /></td>
                        <td class="DisplayNone menu32"><asp:ImageButton ID="imbCopyLoad" ImageUrl="~/images/icon_lists_32px.gif" ToolTip="Copy, Convert or Template this Load" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" AlternateText="Make a copy of this load" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:LinkButton ID="lnbVoidLoad" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CssClass="topikons" BorderStyle="none" CausesValidation="false" Text="Void" /></td>
                        <td class="menu32"><asp:ImageButton ID="imbVoidLoad" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" BorderStyle="none" CausesValidation="false" ImageUrl="~/images/void_load.png" resourcekey="void_load" AlternateText="Void this load" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" style="display: none" valign="middle"><asp:LinkButton ID="lnbCancelReload" runat="server" CssClass="topikons" BorderStyle="none" CausesValidation="false" Text="Undo" /></td>
                        <td class="menu32" style="display: none"><asp:ImageButton ID="imbCancelReload" runat="server" BorderStyle="none" CausesValidation="false" ImageUrl="~/images/cancel_changes.png" resourcekey="cancel_changes" AlternateText="Undo changes" /></td>
                        <td class="menu32" valign="middle"><asp:HyperLink ID="hypAbortText" runat="server" NavigateUrl="~/Default.aspx?tabname=View Loads" CssClass="topikons" BorderStyle="none" Text="Abort" Style="text-decoration: none" ToolTip="Abort and go back to ViewLoads" /></td>
                        <td class="menu32"><asp:HyperLink ID="hypAbort" runat="server" NavigateUrl="~/Default.aspx?tabname=View Loads" BorderStyle="none" ImageUrl="~/images/cancel_changes.png" ToolTip="Abort and go back to ViewLoads" /></td>
                        <td class="menu10" valign="top"><img src="/images/superior_21.gif" width="2" /></td>
                        <td class="menu32" valign="middle"><asp:Label ID="lblIsPrinted" runat="server" CssClass="topikons" Text="Printed?" /></td>
                        <td class="menu32">
                            <asp:Image ID="imgIsPrinted" CssClass="Normal" runat="server" resourcekey="imgIsPrinted" /></td>
                    </tr>
                    <tr id="trIOeMail" runat="server">
                        <td colspan="30" align="right"></td>
                    </tr>
                </table>
            <td><img src="/images/superior_24.gif" /></td>
        </tr>
    </table>
</div>
<asp:Panel ID="pnlBhattji" runat="server" Style="position: relative;">
    <center>
        <table>
            <tr>
                <td valign="top">
                    <table class="boxdisplay">
                        <tr>
                            <td style="text-align: left" class="jrctitletext">&nbsp; Customer Billing &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="320">
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBBaseLoad" resourcekey="plBBaseLoad" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBBaseLoad" CssClass="custbilldol" runat="server" Columns="8" /><act:FilteredTextBoxExtender ID="fteBBaseLoad" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBBaseLoad" ValidChars="+-." />
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblDiscountPCT" resourcekey="plDiscountPCT" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtDiscountPCT" CssClass="custbilldol" runat="server" Columns="1" /> &nbsp;<act:FilteredTextBoxExtender ID="fteDiscountPCT" runat="server" FilterType="Numbers, Custom" TargetControlID="txtDiscountPCT" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtDiscountDlr" CssClass="custbilldol" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteDiscountDlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtDiscountDlr" ValidChars="+-." />
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBDeten" resourcekey="plBDeten" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBDeten" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBDeten" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBDeten" ValidChars="+-." />
                                    <asp:CheckBox ID="chkBINC3" resourcekey="chkBINC3" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBTolls" resourcekey="plBTolls" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBTolls" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBTolls" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBTolls" ValidChars="+-." />
                                    <asp:CheckBox ID="chkBINC4" resourcekey="chkBINC4" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBFuel" resourcekey="plBFuel" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBFuel" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBFuel" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBFuel" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC5" resourcekey="chkBINC5" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBDrop" resourcekey="plBDrop" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBDrop" CssClass="custbilldol" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteBDrop" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBDrop" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC6" resourcekey="chkBINC6" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBRecon" resourcekey="plBRecon" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBRecon" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBRecon" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBRecon" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC7" resourcekey="chkBINC7" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBTarp" resourcekey="plBTarp" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBTarp" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBTarp" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBTarp" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC8" resourcekey="chkBINC8" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBLumper" resourcekey="plBLumper" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBLumper" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBLumper" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBLumper" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC9" resourcekey="chkBINC9" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBUnload" resourcekey="plBUnload" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBUnload" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBUnload" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBUnload" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC10" resourcekey="chkBINC10" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBAdminMisc" resourcekey="plBAdminMisc" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBAdminMisc" CssClass="custbilldol" runat="server" Columns="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBAdminMisc" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBAdminMisc" ValidChars="+-.">
                                    </act:FilteredTextBoxExtender>
                                    <asp:CheckBox ID="chkBINC11" resourcekey="chkBINC11" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                </div>
                                <div class="SubHead nowrap-l">
                                    <asp:Label ID="lblBCustBill" resourcekey="plBCustBill" CssClass="custbilldol" runat="server"></asp:Label></div>
                                <div class="nowrap">
                                    <asp:TextBox ID="txtBCustBill" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" runat="server" Columns="13" ReadOnly="True" />&nbsp;<asp:ImageButton ID="imbCalculate" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 235px">
                                    <caption class="jrctitletext">
                                        <table>
                                            <tr>
                                                <td style="width: 80px" class="jrctitletext">&nbsp; Exclusion &nbsp;</td>
                                                <td style="width: 50px"><asp:Label ID="lblExPermits" CssClass="fixed" Text="Permits" runat="server"></asp:Label></td>
                                                <td style="width: 50px"><asp:Label ID="lblExTrailer" CssClass="fixed" Text="Trailer" runat="server"></asp:Label></td>
                                                <td style="width: 50px"><asp:Label ID="lblExMisc" CssClass="fixed" Text="Misc" runat="server"></asp:Label></td>
                                    </caption>
                        </tr>
                    </table>
                    <tr>
                        <td><asp:Label ID="lblExAmount" CssClass="SubHead" Text="$ Amount" runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="txtExPermits" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteExPermits" runat="server" FilterType="Numbers, Custom" TargetControlID="txtExPermits" ValidChars="+-." />
                        </td>
                        <td><asp:TextBox ID="txtExTrailer" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteExTrailer" runat="server" FilterType="Numbers, Custom" TargetControlID="txtExTrailer" ValidChars="+-." />
                        </td>
                        <td><asp:TextBox ID="txtExMisc" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteExMisc" runat="server" FilterType="Numbers, Custom" TargetControlID="txtExMisc" ValidChars="+-." />
                            <asp:ImageButton ID="imbExclusion" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                        </td>
                    </tr>
        </table>
        <table> <tr> 
        <td valign="top" align="center" style="width: 330px">
            <table id="tblIORecovery" runat="server" class="boxdisplay" width="255">
                <tr>
                    <td style="text-align: left" class="jrctitletext">&nbsp; Inter Office &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table id="tblIORecovery1" runat="server" style="width: 255px">
                            <tr>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlIOOffN1" CssClass="NormalTextBox" Enabled="false" runat="server" Columns="24" AutoPostBack="true" />
                                    <asp:TextBox ID="txtIOOffN1" CssClass="NormalBold" ReadOnly="true" runat="server" Style="display: none" Columns="24" /></td>
                                <td><asp:Label ID="txtJRCIOOffC1" CssClass="NormalBold" runat="server" /><asp:Label ID="txtIoRecoveryCode" CssClass="NormalBold" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblAmount" CssClass="NormalBold" runat="server">$ Amt</asp:Label></td>
                                <td><asp:Label ID="lblAdmin" CssClass="NormalBold" runat="server">Admin</asp:Label></td>
                                <td><asp:Label ID="lblOffLoad" CssClass="NormalBold" runat="server">Off Load</asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtIOComm1" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" Enabled="false" ReadOnly="True" /><act:FilteredTextBoxExtender ID="fteIOComm1" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOComm1" ValidChars="+-." />
                                </td>
                                <td><asp:TextBox ID="txtIOAdmin1" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" ReadOnly="True" /><act:FilteredTextBoxExtender ID="fteIOAdmin1" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOAdmin1" ValidChars="+-." />
                                </td>
                                <td><asp:TextBox ID="txtIOOffL1" CssClass="NormalTextBox" runat="server" Columns="7" MaxLength="7" ReadOnly="True" /><act:FilteredTextBoxExtender ID="fteIOOffL1" runat="server" FilterType="Numbers, LowercaseLetters, UppercaseLetters" TargetControlID="txtIOOffL1" />
                                    <asp:CustomValidator ID="cvIOOffL1" runat="server" ErrorMessage="<b>Error !!!</b><br />IO OffLoad Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIOOffL1" Display="None" /><act:ValidatorCalloutExtender ID="vlxIOOffL1" runat="Server" TargetControlID="cvIOOffL1" WarningIconImageUrl="~/images/red-error.gif" />
                                    <asp:RequiredFieldValidator ID="valIOOffL1" ControlToValidate="txtIOOffL1" Display="None" runat="server" ErrorMessage="<b>Required</b><br>IO OffLoad Must be 7 characters" /><act:ValidatorCalloutExtender ID="vlxReqIOOffL1" runat="Server" TargetControlID="valIOOffL1" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                            </tr>
                        </table>
                        <table id="tblIORecovery2" runat="server" style="width: 255px">
                            <tr style="display: none">
                                <td colspan="3"><asp:Label ID="lblManagementOverride" runat="server" Text="Pay Management Override" CssClass="SubHead" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="plJRCIOOffC2" CssClass="NormalBold" runat="server">Account</asp:Label></td>
                                <td><asp:Label ID="plIOOffN2" CssClass="NormalBold" runat="server">Name</asp:Label></td>
                                <td><asp:Label ID="plIOComm2" CssClass="NormalBold" runat="server">$ Amt</asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtJRCIOOffC2" CssClass="NormalTextBox ReadOnlyTextBox" ReadOnly="true" runat="server" Columns="7" MaxLength="9" /><act:FilteredTextBoxExtender ID="fteJRCIOOffC2" runat="server" FilterType="Numbers" TargetControlID="txtJRCIOOffC2" />
                                    <asp:RequiredFieldValidator ID="valJRCIOOffC2" ControlToValidate="txtJRCIOOffC2" runat="server" ErrorMessage="Account is Required" Display="None" /><act:ValidatorCalloutExtender ID="vlxJRCIOOffC2" runat="Server" TargetControlID="valJRCIOOffC2" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                                <td><asp:TextBox ID="txtIOOffN2" CssClass="NormalTextBox ReadOnlyTextBox" ReadOnly="true" runat="server" Columns="16" /><asp:RequiredFieldValidator ID="valIOOffN2" ControlToValidate="txtIOOffN2" runat="server" ErrorMessage="Account Name is Required" Display="None" /><act:ValidatorCalloutExtender ID="vlxIOOffN2" runat="Server" TargetControlID="valIOOffN2" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                                <td><asp:TextBox ID="txtIOComm2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /><act:FilteredTextBoxExtender ID="fteIOComm2" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOComm2" ValidChars="+-." />
                                    <asp:RequiredFieldValidator ID="valIOComm2" ControlToValidate="txtIOComm2" runat="server" ErrorMessage="$ Amount is Required" Display="None" /><act:ValidatorCalloutExtender ID="vlxIOComm2" runat="Server" TargetControlID="valIOComm2" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlIOOffN2" CssClass="NormalTextBox" runat="server" Columns="24" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td><asp:Label ID="lblAdmin2" CssClass="NormalBold" runat="server">Admin</asp:Label></td>
                                <td><asp:Label ID="lblOffLoad2" CssClass="NormalBold" runat="server">Off Load</asp:Label></td>
                            </tr>
                            <tr style="display: none">
                                <td><asp:TextBox ID="txtIOAdmin2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:FilteredTextBoxExtender ID="fteIOAdmin2" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOAdmin2" ValidChars="+-." />
                                </td>
                                <td><asp:TextBox ID="txtIOOffL2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" MaxLength="7" /><act:FilteredTextBoxExtender ID="fteIOOffL2" runat="server" FilterType="Numbers, LowercaseLetters, UppercaseLetters" TargetControlID="txtIOOffL2" />
                                    <asp:CustomValidator ID="cvIOOffL2" runat="server" ErrorMessage="<b>Error !!!</b><br />IO OffLoad Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIOOffL2" Display="None" /><act:ValidatorCalloutExtender ID="vlxIOOffL2" runat="Server" TargetControlID="cvIOOffL2" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td><asp:Label ID="plIOOffC4" CssClass="NormalBold" runat="server">Account</asp:Label></td>
                                <td><asp:Label ID="plIOOffN4" CssClass="NormalBold" runat="server">Name</asp:Label></td>
                                <td><asp:Label ID="plIOComm4" CssClass="NormalBold" runat="server">$ Amt</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIOOffC4" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
                                        <asp:ListItem Value="" Text="" />
                                        <asp:ListItem Value="0010108" Text="001010810" />
                                        <asp:ListItem Value="0000254" Text="000025410" />
                                        <asp:ListItem Value="0000600" Text="000060010" />
                                        <asp:ListItem Value="0016775" Text="001677510" />
                                        <asp:ListItem Value="0011429" Text="001142911" />
                                        <asp:ListItem Value="0008865" Text="0008865" />
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtIOOffC4" CssClass="NormalTextBox" Style="display: none" runat="server" Columns="7" MaxLength="9" /><act:FilteredTextBoxExtender ID="fteIOOffC4" runat="server" FilterType="Numbers" TargetControlID="txtIOOffC4" />
                                </td>
                                <td><asp:TextBox ID="txtIOOffN4" CssClass="NormalTextBox" ReadOnly="true" runat="server" Columns="16" /></td>
                                <td><asp:TextBox ID="txtIOComm4" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /><act:FilteredTextBoxExtender ID="fteIOComm4" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOComm4" ValidChars="+-." />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="tblBroker" runat="server" class="boxdisplay">
                <tr>
                    <td>
                        <table style="width: 255px">
                            <tr>
                                <td colspan="3">
                                    <div class="jrctitletext fleft">
                                        <div class="col60per">
                                            &nbsp; Broker &nbsp;</div>
                                        <div class="col40per">
                                            <asp:CheckBox ID="chkBKFixed" resourcekey="chkBKFixed" CssClass="fixed" Text="Fixed $" runat="server" AutoPostBack="True" Checked="True" /></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblBrokerCode" runat="server" CssClass="NormalBold"></asp:Label></td>
                                <td colspan="2"><asp:Label ID="lblBrokerName" runat="server" CssClass="NormalBold"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblBrokerAmt" CssClass="NormalBold" runat="server">Broker $</asp:Label></td>
                                <td><asp:Label ID="lblComm" CssClass="NormalBold" runat="server">%Comm</asp:Label></td>
                                <td class="DisplayNone"><asp:Label ID="lblBKAdminExempt" CssClass="NormalBold" runat="server" Text="Ad-X" /></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtBkrDlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="10" /><act:FilteredTextBoxExtender ID="fteBkrDlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBkrDlr" ValidChars="+-." />
                                </td>
                                <td><asp:TextBox ID="txtBkrPct" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:FilteredTextBoxExtender ID="fteBkrPct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBkrPct" ValidChars="+-." />
                                </td>
                                <td class="DisplayNone">
                                    <asp:CheckBox ID="chkBKAdminExempt" Enabled="false" CssClass="NormalTextBox" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:RangeValidator ID="valBkrPct" ControlToValidate="txtBkrPct" Type="Double" MinimumValue="0" MaximumValue="95" runat="server" ErrorMessage="Broker % has to be between 0 & 95" Display="None" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxBkrPct" runat="Server" TargetControlID="valBkrPct" WarningIconImageUrl="~/images/red-error.gif" />
                        <asp:CompareValidator ID="valBkrDlr" runat="server" ControlToCompare="txtBase" ControlToValidate="txtBkrDlr" Display="None" ErrorMessage="Broker Dollor should be Less than  Dollor Base" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" /><act:ValidatorCalloutExtender ID="vlxBkrDlr" runat="Server" TargetControlID="valBkrDlr" WarningIconImageUrl="~/images/red-error.gif" />
                    </td>
                </tr>
            </table>
            <table id="tblInterOffice" runat="server" class="boxdisplay">
                <tr>
                    <td width="255">
                        <div class="jrctitletext">
                            &nbsp; I/O Office &nbsp;</div>
                        <div>
                            <asp:Label ID="lblIOCode" runat="server" CssClass="NormalBold" /> &nbsp; <asp:Label ID="lblIOName" runat="server" CssClass="NormalBold" /></div>
                        <table>
                            <tr>
                                <td>
                                    <div class="fleft">
                                        <div class="col25">
                                            <asp:Label ID="lblIoPct" CssClass="NormalBold" runat="server">%</asp:Label></div>
                                        <div class="col25 DisplayNone">
                                            <asp:Label ID="lblIOFixed" CssClass="SubHead" runat="server" Text="Fixed$" /></div>
                                        <div class="col25">
                                            <asp:Label ID="lblIoDlr" CssClass="NormalBold" runat="server" Text="I/O Comm $" /></div>
                                        <div class="col25 DisplayNone">
                                            <asp:Label ID="lblNet" CssClass="NormalBold" runat="server" Text="Net$" /></div>
                                    </div>
                                    <div class="fleft">
                                        <div class="col25">
                                            <asp:TextBox ID="txtIOPct" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:FilteredTextBoxExtender ID="fteIOPct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIOPct" ValidChars="+-." />
                                        </div>
                                        <div class="col25 DisplayNone">
                                            <asp:CheckBox ID="chkIOFixed" resourcekey="chkIOFixed" CssClass="Normal" runat="server" AutoPostBack="True" /></div>
                                        <div class="col25">
                                            <asp:TextBox ID="txtIODlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:FilteredTextBoxExtender ID="fteIODlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtIODlr" ValidChars="+-." />
                                        </div>
                                        <div class="col25 DisplayNone">
                                            <asp:TextBox ID="txtNetIODlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:FilteredTextBoxExtender ID="fteNetIODlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtNetIODlr" ValidChars="+-." />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="tblDriver" runat="server" class="boxdisplay">
                <tr>
                    <td width="255">
                        <table width="100%">
                            <tr>
                                <td colspan="4">
                                    <div class="jrctitletext fleft">
                                        <div class="col60per">
                                            &nbsp; Driver &nbsp;</div>
                                        <div class="col40per">
                                            <asp:CheckBox ID="chkOOFixed" runat="server" AutoPostBack="True" CssClass="fixed" resourcekey="chkOOFixed" Checked="False" /></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblDriverCode" runat="server" CssClass="NormalBold"></asp:Label></td>
                                <td colspan="3"><asp:Label ID="lblDriverName" runat="server" CssClass="NormalBold"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblOverRide" runat="server" CssClass="NormalBold">% Comm</asp:Label></td>
                                <td colspan="3"><asp:TextBox ID="txtCommRate" CssClass="NormalTextBox NumericTextBox" Columns="4" runat="server" /><act:FilteredTextBoxExtender ID="fteCommRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRate" ValidChars="+-." />
                                    <asp:RangeValidator ID="valCommRate" runat="server" ControlToValidate="txtCommRate" Display="None" ErrorMessage="Driver % has to be between 0 & 93" MaximumValue="93" MinimumValue="0" SetFocusOnError="True" Type="Double" /><act:ValidatorCalloutExtender ID="vlxCommRate" runat="Server" TargetControlID="valCommRate" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblDRTolls" CssClass="NormalBold" runat="server">Tolls</asp:Label></td>
                                <td><asp:TextBox ID="txtDRTolls" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:FilteredTextBoxExtender ID="fteDRTolls" runat="server" FilterType="Numbers, Custom" TargetControlID="txtDRTolls" ValidChars="+-." />
                                </td>
                                <td class="DisplayNone"><asp:Label ID="lblBase" CssClass="NormalBold" runat="server">$ Base</asp:Label></td>
                                <td><asp:Label ID="lblDRCommBase" CssClass="NormalBold" runat="server">Driver $</asp:Label></td>
                                <td class="DisplayNone"><asp:TextBox ID="txtBaseOO" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" Columns="8" runat="server" ReadOnly="True" /></td>
                                <td><asp:TextBox ID="txtDRCommBase" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:FilteredTextBoxExtender ID="fteDRCommBase" runat="server" FilterType="Numbers, Custom" TargetControlID="txtDRCommBase" ValidChars="+-." />
                                    <asp:ImageButton ID="imbDriver" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                    <asp:CompareValidator ID="valDRCommBase" runat="server" ControlToCompare="txtBase" ControlToValidate="txtDRCommBase" Display="None" ErrorMessage="Driver Commision should be Less than  Dollor Base" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" /><act:ValidatorCalloutExtender ID="vlxDRCommBase" runat="Server" TargetControlID="valDRCommBase" WarningIconImageUrl="~/images/red-error.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblDRMisc" CssClass="NormalBold" runat="server" Text="Misc" /></td>
                                <td><asp:TextBox ID="txtDRMisc" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:FilteredTextBoxExtender ID="fteDRMisc" runat="server" FilterType="Numbers, Custom" TargetControlID="txtDRMisc" ValidChars="+-." />
                                </td>
                                <td><asp:Label ID="lblOCommNeg" CssClass="NormalBold" runat="server" Text="Adj +/-" /></td>
                                <td><asp:TextBox ID="txtOCommNeg" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /></td>
                            </tr>
                            <tr>
                                <td class="DisplayNone"><asp:Label ID="lblExmt" CssClass="NormalBold" runat="server" Text="Exmt" /></td>
                                <td class="DisplayNone">
                                    <asp:CheckBox ID="chkAdminExempt" Enabled="false" CssClass="NormalTextBox" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table id="tblDriverDeduction" runat="server" width="100%">
                                        <tr class="jrctitletext">
                                            <td colspan="4">&nbsp; DriverDeduction &nbsp; </td>
                                            <td colspan="2" align="left"><asp:TextBox ID="txtDvrDedResn" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="12" ReadOnly="True" /></td>
                                        </tr>
                                        <tr>
                                            <td class="DisplayNone"><asp:Label ID="lblDvrDedResn" CssClass="NormalBold" runat="server" Text="Reason For Carrier<br/>Deduction" /></td>
                                            <td><asp:Label ID="lblDvrDedPct" CssClass="NormalBold" runat="server" Text="Ded %" /> <asp:TextBox ID="txtDvrDedPct" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /> <asp:TextBox ID="txtOCommPlus" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="tblCommissionsSplit" runat="server" class="boxdisplay">
                <tr>
                    <td>
                        <table style="width: 255px">
                            <tr>
                                <td class="DisplayNone">
                                    <caption style="text-align: left" class="jrctitletext">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" valign="middle" width="20%" class="jrctitletext">&nbsp; Splits &nbsp;</td>
                                                <td align="center" valign="middle" width="20%"><asp:TextBox ID="txtIOOffC3" CssClass="NormalTextBox" ReadOnly="true" runat="server" Columns="6" /></td>
                                                <td align="center" valign="middle" width="40%"><asp:TextBox ID="txtIOOffN3" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" runat="server"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </caption>
                                </td>
                            </tr>
                            <tr>
                                <td class="DisplayNone" nowrap><dnn:Label ID="plSubOffComm" Suffix=":" ControlName="chkSubOffComm" runat="server" CssClass="SubHead" /></td>
                                <td class="DisplayNone">
                                    <asp:CheckBox ID="chkSubOffComm" CssClass="Normal" runat="server" resourcekey="chkSubOffComm"></asp:CheckBox></td>
                            </tr>
                        </table>
                        <table id="tblCommissionsSplit3" runat="server" style="width: 255px">
                            <tr>
                                <td colspan="4" class="DisplayNone"><asp:Label ID="lblCommRecipient" CssClass="NormalBold" runat="server">CommRecipient</asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblCommAdmin" runat="server" CssClass="NormalBold">Com%</asp:Label></td>
                                <td><asp:TextBox ID="txtIOAdmin3" runat="server" Columns="4" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" /></td>
                                <td><asp:Label ID="lblCommAmt" runat="server" CssClass="NormalBold">Com$</asp:Label></td>
                                <td><asp:TextBox ID="txtIOComm3" runat="server" Columns="4" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" /></td>
                            </tr>
                        </table>
                        <table id="tblCommissionsSplit4" runat="server" style="width: 255px" visible="false">
                            <tr>
                                <td colspan="4"><asp:Label ID="lblCommRecipient4" CssClass="NormalBold" runat="server">CommRecipient</asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4"><asp:TextBox ID="txtIOOffC4O" Visible="false" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /><asp:TextBox ID="txtIOOffN4O" Visible="false" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblCommAdmin4" runat="server" CssClass="NormalBold">%% Comm</asp:Label></td>
                                <td><asp:TextBox ID="txtIOAdmin4" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4"></asp:TextBox></td>
                                <td><asp:Label ID="lblCommAmt4" runat="server" CssClass="NormalBold">Comm $ Amt</asp:Label></td>
                                <td><asp:TextBox ID="txtIOComm4O" Visible="false" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table id="tblJRCOffCommissionSplit" runat="server" style="width: 255px">
                            <tr>
                                <td colspan="2"><asp:Label ID="lblJRCOffCode" CssClass="NormalBold" runat="server" /></td>
                                <td colspan="2"><asp:Label ID="lblJRCOffName" CssClass="NormalBold" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblJRCOffAdminPct" runat="server" CssClass="NormalBold">Com%</asp:Label></td>
                                <td><asp:TextBox ID="txtJRCOffAdminPct" runat="server" Columns="4" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" /></td>
                                <td><asp:Label ID="lblJRCOffCommDlr" runat="server" CssClass="NormalBold">Com$</asp:Label></td>
                                <td><asp:TextBox ID="txtJRCOffCommDlr" runat="server" Columns="4" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="255" class="boxdisplay" id="tblComCod" runat="server">
                <tr>
                    <td>
                        <table id="tblComCheck" runat="server" style="width: 100%">
                            <tr>
                                <td class="jrctitletext" colspan="4">&nbsp; Checks In / Out &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fixed_blue">Com#</td>
                                <td class="col110"><asp:TextBox ID="txtComCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                <td class="fixed_blue">$</td>
                                <td class="col110"><asp:TextBox ID="txtComCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteComCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtComCheckAmt" ValidChars="+-." />
                                </td>
                            </tr>
                        </table>
                        <table id="tblCodCheck" runat="server" style="width: 100%">
                            <tr>
                                <td class="fixed_blue">COD#</td>
                                <td class="col110"><asp:TextBox ID="txtCodCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                <td class="fixed_blue">$</td>
                                <td class="col110"><asp:TextBox ID="txtCodCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteCodCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCodCheckAmt" ValidChars="+-." />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td><asp:ImageButton ID="imbJrcTotal" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                        <asp:Label ID="errJRCTotal" CssClass="NormalRed" runat="server" />
                        <asp:CustomValidator ID="cvGPPct" runat="server" ControlToValidate="txtBCustBill" Display="Dynamic" ErrorMessage="<br/>JRC Percentage must be more than 4.85%" CssClass="NormalRed" />
                    </td>
                </tr>
                <tr id="trAdjustJrcTotal" runat="server">
                    <td bgcolor="#D2FFD2" cssclass="alloc_amt">
                        <asp:CheckBox ID="chkAdjustJrcTotal" CssClass="alloc_amt" runat="server" Text="Click this box to adjust your commission, then re-calculate." /></td>
                </tr>
            </table>
            <table id="tblAccountingNegative" runat="server" visible="false" width="100%" border="1" cellspacing="0" cellpadding="0">
                <tr>
                    <td><asp:Label ID="lblAccountingNegativeHeading" runat="server" CssClass="NormalRed" Text="Accounting contains negative Amounts" /><br />
                        <asp:Label ID="lblAccountingNegativeMessage" runat="server" CssClass="SubHead" Text="If you dont know the base load amount at this time OR are unable to correct situation, please hit 'abort' to return to 'View Loads'" /> <asp:HyperLink ID="hypAccountingNegative" runat="server" ImageUrl="~/images/cancel_changes.png" NavigateUrl="~/Default.aspx?tabname=View Loads" /> </td>
                </tr>
            </table>
        </td>
        <td align="right" valign="top">
            <table class="boxdisplay">
                <tr>
                    <td width="180">
                        <div class="jrctitletext fleft">
                            &nbsp; Load Miles Calculator &nbsp;</div>
                        <div class="col33per">
                            <asp:Label ID="lblCalcMI" resourcekey="plCalcMI" CssClass="SubHead" runat="server"></asp:Label></div>
                        <div class="col33per">
                            <asp:Label ID="lblCalcRate" resourcekey="plCalcRate" CssClass="SubHead" runat="server"></asp:Label></div>
                        <div class="col33per">
                            <asp:Label ID="lblCalcTot" resourcekey="plCalcTot" CssClass="SubHead" runat="server"></asp:Label></div>
                        <div class="col33per">
                            <asp:TextBox ID="txtCalcMI" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="3" /><act:FilteredTextBoxExtender ID="fteCalcMI" runat="server" TargetControlID="txtCalcMI" FilterType="Numbers" />
                        </div>
                        <div class="col33per">
                            <asp:TextBox ID="txtCalcRate" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="3" AutoPostBack="True" /><act:FilteredTextBoxExtender ID="fteCalcRate" runat="server" TargetControlID="txtCalcRate" FilterType="Numbers, Custom" ValidChars="+-." />
                        </div>
                        <div class="col33per">
                            <asp:TextBox ID="txtCalcTot" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" AutoPostBack="True" ReadOnly="True" /></div>
                    </td>
                </tr>
            </table>
            <table class="boxdisplay">
                <tr>
                    <td width="180">
                        <div class="jrctitletext fleft">
                            <div class="col60per">
                                &nbsp; Sales Rep &nbsp;</div>
                            <div class="col40per">
                                <asp:CheckBox ID="chkRepFixed" CssClass="fixed" Checked="true" Text="Fixed$" runat="server" AutoPostBack="True" /></div>
                        </div>
                        <div class="col40per normalbold">
                            Override?<br />
                            <asp:Label ID="plOverrideCode" resourcekey="plOverrideCode" runat="server" CssClass="displaynone" /></div>
                        <div class="col60per">
                            <asp:CheckBox ID="chkOverrideCode" runat="server" AutoPostBack="true" /><asp:Label ID="lblOverriddenBy" runat="server" CssClass="NormalBold" /><asp:TextBox ID="txtOverrideCode" runat="server" CssClass="NormalTextBox" Columns="8" AutoPostBack="true" Visible="false" /></div>
                        <div class="fleft">
                            <asp:Label ID="errOverrideCode" runat="server" CssClass="NormalRed" EnableViewState="false" /></div>
                        <div class="col50per">
                            <asp:Label ID="lblRepNo" runat="server" CssClass="NormalBold" /></div>
                        <div class="col50per">
                            <asp:Label ID="lblRepName" runat="server" CssClass="NormalBold" /></div>
                        <div class="fleft">
                            <asp:DropDownList ID="ddlRepNo" runat="server" CssClass="NormalTextBox" AutoPostBack="true" />
                        </div>
                        <div class="col50per">
                            <asp:Label ID="plRepPct" runat="server" CssClass="NormalBold" Text="Comm %" /></div>
                        <div class="col50per">
                            <asp:Label ID="plRepDlr" runat="server" CssClass="NormalBold" Text="Comm $" /></div>
                        <div class="col50per">
                            <act:FilteredTextBoxExtender ID="fteRepPct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepPct" ValidChars="+-." />
                            <asp:TextBox ID="txtRepPct" runat="server" Columns="2" CssClass="NormalTextBox NumericTextBox" Text="0" /></div>
                        <div class="col50per">
                            <asp:TextBox ID="txtRepDlr" runat="server" Columns="7" CssClass="NormalTextBox NumericTextBox" Text="0" />
                            <act:FilteredTextBoxExtender ID="fteRepDlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepDlr" ValidChars="+-." />
                        </div>
                        <asp:CompareValidator ID="valRepPct" runat="server" ValueToCompare="50" ControlToValidate="txtRepPct" Display="None" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" ErrorMessage="Sales Rep % has to be between 0 & 50" /><act:ValidatorCalloutExtender ID="vlxRepPct" runat="Server" TargetControlID="valRepPct" WarningIconImageUrl="~/images/red-error.gif" />
                        <asp:CompareValidator ID="valRepDlr" runat="server" ValueToCompare="100" ControlToValidate="txtRepDlr" Display="None" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" ErrorMessage="Sales Rep Commision should be Less than 5% of Dollor Base" /><act:ValidatorCalloutExtender ID="vlxRepDlr" runat="Server" TargetControlID="valRepDlr" WarningIconImageUrl="~/images/red-error.gif" />
                    </td>
                </tr>
            </table>
            <table class="boxdisplay">
                <tr>
                    <td>
                        <table style="width: 180px" cellpadding="0" cellspacing="0" border="0">
                            <asp:Label ID="lblLoadType" Text="LoadAccounting" CssClass="displaynone" runat="server" />
                            <tr>
                                <td class="SubHead" nowrap="nowrap"><asp:Label ID="lblLoadID" runat="server" resourcekey="plLoadID" /><br />
                                    <asp:HyperLink ID="hypLoadID" runat="server" CssClass="SubHead" /></td>
                                <td class="DisplayNone" nowrap="nowrap"><asp:HyperLink ID="hypLoadID1" runat="server" BorderStyle="none" CssClass="CommandButton" ImageUrl="~/images/lt.gif" resourcekey="plLoadID" /></td>
                                <td align="center" class="SubHead" valign="top">
                                    <asp:ImageButton ID="imbMasterCalc1" runat="server" BorderStyle="none" CausesValidation="False" CssClass="CommandButton" ImageUrl="~/images/update_accounting.png" resourcekey="Calculate" />
                                    <br />
                                    <asp:LinkButton ID="cmdMasterCalc1" runat="server" BorderStyle="none" CausesValidation="False" CssClass="CommandButton" resourcekey="Calculate" />
                                    <asp:ImageButton ID="imbUpdateContinueEdit1" runat="server" BorderStyle="none" CssClass="CommandButton" ImageUrl="~/images/update_and_edit.png" resourcekey="update_and_edit" Visible="False" />
                                    <asp:LinkButton ID="lnbUpdateContinueEdit1" runat="server" BorderStyle="none" CssClass="CommandButton" resourcekey="update_and_edit" Text="Save &amp; Continue" Visible="False" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td class="DisplayNone" nowrap="nowrap"><asp:Label ID="lblBaseCalc" runat="server" Text="$ Base" /></td>
                                <td class="DisplayNone" nowrap="nowrap" align="right"><asp:TextBox ID="txtBase" Columns="10" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" runat="server" ReadOnly="True" /> <asp:ImageButton ID="imbBaseCalculate" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="displaynone">
                            <tr>
                                <td colspan="2"><span class="Normal">
                                    <asp:DropDownList ID="ddleMailTo" CssClass="emaildrop" runat="server" DataTextField="DispatchName" DataValueField="DispatchCode" />
                                </span></td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        <span class="SubHead"><dnn:Label ID="pleMailTo" Text="eMail It >" Suffix=":" ControlName="ddleMailTo" runat="server" CssClass="SubHead" /></span>
                                    </div>
                                </td>
                                <td><span class="Normal"><asp:ImageButton ID="imbeMailTo" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" />
                                </span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            
            <table class="boxdisplay" width="180">
                <tr>
                    <td colspan="2" class="jrctitletext fleft">Load Details</td>
                </tr>
                <tr>
                    <td class="NormalBold">Customer</td>
                    <td><asp:Label ID="lblCustomer" runat="server" CssClass="SubHead" /></td>
                </tr>
                <tr>
                    <td class="NormalBold">FirstPU</td>
                    <td><asp:Label ID="lblFirstPU" runat="server" CssClass="SubHead" /></td>
                </tr>
                <tr>
                    <td class="NormalBold">LastDP</td>
                    <td><asp:Label ID="lblLastDP" runat="server" CssClass="SubHead" /></td>
                </tr>
            </table>
        </td>
        <td>
            <table width="50" border="0" align="right" cellspacing="0" class="alloc_tab">
                <tr id="trAccountingSummary" runat="server">
                    <td>
                        <div id="acctcolumn">
                            <div class="acctitem">
                                <asp:Label ID="txtLoadStatus" CssClass="SubHead" Style="font-weight: bold; border-width: 0;" runat="server" />
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="Label01" CssClass="NormalBold" runat="server" Text="Customer">Customer</asp:Label> <br />
                                <asp:Label ID="txtCustBill" CssClass="alloc_amt" runat="server" Text="0.00" />
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblIOComm" CssClass="alloc_lab" runat="server" Text="IO $">IO $</asp:Label> <br />
                                <asp:Label ID="txtIOCommTot" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblIOAdmin" CssClass="alloc_lab" runat="server" Text="IO Adm$">IO Adm$</asp:Label> <asp:Label ID="txtIOAdminTot" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblExclusion" CssClass="alloc_lab" runat="server" Text="Exclusion">Exclusion</asp:Label> <br />
                                <asp:Label ID="txtExTot" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblRepDue" CssClass="alloc_lab" runat="server" Text="Rep Due">Rep Due</asp:Label> <br />
                                <asp:Label ID="txtRep" CssClass="alloc_amt" runat="server" Text="0.00" />
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblCarrierDue" CssClass="alloc_lab" runat="server" Text="Carrier$">Carrier$</asp:Label> <br />
                                <asp:Label ID="txtDRTotDue" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblAPcomm4" CssClass="alloc_lab" runat="server" Text="Unbound">Unbound</asp:Label> <asp:Label ID="txtAPComm4" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblAPcomm3" CssClass="alloc_lab" runat="server" Text="Unbound">Unbound</asp:Label> <br />
                                <asp:Label ID="txtAPComm3" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <span class="DisplayNone"><asp:Label ID="lblAPcomm2" CssClass="alloc_lab" runat="server" Text="Unbound">Unbound</asp:Label> <br />
                                    <asp:Label ID="txtAPComm2" CssClass="alloc_amt" runat="server">0.00</asp:Label> </span>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblJRCOffComm" CssClass="alloc_lab" runat="server" Text="Unbound">Unbound</asp:Label> <br />
                                <asp:Label ID="txtJRCOffComm" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblJRCOnePct" CssClass="alloc_lab" runat="server" Text="% Admin">% Admin</asp:Label> <br />
                                <asp:Label ID="txtJRCOnePct" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <asp:Label ID="lblJRCTotal" CssClass="alloc_lab" runat="server" Text="JRC Total">JRC</asp:Label> <br />
                                <asp:Label ID="txtJRCTotal" CssClass="alloc_amt" runat="server">0.00</asp:Label>
                            </div>
                            <div class="acctitem">
                                <div cssclass="alloc_amt">
                                    <asp:Label ID="txtGPPct" CssClass="alloc_amt" runat="server">0.00</asp:Label>%</div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
        </tr> </table>
    </center>
    <script language="javascript" type="text/javascript">window.history.forward(1);</script>
</asp:Panel>
<p style="display: none">
<asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
    <asp:ListItem Value="Listing" resourcekey="Listing" />
    <asp:ListItem Value="NewItem" resourcekey="NewItem" />
    <asp:ListItem Value="EditItem" resourcekey="EditItem" />
    <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
    <asp:ListItem Value="LoadSheet" resourcekey="LoadSheet" />
</asp:DropDownList>
<br />
<asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp; <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
<asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />&nbsp; <span class="DisplayNone"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
    <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></span></p>
<p>
<Portal:Audit ID="ctlAudit" runat="server" />
</p>
<p>
<Portal:Tracking ID="ctlTracking" runat="server" />
</p>
<table id="tblLoadAcctEdit" style="display: none" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDiscountDlr" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDiscountDlr"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDRRebur" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDRRebur"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDRRebur" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDRPermits" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDRPermits"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDRPermits" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPCommTot" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPCommTot"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCommTot" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOOffC1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOOffC1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffC1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOOffC2" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOOffC2"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffC2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOOffL3" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOOffL3"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffL3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOOffL4" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOOffL4"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffL4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="32"><dnn:Label ID="plBINC3" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC3"></dnn:Label></td>
        <td class="Normal" height="32"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC4" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC4"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC5" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC5"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC6" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC6"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC7" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC7"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC8" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC8"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC9" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC9"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC10" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC10"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBINC11" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkBINC11"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRCOffPct" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtJRCOffPct"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCOffPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRCBkrPct" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtJRCBkrPct"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCBkrPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDCPCT" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDCPCT"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDCPCT" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plONEPCT" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtONEPCT"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtONEPCT" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDispPct" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDispPct"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDispPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDispDlr" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtDispDlr"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDispDlr" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOXPct1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOXPct1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOXPct2" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOXPct2"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOXPct3" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOXPct3"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIOXPct4" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtIOXPct4"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRCAdminP" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtJRCAdminP"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCAdminP" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffC1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffC1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffC2" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffC2"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffC3" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffC3"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffC4" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffC4"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffN1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffN1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffN2" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffN2"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffN3" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffN3"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPOffN4" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPOffN4"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPComm1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPComm1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPComm1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPCPct1" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPCPct1"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPCPct2" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPCPct2"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPCPct3" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPCPct3"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAPCPct4" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAPCPct4"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAllowORide" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkAllowORide"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAllowORide" resourcekey="chkAllowORide" CssClass="Normal" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBType" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtBType"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtBType" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plOCommNeg" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtOCommNeg"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAlumaPct" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAlumaPct"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAlumaPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAlumaDlrDisc" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtAlumaDlrDisc"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAlumaDlrDisc" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plGPPct" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtGPPct"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPName" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtTPName"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPAmt" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtTPAmt"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPAmt" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPDesc" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtTPDesc"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPDesc" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPPaidDate" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtTPPaidDate"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPPaidDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarTPPaidDate" resourcekey="Calendar" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPCkNo" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtTPCkNo"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPCkNo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRC5050" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkJRC5050"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkJRC5050" resourcekey="chkJRC5050" CssClass="Normal" runat="server"></asp:CheckBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plCalc85" CssClass="SubHead" runat="server" Suffix=":" ControlName="chkCalc85"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCalc85" resourcekey="chkCalc85" CssClass="Normal" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plViewOrder" CssClass="SubHead" runat="server" Suffix=":" ControlName="txtViewOrder"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
</table>
