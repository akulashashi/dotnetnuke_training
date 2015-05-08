<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Details.ascx.cs" Inherits="bhattji.Modules.XYZ70s.Details" %>
<%@ Register TagPrefix="portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<table width="100%">
	<tr>
		<td align="left" colspan="2">
			<asp:HyperLink id="hypEditItem" ImageUrl="~/images/edit.gif" ResourceKey="Edit" runat="server" />
			<asp:HyperLink id="hypTitle" CssClass="SubHead" runat="server" /><br />
			<asp:HyperLink id="hypRatings" runat="server" /></td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:PlaceHolder id="phtXYZ70Description" runat="server" />
			<%--CreateViewUiControlStub--%>
			<asp:PlaceHolder id="phtXYZ70Details" runat="server" />
			<asp:HyperLink id="hypMoreLink" runat="server" />
		</td>
	</tr>
</table>
<div id="divButtons" runat="server" style="text-align:center">
    <ul class="dnnActions dnnClear">
        <li id="liEdit" runat="server"><asp:HyperLink ID="hypEdit" ResourceKey="Edit" CssClass="dnnPrimaryAction" runat="server" Visible="false" /></li>
        <li><asp:HyperLink ID="hypClose" ResourceKey="Close" CssClass="dnnPrimaryAction" runat="server" /></li>
        <li><asp:HyperLink ID="hypPrint" Target="_blank" ResourceKey="Print" CssClass="dnnSecondaryAction" runat="server" /></li>
    </ul>
</div>    
<p><portal:Audit id="ctlAudit" runat="server" /></p>
<p><portal:Tracking id="ctlTracking" runat="server" /></p>