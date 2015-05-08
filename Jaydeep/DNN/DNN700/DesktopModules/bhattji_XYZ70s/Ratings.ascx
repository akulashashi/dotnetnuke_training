<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Ratings.ascx.cs" Inherits="bhattji.Modules.XYZ70s.Ratings" %>
<p><asp:label id="lblRatings" CssClass="SubHead" runat="server" /></p>
<p><asp:radiobuttonlist id="rblRatings" CssClass="NormalBold" runat="server" /></p>
<table align="center">
    <tr>
        <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" ResourceKey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
            <asp:LinkButton ID="cmdUpdate" ResourceKey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
        </td>
        <td id="tdCancel" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" ResourceKey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
            <asp:LinkButton ID="cmdCancel" ResourceKey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
        <td id="tdClose" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbClose" ImageUrl="~/images/lt.gif" ResourceKey="Close" CssClass="CommandButton" runat="server" CausesValidation="False" Visible="False" /><br />
            <asp:LinkButton ID="cmdClose" ResourceKey="Close" CssClass="CommandButton" runat="server" CausesValidation="False" Visible="False" />
        </td>
    </tr>
</table>