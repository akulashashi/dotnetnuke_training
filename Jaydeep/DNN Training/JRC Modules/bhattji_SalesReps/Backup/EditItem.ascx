<%@ Control Language="c#" AutoEventWireup="true" Codebehind="EditItem.ascx.cs" Inherits="bhattji.Modules.SalesReps.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<%@ Register TagPrefix="radCln" Namespace="Telerik.WebControls" Assembly="RadCalendar.Net2" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="ExtJS" %>
--%>
<table class="jrcskintable" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td> class="jrctoplefttd"></td>
		<td class="jrctitletd"><span class="jrctitletext">&nbsp; Sales Representative &nbsp;</span></td>
		<td class="jrctopslide"></td>
		<td class="jrctoprighttd"></td>
	</tr>
	<tr>
		<td class="jrcleftslidetd"></td>
		<td colspan="2">
			<table id="Table1" cellspacing="1" cellpadding="1" border="0">
				<tr>
					<td class="SubHead"><dnn:label id="plRepNo" controlname="txtRepNo" suffix=":" CssClass="SubHead" runat="server" /></td>
					<td class="Normal"><asp:textbox id="txtRepNo" CssClass="NormalTextBox" runat="server" /></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plRepName" controlname="txtRepName" suffix=":" CssClass="SubHead" runat="server" /></td>
					<td class="Normal"><asp:textbox id="txtRepName" CssClass="NormalTextBox" runat="server" /></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plRepRate" controlname="txtRepRate" suffix=":" CssClass="SubHead" runat="server" /></td>
					<td class="Normal"><asp:textbox id="txtRepRate" CssClass="NormalTextBox" runat="server" AutoPostBack="True" /></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plRepDollar" controlname="txtRepDollar" suffix=":" CssClass="SubHead" runat="server" /></td>
					<td class="Normal"><asp:textbox id="txtRepDollar" CssClass="NormalTextBox" runat="server" AutoPostBack="True" /></td>
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
					<td colspan="2"></td>
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
<table width="560" cellspacing="0" cellpadding="0" border="0" summary="Edit SalesReps Design Table">
    <tr>
        <td class="SubHead" width="150"></td>
        <td class="Normal" width="400"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:label id="plTitle" controlname="txtTitle" suffix=":" runat="server" /></td>
        <td class="Normal">        
            <asp:TextBox ID="txtTitle" Width="300" CssClass="NormalTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="valTitle" ControlToValidate="txtTitle" ErrorMessage="You Must Enter A Title For The SalesRep" resourcekey="Title.ErrorMessage" CssClass="NormalRed" Display="None" runat="server" /><act:ValidatorCalloutExtender runat="Server" ID="vlxTitle" TargetControlID="valTitle" HighlightCssClass="CustomValidatorCalloutStyle" />
            </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:label id="plCategoryId" runat="server" controlname="ddlCategoryId" cssclass="SubHead" suffix=":" /></td>
        <td class="Normal">
            <asp:DropDownList ID="ddlCategoryId" CssClass="NormalTextBox" runat="server" /><asp:HyperLink ID="hypViewCategories" ImageUrl="~/images/register.gif" NavigateUrl="javascript://ShowModalPopup();" resourcekey="ViewCategories" CssClass="CommandButton" BorderStyle="none" runat="server" />
             <asp:ImageButton ID="imbShowCategories" ImageUrl="~/images/rt.gif" resourcekey="Open" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            <asp:ImageButton ID="imbHideCategories" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" Visible="False" />
            <asp:PlaceHolder ID="phtCategories" runat="server" Visible="False" />
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secMediaSettings" cssclass="Head" section="tblMediaSettings" resourcekey="secMediaSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblMediaSettings" runat="server">
                <tr>
                    <td class="SubHead"><dnn:label id="plMediaSrc" controlname="ctlMediaSrc" suffix=":" runat="server" /></td>
                    <td class="Normal">
                    <dnn:sectionhead id="secMediaSrc" cssclass="SubHead" section="divMediaSrc" resourcekey="secMediaSrc" includerule="True" isexpanded="false" runat="server" />
                    <div id="divMediaSrc" runat="server">
                    <portal:url id="ctlMediaSrc" width="300" runat="server" />
                        <table>
                            <tr>
                                <td><asp:Label ID="lblMediaWidth" resourcekey="MediaWidth" CssClass="SubHead" runat="server" /></td>
                                <td><asp:TextBox ID="txtMediaWidth" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth" ErrorMessage="<br />Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="NormalRed" /></td>
                                <td><asp:Label ID="lblMediaHeight" resourcekey="MediaHeight" CssClass="SubHead" runat="server" /></td>
                                <td><asp:TextBox ID="txtMediaHeight" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight" ErrorMessage="<br />Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="NormalRed" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMediaAlign" resourcekey="MediaAlign" CssClass="SubHead" runat="server" /></td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="rblMediaAlign" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Left" resourcekey="Left" />
                                        <asp:ListItem Value="Right" resourcekey="Right" />
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table></div>
                    </td>
                </tr>

                 <tr>
                    <td class="SubHead"><dnn:label id="plDescription" controlname="txtDescription" suffix=":" runat="server" /></td>
                    <td class="Normal"><dnn:sectionhead id="secDescription" cssclass="SubHead" section="divDescription" resourcekey="secDescription" includerule="True" isexpanded="false" runat="server" /></td>
                </tr>

                <tr>
                    <td class="SubHead" colspan="2">
                        <div id="divDescription" runat="server">
                        <dnn:texteditor id="teDescription" width="640" height="480" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="valDescription" resourcekey="Description.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="teDescription" ErrorMessage="You Must Enter A Description Of The SalesRep" Display="Dynamic" /><act:ValidatorCalloutExtender runat="Server" ID="vlxDescription" TargetControlID="valDescription" HighlightCssClass="CustomValidatorCalloutStyle" />
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:label id="plActualFields" controlname="txtActualFields" suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtActualFields" Width="300" CssClass="NormalTextBox" runat="server" /></td>
    </tr>
    <tr id="trPQR45s" runat="server">
        <td colspan="2"><br />
            <dnn:sectionhead id="secPQR45s" cssclass="SubHead" section="divPQR45s" resourcekey="secPQR45s" includerule="True" isexpanded="false" runat="server" />
            <div id="divPQR45s" runat="server" />
        </td>
    </tr>

    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secMedia2Settings" cssclass="Head" section="tblMedia2Settings" resourcekey="secMedia2Settings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblMedia2Settings" runat="server">
                 <tr>
                    <td class="SubHead"><dnn:label id="plDetails" controlname="txtDetails" suffix=":" runat="server" /></td>
                    <td class="Normal"><dnn:sectionhead id="secDetails" cssclass="SubHead" section="divDetails" resourcekey="secDetails" includerule="True" isexpanded="false" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead" colspan="2">
                        <div id="divDetails" runat="server">
                        <dnn:texteditor id="teDetails" width="640" height="480" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="valDetails" resourcekey="Details.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="teDetails" ErrorMessage="You Must Enter A Details Of The SalesRep" Display="Dynamic" /><act:ValidatorCalloutExtender runat="Server" ID="vlxDetails" TargetControlID="valDetails" HighlightCssClass="CustomValidatorCalloutStyle" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plMediaSrc2" controlname="ctlMediaSrc2" suffix=":" runat="server" /></td>
                    <td class="Normal">
                    <dnn:sectionhead id="secMediaSrc2" cssclass="SubHead" section="divMediaSrc2" resourcekey="secMediaSrc2" includerule="True" isexpanded="false" runat="server" />
                    <div id="divMediaSrc2" runat="server">
                        <portal:url id="ctlMediaSrc2" width="300" runat="server" />
                        <table>
                            <tr>
                                <td><asp:Label ID="lblMediaWidth2" resourcekey="MediaWidth" CssClass="SubHead" runat="server" /></td>
                                <td><asp:TextBox ID="txtMediaWidth2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth2" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth2" ErrorMessage="<br />Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="NormalRed" /></td>
                                <td><asp:Label ID="lblMediaHeight2" resourcekey="MediaHeight" CssClass="SubHead" runat="server" /></td>
                                <td><asp:TextBox ID="txtMediaHeight2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight2" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight2" ErrorMessage="<br />Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="NormalRed" /></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblMediaAlign2" resourcekey="MediaAlign" CssClass="SubHead" runat="server" /></td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="rblMediaAlign2" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Left" resourcekey="Left" />
                                        <asp:ListItem Value="Right" resourcekey="Right" />
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table></div>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plNavURL" controlname="ctlNavURL" suffix=":" runat="server" /></td>
                    <td class="Normal">
                    <dnn:sectionhead id="secNavURL" cssclass="SubHead" section="divNavURL" resourcekey="secNavURL" includerule="True" isexpanded="false" runat="server" />
                    <div id="divNavURL" runat="server"><portal:url id="ctlNavURL" width="300" runat="server" /></div></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plPublishDate" controlname="txtPublishDate" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:TextBox ID="txtPublishDate" Width="100" CssClass="NormalTextBox" runat="server" /><asp:Image runat="server" ID="imgPublishDate" ImageUrl="~/images/calendar.png" style="cursor:hand" />
                        <act:CalendarExtender ID="calPublishDate" TargetControlID="txtPublishDate" PopupButtonID="imgPublishDate" runat="server" Format="d" />
                        <%--<asp:CompareValidator ID="valPublishDate" resourcekey="PublishDate.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="txtPublishDate" ErrorMessage="<br />You have entered an invalid date!" Display="Dynamic" Type="Date" Operator="DataTypeCheck" />--%>
                        </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plExpiryDate" controlname="txtExpiryDate" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:TextBox ID="txtExpiryDate" runat="server" Width="100" CssClass="NormalTextBox" /><asp:Image runat="server" ID="imgExpiryDate" ImageUrl="~/images/calendar.png" style="cursor:hand" />
                        <act:CalendarExtender ID="calExpiryDate" TargetControlID="txtExpiryDate" PopupButtonID="imgExpiryDate" runat="server" Format="d" />
                        <%--<asp:CompareValidator ID="valExpiryDate" resourcekey="ExpiryDate.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="txtExpiryDate" ErrorMessage="<br />You have entered an invalid date!" Display="Dynamic" Type="Date" Operator="DataTypeCheck" />--%>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plViewOrder" controlname="txtViewOrder" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtViewOrder" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:CompareValidator ID="valViewOrder" resourcekey="ViewOrder.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="txtViewOrder" ErrorMessage="<br />View order must be an integer value." Display="Dynamic" Type="Integer" Operator="DataTypeCheck" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<center>
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center"><asp:ValidationSummary ID="valValidationSummary" runat="server" /></td>
        </tr>
        <tr>
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
            <td id="tdAdd" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </td>
            <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </td>
            <td class="SubHead" align="center" valign="bottom">
                <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" />
            </td>
        </tr>
    </table>
</center>
<p><portal:audit id="ctlAudit" runat="server" /></p>
<p><portal:tracking id="ctlTracking" runat="server" /></p>
<p><button onclick="ShowModalPopup('Default.aspx', 400, 200); return false;">show modal window button</button>
<asp:LinkButton ID="lnbModal" runat="server" Text="lnbModal" OnClientClick="showPopWin('http://www.bhattji.com', 480, 360, Null); return false;" />
<asp:HyperLink ID="hypModal" Text="hypModal" NavigateUrl="http://www.bhattji.com/web/default.aspx" CssClass="submodal" BorderStyle="none" runat="server" /> | <a class="submodal-400-600" href="http://www.bhattji.com/web">HTML Modal</a></p>
<a onclick="ShowModalPopup();" style="cursor:hand">AjaxModalPopup</a>
<%--<asp:TextBox ID="txtDate" runat="server" />
<ExtJS:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtDate" disabledDays="[0,1]" format="d/m/Y" />
       
<radcln:RadDatePicker id="RadDatePicker1" Runat="server" MinDate="2006-01-01" SelectedDate="2006-12-24">
<datepopupbutton HoverImageUrl="~/images/register.gif" ImageUrl="~/images/calendar.png"></datepopupbutton>
</radcln:RadDatePicker>
--%> 