<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.ViewLoadPUs" CodeBehind="ViewLoadPUs.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<center><dnn:SectionHead ID="secLoadPUs" CssClass="SubHead" Section="divLoadPUs" ResourceKey="divLoadPUs" Text="Load PickUps" IncludeRule="True" IsExpanded="true" runat="server" /></center>--%>
<div id="divLoadPUs" runat="server">
    <asp:GridView ID="gdvLoadPUs" runat="server" DataSourceID="odsLoadPUs" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="300" EmptyDataText="<center class='NormalRed'>No Load-Pickup Defined</center>">
        <Columns>
            
            <asp:TemplateField HeaderText="<nobr>Pickup Locations</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr><td nowrap style="width: 16px;height:16px"><dnn:SectionHead ID="secMoreInfo1" CssClass="SubHead" Section="trMoreInfo1" ResourceKey="secMoreInfo1" Text="" IncludeRule="False" MaxImageUrl="images/jbplus.gif" MinImageUrl="images/jbminus.gif" IsExpanded="false" runat="server" /></td><td width="75" nowrap><asp:Label ID="lblPUDate" runat="server" CssClass="Normal" /></td><td style="width:16px"><td nowrap><asp:Label ID="lblSeq" runat="server" CssClass="DisplayNone" Text='<%# Eval("Seq") %>' /><asp:Label ID="lblPUCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUCity") %>' />/<asp:Label ID="lblPUState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUState") %>' />/<asp:Label ID="lblZipCode" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("ZipCode") %>' /></td></tr>
                        <tr id="trMoreInfo1" runat="server">
                          <td colspan="4" valign="top"><table width="200" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                              <td width="75"><asp:Label ID="lblAdditional" runat="server" CssClass="Normal" /></td>
                              <td width="125"><asp:Label ID="lblAdditional2" runat="server" CssClass="Normal" /></td>
                            </tr>
                          </table></td>
                        </tr>
                    </table>

                </ItemTemplate>
            </asp:TemplateField>
            <%--
            <asp:TemplateField HeaderText="<nobr>Pickup Date</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <%--<asp:Label ID="lblPUDate" runat="server" Text='<%# Eval("PUDate", "{0:d}") %>' CssClass="Normal" />--%>
                    <%--
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr><td nowrap style="width:16px"><dnn:SectionHead ID="secMoreInfo2" CssClass="SubHead" Section="trMoreInfo2" ResourceKey="secMoreInfo2" Text="" IncludeRule="True" IsExpanded="false" runat="server" /></td><td nowrap><asp:Label ID="lblPUDate" runat="server" CssClass="Normal" /></td></tr>
                        <tr id="trMoreInfo2" runat="server"><td colspan="2"><asp:Label ID="lblAdditional2" runat="server" CssClass="Normal" /></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            --%>
        </Columns>
        <HeaderStyle CssClass="jrctitletext" Font-Bold="True" />
        <PagerStyle CssClass="jrctitletext" Font-Bold="True" HorizontalAlign="Center" />
        <PagerSettings Mode="NumericFirstLast" />
        <%--<EmptyDataTemplate>
            <p class="NormalRed" align="center">No Load-Pickup Defined<br />
                <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
        </EmptyDataTemplate>--%>
    </asp:GridView>
    <%--<div class="reorderListDemo" id="divLoadPUs" runat="server">
    <act:ReorderList ID="rlLoadPUs" runat="server" PostBackOnReorder="false" DataSourceID="odsLoadPUs" CallbackCssStyle="callbackStyle" DragHandleAlignment="Left" ItemInsertLocation="End" DataKeyField="ItemID" SortOrderField="Seq" Width="350px">
        <ItemTemplate>
            <div class="itemArea">
                <asp:ImageButton ID="cmdEdit" runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="EditLoadPU" CausesValidation="false" />
                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                <asp:Label ID="lblLoadId" CssClass="DisplayNone" runat="server" Text='<%# Eval("LoadId") %>' />
                <asp:Label ID="lblSeq" CssClass="DisplayNone" runat="server" Text='<%# Eval("Seq") %>' />
                <asp:Label ID="lblPUCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUCity") %>' />/<asp:Label ID="lblPUState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUState") %>' />
                <asp:Label ID="lblPUDate" runat="server" Text='<%# Eval("PUDate", "{0:d}") %>' CssClass="Normal" />
            </div>
        </ItemTemplate>
        <ReorderTemplate>
            <asp:Panel ID="Panel2" runat="server" CssClass="reorderCue" />
        </ReorderTemplate>
        <DragHandleTemplate>
            <div class="dragHandle" />
        </DragHandleTemplate>
        <%--<InsertItemTemplate>
                        <div style="display: none; padding-left: 25px; border-bottom: thin solid transparent;">
                            <asp:Panel ID="panel1" runat="server" DefaultButton="btnAdd">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPUCity" CssClass="SubHead" runat="server" Text="City" /></td>
                                        <td>
                                            <asp:TextBox ID="PUCity" runat="server" Text='<%# Bind("PUCity") %>' /></td>
                                        <td>
                                            <asp:Label ID="lblPUState" CssClass="SubHead" runat="server" Text="ST" /></td>
                                        <td>
                                            <asp:TextBox ID="PUState" runat="server" Text='<%# Bind("PUState") %>' Columns="2" /></td>
                                        <td>
                                            <asp:Label ID="lblPUDate" CssClass="SubHead" runat="server" Text="Date" /></td>
                                        <td>
                                            <asp:TextBox ID="PUDate" runat="server" Text='<%# Bind("PUDate") %>' Columns="8" /><act:CalendarExtender ID="calDate" runat="server" TargetControlID="PUDate" />
                                       </td>
                                        <td>
                                            <asp:Button ID="btnAdd" runat="server" CommandName="AddLoadPU" Text="Add" /></td>
                                    </tr>
                                </table>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter Valid Date for the ToDoList" ControlToValidate="PUDate" Type="Date" MinimumValue="1/1/2000" MaximumValue="12/12/2020" />
                            </asp:Panel>
                        </div>
                    </InsertItemTemplate>
    </act:ReorderList>--%>
</div>
<asp:ObjectDataSource ID="odsLoadPUs" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadPUInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadPUsController" SelectMethod="GetLoadPUByLoadId" DeleteMethod="DeleteLoadPU">
    <SelectParameters>
        <asp:Parameter Name="LoadID" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

