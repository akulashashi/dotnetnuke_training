<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCat.ascx.cs" Inherits="bhattji.Modules.XYZ70s.ViewCat" %>
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

<%= GetMarquee() %><asp:GridView ID="gdvViewCat" DataSourceID="odsXYZ70s" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No XYZ70 Defined</center>" CssClass="dnnGrid">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add.gif" ResourceKey="Add" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
               <asp:HyperLink id="hypEditItem" ImageUrl="~/images/edit.gif" ResourceKey="Edit" runat="server" />
               <asp:imagebutton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" ResourceKey="cmdDelete" CommandName="Delete" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                            <asp:PlaceHolder id="phtThumb" runat="server" /><br />
							<asp:HyperLink id="hypRatings" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
							<asp:HyperLink id="hypTitle" CssClass="SubHead" runat="server" /><br />
							<asp:PlaceHolder id="phtXYZ70Description" runat="server" />&nbsp;<asp:HyperLink id="hypMoreLink" CssClass="Normal" ResourceKey="ReadMore" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <p class="NormalRed" align="center">No XYZ70 Defined<br />
        <asp:HyperLink ID="HyperLink1" ImageUrl="~/images/add.gif" NavigateUrl='<%# EditUrl() %>'  ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /><asp:HyperLink ID="HyperLink2" NavigateUrl='<%# EditUrl() %>'  ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /></p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" Font-Bold="True" />
    <RowStyle CssClass="dnnGridItem" VerticalAlign="Top" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" VerticalAlign="Top" />
    <SelectedRowStyle CssClass="dnnFormError" />
    <EditRowStyle CssClass="dnnFormInput" />
    <PagerStyle CssClass="dnnGridPager" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
    <FooterStyle CssClass="dnnGridFooter" />
</asp:GridView><%= GetMarqueeEnd() %>

<asp:ObjectDataSource ID="odsXYZ70s" runat="server" />
