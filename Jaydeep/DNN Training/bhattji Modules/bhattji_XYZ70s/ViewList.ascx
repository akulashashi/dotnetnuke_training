<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ViewList.ascx.cs" Inherits="bhattji.Modules.XYZ70s.ViewList" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<div id="divSearch" runat="server" style="width: 100%">
    <div class="dnnClear" style="width: 100%">
        <div class="dnnLeft" style="padding: 5px">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="dnnFormInput" runat="server" BackColor="Transparent" RepeatDirection="Horizontal">
                <asp:ListItem Value="Title" Text="Title" ResourceKey="Title" />
                <asp:ListItem Value="Description" Text="Description" ResourceKey="Description" />
                <asp:ListItem Value="Details" Text="Details" ResourceKey="Details" />
                <asp:ListItem Value="ANY" Text="Any" ResourceKey="Any" Selected="True" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnRight" style="padding: 5px">
            <asp:RadioButtonList ID="rblSearchType" CssClass="dnnFormInput" BackColor="Transparent" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" ResourceKey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" ResourceKey="Contains" />
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="dnnClear" style="width: 100%">
        <div class="dnnLeft" style="padding: 5px">
            <asp:Label ID="plFromDate" Text="From" runat="server" /><asp:TextBox ID="txtFrom" CssClass="dnnFormInput" runat="server" Columns="10" /><asp:HyperLink runat="server" ID="hypFrom" ImageUrl="~/images/calendar.png" Style="cursor: hand" /></div>
        <div class="dnnLeft" style="padding: 5px">
            <asp:Label ID="plToDate" Text="To" runat="server" /><asp:TextBox ID="txtTo" CssClass="dnnFormInput" runat="server" Columns="10" /><asp:HyperLink runat="server" ID="hypTo" ImageUrl="~/images/calendar.png" Style="cursor: hand" /></div>
        <div class="dnnRight" style="padding: 5px">
            <asp:TextBox ID="txtSearch" CssClass="dnnFormInput" runat="server" /><asp:Button ID="btnSearch" runat="server" ResourceKey="Search" /></div>
        <div class="dnnRight" style="padding: 5px">
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" CssClass="dnnFormInput" />
            <asp:HyperLink ID="hypEditCategory" runat="server" ImageUrl="~/images/action_settings.gif" ResourceKey="Edit" /></div>
    </div>
</div>
<%= GetMarquee() %><asp:GridView ID="gdvViewList" DataSourceID="odsXYZ70s" 
    runat="server" AllowPaging="True" AllowSorting="True" 
    AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" 
    EmptyDataText="<center class='NormalRed'>No XYZ70 Defined</center>" 
    CssClass="dnnGrid" BackColor="Transparent">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add.gif" ResourceKey="Add" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" ResourceKey="Edit" runat="server" />
                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" ResourceKey="cmdDelete" CommandName="Delete" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypTitle" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="RatingAverage">
            <ItemTemplate>
                <asp:HyperLink ID="hypRatings" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypPrint" ImageUrl="~/images/print.gif" ResourceKey="Print" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypMoreLink" ResourceKey="ReadMore" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <p class="NormalRed" align="center">No XYZ70 Defined<br />
            <asp:HyperLink ImageUrl="~/images/add.gif" NavigateUrl='<%# EditUrl() %>' ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /><asp:HyperLink NavigateUrl='<%# EditUrl() %>' ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /></p>
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