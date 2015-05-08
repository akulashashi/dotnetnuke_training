<%@ Control Language="c#" Inherits="bhattji.Modules.SalesReps.ViewJukes" Codebehind="ViewJukes.ascx.cs" AutoEventWireup="true" Explicit="True" %>
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

<%= GetMarquee() %><asp:GridView ID="gdvViewJukes" DataSourceID="odsSalesReps" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No SalesRep Defined</center>">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add.gif" resourcekey="Add" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
               <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" resourcekey="Edit" runat="server" />
               <asp:imagebutton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
               <table width="100%">
                    <tr>
                        <td Class="Normal" align="left">
                            <asp:HyperLink ID="hypThumb" CssClass="SubHead" runat="server" />
                            <asp:HyperLink ID="hypTitle" CssClass="SubHead" runat="server" />
                            <asp:HyperLink ID="hypRatings" runat="server" /></td>
                        <td Class="Normal" align="right">
                            <asp:HyperLink ID="hypMoreLink" runat="server" /></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>        
    </Columns>
    <EmptyDataTemplate>
        <p class="NormalRed" align="center">No SalesRep Defined<br />
        <asp:HyperLink ImageUrl="~/images/add.gif" NavigateUrl='<%# EditUrl() %>'  resourcekey="Add" Visible='<%# IsEditable %>' runat="server" /><asp:HyperLink NavigateUrl='<%# EditUrl() %>'  resourcekey="Add" Visible='<%# IsEditable %>' runat="server" /></p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
    <RowStyle CssClass="Normal" />
    <AlternatingRowStyle CssClass="Normal" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView><%= GetMarqueeEnd() %>

<asp:ObjectDataSource ID="odsSalesReps" runat="server" />
