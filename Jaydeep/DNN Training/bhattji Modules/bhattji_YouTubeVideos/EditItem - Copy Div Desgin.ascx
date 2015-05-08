<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditItem.ascx.cs" Inherits="bhattji.Modules.YouTubeVideos.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%--<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>--%>

<div class="dnnForm" id="frmEditItem">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label id="plTitle" controlname="txtTitle" suffix=":" runat="server" />

            <asp:TextBox ID="txtTitle" Width="300" CssClass="dnnFormRequired" runat="server" />
            <asp:RequiredFieldValidator ID="valTitle" ControlToValidate="txtTitle" ErrorMessage="You Must Enter A Title For The YouTubeVideo" resourcekey="Title.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plCategoryId" runat="server" controlname="ddlCategoryId" suffix=":" />

            <div>
                <asp:DropDownList ID="ddlCategoryId" CssClass="NormalTextBox" runat="server" />
                <asp:HyperLink ID="hypViewCategories" ImageUrl="~/images/register.gif" NavigateUrl="javascript://ShowModalPopup();" resourcekey="ViewCategories" CssClass="CommandButton" BorderStyle="none" runat="server" />
                <asp:ImageButton ID="imbShowCategories" ImageUrl="~/images/rt.gif" resourcekey="Open" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
                <asp:ImageButton ID="imbHideCategories" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" Visible="False" />
                <asp:PlaceHolder ID="phtCategories" runat="server" Visible="False" />
            </div>        
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc" controlname="ctlMediaSrc" suffix=":" runat="server" />

				<div>
					<portal:url id="ctlMediaSrc" width="300" runat="server" />            
					<asp:Label ID="lblMediaWidth" resourcekey="MediaWidth" CssClass="SubHead" runat="server" />
					<asp:TextBox ID="txtMediaWidth" Columns="5" CssClass="NormalTextBox" runat="server" Width="30px" />
					<asp:RegularExpressionValidator ID="valMediaWidth" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth" ErrorMessage="<br />Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
					<asp:Label ID="lblMediaHeight" resourcekey="MediaHeight" CssClass="SubHead" runat="server" />
					<asp:TextBox ID="txtMediaHeight" runat="server" Width="30px" />
					<asp:RegularExpressionValidator ID="valMediaHeight" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight" ErrorMessage="<br />Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
					<asp:Label ID="lblMediaAlign" resourcekey="MediaAlign" CssClass="SubHead" runat="server" />
					<asp:RadioButtonList ID="rblMediaAlign" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
						<asp:ListItem Value="Left" resourcekey="Left" />
						<asp:ListItem Value="Right" resourcekey="Right" />
					</asp:RadioButtonList>
				</div>
                  
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plDescription" controlname="txtDescription" suffix=":" runat="server" />

            <dnn:texteditor id="teDescription" width="640" height="480" runat="server" />
            <asp:RequiredFieldValidator ID="valDescription" resourcekey="Description.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDescription" ErrorMessage="You Must Enter A Description Of The YouTubeVideo" Display="Dynamic" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plActualFields" controlname="txtActualFields" suffix=":" runat="server" />

            <asp:TextBox ID="txtActualFields" Width="300" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plDetails" controlname="txtDetails" suffix=":" runat="server" />

            <dnn:texteditor id="teDetails" width="640" height="480" runat="server" />
            <asp:RequiredFieldValidator ID="valDetails" resourcekey="Details.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDetails" ErrorMessage="You Must Enter A Details Of The YouTubeVideo" Display="Dynamic" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc2" controlname="ctlMediaSrc2" suffix=":" runat="server" />

            <div>
                <portal:url id="ctlMediaSrc2" width="300" runat="server" />
                <asp:Label ID="lblMediaWidth2" resourcekey="MediaWidth" CssClass="SubHead" runat="server" /></td>
                <asp:TextBox ID="txtMediaWidth2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth2" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth2" ErrorMessage="<br />Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /><%--<act:filteredtextboxextender runat="server" id="fteMediaWidth2" targetcontrolid="txtMediaWidth2" filtertype="Numbers" />--%>
                <asp:Label ID="lblMediaHeight2" resourcekey="MediaHeight" CssClass="SubHead" runat="server" /></td>
                <asp:TextBox ID="txtMediaHeight2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight2" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight2" ErrorMessage="<br />Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /><%--<act:filteredtextboxextender runat="server" id="fteMediaHeight2" targetcontrolid="txtMediaHeight2" filtertype="Numbers" />--%>
                <asp:Label ID="lblMediaAlign2" resourcekey="MediaAlign" CssClass="SubHead" runat="server" /></td>
                <asp:RadioButtonList ID="rblMediaAlign2" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Left" resourcekey="Left" />
                    <asp:ListItem Value="Right" resourcekey="Right" />
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="dnnFormItem">
				<dnn:label id="plNavURL" controlname="ctlNavURL" suffix=":" runat="server" />
                <portal:url id="ctlNavURL" width="300" runat="server" />
        
        </div>
        <div class="dnnFormItem">
                <dnn:label id="plPublishDate" controlname="txtPublishDate" suffix=":" runat="server" />
                <dnn:DnnDatePicker ID="txtPublishDate"  runat="server" CssClass="dnnFormInput" />
                <asp:HyperLink runat="server" ID="hypPublishDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
                
        </div>
        <div class="dnnFormItem">
                <dnn:label id="plExpiryDate" controlname="txtExpiryDate" suffix=":" runat="server" />
                <dnn:DnnDatePicker ID="txtExpiryDate" runat="server" CssClass="dnnFormInput" />
                <asp:HyperLink runat="server" ID="hypExpiryDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" />
        </div>
        <div class="dnnFormItem">
                <dnn:label id="plViewOrder" controlname="txtViewOrder" suffix=":" runat="server" />
                <asp:TextBox ID="txtViewOrder" Columns="5" CssClass="NormalTextBox" runat="server" />
                <asp:CompareValidator ID="valViewOrder" resourcekey="ViewOrder.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="txtViewOrder" ErrorMessage="<br />View order must be an integer value." Display="Dynamic" Type="Integer" Operator="DataTypeCheck" />
        </div>       
    </fieldset>

    <div class="dnnFormItem">
        <asp:ValidationSummary ID="valValidationSummary" runat="server" />
    </div>
    <div class="dnnFormItem">
        <asp:DropDownList ID="ddlUpdateRedirection" runat="server">
            <asp:ListItem Value="Listing" resourcekey="Listing" />
            <asp:ListItem Value="NewItem" resourcekey="NewItem" />
            <asp:ListItem Value="EditItem" resourcekey="EditItem" />
            <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
        </asp:DropDownList>
    </div>
    <ul class="dnnActions dnnClear">
        <li><asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="dnnPrimaryAction" BorderStyle="none" runat="server" /></li>
        <li><asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="dnnPrimaryAction" BorderStyle="none" runat="server" /></li>
        <li><asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" BorderStyle="none" CausesValidation="False" runat="server" /></li>
        <li><asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="dnnSecondaryAction" BorderStyle="none" CausesValidation="False" runat="server" /></li>
        <li><asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="dnnSecondaryAction" runat="server" /></li>
    </ul>
    
    <p><portal:audit id="ctlAudit" runat="server" />
    <p><portal:tracking id="ctlTracking" runat="server" />
