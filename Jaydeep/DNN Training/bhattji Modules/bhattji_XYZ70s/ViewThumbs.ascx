<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="ViewThumbs.ascx.cs" Inherits="bhattji.Modules.XYZ70s.ViewThumbs" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"  %>

<table id="tblSearch" width="100%" runat="server">
    <tr>
        <td nowrap colspan="2">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Title" Text="Title" ResourceKey="Title" />
                <asp:ListItem Value="Description" Text="Description" ResourceKey="Description" />
                <asp:ListItem Value="Details" Text="Details" ResourceKey="Details" />
                <asp:ListItem Value="ANY" Text="Any" ResourceKey="Any" Selected="True" />
            </asp:RadioButtonList></td>
        <td nowrap align="right">
            <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" ResourceKey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" ResourceKey="Contains" />
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td nowrap>
            <asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" ResourceKey="Calendar" runat="server" />&nbsp;
            
            <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" ResourceKey="Calendar" runat="server" /></td>
        <td nowrap >
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" CssClass="NormalTextBox" /><asp:HyperLink ID="hypEditCategory" runat="server" ImageUrl="~/images/action_settings.gif" ResourceKey="Edit" /></td>
        <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" ResourceKey="Search" /></td>
    </tr>
</table>

<%= GetMarquee() %><asp:DataList ID="lstViewThumbs" runat="server" 
    Summary="XYZ70 Thumbnails Design Table" RepeatColumns="5" GridLines="None" 
    Width="100%" CssClass="dnnGrid">  <%--DataSourceID="odsXYZ70s"--%>
    <ItemTemplate>
        <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" ResourceKey="Edit" runat="server" />
        <asp:HyperLink ID="hypTitle" CssClass="SubHead" runat="server" /><br />
        <asp:PlaceHolder ID="phtXYZ70Description" runat="server" /><br />
        <asp:HyperLink ID="hypRatings" runat="server" /><br />
        <asp:HyperLink ID="hypMoreLink" ResourceKey="MoreLink" runat="server" />
    </ItemTemplate>
    <ItemStyle CssClass="dnnGridItem" VerticalAlign="Top" />
    
    <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" Font-Bold="True" />
    
    <AlternatingItemStyle CssClass="dnnGridAltItem" VerticalAlign="Top" />
    <SelectedItemStyle CssClass="dnnFormError" />
    <EditItemStyle CssClass="dnnFormInput" />
    <FooterStyle CssClass="dnnGridFooter" />

</asp:DataList><%= GetMarqueeEnd() %>
<p><dnn:PagingControl id="PagingControl1" runat="server" /></p>

<asp:ObjectDataSource ID="odsXYZ70s" runat="server" />
