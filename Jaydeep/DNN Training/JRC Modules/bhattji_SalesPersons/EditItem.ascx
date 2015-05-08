<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.SalesPersons.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagName="DualList" TagPrefix="Portal" Src="~/controls/DualListControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<script type="text/javascript">      
   function ClientValidate4char(source, clientside_arguments)
   {         
      if (clientside_arguments.Value.length  == 4 ) 
        {clientside_arguments.IsValid=true;} 
      else 
        {clientside_arguments.IsValid=false};
   }
   
   function ClientValidate7char(source, clientside_arguments)
   {         
      if (clientside_arguments.Value.length  == 7 ) 
        {clientside_arguments.IsValid=true;} 
      else 
        {clientside_arguments.IsValid=false};
   }   
//   function ClientValidateAlphachar(source, clientside_arguments)
//   {         
//      if (clientside_arguments.Value < 64 AND clientside_arguments.Value > 90) OR (clientside_arguments.Value < 97 AND clientside_arguments.Value > 122)
//      {
//         clientside_arguments.IsValid=true;
//      }
//      else {clientside_arguments.IsValid=false};
//   }   
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
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server" visible="False"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /> </td>
        </tr>
    </table>
    
    <asp:Label ID="lblDriverTerminated" runat="server" Font-Size="Large" ForeColor="Red" />
    <table>
    <tr id="trNormal" runat="server">
    <td>
    <table>
        <tr>
            <td colspan="2">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; DriverDetail &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 630px">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plDriverCode" runat="server" Suffix=":" ControlName="txtDriverCode" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><dnn:Label ID="plDriverName" runat="server" Suffix=":" ControlName="txtDriverName" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><dnn:Label ID="plOfficeOwner" runat="server" Suffix=":" ControlName="ddlOfficeOwner" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><dnn:Label ID="plStatus" runat="server" Suffix=":" ControlName="chkStatus" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><dnn:Label ID="plSafetyAuth" runat="server" Suffix=":" ControlName="chkSafetyAuth" CssClass="SubHead"></dnn:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtDriverCode" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="4" MaxLength="4"></asp:TextBox><asp:RequiredFieldValidator ID="valDriverCode" ControlToValidate="txtDriverCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Driver Code Cannot be null" SetFocusOnError="true" /><act:ValidatorCalloutExtender ID="vlxDriverCode" TargetControlID="valDriverCode" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <asp:CustomValidator ID="cvDriverCode" runat="server" ErrorMessage="<br />Driver Code must be 4 digit long" ClientValidationFunction="ClientValidate4char" ControlToValidate="txtDriverCode" Display="None" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxDriverCode0" TargetControlID="cvDriverCode" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <act:FilteredTextBoxExtender ID="actDriverCode" runat="server" TargetControlID="txtDriverCode" FilterType="UppercaseLetters,LowercaseLetters" />
                                        <%--<asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="<br />Driver Code must be in Alphabets(a-z or A-Z)" ClientValidationFunction="ClientValidateAlphachar" ControlToValidate="txtDriverCode" Display="None"></asp:CustomValidator>--%>
                                    </td>
                                    <td><asp:TextBox ID="txtDriverName" runat="server" CssClass="NormalTextBox" /> </td>
                                    <td>
                                        <asp:DropDownList ID="ddlOfficeOwner" AutoPostBack="true" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" />
                                        <asp:RequiredFieldValidator ID="valddlOfficeOwner" ControlToValidate="ddlOfficeOwner" SetFocusOnError="true" InitialValue="000000000" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>Please Select the right Office" /><act:ValidatorCalloutExtender ID="vlxddlOfficeOwner" TargetControlID="valddlOfficeOwner" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td><asp:Image ID="imgActive" ImageUrl="~/images/greendot.gif" CssClass="Normal" runat="server" resourcekey="imgStatus" />
                                        <asp:CheckBox ID="chkStatus" runat="server" CssClass="Normal" resourcekey="chkStatus" AutoPostBack="True" />
                                        <asp:Image ID="imgStatus" ImageUrl="~/images/delete.gif" CssClass="Normal" runat="server" resourcekey="imgStatus" /></td>
                                    <td class="Normal">
                                        <asp:CheckBox ID="chkSafetyAuth" runat="server" CssClass="Normal" resourcekey="chkSafetyAuth" />
                                        <asp:Image ID="imgSafetyAuth" ImageUrl="~/images/delete.gif" CssClass="Normal" runat="server" resourcekey="imgSafetyAuth" /></td>
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
                        <td class="jrctitletext">&nbsp; PersonDetail &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 320px">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plDLastName" runat="server" Suffix=":" ControlName="txtDLastName" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><asp:TextBox ID="txtDLastName" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" /><asp:RequiredFieldValidator ID="valDLastName" ControlToValidate="txtDLastName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DLastName Cannot be null" SetFocusOnError="True" />
                                        <act:ValidatorCalloutExtender ID="vlxDLastName" TargetControlID="valDLastName" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plDFirstName" runat="server" Suffix=":" ControlName="txtDFirstName" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><asp:TextBox ID="txtDFirstName" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" /><asp:RequiredFieldValidator ID="valDFirstName" ControlToValidate="txtDFirstName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DFirstName Cannot be null" SetFocusOnError="true" /><act:ValidatorCalloutExtender ID="vlxDFirstName" TargetControlID="valDFirstName" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plAddressLine1" runat="server" Suffix=":" ControlName="txtAddressLine1" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtAddressLine1" runat="server" CssClass="NormalTextBox" Columns="32"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><asp:TextBox ID="txtAddressLine2" runat="server" CssClass="NormalTextBox" Columns="32"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plCity" runat="server" Suffix=":" ControlName="txtCity" CssClass="SubHead"></dnn:Label></td>
                                    <td nowrap><asp:TextBox ID="txtCity" runat="server" CssClass="NormalTextBox" Columns="15"></asp:TextBox><%--<asp:TextBox ID="txtState" runat="server" CssClass="NormalTextBox" Columns="2"></asp:TextBox>--%><asp:DropDownList ID="ddlStateCode" DataValueField="StateCode" DataTextField="StateCode" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" />
                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="NormalTextBox" Columns="6"></asp:TextBox><asp:RequiredFieldValidator ID="valState" ControlToValidate="ddlStateCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>State is Required" SetFocusOnError="True" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plCountryCode" runat="server" Suffix=":" ControlName="txtCountryCode" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtCountryCode" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plAccountNo" runat="server" Suffix=":" ControlName="txtAccountNo" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtAccountNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="7" MaxLength="7"></asp:TextBox><asp:RequiredFieldValidator ID="valAccountNo" ControlToValidate="txtAccountNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="AccountNo Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxAccountNo" TargetControlID="valAccountNo" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <br />
                                        <asp:CustomValidator ID="cvAccountNo" runat="server" ErrorMessage="Account Number must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtAccountNo" Display="None" SetFocusOnError="true" />
                                        <act:ValidatorCalloutExtender ID="vlxAccountNo0" TargetControlID="cvAccountNo" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plPhoneNo" runat="server" Suffix=":" ControlName="txtPhoneNo" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtPhoneNo" runat="server" CssClass="NormalTextBox" Style="text-align: right" /> <asp:Label ID="plExt" runat="server" CssClass="SubHead" Text="Ext" /><asp:TextBox ID="txtExt" runat="server" CssClass="NormalTextBox" Columns="4" />
                                        <%--<act:FilteredTextBoxExtender ID="ftPhoneNo" runat="server" TargetControlID="txtPhoneNo" FilterType="numbers" />--%>
                                        <act:MaskedEditExtender runat="server" ID="meePhoneNo" TargetControlID="txtPhoneNo" Mask="(999)999-9999" MaskType="None" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" AcceptNegative="Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plFaxNo" runat="server" Suffix=":" ControlName="txtFaxNo" CssClass="SubHead"></dnn:Label></td>
                                    <td class="Normal"><asp:TextBox ID="txtFaxNo" runat="server" CssClass="NormalTextBox" Style="text-align: right" />
                                        <%--<act:FilteredTextBoxExtender ID="ftFaxNo" runat="server" TargetControlID="txtFaxNo" FilterType="numbers" />--%>
                                        <act:MaskedEditExtender runat="server" ID="meeFaxNo" TargetControlID="txtFaxNo" Mask="(999)999-9999" MaskType="None" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" AcceptNegative="Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plCellPhone" runat="server" Suffix=":" ControlName="txtCellPhone" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><asp:TextBox ID="txtCellPhone" runat="server" CssClass="NormalTextBox" Style="text-align: right" />
                                        <%--<act:FilteredTextBoxExtender ID="ftCellPhone" runat="server" TargetControlID="txtCellPhone" FilterType="numbers" />--%>
                                        <act:MaskedEditExtender runat="server" ID="meeCellPhone" TargetControlID="txtCellPhone" Mask="(999)999-9999" MaskType="None" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" AcceptNegative="Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><dnn:Label ID="plPager" runat="server" Suffix=":" ControlName="txtPager" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtPager" runat="server" CssClass="NormalTextBox" Style="text-align: right" />
                                        <%--<act:FilteredTextBoxExtender ID="ftPager" runat="server" TargetControlID="txtPager" FilterType="numbers" />--%>
                                        <act:MaskedEditExtender runat="server" ID="meePager" TargetControlID="txtPager" Mask="(999)999-9999" MaskType="None" ClearMaskOnLostFocus="false" ClearTextOnInvalid="false" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" InputDirection="RightToLeft" AcceptNegative="Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plEmailAddress" runat="server" Suffix=":" ControlName="txtEmailAddress" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="NormalTextBox" /><asp:RegularExpressionValidator ID="valEmailAddress" runat="server" ErrorMessage="Valid eMail required" ControlToValidate="txtEmailAddress" Display="None" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plSafetyNotes" runat="server" Suffix=":" ControlName="txtSafetyNotes" CssClass="SubHead" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtSafetyNotes" runat="server" CssClass="NormalTextBox" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" id="tdLastLoadID" runat="server">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; LastLoadID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastLoadID" runat="server" Suffix=":" ControlName="txtLastLoadID" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastLoadID" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastLoad" runat="server" Suffix=":" ControlName="txtLastLoad" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastLoad" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0" /><%--<asp:Image ID="imgLastLoad" runat="server" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calLastLoad" runat="server" TargetControlID="txtLastLoad" PopupButtonID="imgLastLoad" Format="d" />--%></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastLoadDeliv" runat="server" Suffix=":" ControlName="txtLastLoadDeliv" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastLoadDeliv" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0" /><%--<asp:Image runat="server" ID="imgLastLoadDeliv" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calLastLoadDeliv" TargetControlID="txtLastLoadDeliv" PopupButtonID="imgLastLoadDeliv" Animated="true" runat="server" Format="d" />--%></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastTrailerUsed" runat="server" Suffix=":" ControlName="txtLastTrailerUsed" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastTrailerUsed" runat="server" CssClass="NormalBold" ReadOnly="True" BorderWidth="0" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastPU" runat="server" Suffix=":" ControlName="txtLastPU" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastPU" runat="server" CssClass="NormalBold" ReadOnly="True" BorderWidth="0" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLastDP" runat="server" Suffix=":" ControlName="txtLastDP" CssClass="SubHead" /></td>
                                    <td><asp:TextBox ID="txtLastDP" runat="server" CssClass="NormalBold" ReadOnly="True" BorderWidth="0" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="tblAccountInfo" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; AccountInfo &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plCommRate" runat="server" Suffix=":" ControlName="txtCommRate" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtCommRate" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="5" AutoPostBack="true" /><asp:RequiredFieldValidator ID="valCommRate" ControlToValidate="txtCommRate" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="CommRate Cannot be null" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxCommRate" TargetControlID="valCommRate" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                        <act:FilteredTextBoxExtender ID="fteCommRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRate" ValidChars="+-." />
                                    </td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead"><dnn:Label ID="plCalc85" runat="server" Suffix=":" ControlName="chkCalc85" CssClass="SubHead"></dnn:Label></td>
                                    <td>
                                        <asp:CheckBox ID="chkCalc85" runat="server" CssClass="Normal" resourcekey="chkCalc85"></asp:CheckBox></td>
                                </tr>
                                <tr id="trDvrDedPct" runat="server">
                                    <td class="SubHead"><dnn:Label ID="plDvrDedPct" runat="server" Suffix=":" ControlName="txtDvrDedPct" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtDvrDedPct" runat="server" CssClass="NormalTextBox NumericTextBox" Columns="1" MaxLength="1" /><act:FilteredTextBoxExtender ID="fteDvrDedPct" runat="server" FilterType="Custom" ValidChars="012" TargetControlID="txtDvrDedPct" />
                                    </td>
                                </tr>
                                <tr id="trDvrDedResn" runat="server">
                                    <td class="SubHead"><dnn:Label ID="plDvrDedResn" runat="server" Suffix=":" ControlName="txtDvrDedResn" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtDvrDedResn" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plJRCTrailer" runat="server" Suffix=":" ControlName="txtJRCTrailer" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtJRCTrailer" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plDriverNotes" runat="server" Suffix=":" ControlName="txtDriverNotes" CssClass="SubHead"></dnn:Label></td>
                                    <td><asp:TextBox ID="txtDriverNotes" TextMode="MultiLine" Rows="4" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trAccountAdmin" runat="server">
            <td valign="top" colspan="2">
                <table id="tblAdmin" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Admin &nbsp; <asp:CheckBox ID="chkProbDriver" runat="server" CssClass="jrctitletext" Text="Is Problem Driver ?" /></td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="DisplayNone"><dnn:Label ID="plAdminExempt" runat="server" Suffix=":" ControlName="chkAdminExempt" CssClass="SubHead" />
                                        <asp:CheckBox ID="chkAdminExempt" runat="server" CssClass="Normal" resourcekey="chkAdminExempt"></asp:CheckBox></td>
                                    <td class="DisplayNone"><dnn:Label ID="plBrokerCodeD" runat="server" Suffix=":" ControlName="txtBrokerCodeD" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtBrokerCodeD" Text="0000000" runat="server" CssClass="NormalTextBox" Columns="9"></asp:TextBox> </td>
                                    <td class="SubHead"><dnn:Label ID="plLicenceDate" runat="server" Suffix=":" ControlName="txtLicenceDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtLicenceDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgLicenceDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calLicenceDate" TargetControlID="txtLicenceDate" PopupButtonID="imgLicenceDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plDrugDate" runat="server" Suffix=":" ControlName="txtDrugDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtDrugDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgDrugDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calDrugDate" TargetControlID="txtDrugDate" PopupButtonID="imgDrugDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plMedicalDate" runat="server" Suffix=":" ControlName="txtMedicalDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtMedicalDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgMedicalDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calMedicalDate" TargetControlID="txtMedicalDate" PopupButtonID="imgMedicalDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plInactivateDate" runat="server" Suffix=":" ControlName="txtInactivateDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtInactivateDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgInactivateDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calInactivateDate" TargetControlID="txtInactivateDate" PopupButtonID="imgInactivateDate" Animated="true" runat="server" Format="d" />
                                        <asp:RequiredFieldValidator ID="valInactivateDate" runat="server" ControlToValidate="txtInactivateDate" CssClass="NormalRed" Display="None" ErrorMessage="&lt;br/&gt;Inactivate Date is Required" SetFocusOnError="True" />
                                        <act:ValidatorCalloutExtender ID="vlxInactivateDate" TargetControlID="valInactivateDate" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plLogBookOS" runat="server" Suffix=":" ControlName="chkLogBookOS" CssClass="SubHead"></dnn:Label>
                                        <asp:CheckBox ID="chkLogBookOS" runat="server" CssClass="Normal" resourcekey="chkLogBookOS"></asp:CheckBox></td>
                                    <td class="SubHead"><dnn:Label ID="plTruckInsDate" runat="server" Suffix=":" ControlName="txtTruckInsDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtTruckInsDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgTruckInsDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calTruckInsDate" TargetControlID="txtTruckInsDate" PopupButtonID="imgTruckInsDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plTrailerInsDate" runat="server" Suffix=":" ControlName="txtTrailerInsDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtTrailerInsDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgTrailerInsDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calTrailerInsDate" TargetControlID="txtTrailerInsDate" PopupButtonID="imgTrailerInsDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plRegRenewDate" runat="server" Suffix=":" ControlName="txtRegRenewDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtRegRenewDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgRegRenewDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calRegRenewDate" TargetControlID="txtRegRenewDate" PopupButtonID="imgRegRenewDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plNewLeaseDate" runat="server" Suffix=":" ControlName="txtNewLeaseDate" CssClass="SubHead"></dnn:Label><asp:TextBox ID="txtNewLeaseDate" runat="server" CssClass="NormalTextBox" Columns="10" /><asp:Image runat="server" ID="imgNewLeaseDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calNewLeaseDate" TargetControlID="txtNewLeaseDate" PopupButtonID="imgNewLeaseDate" Animated="true" runat="server" Format="d" />
                                    </td>
                                </tr>
                                
                                
                                
		<tr><td class="SubHead" nowrap><dnn:label id="plMoMaint" controlname="txtMoMaint" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtMoMaint" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypMoMaint" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calMoMaint" runat="server" TargetControlID="txtMoMaint" PopupButtonID="hypMoMaint" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plDotInspec" controlname="txtDotInspec" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtDotInspec" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypDotInspec" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calDotInspec" runat="server" TargetControlID="txtDotInspec" PopupButtonID="hypDotInspec" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plTrailerMaint" controlname="txtTrailerMaint" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtTrailerMaint" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypTrailerMaint" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calTrailerMaint" runat="server" TargetControlID="txtTrailerMaint" PopupButtonID="hypTrailerMaint" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plRegRenew" controlname="txtRegRenew" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtRegRenew" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypRegRenew" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calRegRenew" runat="server" TargetControlID="txtRegRenew" PopupButtonID="hypRegRenew" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plOccIns" controlname="txtOccIns" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtOccIns" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypOccIns" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calOccIns" runat="server" TargetControlID="txtOccIns" PopupButtonID="hypOccIns" Format="d" /></td></tr> 
		
		<tr><td class="SubHead" nowrap><dnn:label id="plNtlIns" controlname="txtNtlIns" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtNtlIns" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypNtlIns" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calNtlIns" runat="server" TargetControlID="txtNtlIns" PopupButtonID="hypNtlIns" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plPhysDmg" controlname="txtPhysDmg" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtPhysDmg" CssClass="NormalTextBox" runat="server" Columns="10" TabIndex="10" /><asp:hyperlink id="hypPhysDmg" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calPhysDmg" runat="server" TargetControlID="txtPhysDmg" PopupButtonID="hypPhysDmg" Format="d" /></td>
		<td class="SubHead" nowrap><dnn:label id="plSeaLink" controlname="txtSeaLink" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtSeaLink" CssClass="NormalTextBox" runat="server" Columns="10" TabIndex="10" /><asp:hyperlink id="hypSeaLink" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calSeaLink" runat="server" TargetControlID="txtSeaLink" PopupButtonID="hypSeaLink" Format="d" /></td> 
		<td class="SubHead" nowrap><dnn:label id="plAnnIns" controlname="txtAnnIns" suffix=":" CssClass="SubHead" runat="server"/><asp:textbox id="txtAnnIns" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:hyperlink id="hypAnnIns" runat="server"  ImageUrl="~/images/calendar.png" style="cursor:hand"/><act:CalendarExtender ID="calAnnIns" runat="server" TargetControlID="txtAnnIns" PopupButtonID="hypAnnIns" Format="d" /></td>
		</tr> 
	

                                
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="jrctoplefttd"></td>
                        <td class="jrctitletd"><span class="jrctitletext">&nbsp; Offices &nbsp;</span></td>
                        <td class="jrctopslide"></td>
                        <td class="jrctoprighttd"></td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd"></td>
                        <td colspan="2">
                            <Portal:DualList ID="ctlSalesPersonIOs" runat="server" ListBoxWidth="130" ListBoxHeight="130" DataValueField="InterOfficeId" DataTextField="IOName"></Portal:DualList>
                            <asp:Button ID="btnUpdateIOs" runat="server" Text="Update Offices" Visible="false" UseSubmitBehavior="false"></asp:Button></td>
                        <td class="jrcrightslidetd"></td>
                    </tr>
                    <tr>
                        <td class="jrcbottomlefttd"></td>
                        <td class="jrcbottomslide" colspan="2"></td>
                        <td class="jrcbottomrighttd"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>    
    </td>
    </tr>
    
    
    <tr id="trTermination" runat="server" visible="false">
    <td>
    <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Terminated ? &nbsp; <asp:CheckBox ID="chkTerminated" runat="server" AutoPostBack="True" /> 
                            <asp:Label ID="lblDriverCode" runat="server" /> : <asp:Label ID="lblDriverName" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 630px">
                                <tr>
                                    <td class="SubHead" nowrap style="display:none"><dnn:Label ID="plTerm_Staff" ControlName="txtTerm_Staff" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                    <td class="Normal" style="display:none"><asp:TextBox ID="txtTerm_Staff" CssClass="NormalTextBox" runat="server" /></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plTerm_Date" ControlName="txtTerm_Date" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtTerm_Date" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:HyperLink ID="hypTerm_Date" runat="server" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><act:CalendarExtender ID="calTerm_Date" runat="server" TargetControlID="txtTerm_Date" PopupButtonID="hypTerm_Date" Format="d" />
                                    <asp:RequiredFieldValidator ID="valTerm_Date" runat="server" ControlToValidate="txtTerm_Date" CssClass="NormalRed" Display="None" ErrorMessage="&lt;br/&gt;Termination Date is Required" SetFocusOnError="True" />
                                        <act:ValidatorCalloutExtender ID="vlxTerm_Date" TargetControlID="valTerm_Date" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    <asp:CompareValidator ID="valTerm_Date1" runat="server" ControlToValidate="txtTerm_Date" CssClass="NormalRed" Display="None" ErrorMessage="&lt;br/&gt;Termination Date is Requires to be greater than Today" SetFocusOnError="True" Operator="GreaterThanEqual" Type="Date" ValueToCompare="11/11/2000" />
                                        <act:ValidatorCalloutExtender ID="vlxTerm_Date1" TargetControlID="valTerm_Date1" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />  
                                        
                                    </td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plTerm_Reason" ControlName="txtTerm_Reason" Suffix=":" CssClass="SubHead" runat="server" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtTerm_Reason" CssClass="NormalTextBox" runat="server" Columns="50" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="valTerm_Reason" runat="server" ControlToValidate="txtTerm_Reason" CssClass="NormalRed" Display="None" ErrorMessage="&lt;br/&gt;Termination Reason is Required" SetFocusOnError="True" />
                                        <act:ValidatorCalloutExtender ID="vlxTerm_Reason" TargetControlID="valTerm_Reason" runat="Server" WarningIconImageUrl="~/images/red-error.gif" />
                                    </td>
                                    <td class="SubHead" nowrap><asp:LinkButton ID="cmdUnterminate" resourcekey="cmdUnterminate" CssClass="CommandButton" BorderStyle="none" runat="server" CausesValidation="false" /></td>
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
</center>
<table style="display: none" cellspacing="0" cellpadding="0" summary="Edit SalesPersons Design Table" border="0">
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
        <td class="SubHead"><dnn:Label ID="plAddressLine2" runat="server" Suffix=":" ControlName="txtAddressLine2" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plAddressLine3" runat="server" Suffix=":" ControlName="txtAddressLine3" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAddressLine3" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plState" runat="server" Suffix=":" ControlName="txtState" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plZipCode" runat="server" Suffix=":" ControlName="txtZipCode" CssClass="SubHead"></dnn:Label></td>
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
        <td class="SubHead" height="25"></td>
        <td class="Normal" height="25"></td>
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
        <td class="SubHead"><dnn:Label ID="plLoadType" runat="server" Suffix=":" ControlName="txtLoadType" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLoadType" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead"><dnn:Label ID="plCalc87" runat="server" Suffix=":" ControlName="chkCalc87" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkCalc87" runat="server" CssClass="Normal" resourcekey="chkCalc87"></asp:CheckBox></td>
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
        <td class="SubHead"><dnn:Label ID="plViewOrder" runat="server" Suffix=":" ControlName="txtViewOrder" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtViewOrder" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
</table>
