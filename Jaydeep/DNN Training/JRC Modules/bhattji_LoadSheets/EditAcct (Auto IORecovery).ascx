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
<asp:Panel ID="pnlBhattji" runat="server" Style="position: relative;" DefaultButton="imbMasterCalc1">
    <center>
        <table>
            <tr>
                <td valign="top">
                    <table class="boxdisplay">
                        <tr>
                            <td style="text-align: left" class="jrctitletext">&nbsp; Customer Billing &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 370px">
                                <table>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBBaseLoad" resourcekey="plBBaseLoad" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBBaseLoad" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:filteredtextboxextender id="fteBBaseLoad" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBBaseLoad" validchars="+-." /></td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblDiscountPCT" resourcekey="plDiscountPCT" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtDiscountPCT" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="1" /><act:filteredtextboxextender id="fteDiscountPCT" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtDiscountPCT" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:TextBox ID="txtDiscountDlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:filteredtextboxextender id="fteDiscountDlr" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtDiscountDlr" validchars="+-." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBDeten" resourcekey="plBDeten" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBDeten" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBDeten" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBDeten" validchars="+-." />
                                            <asp:CheckBox ID="chkBINC3" resourcekey="chkBINC3" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBTolls" resourcekey="plBTolls" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBTolls" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBTolls" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBTolls" validchars="+-." />
                                            <asp:CheckBox ID="chkBINC4" resourcekey="chkBINC4" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBFuel" resourcekey="plBFuel" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBFuel" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBFuel" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBFuel" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC5" resourcekey="chkBINC5" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBDrop" resourcekey="plBDrop" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBDrop" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:filteredtextboxextender id="fteBDrop" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBDrop" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC6" resourcekey="chkBINC6" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBRecon" resourcekey="plBRecon" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBRecon" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBRecon" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBRecon" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC7" resourcekey="chkBINC7" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBTarp" resourcekey="plBTarp" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBTarp" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBTarp" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBTarp" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC8" resourcekey="chkBINC8" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBLumper" resourcekey="plBLumper" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBLumper" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBLumper" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBLumper" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC9" resourcekey="chkBINC9" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBUnload" resourcekey="plBUnload" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBUnload" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBUnload" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBUnload" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC10" resourcekey="chkBINC10" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBAdminMisc" resourcekey="plBAdminMisc" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td class="SubHead" nowrap><asp:TextBox ID="txtBAdminMisc" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteBAdminMisc" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBAdminMisc" validchars="+-.">
                                        </act:filteredtextboxextender>
                                            <asp:CheckBox ID="chkBINC11" resourcekey="chkBINC11" CssClass="Normal" runat="server" Checked="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBCustBill" resourcekey="plBCustBill" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td nowrap><asp:TextBox ID="txtBCustBill" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" runat="server" Columns="13" ReadOnly="True" /><asp:ImageButton ID="imbCalculate" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:CompareValidator ID="valBBaseLoad" runat="server" ControlToValidate="txtBBaseLoad" Display="None" ErrorMessage="Customer Base Load can not be Zero" Operator="GreaterThan" SetFocusOnError="True" Type="Double" ValueToCompare="0" /><act:validatorcalloutextender id="vlxBBaseLoad" runat="Server" targetcontrolid="valBBaseLoad" warningiconimageurl="~/images/red-error.gif" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" align="center" style="width: 330px">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <progresstemplate>
                    <br />
                    <asp:Image ID="Image2" ImageUrl="~/images/progressbar.gif" runat="server" />
                </progresstemplate>
                    </asp:UpdateProgress>
                    <table id="tblIORecovery" runat="server" class="boxdisplay">
                        <tr>
                            <td style="text-align: left" class="jrctitletext">&nbsp; Inter Office &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table id="tblIORecovery1" runat="server" style="width: 255px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlIOOffN1" CssClass="NormalTextBox" runat="server" Columns="24" Enabled="false" AutoPostBack="true" />
                                            <asp:TextBox ID="txtIOOffN1" CssClass="NormalBold" ReadOnly="true" runat="server" Style="display: none" Columns="24" /></td>
                                        <td><asp:Label ID="txtJRCIOOffC1" CssClass="NormalBold" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblAmount" CssClass="NormalBold" runat="server">$ Amt</asp:Label></td>
                                        <td><asp:Label ID="lblAdmin" CssClass="NormalBold" runat="server">Admin</asp:Label></td>
                                        <td><asp:Label ID="lblOffLoad" CssClass="NormalBold" runat="server">Off Load</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:TextBox ID="txtIOComm1" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" ReadOnly="True" /><act:filteredtextboxextender id="fteIOComm1" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOComm1" validchars="+-." /></td>
                                        <td><asp:TextBox ID="txtIOAdmin1" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" ReadOnly="True" /><act:filteredtextboxextender id="fteIOAdmin1" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOAdmin1" validchars="+-." /></td>
                                        <td><asp:TextBox ID="txtIOOffL1" CssClass="NormalTextBox" runat="server" Columns="7" MaxLength="7" ReadOnly="True" /><act:filteredtextboxextender id="fteIOOffL1" runat="server" filtertype="Numbers, LowercaseLetters, UppercaseLetters" targetcontrolid="txtIOOffL1" /><asp:CustomValidator ID="cvIOOffL1" runat="server" ErrorMessage="<b>Error !!!</b><br />IO OffLoad Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIOOffL1" Display="None" /><act:validatorcalloutextender id="vlxIOOffL1" runat="Server" targetcontrolid="cvIOOffL1" warningiconimageurl="~/images/red-error.gif" /><asp:RequiredFieldValidator ID="valIOOffL1" ControlToValidate="txtIOOffL1" Display="None" runat="server" ErrorMessage="<b>Required</b><br>IO OffLoad Must be 7 characters" /><act:validatorcalloutextender id="vlxReqIOOffL1" runat="Server" targetcontrolid="valIOOffL1" warningiconimageurl="~/images/red-error.gif" /></td>
                                    </tr>
                                </table>
                                <%--<asp:CheckBox ID="chkManagementOverride" runat="server" CssClass="SubHead" AutoPostBack="true" Text="Pay Management Override" />--%>
                                <table id="tblIORecovery2" runat="server" style="width: 255px">
                                    <tr style="display:none">
                                        <td colspan="3"><asp:Label ID="lblManagementOverride" runat="server" Text="Pay Management Override" CssClass="SubHead" /></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="plJRCIOOffC2" CssClass="NormalBold" runat="server">Account</asp:Label></td>
                                        <td><asp:Label ID="plIOOffN2" CssClass="NormalBold" runat="server">Name</asp:Label></td>
                                        <td><asp:Label ID="plIOComm2" CssClass="NormalBold" runat="server">$ Amt</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:TextBox ID="txtJRCIOOffC2" CssClass="NormalTextBox ReadOnlyTextBox" ReadOnly="true" runat="server" Columns="7" MaxLength="9" /><act:filteredtextboxextender id="fteJRCIOOffC2" runat="server" filtertype="Numbers" targetcontrolid="txtJRCIOOffC2" /><asp:RequiredFieldValidator ID="valJRCIOOffC2" ControlToValidate="txtJRCIOOffC2" runat="server" ErrorMessage="Account is Required" Display="None" /><act:validatorcalloutextender id="vlxJRCIOOffC2" runat="Server" targetcontrolid="valJRCIOOffC2" warningiconimageurl="~/images/red-error.gif" /></td>
                                        <td><asp:TextBox ID="txtIOOffN2" CssClass="NormalTextBox ReadOnlyTextBox" ReadOnly="true" runat="server" Columns="16" /><asp:RequiredFieldValidator ID="valIOOffN2" ControlToValidate="txtIOOffN2" runat="server" ErrorMessage="Account Name is Required" Display="None" /><act:validatorcalloutextender id="vlxIOOffN2" runat="Server" targetcontrolid="valIOOffN2" warningiconimageurl="~/images/red-error.gif" /></td>
                                        <td><asp:TextBox ID="txtIOComm2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6"  /><act:filteredtextboxextender id="fteIOComm2" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOComm2" validchars="+-." /><asp:RequiredFieldValidator ID="valIOComm2" ControlToValidate="txtIOComm2" runat="server" ErrorMessage="$ Amount is Required" Display="None" /><act:validatorcalloutextender id="vlxIOComm2" runat="Server" targetcontrolid="valIOComm2" warningiconimageurl="~/images/red-error.gif" /></td>
                                    </tr>
                                    <tr style="display:none">
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlIOOffN2" CssClass="NormalTextBox" runat="server" Columns="24" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr style="display:none">
                                        <td><asp:Label ID="lblAdmin2" CssClass="NormalBold" runat="server">Admin</asp:Label></td>
                                        <td><asp:Label ID="lblOffLoad2" CssClass="NormalBold" runat="server">Off Load</asp:Label></td>
                                    </tr>
                                    <tr style="display:none">
                                        <td><asp:TextBox ID="txtIOAdmin2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:filteredtextboxextender id="fteIOAdmin2" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOAdmin2" validchars="+-." /></td>
                                        <td><asp:TextBox ID="txtIOOffL2" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" MaxLength="7" /><act:filteredtextboxextender id="fteIOOffL2" runat="server" filtertype="Numbers, LowercaseLetters, UppercaseLetters" targetcontrolid="txtIOOffL2" /><asp:CustomValidator ID="cvIOOffL2" runat="server" ErrorMessage="<b>Error !!!</b><br />IO OffLoad Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIOOffL2" Display="None" /><act:validatorcalloutextender id="vlxIOOffL2" runat="Server" targetcontrolid="cvIOOffL2" warningiconimageurl="~/images/red-error.gif" /></td>
                                    </tr>
                                    <tr style="display:none">
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
                                            <asp:TextBox ID="txtIOOffC4" CssClass="NormalTextBox" Style="display: none" runat="server" Columns="7" MaxLength="9" /><act:filteredtextboxextender id="fteIOOffC4" runat="server" filtertype="Numbers" targetcontrolid="txtIOOffC4" /></td>
                                        <td><asp:TextBox ID="txtIOOffN4" CssClass="NormalTextBox" ReadOnly="true" runat="server" Columns="16" /></td>
                                        <td><asp:TextBox ID="txtIOComm4" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /><act:filteredtextboxextender id="fteIOComm4" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOComm4" validchars="+-." /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 255px">
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; Exclusion &nbsp;</caption>
                                    <tr>
                                        <td><asp:Label ID="lblDesc" CssClass="SubHead" Text="Desc" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lblExPermits" CssClass="NormalBold" Text="Permits" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lblExTrailer" CssClass="NormalBold" Text="Trailer" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lblExMisc" CssClass="NormalBold" Text="Misc" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblExAmount" CssClass="SubHead" Text="$ Amount" runat="server"></asp:Label></td>
                                        <td><asp:TextBox ID="txtExPermits" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteExPermits" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtExPermits" validchars="+-." />
                                        </td>
                                        <td><asp:TextBox ID="txtExTrailer" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteExTrailer" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtExTrailer" validchars="+-." />
                                        </td>
                                        <td><asp:TextBox ID="txtExMisc" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7"></asp:TextBox><act:filteredtextboxextender id="fteExMisc" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtExMisc" validchars="+-." /><asp:ImageButton ID="imbExclusion" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
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
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; Broker &nbsp;</caption>
                                    <tr>
                                        <td><asp:Label ID="lblBrokerCode" runat="server" CssClass="NormalBold"></asp:Label></td>
                                        <td colspan="3"><asp:Label ID="lblBrokerName" runat="server" CssClass="NormalBold"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblBrokerAmt" CssClass="NormalBold" runat="server">Broker $ Amt</asp:Label></td>
                                        <td><asp:Label ID="lblComm" CssClass="NormalBold" runat="server">% Comm</asp:Label></td>
                                        <td><asp:Label ID="lblPatFixedvalue" CssClass="NormalBold" runat="server" Text="Fixed $" /></td>
                                        <td><asp:Label ID="lblBKAdminExempt" CssClass="NormalBold" runat="server" Text="AdmExmpt" /></td>
                                    </tr>
                                    <tr>
                                        <td><asp:TextBox ID="txtBkrDlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="10" /><act:filteredtextboxextender id="fteBkrDlr" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBkrDlr" validchars="+-." />
                                        </td>
                                        <td><asp:TextBox ID="txtBkrPct" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:filteredtextboxextender id="fteBkrPct" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtBkrPct" validchars="+-." />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkBKFixed" resourcekey="chkBKFixed" CssClass="Normal" runat="server" AutoPostBack="True" Checked="True" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkBKAdminExempt" Enabled="false" CssClass="NormalTextBox" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:RangeValidator ID="valBkrPct" ControlToValidate="txtBkrPct" Type="Double" MinimumValue="0" MaximumValue="90" runat="server" ErrorMessage="Broker % has to be between 0 & 90" Display="None" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxBkrPct" runat="Server" targetcontrolid="valBkrPct" warningiconimageurl="~/images/red-error.gif" />
                                <asp:CompareValidator ID="valBkrDlr" runat="server" ControlToCompare="txtBase" ControlToValidate="txtBkrDlr" Display="None" ErrorMessage="Broker Dollor should be Less than  Dollor Base" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" /><act:validatorcalloutextender id="vlxBkrDlr" runat="Server" targetcontrolid="valBkrDlr" warningiconimageurl="~/images/red-error.gif" />
                            </td>
                        </tr>
                    </table>
                    <table id="tblInterOffice" runat="server" class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 255px">
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; I/O Office &nbsp;</caption>
                                    <tr>
                                        <td><asp:Label ID="lblIOCode" runat="server" CssClass="NormalBold" /> &nbsp; <asp:Label ID="lblIOName" runat="server" CssClass="NormalBold" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td><asp:Label ID="lblIoPct" CssClass="NormalBold" runat="server">%</asp:Label></td>
                                                    <td nowrap><asp:Label ID="lblIOFixed" CssClass="SubHead" runat="server" Text="Fixed$" /></td>
                                                    <td><asp:Label ID="lblIoDlr" CssClass="NormalBold" runat="server" Text="I/O Comm $" /></td>
                                                    <td class="DisplayNone"><asp:Label ID="lblNet" CssClass="NormalBold" runat="server" Text="Net$" /></td>
                                                </tr>
                                                <tr>
                                                    <td><asp:TextBox ID="txtIOPct" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:filteredtextboxextender id="fteIOPct" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIOPct" validchars="+-." /><asp:CompareValidator ID="valIOPct" runat="server" ControlToValidate="txtIOPct" Display="None" ErrorMessage="IO % cannot be more than  94%" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" ValueToCompare="94" /><act:validatorcalloutextender id="vlxIOPct" runat="Server" targetcontrolid="valIOPct" warningiconimageurl="~/images/red-error.gif" /></td>
                                                    <td nowrap>
                                                        <asp:CheckBox ID="chkIOFixed" resourcekey="chkIOFixed" CssClass="Normal" runat="server" AutoPostBack="True" /></td>
                                                    <td><asp:TextBox ID="txtIODlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:filteredtextboxextender id="fteIODlr" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtIODlr" validchars="+-." /></td>
                                                    <td class="DisplayNone"><asp:TextBox ID="txtNetIODlr" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:filteredtextboxextender id="fteNetIODlr" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtNetIODlr" validchars="+-." /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table id="tblDriver" runat="server" class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 255px">
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; Driver &nbsp;</caption>
                                    <tr>
                                        <td><asp:Label ID="lblDriverCode" runat="server" CssClass="NormalBold"></asp:Label></td>
                                        <td colspan="3"><asp:Label ID="lblDriverName" runat="server" CssClass="NormalBold"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblOverRide" runat="server" CssClass="NormalBold">%% OverRide</asp:Label></td>
                                        <td colspan="3"><asp:TextBox ID="txtCommRate" CssClass="NormalTextBox NumericTextBox" Columns="4" runat="server" /><act:filteredtextboxextender id="fteCommRate" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtCommRate" validchars="+-." />
                                            <asp:CheckBox ID="chkOOFixed" runat="server" AutoPostBack="True" CssClass="NormalBold" resourcekey="chkOOFixed" Checked="False" />
                                            <asp:RangeValidator ID="valCommRate" runat="server" ControlToValidate="txtCommRate" Display="None" ErrorMessage="Driver % has to be between 0 & 93" MaximumValue="93" MinimumValue="0" SetFocusOnError="True" Type="Double">
                                            </asp:RangeValidator><act:validatorcalloutextender id="vlxCommRate" runat="Server" targetcontrolid="valCommRate" warningiconimageurl="~/images/red-error.gif">
                                            </act:validatorcalloutextender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblDRTolls" CssClass="NormalBold" runat="server">Tolls To Driver</asp:Label></td>
                                        <td><asp:TextBox ID="txtDRTolls" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:filteredtextboxextender id="fteDRTolls" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtDRTolls" validchars="+-." />
                                        </td>
                                        <td><asp:Label ID="lblBase" CssClass="NormalBold" runat="server">$ Base</asp:Label></td>
                                        <td><asp:Label ID="lblDRCommBase" CssClass="NormalBold" runat="server">Driver<br/>Comm</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblDRMisc" CssClass="NormalBold" runat="server" Text="Misc To Driver" /></td>
                                        <td><asp:TextBox ID="txtDRMisc" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="4" /><act:filteredtextboxextender id="fteDRMisc" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtDRMisc" validchars="+-." />
                                        </td>
                                        <td><asp:TextBox ID="txtBaseOO" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" Columns="8" runat="server" ReadOnly="True" /></td>
                                        <td><asp:TextBox ID="txtDRCommBase" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="8" /><act:filteredtextboxextender id="fteDRCommBase" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtDRCommBase" validchars="+-." /><asp:ImageButton ID="imbDriver" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                            <asp:CompareValidator ID="valDRCommBase" runat="server" ControlToCompare="txtBase" ControlToValidate="txtDRCommBase" Display="None" ErrorMessage="Driver Commision should be Less than  Dollor Base" Operator="LessThanEqual" SetFocusOnError="True" Type="Double"></asp:CompareValidator><act:validatorcalloutextender id="vlxDRCommBase" runat="Server" targetcontrolid="valDRCommBase" warningiconimageurl="~/images/red-error.gif">
                                            </act:validatorcalloutextender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblOCommNeg" CssClass="NormalBold" runat="server" Text="Comm Adj" /></td>
                                        <td><asp:TextBox ID="txtOCommNeg" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /></td>
                                        <td><asp:Label ID="lblExmt" CssClass="NormalBold" runat="server" Text="Exmt" /></td>
                                        <td>
                                            <asp:CheckBox ID="chkAdminExempt" Enabled="false" CssClass="NormalTextBox" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table id="tblDriverDeduction" runat="server" width="100%">
                                                <tr>
                                                    <td colspan="4"><span class="jrctitletext">&nbsp; DriverDeduction &nbsp; </span></td>
                                                </tr>
                                                <tr>
                                                    <td class="DisplayNone"><asp:Label ID="lblDvrDedResn" CssClass="NormalBold" runat="server" Text="Reason For Carrier<br/>Deduction" /></td>
                                                    <td colspan="2" align="left"><asp:TextBox ID="txtDvrDedResn" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="12" TextMode="MultiLine" ReadOnly="True" /></td>
                                                    <td><asp:Label ID="lblDvrDedPct" CssClass="NormalBold" runat="server" Text="Ded %" /><br />
                                                        <asp:TextBox ID="txtDvrDedPct" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /> <asp:TextBox ID="txtOCommPlus" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="4" ReadOnly="True" /></td>
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
                                                &nbsp; Commission Split &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="DisplayNone" nowrap><dnn:label id="plSubOffComm" suffix=":" controlname="chkSubOffComm" runat="server" cssclass="SubHead" /></td>
                                        <td class="DisplayNone">
                                            <asp:CheckBox ID="chkSubOffComm" CssClass="Normal" runat="server" resourcekey="chkSubOffComm"></asp:CheckBox></td>
                                    </tr>
                                </table>
                                <table id="tblCommissionsSplit3" runat="server" style="width: 255px">
                                    <tr>
                                        <td colspan="4"><asp:Label ID="lblCommRecipient" CssClass="NormalBold" runat="server">CommRecipient</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="margin-left: 40px"><asp:TextBox ID="txtIOOffC3" CssClass="NormalTextBox" ReadOnly="true" runat="server" Columns="6" /> <asp:TextBox ID="txtIOOffN3" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lblCommAdmin" runat="server" CssClass="NormalBold">%% Comm</asp:Label></td>
                                        <td><asp:TextBox ID="txtIOAdmin3" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" runat="server" Columns="4"></asp:TextBox></td>
                                        <td><asp:Label ID="lblCommAmt" runat="server" CssClass="NormalBold">Comm $ Amt</asp:Label></td>
                                        <td><asp:TextBox ID="txtIOComm3" CssClass="NormalTextBox NumericTextBox" ReadOnly="true" runat="server" Columns="4"></asp:TextBox></td>
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
                            </td>
                        </tr>
                    </table>
                    
                    <table id="tblComCod" runat="server" class="boxdisplay">
                        <tr>
                            <td>
                                <table  id="tblComCheck" runat="server" style="width: 255px">
                                    <tr><td class="jrctitletext" colspan="2">&nbsp; Com Check &nbsp;</td></tr>
                                    <tr>
                                        <td class="SubHead"><dnn:Label ID="plComCheckSeq" ControlName="txtComCheckSeq" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtComCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                        <td class="SubHead"><dnn:Label ID="plComCheckAmt" ControlName="txtComCheckAmt" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtComCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteComCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtComCheckAmt" ValidChars="+-." /></td>
                                    </tr>
                                </table>
                                <table id="tblCodCheck" runat="server" style="width: 255px">
                                    <tr><td class="jrctitletext" colspan="2">&nbsp; Cod Check &nbsp;</td></tr>
                                    <tr>
                                        <td class="SubHead"><dnn:Label ID="plCodCheckSeq" ControlName="txtCodCheckSeq" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtCodCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                        <td class="SubHead"><dnn:Label ID="plCodCheckAmt" ControlName="txtCodCheckAmt" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtCodCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" /><act:FilteredTextBoxExtender ID="fteCodCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCodCheckAmt" ValidChars="+-." /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right" valign="top">
                    <table class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 160px">
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; Load Miles Calculator &nbsp;</caption>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblCalcMI" resourcekey="plCalcMI" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td class="SubHead" nowrap><asp:Label ID="lblCalcRate" resourcekey="plCalcRate" CssClass="SubHead" runat="server"></asp:Label></td>
                                        <td class="SubHead" align="right"><asp:Label ID="lblCalcTot" resourcekey="plCalcTot" CssClass="SubHead" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:TextBox ID="txtCalcMI" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="3" /><act:filteredtextboxextender id="fteCalcMI" runat="server" targetcontrolid="txtCalcMI" filtertype="Numbers" />
                                        </td>
                                        <td><asp:TextBox ID="txtCalcRate" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="3" AutoPostBack="True" /><act:filteredtextboxextender id="fteCalcRate" runat="server" targetcontrolid="txtCalcRate" filtertype="Numbers, Custom" validchars="+-." />
                                        </td>
                                        <td><asp:TextBox ID="txtCalcTot" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" runat="server" Columns="9" AutoPostBack="True" ReadOnly="True" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 160px">
                                    <caption style="text-align: left" class="jrctitletext">
                                        &nbsp; Sales Rep &nbsp;</caption>
                                    <tr>
                                        <td><asp:Label ID="lblRepNo" runat="server" CssClass="NormalBold" /></td>
                                        <td><asp:Label ID="lblRepName" runat="server" CssClass="NormalBold" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlRepNo" runat="server" CssClass="NormalTextBox" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" nowrap>
                                            <asp:CheckBox ID="chkRepFixed" CssClass="NormalBold" Checked="true" Text="Fixed$ ?" runat="server" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap><asp:Label ID="plRepPct" CssClass="NormalBold" runat="server" Text="Comm %" /></td>
                                        <td nowrap><asp:Label ID="plRepDlr" CssClass="NormalBold" runat="server" Text="Comm $" /></td>
                                    </tr>
                                    <tr>
                                        <td nowrap><asp:TextBox ID="txtRepPct" CssClass="NormalTextBox NumericTextBox" runat="server" Text="0" Columns="4" /><act:filteredtextboxextender id="fteRepPct" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtRepPct" validchars="+-." />
                                            <%--<asp:Label ID="lblRepPct" CssClass="NormalBold" runat="server" />--%>
                                        </td>
                                        <td nowrap><asp:TextBox ID="txtRepDlr" CssClass="NormalTextBox NumericTextBox" runat="server" Text="0" Columns="7" /><act:filteredtextboxextender id="fteRepDlr" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtRepDlr" validchars="+-." />
                                            <%--<asp:Label ID="lblRepDlr" CssClass="NormalBold" runat="server" />--%>
                                        </td>
                                    </tr>
                                </table>
                                <asp:CompareValidator ID="valRepPct" runat="server" ValueToCompare="5" ControlToValidate="txtRepPct" Display="None" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" ErrorMessage="Sales Rep % has to be between 0 & 5" /><act:validatorcalloutextender id="vlxRepPct" runat="Server" targetcontrolid="valRepPct" warningiconimageurl="~/images/red-error.gif" />
                                <asp:CompareValidator ID="valRepDlr" runat="server" ValueToCompare="100" ControlToValidate="txtRepDlr" Display="None" Operator="LessThanEqual" SetFocusOnError="True" Type="Double" ErrorMessage="Sales Rep Commision should be Less than 5% of Dollor Base" /><act:validatorcalloutextender id="vlxRepDlr" runat="Server" targetcontrolid="valRepDlr" warningiconimageurl="~/images/red-error.gif">
                                </act:validatorcalloutextender>
                            </td>
                        </tr>
                    </table>
                    <table class="boxdisplay">
                        <tr>
                            <td>
                                <table style="width: 160px">
                                    <%--<caption style="text-align: left" class="jrctitletext"> &nbsp; Load Accounting &nbsp;</caption>--%>
                                    <asp:Label ID="lblLoadType" Text="LoadAccounting" CssClass="jrctitletext" runat="server" /><tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblLoadID" resourcekey="plLoadID" CssClass="SubHead" runat="server"></asp:Label><br />
                                            <asp:HyperLink ID="hypLoadID" CssClass="SubHead" runat="server" />
                                                        <br /><asp:ImageButton ID="imbAbandon" ImageUrl="~/images/update_to_load.png" ToolTip="Abandon the changes and leave to LoadList" CssClass="CommandButton" BorderStyle="none" runat="server" CausesValidation="false" Visible="false" />
                                            </td>
                                        <td class="DisplayNone" nowrap><asp:HyperLink ID="hypLoadID1" ImageUrl="~/images/lt.gif" resourcekey="plLoadID" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
                                        <td class="SubHead" align="center">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <progresstemplate><br /><asp:Image ID="Image1" ImageUrl="~/images/dnnanim.gif" runat="server" />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                            <asp:ImageButton ID="imbMasterCalc1" ImageUrl="~/images/update_accounting.png" resourcekey="Calculate" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                                            <asp:LinkButton ID="cmdMasterCalc1" resourcekey="Calculate" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                            <asp:ImageButton ID="imbUpdateContinueEdit1" ImageUrl="~/images/update_and_edit.png" resourcekey="update_and_edit" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" /><br />
                                            <asp:LinkButton ID="lnbUpdateContinueEdit1" Text="Save & Continue" resourcekey="update_and_edit" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="SubHead" nowrap><asp:Label ID="lblBaseCalc" CssClass="jrctitletext" runat="server" Text="$ Base" /></td>
                                        <td class="SubHead" nowrap align="right"><asp:TextBox ID="txtBase" Columns="10" CssClass="NormalTextBox NumericTextBox ReadOnlyTextBox" Style="font-weight: bold; border: none; text-align: right;" runat="server" ReadOnly="True" /> <asp:ImageButton ID="imbBaseCalculate" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trAccountingSummary" runat="server">
                <td colspan="3">
                    <table width="100%" class="boxdisplay">
                        <tr>
                            <td align="right"><asp:Label ID="Label01" CssClass="NormalBold" runat="server" Text="Cust Billing">Cust Billing</asp:Label></td>
                            <td align="right"><asp:Label ID="lblIOComm" CssClass="NormalBold" runat="server" Text="I/O Comm">I/O Comm</asp:Label></td>
                            <td align="right"><asp:Label ID="lblIOAdmin" CssClass="NormalBold" runat="server" Text="I/O Admin">I/O Admin</asp:Label></td>
                            <td align="right"><asp:Label ID="lblExclusion" CssClass="NormalBold" runat="server" Text="Exclusion">Exclusion</asp:Label></td>
                            <td align="right"><asp:Label ID="lblRepDue" CssClass="NormalBold" runat="server" Text="Rep Due">Rep Due</asp:Label></td>
                            <td align="right"><asp:Label ID="lblCarrierDue" CssClass="NormalBold" runat="server" Text="Carrier Due">Carrier Due</asp:Label></td>
                            <td align="right"><asp:Label ID="lblAPcomm4" CssClass="NormalBold" runat="server" Text="Unbound">Unbound</asp:Label></td>
                            <td align="right"><asp:Label ID="lblAPcomm3" CssClass="NormalBold" runat="server" Text="Unbound">Unbound</asp:Label></td>
                            <td align="right" class="DisplayNone"><asp:Label ID="lblAPcomm2" CssClass="NormalBold" runat="server" Text="Unbound">Unbound</asp:Label></td>
                            <td align="right"><asp:Label ID="lblJRCOffComm" CssClass="NormalBold" runat="server" Text="Unbound">Unbound</asp:Label></td>
                            <td align="right"><asp:Label ID="lblJRCOnePct" CssClass="NormalBold" runat="server" Text="% Admin">% Admin</asp:Label></td>
                            <td align="right"><asp:Label ID="lblJRCTotal" CssClass="NormalBold" runat="server" Text="JRC Total">JRC Total</asp:Label></td>
                            <td align="right"><asp:Label ID="lblGPPct" CssClass="SubHead" Text="G/P %" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right"><asp:Label ID="txtCustBill" CssClass="SubHead" runat="server" Text="0.00" /></td>
                            <td align="right"><asp:Label ID="txtIOCommTot" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtIOAdminTot" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtExTot" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtRep" CssClass="SubHead" runat="server" Text="0.00" /></td>
                            <td align="right"><asp:Label ID="txtDRTotDue" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtAPComm4" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtAPComm3" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right" class="DisplayNone"><asp:Label ID="txtAPComm2" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtJRCOffComm" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtJRCOnePct" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtJRCTotal" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <td align="right"><asp:Label ID="txtGPPct" CssClass="SubHead" runat="server">0.00</asp:Label></td>
                            <%--
                            <td align="right"><asp:TextBox ID="txtJRCTotal" CssClass="SubHead" runat="server" Text="0.00" Columns="4" ReadOnly="true" Style="text-align: right; border: none" /><act:filteredtextboxextender id="fteJRCTotal" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtJRCTotal" validchars="+-." /></td>
                            <td align="right"><asp:TextBox ID="txtGPPct" CssClass="SubHead" runat="server" Text="0.000" Columns="4" ReadOnly="true" Style="text-align: right; border: none" /><act:filteredtextboxextender id="fteGPPct" runat="server" filtertype="Numbers, Custom" targetcontrolid="txtGPPct" validchars="+-." /></td>
                            --%>
                        </tr>
                        <tr style="display: none">
                            <td colspan="9"></td>
                            <td align="right"><asp:ImageButton ID="imbJrcTotal" runat="server" ImageUrl="~/images/accounting_small.png" Visible="False" />
                            </td>
                            <td align="right"></td>
                            <td align="right"></td>
                        </tr>
                        <tr>
                            <td colspan="13" align="right">
                                <asp:Label ID="errJRCTotal" EnableViewState="false" CssClass="NormalRed" runat="server" /><%--<asp:CompareValidator ID="valGPPct" runat="server" ControlToValidate="txtGPPct" Display="None" ErrorMessage="JRC Percentage should be greater than 4.80%" Operator="GreaterThanEqual" SetFocusOnError="True" Type="Double" ValueToCompare="4.80" /><act:validatorcalloutextender id="vlxGPPct" runat="Server" targetcontrolid="valGPPct" warningiconimageurl="~/images/red-error.gif"/>--%>
                            </td>
                        </tr>
                    </table>
                     <%--
                   <asp:CompareValidator ID="valGPPct1" runat="server" ControlToValidate="txtGPPct" Operator="GreaterThanEqual" ValueToCompare="4.80" Display="Dynamic" ErrorMessage="JRC Total is less than 4.80% of Dollor Base<br />You have three options: 1.Undo changes  2.Void Load  3.Correct your accounting" SetFocusOnError="True" Type="Double" CssClass="NormalRed" />
                   <asp:CompareValidator ID="valJRCTotal" runat="server" 
                        ControlToCompare="txtBase"
                        ControlToValidate="txtJRCTotal" 
                        Display="Dynamic" 
                        ErrorMessage="JRC Total should be greater than 4.85% of Dollor Base <br />You have three options: 1.Undo changes  2.Void Load  3.Correct your accounting"
                        Operator="GreaterThanEqual" 
                        SetFocusOnError="True" 
                        Type="Double"/>--%>
                </td>
            </tr>
        </table>
        <table>
            <tr style="display: none">
                <%--<td align="center"></td>--%>
                <td align="center" colspan="7">
                    <blink><marquee behavior="ALTERNATE" onmouseover="this.stop()" onmouseout="this.start()"><asp:Label ID="lblCalMsg" runat="server" Text="Remember to calculate every time you make a change" CssClass="NormalRed" /></marquee></blink>
                </td>
                <td align="center" colspan="2"></td>
            </tr>
            <%--<tr>
                <td align="center"></td>
                <td align="center" colspan="7"><asp:Label ID="lblJrctotalMsg" runat="server" Text="You have three options: 1.Undo changes  2.Void Load  3.Correct your accounting" CssClass="NormalRed" /></td>
                <td align="center" colspan="2"></td>
            </tr>--%>
            <tr>
                <%--<td align="center"></td>--%>
                <td align="center" colspan="6" class="jrcheadingtd"><span class="jrctitletext">&nbsp; Save Icons &nbsp; </span></td>
                <td></td>
                <td align="center" colspan="2" class="jrcheadingtd"><span class="jrctitletext">&nbsp; Cancel Icons &nbsp; </span></td>
            </tr>
            <tr>
                <td class="DisplayNone" align="center" valign="top" width="9%">
                    <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                        <progresstemplate>
                        <asp:Image ID="Image3" ImageUrl="~/images/dnnanim.gif" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>
                    <asp:ImageButton ID="imbMasterCalc" ImageUrl="~/images/update_accounting.png" resourcekey="Calculate" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                    <br />
                    <asp:LinkButton ID="cmdMasterCalc" resourcekey="Calculate" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbUpdateLoadsheet" ImageUrl="~/images/update_to_load.png" resourcekey="update_to_accounting" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbUpdateLoadsheet" Text="To Loadsheet" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbUpdateAddNew" ImageUrl="~/images/update_and_add.png" resourcekey="update_and_add" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbUpdateAddNew" Text="Add New" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbUpdateContinueEdit" ImageUrl="~/images/update_and_edit.png" resourcekey="update_and_edit" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbUpdateContinueEdit" Text="Save & Continue" resourcekey="update_and_edit" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbUpdateToList" ImageUrl="~/images/update_and_list.png" resourcekey="update_and_list" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbUpdateToList" Text="To List" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td style="display: none" class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbUpdateToViewer" ImageUrl="~/images/update_and_view.png" resourcekey="update_and_view" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbUpdateToViewer" Text="To Viewer" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbPrint" ImageUrl="~/images/print_this.png" resourcekey="print_this" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbPrint" resourcekey="print_this" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbPrintConfirm" ImageUrl="~/images/print_this.png" resourcekey="print_Confirm" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbPrintConfirm" resourcekey="print_Confirm" CssClass="CommandButton" BorderStyle="none" runat="server" />
                </td>
                <td class="DisplayNone" align="center" valign="top" width="9%"><asp:ImageButton ID="imbEmail" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" />
                    <br />
                    <asp:LinkButton ID="lnbEmail" Text="eMail" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" />
                </td>
                <td class="NormalBold" align="center" valign="top" width="9%"><asp:ImageButton ID="imbCopyLoad" ImageUrl="~/images/icon_lists_32px.gif" ToolTip="Copy, Convert or Template this Load" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" />
                    <br />
                    <asp:LinkButton ID="lnbCopyLoad" Text="Copy" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" ToolTip="Copy, Convert or Template this Load" />
                </td>
                <td align="center" class="NormalBold" valign="top" width="9%"><asp:ImageButton ID="imbVoidLoad" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" BorderStyle="none" CausesValidation="false" CssClass="CommandButton" ImageUrl="~/images/void_load.png" resourcekey="void_load" />
                    <br />
                    <asp:LinkButton ID="lnbVoidLoad" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" BorderStyle="none" CausesValidation="false" CssClass="CommandButton" Text="Void" />
                </td>
                <td align="center" class="NormalBold" valign="top" width="9%"><asp:ImageButton ID="imbCancelReload" runat="server" BorderStyle="none" CausesValidation="false" CssClass="CommandButton" ImageUrl="~/images/cancel_changes.png" resourcekey="cancel_changes" />
                    <br />
                    <asp:LinkButton ID="lnbCancelReload" runat="server" BorderStyle="none" CausesValidation="false" CssClass="CommandButton" Text="Undo Changes" />
                </td>
            </tr>
            <tr id="trIOeMail" runat="server">
                <td colspan="9" align="right">
                    <table>
                        <tr>
                            <td class="SubHead" valign="bottom"><dnn:label id="pleMailTo" text="eMail To" suffix=":" controlname="ddleMailTo" runat="server" cssclass="SubHead" /></td>
                            <td class="Normal" valign="bottom">
                                <asp:DropDownList ID="ddleMailTo" CssClass="NormalTextBox" runat="server" DataTextField="DispatchName" DataValueField="DispatchCode" />
                            </td>
                            <td class="Normal" valign="bottom"><asp:ImageButton ID="imbeMailTo" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
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
<p><Portal:audit id="ctlAudit" runat="server" /></p>
<p><Portal:tracking id="ctlTracking" runat="server" />
<p>
<table id="tblLoadAcctEdit" style="display: none" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="27"></td>
        <td class="Normal" height="27"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="22"></td>
        <td class="Normal" height="22"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDiscountDlr" cssclass="SubHead" runat="server" suffix=":" controlname="txtDiscountDlr"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDRRebur" cssclass="SubHead" runat="server" suffix=":" controlname="txtDRRebur"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtDRRebur" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDRPermits" cssclass="SubHead" runat="server" suffix=":" controlname="txtDRPermits"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtDRPermits" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPCommTot" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPCommTot"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCommTot" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="23"></td>
        <td class="Normal" height="23"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="12"></td>
        <td class="Normal" height="12"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="27"></td>
        <td class="Normal" height="27"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOOffC1" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOOffC1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffC1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOOffC2" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOOffC2"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffC2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOOffL3" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOOffL3"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffL3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOOffL4" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOOffL4"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOOffL4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="32"><dnn:label id="plBINC3" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC3"></dnn:label></td>
        <td class="Normal" height="32"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC4" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC4"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC5" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC5"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC6" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC6"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC7" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC7"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC8" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC8"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC9" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC9"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC10" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC10"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBINC11" cssclass="SubHead" runat="server" suffix=":" controlname="chkBINC11"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plJRCOffPct" cssclass="SubHead" runat="server" suffix=":" controlname="txtJRCOffPct"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCOffPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plJRCBkrPct" cssclass="SubHead" runat="server" suffix=":" controlname="txtJRCBkrPct"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCBkrPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="23"></td>
        <td class="Normal" height="23"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDCPCT" cssclass="SubHead" runat="server" suffix=":" controlname="txtDCPCT"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtDCPCT" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plONEPCT" cssclass="SubHead" runat="server" suffix=":" controlname="txtONEPCT"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtONEPCT" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDispPct" cssclass="SubHead" runat="server" suffix=":" controlname="txtDispPct"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtDispPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plDispDlr" cssclass="SubHead" runat="server" suffix=":" controlname="txtDispDlr"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtDispDlr" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOXPct1" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOXPct1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOXPct2" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOXPct2"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOXPct3" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOXPct3"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plIOXPct4" cssclass="SubHead" runat="server" suffix=":" controlname="txtIOXPct4"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtIOXPct4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plJRCAdminP" cssclass="SubHead" runat="server" suffix=":" controlname="txtJRCAdminP"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCAdminP" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffC1" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffC1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffC2" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffC2"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffC3" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffC3"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffC4" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffC4"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffC4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffN1" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffN1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffN2" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffN2"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffN3" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffN3"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPOffN4" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPOffN4"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPOffN4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPComm1" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPComm1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPComm1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPCPct1" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPCPct1"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct1" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPCPct2" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPCPct2"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct2" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPCPct3" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPCPct3"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct3" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAPCPct4" cssclass="SubHead" runat="server" suffix=":" controlname="txtAPCPct4"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAPCPct4" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAllowORide" cssclass="SubHead" runat="server" suffix=":" controlname="chkAllowORide"></dnn:label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAllowORide" resourcekey="chkAllowORide" CssClass="Normal" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plBType" cssclass="SubHead" runat="server" suffix=":" controlname="txtBType"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtBType" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plOCommNeg" cssclass="SubHead" runat="server" suffix=":" controlname="txtOCommNeg"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAlumaPct" cssclass="SubHead" runat="server" suffix=":" controlname="txtAlumaPct"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAlumaPct" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plAlumaDlrDisc" cssclass="SubHead" runat="server" suffix=":" controlname="txtAlumaDlrDisc"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtAlumaDlrDisc" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plGPPct" cssclass="SubHead" runat="server" suffix=":" controlname="txtGPPct"></dnn:label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plTPName" cssclass="SubHead" runat="server" suffix=":" controlname="txtTPName"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtTPName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plTPAmt" cssclass="SubHead" runat="server" suffix=":" controlname="txtTPAmt"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtTPAmt" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plTPDesc" cssclass="SubHead" runat="server" suffix=":" controlname="txtTPDesc"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtTPDesc" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plTPPaidDate" cssclass="SubHead" runat="server" suffix=":" controlname="txtTPPaidDate"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtTPPaidDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarTPPaidDate" resourcekey="Calendar" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plTPCkNo" cssclass="SubHead" runat="server" suffix=":" controlname="txtTPCkNo"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtTPCkNo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plJRC5050" cssclass="SubHead" runat="server" suffix=":" controlname="chkJRC5050"></dnn:label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkJRC5050" resourcekey="chkJRC5050" CssClass="Normal" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plCalc85" cssclass="SubHead" runat="server" suffix=":" controlname="chkCalc85"></dnn:label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCalc85" resourcekey="chkCalc85" CssClass="Normal" runat="server"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="29"></td>
        <td class="Normal" height="29"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:label id="plViewOrder" cssclass="SubHead" runat="server" suffix=":" controlname="txtViewOrder"></dnn:label></td>
        <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
</table>
