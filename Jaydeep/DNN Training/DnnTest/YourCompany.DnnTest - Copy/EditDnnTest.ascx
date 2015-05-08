<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDnnTest.ascx.cs" Inherits="YourCompany.Modules.DnnTest.EditDnnTest" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<table width="650" cellspacing="0" cellpadding="0" border="0" summary="Edit Table">

    <tr valign="top">
		<td class="SubHead" width="125"><dnn:Label id="lblTitle" runat="server" controlname="lblTitle" suffix=":"></dnn:Label></td>

        <td>
			<asp:TextBox id="txtTitle" runat="server" width="500" />
			
		</td>
	</tr>

    <tr valign="top">
		<td class="SubHead" width="125"><dnn:Label id="lblContent" runat="server" controlname="lblContent" suffix=":"></dnn:Label></td>

        <td>
			<dnn:texteditor id="txtContent" runat="server" height="200" width="500" />
			<asp:RequiredFieldValidator ID="valContent" resourcekey="valContent.ErrorMessage" ControlToValidate="txtContent"
				CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required" Runat="server" />
		</td>
	</tr>
</table>
<p>
    <asp:linkbutton cssclass="CommandButton" id="cmdUpdate" resourcekey="cmdUpdate" runat="server" borderstyle="none" text="Update" OnClick="cmdUpdate_Click"></asp:linkbutton>&nbsp;
    <asp:linkbutton cssclass="CommandButton" id="cmdCancel" resourcekey="cmdCancel" runat="server" borderstyle="none" text="Cancel" causesvalidation="False" OnClick="cmdCancel_Click"></asp:linkbutton>&nbsp;
    <asp:linkbutton cssclass="CommandButton" id="cmdDelete" resourcekey="cmdDelete" runat="server" borderstyle="none" text="Delete" causesvalidation="False" OnClick="cmdDelete_Click"></asp:linkbutton>&nbsp;
</p>
<dnn:Audit id="ctlAudit" runat="server" />
