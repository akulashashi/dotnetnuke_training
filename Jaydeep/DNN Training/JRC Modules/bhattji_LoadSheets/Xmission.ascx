<%@ Control Language="vb" AutoEventWireup="False" CodeBehind="Xmission.ascx.vb" Inherits="bhattji.Modules.LoadSheets.Xmission" %>
<table width="100%">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td nowrap>
                        <asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" />
                            <asp:ListItem Value="OO" Text="Driver" resourcekey="Driver" />
                            <%--<asp:ListItem Value="IO" Text="InterOffice" resourcekey="InterOffice" />--%>
                            <asp:ListItem Value="BK" Text="Broker" resourcekey="Broker" />
                            <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />
                            <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />
                            <asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />
                            <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />
                            <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkCodOnly" Text="COD" runat="server" ForeColor="Red" Font-Size="Larger" AutoPostBack="True" /><br />                        
                        <asp:CheckBox ID="chkMissingCodOnly" Text="Missing Only" runat="server" Font-Size="X-Small" AutoPostBack="True" Visible="false" /></td>
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
                    <td nowrap><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />&nbsp; <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /></td>
                    <td><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlJRCIOfficeCode" CssClass="NormalTextBox" runat="server" AutoPostBack="True" />
                    </td>
                    <td nowrap align="right"><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" /> <asp:Button ID="btnSearch" UseSubmitBehavior="true" runat="server" resourcekey="Search" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:GridView ID="gdvViewList" DataSourceID="odsLoadSheets" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" EmptyDataText="<center class='NormalRed'>No LoadSheet Defined</center>">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add_big.gif" resourcekey="Add" runat="server" Style="display: none" />
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                    <td style="display: none"><asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" resourcekey="Details" runat="server" Visible="false" /></td>
                    <td style="width: 16px"><asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" resourcekey="Edit" runat="server" /></td>
                    <td style="width: 16px; display: none"><asp:HyperLink ID="hypEditAcct" ImageUrl="~/images/icon_Vendors_16px.gif" resourcekey="EditAcct" runat="server" /></td>
                    <td style="width: 16px; display: none"><asp:HyperLink ID="hypCopyLoad" ImageUrl="~/images/icon_lists_16px.gif" resourcekey="copy_load" runat="server" /></td>
                    <td style="width: 16px; display: none"><asp:HyperLink ID="hypLoadReport" ImageUrl="~/images/file.gif" Target="_blank" resourcekey="LoadReport" runat="server" /></td>
                    <td style="width: 16px; display: none"><asp:HyperLink ID="hypPrintLoadReport" ImageUrl="~/images/synchronize.gif" Target="_blank" resourcekey="PrintLoadReport" runat="server" /></td>
                    <td style="display: none"><asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" /></td>
                </table>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="imgXmission" ImageUrl="~/images/FileManager/files/OK.gif" CssClass="Normal" runat="server" resourcekey="imgXmission" />
                <asp:CheckBox ID="chkXMissionSave" runat="server" CssClass="NormalTextBox" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Label ID="lblCodCheckSeqHead" Text="Check #" ForeColor="white" ToolTip="COD Check #" CssClass="SubHead" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtCodCheckSeq" runat="server" CssClass="NormalTextBox" Columns="10" />
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField HeaderText="LoadID" DataField="LoadID" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />--%>
        <asp:TemplateField HeaderText="LoadID" SortExpression="LoadID" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="CommandButton">
            <ItemTemplate>
                <asp:HyperLink ID="hypLoadID" runat="server" CssClass="CommandButton" />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Label ID="lblBkrInvNoHead" Text="BkrInv #" ForeColor="white" ToolTip="Broker Invoice No" CssClass="SubHead" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtBkrInvNo" runat="server" CssClass="NormalTextBox" Columns="8" />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Label ID="lblCustPOHead" Text="CustPO #" ForeColor="white" ToolTip="Customer Purchase Order No" CssClass="SubHead" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtCustPO" runat="server" CssClass="NormalTextBox" Columns="10" />
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField HeaderText="LoadDate" DataField="LoadDate" DataFormatString="{0:d}" SortExpression="LoadDate" HtmlEncode="False" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:TemplateField HeaderText="Stat" SortExpression="LoadStatus" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal">
            <ItemTemplate>
                <asp:Label ID="lblLoadStatus" runat="server" CssClass="Normal" />
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField HeaderText="OfficeCode" DataField="JRCIOfficeCode" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />--%>
        <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" SortExpression="CustomerName" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:BoundField HeaderText="Dispatch" DataField="DispatchCode" SortExpression="DispatchCode" HeaderStyle-CssClass="SubHead" ItemStyle-CssClass="Normal" />
        <asp:TemplateField HeaderText="load" SortExpression="load">
            <HeaderTemplate>
                <asp:Label ID="lblLoadTypeHead" Text="Name" ForeColor="white" ToolTip="Code" CssClass="SubHead" runat="server" />
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
<p align="right" class="DisplayNone"><asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
<asp:Button ID="btnXmission" runat="server" Text="Xmission" Width="80px" /></p>
<p align="right"><asp:HyperLink ID="hypXmission" EnableViewState="false" CssClass="SubHead" runat="server" />
<table align="right">
    <tr>
        <td>
            <asp:DropDownList ID="ddlXmissionFile" runat="server" AutoPostBack="True" />
        </td>
        <td id="tdUnXmission" runat="server" visible="false" rowspan="2">
            <table>
                <tr>
                    <td class="NormalBold" align="center" valign="top" rowspan="2"><asp:ImageButton ID="imgUnXmission" ImageUrl="~/images/update_and_edit.png" resourcekey="imgUnXmission" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="return confirm('Are you sure, you want to Un-Xmit ?')" /><br />
                        <asp:LinkButton ID="lnbUnXmission" Text="UnXmission" CssClass="CommandButton" BorderStyle="none" runat="server" OnClientClick="return confirm('Are you sure, you want to Un-Xmit ?')" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td id="tdXmission" runat="server">
            <asp:CheckBox ID="chkRedirect2Report" Checked="true" Text="Redirect to Report?" ToolTip="Redirect to Xmission Report after successfull Xmission" runat="server" CssClass="SubHead" />
            <table align="right">
                <tr>
                    <td class="NormalBold" align="center" valign="top"><asp:ImageButton ID="imbSelectAll" ImageUrl="~/images/icon_survey_32px.gif" resourcekey="imbSelectAll" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                        <asp:LinkButton ID="lnbSelectAll" Text="SelectAll" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                    <td class="NormalBold" align="center" valign="top"><asp:ImageButton ID="imbUnSelectAll" ImageUrl="~/images/UnSelectAll.gif" resourcekey="imbUnSelectAll" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                        <asp:LinkButton ID="lnbUnSelectAll" Text="UnSelectAll" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                    <td class="NormalBold" align="center" valign="top"><asp:ImageButton ID="imbSave" ImageUrl="~/images/icon_wizard_32px.gif" resourcekey="imbSave" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                        <asp:LinkButton ID="lnbSave" Text="Save" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                    <td class="NormalBold" align="center" valign="top"><asp:ImageButton ID="imbCancel" ImageUrl="~/images/cancel_changes.png" resourcekey="imbSave" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                        <asp:LinkButton ID="lnbCancel" Text="Cancel" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                    <td class="NormalBold" align="center" valign="top"><asp:ImageButton ID="imbXmission" ImageUrl="~/images/icon_sitesettings_32px.gif" resourcekey="imbSave" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                        <asp:LinkButton ID="lnbXmission" Text="Xmission" CssClass="CommandButton" BorderStyle="none" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</p>
