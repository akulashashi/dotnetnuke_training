<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.ViewLoadDrops" CodeBehind="ViewLoadDrops.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table id="tblManageLoadDrops" cssclass="DisplayNone" runat="server">
    <tr id="trAddLoadDrop" runat="server">
        <td></td>
    </tr>
    <tr id="trManageLoadDrops" runat="server">
        <td><asp:LinkButton ID="lnkAddLoadDrop" CssClass="DisplayNone" resourcekey="Add" runat="server" CausesValidation="false" />
       </td>
    </tr>
</table>
<center><dnn:SectionHead ID="secLoadDPs" CssClass="SubHead" Section="divLoadDPs" ResourceKey="divLoadDPs" Text="Load Drops" IncludeRule="True" IsExpanded="true" runat="server" /></center>
<div class="reorderListDemo" id="divLoadDPs" runat="server">
    <asp:GridView ID="gdvLoadDrops" DataSourceID="odsLoadDrops" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="300" EmptyDataText="<center class='NormalRed'>No Load-Drop Defined</center>">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/add.gif" resourcekey="Add" CommandName="Add" CausesValidation="false" Visible="false" />
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr valign="top">
                            <td style="width: 16px"><asp:ImageButton ID="cmdEdit" CssClass="DisplayNone" runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="Edit" CausesValidation="false" />
                                <asp:ImageButton ID="imbEditDP" runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="EditDP" CausesValidation="false" />
                           </td>
                            <td style="width: 16px"><asp:ImageButton ID="imbDelete" CssClass="DisplayNone" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                                <asp:ImageButton ID="imbDeleteDP" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="DeleteDP" CausesValidation="false" />
                           </td>
                            <td style="width: 16px"><asp:ImageButton ID="cmdUp" runat="server" ImageUrl="~/images/up.gif" resourcekey="Up" CommandName="Up" CausesValidation="false" />
                           </td>
                            <td style="width: 16px"><asp:ImageButton ID="cmdDown" runat="server" ImageUrl="~/images/dn.gif" resourcekey="Down" CommandName="Down" CausesValidation="false" />
                           </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<nobr>City / State</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:Label ID="lblSeq" runat="server" CssClass="DisplayNone" Text='<%# Eval("Seq") %>' /> <asp:Label ID="lblDPCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPCity") %>' />/<asp:Label ID="lblDPState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPState") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<nobr>Drop Date</nobr>" HeaderStyle-CssClass="jrctitletext" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <%--<asp:Label ID="lblDPDate" runat="server" Text='<%# Eval("DPDate", "{0:d}") %>' CssClass="Normal" />--%>
                    <asp:Label ID="lblDPDate" runat="server" CssClass="Normal" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
        <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
        <PagerSettings Mode="NumericFirstLast" />
        <%--<EmptyDataTemplate>
            <p class="NormalRed" align="center">No Load-Drop Defined<br />
                <asp:ImageButton ID="imbAdd" runat="server" CausesValidation="false" CommandName="Add" ImageUrl="~/images/add.gif" resourcekey="Add" Visible='<%# IsEditable %>' /><asp:LinkButton ID="lnbAdd" runat="server" CausesValidation="false" CommandName="Add" resourcekey="Add" Visible='<%# IsEditable %>' /></p>
        </EmptyDataTemplate>--%>
    </asp:GridView>
    <%--<div class="reorderListDemo" id="divLoadDPs" runat="server">
    <act:ReorderList ID="rlLoadDPs" runat="server" PostBackOnReorder="false" DataSourceID="odsLoadDrops" CallbackCssStyle="callbackStyle" DragHandleAlignment="Left" ItemInsertLocation="End" DataKeyField="ItemID" SortOrderField="Seq" Width="350px">
        <ItemTemplate>
            <div class="itemArea">
                <asp:ImageButton ID="cmdEdit" runat="server" ImageUrl="~/images/edit.gif" resourcekey="Edit" CommandName="EditLoadDP" CausesValidation="false" />
                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CommandName="Delete" CausesValidation="false" />
                <asp:Label ID="lblLoadId" CssClass="DisplayNone" runat="server" Text='<%# Eval("LoadId") %>' />
                <asp:Label ID="lblSeq" CssClass="DisplayNone" runat="server" Text='<%# Eval("Seq") %>' />
                <asp:Label ID="lblDPCity" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPCity") %>' />/<asp:Label ID="lblDPState" CssClass="Normal" Style="background-color: #FFFFA0; color: #000000" runat="server" Text='<%# Eval("DPState") %>' />
                <asp:Label ID="lblDPDate" runat="server" Text='<%# Eval("DPDate", "{0:d}") %>' CssClass="Normal" />
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
                                <asp:Label ID="lblDPCity" CssClass="SubHead" runat="server" Text="City" /></td>
                            <td>
                                <asp:TextBox ID="DPCity" runat="server" Text='<%# Bind("DPCity") %>' /></td>
                            <td>
                                <asp:Label ID="lblDPState" CssClass="SubHead" runat="server" Text="ST" /></td>
                            <td>
                                <asp:TextBox ID="DPState" runat="server" Text='<%# Bind("DPState") %>' Columns="2" /></td>
                            <td>
                                <asp:Label ID="lblDPDate" CssClass="SubHead" runat="server" Text="Date" /></td>
                            <td>
                                <asp:TextBox ID="DPDate" runat="server" Text='<%# Bind("DPDate") %>' Columns="8" /><act:CalendarExtender ID="calDate" runat="server" TargetControlID="DPDate" />
                           </td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" CommandName="AddLoadDrop" Text="Add" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </InsertItemTemplate>
    </act:ReorderList>--%>
