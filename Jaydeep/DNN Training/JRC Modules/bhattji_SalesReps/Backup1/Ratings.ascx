<%@ Control Language="c#" AutoEventWireup="true" Codebehind="Ratings.ascx.cs" Inherits="bhattji.Modules.SalesReps.Ratings" %>
<p><asp:label id="lblRatings" CssClass="SubHead" Runat="server" /></p>
<p><asp:radiobuttonlist id="rblRatings" CssClass="NormalBold" runat="server" /></p>
<table align="center">
    <tr>
        <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
            <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
        </td>
        <td id="tdCancel" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
            <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
        <td id="tdClose" class="SubHead" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" runat="server" CausesValidation="False" Visible="False" /><br />
            <asp:LinkButton ID="cmdClose" resourcekey="Close" CssClass="CommandButton" runat="server" CausesValidation="False" Visible="False" />
        </td>
    </tr>
</table>