<%@ Control Language="VB" Inherits="bhattji.Modules.SalesPersons.ViewList" CodeBehind="ViewList.ascx.vb" AutoEventWireup="true" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table width="100%">
    <tr>
        <td nowrap colspan="3">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="DriverName" Text="DriverName" resourcekey="DriverName" />
                <asp:ListItem Value="DriverCode" Text="DriverCode" resourcekey="DriverCode" />
                <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
            </asp:RadioButtonList>
        </td>
<td><span class="Subhead">Legend&nbsp;<br /><img src="http://jrc2.jrcdispatch.com/images/greendot.gif" alt="ACTIVE" />ACTIVE <img src="http://jrc2.jrcdispatch.com/images/reddot.gif" alt="Inactive" />INACTICE <img src="http://jrc2.jrcdispatch.com/images/term_driver.gif" alt="Terminated" />TERMINATED</span>
        </span></td>
        <td colspan="3" nowrap align="right">
            <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td nowrap style="display: none"><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgFrom" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
            <act:calendarextender id="calFrom" targetcontrolid="txtFrom" popupbuttonid="imgFrom" animated="true" runat="server" format="d" />
            &nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgTo" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
            <act:calendarextender id="calTo" targetcontrolid="txtTo" popupbuttonid="imgTo" runat="server" format="d" />
        </td>
        <td class="SubHead">
            <dnn:Label ID="plStatus" runat="server" Suffix=":" CssClass="SubHead"></dnn:Label>
        </td>
        <td nowrap>
            <asp:RadioButtonList ID="rblStatus" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Value="N" Text="Active" resourcekey="Active" />
                <asp:ListItem Value="Y" Text="Inactive" resourcekey="Inactive" />
                <asp:ListItem Value="A" Text="All" resourcekey="All" Selected="True" />
            </asp:RadioButtonList>
        </td>
        <td nowrap><asp:Label ID="plTerminated" Text="Terminated" CssClass="SubHead" runat="server" /></td>
        <td nowrap>
            <asp:RadioButtonList ID="rblTerminated" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Value="T" Text="Terminated" resourcekey="Terminated" />
                <asp:ListItem Value="U" Text="Unterminated" resourcekey="Unterminated" />
                <asp:ListItem Value="A" Text="All" resourcekey="All" Selected="True" />
            </asp:RadioButtonList>        
        </td>
        <td nowrap align="right"><asp:Label ID="plJRCIOfficeCode" Text="JRCIOffice" CssClass="SubHead" runat="server" />
            <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" /><asp:Button ID="btnScanProbDrivers" runat="server" resourcekey="btnScanProbDrivers" />
        </td>
        <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" runat="server" resourcekey="Search" /></td>
    </tr>
</table>
<asp:GridView ID="gdvViewList" DataSourceID="odsSalesPersons" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No SalesPerson Defined</center>">
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
        <asp:BoundField HeaderText="Code" DataField="DriverCode" SortExpression="DriverCode" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="DriverName" DataField="DriverName" SortExpression="DriverName" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Account No" DataField="AccountNo" SortExpression="AccountNo" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField Visible="false" HeaderText="Office Owner" DataField="IOName" SortExpression="IOName" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        
        <asp:TemplateField HeaderText="Status" SortExpression="Status" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Image ID="imgStatus" ImageUrl="~/images/greendot.gif" CssClass="Normal" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>        
        <%--<asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />--%>
        
        <asp:BoundField HeaderText="SafetyAuth" DataField="SafetyAuth" SortExpression="SafetyAuth" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="State" DataField="State" SortExpression="State" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <%--
        <asp:BoundField HeaderText="Phone No" DataField="PhoneNo" SortExpression="PhoneNo" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        <asp:BoundField HeaderText="Cell No" DataField="CellPhone" SortExpression="CellPhone" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" />
        --%>
        <asp:TemplateField HeaderText="Phone No" SortExpression="PhoneNo" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false">
            <ItemTemplate>
                <asp:Label ID="lblPhoneNo" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cell No" SortExpression="CellPhone" ItemStyle-CssClass="Normal" HeaderStyle-CssClass="SubHead" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false">
            <ItemTemplate>
                <asp:Label ID="lblCellPhone" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
    <EmptyDataTemplate>
        <p class="NormalRed" align="center">
            No Driver Defined<br />
            <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="odsSalesPersons" runat="server" SelectMethod="GetSalesPersons" DeleteMethod="DeleteSalesPerson" TypeName="bhattji.Modules.SalesPersons.Business.SalesPersonsController">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="Status" Type="String" DefaultValue="A" />
        <asp:Parameter Name="Terminated" Type="String" DefaultValue="A" />
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
