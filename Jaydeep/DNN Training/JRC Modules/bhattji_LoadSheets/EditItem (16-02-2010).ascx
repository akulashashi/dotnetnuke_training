<%@ Control Language="VB" AutoEventWireup="False" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.LoadSheets.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<center>
    <div id="menucenterloadedit">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="loadeditnav1">
            <tr>
                <td><img src="/images/superior_16.gif" width="10" height="44" /></td>
                <td width="100%" background="/images/superior_17.gif">
                    <table width="750" cellpadding="0" cellspacing="0" border="0">
                        <tr><td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbHome" Text="Home" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbHome" ImageUrl="~/images/home.png" resourcekey="lnbHome" BorderStyle="none" runat="server" /></td>
                            
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateAccounting" Text="Edit Accounting" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateAccounting" ImageUrl="~/images/update_to_accounting.png" resourcekey="update_to_accounting" BorderStyle="none" runat="server" /></td>
                            <td><img src="/images/superior_21.gif" width="2" height="30" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateAddNew" Text="Add Load" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateAddNew" ImageUrl="~/images/update_and_add.png" resourcekey="update_and_add" BorderStyle="none" runat="server" /></td>
                            <td><img src="/images/superior_21.gif" width="2" height="30" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateToList" Text="View Loads" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateToList" ImageUrl="~/images/update_and_list.png" resourcekey="update_and_list" BorderStyle="none" runat="server" /></td>
                            <td><img src="/images/superior_21.gif" width="2" height="30" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbPrint" resourcekey="print_this" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbPrint" ImageUrl="~/images/print_this.png" resourcekey="print_this" BorderStyle="none" runat="server" /></td>
                            <td><img src="/images/superior_21.gif" width="2" height="30" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbPrintConfirm" resourcekey="print_Confirm" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbPrintConfirm" ImageUrl="~/images/print_this.png" resourcekey="print_Confirm" BorderStyle="none" runat="server" /></td>
                            <td class="DisplayNone" align="center" valign="middle" width="32"><asp:LinkButton ID="lnbEmail" Text="eMail" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td class="DisplayNone" width="32"><asp:ImageButton ID="imbEmail" ImageUrl="~/images/email_this.png" resourcekey="email_this" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" height="30" /></td>
                            <td class="DisplayNone" align="center" valign="middle" width="32"><asp:LinkButton ID="lnbCopyLoad" Text="Copy" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" ToolTip="Copy, Convert or Template this Load" /></td>
                            <td class="DisplayNone" width="15"><asp:ImageButton ID="imbCopyLoad" ImageUrl="~/images/icon_lists_32px.gif" ToolTip="Copy, Convert or Template this Load" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" /></td>
                            <td valign="middle" class="NormalBold" id="tdVoid" runat="server">
                                <table width="66" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="32" valign="middle">
                                            <div align="right">
                                                <asp:LinkButton ID="lnbVoidLoad" Text="Void" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CausesValidation="false" />
                                            </div>
                                        </td>
                                        <td width="32" valign="middle"><asp:ImageButton ID="imbVoidLoad" ImageUrl="~/images/void_load.png" resourcekey="void_load" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CausesValidation="false" /></td>
                                        <td width="2"><img src="/images/superior_21.gif" width="2" height="30" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="middle" class="NormalBold" id="tdUnVoid" runat="server" visible="false">
                                <table width="66" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="32" valign="middle">
                                            <div align="right">
                                                <asp:LinkButton ID="inbUnVoidLoad" Text="UnVoid" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to UNVOID this Load ?')" runat="server" />
                                            </div>
                                        </td>
                                        <td width="32" valign="middle"><asp:ImageButton ID="imbUnVoidload" ImageUrl="~/images/arrowleft32.png" resourcekey="Unvoid_load" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to UNVOID this Load ?')" runat="server" /></td>
                                        <td width="2"><img src="/images/superior_21.gif" width="2" height="30" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td><img src="/images/superior_21.gif" width="2" height="25" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbCancelReload" Text="Undo" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbCancelReload" ImageUrl="~/images/cancel_changes.png" resourcekey="cancel_changes" BorderStyle="none" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td><img src="/images/superior_24.gif" width="10" height="44" /></td>
            </tr>
        </table>
    </div>
    <table id="tblLoads" width="100%" border="0">
        <tr>
            <td align="center" colspan="2">
                <table style="display: none" class="jrcskintable" width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="jrctoplefttd" style="height: 19px"></td>
                        <td class="jrctitletd" style="height: 19px"><span class="jrctitletext">&nbsp;<asp:Label ID="lblLoadType" Text="Loadsheet" CssClass="jrctitletext" runat="server" />&nbsp;</span></td>
                        <td class="jrctopslide" style="height: 19px"></td>
                        <td class="jrctoprighttd" width="23" style="height: 19px"></td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd"></td>
                        <td colspan="2"></td>
                        <td class="jrcrightslidetd" width="23" height="90"></td>
                    </tr>
                    <tr>
                        <td class="jrcbottomlefttd" height="19"></td>
                        <td class="jrcbottomslide" colspan="2" height="19"></td>
                        <td class="jrcbottomrighttd" width="23" height="19"></td>
                    </tr>
                </table>
                <table width="100%" class="boxdisplay">
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plLoadType" ControlName="ddlLoadType" Suffix=":" CssClass="SubHead" runat="server" />
                            <asp:DropDownList ID="ddlLoadType" CssClass="NormalTextBox" runat="server" Font-Size="Medium" ForeColor="Blue" Enabled="false" Style="display: none">
                                <asp:ListItem resourcekey="OO" Text="Driver" Value="OO" />
                                <asp:ListItem resourcekey="IO" Text="InterOffice" Value="IO" />
                                <asp:ListItem resourcekey="BK" Text="Broker" Value="BK" />
                            </asp:DropDownList>
                            <asp:Label ID="txtLoadType" CssClass="SubHead" Style="color: Blue; font-weight: bold; font-size: larger; border-width: 0;" runat="server" /></td>
                        <td class="SubHead"><dnn:Label ID="plLoadID" ControlName="txtLoadID" Suffix=":" CssClass="SubHead" runat="server" /><asp:Label ID="txtLoadID" CssClass="SubHead" Style="color: Blue; font-weight: bold; font-size: larger; border-width: 0;" runat="server" /><asp:HyperLink ID="hypLoadAccounting" runat="server" ImageUrl="~/images/accounting_small.png" CssClass="DisplayNone" /></td>
                        <td class="SubHead"><dnn:Label ID="plLoadDate" runat="server" ControlName="txtLoadDate" CssClass="SubHead" Suffix=":" /><asp:TextBox ID="txtLoadDate" runat="server" Columns="10" CssClass="NormalTextBox" Style="background-color: Red; color: White;" /><asp:Image runat="server" ID="imgLoadDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                            <act:CalendarExtender ID="calLoadDate" TargetControlID="txtLoadDate" PopupButtonID="imgLoadDate" runat="server" Format="d" />
                            <asp:RangeValidator ID="valLoadDate" runat="server" ControlToValidate="txtLoadDate" Display="None" ErrorMessage="<br>Load Date needs to be within range" MaximumValue="12/12/2020" MinimumValue="1/1/2000" Type="Date" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxLoadDate" runat="Server" TargetControlID="valLoadDate" WarningIconImageUrl="~/images/red-error.gif" />
                            <asp:RequiredFieldValidator ID="ReqLoadDate" runat="server" ErrorMessage="<br/>Must Select Load Date" ControlToValidate="txtLoadDate" InitialValue="" SetFocusOnError="True" Display="None" /><act:ValidatorCalloutExtender ID="vlxReqLoadDate" runat="Server" TargetControlID="ReqLoadDate" WarningIconImageUrl="~/images/red-error.gif" />
                        </td>
                        <td class="SubHead"><dnn:Label ID="plDeliveryDate" ControlName="txtDeliveryDate" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtDeliveryDate" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgDeliveryDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                            <act:CalendarExtender ID="calDeliveryDate" TargetControlID="txtDeliveryDate" PopupButtonID="imgDeliveryDate" runat="server" Format="d" />
                        </td>
                        <td class="SubHead" id="tdLoadStatus" runat="server"><dnn:Label ID="plLoadStatus" ControlName="ddlLoadStatus" Suffix=":" CssClass="SubHead" runat="server" />
                            <asp:UpdatePanel ID="upnlLoadStatus" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlLoadStatus" CssClass="NormalTextBox" runat="server" Font-Size="Medium" ForeColor="Blue" Enabled="false" Style="display: none">
                                        <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
                                        <asp:ListItem Value="WIP" Text="WIP" />
                                        <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
                                        <asp:ListItem Value="VOIDED" Text="VOIDED" />
                                    </asp:DropDownList>
                                    <asp:Label ID="txtLoadStatus" CssClass="SubHead" Style="font-weight: bold; font-size: larger; border-width: 0;" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="SubHead"><dnn:Label ID="plIsPrinted" ControlName="chkIsPrinted" Suffix=":" CssClass="SubHead" runat="server" />
                            <asp:Image ID="imgIsPrinted" CssClass="Normal" runat="server" resourcekey="imgIsPrinted" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="Normal" valign="top"></td>
                        <td class="Normal" valign="top"></td>
                        <td class="Normal" valign="top"></td>
                        <td class="Normal" valign="top"></td>
                        <td class="Normal" valign="top"><br />
                            <asp:LinkButton ID="lnbVoid" Text="Void" CssClass="DisplayNone" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CausesValidation="false" />
                        </td>
                        <td class="Normal" valign="top">
                            <asp:CheckBox ID="chkIsPrinted" CssClass="Normal" runat="server" resourcekey="chkIsPrinted" Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="50%">
                <table class="boxdisplay">
                    <tr>
                        <td>
                            <table id="tblCustomer" runat="server" style="width: 100%">
                                <tr>
                                    <td colspan="2" nowrap="nowrap" class="jrctitletext">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="25%" nowrap="nowrap" class="jrctitletext"><dnn:Label ID="plCustomerName" ControlName="txtCustomerName" Suffix=":" runat="server" /></td>
                                                <td width="75%" nowrap="nowrap" class="jrctitletext">
                                                    <asp:DropDownList ID="ddlCustomerNumber" columns="40" CssClass="NormalTextBox" runat="server" AutoPostBack="True" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" nowrap="nowrap" class="SubHead">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td nowrap="nowrap" class="SubHead"><dnn:Label ID="plCustomerNumber" ControlName="ddlCustomerNumber" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td nowrap="nowrap" class="SubHead"><asp:TextBox ID="txtCustomerName" Columns="40" CssClass="NormalTextBox" runat="server" /></td>
                                                <td nowrap="nowrap" class="SubHead"><asp:ImageButton ID="btnCustomerSearch" runat="server" ImageUrl="~/images/view.gif" CausesValidation="false" /></td>
                                                <td nowrap="nowrap" class="SubHead"><asp:TextBox ID="txtCustomerNumber" Columns="6" runat="server" CssClass="NormalTextBox" AutoPostBack="True" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap="nowrap" colspan="2"><asp:Label ID="lblCStatus" CssClass="NormalBold" runat="server" />
                                        <asp:RequiredFieldValidator ID="valCustomerNumber" runat="server" ErrorMessage="&lt;br/&gt;Must Select Valid Customer" ControlToValidate="ddlCustomerNumber" InitialValue="" SetFocusOnError="True" Display="None" />
                                        <act:ValidatorCalloutExtender ID="vlxCustomerNumber" runat="Server" TargetControlID="valCustomerNumber" WarningIconImageUrl="~/images/red-error.gif" />
                                        <asp:Label ID="lblCustomerChanged" runat="server" CssClass="NormalRed" Font-Bold="true" /></td>
                                </tr>
                                <tr>
                                    <td width="65%" valign="top" class="SubHead"><asp:Label ID="lblCustomer" CssClass="NormalBold" runat="server" /></td>
                                    <td width="35%" valign="top" class="SubHead"><dnn:Label ID="plCustPO" ControlName="txtCustPO" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtCustPO" CssClass="NormalTextBox" Columns="25" Style="background-color: #FFFFA0; color: #000000" runat="server" /> <br />
                                        <dnn:Label ID="plProJob" ControlName="txtProJob" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtProJob" CssClass="NormalTextBox" Columns="25" Style="background-color: #FFFFA0; color: #000000" runat="server" /></td>
                                </tr>
                                <tr style="display: none">
                                    <td nowrap="nowrap" colspan="2">
                                        <table width="100%">
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plRepNo" runat="server" CssClass="SubHead" Suffix=":" ControlName="ddlRepNo" /></td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlRepNo" runat="server" CssClass="NormalTextBox" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plRepDlrStd" ControlName="txtRepDlrStd" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td><asp:TextBox ID="txtRepDlrStd" runat="server" CssClass="NormalTextBox" Columns="6" ReadOnly="True" /></td>
                                                <td class="SubHead"><dnn:Label ID="plRepPctStd" ControlName="txtRepPctStd" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td><asp:TextBox ID="txtRepPctStd" runat="server" CssClass="NormalTextBox" Columns="6" ReadOnly="True" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plRepDlrM" ControlName="txtRepDlrM" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td><asp:TextBox ID="txtRepDlrM" runat="server" CssClass="NormalTextBox" Columns="6" ReadOnly="True" /></td>
                                                <td class="SubHead"><dnn:Label ID="plRepPctM" ControlName="txtRepPctM" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td><asp:TextBox ID="txtRepPctM" runat="server" CssClass="NormalTextBox" Columns="6" ReadOnly="True" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plDispatchCode" ControlName="txtDispatchCode" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td colspan="3"><asp:TextBox ID="txtDispatchCode" CssClass="NormalTextBox" runat="server" ReadOnly="true" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="boxdisplay" id="tblDriver" runat="server">
                    <tr>
                        <td>
                            <table width="100%">
                                <caption class="jrctitletext">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="46%"><dnn:Label ID="plDriverName" runat="server" CssClass="jrctitletext" Suffix=":" ControlName="txtDriverName" /></td>
                                            <td width="54%">
                                                <asp:DropDownList ID="ddlDriverCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True" />
                                            </td>
                                        </tr>
                                    </table>
                                </caption>
                                <tr style="display: none">
                                    <td class="SubHead" style="height: 40px"><dnn:Label ID="plDriverCode" runat="server" CssClass="SubHead" Suffix=":" ControlName="ddlDriverCode" /></td>
                                    <td style="height: 40px"><asp:TextBox ID="txtDriverName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><asp:Label ID="lblSafetyAuth" CssClass="NormalBold" runat="server" />
                                        <asp:RequiredFieldValidator ID="valDriverCode" runat="server" ControlToValidate="ddlDriverCode" ErrorMessage="&lt;b&gt;Invalid Driver&lt;/b&gt;&lt;br/&gt;Must Select Valid Driver" InitialValue="" SetFocusOnError="True" Display="None" />
                                        <act:ValidatorCalloutExtender ID="vlxDriverCode" runat="Server" TargetControlID="valDriverCode" WarningIconImageUrl="~/images/red-error.gif" />
                                        <asp:Label ID="lblDriver" runat="server" CssClass="NormalBold" /></td>
                                </tr>
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plAdminExempt" runat="server" CssClass="SubHead" Suffix=":" ControlName="chkAdminExempt" /></td>
                                    <td>
                                        <asp:CheckBox ID="chkAdminExempt" CssClass="Normal" runat="server" resourcekey="chkAdminExempt" />
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plOverrideComm" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtOverrideComm" /></td>
                                    <td><asp:TextBox ID="txtOverrideComm" runat="server" CssClass="NormalTextBox" Columns="8" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" class="boxdisplay" id="tblInterOffice" runat="server">
                    <tr>
                        <td>
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <caption style="text-align: left" class="jrctitletext">
                                    &nbsp; InterOffice &nbsp;
                                </caption>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plIOCode" runat="server" CssClass="SubHead" Suffix=":" ControlName="ddlIOCode" />
                                        <asp:DropDownList ID="ddlIOCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true" />
                                    </td>
                                    <td class="Normal" valign="top"><dnn:Label ID="plCanRecover" runat="server" ControlName="ddlCanRecover" Suffix=":" CssClass="SubHead" Text="Can Recover" />
                                        <asp:DropDownList ID="ddlCanRecover" DataValueField="DispatchCode" DataTextField="DispatchName" runat="server" CssClass="NormalTextBox" />
                                    </td>
                                    <td class="DisplayNone"><asp:ImageButton ID="imbEmailCanRecover" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="tblBroker" runat="server" class="boxdisplay" style="width: 100%">
                    <tr>
                        <td>
                            <table style="width: 100%">
                                <caption style="text-align: left" class="jrctitletext">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="38%" class="jrctitletext"><dnn:Label ID="plBrokerName" runat="server" Suffix=":" ControlName="txtBrokerName" /></td>
                                            <td width="62%"><span class="jrctitletext" style="text-align: left">
                                                <asp:DropDownList ID="ddlBrokerCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True" />
                                            </span></td>
                                        </tr>
                                    </table>
                                </caption>
                                <tr>
                                    <td width="100%" class="SubHead">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="18%"><dnn:Label ID="plBrokerCode" runat="server" CssClass="SubHead" Suffix=":" ControlName="ddlBrokerCode" /></td>
                                                <td width="50%"><asp:TextBox ID="txtBrokerName" runat="server" CssClass="NormalTextBox" Columns="32" /></td>
                                                <td width="6%"><asp:ImageButton ID="btnBrokerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                                                <td width="26%"><asp:TextBox ID="txtBrokerCode" runat="server" AutoPostBack="True" CssClass="NormalTextBox" Columns="6" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkShowPUInfo" runat="server" Text="Display pickup info on confirm?" CssClass="SubHead" />
                                    
                                        <act:ValidatorCalloutExtender ID="vlxBrokerCode" runat="Server" TargetControlID="valBrokerCode" WarningIconImageUrl="~/images/red-error.gif" />
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="57%" valign="top">
                                                    <asp:RequiredFieldValidator ID="valBrokerCode" runat="server" ErrorMessage="&lt;br/&gt;Must Select Valid Broker" ControlToValidate="ddlBrokerCode" InitialValue="" SetFocusOnError="True" Display="None" />
                                                    <asp:Label ID="lblBroker" runat="server" CssClass="NormalBold" />
                                                    <asp:Label ID="lblUpdateBroker" runat="server" CssClass="NormalRed" />
                                                    <asp:Label ID="lblBrokerNotes" runat="server" CssClass="NormalRed" />
                                                    </td>
                                                <td width="43%">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top"><span class="SubHead"><dnn:Label ID="plBkrDriverNo" ControlName="ddlBkrDriverNo" Suffix=":" CssClass="SubHead" runat="server" /></span></td>
                                                            <td valign="top"><span class="SubHead">
                                                                <asp:DropDownList ID="ddlBkrDriverNo" runat="server" CssClass="NormalTextBox">
                                                                    <asp:ListItem Value="ZXZX" Text="N/A" />
                                                                </asp:DropDownList>
                                                            </span></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top"><span class="SubHead"><dnn:Label ID="plBkrInvNo" ControlName="txtBkrInvNo" Suffix=":" CssClass="SubHead" runat="server" /></span></td>
                                                            <td valign="top"><span class="SubHead"><asp:TextBox ID="txtBkrInvNo" CssClass="NormalTextBox" runat="server" Columns="10" /> </span></td>
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
                <table width="100%" class="boxdisplay" id="tblComCod" runat="server" visible="false">
                    <tr>
                        <td>
                            <table width="415" style="width: 100%">
                                <tr>
                                    <td class="jrctitletext" colspan="2">Checks In / Out </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plComCheckSeq" ControlName="txtComCheckSeq" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtComCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                    <td class="SubHead"><dnn:Label ID="plComCheckAmt" ControlName="txtComCheckAmt" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtComCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" />
                                        <act:FilteredTextBoxExtender ID="fteComCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtComCheckAmt" ValidChars="+-." />
                                    </td>
                                </tr>
                            </table>
                            <table id="tblCodCheck" runat="server" style="width: 100%">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plCodCheckSeq" ControlName="txtCodCheckSeq" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtCodCheckSeq" CssClass="NormalTextBox" runat="server" /></td>
                                    <td class="SubHead"><dnn:Label ID="plCodCheckAmt" ControlName="txtCodCheckAmt" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtCodCheckAmt" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="7" />
                                        <act:FilteredTextBoxExtender ID="fteCodCheckAmt" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCodCheckAmt" ValidChars="+-." />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right" valign="top" width="50%">
                <table class="boxdisplay" width="100%">
                    <tr id="trLoadDelivery" runat="server">
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" id="tblLoadPUs" style="width: 375px" runat="server">
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plPUCityST" ControlName="txtPUCityST" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtPUCityST" CssClass="NormalTextBox" runat="server" ReadOnly="true" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:PlaceHolder ID="phtLoadPUs" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" id="tblLoadDrops" style="width: 375px" runat="server">
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plDPCityST" ControlName="txtDPCityST" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtDPCityST" CssClass="NormalTextBox" runat="server" ReadOnly="true" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:PlaceHolder ID="phtLoadDrops" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <table width="100%">
                    <tr>
                        <td align="left" valign="top" width="33%">
                            <table class="boxdisplay">
                                <tr>
                                    <td>
                                        <table cellspacing="1" cellpadding="1" border="0" style="width: 230px">
                                            <caption style="text-align: left" class="jrctitletext">
                                                &nbsp; Tarp/Trailer &nbsp;</caption>
                                            <tr style="display: none">
                                                <td class="SubHead"><dnn:Label ID="plTarpLoad" Text="Tarp" runat="server" CssClass="SubHead" Suffix=":" ControlName="chkTarpLoad" /></td>
                                                <td class="Normal"></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTarpMessage" ControlName="txtTarpMessage" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal" align="left">
                                                    <asp:CheckBox ID="chkTarpLoad" CssClass="Normal" runat="server" resourcekey="chkTarpLoad" AutoPostBack="true" />
                                                </td>
                                            </tr>
                                            <tr id="trTarpMessage" runat="server">
                                                <td align="left" colspan="2"><asp:TextBox ID="txtTarpMessage" CssClass="NormalTextBox" runat="server" Columns="40" /></td>
                                            </tr>
                                        </table>
                                        <table cellspacing="1" cellpadding="1" border="0" style="width: 230px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTrailerType" ControlName="ddlTrailerType" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal">
                                                    <asp:DropDownList ID="ddlTrailerType" CssClass="NormalTextBox" runat="server">
                                                        <asp:ListItem Value="" Text="" />
                                                        <asp:ListItem Value="FD" Text="Flatbed" />
                                                        <asp:ListItem Value="SD" Text="Stepdeck" />
                                                        <asp:ListItem Value="RG" Text="RGN" />
                                                        <asp:ListItem Value="DD" Text="Double Drop" />
                                                        <asp:ListItem Value="48" Text="Van 48'" />
                                                        <asp:ListItem Value="53" Text="Van 53'" />
                                                        <asp:ListItem Value="20" Text="20' container" />
                                                        <asp:ListItem Value="40" Text="40' container" />
                                                        <asp:ListItem Value="FT" Text="FT" />
                                                        <asp:ListItem Value="F" Text="F" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTrailerNumber" ControlName="txtTrailerNumber" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal"><asp:TextBox ID="txtTrailerNumber" CssClass="NormalTextBox" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTrailerDue" ControlName="txtTrailerDue" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal"><asp:TextBox ID="txtTrailerDue" Columns="10" CssClass="NormalTextBox" runat="server" /><asp:Image runat="server" ID="imgTrailerDue" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calTrailerDue" TargetControlID="txtTrailerDue" PopupButtonID="imgTrailerDue" runat="server" Format="d" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center" valign="top" width="33%">
                            <table class="boxdisplay">
                                <tr>
                                    <td>
                                        <table style="width: 220px">
                                            <caption style="text-align: left" class="jrctitletext">
                                                &nbsp;Load Note 60 Characters each &nbsp;</caption>
                                            <tr style="display: none">
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plLoadNotes" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtLoadNotes" /></td>
                                                <td align="center"><asp:TextBox ID="txtLoadNotes" runat="server" CssClass="NormalTextBox" Columns="1" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plLDNotesA" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtLDNotesA" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtLDNotesA" runat="server" CssClass="NormalTextBox" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plLDNotesB" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtLDNotesB" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtLDNotesB" runat="server" CssClass="NormalTextBox" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plLDNotesC" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtLDNotesC" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtLDNotesC" runat="server" CssClass="NormalTextBox" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plLDNotesD" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtLDNotesD" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtLDNotesD" runat="server" CssClass="NormalTextBox" Columns="35" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" valign="top" width="33%">
                            <table class="boxdisplay">
                                <tr>
                                    <td>
                                        <table style="width: 240px">
                                            <caption style="text-align: left" class="jrctitletext">
                                                &nbsp; Inv Comment 50 Characters each &nbsp;</caption>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plInvCommentA" ControlName="txtInvCommentA" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtInvCommentA" CssClass="NormalTextBox" Style="background-color: #FFFFA0; color: #000000" runat="server" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plInvCommentB" ControlName="txtInvCommentB" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtInvCommentB" CssClass="NormalTextBox" Style="background-color: #FFFFA0; color: #000000" runat="server" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plInvCommentC" ControlName="txtInvCommentC" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td align="center"><asp:TextBox ID="txtInvCommentC" CssClass="NormalTextBox" Style="background-color: #FFFFA0; color: #000000" runat="server" Columns="35" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" style="display: none"><dnn:Label ID="plInvCommentD" ControlName="txtInvCommentD" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                                <td class="Normal" align="center"><asp:TextBox ID="txtInvCommentD" CssClass="NormalTextBox" Style="background-color: #FFFFA0; color: #000000" runat="server" Columns="35" /></td>
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
            <td colspan="2">
                <div class="update">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="imgUpdateProgress1" ImageUrl="~/images/progressbar.gif" runat="server" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <table width="100%">
                    <tr id="trIOeMail" runat="server">
                        <td width="81%" align="right">
                            <table style="display: none">
                                <tr>
                                    <td nowrap class="SubHead" valign="bottom"><dnn:Label ID="pleMailTo" Text="eMail To" Suffix=":" ControlName="ddleMailTo" runat="server" CssClass="SubHead" /></td>
                                    <td nowrap class="Normal" valign="bottom">
                                        <asp:DropDownList ID="ddleMailTo" CssClass="NormalTextBox" runat="server" DataTextField="DispatchName" DataValueField="DispatchCode" AutoPostBack="True" />
                                    </td>
                                    <td nowrap class="Normal" valign="bottom"><asp:TextBox ID="txteMailTo" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valeMailTo" runat="server" ErrorMessage="Valid eMail required" CssClass="NormalRed" Display="None" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txteMailTo" /><act:ValidatorCalloutExtender ID="vlxeMailTo" runat="Server" TargetControlID="valeMailTo" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td nowrap class="Normal" valign="bottom"><asp:ImageButton ID="imbeMailTo" ImageUrl="~/images/email_this.png" resourcekey="email_this" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="javascript:return confirm('By sending this email, you agree that this load is final and complete. Are you Sure ?')" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p>
    <Portal:Audit ID="ctlAudit" runat="server" />
    <br />
    <Portal:Tracking ID="ctlTracking" runat="server" />
