<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.EditLoadPUs" CodeBehind="EditLoadPUs.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table id="tblManageLoadPUs" cssclass="DisplayNone" runat="server">
    <tr id="trAddLoadPU" runat="server">
        <td></td>
    </tr>
    <tr id="trManageLoadPUs" runat="server">
        <td><asp:LinkButton ID="lnkAddLoadPU" CssClass="DisplayNone" resourcekey="Add" runat="server" CausesValidation="false" />
        </td>
    </tr>
</table>
<%--<center><dnn:SectionHead ID="secAddLoadPU" CssClass="SubHead" Section="tblAddLoadPU" ResourceKey="tblAddLoadPU" Text="Add Load PickUp" IncludeRule="True" IsExpanded="false" runat="server" /></center>--%>
<table id="tblAddLoadPU" border="0" cellspacing="0" cellpadding="0" class="boxdisplay" Width="375" runat="server">
    <tr bgcolor="#FFFF99">
        <td colspan="2" class="SubHead">
            <table>
                <tr>
                    <td nowrap><dnn:Label ID="plPUCity" ControlName="txtPUCity" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUCity" Columns="22" CssClass="NormalTextBox" runat="server" />
                        <act:AutoCompleteExtender ID="acePUCity" MinimumPrefixLength="1" ServicePath="~/DesktopModules/bhattji.LoadSheets/WebService.asmx" ServiceMethod="GetCityList" runat="server" TargetControlID="txtPUCity" CompletionListCssClass="CompletionListCssClass" CompletionListItemCssClass="CompletionListItemCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass" CompletionSetCount="25" EnableCaching="true" />
                    </td>
                    <td nowrap><dnn:Label ID="plPUState" ControlName="txtPUState" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUState" Columns="1" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchCity" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                    <td nowrap><dnn:Label ID="plZipCode" ControlName="txtZipCode" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtZipCode" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchZipCode" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                    <td nowrap><dnn:Label ID="plPUDate" ControlName="txtPUDate" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUDate" Columns="8" CssClass="NormalTextBox" runat="server" /><act:CalendarExtender ID="actPUDate" TargetControlID="txtPUDate" PopupButtonID="imgPUDate" runat="server" Format="d" />
                        <asp:Image runat="server" ID="imgPUDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><%--<asp:RequiredFieldValidator ID="valPUDate" ControlToValidate="txtPUDate" runat="server" ErrorMessage="Pick-up date is Required" Display="None"/><act:ValidatorCalloutExtender runat="Server" ID="vlxPUDate" TargetControlID="valPUDate" WarningIconImageUrl="~/images/red-error.gif" />--%></td>
                </tr>
            </table>
      </td>
    </tr>
    <tr bgcolor="#FFFF99">
        <td colspan="2" class="SubHead">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="SubHead" nowrap><dnn:Label ID="plSearchZipCode" ControlName="ddlZipCodes" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="SubHead">
                        <asp:DropDownList ID="ddlZipCodes" AutoPostBack="true" CssClass="NormalTextBox" runat="server" />
                    </td>
                </tr>
            </table>
            <%--<dnn:SectionHead ID="secAdditionalInfo" CssClass="SubHead" Section="trAdditionalInfo" ResourceKey="trAdditionalInfo" Text="AdditionalInfo" IncludeRule="True" IsExpanded="True" runat="server" />--%>
      </td>
    </tr>
    <tr id="trAdditionalInfo" runat="server">
        <td valign="top" bgcolor="#FFFF99" class="SubHead"><dnn:Label ID="plPUName" ControlName="txtPUName" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUName" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plPUContact" ControlName="txtPUContact" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUContact" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plPUTel" ControlName="txtPUTel" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUTel" Style="text-align: right" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plPUAdd1" ControlName="txtPUAdd1" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPUAdd1" CssClass="NormalTextBox" runat="server" TextMode="MultiLine" /><br />
            <asp:Label ID="plSeq" resourcekey="plSeq" CssClass="DisplayNone" runat="server" /> <asp:TextBox ID="txtSeq" CssClass="DisplayNone" runat="server" />
            <act:MaskedEditExtender runat="server" ID="meePUTel" TargetControlID="txtPUTel" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="Left" />
      </td>
        <td valign="top" bgcolor="#FFFF99" class="SubHead"><dnn:Label ID="plPRONo" ControlName="txtPRONo" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtPRONo" CssClass="NormalTextBox" runat="server" />
            <table>
                <tr>
                    <td nowrap><dnn:Label ID="plPUTime" ControlName="txtPUTime" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td nowrap align="right"><asp:TextBox ID="txtPUTime" CssClass="NormalTextBox NumericTextBox" Columns="6" runat="server" /></td>
                </tr>
                <tr>
                    <td nowrap><dnn:Label ID="plPieces" ControlName="txtPieces" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td nowrap align="right"><asp:TextBox ID="txtPieces" CssClass="NormalTextBox NumericTextBox" Columns="6" runat="server" /></td>
                </tr>
                <tr>
                    <td nowrap><dnn:Label ID="plWeight" ControlName="txtWeight" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td nowrap align="right"><asp:TextBox ID="txtWeight" CssClass="NormalTextBox NumericTextBox" Columns="6" runat="server" /></td>
                </tr>
                <tr>
                    <td nowrap><dnn:Label ID="plMiles" ControlName="txtMiles" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td nowrap align="right"><asp:TextBox ID="txtMiles" CssClass="NormalTextBox NumericTextBox" Columns="6" runat="server" /></td>
                </tr>
            </table>
            <asp:Label ID="lblItemId" CssClass="SubHead" runat="server" />
      <%--
            <act:MaskedEditExtender runat="server" ID="meePUTime" 
            TargetControlID="txtPUTime" 
            Mask="99:99:99" 
            AcceptAMPM="true"
            MessageValidatorTip="true" 
            OnFocusCssClass="MaskedEditFocus" 
            OnInvalidCssClass="MaskedEditError" 
            InputDirection="RightToLeft" 
            MaskType="Time" />
            --%>      </td>
    </tr>
    <tr>
        <td bgcolor="#FFFF99" class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr bgcolor="#FFFF99">
      <td colspan="2" align="center"><table width="100%" border="0" cellspacing="0" cellpadding="10">
        <tr>
          <td align="center"><asp:ImageButton ID="imbAdd" CommandName="Insert" ImageUrl="~/images/add.gif" CssClass="CommandButton" BorderStyle="none" runat="server" />          
            <asp:LinkButton ID="cmdAdd" CommandName="Insert" Text="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />            
            &nbsp;
            <asp:ImageButton ID="imbCancel" CommandName="Cancel" ImageUrl="~/images/restore.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />            
          <asp:LinkButton ID="cmdCancel" CommandName="Cancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></td>
        </tr>
      </table></td>
    </tr>
    <tr>
        <td bgcolor="#FFFF99" class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
