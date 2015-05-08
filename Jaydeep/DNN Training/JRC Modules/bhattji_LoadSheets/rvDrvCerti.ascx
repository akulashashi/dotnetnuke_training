<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvDrvCerti" CodeBehind="rvDrvCerti.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table width="770" id="tblSearch">
    <tr>
        <td valign="top">
            <table class="boxdisplay">
                <tr>
                    <td>
                        <table id="tblOffice">
                            <tr class="jrctitletext">
                                <td nowrap><asp:Label ID="plJRCIOfficeCode" Text="Office:" CssClass="SubHead_white" runat="server" /></td>
                                <td nowrap>
                                    <asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="SubHead_white"><asp:Label ID="plStatus" Text="Status:" CssClass="SubHead" runat="server" /></td>
                                <td>
                                    <asp:RadioButtonList ID="rblStatus" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal" AutoPostBack="true">
                                        <asp:ListItem Value="N" Text="Active" />
                                        <asp:ListItem Value="Y" Text="Inactive" />
                                        <asp:ListItem Value="All" Text="All" Selected="True" />
                                    </asp:RadioButtonList>
                                </td>
                            </tr>                            
                            <tr>
                                <td></td><td align="right" nowrap><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" Visible="false" /><asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" /> <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" style="display:none">
            <table class="boxdisplay">
                <tr>
                    <td>
                        <table id="tblCustomer">
                            <tr class="jrctitletext">
                                <td nowrap><asp:Label ID="plCustomer" Text="Customer:" CssClass="SubHead_white" runat="server" /></td>
                                <td nowrap>
                                    <asp:DropDownList ID="ddlCustomerNumber" runat="server" CssClass="NormalTextBox">
                                        <asp:ListItem Value="" Text="<All Customers>" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap><asp:Label ID="plSerachCustomer" Text="Search:" CssClass="SubHead" runat="server" /></td>
                                <td nowrap><asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" /> <asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                            </tr>
                            <tr>
                                <td nowrap><asp:Label ID="plCustPO" Text="PO:" CssClass="SubHead" runat="server" /></td>
                                <td nowrap><asp:TextBox ID="txtCustPO" runat="server" CssClass="NormalTextBox" /></td>
                            </tr>
                            <tr>
                                <td nowrap><asp:Label ID="plProJob" Text="Pro Job#:" CssClass="SubHead" runat="server" /></td>
                                <td nowrap><asp:TextBox ID="txtProJob" runat="server" CssClass="NormalTextBox" /></td>
                            </tr>
                        </table>
                        <table id="tblLoadDates">
                            <tr class="jrctitletext">
                                <td nowrap colspan="2"><asp:Label ID="plLoadDates" Text="LoadDates:" CssClass="SubHead_white" runat="server" /></td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2"><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> </td>
                            </tr>
                        </table>
                        <table id="tblCompletedDates">
                            <tr class="jrctitletext">
                                <td nowrap colspan="2"><asp:Label ID="plCompletedDates" Text="CompletedDates:" CssClass="SubHead_white" runat="server" /></td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2"><asp:Label ID="plFromDate3" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom3" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarFromDate3" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> <asp:Label ID="plToDate3" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo3" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarToDate3" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> </td>
                            </tr>
                        </table>
                        <table id="tblDeliveryDates">
                            <tr class="jrctitletext">
                                <td nowrap colspan="2"><asp:Label ID="plDeliveryDates" Text="DeliveryDates:" CssClass="SubHead_white" runat="server" /></td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2"><asp:Label ID="plFromDate2" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom2" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarFromDate2" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> <asp:Label ID="plToDate2" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo2" CssClass="NormalTextBox" runat="server" Columns="10" /> <asp:HyperLink ID="hypCalandarToDate2" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" style="display:none">
            <table class="boxdisplay">
                <tr>
                    <td>
                        <table id="tblPickup">
                            <tr class="jrctitletext">
                                <td nowrap colspan="2"><asp:Label ID="plPickups" Text="First Pickup:" CssClass="SubHead_white" runat="server" /></td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2">
                                    <table>
                                        <tr>
                                            <td nowrap><asp:Label ID="plPUCity" Text="City" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtPUCity" CssClass="NormalTextBox" runat="server" /></td>
                                            <td nowrap><asp:Label ID="plPUState" Text="St" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtPUState" Columns="1" CssClass="NormalTextBox" runat="server" /> <asp:ImageButton ID="imbSearchCity" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                                            <td nowrap><asp:Label ID="plZipCode" Text="Zip" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtZipCode" Columns="5" CssClass="NormalTextBox" runat="server" /> <asp:ImageButton ID="imbSearchZipCode" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="SubHead_white" nowrap><asp:Label ID="plSearchZipCode" Text="Select" CssClass="SubHead" runat="server" /></td>
                                            <td class="SubHead_white">
                                                <asp:DropDownList ID="ddlZipCodes" AutoPostBack="true" CssClass="NormalTextBox" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table id="tblDrops">
                            <tr class="jrctitletext">
                                <td nowrap colspan="2"><asp:Label ID="plDrops" Text="Last Drop:" CssClass="SubHead_white" runat="server" /></td>
                            </tr>
                            <tr>
                                <td nowrap colspan="2">
                                    <table>
                                        <tr>
                                            <td nowrap><asp:Label ID="plDPCity" Text="City" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtDPCity" CssClass="NormalTextBox" runat="server" /></td>
                                            <td nowrap><asp:Label ID="plDPState" Text="St" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtDPState" Columns="1" CssClass="NormalTextBox" runat="server" /> <asp:ImageButton ID="imbSearchCity2" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                                            <td nowrap><asp:Label ID="plZipCode2" Text="Zip" CssClass="SubHead" runat="server" /> <br />
                                                <asp:TextBox ID="txtZipCode2" Columns="5" CssClass="NormalTextBox" runat="server" /> <asp:ImageButton ID="imbSearchZipCode2" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left" nowrap>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="SubHead_white" nowrap><asp:Label ID="plSearchZipCode2" Text="Select" CssClass="SubHead" runat="server" /></td>
                                            <td class="SubHead_white">
                                                <asp:DropDownList ID="ddlZipCodes2" AutoPostBack="true" CssClass="NormalTextBox" runat="server" />
                                            </td>
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
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />