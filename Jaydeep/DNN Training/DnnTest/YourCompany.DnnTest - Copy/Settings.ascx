<%@ Control Language="C#" AutoEventWireup="false" Inherits="YourCompany.Modules.DnnTest.Settings" Codebehind="Settings.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="DnnTest Settings Design Table">
    <tr>
        <td class="SubHead" width="150"><dnn:label id="lblTemplate" runat="server" controlname="txtTemplate" suffix=":"></dnn:label></td>
        <td valign="bottom" >
            <asp:textbox id="txtTemplate" cssclass="NormalTextBox" width="390" columns="30" textmode="MultiLine" rows="10" maxlength="2000" runat="server" />
        </td>
    </tr>
</table>