</center>
<script language="javascript" type="text/javascript">window.history.forward(1);</script>
<table id="tblLoads1" cellspacing="1" cellpadding="1" border="0">
    <tr id="trLoadDetails" style="display: none" runat="server">
        <td>
            <table cellspacing="1" cellpadding="1" border="0">
                <tr>
                    <td valign="top">
                        <table class="jrcskintable" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td class="jrctoplefttd"></td>
                                <td class="jrctitletd"><span class="jrctitletext">&nbsp; Sales Representative &nbsp;epresentative &nbsp;</span></td>
                                <td class="jrctopslide"></td>
                                <td class="jrctoprighttd"></td>
                            </tr>
                            <tr>
                                <td class="jrcleftslidetd"></td>
                                <td colspan="2"></td>
                                <td class="jrcrightslidetd"></td>
                            </tr>
                            <tr>
                                <td class="jrcbottomlefttd"></td>
                                <td class="jrcbottomslide" colspan="2"></td>
                                <td class="jrcbottomrighttd"></td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table style="display: none" class="jrcskintable" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td class="jrctoplefttd"></td>
                                <td class="jrctitletd"><span class="jrctitletext">&nbsp; Alert &nbsp;</span></td>
                                <td class="jrctopslide"></td>
                                <td class="jrctoprighttd"></td>
                            </tr>
                            <tr>
                                <td class="jrcleftslidetd" height="91"></td>
                                <td colspan="2" height="91">
                                    <table>
                                        <tr>
                                            <td class="SubHead"><dnn:Label ID="plOffFunds" ControlName="chkOffFunds" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                            <td class="Normal">
                                                <asp:CheckBox ID="chkOffFunds" CssClass="Normal" runat="server" resourcekey="chkOffFunds"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead"><dnn:Label ID="plOffOrgin" ControlName="chkOffOrgin" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                            <td class="Normal">
                                                <asp:CheckBox ID="chkOffOrgin" CssClass="Normal" runat="server" resourcekey="chkOffOrgin"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead"><dnn:Label ID="plBkrFunds" ControlName="chkBkrFunds" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                            <td class="Normal">
                                                <asp:CheckBox ID="chkBkrFunds" CssClass="Normal" runat="server" resourcekey="chkBkrFunds"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="jrcrightslidetd" height="91"></td>
                            </tr>
                            <tr>
                                <td class="jrcbottomlefttd"></td>
                                <td class="jrcbottomslide" colspan="2"></td>
                                <td class="jrcbottomrighttd"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trLoadDelivery1" runat="server">
        <td nowrap>
            <table cellspacing="1" cellpadding="1" border="0" width="100%">
                <tr>
                    <td valign="top"></td>
                    <td valign="top" align="right"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<p style="display: none">
<asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
    <asp:ListItem Value="Listing" resourcekey="Listing" />
    <asp:ListItem Value="NewItem" resourcekey="NewItem" />
    <asp:ListItem Value="EditItem" resourcekey="EditItem" />
    <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
    <asp:ListItem Value="Accounting" resourcekey="Accounting" />
</asp:DropDownList>
<br />
<asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp; <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
<asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />&nbsp; <span class="DisplayNone"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></span></p>
<table id="tblLoadSheetEdit" style="display: none">
    <tr>
        <td class="SubHead"><dnn:Label ID="plOfficeVendorNO" ControlName="txtOfficeVendorNO" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtOfficeVendorNO" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plJRCIOfficeCode" ControlName="txtJRCIOfficeCode" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtJRCIOfficeCode" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plOfficeCode" runat="server" CssClass="SubHead" Suffix=":" ControlName="txtOfficeCode" /></td>
        <td><asp:TextBox ID="txtOfficeCode" runat="server" CssClass="NormalTextBox" Width="116px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCompletedLoad" ControlName="chkCompletedLoad" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCompletedLoad" CssClass="Normal" runat="server" resourcekey="chkCompletedLoad"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCompletedDate" ControlName="txtCompletedDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtCompletedDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarCompletedDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plJRCIOCode" ControlName="txtJRCIOCode" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtJRCIOCode" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plIOName" ControlName="txtIOName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtIOName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDriverPct" ControlName="txtDriverPct" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDriverPct" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plFOB" ControlName="txtFOB" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtFOB" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead">&nbsp;</td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDispName" ControlName="txtDispName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDispName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDispOverride" ControlName="txtDispOverride" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDispOverride" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plRepName" ControlName="txtRepName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtRepName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLastUpdate" ControlName="txtLastUpdate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtLastUpdate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalenderLastUpdate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plXmissionSeq" ControlName="txtXmissionSeq" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtXmissionSeq" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDriverComm" ControlName="txtDriverComm" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDriverComm" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBrokerComm" ControlName="txtBrokerComm" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBrokerComm" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLoadWeight" ControlName="txtLoadWeight" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtLoadWeight" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLoadPieces" ControlName="txtLoadPieces" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtLoadPieces" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLoadMileage" ControlName="txtLoadMileage" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtLoadMileage" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plProNox" ControlName="txtProNox" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtProNox" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plXMissionFile" ControlName="txtXMissionFile" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtXMissionFile" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plXMissionDate" ControlName="txtXMissionDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtXMissionDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarXMissionDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plEntryDate" ControlName="txtEntryDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtEntryDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarEntryDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" height="28"></td>
        <td class="Normal" height="28"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plRepOverride" ControlName="txtRepOverride" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtRepOverride" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCorpTo" ControlName="txtCorpTo" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtCorpTo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBrokerType" ControlName="ddlBrokerType" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:DropDownList ID="ddlBrokerType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="##" Text="" resourcekey="" />
                <asp:ListItem Value="00" Text="00" resourcekey="00" />
                <asp:ListItem Value="07" Text="07" resourcekey="07" />
                <asp:ListItem Value="15" Text="15" resourcekey="15" />
                <asp:ListItem Value="30" Text="30" resourcekey="30" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plOfficePaid" ControlName="chkOfficePaid" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkOfficePaid" CssClass="Normal" runat="server" resourcekey="chkOfficePaid"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPDCkNo" ControlName="txtPDCkNo" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtPDCkNo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPDDate" ControlName="txtPDDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtPDDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarPDDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPDAmt" ControlName="txtPDAmt" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtPDAmt" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plReasonFor" ControlName="txtReasonFor" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtReasonFor" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBkrInvDate" ControlName="txtBkrInvDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBkrInvDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarBkrInvDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plIOAvail" ControlName="chkIOAvail" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkIOAvail" CssClass="Normal" runat="server" resourcekey="chkIOAvail"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plAcctNull" ControlName="txtAcctNull" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtAcctNull" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCNOfficeVendorNO" ControlName="txtCNOfficeVendorNO" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtCNOfficeVendorNO" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPUSEQ" ControlName="txtPUSEQ" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtPUSEQ" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDPSEQ" ControlName="txtDPSEQ" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDPSEQ" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plIsIODiv" ControlName="chkIsIODiv" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkIsIODiv" CssClass="Normal" runat="server" resourcekey="chkIsIODiv"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plOLPUDate" ControlName="txtOLPUDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtOLPUDate" CssClass="NormalTextBox" runat="server"></asp:TextBox><asp:HyperLink ID="cmdCalendarOLPUDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plOLNoStops" ControlName="txtOLNoStops" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtOLNoStops" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCarrierName" ControlName="txtCarrierName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtCarrierName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBkrIOName" ControlName="txtBkrIOName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBkrIOName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"><asp:TextBox ID="txtBkrDriverNo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBKDriver" ControlName="txtBKDriver" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBKDriver" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCommPaid" ControlName="chkCommPaid" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCommPaid" CssClass="Normal" runat="server" resourcekey="chkCommPaid"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLoadMo" ControlName="ddlLoadMo" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:DropDownList ID="ddlLoadMo" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Text="" resourcekey="" />
                <asp:ListItem Value="1" Text="Januaray" resourcekey="Januaray" />
                <asp:ListItem Value="2" Text="February" resourcekey="" />
                <asp:ListItem Value="3" Text="March" resourcekey="" />
                <asp:ListItem Value="4" Text="April" resourcekey="" />
                <asp:ListItem Value="5" Text="May" resourcekey="" />
                <asp:ListItem Value="6" Text="June" resourcekey="" />
                <asp:ListItem Value="7" Text="July" resourcekey="" />
                <asp:ListItem Value="8" Text="August" resourcekey="" />
                <asp:ListItem Value="9" Text="September" resourcekey="" />
                <asp:ListItem Value="10" Text="October" resourcekey="" />
                <asp:ListItem Value="11" Text="November" resourcekey="" />
                <asp:ListItem Value="12" Text="December" resourcekey="" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlLoadYR" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Text="" resourcekey="" />
                <asp:ListItem Value="2000" Text="2000" resourcekey="2000" />
                <asp:ListItem Value="2001" Text="2001" resourcekey="2001" />
                <asp:ListItem Value="2002" Text="2002" resourcekey="2002" />
                <asp:ListItem Value="2003" Text="2003" resourcekey="2003" />
                <asp:ListItem Value="2004" Text="2004" resourcekey="2004" />
                <asp:ListItem Value="2005" Text="2005" resourcekey="2005" />
                <asp:ListItem Value="2006" Text="2006" resourcekey="2006" />
                <asp:ListItem Value="2007" Text="2007" resourcekey="2007" />
                <asp:ListItem Value="2008" Text="2008" resourcekey="2008" />
                <asp:ListItem Value="2009" Text="2009" resourcekey="2009" />
                <asp:ListItem Value="2010" Text="2010" resourcekey="2010" />
                <asp:ListItem Value="2011" Text="2011" resourcekey="2011" />
                <asp:ListItem Value="2012" Text="2012" resourcekey="2012" />
                <asp:ListItem Value="2013" Text="2013" resourcekey="2013" />
                <asp:ListItem Value="2014" Text="2014" resourcekey="2014" />
                <asp:ListItem Value="2015" Text="2015" resourcekey="2015" />
                <asp:ListItem Value="2016" Text="2016" resourcekey="2016" />
                <asp:ListItem Value="2017" Text="2017" resourcekey="2017" />
                <asp:ListItem Value="2018" Text="2018" resourcekey="2018" />
                <asp:ListItem Value="2019" Text="2019" resourcekey="2019" />
                <asp:ListItem Value="2020" Text="2020" resourcekey="2020" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plLoadYR" ControlName="ddlLoadYR" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plCalc85" ControlName="chkCalc85" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCalc85" CssClass="Normal" runat="server" resourcekey="chkCalc85"></asp:CheckBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDvrDedPct" ControlName="txtDvrDedPct" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDvrDedPct" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDvrDedResn" ControlName="txtDvrDedResn" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtDvrDedResn" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plViewOrder" ControlName="txtViewOrder" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
