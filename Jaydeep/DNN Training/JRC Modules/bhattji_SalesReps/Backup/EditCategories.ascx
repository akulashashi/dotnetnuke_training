<%@ Control AutoEventWireup="false" AutoEventWireup="true" Codebehind="EditCategories.ascx.cs" Inherits="bhattji.Modules.SalesReps.EditCategories" Language="c#" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table id="tblManageCategories" runat="server">
    <tr id="trAddCategory" runat="server">
        <td>
            <asp:FormView ID="frmSalesRepCategories" DataSourceID="odsSalesRepCategories" DataKeyNames="ItemId,ModuleId" DefaultMode="Insert" runat="server">
                <InsertItemTemplate>
                    <table>
                        <tr>
                            <td class="SubHead"><dnn:label id="plCategory" controlname="txtCategory" suffix=":" runat="server" /></td>
                            <td class="Normal">
                                <asp:TextBox ID="txtCategory" CssClass="NormalTextBox" runat="server" />
                                <asp:RequiredFieldValidator ID="valCategory" ControlToValidate="txtCategory" ErrorMessage="<br />You Must Enter A Category For The SalesRep" resourcekey="Category.ErrorMessage" CssClass="NormalRed" Display="Dynamic" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="SubHead"><dnn:label id="plViewOrder" controlname="txtViewOrder" suffix=":" runat="server" /></td>
                            <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:ImageButton ID="imbAdd" CommandName="Insert" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
                                <asp:LinkButton ID="cmdAdd" CommandName="Insert" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp;
                                <asp:ImageButton ID="imbCancel" CommandName="Cancel" ImageUrl="~/images/restore.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                                <asp:LinkButton ID="cmdCancel" CommandName="Cancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                            </td>
                        </tr>
                    </table>
                </InsertItemTemplate>
            </asp:FormView>
        </td>
    </tr>
    <tr id="trManageCategories" runat="server">
        <td>
            <asp:GridView ID="gdvSalesRepCategories" DataSourceID="odsSalesRepCategories" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId,ModuleId" GridLines="None" EmptyDataText="<center class='NormalRed'>No SalesRep Category Defined</center>">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/add.gif" resourcekey="Add"
                                CommandName="Add" CausesValidation="false" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="Edit" CausesValidation="false" ID="cmdEdit" />
                            <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton runat="server" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CommandName="Update" ID="cmdUpdate" />&nbsp;
                            <asp:ImageButton runat="server" ImageUrl="~/images/restore.gif" resourcekey="cmdCancel" CommandName="Cancel" ID="cmdCancel" CausesValidation="false" />
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="ItemId" HeaderText="Id" SortExpression="ItemId" ReadOnly="True" >
                        <ItemStyle CssClass="NormalBold" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" CssClass="Normal" Text='<%# Eval("Category") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategory" runat="server" CssClass="NormalTextBox" Text='<%# Bind("Category") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View Order" SortExpression="ViewOrder">
                        <ItemTemplate>
                            <asp:Label ID="lblViewOrder" runat="server" CssClass="Normal" Text='<%# Eval("ViewOrder") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtViewOrder" runat="server" CssClass="NormalTextBox" Text='<%# Bind("ViewOrder") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <p class="NormalRed" align="center">No SalesRep Category Defined<br />
                    <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                <PagerSettings Mode="NumericFirstLast" />
            </asp:GridView>
            <asp:ObjectDataSource ID="odsSalesRepCategories" runat="server" />
             <center>             
            <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
            <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
             </center>
        </td>
    </tr>
    <tr>
        <td align="center"></td>
    </tr>
</table>