</div>
<center>
    <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" /> <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
</center>
<asp:ObjectDataSource ID="odsLoadDrops" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadDropInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadDropsController" SelectMethod="GetLoadDropByLoadId" DeleteMethod="DeleteLoadDrop" UpdateMethod="UpdateLoadDrop">
    <SelectParameters>
        <asp:Parameter Name="LoadID" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <progresstemplate>
<center><asp:Image ID="Image1" ImageUrl="~/images/dnnanim.gif" runat="server" /></center>
</progresstemplate>
</asp:UpdateProgress>
<center><dnn:SectionHead ID="secAddLoadDrop" CssClass="SubHead" Section="tblAddLoadDrop" ResourceKey="tblAddLoadDrop" Text="Add Load Drop" IncludeRule="True" IsExpanded="false" runat="server" /></center>
<table id="tblAddLoadDrop" border="0" cellspacing="1" cellpadding="1" runat="server">
    <tr>
        <td class="SubHead" colspan="2">
            <table>
                <tr>
                    <td nowrap><dnn:Label ID="plDPCity" ControlName="txtDPCity" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtDPCity" Columns="22" CssClass="NormalTextBox" runat="server" /></td>
                    <td nowrap><dnn:Label ID="plDPState" ControlName="txtDPState" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtDPState" Columns="1" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchCity" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                    <td nowrap><dnn:Label ID="plZipCode" ControlName="txtZipCode" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtZipCode" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:ImageButton ID="imbSearchZipCode" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                    <td nowrap><dnn:Label ID="plDPDate" ControlName="txtDPDate" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtDPDate" Columns="8" CssClass="NormalTextBox" runat="server" /><act:CalendarExtender ID="actDPDate" TargetControlID="txtDPDate" PopupButtonID="imgDPDate" runat="server" Format="d" /><asp:Image runat="server" ID="imgDPDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><%--<asp:RequiredFieldValidator ID="valDPDate" ControlToValidate="txtDPDate" runat="server" ErrorMessage="Drop date is Required" Display="None"/><act:ValidatorCalloutExtender runat="Server" ID="vlxDPDate" TargetControlID="valDPDate" WarningIconImageUrl="~/images/red-error.gif" />--%></td>
                </tr>
            </table>
       </td>
    </tr>
    
    <tr>
        <td class="SubHead" colspan="2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="SubHead" nowrap><dnn:Label ID="plSearchZipCode" ControlName="ddlZipCodes" Suffix=":" CssClass="SubHead" runat="server" /></td>
                    <td class="SubHead"><asp:DropDownList ID="ddlZipCodes" AutoPostBack="true" CssClass="NormalTextBox" runat="server" /></td>
                </tr>
            </table>
            <dnn:SectionHead ID="secAdditionalInfo" CssClass="SubHead" Section="trAdditionalInfo" ResourceKey="trAdditionalInfo" Text="AdditionalInfo" IncludeRule="True" IsExpanded="True" runat="server" />
       </td>
    </tr>
    <tr id="trAdditionalInfo" runat="server">
        <td class="SubHead" valign="top"><dnn:Label ID="plDPName" ControlName="txtDPName" Suffix=":" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtDPName" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plDPContact" ControlName="txtDPContact" Suffix=":" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtDPContact" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plDPPhone" ControlName="txtDPPhone" Suffix=":" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtDPPhone" CssClass="NormalTextBox" Style="text-align: right" runat="server" /><br />
            <dnn:Label ID="plDPAddr" ControlName="txtDPAddr" Suffix=":" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtDPAddr" CssClass="NormalTextBox" runat="server" TextMode="MultiLine" /><br />
            <asp:Label ID="plSeq" resourcekey="plSeq" CssClass="DisplayNone" runat="server" /> <asp:TextBox ID="txtSeq" CssClass="DisplayNone" runat="server" />
            <act:MaskedEditExtender runat="server" ID="meeDPPhone" TargetControlID="txtDPPhone" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="Left" />
       </td>
        <td class="SubHead" valign="top"><dnn:Label ID="plJobno" ControlName="txtJobno" Suffix=":" CssClass="SubHead" runat="server" /> <asp:TextBox ID="txtJobno" CssClass="NormalTextBox" runat="server" /><br />
            <dnn:Label ID="plBillOLay" ControlName="txtBillOLay" Suffix=":" CssClass="SubHead" runat="server" /> <asp:DropDownList ID="ddlBillOLay" CssClass="NormalTextBox" runat="server"><asp:ListItem Value="1st Come 1st Server" /><asp:ListItem Value="Call for Appointment" /><asp:ListItem Value="Appointment Made" /></asp:DropDownList>
            <table>
            <tr><td nowrap><dnn:Label ID="plBOLSeq" ControlName="txtBOLSeq" Suffix=":" CssClass="SubHead" runat="server" /></td><td nowrap align="right"><asp:TextBox ID="txtBOLSeq" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /></td></tr>
            <tr><td nowrap><dnn:Label ID="plStime" ControlName="txtStime" Suffix=":" CssClass="SubHead" runat="server" /></td><td nowrap align="right"><asp:TextBox ID="txtStime" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /></td></tr>
            <tr><td nowrap><dnn:Label ID="plEtime" ControlName="txtEtime" Suffix=":" CssClass="SubHead" runat="server" /></td><td nowrap align="right"><asp:TextBox ID="txtEtime" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="6" /></td></tr>
            </table>
            <asp:Label ID="lblItemId" CssClass="SubHead" runat="server" />             
            <%--
            <act:MaskedEditExtender runat="server" ID="meeStime" 
            TargetControlID="txtStime" 
            Mask="99:99:99"
            AcceptAMPM="true" 
            MessageValidatorTip="true" 
            OnFocusCssClass="MaskedEditFocus" 
            OnInvalidCssClass="MaskedEditError" 
            InputDirection="RightToLeft" 
            MaskType="Time" />
            
            <act:MaskedEditExtender runat="server" ID="meeEtime" 
            TargetControlID="txtEtime" 
            Mask="99:99:99" 
            AcceptAMPM="true"
            MessageValidatorTip="true" 
            OnFocusCssClass="MaskedEditFocus" 
            OnInvalidCssClass="MaskedEditError" 
            InputDirection="RightToLeft" 
            MaskType="Time" />
            --%>
       </td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2" align="center"><asp:ImageButton ID="imbAdd" CommandName="Insert" ImageUrl="~/images/add.gif" CssClass="CommandButton" BorderStyle="none" runat="server" />
            <asp:LinkButton ID="cmdAdd" CommandName="Insert" Text="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp; <asp:ImageButton ID="imbCancel" CommandName="Cancel" ImageUrl="~/images/restore.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:LinkButton ID="cmdCancel" CommandName="Cancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
       </td>
    </tr>
</table>
