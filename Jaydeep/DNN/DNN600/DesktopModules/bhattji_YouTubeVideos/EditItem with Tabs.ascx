<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditItem.ascx.cs" Inherits="bhattji.Modules.YouTubeVideos.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%--<%@ Register TagPrefix="act" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>--%>
<script type="text/javascript">
    jQuery(function ($) {
        $('#frmEditItem').dnnTabs();
    });
</script>
<div class="dnnForm" id="frmEditItem">
    <div class="dnnFormItem dnnFormHelp dnnClear">
        <p class="dnnFormRequired">
            <asp:Label ID="lblRequiredIndicator" runat="server" ResourceKey="RequiredIndicator" /></p>
    </div>
    <ul class="dnnAdminTabNav">
        <li><a href="#tabBasic">Basic</a></li>
        <li><a href="#tabDescription">Description</a></li>
        <li><a href="#tabActual">Actual</a></li>
        <li><a href="#tabDetail">Detail</a></li>
        <li><a href="#tabOther">Other</a></li>
    </ul>
        <div id="tabBasic" class="dnnClear">
    <fieldset>
            <div class="dnnFormItem">
                <dnn:Label ID="plTitle" ControlName="txtTitle" Suffix=":" runat="server" />
                <asp:TextBox ID="txtTitle" Width="300" CssClass="dnnFormRequired" runat="server" />
                <asp:RequiredFieldValidator ID="valTitle" ControlToValidate="txtTitle" ErrorMessage="You Must Enter A Title For The YouTubeVideo" resourcekey="Title.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
            </div>
            <div class="dnnFormItem">
                <dnn:Label ID="plCategoryId" runat="server" ControlName="ddlCategoryId" Suffix=":" />
                <div class="dnnLeft">
                    <asp:DropDownList ID="ddlCategoryId" runat="server" />
                    <div class="dnnLeft">
                        <asp:ImageButton ID="imbShowCategories" ImageUrl="~/images/rt.gif" resourcekey="Open" CssClass="dnnPrimaryAction" CausesValidation="False" runat="server" />
                        <asp:ImageButton ID="imbHideCategories" ImageUrl="~/images/lt.gif" resourcekey="Close" CssClass="dnnPrimaryAction" CausesValidation="False" runat="server" Visible="False" />
                    </div>
                    <div class="dnnLeft dnnClear">
                        <asp:PlaceHolder ID="phtCategories" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
    </fieldset>
        </div>
        <div id="tabDescription" class="dnnClear">
    <fieldset>
            <div class="dnnFormItem">
                <dnn:Label ID="plMediaSrc" ControlName="ctlMediaSrc" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <Portal:URL ID="ctlMediaSrc" Width="300px" runat="server" />
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaWidth" resourcekey="MediaWidth" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:TextBox ID="txtMediaWidth" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaHeight" resourcekey="MediaHeight" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:TextBox ID="txtMediaHeight" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaAlign" resourcekey="MediaAlign" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:RadioButtonList ID="rblMediaAlign" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Left" resourcekey="Left" />
                            <asp:ListItem Value="Right" resourcekey="Right" />
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div class="dnnFormItem">
                <dnn:Label ID="plDescription" ControlName="teDescription" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <dnn:TextEditor ID="teDescription" Width="480px" runat="server" CssClass="dnnFormInput" />
                    <asp:RequiredFieldValidator ID="valDescription" resourcekey="Description.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDescription" ErrorMessage="You Must Enter A Description Of The YouTubeVideo" Display="Dynamic" />
                </div>
            </div>
    </fieldset>
        </div>
        <div id="tabActual" class="dnnClear">
    <fieldset>
            <div class="dnnFormItem">
                <dnn:Label ID="plActualFields" ControlName="txtActualFields" Suffix=":" runat="server" />
                <asp:TextBox ID="txtActualFields" Width="300" runat="server" />
            </div>
    </fieldset>
        </div>
        <div id="tabDetail" class="dnnClear">
    <fieldset>
            <div class="dnnFormItem">
                <dnn:Label ID="plDetails" ControlName="teDetails" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <dnn:TextEditor ID="teDetails" Width="480px" runat="server" />
                    <asp:RequiredFieldValidator ID="valDetails" resourcekey="Details.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDetails" ErrorMessage="You Must Enter A Details Of The YouTubeVideo" Display="Dynamic" />
                </div>
            </div>
            <div class="dnnFormItem">
                <dnn:Label ID="plMediaSrc2" ControlName="ctlMediaSrc2" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <Portal:URL ID="ctlMediaSrc2" Width="300px" runat="server" />
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaWidth2" resourcekey="MediaWidth" CssClass="SubHead" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:TextBox ID="txtMediaWidth2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth2" resourcekey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth2" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaHeight2" resourcekey="MediaHeight" CssClass="SubHead" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:TextBox ID="txtMediaHeight2" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight2" resourcekey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight2" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft">
                        <asp:Label ID="lblMediaAlign2" resourcekey="MediaAlign" CssClass="SubHead" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:RadioButtonList ID="rblMediaAlign2" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Left" resourcekey="Left" />
                            <asp:ListItem Value="Right" resourcekey="Right" />
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
    </fieldset>
        </div>
        <div id="tabOther" class="dnnClear">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="plNavURL" ControlName="ctlNavURL" Suffix=":" runat="server" />
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlNavURL" Width="300px" runat="server" />
            </div>
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="plPublishDate" ControlName="txtPublishDate" Suffix=":" runat="server" />
            <asp:TextBox ID="txtPublishDate" runat="server" CssClass="dnnFormInput" /><asp:HyperLink runat="server" ID="hypPublishDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><asp:CompareValidator ID="valPublishDate" resourcekey="PublishDate.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="txtPublishDate" ErrorMessage="PublishDate must be a valid date value." Display="Dynamic" Type="Date" Operator="DataTypeCheck" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="plExpiryDate" ControlName="txtExpiryDate" Suffix=":" runat="server" />
            <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="dnnFormInput" /><asp:HyperLink runat="server" ID="hypExpiryDate" ImageUrl="~/images/calendar.png" Style="cursor: hand" /><asp:CompareValidator ID="valExpiryDate" resourcekey="ExpiryDate.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="txtExpiryDate" ErrorMessage="ExpiryDate must be a valid date value." Display="Dynamic" Type="Date" Operator="DataTypeCheck" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="plViewOrder" ControlName="txtViewOrder" Suffix=":" runat="server" />
            <asp:TextBox ID="txtViewOrder" Columns="5" CssClass="NormalTextBox" runat="server" /><asp:CompareValidator ID="valViewOrder" resourcekey="ViewOrder.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="txtViewOrder" ErrorMessage="View order must be an integer value." Display="Dynamic" Type="Integer" Operator="DataTypeCheck" />
        </div>
        <div class="dnnFormItem" id="dfiPQR45s" runat="server">
            <dnn:Label ID="plPQR45s" ControlName="divPQR45s" Suffix=":" runat="server" />
            <div id="divPQR45s" runat="server" />
         </div>
    </fieldset>
         </div>
