<%@ Control Language="VB" AutoEventWireup="false" CodeBehind="EditItem.ascx.vb" Inherits="bhattji.Modules.Dispatchs.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="DualList" Src="~/controls/DualListControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<script type="text/javascript">
function ClientValidate7char(source, clientside_arguments)
{
//    if (clientside_arguments.Value.length  == 7)
//        {clientside_arguments.IsValid=true;}
//    else
//        {clientside_arguments.IsValid=false};
    clientside_arguments.IsValid=(clientside_arguments.Value.length > 6);
}
</script>
<center>
    <table>
        <tr>
            <td valign="top">
                <table class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; User &nbsp; </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plDispatchCode" cssclass="SubHead" controlname="txtDispatchCode" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtDispatchCode" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" MaxLength="12" /><asp:ImageButton ID="imbAddUser" ImageUrl="~/images/icon_hostusers_16px.gif" resourcekey="cmdAddUser" CssClass="CommandButton" BorderStyle="none" runat="server" ToolTip="Create DNN User" /><asp:RequiredFieldValidator ID="valDispatchCode" ControlToValidate="txtDispatchCode" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Dispatch Code Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDispatchCode" targetcontrolid="valDispatchCode" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plDispPassw" cssclass="SubHead" controlname="txtDispPassw" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtDispPassw" Columns="30" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" /><asp:LinkButton ID="cmdUpdatePassword" Visible="false" runat="server" BorderStyle="none" CssClass="CommandButton" resourcekey="cmdUpdatePassword" Text="UpdatePassword" /><asp:RequiredFieldValidator ID="valDispPassw" ControlToValidate="txtDispPassw" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Password Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDispPassw" targetcontrolid="valDispPassw" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plDispatchName" cssclass="SubHead" controlname="txtDispatchName" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtDispatchName" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" runat="server" Columns="30"></asp:TextBox><asp:RequiredFieldValidator ID="valDispatchName" ControlToValidate="txtDispatchName" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Dispatch Name Cannot be null" SetFocusOnError="True"/><act:validatorcalloutextender id="vlxDispatchName" targetcontrolid="valDispatchName" runat="Server" warningiconimageurl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plEmail" runat="server" controlname="txtEmail" cssclass="SubHead" suffix=":"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtEmail" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" Columns="30"></asp:TextBox><asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="<br>Requires Valid eMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="valEmail1" ControlToValidate="txtEmail" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="Email Cannot be null" SetFocusOnError="true" /><act:validatorcalloutextender id="vlxEmail" targetcontrolid="valEmail1" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                        <asp:RegularExpressionValidator ID="valEmail0" runat="server" Display="None" ErrorMessage="Requires valid eMail Format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                                        <act:validatorcalloutextender id="vlxEmail0" targetcontrolid="valEmail0" runat="Server" warningiconimageurl="~/images/red-error.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plOffice" cssclass="SubHead" controlname="ddlOfficeOwner" suffix=":" runat="server" /></td>
                                    <td class="Normal"><asp:DropDownList ID="ddlOfficeOwner" runat="server" ForeColor="White" BackColor="Red" CssClass="NormalTextBox" />
                                        <asp:RequiredFieldValidator ID="valddlOfficeOwner" ControlToValidate="ddlOfficeOwner" SetFocusOnError="true" InitialValue="000000000" runat="server" CssClass="NormalRed" Display="None" ErrorMessage="<br/>Please Select the right Office"/><act:ValidatorCalloutExtender ID="vlxddlOfficeOwner" TargetControlID="valddlOfficeOwner" runat="Server" WarningIconImageUrl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plOfficeOverride" cssclass="SubHead" controlname="txtOfficeOverride" suffix=":" runat="server" /></td>
                                    <td class="Normal"><asp:TextBox ID="txtOfficeOverride" CssClass="NormalTextBox" runat="server" Columns="8" MaxLength="9" /><act:filteredtextboxextender id="fteOfficeOverride" runat="server" filtertype="Numbers" targetcontrolid="txtOfficeOverride" /><asp:CustomValidator ID="cvOfficeOverride" runat="server" ErrorMessage="<b>Error !!!</b><br />IO Override Office Account # Must be 7 characters" ClientValidationFunction="ClientValidate7char" ControlToValidate="txtOfficeOverride" Display="None" SetFocusOnError="True" /><act:validatorcalloutextender id="vlxOfficeOverride" runat="Server" targetcontrolid="cvOfficeOverride" warningiconimageurl="~/images/red-error.gif" /><%--<asp:DropDownList ID="ddlOfficeOverride" runat="server" CssClass="NormalTextBox" />--%></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plManagerOverride" cssclass="SubHead" controlname="txtManagerOverride" suffix=":" runat="server" /></td>
                                    <td class="Normal"><asp:DropDownList ID="ddlManagerOverride" runat="server" CssClass="NormalTextBox" /><asp:RequiredFieldValidator ID="valManagerOverride" runat="server" ErrorMessage="&lt;b&gt;Error !!!&lt;/b&gt;&lt;br /&gt;Invalid Manager Override" ControlToValidate="ddlManagerOverride" Display="None" SetFocusOnError="True" InitialValue="ZXZX" /><act:validatorcalloutextender id="vlxManagerOverride" runat="Server" targetcontrolid="valManagerOverride" warningiconimageurl="~/images/red-error.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plCommRate" cssclass="SubHead" controlname="txtCommRate" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtCommRate" CssClass="NormalTextBox NumericTextBox" runat="server" Columns="5"></asp:TextBox><act:FilteredTextBoxExtender ID="fteCommRate" runat="server" FilterType="Numbers, Custom" TargetControlID="txtCommRate" ValidChars="+-." />
                                    </td>
                                </tr>
                                <tr id="trStatus" runat="server">
                                    <td class="SubHead" nowrap><dnn:label id="plStatus" cssclass="SubHead" controlname="chkStatus" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal">
                                        <asp:CheckBox ID="chkStatus" CssClass="Normal" AutoPostBack="true" resourcekey="chkStatus" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="DisplayNone" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="jrctoplefttd"></td>
                        <td class="jrctitletd"><span class="jrctitletext">&nbsp; &nbsp;</span> </td>
                        <td class="jrctopslide"></td>
                        <td class="jrctoprighttd"></td>
                    </tr>
                    <tr>
                        <td class="jrcleftslidetd"></td>
                        <td colspan="2">
                            <table id="Table1" cellspacing="1" cellpadding="1" border="0">
                            </table>
                            <table>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plDefDisp" cssclass="SubHead" controlname="txtDefDisp" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtDefDisp" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plOffLogNo" cssclass="SubHead" controlname="txtOffLogNo" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtOffLogNo" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plDOffLogNo" cssclass="SubHead" controlname="txtDOffLogNo" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtDOffLogNo" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plClearCode" cssclass="SubHead" controlname="chkClearCode" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal">
                                        <asp:CheckBox ID="chkClearCode" CssClass="Normal" resourcekey="chkClearCode" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plWhatProcess" cssclass="SubHead" controlname="txtWhatProcess" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtWhatProcess" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plXMProc" cssclass="SubHead" controlname="txtXMProc" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtXMProc" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
                                </tr>
                                <tr>
                                    <td class="SubHead" nowrap><dnn:label id="plViewOrder" cssclass="SubHead" controlname="txtViewOrder" suffix=":" runat="server"></dnn:label> </td>
                                    <td class="Normal"><asp:TextBox ID="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:TextBox> </td>
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
                <table id="tblJrcOffices" runat="server" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; Offices &nbsp; </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 315px">
                                <tr>
                                    <td>
                                        <Portal:duallist id="ctlDispatchIOs" runat="server" datatextfield="IOName" datavaluefield="InterOfficeId" listboxheight="130" listboxwidth="130" />
                                        <asp:Button ID="btnUpdateIOs" Text="Update Offices" UseSubmitBehavior="false" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="tblUserRoles" runat="server" class="boxdisplay">
                    <tr>
                        <td class="jrctitletext">&nbsp; User Roles &nbsp; </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 250px">
                                <tr>
                                    <td class="Normal">
                                        <asp:DropDownList ID="ddlPortals" CssClass="NormalTextBox" runat="server" />
                                        <asp:Button ID="btnRoles" runat="server" Text="GetRoles" />
                                    </td>
                                </tr>
                                <tr>
                                    <td id="tdUserAndRoles" class="SubHead" runat="server"></td>
                                </tr>
                                <tr>
                                    <td class="Normal">
                                        <asp:CheckBoxList ID="cblUserAndRoles" CssClass="NormalTextBox" runat="server" />
                                        <asp:LinkButton ID="cmdAddUser" runat="server" BorderStyle="none" CssClass="CommandButton" resourcekey="cmdAddUser" Text="<h1>Create DNN User</h1>" /><br />
                                        <asp:CheckBox ID="chkSelectAll" CssClass="NormalTextBox" AutoPostBack="true" runat="server" Text="All" />
                                        &nbsp; <asp:Button ID="btnUpdateRoles" runat="server" Text="UpdateRoles" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="divPopup" runat="server" />
    <p><asp:ImageButton ID="imbUpdateUser" ImageUrl="~/images/icon_hostusers_16px.gif" resourcekey="cmdUpdateUser" CssClass="CommandButton" BorderStyle="none" runat="server" Visible="False" />
    <asp:LinkButton ID="cmdUpdateUser" runat="server" resourcekey="cmdUpdateUser" Text="UpdateUser" CssClass="CommandButton" BorderStyle="none" Visible="False"></asp:LinkButton></p>
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
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server"><asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /> </td>
        </tr>
    </table>
    <p>
    <Portal:audit id="ctlAudit" runat="server" />
    </p>
    <p>
    <Portal:tracking id="ctlTracking" runat="server" />
    </p>
    <table style="display: none">
        <tr>
            <td class="SubHead" nowrap><dnn:label id="plAllowXM" runat="server" controlname="chkAllowXM" cssclass="SubHead" suffix=":"></dnn:label> </td>
            <td class="Normal">
                <asp:CheckBox ID="chkAllowXM" runat="server" CssClass="Normal" resourcekey="chkAllowXM" />
            </td>
        </tr>
        <tr>
            <td class="SubHead" nowrap><dnn:label id="plLogonLink" runat="server" controlname="txtLogonLink" cssclass="SubHead" suffix=":"></dnn:label> </td>
            <td class="Normal"><asp:TextBox ID="txtLogonLink" runat="server" CssClass="NormalTextBox" /> </td>
        </tr>
        <tr>
            <td class="SubHead" nowrap><dnn:label id="plLogDate" runat="server" controlname="txtLogDate" cssclass="SubHead" suffix=":"></dnn:label> </td>
            <td class="Normal"><asp:TextBox ID="txtLogDate" runat="server" CssClass="NormalTextBox"></asp:TextBox><asp:HyperLink ID="cmdCalendarLogDate" runat="server" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" Text="Calendar"></asp:HyperLink> </td>
        </tr>
        <tr>
            <td class="SubHead" nowrap><dnn:label id="plLogTime" runat="server" controlname="txtLogTime" cssclass="SubHead" suffix=":"></dnn:label> </td>
            <td class="Normal"><asp:TextBox ID="txtLogTime" runat="server" CssClass="NormalTextBox"></asp:TextBox> </td>
        </tr>
    </table>
</center>
