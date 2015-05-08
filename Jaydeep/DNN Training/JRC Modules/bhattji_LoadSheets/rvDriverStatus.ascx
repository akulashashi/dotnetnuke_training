<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvDriverStatus" CodeBehind="rvDriverStatus.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                        </asp:RadioButtonList>
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
            <table width="100%" style="display: none">
                <tr>
                    <td nowrap style="display: none"><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
                    <td></td>
                    <td nowrap align="right"></td>
                    <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                   </td>
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
                        </asp:RadioButtonList>
                   </td>
                    <td nowrap id="tdNoOfItems" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /></td>
                                <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                   </td>
                    <td align="right"><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" /><asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                   </td>
                    <td align="right" style="display:none"><asp:Label ID="plSort" Text="Sort" CssClass="SubHead" runat="server" /></td>
                    <td align="right" style="display:none">
                        <asp:DropDownList ID="ddlSort" runat="server" CssClass="NormalTextBox" AutoPostBack="true">
                            <asp:ListItem Value="DriverName" Text="DriverName" />
                            <asp:ListItem Value="LastLoadID" Text="LastLoadID" />
                            <asp:ListItem Value="LastLoad" Text="LastLoad" />
                            <asp:ListItem Value="LastPU" Text="LastPU" />
                            <asp:ListItem Value="LastDP" Text="LastDP" />
                            <asp:ListItem Value="CellPhone" Text="CellPhone" />
                        </asp:DropDownList>
                        <asp:CheckBox ID="chkSortDesc" runat="server" Text="Descending" CssClass="NormalTextBox" AutoPostBack="true" />
                   </td>
                    <td align="right" nowrap><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" />
                   </td>
                    <td style="display: none"><asp:HyperLink ID="hypClose" ImageUrl="~/images/cancel_changes.png" NavigateUrl="javascript:window.close();" ToolTip="Close this Window" CssClass="CommandButton" runat="server" /></td>
                    <td nowrap align="right" class="DisplayNone"><asp:HyperLink ID="hypDriverStatus" resourcekey="hypDriverStatus" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "DriverStatus", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>
       </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />
