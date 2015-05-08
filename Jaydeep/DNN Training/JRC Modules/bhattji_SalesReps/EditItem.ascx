<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.SalesReps.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<center>
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
    <table id="jrcmaintable" class="boxdisplay">
        <tr>
            <td class="jrctitletext">&nbsp; Sales Representative &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plRepNo" ControlName="txtRepNo" Suffix=":" CssClass="SubHead" runat="server" />
                            <asp:Literal ID="lblMsgId" runat="server" EnableViewState="false" />
                        </td>
                        <td class="Normal"><asp:TextBox ID="txtRepNo" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" MaxLength="7" /><asp:CustomValidator ID="cvRepNo" runat="server" ErrorMessage="<br />Rep No must be 7 digit long" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtRepNo" Display="None" SetFocusOnError="True"></asp:CustomValidator><act:validatorcalloutextender id="vlxRepNo0" targetcontrolid="cvRepNo" runat="Server" warningiconimageurl="~/images/red-error.gif" /><act:FilteredTextBoxExtender ID="actRepNo" runat="server" TargetControlID="txtRepNo" FilterType="Numbers" /><asp:RequiredFieldValidator ID="valRepNo" ControlToValidate="txtRepNo" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="RepNo Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxRepNo" targetcontrolid="valRepNo" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plRepName" ControlName="txtRepName" Suffix=":" CssClass="SubHead" runat="server" /> </td>
                        <td class="Normal"><asp:TextBox ID="txtRepName" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" /><asp:RequiredFieldValidator ID="valRepName" ControlToValidate="txtRepName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="RepName Cannot be null"/><act:validatorcalloutextender id="vlxRepName" targetcontrolid="valRepName" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plRepRate" ControlName="txtRepRate" Suffix=":" CssClass="SubHead" runat="server" /> </td>
                        <td class="Normal"><asp:TextBox ID="txtRepRate" CssClass="NormalTextBox NumericTextBox" runat="server" AutoPostBack="True" /><act:FilteredTextBoxExtender ID="fteRepRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepRate" ValidChars="+-." />
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plRepDollar" ControlName="txtRepDollar" Suffix=":" CssClass="SubHead" runat="server" /> </td>
                        <td class="Normal"><asp:TextBox ID="txtRepDollar" CssClass="NormalTextBox NumericTextBox" runat="server" AutoPostBack="True" /><act:FilteredTextBoxExtender ID="fteRepDollar" runat="server" FilterType="Numbers, Custom" TargetControlID="txtRepDollar" ValidChars="+-." />
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plSecPinA" ControlName="txtSecPinA" Suffix=":" CssClass="SubHead" runat="server" /> </td>
                        <td class="Normal"><asp:TextBox ID="txtSecPinA" CssClass="NormalTextBox NumericTextBox" runat="server" /><act:FilteredTextBoxExtender ID="fteSecPinA" runat="server" FilterType="Numbers" TargetControlID="txtSecPinA" />
                        <asp:RangeValidator ID="valSecPinA" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="Security Pin A, has to be between 1 &amp; 31" MaximumValue="31" MinimumValue="1" SetFocusOnError="True" ControlToValidate="txtSecPinA" Type="Integer"/></td>
                    </tr>
                    <tr>
                        <td class="SubHead"><dnn:Label ID="plSecPinB" ControlName="txtSecPinB" Suffix=":" CssClass="SubHead" runat="server" /> </td>
                        <td class="Normal"><asp:TextBox ID="txtSecPinB" CssClass="NormalTextBox NumericTextBox" runat="server" /><act:FilteredTextBoxExtender ID="fteSecPinB" runat="server" FilterType="Numbers" TargetControlID="txtSecPinB" />
                        <asp:RangeValidator ID="valSecPinB" runat="server" CssClass="NormalRed" Display="Dynamic" ErrorMessage="Security Pin B, has to be between 1 &amp; 12" MaximumValue="12" MinimumValue="1" SetFocusOnError="True" ControlToValidate="txtSecPinB" Type="Integer" />
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="lblMsg" runat="server" EnableViewState="false" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center">
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
    <p>
    <Portal:Audit ID="ctlAudit" runat="server" />
    </p>
    <p>
    <Portal:Tracking ID="ctlTracking" runat="server" />
    <p>
    <table style="display: none" id="Table2" cellspacing="1" cellpadding="1" border="1">
        <tr>
            <td><dnn:Label CssClass="SubHead" ID="plViewOrder" runat="server" ControlName="txtViewOrder" Suffix=":"></dnn:Label> </td>
            <td><asp:TextBox CssClass="NormalTextBox" ID="txtViewOrder" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    </p>
</center>
