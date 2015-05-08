<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rptDriverStatus" Codebehind="rptDriverStatus.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblSearch" runat="server">
    <tr style="display: none">
        <td>
            <table width="100%">
                <tr>
                    <td nowrap>
                        <%--<asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="OO" Text="Driver" resourcekey="Driver" />
                            <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />
                            <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />
                            <asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />
                            <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />
                            <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
                        </asp:RadioButtonList>--%>
                        &nbsp;</td>
                    <%-- <td><asp:TextBox ID="txtOOSearch" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Button ID="btnOOSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" /></td>
                     <td><asp:DropDownList ID="ddlOOSearch" runat="server" AutoPostBack="True" /></td>--%>
                    <td nowrap class="SubHead"></td>
                    <td></td>
                    <td nowrap align="right">
                        <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                            <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
                        </asp:RadioButtonList></td>
                </tr>
            </table>
            <%--<asp:RangeValidator ID="valNoOfItems" runat="server" ControlToValidate="txtNoOfItems"
                Display="Dynamic" ErrorMessage="No of Records to be fetched, should be be between 1 & 1000"
                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" />--%>
       </td>
    </tr>
    <tr style="display: none">
        <td>
            <table width="100%">
                <tr>
                    <td nowrap style="display: none">
                        <asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />
                        <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink
                            ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png"
                            resourcekey="Calendar" runat="server" />&nbsp;
                        <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />
                        <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink
                            ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png"
                            resourcekey="Calendar" runat="server" /></td>
                    <td></td>
                    <td nowrap align="right">
                        <asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button
                            ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
                    <td nowrap align="right"></td>
                </tr>
            </table>
       </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rblDriverType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                            <asp:ListItem Value="OO" Text="Drivers" resourcekey="Drivers" />
                            <asp:ListItem Value="BK" Text="Brokers" resourcekey="Brokers" />
                            <asp:ListItem Value="ANY" Text="Both" resourcekey="Both" Selected="True" />
                        </asp:RadioButtonList></td>
                    <td nowrap id="tdNoOfItems" runat="server">
                    <table>
                    <tr>
                    <td><dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                    </tr>
                    </table>
                   </td>
                    <td align="right">
                        <asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" /><asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" /></td>
                    <td align="right" nowrap>
                        <asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" />
                       </td><td style="display:none"><asp:HyperLink id="hypClose" ImageUrl="~/images/cancel_changes.png" NavigateUrl="javascript:window.close();" ToolTip="Close this Window" CssClass="CommandButton" runat="server" /></td>
                        <td nowrap align="right" class="DisplayNone"><asp:HyperLink ID="hypDriverStatus" resourcekey="hypDriverStatus" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "DriverStatus", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" />
                       </td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<%--<h1 align="center">Driver Status Report</h1>--%>
<asp:GridView ID="gdvViewList" Caption="<h1>Driver Status Report</h1>" DataSourceID="odsLoadSheets" runat="server" AllowPaging="False"
    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="vertical"
    Width="100%" ShowFooter="True">
    <Columns>
        <asp:BoundField HeaderText="DriverName" DataField="DriverName" SortExpression="DriverName" />
        <%--<asp:BoundField HeaderText="DriverCode" DataField="DriverCode" SortExpression="DriverCode" />--%>
        <asp:BoundField HeaderText="LastPU" DataField="LastPU" SortExpression="LastPU" />
        <asp:BoundField HeaderText="LastDP" DataField="LastDP" SortExpression="LastDP" />
        <asp:TemplateField HeaderText="LastLoadID" SortExpression="LastLoadID">
            <ItemTemplate>
                <asp:HyperLink ID="hypLastLoadID" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="LastLoad" DataField="LastLoad" SortExpression="LastLoad" DataFormatString="{0:d}" HtmlEncode="False" />
       <asp:BoundField HeaderText="CellPhone" DataField="CellPhone" SortExpression="CellPhone" >
           <ItemStyle Wrap="False" />
       </asp:BoundField>
    </Columns>
    <EmptyDataTemplate>
        <p align="center" class="NormalRed">
            No Drivers Found</p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="SubHead" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
    <RowStyle CssClass="Normal" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="Normal" HorizontalAlign="Left" />
    <FooterStyle CssClass="GridFooter" Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsLoadSheets" runat="server" SelectMethod="GetReportDriverStatus"
    TypeName="bhattji.Modules.LoadSheets.Business.LoadSheetsController">
    <SelectParameters>
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="SortOn" Type="String" DefaultValue="DriverName" />
        <asp:Parameter Name="SortDesc" Type="Boolean" DefaultValue="False" />
        <%--<asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="SearchOn" Type="String" DefaultValue="Any" />
        <asp:Parameter Name="StartsWith" Type="Boolean" DefaultValue="true" />--%>
        <asp:Parameter Name="NoOfItems" Type="Int32" DefaultValue="100" />
        <asp:Parameter Name="FromDate" Type="String" DefaultValue="1/1/1" />
        <asp:Parameter Name="ToDate" Type="String" DefaultValue="12/12/2020" />
        <%--<asp:Parameter Name="ModuleId" Type="Int32" DefaultValue="-1" />
        <asp:Parameter Name="PortalId" Type="Int32" DefaultValue="-1" />--%>
        <asp:Parameter Name="GetItems" Type="Int32" DefaultValue="2" />
        <asp:Parameter Name="DriverType" Type="string" DefaultValue="Any" />
    </SelectParameters>
</asp:ObjectDataSource>