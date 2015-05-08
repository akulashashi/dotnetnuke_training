<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.InterOffices.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<script type="text/javascript"> 
   function ClientValidate9char(source, clientside_arguments)
   {         
//      if (clientside_arguments.Value.length  == 9 )
//        {clientside_arguments.IsValid=true;}
//      else 
//        {clientside_arguments.IsValid=false};
      clientside_arguments.IsValid = (clientside_arguments.Value.length  == 9 );
   }     
   function ClientValidate7char(source, clientside_arguments)
   {         
//      if (clientside_arguments.Value.length  == 7 )
//        {clientside_arguments.IsValid=true;}
//      else 
//        {clientside_arguments.IsValid=false};
      clientside_arguments.IsValid = (clientside_arguments.Value.length  == 7 );
   }
   function ClientValidate3char(source, clientside_arguments)
   { 
      clientside_arguments.IsValid = (clientside_arguments.Value.length  == 3 );
   }
   function ClientValidate2char(source, clientside_arguments)
   { 
      clientside_arguments.IsValid = (clientside_arguments.Value.length  == 2 );
   }
   
</script>
<center>
    <table>
        <tr>
            <td colspan="3">
                <table id="jrcmaintable" runat="server" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; JrcOfficeCode &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 490px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:Label ID="plJRCIOfficeCode" CssClass="SubHead" runat="server" ControlName="txtJRCIOfficeCode" Suffix=":"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plIOfficeCode" CssClass="SubHead" runat="server" ControlName="txtIOfficeCode" Suffix=":"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plIOName" CssClass="SubHead" runat="server" ControlName="txtIOName" Suffix=":"></dnn:Label></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plJRCActive" CssClass="SubHead" runat="server" ControlName="chkJRCActive" Suffix=":"></dnn:Label></td>
                                    <td class="SubHead" nowrap rowspan="2">
                                        <asp:CheckBox ID="chkCorpOff" CssClass="SubHead" resourcekey="chkCorpOff" runat="server" /><br/>
                                        <asp:CheckBox ID="chkShowOnWeb" CssClass="SubHead" resourcekey="chkShowOnWeb" runat="server" />                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtJRCIOfficeCode" ForeColor="White" BackColor="Red" CssClass="NormalTextBox " runat="server" Columns="10" MaxLength="9"></asp:TextBox><act:FilteredTextBoxExtender ID="fteJRCIOfficeCode" runat="server" TargetControlID="txtJRCIOfficeCode" FilterType="Numbers" /><asp:CustomValidator ID="cvJRCIOfficeCode" runat="server" ErrorMessage="<br />JRCIOfficeCode must be 9 digit long" ClientValidationFunction="ClientValidate9char" ControlToValidate="txtJRCIOfficeCode" Display="None" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxJRCIOfficeCode0" runat="Server" targetcontrolid="cvJRCIOfficeCode" warningiconimageurl="~/images/red-error.gif" /><asp:RequiredFieldValidator ID="valJRCIOfficeCode" ControlToValidate="txtJRCIOfficeCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="JRCIOffice Code Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxJRCIOfficeCode" runat="Server" targetcontrolid="valJRCIOfficeCode" warningiconimageurl="~/images/red-error.gif" /></td>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtIOfficeCode" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="8" MaxLength="7"></asp:TextBox><act:FilteredTextBoxExtender ID="fteIOfficeCode" runat="server" TargetControlID="txtIOfficeCode" FilterType="Numbers" /><asp:CustomValidator ID="cvIOfficeCode" runat="server" ErrorMessage="<br />IOfficeCode must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIOfficeCode" Display="None" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxIOfficeCode0" runat="Server" targetcontrolid="cvIOfficeCode" warningiconimageurl="~/images/red-error.gif" /><asp:RequiredFieldValidator ID="valIOfficeCode" ControlToValidate="txtIOfficeCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="IOfficeCode Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxIOfficeCode" runat="Server" targetcontrolid="valIOfficeCode" warningiconimageurl="~/images/red-error.gif" /></td>
                                    <td class="SubHead" nowrap><asp:TextBox ID="txtIOName" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" /><asp:RequiredFieldValidator ID="valIOName" ControlToValidate="txtIOName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="IOName Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxIOName" runat="Server" targetcontrolid="valIOName" warningiconimageurl="~/images/red-error.gif" /></td>
                                    <td class="SubHead" nowrap>
                                        <asp:CheckBox ID="chkJRCActive" CssClass="Normal" resourcekey="chkJRCActive" runat="server" />
                                        <asp:Image ID="imgJRCActive" ImageUrl="~/images/delete.gif" CssClass="Normal" runat="server" resourcekey="imgJRCActive" />
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tblIODetails" runat="server">
                    <tr>
                        <td valign="top" align="left" nowrap>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; InterOffice Detail &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 250px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAbvrName" CssClass="SubHead" runat="server" ControlName="txtAbvrName" Suffix=":"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtAbvrName" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAddressLine1" CssClass="SubHead" runat="server" ControlName="txtAddressLine1" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAddressLine1" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td><asp:TextBox ID="txtAddressLine2" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" valign="top"><dnn:Label ID="plCity" CssClass="SubHead" runat="server" ControlName="txtCity" Suffix=":"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtCity" CssClass="NormalTextBox" runat="server" Columns="25" /><br />
                                                <%--<asp:TextBox ID="txtState" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="2" />--%><asp:DropDownList ID="ddlStateCode" DataValueField="StateCode" DataTextField="StateCode" runat="server" CssClass="NormalTextBox" ForeColor="White" BackColor="Red" /><asp:RequiredFieldValidator ID="valState" ControlToValidate="ddlStateCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>State is Required" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxState" runat="Server" targetcontrolid="valState" warningiconimageurl="~/images/red-error.gif" /> - <asp:TextBox ID="txtZipCode" CssClass="NormalTextBox" runat="server" Columns="4" /><br/><asp:TextBox ID="txtCountryCode" CssClass="NormalTextBox" runat="server" /></td>
                                            </tr>
                                            <tr style="display: none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plCountryCode" CssClass="SubHead" runat="server" ControlName="txtCountryCode" Suffix=":"></dnn:Label></td>
                                                <td nowrap></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plPhoneNo" CssClass="SubHead" runat="server" ControlName="txtPhoneNo" Suffix=":"></dnn:Label></td>
                                                <td class="SubHead" nowrap><asp:TextBox ID="txtPhoneNo" CssClass="NormalTextBox" runat="server" Columns="16" /><asp:Label ID="plExt" CssClass="SubHead" runat="server" Text="X" /><asp:TextBox ID="txtExt" CssClass="NormalTextBox" runat="server" Columns="3" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plFaxNo" CssClass="SubHead" runat="server" ControlName="txtFaxNo" Suffix=":"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtFaxNo" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plEmailAddress" CssClass="SubHead" runat="server" ControlName="txtEmailAddress" Suffix=":"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtEmailAddress" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="SubHead" nowrap></td>
                                                <td nowrap><asp:CheckBox ID="chkHasProbDrivers" CssClass="SubHead" runat="server" resourcekey="chkHasProbDrivers" /></td>
                                            </tr>
                                            <tr class="DisplayNone">
                                                <td class="SubHead" nowrap><dnn:Label ID="plLogOnPW" CssClass="SubHead" runat="server" ControlName="txtLogOnPW" Suffix=":"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtLogOnPW" CssClass="NormalTextBox" runat="server" Columns="25"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; SubOffComm &nbsp;<asp:CheckBox ID="chkSubOffComm" CssClass="Normal" runat="server" resourcekey="chkSubOffComm" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 250px">
                                            <tr runat="server" visible="false">
                                                <td class="SubHead" nowrap><dnn:Label ID="plSubOffComm" Suffix=":" ControlName="chkSubOffComm" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAPCodeFM" Suffix=":" ControlName="txtAPCodeFM" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAPCodeFM" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAbvrNameFM" Suffix=":" ControlName="txtAbvrNameFM" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAbvrNameFM" runat="server" CssClass="NormalTextBox" Columns="20"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plCommRateFM" Suffix=":" ControlName="txtCommRateFM" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtCommRateFM" runat="server" CssClass="NormalTextBox NumericTextBox" Columns="10" /><act:FilteredTextBoxExtender ID="fteCommRateFM" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRateFM" ValidChars="+-." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plBKCommRateFM" Suffix=":" ControlName="txtBKCommRateFM" runat="server" CssClass="SubHead" /></td>
                                                <td><asp:TextBox ID="txtBKCommRateFM" runat="server" CssClass="NormalTextBox NumericTextBox" Columns="10"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBKCommRateFM" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBKCommRateFM" ValidChars="+-." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plBrokerOnly" CssClass="SubHead" runat="server" ControlName="chkBrokerOnly" Suffix=":"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkBrokerOnly" CssClass="Normal" resourcekey="chkBrokerOnly" runat="server" /></td>
                                            </tr>
                                            <tr id="trIntraOComm" runat="server" visible="false">
                                                <td class="SubHead" nowrap><dnn:Label ID="plIntraOComm" Suffix=":" ControlName="chkIntraOComm" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkIntraOComm" CssClass="Normal" runat="server" resourcekey="chkIntraOComm"></asp:CheckBox></td>
                                            </tr>
                                            <tr class="DisplayNone">
                                                <td class="SubHead" nowrap><dnn:Label ID="plPASplit" Suffix=":" ControlName="chkPASplit" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkPASplit" CssClass="Normal" runat="server" resourcekey="chkPASplit"></asp:CheckBox></td>
                                            </tr>
                                            <tr class="DisplayNone">
                                                <td class="SubHead" nowrap><dnn:Label ID="plCommAdj" Suffix=":" ControlName="chkCommAdj" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkCommAdj" CssClass="Normal" runat="server" resourcekey="chkCommAdj"></asp:CheckBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAllowCDed" Suffix=":" ControlName="chkAllowCDed" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkAllowCDed" CssClass="Normal" runat="server" resourcekey="chkAllowCDed"></asp:CheckBox></td>
                                            </tr>
                                            <tr id="trDvrDAcct1" runat="server" visible="false">
                                                <td class="SubHead" nowrap><dnn:Label ID="plDvrDAcct1" Suffix=":" ControlName="txtDvrDAcct1" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDvrDAcct1" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right" nowrap>
                            <table class="DisplayNone" class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; JrcActive &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr style="display: none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plDoABU" CssClass="SubHead" runat="server" ControlName="chkDoABU" Suffix=":"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkDoABU" CssClass="Normal" resourcekey="chkDoABU" runat="server" /></td>
                                            </tr>
                                            <tr class="DisplayNone">
                                                <td class="SubHead" nowrap><dnn:Label ID="plXMissionSeq" CssClass="SubHead" runat="server" ControlName="chkXMissionSeq" Suffix=":"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkXMissionSeq" CssClass="Normal" resourcekey="chkXMissionSeq" runat="server" /></td>
                                            </tr>
                                            <tr class="DisplayNone">
                                                <td class="SubHead" nowrap><dnn:Label ID="plWhatDivision" CssClass="SubHead" runat="server" ControlName="ddlWhatDivision" Suffix=":"></dnn:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlWhatDivision" CssClass="NormalTextBox" runat="server" Width="100px">
                                                        <asp:ListItem Value="JRC ">JRC </asp:ListItem>
                                                        <asp:ListItem Value="JRC Transportation">JRC Transportation</asp:ListItem>
                                                        <asp:ListItem Value="CLT ">CLT </asp:ListItem>
                                                        <asp:ListItem Value="CLT Division">CLT Division</asp:ListItem>
                                                        <asp:ListItem Value="JRCD">JRCD</asp:ListItem>
                                                        <asp:ListItem Value="JRC Deland,Fl">JRC Deland,Fl</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; LoadAcct &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plGenCode" CssClass="SubHead" runat="server" ControlName="txtGenCode" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtGenCode" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="5" /><asp:LinkButton ID="cmdGo" runat="server" resourcekey="cmdGo" CssClass="CommandButton" Text="Go" BorderStyle="none" CausesValidation="false" /><asp:RequiredFieldValidator ID="valGenCode" ControlToValidate="txtGenCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Gen Code Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxGenCode" runat="Server" targetcontrolid="valGenCode" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plLoadAcct" CssClass="SubHead" runat="server" ControlName="txtLoadAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtLoadAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valLoadAcct" ControlToValidate="txtLoadAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="LoadAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxLoadAcct" targetcontrolid="valLoadAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plDiscAcct" CssClass="SubHead" runat="server" ControlName="txtDiscAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDiscAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDiscAcct" ControlToValidate="txtDiscAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DiscAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDiscAcct" targetcontrolid="valDiscAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plDetenAcct" CssClass="SubHead" runat="server" ControlName="txtDetenAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDetenAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDetenAcct" ControlToValidate="txtDetenAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DetenAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDetenAcct" targetcontrolid="valDetenAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTollsAcct" CssClass="SubHead" runat="server" ControlName="txtTollsAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtTollsAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valTollsAcct" ControlToValidate="txtTollsAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="TollsAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxTollsAcct" targetcontrolid="valTollsAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plFuelAcct" CssClass="SubHead" runat="server" ControlName="txtFuelAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtFuelAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valFuelAcct" ControlToValidate="txtFuelAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="FuelAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxFuelAcct" targetcontrolid="valFuelAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plDropAcct" CssClass="SubHead" runat="server" ControlName="txtDropAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDropAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDropAcct" ControlToValidate="txtDropAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DropAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDropAcct" targetcontrolid="valDropAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plReconAcct" CssClass="SubHead" runat="server" ControlName="txtReconAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtReconAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valReconAcct" ControlToValidate="txtReconAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="ReconAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxReconAcct" targetcontrolid="valReconAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plTarpAcct" CssClass="SubHead" runat="server" ControlName="txtTarpAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtTarpAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valTarpAcct" ControlToValidate="txtTarpAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="TarpAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxTarpAcct" targetcontrolid="valTarpAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plLumperAcct" CssClass="SubHead" runat="server" ControlName="txtLumperAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtLumperAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valLumperAcct" ControlToValidate="txtLumperAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="LumperAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxLumperAcct" targetcontrolid="valLumperAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plUnloadAcct" CssClass="SubHead" runat="server" ControlName="txtUnloadAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtUnloadAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valUnloadAcct" ControlToValidate="txtUnloadAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="UnloadAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxUnloadAcct" targetcontrolid="valUnloadAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plAdminMiscAcct" CssClass="SubHead" runat="server" ControlName="txtAdminMiscAcct" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAdminMiscAcct" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valAdminMiscAcct" ControlToValidate="txtAdminMiscAcct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="AdminMiscAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxAdminMiscAcct" targetcontrolid="valAdminMiscAcct" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; Xmission &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr>
                                                <td class="SubHead" nowrap>
                                                    <p><dnn:Label ID="plTempFile1" CssClass="SubHead" runat="server" ControlName="txtTempFile1" Suffix=":"></dnn:Label> </p>
                                                </td>
                                                <td colspan="2"><asp:TextBox ID="txtTempFile1" Text="D:\FTP_ACCOUNTS\JRC\MASTXT" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="13"></asp:TextBox><asp:RequiredFieldValidator ID="valTempFile1" ControlToValidate="txtTempFile1" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="TempFile1 Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxTempFile1" targetcontrolid="valTempFile1" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plLastXferDate" CssClass="SubHead" runat="server" ControlName="txtLastXferDate" Suffix=":"></dnn:Label></td>
                                                <td nowrap colspan="2"><asp:TextBox ID="txtLastXferDate" CssClass="NormalTextBox" runat="server" Columns="10" /><asp:Image runat="server" ID="imgLastXferDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                                                    <act:CalendarExtender ID="calLastXferDate" TargetControlID="txtLastXferDate" PopupButtonID="imgLastXferDate" Animated="true" runat="server" Format="d" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plLastXmission" CssClass="SubHead" runat="server" ControlName="txtLastXmission" Suffix=":"></dnn:Label></td>
                                                <td colspan="2"><asp:TextBox ID="txtLastXmission" CssClass="NormalTextBox" runat="server" Columns="13"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plXfer" CssClass="SubHead" runat="server" ControlName="txtXfer" Suffix=":"></dnn:Label></td>
                                                <td colspan="2"><asp:TextBox ID="txtXfer" CssClass="NormalTextBox" runat="server" Columns="13"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; LoadAcctB &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plLoadAcctB" CssClass="SubHead" runat="server" ControlName="txtLoadAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtLoadAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valLoadAcctB" ControlToValidate="txtLoadAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="LoadAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxLoadAcctB" targetcontrolid="valLoadAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plDiscAcctB" CssClass="SubHead" runat="server" ControlName="txtDiscAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDiscAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDiscAcctB" ControlToValidate="txtDiscAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DiscAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDiscAcctB" targetcontrolid="valDiscAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plDetenAcctB" CssClass="SubHead" runat="server" ControlName="txtDetenAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDetenAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDetenAcctB" ControlToValidate="txtDetenAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DetenAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDetenAcctB" targetcontrolid="valDetenAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plTollsAcctB" CssClass="SubHead" runat="server" ControlName="txtTollsAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtTollsAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valTollsAcctB" ControlToValidate="txtTollsAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="TollsAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxTollsAcctB" targetcontrolid="valTollsAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plFuelAcctB" CssClass="SubHead" runat="server" ControlName="txtFuelAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtFuelAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valFuelAcctB" ControlToValidate="txtFuelAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="FuelAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxFuelAcctB" targetcontrolid="valFuelAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plDropAcctB" CssClass="SubHead" runat="server" ControlName="txtDropAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDropAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valDropAcctB" ControlToValidate="txtDropAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="DropAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDropAcctB" targetcontrolid="valDropAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plReconAcctB" CssClass="SubHead" runat="server" ControlName="txtReconAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtReconAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valReconAcctB" ControlToValidate="txtReconAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="ReconAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxReconAcctB" targetcontrolid="valReconAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plTarpAcctB" CssClass="SubHead" runat="server" ControlName="txtTarpAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtTarpAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valTarpAcctB" ControlToValidate="txtTarpAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="TarpAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxTarpAcctB" targetcontrolid="valTarpAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plLumperAcctB" CssClass="SubHead" runat="server" ControlName="txtLumperAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtLumperAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valLumperAcctB" ControlToValidate="txtLumperAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="ReconAcctB Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxLumperAcctB" targetcontrolid="valLumperAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plUnloadAcctB" CssClass="SubHead" runat="server" ControlName="txtUnloadAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtUnloadAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valUnloadAcctB" ControlToValidate="txtUnloadAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="UnloadAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxUnloadAcctB" targetcontrolid="valUnloadAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead"><dnn:Label ID="plAdminMiscAcctB" CssClass="SubHead" runat="server" ControlName="txtAdminMiscAcctB" Suffix=":"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAdminMiscAcctB" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" ReadOnly="True" Columns="8"></asp:TextBox><asp:RequiredFieldValidator ID="valAdminMiscAcctB" ControlToValidate="txtAdminMiscAcctB" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="AdminMiscAcct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxAdminMiscAcctB" targetcontrolid="valAdminMiscAcctB" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; UserInfo &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plNoOffChar" Suffix=":" ControlName="txtNoOffChar" runat="server" CssClass="SubHead" /></td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlNoOffChar" CssClass="NormalTextBox" runat="server" AutoPostBack="true">
                                                        <asp:ListItem Value="2" Text="2" Selected="True" />
                                                        <asp:ListItem Value="3" Text="3" />
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                            </tr>
                                            
                                            
                                            <tr>
                                                  <td></td>
                                               <td class="SubHead" nowrap><asp:Label ID="lblPreFix" Text="PreFix" runat="server" CssClass="SubHead"/></td>
                                               <td class="SubHead" nowrap><asp:Label ID="lblLoadNo" Text="LoadNo" runat="server" CssClass="SubHead"/></td>
                                                 </tr>
                                                 
                                                 
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plOONo" Suffix=":" ControlName="txtOONo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtOONo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="3"></asp:TextBox><asp:RequiredFieldValidator ID="valOONo" ControlToValidate="txtOONo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="OONo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxOONo" targetcontrolid="valOONo" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                    <asp:CustomValidator ID="cvOONo" runat="server" ClientValidationFunction="ClientValidate2char" ControlToValidate="txtOONo" Display="None" ErrorMessage="Length of OONo is not valid" SetFocusOnError="True" />
                                                    <act:ValidatorCalloutExtender ID="vlxOONo0" runat="Server" targetcontrolid="cvOONo" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                                <td><asp:TextBox ID="txtOOLoadNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"/><act:filteredtextboxextender id="fteOOLoadNo" runat="server" targetcontrolid="txtOOLoadNo" filtertype="Numbers" /><asp:RequiredFieldValidator ID="valOOLoadNo" ControlToValidate="txtOOLoadNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="OOLoadNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxOOLoadNo" targetcontrolid="valOOLoadNo" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                    <asp:RangeValidator ID="valOOLoadNo0" runat="server" ErrorMessage="OOLoadNo out of range" ControlToValidate="txtOOLoadNo" MaximumValue="99999" MinimumValue="0" SetFocusOnError="True" Display="None" Type="Integer"/><act:validatorcalloutextender id="vlxOOLoadNo0" targetcontrolid="valOOLoadNo0" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                    </td>
                                           
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plBKNo" Suffix=":" ControlName="txtBKNo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtBKNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="3"></asp:TextBox><asp:RequiredFieldValidator ID="valBKNo" ControlToValidate="txtBKNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="BKNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxBKNo" targetcontrolid="valBKNo" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                    <asp:CustomValidator ID="cvBKNo" runat="server" ClientValidationFunction="ClientValidate2char" ControlToValidate="txtBKNo" Display="None" ErrorMessage="Length of BKNo is not valid" SetFocusOnError="True" />
                                                    <act:ValidatorCalloutExtender ID="vlxBKNo0" runat="Server" targetcontrolid="cvBKNo" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                                <td><asp:TextBox ID="txtBKLoadNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"/><act:filteredtextboxextender id="fteBKLoadNo" runat="server" targetcontrolid="txtBKLoadNo" filtertype="Numbers" /><asp:RequiredFieldValidator ID="valBKLoadNo" ControlToValidate="txtBKLoadNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="BKLoadNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxBKLoadNo" targetcontrolid="valBKLoadNo" runat="Server" warningiconimageurl="~/images/red-error.gif" /><asp:RangeValidator ID="valBKLoadNo0" runat="server" ErrorMessage="BKLoadNo out of range" ControlToValidate="txtBKLoadNo" MaximumValue="99999" MinimumValue="0" SetFocusOnError="True" Display="None" Type="Integer"/><act:validatorcalloutextender id="vlxBKLoadNo0" targetcontrolid="valBKLoadNo0" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                           
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plAVNo" Suffix=":" ControlName="txtAVNo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtAVNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="3"></asp:TextBox><asp:RequiredFieldValidator ID="valAVNo" ControlToValidate="txtAVNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="AVNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxAVNo" targetcontrolid="valAVNo" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                    <asp:CustomValidator ID="cvAVNo" runat="server" ClientValidationFunction="ClientValidate2char" ControlToValidate="txtAVNo" Display="None" ErrorMessage="Length of AVNo is not valid" SetFocusOnError="True" />
                                                    <act:ValidatorCalloutExtender ID="vlxAVNo0" runat="Server" targetcontrolid="cvAVNo" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                                <td><asp:TextBox ID="txtAVLoadNo" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"/><act:filteredtextboxextender id="fteAVLoadNo" runat="server" targetcontrolid="txtAVLoadNo" filtertype="Numbers" /><asp:RequiredFieldValidator ID="valAVLoadNo" ControlToValidate="txtAVLoadNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="AVLoadNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxAVLoadNo" targetcontrolid="valAVLoadNo" runat="Server" warningiconimageurl="~/images/red-error.gif" /><asp:RangeValidator ID="valAVLoadNo0" runat="server" ErrorMessage="AVLoadNo out of range" ControlToValidate="txtAVLoadNo" MaximumValue="99999" MinimumValue="0" SetFocusOnError="True" Display="None" Type="Integer"/><act:validatorcalloutextender id="vlxAVLoadNo0" targetcontrolid="valAVLoadNo0" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                           
                                            </tr>
                                            <tr style="display:none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plOOLoadNo" Suffix=":" ControlName="txtOOLoadNo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                 <td></td>
                                                 <td></td>
                                                 </tr>
                                            <tr style="display:none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plBKLoadNo" Suffix=":" ControlName="txtBKLoadNo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                 <td></td>
                                                 <td></td>
                                                 </tr>
                                            <tr style="display:none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plAVLoadNo" Suffix=":" ControlName="txtAVLoadNo" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                 <td></td>
                                                 <td></td>
                                                 </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; Confirmation &nbsp;</td>
                                    <td class="jrctitletext">&nbsp; Broker Words &nbsp;</td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td class="SubHead" nowrap><asp:CheckBox ID="chkCopyAddress" CssClass="SubHead" resourcekey="chkCopyAddress" runat="server" AutoPostBack="True" /><p/></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plConfName" Suffix=":" ControlName="txtConfName" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtConfName" runat="server" CssClass="NormalTextBox" Columns="40"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plConfAddr" Suffix=":" ControlName="txtConfAddr" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtConfAddr" runat="server" CssClass="NormalTextBox" Columns="40"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plConfSTZ" Suffix=":" ControlName="txtConfSTZ" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtConfSTZ" runat="server" CssClass="NormalTextBox" Columns="40"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plConfPNo" Suffix=":" ControlName="txtConfPNo" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtConfPNo" runat="server" CssClass="NormalTextBox" Columns="40" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                    </td>
                                    <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plBWordsA" Suffix=":" ControlName="txtBWordsA" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtBWordsA" TextMode="MultiLine" Rows="4" Columns="40" runat="server" CssClass="NormalTextBox" Text="DRIVER TO CALL 1-800-285-3323 FOR DISPATCH, DAILY WHILE ENROUTE, AND UPON COMPLETION OF DELIVERY" MaxLength="250" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plBWordsB" Suffix=":" ControlName="txtBWordsB" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtBWordsB" TextMode="MultiLine" Rows="4" Columns="40" runat="server" CssClass="NormalTextBox" Text="By signing this document the carrier agrees to all terms and conditions according to the broker / JRC contracts" MaxLength="250" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="SubHead" nowrap><dnn:Label ID="plBWordsC" Suffix=":" ControlName="txtBWordsC" runat="server" CssClass="SubHead"></dnn:Label> <asp:TextBox ID="txtBWordsC" TextMode="MultiLine" Rows="4" Columns="40" runat="server" CssClass="NormalTextBox" Text="FOR  PROMPT PAYMENT, MAIL INVOICES ALONG WITH ORIGINAL PODS TO:     JRC TRANSPORTATION     PO BOX 1397     KENNEBUNK 04043     (EB # MUST APPEAR ON INVOICE)" MaxLength="250" /></td>
                                                        </tr>
                                                    </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td id="tdConfirmation" runat="server" valign="top">
                            <table class="boxdisplay" id="rblOfficeOR" runat="server" visible="false">
                                <tr>
                                    <td class="jrctitletext">&nbsp; OfficeOR &nbsp;<asp:CheckBox ID="chkOfficeOR" CssClass="Normal" runat="server" resourcekey="chkOfficeOR" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr runat="server" visible="false">
                                                <td class="SubHead" nowrap><dnn:Label ID="plOfficeOR" Suffix=":" ControlName="chkOfficeOR" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plOfficeORAcct" Suffix=":" ControlName="txtOfficeORAcct" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtOfficeORAcct" runat="server" CssClass="NormalTextBox" Columns="10"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plOfficeORPct" Suffix=":" ControlName="txtOfficeORPct" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtOfficeORPct" runat="server" CssClass="NormalTextBox NumericTextBox" Columns="10"></asp:TextBox><act:FilteredTextBoxExtender ID="fteOfficeORPct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtOfficeORPct" ValidChars="+-." />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; CommRate &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 195px">
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plDivision" Suffix=":" ControlName="txtDivision" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtDivision" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="4"></asp:TextBox><asp:RequiredFieldValidator ID="valDivision" ControlToValidate="txtDivision" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Division Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDivision" targetcontrolid="valDivision" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                            </tr>
                                            <tr style="display: none">
                                                <td class="SubHead" nowrap><dnn:Label ID="plStatus" Suffix=":" ControlName="chkStatus" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkStatus" CssClass="Normal" runat="server" resourcekey="chkStatus"></asp:CheckBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plCommRate" Suffix=":" ControlName="txtCommRate" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td nowrap><asp:TextBox ID="txtCommRate" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteCommRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRate" ValidChars="+-." /><asp:RequiredFieldValidator ID="valCommRate" ControlToValidate="txtCommRate" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="CommRate Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxCommRate" targetcontrolid="valCommRate" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plOfficePct" Suffix=":" ControlName="txtOfficePct" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtOfficePct" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteOfficePct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtOfficePct" ValidChars="+-." /><asp:RequiredFieldValidator ID="valOfficePct" ControlToValidate="txtOfficePct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="OfficePct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxOfficePct" targetcontrolid="valOfficePct" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="SubHead" nowrap><dnn:Label ID="plBKOfficePct" Suffix=":" ControlName="txtBKOfficePct" runat="server" CssClass="SubHead"></dnn:Label></td>
                                                <td><asp:TextBox ID="txtBKOfficePct" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox NumericTextBox" Columns="4"></asp:TextBox><act:FilteredTextBoxExtender ID="fteBKOfficePct" runat="server" FilterType="Numbers, Custom" TargetControlID="txtBKOfficePct" ValidChars="+-." /><asp:RequiredFieldValidator ID="valBKOfficePct" ControlToValidate="txtBKOfficePct" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="BKOfficePct Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxBKOfficePct" targetcontrolid="valBKOfficePct" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="DisplayNone" class="boxdisplay">
        <tr>
            <td>
                <table id="tblNewIO" runat="server" cellspacing="0" cellpadding="2" summary="Basic Settings Design Table" border="0">
                    <caption style="text-align: left" class="jrctitletext">
                        &nbsp; Create New InterOffice &nbsp;</caption>
                    <tr>
                        <td class="SubHead" valign="top"><dnn:Label ID="plTemplate" Text="Template:" runat="server" ControlName="cboTemplate"></dnn:Label></td>
                        <td valign="top">
                            <asp:DropDownList ID="cboTemplate" CssClass="NormalTextBox" runat="server" AutoPostBack="True"/>
                            <asp:RequiredFieldValidator ID="valTemplate" runat="server" ErrorMessage="Please select a template file" Display="None" ControlToValidate="cboTemplate" InitialValue="-1" resourcekey="valTemplate.ErrorMessage"></asp:RequiredFieldValidator><br>
                            <asp:Label ID="lblTemplateDescription" runat="server" CssClass="Normal"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plFirstName" Text="First Name:" runat="server" ControlName="txtFirstName"></dnn:Label></td>
                        <td><asp:TextBox ID="txtFirstName" Text="Jrc" CssClass="NormalTextBox" runat="server" MaxLength="100" Columns="10"></asp:TextBox><asp:RequiredFieldValidator ID="valFirstName" resourcekey="valFirstName.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plLastName" Text="Last Name:" runat="server" ControlName="txtLastName"></dnn:Label></td>
                        <td><asp:TextBox ID="txtLastName" Text="Admin" CssClass="NormalTextBox" runat="server" MaxLength="100" Columns="10"></asp:TextBox><asp:RequiredFieldValidator ID="valLastName" resourcekey="valLastName.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plUsername" Text="Username:" runat="server" ControlName="txtUsername"></dnn:Label></td>
                        <td><asp:TextBox ID="txtUsername" Text="JrcAdmin" CssClass="NormalTextBox" runat="server" MaxLength="100" Columns="10"></asp:TextBox><asp:RequiredFieldValidator ID="valUsername" resourcekey="valUsername.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plPassword" Text="Password:" runat="server" ControlName="txtPassword"></dnn:Label></td>
                        <td><asp:TextBox ID="txtPassword" Text="jrcadmin" CssClass="NormalTextBox" runat="server" MaxLength="20" Columns="10" /><asp:RequiredFieldValidator ID="valPassword" resourcekey="valPassword.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plConfirm" Text="Confirm:" runat="server" ControlName="txtConfirm"></dnn:Label></td>
                        <td><asp:TextBox ID="txtConfirm" Text="jrcadmin" CssClass="NormalTextBox" runat="server" MaxLength="20" Columns="10" /><asp:RequiredFieldValidator ID="valConfirm" resourcekey="valConfirm.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Password Confirmation Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plEmail" Text="Email:" runat="server" ControlName="txtEmail"></dnn:Label></td>
                        <td><asp:TextBox ID="txtEmail" Text="jrcadmin@jrctransportation.com" CssClass="NormalTextBox" runat="server" MaxLength="100" Columns="10"></asp:TextBox><asp:RequiredFieldValidator ID="valEmail" resourcekey="valEmail.ErrorMessage" CssClass="Normal" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Is Required." Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <p><asp:Label ID="lblMessage" CssClass="NormalRed" runat="server"></asp:Label><br>
                            <asp:DataList ID="lstResults" runat="server" CellPadding="4" CellSpacing="0" BorderWidth="0" Visible="False" Width="100%">
                                <HeaderTemplate>
                                    <span class="NormalBold">Validation Results</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span class="Normal">
                                        <%# Container.DataItem %>
                                    </span>
                                </ItemTemplate>
                            </asp:DataList></p>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2"><asp:LinkButton ID="cmdAddPortal" runat="server" resourcekey="cmdAddPortal" CssClass="CommandButton" Text="AddPortal" BorderStyle="none"></asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divPopup" runat="server" />
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center">
                <asp:Literal ID="lblMsg" runat="server" EnableViewState="false" />
                <asp:ValidationSummary ID="valValidationSummary" runat="server" CssClass="NormalRed" />
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
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /></td>
        </tr>
    </table>
    <p>
    <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
    <Portal:Tracking ID="ctlTracking" runat="server" />
    </p>