</table>
<br />
<%--<center><dnn:SectionHead ID="secLoadPUs" CssClass="SubHead" Section="divLoadPUs" ResourceKey="divLoadPUs" Text="Load PickUps" IncludeRule="True" IsExpanded="true" runat="server" /></center>--%>
<div id="divLoadPUs" runat="server">
    <asp:GridView ID="gdvLoadPUs" runat="server" DataSourceID="odsLoadPUs" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="375" EmptyDataText="<center class='NormalRed'>No Load-Pickup Defined</center>">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:ImageButton ID="cmdAdd" class="displaynone" runat="server" ImageUrl="~/images/add.gif" resourcekey="Add" CommandName="Add" CausesValidation="false" />
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr valign="top">
                            <td style="width: 16px"><asp:ImageButton runat="server" CssClass="DisplayNone" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="Edit" CausesValidation="false" ID="cmdEdit" /><asp:ImageButton ID="imbEditPU" runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="EditPU" CausesValidation="false" /></td>
                            <td style="width: 16px"><asp:ImageButton ID="imbDelete" CssClass="DisplayNone" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" /><asp:ImageButton ID="imbDeletePU" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="DeletePU" CausesValidation="false" /></td>
                            <td style="width: 16px"><asp:ImageButton runat="server" ImageUrl="~/images/up.gif" resourcekey="Up" CommandName="Up" CausesValidation="false" ID="cmdUp" /></td>
                            <td style="width: 16px"><asp:ImageButton runat="server" ImageUrl="~/images/dn.gif" resourcekey="Down" CommandName="Down" CausesValidation="false" ID="cmdDown" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<nobr>Pickup Date / City / State / Zip</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr><td nowrap style="width: 16px;height:16px"><dnn:SectionHead ID="secMoreInfo1" CssClass="SubHead" Section="trMoreInfo1" ResourceKey="secMoreInfo1" Text="" IncludeRule="False" MaxImageUrl="images/jbplus.gif" MinImageUrl="images/jbminus.gif" IsExpanded="false" runat="server" /></td><td nowrap><asp:Label ID="lblPUDate" runat="server" CssClass="Normal" /></td><td style="width:16px"><td nowrap><asp:Label ID="lblSeq" runat="server" CssClass="DisplayNone" Text='<%# Eval("Seq") %>' /><asp:Label ID="lblPUCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUCity") %>' />/<asp:Label ID="lblPUState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("PUState") %>' />/<asp:Label ID="lblZipCode" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("ZipCode") %>' /></td></tr>
                        <tr id="trMoreInfo1" runat="server"><td colspan="3" valign="top"><asp:Label ID="lblAdditional" runat="server" CssClass="Normal" /></td><td valign="top"><asp:Label ID="lblAdditional2" runat="server" CssClass="Normal" /></td></tr>
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
<center>
    <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" /> <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
</center>
<asp:ObjectDataSource ID="odsLoadPUs" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadPUInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadPUsController" SelectMethod="GetLoadPUByLoadId" DeleteMethod="DeleteLoadPU">
    <SelectParameters>
        <asp:Parameter Name="LoadID" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
