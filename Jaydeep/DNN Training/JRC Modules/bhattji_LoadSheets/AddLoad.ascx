<%@ Control Language="vb" AutoEventWireup="False" CodeBehind="AddLoad.ascx.vb" Inherits="bhattji.Modules.LoadSheets.AddLoad" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<script type="text/javascript">
function ClientValidate7char(source, clientside_arguments)
{
    clientside_arguments.IsValid=(clientside_arguments.Value.length  == 7);
}
</script>
<center>
    <table id="jrcmaintable" runat="server" class="boxdisplay">
        <tr>
            <td>
                <table width="700" cellpadding="0" cellspacing="0" border="0">
                    <tr class="jrctitletext">
                        <td style="text-align: left; font-size: 14px;">&nbsp;New Load</td>
                        <td style="text-align: right; font-size: 14px;">
                            <asp:Literal ID="plLoadDate" runat="server" Text="Load Date:" />
                            <asp:TextBox ID="txtLoadDate" runat="server" Columns="15" Style="background-color: Red; color: White; font-size: 14px;" />&nbsp;<asp:HyperLink ID="hypLoadDate" runat="server" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar" Style="cursor: hand" />&nbsp;<act:CalendarExtender ID="calLoadDate" TargetControlID="txtLoadDate" PopupButtonID="hypLoadDate" runat="server" Format="d" />
                            <asp:RangeValidator ID="valLoadDate" runat="server" ControlToValidate="txtLoadDate" Display="None" ErrorMessage="<br>Load Date needs to be within range" MaximumValue="12/12/2020" MinimumValue="1/1/2000" Type="Date" SetFocusOnError="True" /><act:ValidatorCalloutExtender ID="vlxLoadDate" runat="Server" TargetControlID="valLoadDate" WarningIconImageUrl="~/images/red-error.gif" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tblLoadType" runat="server" width="700" cellpadding="5" cellspacing="0">
                    <tr>
                        <td><dnn:Label ID="plLoadType" runat="server" ControlName="rblLoadType" Suffix=":" style="font-size: 12px;" CssClass="SubHead" /></td>
                        <td class="Normal" colspan="2">
                            <asp:RadioButtonList ID="rblLoadType" RepeatDirection="Horizontal" AutoPostBack="True" runat="server" Style="font-size: 16px; font-weight: bold;">
                                <asp:ListItem Value="OO" resourcekey="Driver" />
                                <asp:ListItem Value="IO" resourcekey="InterOffice" />
                                <asp:ListItem Value="BK" resourcekey="Broker" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="valLoadType" runat="server" ErrorMessage="<b>LoadType Required</b><br/>Select the Load Type for the New load to be added" ControlToValidate="rblLoadType" resourcekey="LoadType.ErrorMessage" CssClass="NormalRed" Display="None" /><act:ValidatorCalloutExtender runat="Server" ID="vlxLoadType" TargetControlID="valLoadType" WarningIconImageUrl="~/images/red-error.gif" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tblOfficeCode" runat="server" class="boxdisplay">
        <tr>
            <td>
                <table id="tblJRCIOfficeCode" runat="server" width="700">
                    <tr>
                        <td class="DisplayNone" colspan="3"><dnn:Label ID="plJRCIOfficeCode" runat="server" ControlName="rblOfficeVendorNO" Suffix=":" CssClass="SubHead" /></td>
                    </tr>
                    <tr>
                        <td class="SubHead" colspan="3">
                            <asp:RadioButtonList ID="rblOfficeVendorNO" runat="server" CssClass="NormalTextBox" RepeatColumns="4" AutoPostBack="True" Width="680" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="boxdisplay">
        <tr>
            <td style="text-align: left" class="jrctitletext"><dnn:Label ID="plOperationType" runat="server" ControlName="rblOperationType" Suffix=":" CssClass="jrctitletext" /></td>
        </tr>
        <tr>
            <td>
                <table width="700" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="SubHead" colspan="2" valign="top">
                            <asp:RadioButtonList ID="rblOperationType" CssClass="NormalTextBox" RepeatDirection="Horizontal" AutoPostBack="True" runat="server">
                                <asp:ListItem Value="NewLoad" Selected="True" resourcekey="NewLoad" />
                                <asp:ListItem Value="IoRecovery" resourcekey="IoRecovery" />
                                <asp:ListItem Value="ConvertLoad" resourcekey="ConvertLoad" />
                                <asp:ListItem Value="CopyLoad" resourcekey="CopyLoad" />
                            </asp:RadioButtonList>
                        </td>
                        <td id="tdIoRecovery" runat="server" class="SubHead" valign="top">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td nowrap="nowrap" align="right" valign="middle"><dnn:Label ID="plIoRecoveryLoadId" runat="server" ControlName="txtIoRecoveryLoadId" Suffix=":" CssClass="SubHead" ResourceKey="plIoRecoveryLoadId" />&nbsp;&nbsp;</td>
                                    <td valign="middle"><asp:TextBox ID="txtIoRecoveryLoadId" CssClass="NormalTextBox" runat="server" /></td>
                                    <td valign="bottom"><asp:ImageButton ID="btnIoRecovery" runat="server" ImageUrl="~/images/Retrieve.png" CausesValidation="False" /></td>
                                </tr>
                            </table>
                            <asp:CustomValidator ID="cvIoRecoveryLoadId" runat="server" ErrorMessage="<b>Error !!!</b><br />IO Recovery LoadId Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtIoRecoveryLoadId" Display="None" /><act:ValidatorCalloutExtender ID="vlxIoRecoveryLoadId" runat="Server" TargetControlID="cvIoRecoveryLoadId" WarningIconImageUrl="~/images/red-error.gif" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="703" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="50%" valign="top" nowrap="nowrap" align="left">
                <table id="jrccustomertable" runat="server" class="boxdisplay" width="100%" style="margin-top: 3px;">
                    <tr>
                        <td style="text-align: left" class="jrctitletext">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td valign="top"><asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" AutoPostBack="true" Columns="55" /><asp:Panel ID="pnlCustomerNumber" Height="100px" ScrollBars="Vertical" runat="server" />
                                        <act:AutoCompleteExtender ID="aceCustomerNumber" CompletionListElementID="pnlCustomerNumber" MinimumPrefixLength="1" ServicePath="~/DesktopModules/bhattji.LoadSheets/WebService.asmx" ServiceMethod="GetCustomerNames" runat="server" TargetControlID="txtCustomerNumber" CompletionListCssClass="CompletionListCssClass" CompletionListItemCssClass="CompletionListItemCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass" CompletionSetCount="100" EnableCaching="true" />
                                        <asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                                    <td valign="top" class="displaynone">
                                        <asp:RadioButtonList ID="rblCustomerSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="S" Selected="True">
                                <blockquote>
                                  <p>Starts</p>
                                </blockquote>
                                            </asp:ListItem>
                                            <asp:ListItem Value="A">
                                <blockquote>
                                  <p>Contains</p>
                                </blockquote>
                                            </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblCustomer" runat="server" width="100%">
                                <tr>
                                    <td class="Normal">
                                        <nobr>
                    <table>
                        <tr>
                          <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td width="23%"><span class="subhead" style="text-align: left">&nbsp;Customer </span></td>
                              <td width="77%"><span class="emaildrop">
                                <asp:DropDownList ID="ddlCustomerNumber" runat="server" CssClass="emaildrop" AutoPostBack="True">
                                  <asp:ListItem Value="0000000" Text="No Customer" />                          
                                </asp:DropDownList>
                              </span></td>
                            </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td><asp:Label ID="lblCustomer" runat="server" CssClass="NormalBold" /></td>
                        </tr>
                  </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" valign="top" nowrap="nowrap" align="right">
                <table id="jrcdrivertable" runat="server" class="boxdisplay" width="100%" style="margin-left: 3px; margin-top: 3px;">
                    <tr>
                        <td style="text-align: left" class="jrctitletext">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20%"><span class="jrctitletext" style="text-align: left"><dnn:Label ID="plDriverName" runat="server" ControlName="ddlDriverCode" Suffix=":" CssClass="jrctitletext" ResourceKey="plDriverName"></dnn:Label></span></td>
                                    <td width="80%"><span class="Normal">
                                        <asp:DropDownList ID="ddlDriverCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                                            <asp:ListItem Value="ZXZX" Text="No Driver Selected" />
                                        </asp:DropDownList>
                                    </span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tbldrivertable" runat="server" width="100%">
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plDriverCode" runat="server" ControlName="txtDriverCode" Suffix=":" CssClass="SubHead" ResourceKey="plDriverCode"></dnn:Label></td>
                                    <td class="Normal">
                                        <nobr>
                    <table>
                      <tbody>
                        <tr>
                          <td class="SubHead">Driver</td>
                          <td rowspan="2"><asp:imagebutton id="btnDriverSearch" Runat="server" ImageUrl="~/images/view.gif" CausesValidation="false" /></td>
                          <td class="SubHead">Driver Code</td>
                        </tr>
                        <tr>
                          <td><asp:radiobuttonlist id="rblDriverSearchType" CssClass="NormalTextBox" Runat="server" RepeatDirection="Horizontal">
                              <asp:ListItem Value="S" Selected="True">StartsWith</asp:ListItem>
                              <asp:ListItem Value="A">Contains</asp:ListItem>
                          </asp:radiobuttonlist></td>
                          <td><asp:textbox id="txtDriverName" runat="server" CssClass="NormalTextBox"></asp:textbox></td>
                          <td><asp:textbox id="txtDriverCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True"></asp:textbox></td>
                        </tr>
                      </tbody>
                    </table>
                  </nobr>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">&nbsp;</td>
                                    <td class="Normal"><asp:Label ID="lblDriver" runat="server" CssClass="NormalBold" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"></td>
                                    <td class="Normal">
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="jrcIOtable" runat="server" class="boxdisplay" style="margin-top: 3px; margin-left: 3px;" width="100%">
                    <tr>
                        <td style="text-align: left" class="jrctitletext">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="26%"><span class="jrctitletext" style="text-align: left">&nbsp;InterOffice</span></td>
                                    <td width="74%"><span class="Normal">
                                        <asp:DropDownList ID="ddlIOCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True" />
                                    </span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblIOtable" runat="server" width="100%">
                                <tr style="display: none">
                                    <td class="SubHead"><dnn:Label ID="plIOCode" runat="server" ControlName="txtIOCode" Suffix=":" CssClass="SubHead" ResourceKey="plIOCode" /></td>
                                    <td class="Normal" colspan="2">
                                        <nobr><asp:radiobuttonlist id="rblIOSearchType" RepeatDirection="Horizontal" CssClass="NormalTextBox" Runat="server">
								<asp:listitem Value="S" resourcekey="StartsWith">StartsWith</asp:listitem>
								<asp:listitem Value="A" resourcekey="Contains" Selected="True">Contains</asp:listitem>
							</asp:radiobuttonlist><table><tbody><tr><td class="SubHead">Office No</td><td class="SubHead">Office Name</td><td rowSpan=2><asp:imagebutton id="btnIOSearch" ImageUrl="~/images/view.gif" Runat="server" CausesValidation="False"></asp:imagebutton></td></tr><tr><td><asp:textbox id="txtIOCode" runat="server" AutoPostBack="True" CssClass="NormalTextBox"></asp:textbox></td><td><asp:textbox id="txtIOName" runat="server" CssClass="NormalTextBox"></asp:textbox></td></tr></tbody></table></nobr>
                                    </td>
                                </tr>
                                <tr>
                                    <td><dnn:Label ID="plCanRecover" runat="server" ControlName="ddlCanRecover" Suffix=":" CssClass="SubHead" Text="Dispatcher" /></td>
                                    <td class="Normal" valign="top">
                                        <asp:DropDownList ID="ddlCanRecover" DataValueField="DispatchCode" DataTextField="DispatchName" runat="server" CssClass="NormalTextBox" />
                                    </td>
                                    <td class="Normal" valign="top">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="displaynone"><dnn:Label ID="plIOName" runat="server" ControlName="txtIOName" Suffix=":" CssClass="SubHead" ResourceKey="plIOName"></dnn:Label></td>
                                    <td class="displaynone" valign="top">
                                        <asp:RequiredFieldValidator ID="valIOCode" runat="server" CssClass="NormalRed" ControlToValidate="ddlIOCode" InitialValue="999999999" ErrorMessage="You cant have the IO load for the same office" />
                                        <asp:Label ID="lblIO" runat="server" CssClass="NormalBold"></asp:Label> <br />
                                    </td>
                                    <td class="Normal" valign="top">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table id="jrcbrokertable" runat="server" class="boxdisplay" style="margin-top: 3px; margin-left: 3px;" width="100%">
                    <tr>
                        <td style="text-align: left" class="jrctitletext">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td><asp:TextBox ID="txtBrokerCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true" Columns="55" /><asp:Panel ID="pnlBrokerCode" Height="100px" ScrollBars="Vertical" runat="server" />
                                        <act:AutoCompleteExtender ID="aceBrokerCode" CompletionListElementID="pnlBrokerCode" MinimumPrefixLength="1" ServicePath="~/DesktopModules/bhattji.LoadSheets/WebService.asmx" ServiceMethod="GetBrokerNames" runat="server" TargetControlID="txtBrokerCode" CompletionListCssClass="CompletionListCssClass" CompletionListItemCssClass="CompletionListItemCssClass" CompletionListHighlightedItemCssClass="CompletionListHighlightedItemCssClass" CompletionSetCount="25" EnableCaching="true" />
                                        <asp:ImageButton ID="btnBrokerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" />
                                        <nobr>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblbrokertable" runat="server" width="100%">
                                <tr>
                                    <td class="Normal" valign="top">
                                        <table id="tblBroker" runat="server">
                                            <tr>
                                                <td><span class="subhead" style="text-align: left">&nbsp;Broker</span></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBrokerCode" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                                                        <asp:ListItem Value="0000000" Text="No Broker" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="lblBokerName" Text="BrokerName" CssClass="displaynone" runat="server" /></td>
                                                <td class="Normal"><asp:Label ID="lblBroker" runat="server" CssClass="NormalBold" /><asp:Label ID="lblBkrDriver" runat="server" CssClass="NormalBold" /></td>
                                            </tr>
                                            <tr>
                                                <td class="displaynone">
                                                    <asp:RadioButtonList ID="rblBrokerSearchType" RepeatDirection="Horizontal" CssClass="NormalTextBox" runat="server">
                                                        <asp:ListItem Value="S" resourcekey="StartsWith" Selected="True" />
                                                        <asp:ListItem Value="A" resourcekey="Contains" />
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td class="Normal">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" nowrap="nowrap">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top"><span class="SubHead"><dnn:Label ID="plBkrDriverNo" ControlName="ddlBkrDriverNo" Suffix=":" CssClass="SubHead" runat="server" /></span></td>
                                                <td valign="top"><span class="SubHead">
                                                    <asp:DropDownList ID="ddlBkrDriverNo" runat="server" CssClass="NormalTextBox" AutoPostBack="True">
                                                        <asp:ListItem Value="ZXZX" Text="N/A" />
                                                    </asp:DropDownList>
                                                </span></td>
                                            </tr>
                                            <tr>
                                                <td valign="top"><span class="SubHead"><dnn:Label ID="plBkrInvNo" ControlName="txtBkrInvNo" Suffix=":" CssClass="SubHead" runat="server" /></span></td>
                                                <td valign="top"><span class="SubHead"><asp:TextBox ID="txtBkrInvNo" CssClass="NormalTextBox" runat="server" Columns="10" /> </span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>                
                <table id="tblTrailerDetails" runat="server" class="boxdisplay" style="margin-top: 3px; margin-left: 3px;" width="100%">
                    <tr>
                        <td style="text-align: left" class="jrctitletext">Trailer Details</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="SubHead"><dnn:Label ID="plTrailerType" ControlName="ddlTrailerType" Suffix=":" CssClass="SubHead" runat="server" />
                                        <asp:DropDownList ID="ddlTrailerType" CssClass="NormalTextBox" runat="server">
                                            <asp:ListItem Value="" Text="" />
                                            <asp:ListItem Value="FD" Text="Flatbed" />
                                            <asp:ListItem Value="SD" Text="Stepdeck" />
                                            <asp:ListItem Value="RG" Text="RGN" />
                                            <asp:ListItem Value="DD" Text="Double Drop" />
                                            <asp:ListItem Value="48" Text="Van 48'" />
                                            <asp:ListItem Value="53" Text="Van 53'" />
                                            <asp:ListItem Value="20" Text="20' container" />
                                            <asp:ListItem Value="40" Text="40' container" />
                                            <%--
                                            <asp:ListItem Value="FT" Text="FT" />
                                            <asp:ListItem Value="F" Text="F" />
                                            --%>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="SubHead"><dnn:Label ID="plTrailerNumber" ControlName="txtTrailerNumber" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtTrailerNumber" CssClass="NormalTextBox" runat="server" /></td>
                                    <td class="SubHead" nowrap><dnn:Label ID="plTrailerDue" ControlName="txtTrailerDue" Suffix=":" CssClass="SubHead" runat="server" /><asp:TextBox ID="txtTrailerDue" Columns="10" CssClass="NormalTextBox" runat="server" /><asp:HyperLink ID="cmdCalendarTrailerDue" CssClass="CommandButton" runat="server" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMsg" runat="server" EnableViewState="False" CssClass="NormalRed" />
    <table>
        <tr>
            <td class="NormalBold" align="center" width="10%"><asp:ImageButton ID="imbCancel" ImageUrl="~/images/cancel_changes.png" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdCancel" runat="server" resourcekey="cmdCancel" BorderStyle="none" CssClass="CommandButton" CausesValidation="False"></asp:LinkButton>
            </td>
            <td class="NormalBold" align="center" width="10%"><asp:ImageButton ID="imbAdd" ImageUrl="~/images/update_and_add.png" resourcekey="Add" BorderStyle="none" CssClass="CommandButton" runat="server" /><br />
                <asp:LinkButton ID="cmdAdd" resourcekey="Add" BorderStyle="none" CssClass="CommandButton" runat="server" />
            </td>
        </tr>
    </table>
</center>
<script language="javascript" type="text/javascript">window.history.forward(1);</script>
