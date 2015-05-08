<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ViewZipCodes.ascx.cs" Inherits="bhattji.Modules.XYZ70s.ViewZipCodes" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblManageZipCodes" runat="server" width="100%">
    <tr id="trAddZipCode" runat="server">
        <td>
            <table id="tblAddZipCode" border="0" cellspacing="1" cellpadding="1" runat="server">
                <tr>
                    <td class="SubHead" width="150"></td>
                    <td class="Normal" width="350"><asp:Label ID="lblItemId" CssClass="SubHead" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plZipCode" ControlName="txtZipCode" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtZipCode" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchZipCode" ImageUrl="~/images/view.gif" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plArea" ControlName="txtArea" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtArea" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchArea" ImageUrl="~/images/view.gif" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plCity" ControlName="txtCity" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtCity" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchCity" ImageUrl="~/images/view.gif" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plStateCode" ControlName="txtStateCode" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtState" CssClass="NormalTextBox" runat="server" /><asp:TextBox ID="txtStateCode" Columns="2" CssClass="NormalTextBox" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
               
                <tr>
                    <td class="SubHead" colspan="2">
                        <dnn:Label ID="plSearchZipCode" ControlName="ddlZipCodes" Suffix=":" CssClass="SubHead" runat="server" />
                        <asp:DropDownList ID="ddlZipCodes" AutoPostBack="true" CssClass="NormalTextBox" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <table>
                            <tr>
                                <td id="tdAdd" class="SubHead" valign="bottom" runat="server">
                                    <asp:ImageButton ID="imbAdd" CommandName="Insert" ImageUrl="~/images/add.gif" ResourceKey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                    <asp:LinkButton ID="cmdAdd" CommandName="Insert" ResourceKey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                </td>
                                <td id="tdUpdate" class="SubHead" valign="bottom" runat="server">
                                    <asp:ImageButton ID="imbUpdate" CommandName="Update" ImageUrl="~/images/save.gif" ResourceKey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                    <asp:LinkButton ID="cmdUpdate" CommandName="Update" ResourceKey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp;
                                </td>
                                <td class="SubHead" valign="bottom">
                                    <asp:ImageButton ID="imbCancel" CommandName="Cancel" ImageUrl="~/images/restore.gif" ResourceKey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                    <asp:LinkButton ID="cmdCancel" CommandName="Cancel" ResourceKey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="trManageZipCodes" runat="server">
        <td>
            <asp:GridView ID="gdvZipCodes" DataSourceID="odsZipCodes" runat="server" 
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                DataKeyNames="ItemId" GridLines="None" Width="100%" CssClass="dnnGrid">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/add.gif" ResourceKey="Add" CommandName="Add" CausesValidation="false" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="cmdEdit" runat="server" ImageUrl="~/images/edit.gif" ResourceKey="Edit" CommandName="Edit" CausesValidation="false" />
                            <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" ResourceKey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemId" SortExpression="ItemId" HeaderText="ID" ReadOnly="True">
                        <ItemStyle CssClass="Normal" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ZipCode" SortExpression="ZipCode" HeaderText="ZipCode" ReadOnly="True">
                        <ItemStyle CssClass="Normal" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Area" SortExpression="Area" HeaderText="Area" ReadOnly="True">
                        <ItemStyle CssClass="Normal" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="City" SortExpression="City" HeaderText="City" ReadOnly="True">
                        <ItemStyle CssClass="Normal" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="State" SortExpression="State" HeaderText="State" ReadOnly="True">
                        <ItemStyle CssClass="Normal" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StateCode" SortExpression="StateCode" HeaderText="SC" ReadOnly="True">
                        <ItemStyle CssClass="NormalBold" VerticalAlign="Top" />
                        <HeaderStyle CssClass="SubHead" HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <p class="NormalRed" align="center">No ZipCode Defined<br />
                    <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" ResourceKey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" ResourceKey="Add" Visible='<%# IsEditable %>' /></p>
                </EmptyDataTemplate>
    <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" Font-Bold="True" />
    <RowStyle CssClass="dnnGridItem" VerticalAlign="Top" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" VerticalAlign="Top" />
    <SelectedRowStyle CssClass="dnnFormError" />
    <EditRowStyle CssClass="dnnFormInput" />
    <PagerStyle CssClass="dnnGridPager" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
    <FooterStyle CssClass="dnnGridFooter" />
            </asp:GridView>
            <asp:ObjectDataSource ID="odsZipCodes" runat="server" />
             <div id="divClose" style="text-align:center" runat="server">
                <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" ResourceKey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
                <asp:HyperLink ID="hypClose" ResourceKey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
            </div>
        </td>
    </tr>
    <tr>
        <td class="SubHead" id="tdMsg" runat="server" ></td>
    </tr>
</table>