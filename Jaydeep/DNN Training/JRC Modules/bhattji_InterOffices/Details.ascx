<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Details.ascx.vb" Inherits="bhattji.Modules.InterOffices.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<center>
<table>
    <tr>
        <td colspan="3">
            <table id="jrcmaintable" runat="server" class="boxdisplay">
                <tr>
                    <td class="jrctitletext">
                        &nbsp; JrcOfficeCode &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 470px">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plJRCIOfficeCode" CssClass="SubHead" runat="server" ControlName="txtJRCIOfficeCode"
                                        Suffix=":">
                                    </dnn:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plIOfficeCode" CssClass="SubHead" runat="server" ControlName="txtIOfficeCode"
                                        Suffix=":">
                                    </dnn:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plIOName" CssClass="SubHead" runat="server" ControlName="txtIOName"
                                        Suffix=":">
                                    </dnn:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plJRCActive" CssClass="SubHead" runat="server" ControlName="chkJRCActive"
                                        Suffix=":">
                                    </dnn:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <asp:Label ID="txtJRCIOfficeCode" CssClass="NormalBold" runat="server" Columns="10"
                                        MaxLength="9"></asp:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <asp:Label ID="txtIOfficeCode" CssClass="NormalBold" runat="server" Columns="8"
                                        MaxLength="7"></asp:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <asp:Label ID="txtIOName" CssClass="NormalBold" runat="server" />
                                </td>
                                <td class="SubHead" nowrap>
                                    <asp:Image ID="chkJRCActive" CssClass="Normal" resourcekey="chkJRCActive" runat="server" />
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
            <table id="tblIODetails" runat="server">
                <tr>
                    <td valign="top" align="left" nowrap>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; InterOffice Detail &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 250px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAbvrName" CssClass="SubHead" runat="server" ControlName="txtAbvrName"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtAbvrName" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAddressLine1" CssClass="SubHead" runat="server" ControlName="txtAddressLine1"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAddressLine1" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAddressLine2" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" valign="top">
                                                <dnn:Label ID="plCity" CssClass="SubHead" runat="server" ControlName="txtCity" Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtCity" CssClass="NormalBold" runat="server" Columns="25" /><br />
                                                <asp:Label ID="txtState" CssClass="NormalBold" runat="server" Columns="2" />/<asp:Label
                                                    ID="txtZipCode" CssClass="NormalBold" runat="server" Columns="4" />/<asp:Label
                                                        ID="txtCountryCode" CssClass="NormalBold" runat="server" Columns="6"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plCountryCode" CssClass="SubHead" runat="server" ControlName="txtCountryCode"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plPhoneNo" CssClass="SubHead" runat="server" ControlName="txtPhoneNo"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td class="SubHead" nowrap>
                                                <asp:Label ID="txtPhoneNo" CssClass="NormalBold" runat="server" Columns="16" /><asp:Label
                                                    ID="plExt" CssClass="SubHead" runat="server" Text="X" /><asp:Label ID="txtExt" CssClass="NormalBold"
                                                        runat="server" Columns="3" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plFaxNo" CssClass="SubHead" runat="server" ControlName="txtFaxNo"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtFaxNo" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plEmailAddress" CssClass="SubHead" runat="server" ControlName="txtEmailAddress"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtEmailAddress" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="DisplayNone">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plLogOnPW" CssClass="SubHead" runat="server" ControlName="txtLogOnPW"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtLogOnPW" CssClass="NormalBold" runat="server" Columns="25"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; SubOffComm &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 250px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plSubOffComm" Suffix=":" ControlName="chkSubOffComm" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkSubOffComm" CssClass="Normal" runat="server" resourcekey="chkSubOffComm" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAPCodeFM" Suffix=":" ControlName="txtAPCodeFM" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAPCodeFM" runat="server" CssClass="NormalBold" Columns="10"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAbvrNameFM" Suffix=":" ControlName="txtAbvrNameFM" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAbvrNameFM" runat="server" CssClass="NormalBold" Columns="20"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plCommRateFM" Suffix=":" ControlName="txtCommRateFM" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtCommRateFM" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="10" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plBKCommRateFM" Suffix=":" ControlName="txtBKCommRateFM" runat="server"
                                                    CssClass="SubHead" />
                                            </td>
                                            <td>
                                                <asp:Label ID="txtBKCommRateFM" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="10"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plBrokerOnly" CssClass="SubHead" runat="server" ControlName="chkBrokerOnly"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkBrokerOnly" CssClass="Normal" resourcekey="chkBrokerOnly" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plIntraOComm" Suffix=":" ControlName="chkIntraOComm" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkIntraOComm" CssClass="Normal" runat="server" resourcekey="chkIntraOComm" />
                                            </td>
                                        </tr>
                                        <tr class="DisplayNone">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plPASplit" Suffix=":" ControlName="chkPASplit" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkPASplit" CssClass="Normal" runat="server" resourcekey="chkPASplit" />
                                            </td>
                                        </tr>
                                        <tr class="DisplayNone">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plCommAdj" Suffix=":" ControlName="chkCommAdj" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkCommAdj" CssClass="Normal" runat="server" resourcekey="chkCommAdj" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAllowCDed" Suffix=":" ControlName="chkAllowCDed" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkAllowCDed" CssClass="Normal" runat="server" resourcekey="chkAllowCDed" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDvrDAcct1" Suffix=":" ControlName="txtDvrDAcct1" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDvrDAcct1" runat="server" CssClass="NormalBold" Columns="10"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" align="right" nowrap>
                        <table class="DisplayNone" class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; JrcActive &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr style="display: none">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDoABU" CssClass="SubHead" runat="server" ControlName="chkDoABU"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkDoABU" CssClass="Normal" resourcekey="chkDoABU" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="DisplayNone">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plXMissionSeq" CssClass="SubHead" runat="server" ControlName="chkXMissionSeq"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkXMissionSeq" CssClass="Normal" resourcekey="chkXMissionSeq" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="DisplayNone">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plWhatDivision" CssClass="SubHead" runat="server" ControlName="ddlWhatDivision"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="ddlWhatDivision" CssClass="NormalBold" runat="server" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; LoadAcct &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plGenCode" CssClass="SubHead" runat="server" ControlName="txtGenCode"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtGenCode" CssClass="NormalBold" runat="server" Columns="5" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plLoadAcct" CssClass="SubHead" runat="server" ControlName="txtLoadAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtLoadAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDiscAcct" CssClass="SubHead" runat="server" ControlName="txtDiscAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDiscAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDetenAcct" CssClass="SubHead" runat="server" ControlName="txtDetenAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDetenAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plTollsAcct" CssClass="SubHead" runat="server" ControlName="txtTollsAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTollsAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plFuelAcct" CssClass="SubHead" runat="server" ControlName="txtFuelAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFuelAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plDropAcct" CssClass="SubHead" runat="server" ControlName="txtDropAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDropAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plReconAcct" CssClass="SubHead" runat="server" ControlName="txtReconAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtReconAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plTarpAcct" CssClass="SubHead" runat="server" ControlName="txtTarpAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTarpAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plLumperAcct" CssClass="SubHead" runat="server" ControlName="txtLumperAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtLumperAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plUnloadAcct" CssClass="SubHead" runat="server" ControlName="txtUnloadAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtUnloadAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plAdminMiscAcct" CssClass="SubHead" runat="server" ControlName="txtAdminMiscAcct"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAdminMiscAcct" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; Xmission &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <p>
                                                    <dnn:Label ID="plTempFile1" CssClass="SubHead" runat="server" ControlName="txtTempFile1"
                                                        Suffix=":">
                                                    </dnn:Label>
                                                </p>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="txtTempFile1" CssClass="NormalBold" runat="server" Columns="13"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plLastXferDate" CssClass="SubHead" runat="server" ControlName="txtLastXferDate"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap colspan="2">
                                                <asp:Label ID="txtLastXferDate" CssClass="NormalBold" runat="server" Columns="10" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plLastXmission" CssClass="SubHead" runat="server" ControlName="txtLastXmission"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="txtLastXmission" CssClass="NormalBold" runat="server" Columns="13"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plXfer" CssClass="SubHead" runat="server" ControlName="txtXfer" Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="txtXfer" CssClass="NormalBold" runat="server" Columns="13"></asp:Label>
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
                                    &nbsp; LoadAcctB &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plLoadAcctB" CssClass="SubHead" runat="server" ControlName="txtLoadAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtLoadAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDiscAcctB" CssClass="SubHead" runat="server" ControlName="txtDiscAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDiscAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDetenAcctB" CssClass="SubHead" runat="server" ControlName="txtDetenAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDetenAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plTollsAcctB" CssClass="SubHead" runat="server" ControlName="txtTollsAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTollsAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plFuelAcctB" CssClass="SubHead" runat="server" ControlName="txtFuelAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFuelAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plDropAcctB" CssClass="SubHead" runat="server" ControlName="txtDropAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDropAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plReconAcctB" CssClass="SubHead" runat="server" ControlName="txtReconAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtReconAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plTarpAcctB" CssClass="SubHead" runat="server" ControlName="txtTarpAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtTarpAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plLumperAcctB" CssClass="SubHead" runat="server" ControlName="txtLumperAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtLumperAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plUnloadAcctB" CssClass="SubHead" runat="server" ControlName="txtUnloadAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtUnloadAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead">
                                                <dnn:Label ID="plAdminMiscAcctB" CssClass="SubHead" runat="server" ControlName="txtAdminMiscAcctB"
                                                    Suffix=":">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAdminMiscAcctB" CssClass="NormalBold" runat="server" ReadOnly="True"
                                                    Columns="8"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; UserInfo &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOONo" Suffix=":" ControlName="txtOONo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOONo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plBKNo" Suffix=":" ControlName="txtBKNo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtBKNo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAVNo" Suffix=":" ControlName="txtAVNo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAVNo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plNoOffChar" Suffix=":" ControlName="txtNoOffChar" runat="server"
                                                    CssClass="SubHead" />
                                            </td>
                                            <td>
                                                <asp:Label ID="ddlNoOffChar" CssClass="NormalBold" runat="server" /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOOLoadNo" Suffix=":" ControlName="txtOOLoadNo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOOLoadNo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plBKLoadNo" Suffix=":" ControlName="txtBKLoadNo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtBKLoadNo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plAVLoadNo" Suffix=":" ControlName="txtAVLoadNo" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAVLoadNo" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
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
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; Confirmation &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <table>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plConfName" Suffix=":" ControlName="txtConfName" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:Label ID="txtConfName" runat="server" CssClass="NormalBold" Columns="40"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plConfAddr" Suffix=":" ControlName="txtConfAddr" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:Label ID="txtConfAddr" runat="server" CssClass="NormalBold" Columns="40"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plConfSTZ" Suffix=":" ControlName="txtConfSTZ" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:Label ID="txtConfSTZ" runat="server" CssClass="NormalBold" Columns="40"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plConfPNo" Suffix=":" ControlName="txtConfPNo" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:TextBox ID="txtConfPNo" runat="server" CssClass="NormalBold" Columns="40" Rows="4" TextMode="MultiLine" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top">
                                                <table>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plBWordsA" Suffix=":" ControlName="txtBWordsA" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:TextBox ID="txtBWordsA" TextMode="MultiLine" Rows="4" Columns="40" runat="server" Enabled="false" CssClass="NormalBold" Text="DRIVER TO CALL 1-800-285-3323 FOR DISPATCH, DAILY WHILE ENROUTE, AND UPON COMPLETION OF DELIVERY" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plBWordsB" Suffix=":" ControlName="txtBWordsB" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:TextBox ID="txtBWordsB" TextMode="MultiLine" Rows="4" Columns="40" runat="server" Enabled="false" CssClass="NormalBold" Text="By signing this document the carrier agrees to all terms and conditions according to the broker / JRC contracts" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="SubHead" nowrap>
                                                            <dnn:Label ID="plBWordsC" Suffix=":" ControlName="txtBWordsC" runat="server" CssClass="SubHead">
                                                            </dnn:Label>
                                                            <asp:TextBox ID="txtBWordsC" TextMode="MultiLine" Rows="4" Columns="40" runat="server" Enabled="false" CssClass="NormalBold" Text="FOR  PROMPT PAYMENT, MAIL INVOICES ALONG WITH ORIGINAL PODS TO:     JRC TRANSPORTATION     PO BOX 1397     KENNEBUNK 04043     (EB # MUST APPEAR ON INVOICE)" />
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
                    <td id="tdConfirmation" runat="server" valign="top">
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; OfficeOR &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOfficeOR" Suffix=":" ControlName="chkOfficeOR" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkOfficeOR" CssClass="Normal" runat="server" resourcekey="chkOfficeOR" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOfficeORAcct" Suffix=":" ControlName="txtOfficeORAcct" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOfficeORAcct" runat="server" CssClass="NormalBold" Columns="10"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOfficeORPct" Suffix=":" ControlName="txtOfficeORPct" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOfficeORPct" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="10"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="boxdisplay">
                            <tr>
                                <td class="jrctitletext">
                                    &nbsp; CommRate &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 195px">
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plDivision" Suffix=":" ControlName="txtDivision" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtDivision" runat="server" CssClass="NormalBold" Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plStatus" Suffix=":" ControlName="chkStatus" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="chkStatus" CssClass="Normal" runat="server" resourcekey="chkStatus" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plCommRate" Suffix=":" ControlName="txtCommRate" runat="server" CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td nowrap>
                                                <asp:Label ID="txtCommRate" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plOfficePct" Suffix=":" ControlName="txtOfficePct" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtOfficePct" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="4"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="SubHead" nowrap>
                                                <dnn:Label ID="plBKOfficePct" Suffix=":" ControlName="txtBKOfficePct" runat="server"
                                                    CssClass="SubHead">
                                                </dnn:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtBKOfficePct" runat="server" CssClass="NormalBold NumericTextBox"
                                                    Columns="4"></asp:Label>
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
<table class="DisplayNone" class="boxdisplay">
    <tr>
        <td>
            <table id="tblNewIO" runat="server" cellspacing="0" cellpadding="2" summary="Basic Settings Design Table"
                border="0">
                <caption style="text-align: left" class="jrctitletext">
                    &nbsp; Create New InterOffice &nbsp;</caption>
                <tr>
                    <td class="SubHead" valign="top">
                        <dnn:Label ID="plTemplate" Text="Template:" runat="server" ControlName="cboTemplate">
                        </dnn:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="cboTemplate" CssClass="NormalBold" runat="server" AutoPostBack="True" /><br />
                        <asp:Label ID="lblTemplateDescription" runat="server" CssClass="Normal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plFirstName" Text="First Name:" runat="server" ControlName="txtFirstName">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtFirstName" Text="Jrc" CssClass="NormalBold" runat="server" MaxLength="100"
                            Columns="10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plLastName" Text="Last Name:" runat="server" ControlName="txtLastName">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtLastName" Text="Admin" CssClass="NormalBold" runat="server"
                            MaxLength="100" Columns="10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plUsername" Text="Username:" runat="server" ControlName="txtUsername">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtUsername" Text="JrcAdmin" CssClass="NormalBold" runat="server"
                            MaxLength="100" Columns="10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plPassword" Text="Password:" runat="server" ControlName="txtPassword">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtPassword" Text="jrcadmin" CssClass="NormalBold" runat="server" MaxLength="20" Columns="10" />
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plConfirm" Text="Confirm:" runat="server" ControlName="txtConfirm">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtConfirm" Text="jrcadmin" CssClass="NormalBold" runat="server" MaxLength="20" Columns="10" />
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plEmail" Text="Email:" runat="server" ControlName="txtEmail">
                        </dnn:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtEmail" Text="jrcadmin@jrctransportation.com" CssClass="NormalBold"
                            runat="server" MaxLength="100" Columns="10"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <p>
                            <asp:Label ID="lblMessage" CssClass="NormalRed" runat="server"></asp:Label><br>
                            <asp:DataList ID="lstResults" runat="server" CellPadding="4" CellSpacing="0" BorderWidth="0"
                                Visible="False" Width="100%">
                                <HeaderTemplate>
                                    <span class="NormalBold">Validation Results</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span class="Normal">
                                        <%# Container.DataItem %>
                                    </span>
                                </ItemTemplate>
                            </asp:DataList></p>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:LinkButton ID="cmdAddPortal" runat="server" resourcekey="cmdAddPortal" CssClass="CommandButton"
                            Text="AddPortal" BorderStyle="none"></asp:LinkButton>
                    </td>
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
    <Portal:audit id="ctlAudit" runat="server" /></p>
<p>
    <Portal:tracking id="ctlTracking" runat="server" /></p>

</center>