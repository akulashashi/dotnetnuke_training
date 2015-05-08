<%@ Control Language="VB" AutoEventWireup="false" Inherits="bhattji.Modules.LoadSheets.jbMessageBox" Codebehind="jbMessageBox.ascx.vb" %>
<div class="container">
    <asp:Panel ID="MessageBox" runat="server">
        <asp:HyperLink runat="server" id="hypClose" ImageUrl="~/images/close.png" ToolTip="Click here to close this message" />
        <p><asp:Literal ID="ltrMessage" runat="server"/></p>
    </asp:Panel>
</div>