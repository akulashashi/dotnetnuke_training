<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvContainer" CodeBehind="rvContainer.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<asp:Label ID="lblMsg" runat="server" CssClass="NormalRed" EnableViewState="false" />
<asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="eMail needs to be in valid Format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
<table id="tblSearch" runat="server">
    <tr>
        <td class="SubHead">
            <table width="100%">
                <tr>
                    <td nowrap align="left">
                        <table>
                            <tr>
                                <td class="SubHead"><asp:Label ID="lblCustomer" Text="Customer" CssClass="SubHead" runat="server" /></td>
                                <td nowrap><asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" /><asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
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
                    <td><nobr><asp:Label ID="LoadStatus" Text="Load Status: " CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                            <asp:ListItem Value="" Text="<All Status>" Selected="True" />
                            <asp:ListItem Value="WIP" Text="WIP" />
                            <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
                            <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
                            <asp:ListItem Value="VOIDED" Text="VOIDED" />
                        </asp:DropDownList></nobr><br/>
                        <div ID="divReportTitle" runat="server" visible="false"><asp:Label ID="lblReportTitle" Text="Report Title: " CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlReportTitle" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                            <asp:ListItem Value="CA" Text="Customer Activity" />
                            <asp:ListItem Value="CS" Text="Container Status" />
                            <asp:ListItem Value="TS" Text="Trailer Status" />
                        </asp:DropDownList></div>
                    </td>
                    <td nowrap align="left">
                        <table>
                            <tr>
                                <td colspan="2" nowrap>
                                    <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                                        <%--<asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" />--%>
                                        <asp:ListItem Value="TR" Text="Trailer#" resourcekey="TrailerNumber" />
                                        <asp:ListItem Value="C1" Text="Container1#" resourcekey="Container1" />
                                        <asp:ListItem Value="C2" Text="Container2#" resourcekey="Container2" />
                                        <asp:ListItem Value="C12" Text="Container1&2#" resourcekey="Container12" />
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
                                <td nowrap>
                                <asp:TextBox ID="txtEmail" runat="server" Text="jrc@jrctransportation.com" CssClass="NormalTextBox" /><asp:ImageButton ID="imbEmailPdf" ImageUrl="~/images/email_this.png" resourcekey="email_this" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
            <asp:LinkButton ID="lnbEmailPdf" Text="eMail PDF" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="false" />
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
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /><br />
                        <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" AutoPostBack="True" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
                    <td nowrap><asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /><br />
                        <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" AutoPostBack="True" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /><asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/refresh.gif" ToolTip="Refresh the Report with this New Dates" /></td>
                    <td nowrap id="tdNoOfItems" runat="server">
                        <table>
                            <tr>
                                <td><dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /> </td>
                                <td><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                    <td><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" /><br />
                        <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" AutoPostBack="True" />
                    </td>
                    
                    <td style="display: none"><asp:Label ID="plSort" Text="Sort" CssClass="SubHead" runat="server" /><br />
                        <asp:DropDownList ID="ddlSort" runat="server" CssClass="NormalTextBox" AutoPostBack="true">                            
                            <asp:ListItem Value="LoadDate" Text="Load Date" />
                            <asp:ListItem Value="BBaseLoad" Text="Billing" />
                            <asp:ListItem Value="CustomerName" Text="Customer Name" />
                        </asp:DropDownList>
                        <asp:CheckBox ID="chkSortDesc" runat="server" Text="Descending" CssClass="NormalTextBox" AutoPostBack="true" />
                    </td>
                    <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /></td>
                    <td nowrap align="right"><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" />
                    </td>
                    <td nowrap align="right"><asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                    <td nowrap>
                    <asp:HyperLink ID="hypLoadList" runat="server" ImageUrl="~/images/update_and_list.png" NavigateUrl="~/Default.aspx?tabname=View Loads" ToolTip="To View Load List" />
                    </td>
                    <td nowrap colspan="2" align="right" class="DisplayNone"><asp:HyperLink ID="hyprvXmission" resourcekey="hyprvXmission" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "ReportContainer", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />