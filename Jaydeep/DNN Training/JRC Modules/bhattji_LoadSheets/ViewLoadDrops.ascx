<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.ViewLoadDrops" CodeBehind="ViewLoadDrops.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%--<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/DesktopModules/bhattji.LoadSheets/SectionHeadControl.ascx" %>--%>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<center><dnn:SectionHead ID="secLoadDPs" CssClass="SubHead" Section="divLoadDPs" ResourceKey="divLoadDPs" Text="Load Drops" IncludeRule="True" IsExpanded="true" runat="server" /></center>--%>
<div class="reorderListDemo" id="divLoadDPs" runat="server">
    <asp:GridView ID="gdvLoadDrops" DataSourceID="odsLoadDrops" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="300" EmptyDataText="<center class='NormalRed'>No Load-Drop Defined</center>">
        <Columns>
            <asp:TemplateField HeaderText="<nobr>Drop Locations</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr><td style="width: 16px;height:16px"><dnn:SectionHead ID="secMoreInfo1" CssClass="SubHead" Section="trMoreInfo1" ResourceKey="secMoreInfo1" Text="" IncludeRule="False" MaxImageUrl="images/jbplus.gif" MinImageUrl="images/jbminus.gif" IsExpanded="false" runat="server" /></td><td width="75" nowrap><asp:Label ID="lblDPDate" runat="server" CssClass="Normal" /></td><td nowrap style="width:16px"></td><td nowrap><asp:Label ID="lblSeq" runat="server" CssClass="DisplayNone" Text='<%# Eval("Seq") %>' /><asp:Label ID="lblDPCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPCity") %>' />/<asp:Label ID="lblDPState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPState") %>' />/<asp:Label ID="lblZipCode" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("ZipCode") %>' /></td></tr>
                        <tr id="trMoreInfo1" runat="server"><td colspan="3" valign="top"><asp:Label ID="lblAdditional" runat="server" CssClass="Normal" /></td><td valign="top"><asp:Label ID="lblAdditional2" runat="server" CssClass="Normal" /></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <%--
            <asp:TemplateField HeaderText="<nobr>Drop Date</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <%--<asp:Label ID="lblDPDate" runat="server" Text='<%# Eval("DPDate", "{0:d}") %>' CssClass="Normal" />--%>                    
                    <%--
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr><td nowrap style="width:16px"><dnn:SectionHead ID="secMoreInfo2" CssClass="SubHead" Section="trMoreInfo2" ResourceKey="secMoreInfo2" Text="" IncludeRule="True" IsExpanded="false" runat="server" /></td><td nowrap><asp:Label ID="lblDPDate" runat="server" CssClass="Normal" /></td></tr>
                        <tr id="trMoreInfo2" runat="server"><td colspan="2"><asp:Label ID="lblAdditional2" runat="server" CssClass="Normal" /></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            --%>
        </Columns>
        <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
        <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
        <PagerSettings Mode="NumericFirstLast" />
        <%--<EmptyDataTemplate>
            <p class="NormalRed" align="center">No Load-Drop Defined<br />
                <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
        </EmptyDataTemplate>--%>
    </asp:GridView>
</div>
<asp:ObjectDataSource ID="odsLoadDrops" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadDropInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadDropsController" SelectMethod="GetLoadDropByLoadId" DeleteMethod="DeleteLoadDrop" UpdateMethod="UpdateLoadDrop">
    <SelectParameters>
        <asp:Parameter Name="LoadID" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