</table>
<table id="tblLoadPUEdit" style="display: none" cellspacing="1" cellpadding="1">
    <tr>
        <td><dnn:Label ID="plSeq" ControlName="txtSeq" Suffix=":" CssClass="SubHead" runat="server" /></td>
    </tr>
    <tr>
        <td class="Normal"><asp:TextBox ID="txtSeq" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPRONo" ControlName="txtPRONo" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtPRONo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plPUState" ControlName="txtPUState" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
</table>
<table id="tblLoadDropEdit" style="display: none" cellspacing="1" cellpadding="1">
    <tr>
        <td><dnn:Label ID="plSeqLoadDrop" ControlName="txtSeqLoadDrop" Suffix=":" CssClass="SubHead" runat="server" /></td>
    </tr>
    <tr>
        <td class="Normal"><asp:TextBox ID="txtSeqLoadDrop" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plDPState" ControlName="txtDPState" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plJobno" ControlName="txtJobno" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtJobno" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBillOLay" ControlName="txtBillOLay" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBillOLay" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plBOLSeq" ControlName="txtBOLSeq" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtBOLSeq" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plEtime" ControlName="txtEtime" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
</table>
<table id="tblLoadPUs1" style="display: none">
    <tr>
        <td class="SubHead" width="105"><dnn:Label ID="plPUCity" ControlName="txtPUCity" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUCity" CssClass="NormalTextBox" runat="server" Width="80px"></asp:TextBox>&nbsp;/&nbsp; <asp:TextBox ID="txtPUState" CssClass="NormalTextBox" runat="server" Width="88px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="105"><dnn:Label ID="plPUName" ControlName="txtPUName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUName" CssClass="NormalTextBox" runat="server" Width="184px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="105"><dnn:Label ID="plPUAdd1" ControlName="txtPUAdd1" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUAdd1" CssClass="NormalTextBox" runat="server" Width="184px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="105"><dnn:Label ID="plPUContact" ControlName="txtPUContact" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUContact" CssClass="NormalTextBox" runat="server" Width="184px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="105"><dnn:Label ID="plPUTel" ControlName="txtPUTel" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUTel" CssClass="NormalTextBox" runat="server" Width="184px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="89"><dnn:Label ID="plPUDate" ControlName="txtPUDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td nowrap><asp:TextBox ID="txtPUDate" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox><asp:HyperLink ID="cmdCalendarPUDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" width="89"><dnn:Label ID="plPUTime" ControlName="txtPUTime" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPUTime" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="89"><dnn:Label ID="plWeight" ControlName="txtWeight" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtWeight" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="89"><dnn:Label ID="plPieces" ControlName="txtPieces" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtPieces" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="89"><dnn:Label ID="plMiles" ControlName="txtMiles" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtMiles" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
