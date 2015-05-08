<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rptXmission" CodeBehind="rptXmission.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblSearch" runat="server">
    <tr>
        <td class="DisplayNone">
            <table width="100%">
                <tr>
                    <td nowrap align="left">
                        <table>
                            <tr>
                                <td class="SubHead"><asp:Label ID="lblCustomer" Text="Customer" CssClass="SubHead" runat="server" /></td>
                                <td><asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" /><asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><asp:Label ID="lblCustomerName" Text="CustomerName" CssClass="SubHead" runat="server" /></td>
                                <td>
                                    <asp:DropDownList ID="ddlCustomerNumber" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
                                        <asp:ListItem Value="" Text="<All Customers>" />
                                    </asp:DropDownList>
                               </td>
                            </tr>
                        </table>
                   </td>
                    <td class="SubHead"><asp:Label ID="LoadStatus" Text="Load Status: " CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                            <asp:ListItem Value="" Text="<All Status>" Selected="True" />
                            <asp:ListItem Value="WIP" Text="WIP" />
                            <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
                            <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
                        </asp:DropDownList>
                   </td>
                    <td nowrap align="left">
                        <table>
                            <tr>
                                <td nowrap>
                                    <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                                        <%--<asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" />--%>
                                        <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />
                                        <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />
                                        <%--<asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />
                                        <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />--%>
                                        <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
                                    </asp:RadioButtonList>
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                                        <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
                                    </asp:RadioButtonList>
                               </td>
                            </tr>
                        </table>
                   </td>
                </tr>
            </table>
       </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
                    <td nowrap id="tdNoOfItems" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" />
                               </td>
                                <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                   </td>
                    <td><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                   </td>
                    <td>
                        <asp:DropDownList ID="ddlXmissionFile" runat="server" AutoPostBack="True" />
                   </td>
                    <td nowrap align="right" class="DisplayNone"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /></td>
                    <td nowrap align="right"><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
                    <td nowrap align="right"><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                   </td>
                    <td nowrap colspan="2" align="right" class="DisplayNone"><asp:HyperLink ID="hyprptXmission" resourcekey="hyprptXmission" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<%--<h1 align="center">JRC Load Status Review</h1>--%>
<asp:GridView ID="gdvViewList" Caption="<h1>Xmission Report</h1>" DataSourceID="odsLoadSheets" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="vertical" Width="100%" ShowFooter="True">
    <Columns>
        <%--<asp:BoundField HeaderText="LoadID" DataField="LoadID" SortExpression="LoadID" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />--%>
        <asp:TemplateField HeaderText="LoadID" SortExpression="LoadID">
            <ItemTemplate>
                <asp:HyperLink ID="hypLoadID" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Load Date" DataField="LoadDate" SortExpression="LoadDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate" SortExpression="DeliveryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Customer PO" DataField="CustPO" SortExpression="CustPO" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Broker/Driver Name" DataField="CarrierName" SortExpression="CarrierName" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Load Type" DataField="LoadType" SortExpression="LoadType" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Bkr Type" DataField="BkrType" SortExpression="BkrType" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Bkr Inv" DataField="BkrInvNo" SortExpression="BkrInvNo" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="G/P %" DataField="GPPct" SortExpression="GPPct" DataFormatString="{0:0.00}" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Billing" DataField="BCustBill" SortExpression="BCustBill" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Office Comm" DataField="JRCOffComm" SortExpression="JRCOffComm" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <%--    <asp:TemplateField HeaderText="IO Load" SortExpression="IOOffL1" ItemStyle-CssClass="Normal" HeaderStyle-Cssclass="SubHead" HeaderStyle-HorizontalAlign="Left">
		<ItemTemplate>
    			<asp:Label ID="lblIOOffL1" CssClass="SubHead" runat="server"  />
		</ItemTemplate>
		</asp:TemplateField>--%>
        <asp:BoundField HeaderText="IO Load" DataField="IOOffL1" SortExpression="IOOffL1" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="XMission File" DataField="XMissionFile" SortExpression="XMissionFile" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="No" DataField="XCount" SortExpression="XCount" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <%--<asp:BoundField HeaderText="XMissionDate" DataField="XMissionDate" SortExpression="XMissionDate"
            DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />--%>
    </Columns>
    <EmptyDataTemplate>
        <p align="center" class="NormalRed">
            No Loads Found</p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="SubHead" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
    <RowStyle CssClass="Normal" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="Normal" HorizontalAlign="Left" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <FooterStyle CssClass="GridFooter" Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsLoadSheets" runat="server" SelectMethod="GetReportXmission" TypeName="bhattji.Modules.LoadSheets.Business.LoadSheetsController" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadSheetInfo">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="XmissionFile" Type="String" DefaultValue="" />
        <asp:Parameter Name="LoadStatus" Type="String" DefaultValue="" />
        <asp:Parameter Name="CustomerNumber" Type="String" DefaultValue="0000000" />
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
