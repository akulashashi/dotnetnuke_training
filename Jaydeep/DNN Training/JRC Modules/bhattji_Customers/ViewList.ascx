<%@ Control Language="c#" Inherits="bhattji.Modules.Customers.ViewList" Codebehind="ViewList.ascx.cs" AutoEventWireup="true" Explicit="True" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<table width="100%">
    <tr>
        <td colspan="2" Nowrap>
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                 <asp:ListItem Value="CustomerNumber" Text="CustomerNumber" resourcekey="CustomerNumber" />
                <asp:ListItem Value="CustomerName" Text="CustomerName" resourcekey="CustomerName" />
                <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
            </asp:RadioButtonList></td>
        <td align="right" Nowrap>
            <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
            </asp:RadioButtonList></td>
    </tr>
    <tr><td></td>
        <td Nowrap style="display:none">
            <asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgFrom" ImageUrl="~/images/calendar.png" style="cursor:hand"/>
            <act:CalendarExtender ID="calFrom" TargetControlID="txtFrom" PopupButtonID="imgFrom" Animated="true" runat="server" Format="d" />&nbsp;

            <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />
            <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgTo" ImageUrl="~/images/calendar.png" style="cursor:hand"/>
            <act:CalendarExtender ID="calTo" TargetControlID="txtTo" PopupButtonID="imgTo" runat="server" Format="d" /></td>
      <td>
            <asp:Label ID="plStateCode" Text="StateCode" CssClass="SubHead" runat="server" />
            <asp:DropDownList ID="ddlStateCode" runat="server" AutoPostBack="True" />
     </td>
        <td align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" resourcekey="Search" /></td>
    </tr>
</table>

<asp:GridView ID="gdvViewList" DataSourceID="odsCustomers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No Customer Defined</center>">
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
                <asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" resourcekey="Details"  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" SortExpression="CustomerName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		<asp:BoundField HeaderText="Customer#" DataField="CustomerNumber" SortExpression="CustomerNumber" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		
		<asp:BoundField HeaderText="Rep #" DataField="RepNo" SortExpression="RepNo" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		<asp:BoundField HeaderText="Rep Name" DataField="RepName" SortExpression="RepName" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		<asp:BoundField HeaderText="Rep %" DataField="RepPct" SortExpression="RepPct" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		<asp:BoundField HeaderText="Rep $" DataField="RepDlr" SortExpression="RepDlr" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		
		<%--<asp:BoundField HeaderText="Phone #" DataField="PhoneNumber" SortExpression="PhoneNumber" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />--%>
        <asp:TemplateField HeaderText="Phone #" SortExpression="PhoneNumber" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblPhoneNumber" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
		<asp:BoundField HeaderText="City" DataField="City" SortExpression="City" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />
		<asp:BoundField HeaderText="State" DataField="State" SortExpression="State" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left" />


    </Columns>
    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>

<asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="GetCustomers" DeleteMethod="DeleteCustomer" TypeName="bhattji.Modules.Customers.Business.CustomersController">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="StateCode" Type="String" DefaultValue="" />
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
