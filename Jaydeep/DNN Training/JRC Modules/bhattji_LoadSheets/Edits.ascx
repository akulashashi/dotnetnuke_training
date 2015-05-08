<%@ Control Language="vb" AutoEventWireup="False" Codebehind="Edits.ascx.vb" Inherits="bhattji.Modules.LoadSheets.Edits" %>
<asp:UpdateProgress ID="uprEditMain" runat="server">
    <progresstemplate>
    <table width="100%" class="UpdateProgressClass"><tr><td></td></tr></table>
        <center style="position:absolute;width:100%;height:1000px;vertical-align:middle;z-index:2000;"><asp:Image ID="imgUpdateProgress" ImageUrl="~/images/under_construction.gif" runat="server" Width="200" /><br /><asp:Image ID="Image5" ImageUrl="~/images/progressbar.gif" runat="server" Width="200" /></center>
    </progresstemplate>
</asp:UpdateProgress>
<asp:PlaceHolder ID="phtEdits" runat="server" />
<asp:UpdateProgress ID="uprEdits" runat="server">
    <progresstemplate>
        <center><asp:Image ID="imgProgress" ImageUrl="~/images/progressbar.gif" runat="server" /></center>
    </progresstemplate>
</asp:UpdateProgress>