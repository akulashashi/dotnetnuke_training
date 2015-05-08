<%@ Control Language="VB" Inherits="bhattji.Modules.Dispatchs.ViewList" CodeBehind="ViewList.ascx.vb" AutoEventWireup="true" Explicit="True" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table width="100%">
    <tr>
        <td nowrap colspan="2">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="DispatchName" Text="DispatchName" resourcekey="DispatchName" />
                <asp:ListItem Value="DispatchCode" Text="DispatchCode" resourcekey="DispatchCode" />
                <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
            </asp:RadioButtonList>
        </td>
        <td nowrap align="right">
            <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgFrom" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
            <act:CalendarExtender ID="calFrom" TargetControlID="txtFrom" PopupButtonID="imgFrom" Animated="true" runat="server" Format="d" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgTo" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
            <act:CalendarExtender ID="calTo" TargetControlID="txtTo" PopupButtonID="imgTo" runat="server" Format="d" /></td>
        <td nowrap align="right"><asp:Label ID="plJRCIOfficeCode" Text="JRCIOffice" CssClass="SubHead" runat="server" />
            <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
        </td>
        <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" resourcekey="Search" /></td>
    </tr>
</table>
<asp:GridView ID="gdvViewList" DataSourceID="odsDispatchs" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No Dispatch Defined</center>">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add.gif" resourcekey="Add" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" resourcekey="Edit" runat="server" /> <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" resourcekey="Details" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="DispatchCode" DataField="DispatchCode" SortExpression="DispatchCode" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="DispatchName" DataField="DispatchName" SortExpression="DispatchName" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Office" DataField="Office" SortExpression="Office" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Office Name" DataField="IOName" SortExpression="IOName" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        
        <asp:BoundField HeaderText="Account# Override" DataField="OfficeOverride" SortExpression="OfficeOverride" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Manager Name" DataField="ManagerOverride" SortExpression="ManagerOverride" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
                
        <asp:BoundField HeaderText="Override%" DataField="CommRate" SortExpression="CommRate" DataFormatString="{0:0.00}" HtmlEncode="False" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
    </Columns>
    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsDispatchs" runat="server" SelectMethod="GetDispatchs" DeleteMethod="DeleteDispatch" TypeName="bhattji.Modules.Dispatchs.Business.DispatchsController">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="SearchOn" Type="String" DefaultValue="Any" />
        <asp:Parameter Name="StartsWith" Type="Boolean" DefaultValue="true" />
        <asp:Parameter Name="NoOfItems" Type="Int32" DefaultValue="100" />
        <asp:Parameter Name="FromDate" Type="String" DefaultValue="1/1/1" />
        <asp:Parameter Name="ToDate" Type="String" DefaultValue="12/12/2020" />
        <asp:Parameter Name="ModuleId" Type="Int32" DefaultValue="-1" />
        <asp:Parameter Name="PortalId" Type="Int32" DefaultValue="-1" />
        <asp:Parameter Name="GetItems" Type="Int32" DefaultValue="2" />
    </SelectParameters>
</asp:ObjectDataSource>
