<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.Brokers.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<script type="text/javascript">
      
   function ClientValidate4char(source, clientside_arguments)
   {         
      if ((clientside_arguments.Value.length > 2) && (clientside_arguments.Value.length < 5))
      {
         clientside_arguments.IsValid=true;
      }
      else {clientside_arguments.IsValid=false};
   }
   
   function ClientValidate7char(source, clientside_arguments)
   {         
      if (clientside_arguments.Value.length  == 7 )
      {
         clientside_arguments.IsValid=true;
      }
      else {clientside_arguments.IsValid=false};
   }
</script>
<center>
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center">
                <asp:Literal ID="lblMsg" runat="server" EnableViewState="false" />
                <asp:ValidationSummary ID="valValidationSummary" runat="server" />
            </td>
        </tr>
        <tr id="trUpdateRedirection" runat="server" visible="false">
            <td class="SubHead" colspan="5" align="center">
                <asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
                    <asp:ListItem Value="Listing" resourcekey="Listing" />
                    <asp:ListItem Value="NewItem" resourcekey="NewItem" />
                    <asp:ListItem Value="EditItem" resourcekey="EditItem" />
                    <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td id="tdAdd" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </td>
            <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </td>
            <td class="SubHead" align="center" valign="bottom"><asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /> </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Broker &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 500px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plBrokerCode" CssClass="SubHead" ControlName="txtBrokerCode" Suffix=":" runat="server"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plVendorRef" CssClass="SubHead" ControlName="txtVendorRef" Suffix=":" runat="server"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plBkrType" CssClass="SubHead" ControlName="txtBkrType" Suffix=":" runat="server"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plBStatus" CssClass="SubHead" ControlName="chkBStatus" Suffix=":" runat="server" /></td>
                                    <td class="SubHead" nowrap style="display: none"><dnn:Label ID="plStatus" runat="server" Suffix=":" ControlName="chkStatus" CssClass="SubHead" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtBrokerCode" CssClass="NormalTextBox" ForeColor="White" BackColor="Red" runat="server" Columns="7" MaxLength="7" /><asp:CustomValidator ID="cvBrokerCode" runat="server" ErrorMessage="<br />Broker Code must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtBrokerCode" Display="None" SetFocusOnError="true" /><act:ValidatorCalloutExtender ID="vlxBrokerCode0" TargetControlID="cvBrokerCode" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <act:FilteredTextBoxExtender ID="actBrokerCode" runat="server" TargetControlID="txtBrokerCode" FilterType="Numbers" /><asp:RequiredFieldValidator ID="valBrokerCode" ControlToValidate="txtBrokerCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Broker Code Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxBrokerCode" TargetControlID="valBrokerCode" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtVendorRef" CssClass="NormalTextBox" ForeColor="White" BackColor="Red" runat="server" Columns="4" MaxLength="4" /><asp:CustomValidator ID="cvVendorRef" runat="server" ErrorMessage="<br />Vendor Ref No must be 3 or 4 digit long" ClientValidationFunction="ClientValidate4char" ControlToValidate="txtVendorRef" Display="None" SetFocusOnError="true" /><act:ValidatorCalloutExtender ID="vlxVendorRef0" TargetControlID="cvVendorRef" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <act:FilteredTextBoxExtender ID="actVendorRef" runat="server" TargetControlID="txtVendorRef" FilterType="UppercaseLetters,LowercaseLetters" /><asp:RequiredFieldValidator ID="valVendorRef" ControlToValidate="txtVendorRef" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="VendorRef Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxVendorRef" TargetControlID="valVendorRef" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtBkrType" CssClass="NormalTextBox NumericTextBox" ForeColor="White" BackColor="Red" runat="server" Columns="8" /><asp:RequiredFieldValidator ID="valBkrType" ControlToValidate="txtBkrType" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Broker Type Cannot be null" SetFocusOnError="true" /><act:ValidatorCalloutExtender ID="vlxBkrType" TargetControlID="valBkrType" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td nowrap>
                                        <%--<asp:CheckBox ID="chkBStatus" CssClass="Normal" resourcekey="chkBStatus" runat="server" />--%>
                                        <asp:DropDownList ID="ddlBStatus" runat="server" CssClass="NormalTextBox">
                                            <asp:ListItem Value="ACTIVE" Text="ACTIVE"/>
                                            <asp:ListItem Value="INACTIVE" Text="INACTIVE"/>
                                            <asp:ListItem Value="HOLD" Text="HOLD"/>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="display: none">
                                        <asp:CheckBox ID="chkStatus" CssClass="Normal" resourcekey="chkStatus" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; BrokerID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 330px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plBrokerName" runat="server" Suffix=":" ControlName="txtBrokerName" CssClass="SubHead"></dnn:Label></td>
                                    <td colspan="2"><asp:TextBox ID="txtBrokerName" runat="server" CssClass="NormalTextBox" ForeColor="White" BackColor="Red" Columns="32" /><asp:RequiredFieldValidator ID="valBrokerName" ControlToValidate="txtBrokerName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Broker Name Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxBrokerName" TargetControlID="valBrokerName" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plAddressLine1" runat="server" Suffix=":" ControlName="txtAddressLine1" CssClass="SubHead"></dnn:Label></td>
                                    <td colspan="2"><asp:TextBox ID="txtAddressLine1" runat="server" CssClass="NormalTextBox" Columns="32" /></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2"><asp:TextBox ID="txtAddressLine2" runat="server" CssClass="NormalTextBox" Columns="32" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCity" runat="server" Suffix=":" ControlName="txtCity" CssClass="SubHead"></dnn:Label></td>
                                    <td nowrap><asp:TextBox ID="txtCity" runat="server" CssClass="NormalTextBox" Columns="10" /><%--<asp:TextBox ID="txtState" runat="server" CssClass="NormalTextBox" Columns="2" />--%><asp:DropDownList ID="ddlStateCode" DataValueField="StateCode" DataTextField="StateCode" runat="server" CssClass="NormalTextBox" ForeColor="White" BackColor="Red" />
                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="NormalTextBox" Columns="5" /><asp:RequiredFieldValidator ID="valState" ControlToValidate="ddlStateCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>State is Required" SetFocusOnError="True" /></td>
                                    <td></td>
                                </tr>
                                <tr id="trCountryCode" runat="server" visible="false">
                                    <td class="SubHead" nowrap><dnn:Label ID="plCountryCode" runat="server" Suffix=":" ControlName="txtCountryCode" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtCountryCode" runat="server" CssClass="NormalTextBox" Columns="3" /></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plPhoneNo" runat="server" Suffix=":" ControlName="txtPhoneNo" CssClass="SubHead"></dnn:Label></td>
                                    <td nowrap><asp:TextBox ID="txtPhoneNo" runat="server" Style="text-align: right" CssClass="NormalTextBox" Columns="14" />&nbsp;<asp:Label ID="plExt" runat="server" CssClass="SubHead" Text="Ext"></asp:Label><asp:TextBox ID="txtExt" runat="server" CssClass="NormalTextBox" Columns="4" />
                                        <act:MaskedEditExtender runat="server" ID="meePhoneNo" TargetControlID="txtPhoneNo" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="Left" />
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plFaxNo" runat="server" Suffix=":" ControlName="txtFaxNo" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtFaxNo" runat="server" Style="text-align: right" CssClass="NormalTextBox" Columns="14" />
                                        <act:MaskedEditExtender runat="server" ID="meeFaxNo" TargetControlID="txtFaxNo" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="Left" />
                                    </td>
                                    <td class="SubHead" nowrap></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plEmailAddress" runat="server" Suffix=":" ControlName="txtEmailAddress" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="NormalTextBox" Columns="32" /></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; BrokerNotes &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 330px">
                                <tr>
                                    <td><dnn:Label ID="plBrokerNotes" runat="server" Suffix=":" ControlName="txtBrokerNotes" CssClass="SubHead" /><asp:TextBox ID="txtBrokerNotes" TextMode="MultiLine" Columns="60" Rows="5" runat="server" CssClass="NormalTextBox" /> </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; BrokerInformation &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 120px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plDivision" runat="server" Suffix=":" ControlName="txtDivision" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtDivision" runat="server" CssClass="NormalTextBox" /> </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCommRate" runat="server" Suffix=":" ControlName="txtCommRate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtCommRate" runat="server" CssClass="NormalTextBox NumericTextBox" /><act:FilteredTextBoxExtender ID="fteCommRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRate" ValidChars="+-." />
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead" nowrap><dnn:Label ID="plAdminExempt" runat="server" Suffix=":" ControlName="chkAdminExempt" CssClass="SubHead"></dnn:Label></td>
                                    <td>
                                        <asp:CheckBox ID="chkAdminExempt" CssClass="Normal" resourcekey="chkAdminExempt" runat="server" /></td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead" nowrap><dnn:Label ID="plThirdPartyOK" runat="server" Suffix=":" ControlName="chkThirdPartyOK" CssClass="SubHead"></dnn:Label></td>
                                    <td>
                                        <asp:CheckBox ID="chkThirdPartyOK" CssClass="Normal" resourcekey="chkThirdPartyOK" runat="server" /></td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead" nowrap><dnn:Label ID="plTPPct" runat="server" Suffix=":" ControlName="txtTPPct" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtTPPct" runat="server" CssClass="NormalTextBox" /></td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead" nowrap><dnn:Label ID="plTPAmt" runat="server" Suffix=":" ControlName="txtTPAmt" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtTPAmt" runat="server" CssClass="NormalTextBox" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; JrcTrailer &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 120px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plJRCTrailer" runat="server" Suffix=":" ControlName="txtJRCTrailer" CssClass="SubHead"></dnn:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtJRCTrailer" runat="server" CssClass="NormalTextBox" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divPopup" runat="server" />
    <p>
    <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
    <Portal:Tracking ID="ctlTracking" runat="server" />
    </p>
