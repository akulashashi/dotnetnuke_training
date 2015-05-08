<%@ Control Language="c#" AutoEventWireup="true" Codebehind="Details.ascx.cs" Inherits="bhattji.Modules.Customers.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<table id="Table1" cellspacing="1" cellpadding="1" width="712" border="0">
    <tr>
        <td valign="top">
            <table id="jrcmaintable" runat="server" class="boxdisplay">
                                <tr>
                                    <td class="jrctitletext">&nbsp; Customer ID &nbsp;</td>
                                </tr>
                <tr>
                    <td>
                        <table id="Table3" style="width:385px">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plCustomerStatus" CssClass="SubHead" ControlName="ddlCustomerStatus"
                                        Suffix=":" runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="ddlCustomerStatus" CssClass="NormalBold" runat="server"></asp:Label></td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plCStatus" CssClass="SubHead" ControlName="ddlCStatus" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="ddlCStatus" CssClass="NormalBold" RepeatDirection="Horizontal"
                                        runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="Table4" runat="server" class="boxdisplay">
                <tr>
                <td class="jrctitletext">&nbsp; Customer &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table id="Table9" style="width:385px">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plCustomerNumber" CssClass="SubHead" ControlName="txtCustomerNumber"
                                        Suffix=":" runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtCustomerNumber" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plCustomerName" CssClass="SubHead" ControlName="txtCustomerName" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtCustomerName" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plAddressLine1" CssClass="SubHead" ControlName="txtAddressLine1" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtAddressLine1" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="txtAddressLine2" CssClass="NormalBold" runat="server" /><br>
                                    <asp:Label ID="txtAddressLine3" CssClass="NormalBold" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plCity" CssClass="SubHead" ControlName="txtCity" Suffix=":" runat="server">
                                    </dnn:Label>
                                </td>
                                <td nowrap>
                                    <asp:Label ID="txtCity" CssClass="NormalBold" runat="server" Columns="8"></asp:Label>&nbsp;/&nbsp;
                                    <asp:Label ID="txtState" CssClass="NormalBold" runat="server" Columns="6"></asp:Label>&nbsp;/&nbsp;
                                    <asp:Label ID="txtZipCode" CssClass="NormalBold" runat="server" Columns="6"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plContactCode" CssClass="SubHead" ControlName="txtContactCode" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtContactCode" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plPhoneNumber" CssClass="SubHead" ControlName="txtPhoneNumber" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td class="SubHead" nowrap>
                                    <asp:Label ID="txtPhoneNumber" CssClass="NormalBold" runat="server"></asp:Label> &nbsp; <asp:Label ID="plExt" CssClass="SubHead" runat="server" Text="Ext: "></asp:Label> <asp:Label ID="txtExt" CssClass="NormalBold" runat="server" Columns="4"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plFaxNumber" CssClass="SubHead" ControlName="txtFaxNumber" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtFaxNumber" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="Table6" runat="server" class="boxdisplay">
                <tr><td class="jrctitletext">&nbsp; Sales Representative &nbsp;</td></tr>
                <tr>
                    <td>
                        <table id="Table10" style="width:385px">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plRepNo" CssClass="SubHead" ControlName="ddlRepNo" Suffix=":" runat="server">
                                    </dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="ddlRepNo" CssClass="NormalBold" runat="server"></asp:Label></td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plRepName" CssClass="SubHead" ControlName="txtRepName" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtRepName" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plRepPct" CssClass="SubHead" ControlName="txtRepPct" Suffix=":" runat="server">
                                    </dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtRepPct" CssClass="NormalBold" runat="server"></asp:Label></td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plRepDlr" CssClass="SubHead" ControlName="txtRepDlr" Suffix=":" runat="server">
                                    </dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtRepDlr" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="displaynone" id="Table7" runat="server">
                <tr><td class="jrctitletext">&nbsp; PlcOwner &nbsp;</td></tr>
                <tr>
                    <td>
                        <table id="Table12" border="0">
                            <tr>
                                <td class="SubHead" nowrap colspan="2" height="21">
                                    <dnn:Label ID="plCowner" CssClass="SubHead" ControlName="txtCowner" Suffix=":" runat="server">
                                    </dnn:Label>
                                </td>
                                <td class="SubHead" nowrap height="21">
                                    <dnn:Label ID="plCorpUpd" CssClass="SubHead" ControlName="txtCorpUpd" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td nowrap>
                                    <asp:Label ID="txtCorpUpd" CssClass="NormalBold" runat="server" Columns="10"></asp:Label></td>
                                <td class="SubHead" nowrap height="21">
                                    <dnn:Label ID="plDivision" CssClass="SubHead" ControlName="txtDivision" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" colspan="2">
                                    <asp:Label ID="txtCowner" CssClass="NormalBold" runat="server"></asp:Label></td>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plWhoDoneIT" CssClass="SubHead" ControlName="txtWhoDoneIT" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtWhoDoneIT" CssClass="NormalBold" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="txtDivision" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="displaynone" id="Table8" runat="server">
                <tr><td class="jrctitletext">&nbsp; GSMStatus &nbsp;</td></tr>
                <tr>
                    <td>
                        <table id="Table13" height="45" cellspacing="1" cellpadding="1" border="0">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plGSMStatus" CssClass="SubHead" ControlName="txtGSMStatus" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtGSMStatus" CssClass="NormalBold" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
             <table id="Table5" runat="server" class="boxdisplay">
                <tr><td class="jrctitletext">&nbsp;Billing Information &nbsp;</td></tr>
                <tr>
                    <td>
                        <table id="Table11">
                            <tr>
                                <td class="SubHead" nowrap>
                                    <dnn:Label ID="plBillingInfo" CssClass="SubHead" ControlName="txtBillingInfo" Suffix=":"
                                        runat="server"></dnn:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="txtBillingInfo" CssClass="NormalBold" runat="server" Width="144px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
       
        </td>
    </tr>
