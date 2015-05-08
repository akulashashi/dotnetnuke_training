<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvLoadStatusBroker" CodeBehind="rvLoadStatusBroker.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                    <td nowrap align="left" style="display: none"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
                    <td nowrap align="left" style="display: none">
                        <asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />
                            <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />
                        </asp:RadioButtonList>
                   </td>
                    <td rowspan="2" align="right">
                        <table>
                            <tr>
                                <td>
                                    <table id="tblBroker" runat="server">
                                        <tr>
                                            <td><asp:Label ID="lblBroker" Text="Broker" CssClass="SubHead" runat="server" /></td>
                                            <td><asp:TextBox ID="txtBrokerCode" runat="server" CssClass="NormalTextBox" /><asp:ImageButton ID="btnBrokerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                                        </tr>
                                        <tr>
                                            <td><asp:Label ID="lblBokerName" Text="BrokerName" CssClass="SubHead" runat="server" /></td>
                                            <td>
                                                <asp:DropDownList ID="ddlBrokerCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
                                                    <asp:ListItem Value="" Text="<All Brokers>" />
                                                </asp:DropDownList>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                   </td>
                </tr>
            </table>
            <%--<asp:RangeValidator ID="valNoOfItems" runat="server" ControlToValidate="txtNoOfItems"
                Display="Dynamic" ErrorMessage="No of Records to be fetched, should be be between 1 & 1000"
                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" />--%>
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
                    <td align="right"><asp:Label ID="Status" Text="Broker Status: " runat="server" CssClass="SubHead" /></td>
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
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" AutoPostBack="true" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" AutoPostBack="true" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /><asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/refresh.gif" ToolTip="Refresh the Report with this New Dates" /></td>
                    <td nowrap id="tdNoOfItems" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /></td>
                                <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                   </td>
                    <td align="right"><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                   </td>
                    <td nowrap align="right"><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" />
                   </td>
                    <td nowrap align="right" class="DisplayNone"><asp:HyperLink ID="hypReport2Broker" resourcekey="hypReport2Broker" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" />