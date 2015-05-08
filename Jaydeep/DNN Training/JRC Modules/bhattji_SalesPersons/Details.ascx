<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="Details.ascx.vb" Inherits="bhattji.Modules.SalesPersons.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagName="DualList" TagPrefix="Portal" Src="~/controls/DualListControl.ascx" %>
<center>
    <table cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td colspan="2">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; DriverDetail &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 600px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDriverCode" CssClass="SubHead" ControlName="txtDriverCode" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtDriverCode" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDriverName" CssClass="SubHead" ControlName="txtDriverName" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtDriverName" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plOfficeOwner" CssClass="SubHead" ControlName="ddlOfficeOwner" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="ddlOfficeOwner" CssClass="NormalBold" runat="server"></asp:Label></td>
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
                            <table style="width: 360px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDLastName" CssClass="SubHead" ControlName="txtDLastName" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDFirstName" CssClass="SubHead" ControlName="txtDFirstName" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><asp:Label ID="txtDLastName" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtDFirstName" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plAddressLine1" CssClass="SubHead" ControlName="txtAddressLine1" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtAddressLine1" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtAddressLine2" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plCity" CssClass="SubHead" ControlName="txtCity" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td nowrap><asp:Label ID="txtCity" CssClass="NormalBold" runat="server"></asp:Label> &nbsp;/ <asp:Label ID="txtState" CssClass="NormalBold" runat="server" Columns="5"></asp:Label> &nbsp;/ <asp:Label ID="txtZipCode" CssClass="NormalBold" runat="server" Columns="5"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plCountryCode" CssClass="SubHead" ControlName="txtCountryCode" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtCountryCode" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plPhoneNo" CssClass="SubHead" ControlName="txtPhoneNo" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead"><asp:Label ID="txtPhoneNo" CssClass="NormalBold" runat="server"></asp:Label> <asp:Label ID="plExt" CssClass="SubHead" runat="server" Text="Ext"></asp:Label> <asp:Label ID="txtExt" CssClass="NormalBold" runat="server" Columns="4"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plFaxNo" runat="server" Suffix=":" ControlName="txtFaxNo" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="Normal"><asp:Label ID="txtFaxNo" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plCellPhone" CssClass="SubHead" ControlName="txtCellPhone" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plPager" CssClass="SubHead" ControlName="txtPager" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtCellPhone" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtPager" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plEmailAddress" runat="server" Suffix=":" ControlName="txtEmailAddress" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtEmailAddress" runat="server" CssClass="NormalBold"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; LastLoadID &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastLoadID" runat="server" Suffix=":" ControlName="txtLastLoadID" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastLoad" CssClass="SubHead" ControlName="txtLastLoad" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtLastLoadID" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtLastLoad" CssClass="NormalBold" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLastLoadDeliv" CssClass="SubHead" ControlName="txtLastLoadDeliv" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <p align="left">
                                            <asp:Label ID="txtLastLoadDeliv" CssClass="NormalBold" runat="server" /></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastPU" CssClass="SubHead" ControlName="txtLastPU" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plLastDP" CssClass="SubHead" ControlName="txtLastDP" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtLastPU" CssClass="NormalBold" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtLastDP" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLastTrailerUsed" CssClass="SubHead" ControlName="txtLastTrailerUsed" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtLastTrailerUsed" CssClass="NormalBold" runat="server"></asp:Label></td>
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
                        <td class="jrctitletext">&nbsp; AccountInfo &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 270px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plAccountNo" CssClass="SubHead" ControlName="txtAccountNo" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtAccountNo" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plCommRate" CssClass="SubHead" ControlName="txtCommRate" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtCommRate" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="display: none">
                                    <td class="SubHead">
                                        <dnn:Label ID="plCalc85" CssClass="SubHead" ControlName="imgCalc85" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgCalc85" CssClass="Normal" resourcekey="imgCalc85" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDvrDedPct" CssClass="SubHead" ControlName="txtDvrDedPct" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtDvrDedPct" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDvrDedResn" CssClass="SubHead" ControlName="txtDvrDedResn" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtDvrDedResn" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plJRCTrailer" CssClass="SubHead" ControlName="txtJRCTrailer" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtJRCTrailer" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plDriverNotes" CssClass="SubHead" ControlName="txtDriverNotes" Suffix=":" runat="server">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtDriverNotes" CssClass="NormalBold" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Admin &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="DisplayNone">
                                        <dnn:Label ID="plAdminExempt" runat="server" Suffix=":" ControlName="imgAdminExempt" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="DisplayNone">
                                        <asp:Image ID="imgAdminExempt" CssClass="Normal" resourcekey="imgAdminExempt" runat="server" /></td>
                                    <td class="SubHead">
                                        <dnn:Label ID="plStatus" runat="server" Suffix=":" ControlName="imgStatus" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgStatus" CssClass="Normal" resourcekey="imgStatus" runat="server" /></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:Label ID="plBrokerCodeD" runat="server" Suffix=":" ControlName="txtBrokerCodeD" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td><asp:Label ID="txtBrokerCodeD" runat="server" CssClass="NormalBold" Columns="9"></asp:Label></td>
                                    <td></td>
                                    <td nowrap></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plDrugDate" runat="server" Suffix=":" ControlName="txtDrugDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plTruckInsDate" runat="server" Suffix=":" ControlName="txtTruckInsDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtDrugDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label> </td>
                                    <td colspan="2"><asp:Label ID="txtTruckInsDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLicenceDate" runat="server" Suffix=":" ControlName="txtLicenceDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plTrailerInsDate" runat="server" Suffix=":" ControlName="txtTrailerInsDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtLicenceDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label> </td>
                                    <td colspan="2"><asp:Label ID="txtTrailerInsDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plRegRenewDate" runat="server" Suffix=":" ControlName="txtRegRenewDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plNewLeaseDate" runat="server" Suffix=":" ControlName="txtNewLeaseDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtRegRenewDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label></td>
                                    <td colspan="2"><asp:Label ID="txtNewLeaseDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plMedicalDate" runat="server" Suffix=":" ControlName="txtMedicalDate" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:Label ID="plLogBookOS" runat="server" Suffix=":" ControlName="imgLogBookOS" CssClass="SubHead">
                                        </dnn:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtMedicalDate" runat="server" CssClass="NormalBold" Columns="10"></asp:Label></td>
                                    <td colspan="2">
                                        <asp:Image ID="imgLogBookOS" CssClass="Normal" resourcekey="imgLogBookOS" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone">
                    <tr>
                        <td class="jrctitletext">&nbsp; Offices &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 150px">
                                <tr>
                                    <td>
                                        <asp:ListBox ID="lbxSalesPersonIOs" runat="server" DataTextField="IOName" DataValueField="InterOfficeId" />
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <Portal:DualList ID="ctlSalesPersonIOs" DataTextField="IOName" DataValueField="InterOfficeId" ListBoxHeight="130" ListBoxWidth="130" runat="server" />
                                        <asp:Button ID="btnUpdateIOs" runat="server" Text="Update Offices" UseSubmitBehavior="false" Visible="false" />
                                    </td>
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
                    <td id="tdEdit" class="SubHead" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgEdit" ImageUrl="~/images/edit.gif" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /><br />
                        <asp:HyperLink ID="hypEdit" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /> </td>
                    <td class="SubHead" align="center" valign="bottom"><asp:HyperLink ID="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" runat="server" /><br />
                        <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" runat="server" /> </td>
                    <td class="SubHead" align="center" valign="bottom"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                        <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /> </td>
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
            <td class="SubHead">
                <dnn:Label ID="plAddressLine2" runat="server" Suffix=":" ControlName="txtAddressLine2" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:Label ID="plAddressLine3" runat="server" Suffix=":" ControlName="txtAddressLine3" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"><asp:Label ID="txtAddressLine3" runat="server" CssClass="NormalBold"></asp:Label></td>
        </tr>
        <tr>
            <td class="SubHead"></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:Label ID="plState" runat="server" Suffix=":" ControlName="txtState" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:Label ID="plZipCode" runat="server" Suffix=":" ControlName="txtZipCode" CssClass="SubHead">
                </dnn:Label>
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
                <dnn:Label ID="plLoadType" runat="server" Suffix=":" ControlName="txtLoadType" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"><asp:Label ID="txtLoadType" runat="server" CssClass="NormalBold"></asp:Label></td>
        </tr>
        <tr>
            <td class="SubHead"></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:Label ID="plSafetyAuth" runat="server" Suffix=":" ControlName="txtSafetyAuth" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"><asp:Label ID="txtSafetyAuth" runat="server" CssClass="NormalBold"></asp:Label></td>
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
                <dnn:Label ID="plSafetyNotes" runat="server" Suffix=":" ControlName="txtSafetyNotes" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"><asp:Label ID="txtSafetyNotes" runat="server" CssClass="NormalBold"></asp:Label></td>
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
                <dnn:Label ID="plCalc87" runat="server" Suffix=":" ControlName="chkCalc87" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal">
                <asp:CheckBox ID="chkCalc87" CssClass="Normal" resourcekey="chkCalc87" runat="server" /></td>
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
                <dnn:Label ID="plViewOrder" runat="server" Suffix=":" ControlName="txtViewOrder" CssClass="SubHead">
                </dnn:Label>
            </td>
            <td class="Normal"><asp:Label ID="txtViewOrder" runat="server" CssClass="NormalBold"></asp:Label></td>
        </tr>
        <tr>
            <td class="SubHead"></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
    </table>
</center>
