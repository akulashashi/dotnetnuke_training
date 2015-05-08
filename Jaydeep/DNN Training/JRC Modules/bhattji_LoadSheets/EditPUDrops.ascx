<%@ Control Language="VB" AutoEventWireup="False" CodeBehind="EditPUDrops.ascx.vb" Inherits="bhattji.Modules.LoadSheets.EditPUDrops" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:UpdateProgress ID="uprEditPUDrops" runat="server">
    <progresstemplate>
    <table width="100%" class="UpdateProgressClass"><tr><td></td></tr></table>
        <center style="position:absolute;width:100%;height:1000px;vertical-align:middle;z-index:2000;"><asp:Image ID="imgUpdateProgress" ImageUrl="~/images/under_construction.gif" runat="server" Width="200" /><br /><asp:Image ID="imgProgressBar" ImageUrl="~/images/progressbar.gif" runat="server" Width="200" /></center>
    </progresstemplate>
</asp:UpdateProgress>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="loadeditnav1">
            <tr>
                <td><img src="/images/superior_16.gif" width="7" height="28" /></td>
                <td width="100%" background="/images/superior_17.gif">
                    <table width="524" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbHome" Text="Home" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbHome" ImageUrl="~/images/home.png" resourcekey="lnbHome" BorderStyle="none" runat="server" /></td>
                            
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateLoadsheet" Text="Load Edit" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateLoadsheet" ImageUrl="~/images/update_to_load.png" resourcekey="update_to_accounting" BorderStyle="none" runat="server" AlternateText="Save, then go to loadsheet" /></td>
                        
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateAccounting" Text="Edit Accounting" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateAccounting" ImageUrl="~/images/update_to_accounting.png" resourcekey="update_to_accounting" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateAddNew" Text="Add Load" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateAddNew" ImageUrl="~/images/update_and_add.png" resourcekey="update_and_add" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbUpdateToList" Text="View Loads" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbUpdateToList" ImageUrl="~/images/update_and_list.png" resourcekey="update_and_list" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbPrint" Text="Print Load" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbPrint" ImageUrl="~/images/print_this.png" resourcekey="print_this" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbPrintConfirm" Text="Print Confirm" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbPrintConfirm" ImageUrl="~/images/print_this.png" resourcekey="print_Confirm" BorderStyle="none" runat="server" /></td>
                            <%--
                            <td class="DisplayNone" align="center" valign="middle" width="32"><asp:LinkButton ID="lnbEmail" Text="eMail" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td class="DisplayNone" width="32"><asp:ImageButton ID="imbEmail" ImageUrl="~/images/email_this.png" resourcekey="email_this" BorderStyle="none" runat="server" /></td>
                            <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                            <td class="DisplayNone" align="center" valign="middle" width="32"><asp:LinkButton ID="lnbCopyLoad" Text="Copy" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" ToolTip="Copy, Convert or Template this Load" /></td>
                            <td class="DisplayNone" width="15"><asp:ImageButton ID="imbCopyLoad" ImageUrl="~/images/icon_lists_32px.gif" ToolTip="Copy, Convert or Template this Load" BorderStyle="none" OnClientClick="return confirm('Do you really wish to Copy this Load ?')" runat="server" /></td>
                            <td valign="middle" class="NormalBold" id="tdVoid" runat="server">
                                <table width="66" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="32" valign="middle">
                                            <div align="right">
                                                <asp:LinkButton ID="lnbVoidLoad" Text="Void" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CausesValidation="false" />
                                            </div>
                                        </td>
                                        <td width="32" valign="middle"><asp:ImageButton ID="imbVoidLoad" ImageUrl="~/images/void_load.png" resourcekey="void_load" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to VOID this Load ?')" runat="server" CausesValidation="false" /></td>
                                        <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="middle" class="NormalBold" id="tdUnVoid" runat="server" visible="false">
                                <table width="66" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="32" valign="middle">
                                            <div align="right">
                                                <asp:LinkButton ID="inbUnVoidLoad" Text="UnVoid" CssClass="topikons" BorderStyle="none" OnClientClick="return confirm('Do you really wish to UNVOID this Load ?')" runat="server" />
                                            </div>
                                        </td>
                                        <td width="32" valign="middle"><asp:ImageButton ID="imbUnVoidload" ImageUrl="~/images/arrowleft32.png" resourcekey="Unvoid_load" CssClass="CommandButton" BorderStyle="none" OnClientClick="return confirm('Do you really wish to UNVOID this Load ?')" runat="server" /></td>
                                        <td width="2"><img src="/images/superior_21.gif" width="2" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td><img src="/images/superior_21.gif" width="2" /></td>
                            <td align="center" valign="middle" width="32"><asp:LinkButton ID="lnbCancelReload" Text="Undo" CssClass="topikons" BorderStyle="none" runat="server" /></td>
                            <td width="32"><asp:ImageButton ID="imbCancelReload" ImageUrl="~/images/cancel_changes.png" resourcekey="cancel_changes" BorderStyle="none" runat="server" /></td>
                            --%>
                        </tr>
                  </table>                </td>
                <td><img src="/images/superior_24.gif" width="7" height="28" /></td>
            </tr>
            <tr>
              <td colspan="3"></td>
            </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="4">
          <tr>
            <td><table width="780">
              <tr>
                <td colspan="2" align="center"><table>
                    <tr>
                      <td class="Normal">LoadId:</td>
                      <td><asp:Label ID="lblLoadId" runat="server" CssClass="SubHead" /></td>
                      <td class="Normal">Customer:</td>
                      <td><asp:Label ID="lblCustomer" runat="server" CssClass="SubHead" /></td>
                      <td class="Normal">Driver:</td>
                      <td><asp:Label ID="lblDriver" runat="server" CssClass="SubHead" /></td>
                      <td class="Normal">PO#:</td>
                      <td><asp:Label ID="lblCustPO" runat="server" CssClass="SubHead" /></td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td width="384" align="center" valign="top"><div align="center" class="bighead"> Pickups </div></td>
                <td width="384" align="center" valign="top"><div align="center" class="bighead"> Drops </div></td>
              </tr>
              <tr>
                <td valign="top"><asp:PlaceHolder ID="phtLoadPUs" runat="server" />            
                </td>
                <td align="right" valign="top"><asp:PlaceHolder ID="phtLoadDrops" runat="server" />            
                </td>
              </tr>
              <%--
                <tr>
                    <td colspan="2" align="center">
                        <asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="Listing" resourcekey="Listing" />
                            <asp:ListItem Value="NewItem" resourcekey="NewItem" />
                            <asp:ListItem Value="EditItem" resourcekey="EditItem" />
                            <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
                            <asp:ListItem Value="Accounting" resourcekey="Accounting" />
                        </asp:DropDownList>
                        <br />
                        <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                        <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                    </td>
                </tr>
                --%>
              <tr>
                <td colspan="2" align="center" class="displaynone"><asp:HyperLink ID="hypBack" NavigateUrl="javascript:history.go(-1);" ImageUrl="~/images/arrowleft32.png" resourcekey="cmdBack" CssClass="CommandButton" BorderStyle="none" runat="server" />            
                    <asp:HyperLink ID="hypBack1" NavigateUrl="javascript:history.go(-1);" Text="Back" resourcekey="cmdBack" CssClass="CommandButton" BorderStyle="none" runat="server" />              
                </td>
              </tr>
            </table></td>
          </tr>
        </table>
        