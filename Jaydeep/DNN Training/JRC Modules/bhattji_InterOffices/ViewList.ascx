<%@ Control Language="VB" Inherits="bhattji.Modules.InterOffices.ViewList" CodeBehind="ViewList.ascx.vb" AutoEventWireup="true" Explicit="True" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table width="100%">
    <tr>
        <td nowrap colspan="2">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="IOName" Text="IOName" resourcekey="IOName" />
                <asp:ListItem Value="JRCIOfficeCode" Text="JRCIOfficeCode" resourcekey="JRCIOfficeCode" />
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
        <td><asp:Button ID="btnScanProbDrivers" runat="server" resourcekey="btnScanProbDrivers" /></td>
        <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" resourcekey="Search" /></td>
    </tr>
</table>
<asp:GridView ID="gdvViewList" DataSourceID="odsInterOffices" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No InterOffice Defined</center>">
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
        <asp:BoundField HeaderText="JRCIOfficeCode" DataField="JRCIOfficeCode" SortExpression="JRCIOfficeCode" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="IOName" DataField="IOName" SortExpression="IOName" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        
        <asp:BoundField HeaderText="SubOffice#" DataField="APCodeFM" SortExpression="APCodeFM" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="SubOfficeName" DataField="AbvrNameFM" SortExpression="AbvrNameFM" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="DVR%" DataField="CommRateFM" SortExpression="CommRateFM" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="BKR%" DataField="BKCommRateFM" SortExpression="BKCommRateFM" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        
        <asp:BoundField HeaderText="Active" DataField="JRCActive" SortExpression="JRCActive" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="State" DataField="State" SortExpression="State" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
    </Columns>
    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsInterOffices" runat="server" SelectMethod="GetInterOfficesForGrid" DeleteMethod="DeleteInterOffice" TypeName="bhattji.Modules.InterOffices.Business.InterOfficesController">
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
