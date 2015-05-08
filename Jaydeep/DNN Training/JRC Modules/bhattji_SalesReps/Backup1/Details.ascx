<%@ Control Language="c#" AutoEventWireup="true" Codebehind="Details.ascx.cs" Inherits="bhattji.Modules.SalesReps.Details" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<table width="100%">
	<tr>
		<td align="left" colspan="2">
			<asp:hyperlink id="hypEditItem" ImageUrl="~/images/edit.gif" resourcekey="Edit" runat="server" />
			<asp:hyperlink id="hypTitle" CssClass="SubHead" runat="server" /><br />
			<asp:hyperlink id="hypRatings" runat="server" /></td>
	</tr>
	<tr>
		<td class="Normal" colspan="2">
			<asp:placeholder id="phtSalesRepDescription" runat="server" />
			<asp:Label ID="lblActualFields" runat="server" />
			<asp:placeholder id="phtSalesRepDetails" runat="server" />
			<asp:hyperlink id="hypMoreLink" runat="server" />
		</td>
	</tr>
</table><div id="divButtons" runat="server">
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
<p><portal:audit id="ctlAudit" runat="server" /></p>
<p><portal:tracking id="ctlTracking" runat="server" /></p></div>
<asp:HyperLink ID="HyperLink12" runat="server">HyperLink</asp:HyperLink>
<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>