</center>
<table style="display: none" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <td class="SubHead" style="height: 29px"></td>
        <td class="Normal" style="height: 29px"></td>
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
        <td class="SubHead"><dnn:Label ID="plAddressLine2" Suffix=":" ControlName="txtAddressLine2" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plState" Suffix=":" ControlName="txtState" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plZipCode" Suffix=":" ControlName="txtZipCode" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" height="15"></td>
        <td class="Normal" height="15"></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plAdminExempt" Suffix=":" ControlName="chkAdminExempt" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAdminExempt" CssClass="Normal" resourcekey="chkAdminExempt" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" height="24"></td>
        <td class="Normal" height="24"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLoadType" Suffix=":" ControlName="txtLoadType" runat="server" CssClass="SubHead"></dnn:Label></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plOfficeCodeNo" Suffix=":" ControlName="txtOfficeCodeNo" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtOfficeCodeNo" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plOfficName" Suffix=":" ControlName="txtOfficName" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtOfficName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plOfficeAddr" Suffix=":" ControlName="txtOfficeAddr" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtOfficeAddr" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plOfficeAbrv" Suffix=":" ControlName="txtOfficeAbrv" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtOfficeAbrv" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plUseDispatch" Suffix=":" ControlName="chkUseDispatch" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkUseDispatch" CssClass="Normal" resourcekey="chkUseDispatch" runat="server" /></td>
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
        <td class="Normal">&nbsp;</td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plAllowORide" Suffix=":" ControlName="chkAllowORide" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAllowORide" CssClass="Normal" resourcekey="chkAllowORide" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRCAdminP" Suffix=":" ControlName="txtJRCAdminP" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCAdminP" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plReminder" Suffix=":" ControlName="txtReminder" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtReminder" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDefDispNo" Suffix=":" ControlName="txtDefDispNo" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDefDispNo" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDefDispName" Suffix=":" ControlName="txtDefDispName" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDefDispName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plMultiSing" Suffix=":" ControlName="chkMultiSing" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><td class="Normal">
            <asp:CheckBox ID="chkMultiSing" CssClass="Normal" resourcekey="chkMultiSing" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAutoLoadSeq" Suffix=":" ControlName="chkAutoLoadSeq" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAutoLoadSeq" CssClass="Normal" resourcekey="chkAutoLoadSeq" runat="server" /></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plInitQForCust" Suffix=":" ControlName="chkInitQForCust" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkInitQForCust" CssClass="Normal" resourcekey="chkInitQForCust" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDay0" Suffix=":" ControlName="txtDay0" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDay0" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDay7" Suffix=":" ControlName="txtDay7" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDay7" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDay15" Suffix=":" ControlName="txtDay15" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDay15" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plDay30" Suffix=":" ControlName="txtDay30" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDay30" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plAlumaPct" Suffix=":" ControlName="txtAlumaPct" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtAlumaPct" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLastcorpbu" Suffix=":" ControlName="txtLastcorpbu" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLastcorpbu" runat="server" CssClass="NormalTextBox"></asp:TextBox>&nbsp;<asp:HyperLink ID="cmdCalendarLastcorpbu" CssClass="CommandButton" Text="Calendar" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plCNOfficName" Suffix=":" ControlName="txtCNOfficName" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtCNOfficName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plOffOrgin" Suffix=":" ControlName="txtOffOrgin" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtOffOrgin" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTSL" Suffix=":" ControlName="txtTSL" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTSL" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plTPBCalc" Suffix=":" ControlName="txtTPBCalc" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtTPBCalc" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLastCustUpd" Suffix=":" ControlName="txtLastCustUpd" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLastCustUpd" runat="server" CssClass="NormalTextBox"></asp:TextBox>&nbsp;<asp:HyperLink ID="cmdCalendarLastCustUpd" CssClass="CommandButton" Text="Calendar" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar"></asp:HyperLink></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLastUpdTime" Suffix=":" ControlName="txtLastUpdTime" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLastUpdTime" runat="server" CssClass="NormalTextBox"></asp:TextBox>&nbsp;<asp:HyperLink ID="cmdCalendarLastUpdTime" CssClass="CommandButton" Text="Calendar" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar"></asp:HyperLink></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plUserOn" Suffix=":" ControlName="txtUserOn" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtUserOn" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plMgrCode" Suffix=":" ControlName="txtMgrCode" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtMgrCode" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plMgrName" Suffix=":" ControlName="txtMgrName" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtMgrName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plCommRatex" Suffix=":" ControlName="txtCommRatex" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtCommRatex" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plBKCommRate" Suffix=":" ControlName="txtBKCommRate" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtBKCommRate" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plMGRSplit" Suffix=":" ControlName="chkMGRSplit" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal">
            <asp:CheckBox ID="chkMGRSplit" CssClass="Normal" resourcekey="chkMGRSplit" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plIODiv" Suffix=":" ControlName="txtIODiv" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtIODiv" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLogDisp" Suffix=":" ControlName="txtLogDisp" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLogDisp" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLogDispName" Suffix=":" ControlName="txtLogDispName" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLogDispName" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plLogonOffice" Suffix=":" ControlName="txtLogonOffice" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtLogonOffice" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="SubHead" nowrap><dnn:Label ID="plJRCOfficeNo" Suffix=":" ControlName="txtJRCOfficeNo" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtJRCOfficeNo" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plDvrDAcct2" Suffix=":" ControlName="txtDvrDAcct2" runat="server" CssClass="SubHead"></dnn:Label></td>
        <td class="Normal"><asp:TextBox ID="txtDvrDAcct2" runat="server" CssClass="NormalTextBox"></asp:TextBox></td>
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
        <td class="SubHead" nowrap><dnn:Label ID="plViewOrder" Suffix=":" ControlName="txtViewOrder" runat="server" CssClass="SubHead"></dnn:Label></td>
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
