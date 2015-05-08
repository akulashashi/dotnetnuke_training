<%@ Control Language="VB" AutoEventWireup="true" Codebehind="Details.ascx.vb" Inherits="bhattji.Modules.Brokers.Details" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<center>
    <table id="Table1" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td>
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">
                            &nbsp; BrokerCode &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:330px">
                                
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plBrokerCode" CssClass="SubHead" ControlName="txtBrokerCode" Suffix=":"
                                            runat="server"></dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtBrokerCode" CssClass="NormalBold" runat="server" Columns="8"></asp:Label></td>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plVendorRef" CssClass="SubHead" ControlName="txtVendorRef" Suffix=":"
                                            runat="server"></dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtVendorRef" CssClass="NormalBold" runat="server" Columns="9"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plBkrType" CssClass="SubHead" ControlName="txtBkrType" Suffix=":"
                                            runat="server"></dnn:Label>
                                        <td class="SubHead">
                                            <asp:Label ID="txtBkrType" CssClass="NormalBold" runat="server" Columns="8"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">
                            &nbsp; BrokerStatus &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:200px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plBStatus" CssClass="SubHead" ControlName="imgBStatus" Suffix=":"
                                            runat="server"></dnn:Label>
                                    </td>
                                    <td class="Normal">
                                        <asp:Image ID="imgBStatus" CssClass="Normal" runat="server" resourcekey="imgBStatus">
                                        </asp:Image></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">
                            &nbsp; BrokerID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:330px">
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plBrokerName" runat="server" Suffix=":" ControlName="txtBrokerName"
                                            CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="txtBrokerName" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plAddressLine1" runat="server" Suffix=":" ControlName="txtAddressLine1"
                                            CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="txtAddressLine1" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="txtAddressLine2" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plCity" runat="server" Suffix=":" ControlName="txtCity" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td nowrap>
                                        <asp:Label ID="txtCity" runat="server" CssClass="NormalBold" Columns="6"></asp:Label>&nbsp;/&nbsp;
                                        <asp:Label ID="txtState" runat="server" CssClass="NormalBold" Columns="9"></asp:Label>&nbsp;/
                                        <asp:Label ID="txtZipCode" runat="server" CssClass="NormalBold" Columns="6"></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plCountryCode" runat="server" Suffix=":" ControlName="txtCountryCode"
                                            CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtCountryCode" runat="server" CssClass="NormalBold"></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plPhoneNo" runat="server" Suffix=":" ControlName="txtPhoneNo" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtPhoneNo" runat="server" CssClass="NormalBold" Columns="10"></asp:Label>
                                        <asp:Label ID="plExt" runat="server" CssClass="SubHead" Text="Ext"></asp:Label>&nbsp;
                                        <asp:Label ID="txtExt" runat="server" CssClass="NormalBold" Columns="4"></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plFaxNo" runat="server" Suffix=":" ControlName="txtFaxNo" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtFaxNo" runat="server" CssClass="NormalBold"></asp:Label></td>
                                    <td class="SubHead" nowrap>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plEmailAddress" runat="server" Suffix=":" ControlName="txtEmailAddress"
                                            CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtEmailAddress" runat="server" CssClass="NormalBold"></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">
                            &nbsp; BrokerInformation &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width:200px">
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plDivision" runat="server" Suffix=":" ControlName="txtDivision" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtDivision" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plCommRate" runat="server" Suffix=":" ControlName="txtCommRate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtCommRate" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                            </table>
                            <table class="DisplayNone">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plAdminExempt" CssClass="SubHead" ControlName="imgAdminExempt" Suffix=":"
                                            runat="server"></dnn:Label>
                                    </td>
                                    <td class="Normal">
                                        <asp:Image ID="imgAdminExempt" CssClass="Normal" runat="server" resourcekey="imgAdminExempt">
                                        </asp:Image></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plStatus" CssClass="SubHead" ControlName="imgStatus" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td class="Normal">
                                        <asp:Image ID="imgStatus" CssClass="Normal" runat="server" resourcekey="imgStatus"></asp:Image></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plThirdPartyOK" CssClass="SubHead" ControlName="imgThirdPartyOK" Suffix=":"
                                            runat="server"></dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgThirdPartyOK" CssClass="Normal" runat="server" resourcekey="imgThirdPartyOK">
                                        </asp:Image></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plTPPct" runat="server" Suffix=":" ControlName="txtTPPct" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtTPPct" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plTPAmt" runat="server" Suffix=":" ControlName="txtTPAmt" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtTPAmt" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="jrctoplefttd">
                        </td>
                        <td class="jrctitletd">
                            <span class="jrctitletext">&nbsp; JrcTrailer &nbsp;</span></td>
                        <td class="jrctopslide">
                        </td>
                        <td class="jrctoprighttd">
                        </td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd">
                        </td>
                        <td colspan="2">
                            <table id="Table8" cellspacing="1" cellpadding="1" border="0">
                                <tr>
                                    <td class="SubHead" nowrap>
                                        <dnn:Label ID="plJRCTrailer" runat="server" Suffix=":" ControlName="txtJRCTrailer"
                                            CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="txtJRCTrailer" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td class="jrcrightslidetd">
                        </td>
                    </tr>
                    <tr>
                        <td class="jrcbottomlefttd">
                        </td>
                        <td class="jrcbottomslide" colspan="2">
                        </td>
                        <td class="jrcbottomrighttd">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="boxdisplay">
        <tr>
            <td class="jrctitletext">
                &nbsp; BrokerNotes &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="SubHead" nowrap>
                            <dnn:Label ID="plBrokerNotes" runat="server" Suffix=":" ControlName="txtBrokerNotes"
                                CssClass="SubHead"></dnn:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtBrokerNotes" runat="server" CssClass="NormalBold"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divButtons" runat="server">
        <center>
        <table>
            <tr>
                <td id="tdEdit" class="SubHead" align="center" valign="bottom" runat="server">
                    <asp:HyperLink ID="hypImgEdit" ImageUrl="~/images/edit.gif" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /><br />
                    <asp:HyperLink ID="hypEdit" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" />
                </td>
                <td class="SubHead" align="center" valign="bottom">
                    <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" runat="server" /><br />
                    <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" runat="server" />
                </td>
                <td class="SubHead" align="center" valign="bottom">
                    <asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                    <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" />
                </td>
            </tr>
        </table>
    </center>
    </div>
    <p>
        <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
        <Portal:Tracking ID="ctlTracking" runat="server" />
    </p>
