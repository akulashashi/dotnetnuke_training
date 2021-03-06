<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewPQR45s.ascx.cs" Inherits="bhattji.Modules.XYZ70s.ViewPQR45s" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<div class="dnnLeft">
    <div id="divManagePQR45s" runat="server">
        <asp:GridView ID="gdvPQR45s" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId,XYZ70Id" GridLines="None" EmptyDataText="<center class='NormalRed'>No XYZ70 PQR45 Defined</center>" CssClass="dnnGrid">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/add.gif" ResourceKey="Add" CommandName="Add" CausesValidation="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ImageUrl="~/images/edit.gif" ResourceKey="Edit" CommandName="Edit" CausesValidation="false" ID="cmdEdit" />
                        <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" ResourceKey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="ItemId" HeaderText="Id" SortExpression="ItemId" ReadOnly="True">
                    <ItemStyle CssClass="NormalBold" />
                </asp:BoundField>
                <asp:BoundField DataField="XYZ70Title" HeaderText="XYZ70Title" SortExpression="XYZ70Title" ReadOnly="True" />
                <asp:TemplateField HeaderText="PQR45" SortExpression="PQR45">
                    <ItemTemplate>
                        <asp:Label ID="lblPQR45" runat="server" CssClass="Normal" Text='<%# Eval("PQR45") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--CreateViewChildGridItemStub--%>
                <asp:TemplateField HeaderText="View Order" SortExpression="ViewOrder">
                    <ItemTemplate>
                        <asp:Label ID="lblViewOrder" runat="server" CssClass="Normal" Text='<%# Eval("ViewOrder") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <p class="NormalRed" align="center">No XYZ70 PQR45 Defined<br />
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
        <%--<asp:ObjectDataSource ID="odsPQR45s" runat="server" />--%>
        
        <span class="dnnLeft" style="white-space:nowrap;">
            <asp:TextBox ID="txtSearch" runat="server" Columns="3" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" style="min-width:30px; margin-left:-5px; margin-right:35px;" />
        </span>
        <span class="dnnRight">        
            <asp:RequiredFieldValidator ID="valPageIndex" runat="server" ErrorMessage="PageIndex is required" ControlToValidate="txtPageIndex" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" SetFocusOnError="True" />
            <asp:RangeValidator ID="valRangePageIndex" runat="server" ErrorMessage="PageIndex has to be between 1 & 10"  ControlToValidate="txtPageIndex" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" MaximumValue="10" MinimumValue="1" Type="Integer" SetFocusOnError="True"/>

            <asp:Button ID="btnFirst" runat="server" Text="<<" style="min-width:20px" />
            <asp:Button ID="btnPrev" runat="server" Text="<" style="min-width:20px" />
            <asp:TextBox ID="txtPageIndex" Text="1" Style="width:20px" runat="server" ToolTip="PageIndex" />
            <asp:Button ID="btnGo" runat="server" Text="!" style="min-width:20px;margin-left:-5px" />&nbsp;
            <asp:Button ID="btnNext" runat="server" Text=">" style="min-width:20px" />
            <asp:Button ID="btnLast" runat="server" Text=">>" style="min-width:20px" />
        </span>

        <div id="divClose" style="text-align: center" runat="server">
            <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" ResourceKey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
            <asp:HyperLink ID="hypClose" ResourceKey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" />
        </div>
    </div>
    <div id="divAddPQR45" runat="server">
        <div class="dnnForm" id="frmAddCategory">
            <fieldset>
                <div class="dnnFormItem">
                    <dnn:Label ID="plItemId" ControlName="lblItemId" Suffix=":" Text="ItemId" runat="server" />
                    <asp:Label ID="lblItemId" runat="server" />
                </div>
                <div class="dnnFormItem">
                    <dnn:Label id="plPQR45" ControlName="txtPQR45" Suffix=":" runat="server" />
                    <asp:TextBox ID="txtPQR45" runat="server" />
                    <asp:RequiredFieldValidator ID="valPQR45" ControlToValidate="txtPQR45" ErrorMessage="You Must Enter A PQR45 For The XYZ70" ResourceKey="PQR45.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
                </div>
                <%--CreateChildEditUiControlStub--%>
                <div class="dnnFormItem">
                    <dnn:Label id="plViewOrder" ControlName="txtViewOrder" Suffix=":" runat="server" />
                    <asp:TextBox ID="txtViewOrder" runat="server" />
                </div>
            </fieldset>
            <ul class="dnnActions dnnClear">
                <li id="liAdd" runat="server"><asp:LinkButton ID="cmdAdd" CommandName="Insert" ResourceKey="Add" CssClass="dnnPrimaryAction" runat="server" /></li>
                <li id="liUpdate" runat="server"><asp:LinkButton ID="cmdUpdate" CommandName="Update" ResourceKey="cmdUpdate" CssClass="dnnPrimaryAction" runat="server" /></li>
                <li><asp:LinkButton ID="cmdCancel" CommandName="Cancel" ResourceKey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /></li>
                <li id="liDelete" runat="server"><asp:LinkButton ID="cmdDelete" ResourceKey="cmdDelete" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /></li>
            </ul>
        </div>
    </div>
</div>