<asp:ObjectDataSource ID="odsLoadSheets" runat="server" SelectMethod="GetSearchedLoadSheetsX" DeleteMethod="DeleteLoadSheet" TypeName="bhattji.Modules.LoadSheets.Business.LoadSheetsController" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadSheetInfo" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="SearchText" Type="String" DefaultValue="" />
        <asp:Parameter Name="JRCIOfficeCode" Type="String" DefaultValue="000000000" />
        <asp:Parameter Name="XmissionFile" Type="String" DefaultValue="" />
        <asp:Parameter Name="CodOnly" Type="Boolean" DefaultValue="false" />
        <asp:Parameter Name="MissingCodOnly" Type="Boolean" DefaultValue="false" />
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
<table align="right" class="DisplayNone">
    <tr>
        <td style="width: 99px"><asp:HyperLink ID="hypReport1" resourcekey="hypReport1" ImageUrl="~/images/icon_Vendors_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport2Driver" resourcekey="hypReport2Driver" ImageUrl="~/images/icon_users_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "Report2Driver", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport2Broker" resourcekey="hypReport2Broker" ImageUrl="~/images/icon_hostusers_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "Report2Broker", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypReport3" resourcekey="hypReport3" ImageUrl="~/images/icon_profile_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "Report3", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
        <td><asp:HyperLink ID="hypDriverStatus" resourcekey="hypDriverStatus" ImageUrl="~/images/icon_sql_32px.gif" NavigateUrl='<%# EditUrl("ReportType", "DriverStatus", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
    </tr>
</table>
