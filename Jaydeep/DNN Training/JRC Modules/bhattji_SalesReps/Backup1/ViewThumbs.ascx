<%@ Control Language="c#" Inherits="bhattji.Modules.SalesReps.ViewThumbs" CodeBehind="ViewThumbs.ascx.cs" AutoEventWireup="true" Explicit="True" %>
<table id="tblSearch" width="100%" runat="server">
    <tr>
        <td nowrap colspan="2">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Title" Text="Title" resourcekey="Title" />
                <asp:ListItem Value="Description" Text="Description" resourcekey="Description" />
                <asp:ListItem Value="Details" Text="Details" resourcekey="Details" />
                <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
            </asp:RadioButtonList></td>
        <td nowrap align="right">
            <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td nowrap>
            <asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp;
            
            <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
        <td nowrap >
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" CssClass="NormalTextBox" /><asp:HyperLink ID="hypEditCategory" runat="server" ImageUrl="~/images/action_settings.gif" resourcekey="Edit" /></td>
        <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" resourcekey="Search" /></td>
    </tr>
</table>

<%= GetMarquee() %><asp:DataList ID="lstViewThumbs" runat="server" Summary="SalesRep Thumbnails Design Table" RepeatColumns="5" DataSourceID="odsSalesReps" GridLines="None" Width="100%">
    <ItemTemplate>
        <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" resourcekey="Edit" runat="server" />
        <asp:HyperLink ID="hypTitle" CssClass="SubHead" runat="server" /><br />
        <asp:PlaceHolder ID="phtSalesRepDescription" runat="server" /><br />
        <asp:HyperLink ID="hypRatings" runat="server" /><br />
        <asp:HyperLink ID="hypMoreLink" resourcekey="MoreLink" runat="server" />
    </ItemTemplate>
    <ItemStyle CssClass="Normal" />
</asp:DataList><%= GetMarqueeEnd() %>

<asp:ObjectDataSource ID="odsSalesReps" runat="server" />
