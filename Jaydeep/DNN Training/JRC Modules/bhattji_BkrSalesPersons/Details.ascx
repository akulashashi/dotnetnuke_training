<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="Details.ascx.vb" Inherits="bhattji.Modules.BkrSalesPersons.Details" %>
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
                            <table style="width: 530px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plDriverCode" CssClass="SubHead" controlname="txtDriverCode" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtDriverCode" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plDriverName" CssClass="SubHead" controlname="txtDriverName" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtDriverName" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plOfficeOwner" CssClass="SubHead" controlname="ddlOfficeOwner" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="ddlOfficeOwner" CssClass="NormalTextBox" runat="server"></asp:Label></td>
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
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plDLastName" CssClass="SubHead" controlname="txtDLastName" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plDFirstName" CssClass="SubHead" controlname="txtDFirstName" suffix=":" runat="server">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead"><asp:Label ID="txtDLastName" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtDFirstName" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plAddressLine1" CssClass="SubHead" controlname="txtAddressLine1" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtAddressLine1" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtAddressLine2" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plCity" CssClass="SubHead" controlname="txtCity" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td nowrap><asp:Label ID="txtCity" CssClass="NormalTextBox" runat="server"></asp:Label> &nbsp;/ <asp:Label ID="txtState" CssClass="NormalTextBox" runat="server" Columns="5"></asp:Label> &nbsp;/ <asp:Label ID="txtZipCode" CssClass="NormalTextBox" runat="server" Columns="5"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plCountryCode" CssClass="SubHead" controlname="txtCountryCode" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtCountryCode" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plPhoneNo" CssClass="SubHead" controlname="txtPhoneNo" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td class="SubHead"><asp:Label ID="plExt" CssClass="SubHead" runat="server" Text="Ext"></asp:Label> <asp:Label ID="txtExt" CssClass="NormalTextBox" runat="server" Columns="4"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtPhoneNo" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plFaxNo" runat="server" suffix=":" controlname="txtFaxNo" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="Normal"><asp:Label ID="txtFaxNo" runat="server" CssClass="NormalTextBox"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plCellPhone" CssClass="SubHead" controlname="txtCellPhone" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plPager" CssClass="SubHead" controlname="txtPager" suffix=":" runat="server">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtCellPhone" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtPager" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plEmailAddress" runat="server" suffix=":" controlname="txtEmailAddress" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtEmailAddress" runat="server" CssClass="NormalTextBox"></asp:Label></td>
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
                                        <dnn:label id="plLastLoadID" runat="server" suffix=":" controlname="txtLastLoadID" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plLastLoad" CssClass="SubHead" controlname="txtLastLoad" suffix=":" runat="server">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtLastLoadID" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtLastLoad" CssClass="NormalTextBox" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plLastLoadDeliv" CssClass="SubHead" controlname="txtLastLoadDeliv" suffix=":" runat="server">
                                        </dnn:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <p align="left">
                                            <asp:Label ID="txtLastLoadDeliv" CssClass="NormalTextBox" runat="server" /></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plLastPU" CssClass="SubHead" controlname="txtLastPU" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td class="SubHead">
                                        <dnn:label id="plLastDP" CssClass="SubHead" controlname="txtLastDP" suffix=":" runat="server">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="txtLastPU" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="txtLastDP" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plLastTrailerUsed" CssClass="SubHead" controlname="txtLastTrailerUsed" suffix=":" runat="server">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtLastTrailerUsed" CssClass="NormalTextBox" runat="server"></asp:Label></td>
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
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plAccountNo" CssClass="SubHead" controlname="txtAccountNo" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtAccountNo" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plCommRate" CssClass="SubHead" controlname="txtCommRate" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td height="27"><asp:Label ID="txtCommRate" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="display: none">
                                    <td class="SubHead">
                                        <dnn:label id="plCalc85" CssClass="SubHead" controlname="imgCalc85" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td>
                                        <asp:Image ID="imgCalc85" CssClass="Normal" resourcekey="imgCalc85" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plJRCTrailer" CssClass="SubHead" controlname="txtJRCTrailer" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtJRCTrailer" CssClass="NormalTextBox" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plDriverNotes" CssClass="SubHead" controlname="txtDriverNotes" suffix=":" runat="server">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtDriverNotes" CssClass="NormalTextBox" runat="server"></asp:Label></td>
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
                                        <dnn:label id="plAdminExempt" runat="server" suffix=":" controlname="imgAdminExempt" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="DisplayNone">
                                        <asp:Image ID="imgAdminExempt" CssClass="Normal" resourcekey="imgAdminExempt" runat="server" /></td>
                                    <td class="SubHead">
                                        <dnn:label id="plStatus" runat="server" suffix=":" controlname="imgStatus" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td>
                                        <asp:Image ID="imgStatus" CssClass="Normal" resourcekey="imgStatus" runat="server" /></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="SubHead">
                                        <dnn:label id="plBrokerCodeD" runat="server" suffix=":" controlname="txtBrokerCodeD" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td><asp:Label ID="txtBrokerCodeD" runat="server" CssClass="NormalTextBox" Columns="9"></asp:Label></td>
                                    <td></td>
                                    <td nowrap></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plDrugDate" runat="server" suffix=":" controlname="txtDrugDate" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plTruckInsDate" runat="server" suffix=":" controlname="txtTruckInsDate" CssClass="SubHead">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtDrugDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label> </td>
                                    <td colspan="2"><asp:Label ID="txtTruckInsDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plLicenceDate" runat="server" suffix=":" controlname="txtLicenceDate" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plTrailerInsDate" runat="server" suffix=":" controlname="txtTrailerInsDate" CssClass="SubHead">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtLicenceDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label> </td>
                                    <td colspan="2"><asp:Label ID="txtTrailerInsDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plRegRenewDate" runat="server" suffix=":" controlname="txtRegRenewDate" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plNewLeaseDate" runat="server" suffix=":" controlname="txtNewLeaseDate" CssClass="SubHead">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtRegRenewDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label></td>
                                    <td colspan="2"><asp:Label ID="txtNewLeaseDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plMedicalDate" runat="server" suffix=":" controlname="txtMedicalDate" CssClass="SubHead">
                                        </dnn:label></td>
                                    <td class="SubHead" colspan="2">
                                        <dnn:label id="plLogBookOS" runat="server" suffix=":" controlname="imgLogBookOS" CssClass="SubHead">
                                        </dnn:label></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Label ID="txtMedicalDate" runat="server" CssClass="NormalTextBox" Columns="10"></asp:Label></td>
                                    <td colspan="2">
                                        <asp:Image ID="imgLogBookOS" CssClass="Normal" resourcekey="imgLogBookOS" runat="server" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone" border="0" cellpadding="0" cellspacing="0" class="jrcskintable">
                    <tr>
                        <td class="jrctoplefttd"></td>
                        <td class="jrctitletd"><span class="jrctitletext">&nbsp; Offices &nbsp;</span></td>
                        <td class="jrctopslide"></td>
                        <td class="jrctoprighttd"></td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd"></td>
                        <td colspan="2">
                            <Portal:duallist id="ctlSalesPersonIOs" DataTextField="IOName" DataValueField="InterOfficeId" ListBoxHeight="130" ListBoxWidth="130" runat="server" />
                            <asp:Button ID="btnUpdateIOs" runat="server" Text="Update Offices" UseSubmitBehavior="false" Visible="false" />
                        </td>
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
        <Portal:audit id="ctlAudit" runat="server" /></p>
    <p>
        <Portal:tracking id="ctlTracking" runat="server" /></p>
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
                <dnn:label id="plAddressLine2" runat="server" suffix=":" controlname="txtAddressLine2" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plAddressLine3" runat="server" suffix=":" controlname="txtAddressLine3" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"><asp:Label ID="txtAddressLine3" runat="server" CssClass="NormalTextBox"></asp:Label></td>
        </tr>
        <tr>
            <td class="SubHead"></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plState" runat="server" suffix=":" controlname="txtState" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plZipCode" runat="server" suffix=":" controlname="txtZipCode" CssClass="SubHead">
                </dnn:label></td>
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
                <dnn:label id="plLoadType" runat="server" suffix=":" controlname="txtLoadType" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"><asp:Label ID="txtLoadType" runat="server" CssClass="NormalTextBox"></asp:Label></td>
        </tr>
        <tr>
            <td class="SubHead"></td>
            <td class="Normal"></td>
        </tr>
        <tr>
            <td class="SubHead">
                <dnn:label id="plSafetyAuth" runat="server" suffix=":" controlname="txtSafetyAuth" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"><asp:Label ID="txtSafetyAuth" runat="server" CssClass="NormalTextBox"></asp:Label></td>
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
                <dnn:label id="plSafetyNotes" runat="server" suffix=":" controlname="txtSafetyNotes" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"><asp:Label ID="txtSafetyNotes" runat="server" CssClass="NormalTextBox"></asp:Label></td>
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
                <dnn:label id="plCalc87" runat="server" suffix=":" controlname="chkCalc87" CssClass="SubHead">
                </dnn:label></td>
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
                <dnn:label id="plViewOrder" runat="server" suffix=":" controlname="txtViewOrder" CssClass="SubHead">
                </dnn:label></td>
            <td class="Normal"><asp:Label ID="txtViewOrder" runat="server" CssClass="NormalTextBox"></asp:Label></td>
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