</div>

<table width="560" cellspacing="0" cellpadding="0" border="0" summary="Edit YouTubeVideos Design Table">
    <tr class="dnnForm">
        <td class="SubHead" width="150"></td>
        <td class="Normal" width="400"></td>
    </tr>
    <tr class="dnnForm">
        <td class="SubHead">
            
        </td>
        <td class="dnnFormItem dnnFormShort">
        <%--<act:validatorcalloutextender runat="Server" id="vlxTitle" targetcontrolid="valTitle" highlightcssclass="CustomValidatorCalloutStyle" />--%>
        </td>
    </tr>
    <tr class="dnnForm">
        <td class="SubHead">
            
        </td>
        <td class="dnnFormItem dnnFormShort">
            
        </td>
    </tr>
    <tr class="dnnForm">
        <td colspan="2">
            <br />
            <dnn:sectionhead id="secMediaSettings" cssclass="Head" section="tblMediaSettings" resourcekey="secMediaSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblMediaSettings" runat="server">
                <tr>
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                        <dnn:sectionhead id="secMediaSrc" cssclass="SubHead" section="divMediaSrc" resourcekey="secMediaSrc" includerule="True" isexpanded="false" runat="server" />
                        <div id="divMediaSrc" runat="server">
                            
                            <table>
                                <tr>
                                    <td>
                                        </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                        <dnn:sectionhead id="secDescription" cssclass="SubHead" section="divDescription" resourcekey="secDescription" includerule="True" isexpanded="false" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="SubHead" colspan="2">
                        <div id="divDescription" runat="server">
                            </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="dnnForm">
        <td class="SubHead">
            
        </td>
        <td class="dnnFormItem"></td>
    </tr>
    <tr id="trPQR45s" runat="server" class="dnnForm">
        <td colspan="2">
            <br />
            <dnn:sectionhead id="secPQR45s" cssclass="SubHead" section="divPQR45s" resourcekey="secPQR45s" includerule="True" isexpanded="false" runat="server" />
            <div id="divPQR45s" runat="server" />
        </td>
    </tr>
    <tr class="dnnForm">
        <td colspan="2">
            <br />
            <dnn:sectionhead id="secMedia2Settings" cssclass="Head" section="tblMedia2Settings" resourcekey="secMedia2Settings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblMedia2Settings" runat="server">
                <tr>
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                        <dnn:sectionhead id="secDetails" cssclass="SubHead" section="divDetails" resourcekey="secDetails" includerule="True" isexpanded="false" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="SubHead" colspan="2">
                        <div id="divDetails" runat="server">
                            </div>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                        <%--<dnn:sectionhead id="secMediaSrc2" cssclass="SubHead" section="divMediaSrc2" resourcekey="secMediaSrc2" includerule="True" isexpanded="false" runat="server" />--%>
                        <div id="divMediaSrc2" runat="server">
                            
                            <table>
                                <tr>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr class="dnnForm">
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                        <dnn:sectionhead id="secNavURL" cssclass="SubHead" section="divNavURL" resourcekey="secNavURL" includerule="True" isexpanded="false" runat="server" />
                        <div id="divNavURL" runat="server">
                            
                        </div>
                    </td>
                </tr>
                <tr class="dnnForm">
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                    
                        <%--<act:calendarextender id="calPublishDate" targetcontrolid="txtPublishDate" popupbuttonid="hypPublishDate" runat="server" format="d" />--%>
                        <%--<asp:CompareValidator ID="valPublishDate" resourcekey="PublishDate.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="txtPublishDate" ErrorMessage="<br />You have entered an invalid date!" Display="Dynamic" Type="Date" Operator="DataTypeCheck" />--%>
                    </td>
                </tr>
                <tr class="dnnForm">
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                    
                        <%--<act:calendarextender id="calExpiryDate" targetcontrolid="txtExpiryDate" popupbuttonid="hypExpiryDate" runat="server" format="d" />--%>
                        <%--<asp:CompareValidator ID="valExpiryDate" resourcekey="ExpiryDate.ErrorMessage" runat="server" CssClass="NormalRed" ControlToValidate="txtExpiryDate" ErrorMessage="<br />You have entered an invalid date!" Display="Dynamic" Type="Date" Operator="DataTypeCheck" />--%>
                    </td>
                </tr>
                <tr class="dnnForm">
                    <td class="SubHead">
                        
                    </td>
                    <td class="dnnFormItem dnnFormShort">
                    <%--<act:filteredtextboxextender runat="server" id="fteViewOrder" targetcontrolid="txtViewOrder" filtertype="Numbers" />--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<center>
    <table>
        <tr>
            <td class="SubHead" colspan="5" align="center">
                
            </td>
        </tr>
        <tr class="dnnForm">
            <td class="SubHead" colspan="5" align="center" class="dnnFormItem dnnFormShort">
                
            </td>
        </tr>
        <tr>
            <td id="tdAdd" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                
            </td>
            <td id="tdUpdate" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                
            </td>
            <td class="SubHead" align="center" valign="bottom">
                <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                
            </td>
            <td id="tdDelete" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                
            </td>
            <td id="tdPrint" class="SubHead" align="center" valign="bottom" runat="server">
                <asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                
            </td>
        </tr>
    </table>
</center>