</center>
<table style="display: none" cellspacing="0" cellpadding="0" border="0" id="Table2">
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAddressLine2" CssClass="SubHead" ControlName="txtAddressLine2" Suffix=":" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plState" CssClass="SubHead" ControlName="txtState" Suffix=":" runat="server" Columns="6" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plZipCode" CssClass="SubHead" ControlName="txtZipCode" Suffix=":" runat="server" /></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plContactCode" CssClass="SubHead" ControlName="txtContactCode" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtContactCode" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="Label1" CssClass="SubHead" ControlName="txtAdminExempt" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="Textbox1" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLoadType" CssClass="SubHead" ControlName="txtLoadType" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtLoadType" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plFavorite" CssClass="SubHead" ControlName="txtFavorite" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtFavorite" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plSortSeq" CssClass="SubHead" ControlName="txtSortSeq" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtSortSeq" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plCorpUpd" CssClass="SubHead" ControlName="txtCorpUpd" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtCorpUpd" CssClass="NormalTextBox" runat="server" /><asp:HyperLink ID="cmdCalendarCorpUpd" ImageUrl="~/images/calendar.png" resourcekey="Calendar" CssClass="CommandButton" runat="server" Text="Calendar" /></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label CssClass="SubHead" ID="plViewOrder" runat="server" ControlName="txtViewOrder" Suffix=":"></dnn:Label></td>
        <td class="Normal"><asp:TextBox CssClass="NormalTextBox" ID="txtViewOrder" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
</table>
