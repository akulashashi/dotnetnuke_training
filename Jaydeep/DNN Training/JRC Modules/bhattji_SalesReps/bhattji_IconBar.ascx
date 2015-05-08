<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="bhattji_IconBar.ascx.vb" Inherits=".bhattji_IconBar" %>
<table>
    <tr>
        <td id="tdAdd" class="SubHead" valign="bottom" runat="server">
            <asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
            <asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
        </td>
        <td id="tdUpdate" class="SubHead" valign="bottom" runat="server">
            <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
            <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
        </td>
        <td id="tdDelete" class="SubHead" valign="bottom" runat="server">
            <asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
        <td class="SubHead" valign="bottom">
            <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
        <td class="SubHead" valign="bottom">
            <asp:ImageButton ID="imbClose" ImageUrl="~/images/lt.gif" resourcekey="cmdClose" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:LinkButton ID="cmdClose" resourcekey="cmdClose" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
        <td id="tdPrint" class="SubHead" valign="bottom" runat="server">
            <asp:ImageButton ID="imbPrint" ImageUrl="~/images/print.gif" resourcekey="Print" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:LinkButton ID="cmdPrint" resourcekey="Print" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
        </td>
    </tr>
</table>