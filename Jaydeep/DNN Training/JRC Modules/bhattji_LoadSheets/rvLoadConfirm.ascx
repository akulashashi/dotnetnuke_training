<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvLoadConfirm" CodeBehind="rvLoadConfirm.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<center>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<asp:Label ID="lblMsg" runat="server" CssClass="NormalRed" EnableViewState="false" />
<asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="eMail needs to be in valid Format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
<table id="tblSearch" runat="server">
    <tr>
        <td class="style2"><strong>Email:</strong></td>
        <td><asp:TextBox ID="txtEmail" runat="server" CssClass="NormalTextBox" /></td>
    </tr>
    <tr>
        <td align="right" nowrap><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" CausesValidation="false" />
            <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" CausesValidation="false" /></td>
        <td class="SubHead" align="center" valign="bottom"><asp:ImageButton ID="imbEmailPdf" ImageUrl="~/images/email_this.png" resourcekey="email_this" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
            <asp:LinkButton ID="lnbEmailPdf" Text="eMail PDF" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="false" /></td>
        <td style="display: none"><asp:HyperLink ID="hypClose" ImageUrl="~/images/cancel_changes.png" NavigateUrl="javascript:window.close();" ToolTip="Close this Window" CssClass="CommandButton" runat="server" /></td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />
</center>