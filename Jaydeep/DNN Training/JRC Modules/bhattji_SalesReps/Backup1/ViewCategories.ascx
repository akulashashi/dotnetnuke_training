<%@ Control AutoEventWireup="true" Codebehind="ViewCategories.ascx.cs" Inherits="bhattji.Modules.SalesReps.ViewCategories" Language="c#" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblManageCategories" runat="server">
    <tr id="trManageCategories" runat="server">
        <td>
            <asp:GridView ID="gdvCategories" DataSourceID="odsCategories" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId,ModuleId" GridLines="None" EmptyDataText="<center class='NormalRed'>No SalesRep Category Defined</center>">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/add.gif" resourcekey="Add" CommandName="Add" CausesValidation="false" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="Edit" CausesValidation="false" ID="cmdEdit" />
                            <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemId" HeaderText="Id" SortExpression="ItemId" ReadOnly="True">
                        <ItemStyle CssClass="NormalBold" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" CssClass="Normal" Text='<%# Eval("Category") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View Order" SortExpression="ViewOrder">
                        <ItemTemplate>
                            <asp:Label ID="lblViewOrder" runat="server" CssClass="Normal" Text='<%# Eval("ViewOrder") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <p class="NormalRed" align="center">No SalesRep Category Defined<br />
                        <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                <RowStyle CssClass="Normal" />
                <AlternatingRowStyle CssClass="Normal" />
                <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                <PagerSettings Mode="NumericFirstLast" />
            </asp:GridView>
            <asp:ObjectDataSource ID="odsCategories" runat="server" />
            <div id="divClose" style="text-align: center" runat="server">
                <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
                <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </div>
        </td>
    </tr>
    <tr id="trAddCategory" runat="server">
        <td>
            <table>
                <tr>
                    <td class="SubHead" width="150"></td>
                    <td class="Normal" width="350">
                        <asp:Label ID="lblItemId" CssClass="SubHead" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plCategory" ControlName="txtCategory" Suffix=":" runat="server" />
                    </td>
                    <td class="Normal">
                        <asp:TextBox ID="txtCategory" CssClass="NormalTextBox" runat="server" />
                        <asp:RequiredFieldValidator ID="valCategory" ControlToValidate="txtCategory" ErrorMessage="<br />You Must Enter A Category For The SalesRep" resourcekey="Category.ErrorMessage" CssClass="NormalRed" Display="Dynamic" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead">
                        <dnn:Label ID="plViewOrder" ControlName="txtViewOrder" Suffix=":" runat="server" />
                    </td>
                    <td class="Normal">
                        <asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <table>
                            <tr>
                                <td id="tdAdd" class="SubHead" valign="bottom" runat="server">
                                    <asp:ImageButton ID="imbAdd" CommandName="Insert" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                                    <asp:LinkButton ID="cmdAdd" CommandName="Insert" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                </td>
                                <td id="tdUpdate" class="SubHead" valign="bottom" runat="server">
                                    <asp:ImageButton ID="imbUpdate" CommandName="Update" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                                    <asp:LinkButton ID="cmdUpdate" CommandName="Update" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                </td>
                                <td class="SubHead" valign="bottom">
                                    <asp:ImageButton ID="imbCancel" CommandName="Cancel" ImageUrl="~/images/restore.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                                    <asp:LinkButton ID="cmdCancel" CommandName="Cancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                </td>
                                <td id="tdDelete" class="SubHead" valign="bottom" runat="server">
                                    <asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                                    <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center"></td>
    </tr>
</table>