<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rptReport2Driver" CodeBehind="rptReport2Driver.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblSearch" runat="server">
    <tr>
        <td>
            <table>
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
                    <td nowrap>
                        <%--<asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="horizontal">
                            <asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" Selected="True" />
                            <asp:ListItem Value="DCODE" Text="DriverCode" />
                            <asp:ListItem Value="DCITY" Text="DriverCity" />
                            <asp:ListItem Value="DSTATE" Text="DriverState" />
                            <asp:ListItem Value="DSTATUS" Text="DriverStatus" />
                            <asp:ListItem Value="BN" Text="Broker" resourcekey="Broker" Selected="True" />
                            <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />
                            <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />
                            <asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />
                            <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />
                            <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
                        </asp:RadioButtonList>--%></td>
                    <td rowspan="2">
                        <table>
                            <tr>
                                <td align="right">
                                    <table id="tblDriver" runat="server">
                                        <tr>
                                            <td><asp:Label ID="lblDriver" Text="Driver" CssClass="SubHead" runat="server" /></td>
                                            <td><asp:TextBox ID="txtDriverCode" runat="server" CssClass="NormalTextBox" /><asp:ImageButton ID="btnDriverSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                                        </tr>
                                        <tr>
                                            <td><asp:Label ID="lblDriverName" Text="DriverName" CssClass="SubHead" runat="server" /></td>
                                            <td>
                                                <asp:DropDownList ID="ddlDriverCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
                                                    <asp:ListItem Value="" Text="<All Drivers>" />
                                                </asp:DropDownList>
                                                <asp:Label ID="lblDriverCode" runat="server" CssClass="NormalBold" /></td>
                                        </tr>
                                    </table>
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
            <table>
                <tr>
                    <td><asp:Label ID="LoadStatus" Text="Load Status: " CssClass="SubHead" runat="server" /></td>
                    <td class="SubHead">
                        <asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                            <asp:ListItem Value="" Text="<All Status>" Selected="True" />
                            <asp:ListItem Value="WIP" Text="WIP" />
                            <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
                            <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
                        </asp:DropDownList>
                   </td>
                    <td align="right"><asp:Label ID="Status" Text="Driver Status: " runat="server" CssClass="SubHead" /></td>
                    <td align="right" class="SubHead">
                        <asp:RadioButtonList ID="rblStatus" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                            <asp:ListItem Value="N" Text="Active" resourcekey="Active" Selected="True" />
                            <asp:ListItem Value="Y" Text="Inactive" resourcekey="Inactive" />
                            <asp:ListItem Value="A" Text="All" resourcekey="All" />
                        </asp:RadioButtonList>
                   </td>
                </tr>
            </table>
       </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
                    <td nowrap id="tdNoOfItems" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /></td>
                                <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                   </td>
                    <td align="left"><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                   </td>
                    <td nowrap align="left" style="display: none">
                        <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                            <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
                        </asp:RadioButtonList>
                   </td>
                    <td nowrap align="left" style="display: none"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
                    <td nowrap align="right"><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" />
                   </td>
                    <td nowrap align="right" class="DisplayNone"><asp:HyperLink ID="hypReport2Driver" resourcekey="hypReport2Driver" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<%--<h1 align="center">JRC Load Status By Driver Carrier</h1>--%>
<asp:GridView ID="gdvViewList" Caption="<h1>JRC Load Status By Driver Carrier</h1>" DataSourceID="odsLoadSheets" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="vertical" Width="100%" ShowFooter="True">
    <Columns>
        <asp:BoundField HeaderText="DriverStatus" DataField="Status" SortExpression="Status" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="LoadStatus" DataField="LoadStatus" SortExpression="LoadStatus" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="LoadID" DataField="LoadID" SortExpression="LoadID" />
        <asp:BoundField HeaderText="LoadDate" DataField="LoadDate" SortExpression="LoadDate" DataFormatString="{0:d}" HtmlEncode="False" />
        <asp:BoundField HeaderText="Deliv Date" DataField="DeliveryDate" SortExpression="DeliveryDate" DataFormatString="{0:d}" HtmlEncode="False" />
        <asp:BoundField HeaderText="Cust#" DataField="CustomerNumber" SortExpression="CustomerNumber" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" />
        <asp:BoundField HeaderText="Driver Name" DataField="CarrierName" SortExpression="CarrierName" />
        <asp:BoundField HeaderText="Miles" DataField="LoadMileage" SortExpression="LoadMileage" DataFormatString="{0:#,#}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField HeaderText="Carrier $" DataField="DRTotDue" DataFormatString="{0:n}" HtmlEncode="False" SortExpression="DRTotDue" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField HeaderText="Ded $" DataField="ExTot" DataFormatString="{0:n}" HtmlEncode="False" SortExpression="ExTot" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <%--<asp:BoundField HeaderText="Per Mile" DataField="CalcRate" DataFormatString="{0:n}" HtmlEncode="False" SortExpression="CalcRate" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />--%>
        <asp:TemplateField HeaderText="Per Mile" SortExpression="CalcRate">
            <ItemTemplate>
                <asp:Label ID="lblPerMile" runat="server" />
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="Comm Ck Seq#" DataField="ComCheckSeq" SortExpression="ComCheckSeq" DataFormatString="{0:#,#}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField HeaderText="Check Amt" DataField="ComCheckAmt" DataFormatString="{0:n}" HtmlEncode="False" SortExpression="ComCheckAmt" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField HeaderText="First PickUp" DataField="PUCityST" SortExpression="PUCityST" />
        <asp:BoundField HeaderText="LastDrop" DataField="DPCityST" SortExpression="DPCityST" />
    </Columns>
    <EmptyDataTemplate>
        <p align="center" class="NormalRed">No Loads Found</p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="SubHead" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
    <RowStyle CssClass="Normal" HorizontalAlign="Left" />
    <AlternatingRowStyle CssClass="Normal" HorizontalAlign="Left" />
    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
    <FooterStyle CssClass="GridFooter" Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom" />
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
<asp:ObjectDataSource ID="odsLoadSheets" runat="server" SelectMethod="GetReport2Driver" TypeName="bhattji.Modules.LoadSheets.Business.LoadSheetsController" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadSheetInfo">
    <SelectParameters>
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="CustomerNumber" Type="String" DefaultValue="0000000" />
        <asp:Parameter Name="Status" Type="String" DefaultValue="N" />
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="LoadType" Type="String" DefaultValue="OO" />
        <asp:Parameter Name="CarrierCode" Type="String" DefaultValue="" />
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