</table>
<div id="divButtons" runat="server">
    <center>
        <table>
            <tr>
                <td id="tdEdit" class="SubHead" align="center" valign="bottom" runat="server">
                    <asp:HyperLink ID="hypImgEdit" ImageUrl="~/images/edit.gif" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /><br />
                    <asp:HyperLink ID="hypEdit" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" />
                </td>
                <td class="SubHead" align="center" valign="bottom">
                    <asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" runat="server" /><br />
                    <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" runat="server" />
                </td>
                <td class="SubHead" align="center" valign="bottom">
                    <asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                    <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" />
                </td>
            </tr>
        </table>
    </center>
</div>
<p>
    <Portal:Audit ID="ctlAudit" runat="server" />
</p>
<p>
    <Portal:Tracking ID="ctlTracking" runat="server" />
</p>
<table id="Table2" style="display: none" height="605" cellspacing="0" cellpadding="0"
    border="0">
    <tr>
        <td class="SubHead" nowrap>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plAddressLine2" CssClass="SubHead" ControlName="txtAddressLine2" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plAddressLine3" CssClass="SubHead" ControlName="txtAddressLine3" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plState" CssClass="SubHead" ControlName="txtState" Suffix=":" runat="server">
            </dnn:Label>
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="17">
            <dnn:Label ID="plZipCode" CssClass="SubHead" ControlName="txtZipCode" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal" height="17">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap height="24">
        </td>
        <td class="Normal" height="24">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plFavor" CssClass="SubHead" ControlName="txtFavor" Suffix=":" runat="server">
            </dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label ID="txtFavor" CssClass="NormalBold" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plSortSeq" CssClass="SubHead" ControlName="txtSortSeq" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label ID="txtSortSeq" CssClass="NormalBold" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plOldCustNo" CssClass="SubHead" ControlName="txtOldCustNo" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label ID="txtOldCustNo" CssClass="NormalBold" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plMCNO" CssClass="SubHead" ControlName="txtMCNO" Suffix=":" runat="server">
            </dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label ID="txtMCNO" CssClass="NormalBold" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td class="SubHead" nowrap>
            <dnn:Label ID="plViewOrder" CssClass="SubHead" ControlName="txtViewOrder" Suffix=":"
                runat="server"></dnn:Label>
        </td>
        <td class="Normal">
            <asp:Label ID="txtViewOrder" CssClass="NormalBold" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="SubHead">
        </td>
        <td class="Normal">
        </td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
</table>