</table>
<table id="tblLoadDrops1" style="display: none">
    <tr>
        <td class="SubHead" width="124"><dnn:Label ID="plDPCity" ControlName="txtDPCity" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td nowrap><asp:TextBox ID="txtDPCity" CssClass="NormalTextBox" runat="server" Width="88px"></asp:TextBox>&nbsp;/&nbsp; <asp:TextBox ID="txtDPState" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
    <tr class="SubHead">
        <td width="124"><dnn:Label ID="plDPName" ControlName="txtDPName" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtDPName" CssClass="NormalTextBox" runat="server" Width="208px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="124"><dnn:Label ID="plDPAddr" ControlName="txtDPAddr" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtDPAddr" CssClass="NormalTextBox" runat="server" Width="208px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="124"><dnn:Label ID="plDPContact" ControlName="txtDPContact" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtDPContact" CssClass="NormalTextBox" runat="server" Width="208px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="124"><dnn:Label ID="plDPPhone" ControlName="txtDPPhone" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td><asp:TextBox ID="txtDPPhone" CssClass="NormalTextBox" runat="server" Width="208px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" width="125"><dnn:Label ID="plDPDate" ControlName="txtDPDate" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td valign="top"><asp:TextBox ID="txtDPDate" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox><asp:HyperLink ID="cmdCalendarDPDate" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" width="125"><dnn:Label ID="plStime" ControlName="txtStime" Suffix=":" CssClass="SubHead" runat="server" /></td>
        <td valign="top"><asp:TextBox ID="txtStime" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox><asp:TextBox ID="txtEtime" CssClass="NormalTextBox" runat="server" Width="100"></asp:TextBox></td>
    </tr>
</table>
