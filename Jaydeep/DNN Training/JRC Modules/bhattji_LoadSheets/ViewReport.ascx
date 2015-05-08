<%@ Control Language="VB" Inherits="bhattji.Modules.LoadSheets.ViewReport" CodeBehind="ViewReport.ascx.vb" AutoEventWireup="False" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table width="100%">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td nowrap>
                        <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" />
                            <asp:ListItem Value="OO" Text="Driver" resourcekey="Driver" />
                            <asp:ListItem Value="IO" Text="InterOffice" resourcekey="InterOffice" />
                            <asp:ListItem Value="BK" Text="Broker" resourcekey="Broker" />
                            <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />
                            <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />
                            <asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />
                            <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />
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
            </table>
       </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /></td>
                    <td nowrap><asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /></td>
                    <td nowrap><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" /></td>
                    <td nowrap><asp:Label ID="LoadStatus" Text="Load Status: " CssClass="SubHead" runat="server" /></td>
                    <td nowrap></td>
                </tr>
                <tr>
                    <td nowrap><asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink runat="server" ID="imgFrom" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                        <act:calendarextender id="calFrom" targetcontrolid="txtFrom" popupbuttonid="imgFrom" runat="server" format="d" />
                        &nbsp;</td>
                    <td nowrap><asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink runat="server" ID="imgTo" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                        <act:calendarextender id="calTo" targetcontrolid="txtTo" popupbuttonid="imgTo" runat="server" format="d" />
                   </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                   </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                            <asp:ListItem Value="" Text="<All Status>" Selected="True" />
                            <asp:ListItem Value="WIP" Text="WIP" />
                            <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
                            <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
                            <asp:ListItem Value="VOIDED" Text="VOIDED" />
                        </asp:DropDownList>
                   </td>
                    <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /> <asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<asp:GridView ID="gdvViewReport" DataSourceID="odsLoadSheets" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No LoadSheet Defined</center>" Visible="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <table>
                    <td><asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" resourcekey="Details" runat="server" Visible="false" /></td>
                    <td style="width: 16px"><asp:HyperLink ID="hypLoadReport" ImageUrl="~/images/file.gif" Target="_blank" resourcekey="LoadReport" runat="server" /></td>
                    <td style="width: 16px"><asp:HyperLink ID="hypPrintLoadReport" ImageUrl="~/images/synchronize.gif" Target="_blank" resourcekey="PrintLoadReport" runat="server" /></td>
                </table>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="LoadDate" DataField="LoadDate" SortExpression="LoadDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="LoadID" DataField="LoadID" SortExpression="LoadID" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:TemplateField HeaderText="Stat" SortExpression="Stat" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal">
            <ItemTemplate>
                <asp:Label ID="lblLoadStatus" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField HeaderText="OfficeCode" DataField="JRCIOfficeCode" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />--%>
        <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" SortExpression="CustomerName" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Dispatch" DataField="DispatchCode" SortExpression="DispatchCode" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:TemplateField HeaderText="load">
            <HeaderTemplate>
                <asp:Label ID="lblLoadTypeHead" Text="Name" ToolTip="Code" CssClass="jrctitletext" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblLoadTypeName" CssClass="Normal" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Type" DataField="LoadType" SortExpression="LoadType" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
    </Columns>
    <HeaderStyle CssClass="SubHead" Font-Bold="True" HorizontalAlign="Left" />
    <RowStyle CssClass="Normal" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="Normal" HorizontalAlign="Left" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsLoadSheets" runat="server" SelectMethod="GetLoadSheets" DeleteMethod="DeleteLoadSheet" TypeName="bhattji.Modules.LoadSheets.Business.LoadSheetsController" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadSheetInfo" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="LoadStatus" Type="String" DefaultValue="" />
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
<table align="right">
    <tr>
        <td><asp:HyperLink ID="hypSysInquiry" resourcekey="hypSysInquiry" ImageUrl="~/images/icon_help_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvSysInquiry", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypDrvCerti" resourcekey="hypDrvCerti" ImageUrl="~/images/icon_hostusers_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvDrvCerti", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport1" resourcekey="hypReport1" ImageUrl="~/images/icon_Vendors_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvSalesSummary", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport2Driver" resourcekey="hypReport2Driver" ImageUrl="~/images/icon_users_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvLoadStatusDriver", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport2Broker" resourcekey="hypReport2Broker" ImageUrl="~/images/icon_hostusers_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvLoadStatusBroker", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypLoadStatusReview" resourcekey="hypReport3" ImageUrl="~/images/icon_profile_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvLoadStatusReview", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypDriverStatus" resourcekey="hypDriverStatus" ImageUrl="~/images/icon_sql_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvDriverStatus", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypXmission" resourcekey="hypXmission" ImageUrl="~/images/icon_hostsettings_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvXmission", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypContainer" resourcekey="hypContainer" ImageUrl="~/images/icon_sitesettings_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "rvContainer", "Reports", "dnnprintmode=true") %>' Target="_blank" runat="server" /></td>
    </tr>
</table>
