<%@ Control Language="c#" AutoEventWireup="true" CodeBehind="EditItem.ascx.cs" Inherits="bhattji.Modules.Customers.EditItem" %>
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
      if (clientside_arguments.Value.length  == 4 )
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
                <asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
            <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
            <td class="SubHead" align="center" valign="bottom"><asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></td>
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /></td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Customer ID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 385px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCustomerNumber" CssClass="SubHead" ControlName="txtCustomerNumber" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCustomerStatus" CssClass="SubHead" ControlName="ddlCustomerStatus" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td class="DisplayNone" nowrap><dnn:Label ID="plCStatus" CssClass="SubHead" ControlName="ddlCStatus" Suffix=":" runat="server"></dnn:Label> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtCustomerNumber" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="7" MaxLength="7"></asp:TextBox><asp:CustomValidator ID="cvCustomerNumber" runat="server" ErrorMessage="<br />Customer Number must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtCustomerNumber" Display="None" SetFocusOnError="True"></asp:CustomValidator><act:ValidatorCalloutExtender ID="vlxCustomerNumber0" TargetControlID="cvCustomerNumber" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <act:FilteredTextBoxExtender ID="actCustomerNumber" runat="server" TargetControlID="txtCustomerNumber" FilterType="Numbers" /><asp:RequiredFieldValidator ID="valCustomerNumber" ControlToValidate="txtCustomerNumber" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Customer Number Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxCustomerNumber" TargetControlID="valCustomerNumber" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td class="SubHead" nowrap>
                                        <asp:DropDownList ID="ddlCustomerStatus" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="A" Text="ACTIVE" resourcekey="ACTIVE" />
                                            <asp:ListItem Value="C" Text="COD" resourcekey="COD" />
                                            <asp:ListItem Value="H" Text="CREDIT HOLD" resourcekey="CREDIT HOLD" />
                                            <asp:ListItem Value="I" Text="INACTIVE" resourcekey="INACTIVE" />
                                        </asp:DropDownList>
                                    </td>
                                    <td class="DisplayNone" nowrap>
                                        <asp:DropDownList ID="ddlCStatus" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="ACTIVE" Text="ACTIVE" resourcekey="ACTIVE" />
                                            <asp:ListItem Value="COD" Text="COD" resourcekey="COD" />
                                            <asp:ListItem Value="CREDIT HOLD" Text="CREDIT HOLD" resourcekey="CREDIT HOLD" />
                                            <asp:ListItem Value="INACTIVE" Text="INACTIVE" resourcekey="INACTIVE" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table id="jrcmaintable" runat="server" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Customer &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 385px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCustomerName" CssClass="SubHead" ControlName="txtCustomerName" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtCustomerName" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="37"></asp:TextBox><asp:RequiredFieldValidator ID="valCustomerName" ControlToValidate="txtCustomerName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Customer Name Cannot be null" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxCustomerName" targetcontrolid="valCustomerName" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plAddressLine1" CssClass="SubHead" ControlName="txtAddressLine1" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtAddressLine1" CssClass="NormalTextBox" runat="server" Columns="37"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><asp:TextBox ID="txtAddressLine2" CssClass="NormalTextBox" runat="server" Columns="37" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCity" CssClass="SubHead" ControlName="txtCity" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td nowrap><asp:TextBox ID="txtCity" CssClass="NormalTextBox" runat="server" Columns="15"></asp:TextBox><%--<asp:TextBox ID="txtState" CssClass="NormalTextBox" runat="server" Columns="2"/>--%><asp:DropDownList ID="ddlStateCode" DataValueField="StateCode" DataTextField="StateCode" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" />
                                        <asp:TextBox ID="txtZipCode" CssClass="NormalTextBox" runat="server" Width="78px" Columns="10" /><asp:RequiredFieldValidator ID="valState" ControlToValidate="ddlStateCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>State is Required" SetFocusOnError="True" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plContactCode" CssClass="SubHead" ControlName="txtContactCode" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtContactCode" CssClass="NormalTextBox" runat="server" Columns="37"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plPhoneNumber" CssClass="SubHead" ControlName="txtPhoneNumber" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtPhoneNumber" CssClass="NormalTextBox" Style="text-align: right" Columns="14" runat="server" />
                                        <act:MaskedEditExtender runat="server" ID="meePhoneNumber" TargetControlID="txtPhoneNumber" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="None" />
                                        <asp:Label ID="plExt" CssClass="SubHead" runat="server" Text="Ext"></asp:Label> <asp:TextBox ID="txtExt" CssClass="NormalTextBox" runat="server" Columns="4"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plFaxNumber" CssClass="SubHead" ControlName="txtFaxNumber" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtFaxNumber" CssClass="NormalTextBox" runat="server" Style="text-align: right" Columns="14"></asp:TextBox>
                                        <act:MaskedEditExtender runat="server" ID="meeFaxNumber" TargetControlID="txtFaxNumber" Mask="(???) ???-????" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" MaskType="None" AcceptNegative="None" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Sales Representative &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 385px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plRepNo" CssClass="SubHead" ControlName="ddlRepNo" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRepNo" CssClass="NormalTextBox" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead" nowrap><dnn:Label ID="plRepName" CssClass="SubHead" ControlName="txtRepName" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtRepName" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plRepPct" CssClass="SubHead" ControlName="txtRepPct" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtRepPct" CssClass="NormalTextBox NumericTextBox" runat="server" AutoPostBack="True"></asp:TextBox><act:FilteredTextBoxExtender ID="fteRepPct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepPct" ValidChars="+-." />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plRepDlr" CssClass="SubHead" ControlName="txtRepDlr" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtRepDlr" CssClass="NormalTextBox NumericTextBox" runat="server" AutoPostBack="True"></asp:TextBox><act:FilteredTextBoxExtender ID="fteRepDlr" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepDlr" ValidChars="+-." />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="DisplayNone" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Plcowner &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plCowner" CssClass="SubHead" ControlName="txtCowner" Suffix=":" runat="server"></dnn:Label>
                                        <asp:DropDownList ID="ddlCowner" runat="server" CssClass="NormalTextBox" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="DisplayNone" nowrap><dnn:Label ID="plCorpUpd" CssClass="SubHead" ControlName="txtCorpUpd" Suffix=":" runat="server"></dnn:Label> <asp:TextBox ID="txtCorpUpd" CssClass="NormalTextBox" runat="server" Columns="10"></asp:TextBox><asp:HyperLink ID="cmdCalendarCorpUpd" CssClass="CommandButton" runat="server" resourcekey="Calendar" ImageUrl="~/images/calendar.png" Text="Calendar"></asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="DisplayNone"><dnn:Label ID="plWhoDoneIT" CssClass="SubHead" ControlName="txtWhoDoneIT" Suffix=":" runat="server"></dnn:Label> <asp:TextBox ID="txtWhoDoneIT" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="DisplayNone"><dnn:Label ID="plDivision" CssClass="SubHead" ControlName="txtDivision" Suffix=":" runat="server"></dnn:Label> <asp:TextBox ID="txtDivision" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Billing Information &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plBillingInfo" CssClass="SubHead" ControlName="txtBillingInfo" Suffix=":" runat="server"></dnn:Label> </td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtBillingInfo" CssClass="NormalTextBox" runat="server" Columns="40" Rows="4" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; GSMStatus &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plGSMStatus" CssClass="SubHead" ControlName="txtGSMStatus" Suffix=":" runat="server"></dnn:Label> </td>
                                    <td><asp:TextBox ID="txtGSMStatus" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
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
    <Portal:Audit ID="ctlAudit" runat="server" /></p>
    <p>
    <Portal:Tracking ID="ctlTracking" runat="server" /></p>
</center>
<table id="Table2" style="display: none" height="605" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAddressLine2" CssClass="SubHead" ControlName="txtAddressLine2" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAddressLine3" CssClass="SubHead" ControlName="txtAddressLine3" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtAddressLine3" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plState" CssClass="SubHead" ControlName="txtState" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="17"><dnn:Label ID="plZipCode" CssClass="SubHead" ControlName="txtZipCode" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal" height="17"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="24"></td>
        <td class="Normal" height="24"></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plFavor" CssClass="SubHead" ControlName="txtFavor" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtFavor" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plSortSeq" CssClass="SubHead" ControlName="txtSortSeq" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtSortSeq" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plOldCustNo" CssClass="SubHead" ControlName="txtOldCustNo" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtOldCustNo" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plMCNO" CssClass="SubHead" ControlName="txtMCNO" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtMCNO" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plViewOrder" CssClass="SubHead" ControlName="txtViewOrder" Suffix=":" runat="server"></dnn:Label> </td>
        <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
</table>