</center>
<table style="display: none" cellspacing="0" cellpadding="0" border="0" id="Table2">
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plAddressLine2" CssClass="SubHead" ControlName="txtAddressLine2" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plState" CssClass="SubHead" ControlName="txtState" Suffix=":" runat="server"
                Columns="6" />
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plZipCode" CssClass="SubHead" ControlName="txtZipCode" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plContactCode" CssClass="SubHead" ControlName="txtContactCode" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="txtContactCode" CssClass="NormalBold" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="Label1" CssClass="SubHead" ControlName="txtAdminExempt" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="Textbox1" CssClass="NormalBold" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plLoadType" CssClass="SubHead" ControlName="txtLoadType" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="txtLoadType" CssClass="NormalBold" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plFavorite" CssClass="SubHead" ControlName="txtFavorite" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="txtFavorite" CssClass="NormalBold" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plSortSeq" CssClass="SubHead" ControlName="txtSortSeq" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="txtSortSeq" CssClass="NormalBold" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plCorpUpd" CssClass="SubHead" ControlName="txtCorpUpd" Suffix=":"
                runat="server" />
        </td>
        <td class="Normal">
            <asp:Label ID="txtCorpUpd" CssClass="NormalBold" runat="server" /><asp:HyperLink
                ID="cmdCalendarCorpUpd" ImageUrl="~/images/calendar.png" resourcekey="Calendar"
                CssClass="CommandButton" runat="server" Text="Calendar" /></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label CssClass="SubHead" ID="plViewOrder" runat="server" ControlName="txtViewOrder"
                Suffix=":"></dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label CssClass="NormalBold" ID="txtViewOrder" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
</table>
