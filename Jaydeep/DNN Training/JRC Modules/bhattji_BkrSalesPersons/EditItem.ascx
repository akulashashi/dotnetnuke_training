<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.BkrSalesPersons.EditItem" %>
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
//      if (clientside_arguments.Value.length  == 4 )
//      {
//         clientside_arguments.IsValid=true;
//      }
//      else {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 4);
   }
   
   function ClientValidate7char(source, clientside_arguments)
   {         
//      if (clientside_arguments.Value.length  == 7 )
//      {
//         clientside_arguments.IsValid=true;
//      }
//      else {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 7);
   }
</script>
<center>
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center"><asp:Literal ID="lblMsg" runat="server" EnableViewState="false" />
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
    <table id="Table1" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td colspan="2">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; DriverDetail &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width="630" border="0" cellspacing="3" cellpadding="0">
                              <tr>
                                <td width="82" align="left" valign="top"><span class="SubHead">
                                  <dnn:Label ID="plDriverCode" runat="server" Suffix=":" ControlName="txtDriverCode" CssClass="SubHead"></dnn:Label>
                                </span></td>
                                <td width="30" align="left" valign="top"><asp:TextBox ID="txtDriverCode" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="4" MaxLength="4"/>                                
                                  <asp:RequiredFieldValidator ID="valDriverCode" ControlToValidate="txtDriverCode" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="Driver Code Cannot be null" SetFocusOnError="true" />                                  
                                  <asp:CustomValidator ID="cvDriverCode" runat="server" ErrorMessage="&lt;br /&gt;Driver Code must be 4 digit long" ClientValidationFunction="ClientValidate4char" ControlToValidate="txtDriverCode" Display="Dynamic"/>                                  
                                  <act:filteredtextboxextender id="actDriverCode" runat="server" targetcontrolid="txtDriverCode" filtertype="Numbers,UppercaseLetters,LowercaseLetters" /></td>
                                <td width="76" align="right" valign="top"><dnn:Label ID="plBrokerCodeD" runat="server" Suffix=":" ControlName="txtBrokerCodeD" CssClass="SubHead"></dnn:Label></td>
                                <td width="155" align="left" valign="top"><nobr><asp:TextBox ID="txtBrokerCodeD" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="25" AutoPostBack="true" /><asp:ImageButton ID="btnBrokerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></nobr>
                                  <asp:RequiredFieldValidator ID="valBrokerCodeD" ControlToValidate="txtBrokerCodeD" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="&lt;br/&gt;Broker Code Cannot be null" setfocusonerror="true" />                                  
                                  <asp:CustomValidator ID="cvBrokerCodeD" runat="server" ErrorMessage="&lt;br /&gt;Broker Code must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtBrokerCodeD" Display="Dynamic"/></td>
                                <td width="175" align="left" valign="top"><asp:DropDownList ID="ddlBrokerCodeD" runat="server" CssClass="NormalTextBox" AutoPostBack="true" DataTextField="BrokerName" DataValueField="BrokerCode" />                                
                                <asp:RequiredFieldValidator ID="reqBrokerCode" runat="server" ControlToValidate="ddlBrokerCodeD" ErrorMessage="&lt;br /&gt;Need to select Broker CodeD" /></td>
                              </tr>
                            </table>
                            <table style="width: 630px">
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plDFirstName" runat="server" Suffix=":" ControlName="txtDFirstName" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead"><dnn:Label ID="plDLastName" runat="server" Suffix=":" ControlName="txtDLastName" CssClass="SubHead"></dnn:Label></td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plOfficeOwner" runat="server" Suffix=":" ControlName="ddlOfficeOwner" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plStatus" runat="server" Suffix=":" ControlName="chkStatus" CssClass="SubHead"></dnn:Label>                                    </td>
                                </tr>
                                <tr>
                                    <td><span class="SubHead">
                                    <asp:TextBox ID="txtDFirstName" runat="server" CssClass="NormalTextBox"></asp:TextBox>
                                    </span></td>
                                    <td><span class="SubHead">
                                      <asp:TextBox ID="txtDLastName" runat="server" CssClass="NormalTextBox"></asp:TextBox>
                                    </span></td>
                                    <td>
                                        <asp:DropDownList ID="ddlOfficeOwner" AutoPostBack="true" CssClass="NormalTextBox" runat="server">                                        </asp:DropDownList>                                    </td>
                                    <td>
                                        <%--<asp:CheckBox ID="chkStatus" runat="server" CssClass="Normal" resourcekey="chkStatus"></asp:CheckBox>--%>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="NormalTextBox">
                                            <asp:ListItem Value="N" Text="Active"/>
                                            <asp:ListItem Value="Y" Text="Inactive"/>                                        </asp:DropDownList>
                                        <asp:Image ID="imgStatus" ImageUrl="~/images/delete.gif" CssClass="Normal" runat="server" resourcekey="imgStatus" /></td>
                                </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="z" valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext"> PersonDetail &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 350px">
                                <tr>
                                    <td>
                                      <dnn:Label ID="plDriverName" runat="server" Suffix=":" ControlName="txtDriverName" CssClass="SubHead"></dnn:Label></td>
                                    <td>
                                      <asp:TextBox ID="txtDriverName" runat="server" CssClass="NormalTextBox"/>                                      
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
                                    <td class="SubHead">
                                        <dnn:Label ID="plCity" runat="server" Suffix=":" ControlName="txtCity" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td nowrap><asp:TextBox ID="txtCity" runat="server" CssClass="NormalTextBox" Columns="15"></asp:TextBox>/ <asp:TextBox ID="txtState" runat="server" CssClass="NormalTextBox" Columns="2"></asp:TextBox>/ <asp:TextBox ID="txtZipCode" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox></td>
                                </tr>
                                <tr class="DisplayNone">
                                    <td class="SubHead">
                                        <dnn:Label ID="plCountryCode" runat="server" Suffix=":" ControlName="txtCountryCode" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td><asp:TextBox ID="txtCountryCode" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plPhoneNo" runat="server" Suffix=":" ControlName="txtPhoneNo" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td class="SubHead"><asp:TextBox ID="txtPhoneNo" runat="server" CssClass="NormalTextBox" Style="text-align: right"/> <asp:Label ID="plExt" runat="server" CssClass="SubHead" Text="Ext"></asp:Label> <asp:TextBox ID="txtExt" runat="server" CssClass="NormalTextBox" Columns="3"></asp:TextBox>
                                    
                                    <act:MaskedEditExtender runat="server" ID="meePhoneNo" 
                                         TargetControlID="txtPhoneNo" 
                                         Mask="(999)999-9999" 
                                         MaskType="None" 
                                         ClearMaskOnLostFocus="false"
                                         ClearTextOnInvalid="false"
                                         MessageValidatorTip="true" 
                                         OnFocusCssClass="MaskedEditFocus" 
                                         OnInvalidCssClass="MaskedEditError" 
                                         InputDirection="RightToLeft" 
                                         AcceptNegative="None" />     
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plFaxNo" runat="server" Suffix=":" ControlName="txtFaxNo" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td class="Normal"><asp:TextBox ID="txtFaxNo" runat="server" CssClass="NormalTextBox" Style="text-align: right"/>
                                    <act:MaskedEditExtender runat="server" ID="meeFaxNo" 
                                         TargetControlID="txtFaxNo" 
                                         Mask="(999)999-9999" 
                                         MaskType="None" 
                                         ClearMaskOnLostFocus="false"
                                         ClearTextOnInvalid="false"
                                         MessageValidatorTip="true" 
                                         OnFocusCssClass="MaskedEditFocus" 
                                         OnInvalidCssClass="MaskedEditError" 
                                         InputDirection="RightToLeft" 
                                         AcceptNegative="None" />
                                         </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plCellPhone" runat="server" Suffix=":" ControlName="txtCellPhone" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td class="SubHead"><asp:TextBox ID="txtCellPhone" runat="server" CssClass="NormalTextBox" style="text-align: right"/></td>
                                </tr>
                                <tr>
                                    <td><span class="SubHead">
                                      <dnn:Label ID="plPager" runat="server" Suffix=":" ControlName="txtPager" CssClass="SubHead"></dnn:Label>
                                      </span>
                                      <act:MaskedEditExtender runat="server" ID="meeCellPhone" 
                                         TargetControlID="txtCellPhone" 
                                         Mask="(999)999-9999" 
                                         MaskType="None" 
                                         ClearMaskOnLostFocus="false"
                                         ClearTextOnInvalid="false"
                                         MessageValidatorTip="true" 
                                         OnFocusCssClass="MaskedEditFocus" 
                                         OnInvalidCssClass="MaskedEditError" 
                                         InputDirection="RightToLeft" 
                                         AcceptNegative="None" />
                                         </td><td><asp:TextBox ID="txtPager" runat="server" CssClass="NormalTextBox" Style="text-align: right"/>
                                    <act:MaskedEditExtender runat="server" ID="meePager" 
                                         TargetControlID="txtPager" 
                                         Mask="(999)999-9999" 
                                         MaskType="None" 
                                         ClearMaskOnLostFocus="false"
                                         ClearTextOnInvalid="false"
                                         MessageValidatorTip="true" 
                                         OnFocusCssClass="MaskedEditFocus" 
                                         OnInvalidCssClass="MaskedEditError" 
                                         InputDirection="RightToLeft" 
                                         AcceptNegative="None" />
                                         </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plEmailAddress" runat="server" Suffix=":" ControlName="txtEmailAddress" CssClass="SubHead"></dnn:Label>                                    </td>
                                    <td><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="NormalTextBox" Columns="32"></asp:TextBox></td>
                                </tr>
                            </table>                        </td>
                    </tr>
                </table>
            </td>
            <td width="373" valign="top" id="tdLastLoadID" runat="server">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext" style="height: 23px">&nbsp; LastLoadID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastLoadID" runat="server" Suffix=":" ControlName="txtLastLoadID" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastLoad" runat="server" Suffix=":" ControlName="txtLastLoad" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtLastLoadID" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0" /></td>
                                    <td><asp:TextBox ID="txtLastLoad" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0" /><asp:Image runat="server" ID="imgLastLoad" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                                        <act:calendarextender id="calLastLoad" targetcontrolid="txtLastLoad" popupbuttonid="imgLastLoad" animated="true" runat="server" format="d" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dnn:Label ID="plLastLoadDeliv" runat="server" Suffix=":" ControlName="txtLastLoadDeliv" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtLastLoadDeliv" runat="server" CssClass="NormalBold" Columns="9" ReadOnly="True" BorderWidth="0"></asp:TextBox><asp:Image runat="server" ID="imgLastLoadDeliv" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                                        <act:calendarextender id="calLastLoadDeliv" targetcontrolid="txtLastLoadDeliv" popupbuttonid="imgLastLoadDeliv" animated="true" runat="server" format="d" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastPU" runat="server" Suffix=":" ControlName="txtLastPU" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastDP" runat="server" Suffix=":" ControlName="txtLastDP" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtLastPU" runat="server" CssClass="NormalBold" ReadOnly="True" BorderWidth="0"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtLastDP" runat="server" CssClass="NormalBold" ReadOnly="True" BorderWidth="0"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <dnn:Label ID="plLastTrailerUsed" runat="server" Suffix=":" ControlName="txtLastTrailerUsed" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtLastTrailerUsed" runat="server" CssClass="NormalBold" ReadOnly="true" BorderWidth="0" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="boxdisplay">
                  <tr>
                    <td class="jrctitletext">&nbsp; AccountInfo &nbsp;</td>
                  </tr>
                  <tr>
                    <td><table style="width: 250px">
                        <tr id="trAccountNo" runat="server" visible="false">
                          <td class="SubHead"><dnn:Label ID="plAccountNo" runat="server" Suffix=":" ControlName="txtAccountNo" CssClass="SubHead"></dnn:Label>
                          </td>
                          <td><asp:TextBox ID="txtAccountNo" runat="server" CssClass="NormalTextBox" Columns="7" MaxLength="7"></asp:TextBox>
                              <br />
                              <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Account Number must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtAccountNo" Display="Dynamic"></asp:CustomValidator>
                          </td>
                        </tr>
                        <tr>
                          <td class="SubHead"><dnn:Label ID="plCommRate" runat="server" Suffix=":" ControlName="txtCommRate" CssClass="SubHead"></dnn:Label>
                          </td>
                          <td><asp:TextBox ID="txtCommRate" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                        </tr>
                        <tr class="DisplayNone">
                          <td class="SubHead"><dnn:Label ID="plCalc85" runat="server" Suffix=":" ControlName="chkCalc85" CssClass="SubHead"></dnn:Label>
                          </td>
                          <td><asp:CheckBox ID="chkCalc85" runat="server" CssClass="Normal" resourcekey="chkCalc85"></asp:CheckBox></td>
                        </tr>
                        <tr>
                          <td class="SubHead"><dnn:Label ID="plJRCTrailer" runat="server" Suffix=":" ControlName="txtJRCTrailer" CssClass="SubHead"></dnn:Label>
                          </td>
                          <td><asp:TextBox ID="txtJRCTrailer" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="SubHead"><dnn:Label ID="plDriverNotes" runat="server" Suffix=":" ControlName="txtDriverNotes" CssClass="SubHead"></dnn:Label>
                          </td>
                          <td><asp:TextBox ID="txtDriverNotes" TextMode="MultiLine" Rows="4" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
                        </tr>
                    </table></td>
                  </tr>
                </table></td>
        </tr>
        <tr>
          <td valign="top" id="trAccountAdmin" runat="server">&nbsp;</td>
            <td valign="top">
                <table class="DisplayNone" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="jrctoplefttd" style="height: 19px"></td>
                        <td class="jrctitletd" style="height: 19px"><span class="jrctitletext">&nbsp; Admin &nbsp;</span></td>
                        <td class="jrctopslide" style="height: 19px"></td>
                        <td class="jrctoprighttd" style="height: 19px"></td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd"></td>
                        <td colspan="2">
                            <table id="Table7" cellspacing="1" cellpadding="1" border="0">
                                <tr>
                                    <td class="SubHead"></td>
                                    <td></td>
                                    <td class="DisplayNone">
                                        <dnn:Label ID="plAdminExempt" runat="server" Suffix=":" ControlName="chkAdminExempt" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="DisplayNone">
                                        <asp:CheckBox ID="chkAdminExempt" runat="server" CssClass="Normal" resourcekey="chkAdminExempt"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plDrugDate" runat="server" Suffix=":" ControlName="txtDrugDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plTruckInsDate" runat="server" Suffix=":" ControlName="txtTruckInsDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:TextBox ID="txtDrugDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox> <asp:HyperLink ID="cmdCalendarDrugDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink> </td>
                                    <td colspan="2"><asp:TextBox ID="txtTruckInsDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox> <asp:HyperLink ID="cmdCalendarTruckInsDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLicenceDate" runat="server" Suffix=":" ControlName="txtLicenceDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plTrailerInsDate" runat="server" Suffix=":" ControlName="txtTrailerInsDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:TextBox ID="txtLicenceDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox> <asp:HyperLink ID="cmdCalendarLicenceDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink> </td>
                                    <td colspan="2"><asp:TextBox ID="txtTrailerInsDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox> <asp:HyperLink ID="cmdCalendarTrailerInsDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plRegRenewDate" runat="server" Suffix=":" ControlName="txtRegRenewDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plNewLeaseDate" runat="server" Suffix=":" ControlName="txtNewLeaseDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:TextBox ID="txtRegRenewDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox><asp:HyperLink ID="cmdCalendarRegRenewDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink></td>
                                    <td colspan="2"><asp:TextBox ID="txtNewLeaseDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox><asp:HyperLink ID="cmdCalendarNewLeaseDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plMedicalDate" runat="server" Suffix=":" ControlName="txtMedicalDate" CssClass="SubHead"></dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLogBookOS" runat="server" Suffix=":" ControlName="chkLogBookOS" CssClass="SubHead"></dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:TextBox ID="txtMedicalDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox><asp:HyperLink ID="cmdCalendarMedicalDate" runat="server" CssClass="CommandButton" Text="Calendar" resourcekey="Calendar" ImageUrl="~/images/calendar.png"></asp:HyperLink></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="chkLogBookOS" runat="server" CssClass="Normal" resourcekey="chkLogBookOS"></asp:CheckBox></td>
                                </tr>
                            </table>
                        </td>
                        <td class="jrcrightslidetd"></td>
                    </tr>
                    <tr>
                        <td class="jrcbottomlefttd"></td>
                        <td class="jrcbottomslide" colspan="2"></td>
                        <td class="jrcbottomrighttd"></td>
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
    <div id="divPopup" runat="server" />
    <p>
        <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
        <Portal:Tracking ID="ctlTracking" runat="server" />
    </center>
