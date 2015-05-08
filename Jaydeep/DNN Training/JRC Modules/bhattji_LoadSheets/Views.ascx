<%@ Control Language="vb" AutoEventWireup="False" Codebehind="Views.ascx.vb" Inherits="bhattji.Modules.LoadSheets.Views" %>
<asp:UpdateProgress ID="uprViewMain" runat="server">
    <progresstemplate>
    <table width="100%" class="UpdateProgressClass"><tr><td></td></tr></table>
        <center style="position:absolute;width:100%;height:1000px;vertical-align:middle;z-index:2000;"><asp:Image ID="imgUpdateProgress" ImageUrl="~/images/under_construction.gif" runat="server" Width="200" /><br /><asp:Image ID="Image5" ImageUrl="~/images/progressbar.gif" runat="server" Width="200" /></center>
    </progresstemplate>
</asp:UpdateProgress>
<asp:PlaceHolder ID="phtViews" runat="server" />
<asp:UpdateProgress ID="uprViews" runat="server">
<progresstemplate>
<center><asp:Image ID="imgProgress" ImageUrl="~/images/progressbar.gif" runat="server" /></center>
</progresstemplate>
</asp:UpdateProgress>