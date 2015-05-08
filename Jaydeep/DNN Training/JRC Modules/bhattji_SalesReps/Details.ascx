<%@ Control Language="VB" AutoEventWireup="true" Codebehind="Details.ascx.vb" Inherits="bhattji.Modules.SalesReps.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<center>
    <table id="jrcmaintable" class="boxdisplay">
        <tr>
            <td class="jrctitletext">
                &nbsp; Sales Representative &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table id="Table1" cellspacing="1" cellpadding="1" border="0">
                    <tr>
                        <td class="SubHead">
                            <dnn:Label ID="plRepNo" ControlName="txtRepNo" Suffix=":" CssClass="SubHead" runat="server" />
                        </td>
                        <td class="Normal">
                            <asp:Label ID="txtRepNo" CssClass="NormalBold" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead">
                            <dnn:Label ID="plRepName" ControlName="txtRepName" Suffix=":" CssClass="SubHead"
                                runat="server" />
                        </td>
                        <td class="Normal">
                            <asp:Label ID="txtRepName" CssClass="NormalBold" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead">
                            <dnn:Label ID="plRepRate" ControlName="txtRepRate" Suffix=":" CssClass="SubHead"
                                runat="server" />
                        </td>
                        <td class="Normal">
                            <asp:Label ID="txtRepRate" CssClass="NormalBold" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead">
                            <dnn:Label ID="plRepDollar" ControlName="txtRepDollar" Suffix=":" CssClass="SubHead"
                                runat="server" />
                        </td>
                        <td class="Normal">
                            <asp:Label ID="txtRepDollar" CssClass="NormalBold" runat="server" /></td>
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
                        <td colspan="2">
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
        <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
        <Portal:Tracking ID="ctlTracking" runat="server" />
    </p>
    <table style="display: none" id="Table2" cellspacing="1" cellpadding="1" border="1">
        <tr>
            <td>
                <dnn:Label CssClass="SubHead" ID="plViewOrder" runat="server" ControlName="txtViewOrder"
                    Suffix=":"></dnn:Label>
            </td>
            <td>
                <asp:Label CssClass="NormalBold" ID="txtViewOrder" runat="server"></asp:Label></td>
        </tr>
    </table>
</center>