<table id="Table2" style="display: none" cellspacing="0" cellpadding="0" summary="Edit SalesPersons Design Table" border="0">
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
        <td class="SubHead">
            <dnn:Label ID="plAddressLine2" runat="server" Suffix=":" ControlName="txtAddressLine2" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="plAddressLine3" runat="server" Suffix=":" ControlName="txtAddressLine3" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"><asp:TextBox ID="txtAddressLine3" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="plState" runat="server" Suffix=":" ControlName="txtState" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="plZipCode" runat="server" Suffix=":" ControlName="txtZipCode" CssClass="SubHead"></dnn:Label>
        </td>
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
        <td class="SubHead">
            <dnn:Label ID="plLoadType" runat="server" Suffix=":" ControlName="txtLoadType" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"><asp:TextBox ID="txtLoadType" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="plSafetyAuth" runat="server" Suffix=":" ControlName="txtSafetyAuth" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"><asp:TextBox ID="txtSafetyAuth" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead">
            <dnn:Label ID="plSafetyNotes" runat="server" Suffix=":" ControlName="txtSafetyNotes" CssClass="SubHead"></dnn:Label>
        </td>
        <td class="Normal"><asp:TextBox ID="txtSafetyNotes" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead">
            <dnn:Label ID="plCalc87" runat="server" Suffix=":" ControlName="chkCalc87" CssClass="SubHead"></dnn:Label>
        </td>
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
        <td class="SubHead">
            <dnn:Label ID="plViewOrder" runat="server" Suffix=":" ControlName="txtViewOrder" CssClass="SubHead"></dnn:Label>
        </td>
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