</div>
<table>
    <tr>
        <td colspan="5" align="center">
            <asp:ValidationSummary ID="valValidationSummary" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="5" align="center" class="dnnFormItem">
            <asp:DropDownList ID="ddlUpdateRedirection" runat="server" CssClass="dnnFormInput">
                <asp:ListItem Value="Listing" resourcekey="Listing" />
                <asp:ListItem Value="NewItem" resourcekey="NewItem" />
                <asp:ListItem Value="EditItem" resourcekey="EditItem" />
                <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td id="tdAdd" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbAdd" ImageUrl="~/images/add.gif" resourcekey="Add" CssClass="dnnPrimaryAction" runat="server" /><br />
            <asp:LinkButton ID="cmdAdd" resourcekey="Add" CssClass="dnnPrimaryAction" runat="server" />
        </td>
        <td id="tdUpdate" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="dnnPrimaryAction" runat="server" /><br />
            <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="dnnPrimaryAction" runat="server" />
        </td>
        <td align="center" valign="bottom">
            <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /><br />
            <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" />
        </td>
        <td id="tdDelete" align="center" valign="bottom" runat="server">
            <asp:ImageButton ID="imbDelete" ImageUrl="~/images/delete.gif" resourcekey="cmdDelete" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /><br />
            <asp:LinkButton ID="cmdDelete" resourcekey="cmdDelete" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" />
        </td>
        <td id="tdPrint" align="center" valign="bottom" runat="server">
            <asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print.gif" Target="_blank" resourcekey="Print" CssClass="dnnSecondaryAction" runat="server" /><br />
            <asp:HyperLink ID="hypPrint" Target="_blank" resourcekey="Print" CssClass="dnnSecondaryAction" runat="server" />
        </td>
    </tr>
</table>
<p>
    <Portal:Audit ID="ctlAudit" runat="server" />
</p>
<p>
    <Portal:Tracking ID="ctlTracking" runat="server" />
</p>
