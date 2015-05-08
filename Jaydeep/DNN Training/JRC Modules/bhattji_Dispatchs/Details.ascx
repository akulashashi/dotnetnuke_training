<%@ Control Language="VB" AutoEventWireup="true" Codebehind="Details.ascx.vb" Inherits="bhattji.Modules.Dispatchs.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="DualList" Src="~/controls/DualListControl.ascx" %>
<center>
<table>
	<tr>
		<td vAlign="top">
		
            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; User &nbsp;</td>
                                </tr>
                <tr>
                    <td>
                        <table style="width:315px">
                            
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plDispatchCode" runat="server" suffix=":" controlname="txtDispatchCode" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtDispatchCode" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plDispatchName" runat="server" suffix=":" controlname="txtDispatchName" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtDispatchName" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plEmail" runat="server" suffix=":" controlname="txtEmail" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtEmail" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plOffice" runat="server" suffix=":" controlname="ddlOfficeOwner" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="lblOffice" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plCommRate" runat="server" suffix=":" controlname="txtCommRate" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtCommRate" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plDefDisp" runat="server" suffix=":" controlname="txtDefDisp" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtDefDisp" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plDispPassw" runat="server" suffix=":" controlname="txtDispPassw" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtDispPassw" runat="server" CssClass="NormalBold" Columns="10"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plStatus" runat="server" suffix=":" controlname="imgStatus" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:image id="imgStatus" CssClass="Normal" resourcekey="imgStatus" Runat="server"></asp:image></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plOffLogNo" runat="server" suffix=":" controlname="txtOffLogNo" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtOffLogNo" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plDOffLogNo" runat="server" suffix=":" controlname="txtDOffLogNo" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtDOffLogNo" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plClearCode" runat="server" suffix=":" controlname="imgClearCode" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:image id="imgClearCode" CssClass="Normal" resourcekey="imgClearCode" Runat="server"></asp:image></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plWhatProcess" runat="server" suffix=":" controlname="txtWhatProcess" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtWhatProcess" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plXMProc" runat="server" suffix=":" controlname="txtXMProc" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtXMProc" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
							<tr>
								<td class="SubHead" noWrap><dnn:label id="plViewOrder" runat="server" suffix=":" controlname="txtViewOrder" CssClass="SubHead"></dnn:label></td>
								<td class="Normal"><asp:label id="txtViewOrder" runat="server" CssClass="NormalBold"></asp:label></td>
							</tr>
                            
                        </table>
                    </td>
                </tr>
            </table>		
    		
            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; Assigned Offices &nbsp;</td>
                                </tr>
                <tr>
                    <td>
                        <table style="width:315px">
                            
                           <tr>
                    <td>
					<portal:duallist id="ctlDispatchIOs" runat="server" ListBoxWidth="130" ListBoxHeight="130" DataValueField="InterOfficeId"
							DataTextField="IOName"></portal:duallist>
							<asp:button id="btnUpdateIOs" runat="server" Text="Update Offices" Visible="false" UseSubmitBehavior="false"></asp:button></td>         
                           </tr> 
                        </table>
                    </td>
                </tr>
            </table>			
			
		</td>

	</tr>
</table>
<%--<asp:HyperLink id="hypImgClose1" ImageUrl="~/images/cancel_changes.png" resourcekey="Close" cssclass="CommandButton" runat="server" />--%>

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

<p><portal:audit id="ctlAudit" runat="server" /></p>
<p><portal:tracking id="ctlTracking" runat="server" /></p>
<table style="DISPLAY: none">
	<tr>
		<td class="SubHead" noWrap><dnn:label id="plAllowXM" runat="server" suffix=":" controlname="chkAllowXM" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkAllowXM" runat="server" CssClass="Normal" resourcekey="chkAllowXM"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="plLogonLink" runat="server" suffix=":" controlname="txtLogonLink" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="txtLogonLink" runat="server" CssClass="NormalBold"></asp:label></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="plLogDate" runat="server" suffix=":" controlname="txtLogDate" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="txtLogDate" runat="server" CssClass="NormalBold"></asp:label><asp:hyperlink id="cmdCalendarLogDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="plLogTime" runat="server" suffix=":" controlname="txtLogTime" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="txtLogTime" runat="server" CssClass="NormalBold"></asp:label></td>
	</tr>
</table>
</center>

<table style="DISPLAY: none">
	<tr>
		<td class="SubHead" noWrap><dnn:label id="Label1" runat="server" suffix=":" controlname="chkAllowXM" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="Checkbox1" runat="server" CssClass="Normal" resourcekey="chkAllowXM"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="Label2" runat="server" suffix=":" controlname="txtLogonLink" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="Label3" runat="server" CssClass="NormalBold"></asp:label></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="Label4" runat="server" suffix=":" controlname="txtLogDate" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="Label5" runat="server" CssClass="NormalBold"></asp:label><asp:hyperlink id="Hyperlink1" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead" noWrap><dnn:label id="Label6" runat="server" suffix=":" controlname="txtLogTime" CssClass="SubHead"></dnn:label></td>
		<td class="Normal"><asp:label id="Label7" runat="server" CssClass="NormalBold"></asp:label></td>
	</tr>
</table>