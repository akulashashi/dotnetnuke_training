<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditItem.ascx.cs" Inherits="bhattji.Modules.XYZ70s.EditItem" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
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
                <dnn:Label id="plTitle" ControlName="txtTitle" Suffix=":" runat="server" />
                <asp:TextBox ID="txtTitle" CssClass="dnnFormRequired" runat="server" />
                <asp:RequiredFieldValidator ID="valTitle" ControlToValidate="txtTitle" ErrorMessage="You Must Enter A Title For The XYZ70" ResourceKey="Title.ErrorMessage" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plCategoryId" runat="server" ControlName="ddlCategoryId" Suffix=":" />
                <div class="dnnLeft" style="width: 480px">
                    <asp:DropDownList ID="ddlCategoryId" runat="server" />
                    <asp:ImageButton ID="imbShowCategories" ImageUrl="~/images/rt.gif" ResourceKey="Open" CausesValidation="False" runat="server" /><asp:ImageButton ID="imbHideCategories" ImageUrl="~/images/lt.gif" ResourceKey="Close" CausesValidation="False" runat="server" Visible="False" />
                    <div class="dnnLeft" style="width: 480px">
                        <asp:PlaceHolder ID="phtCategories" runat="server" Visible="false" />
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
    <div id="tabDescription" class="dnnClear">
        <fieldset>
            <div class="dnnFormItem">
                <dnn:Label id="plMediaSrc" ControlName="ctlMediaSrc" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <div class="dnnClear" style="width: 480px">
                        <portal:URL ID="ctlMediaSrc" ShowNone="true" ShowUrls="true" ShowFiles="true" ShowTabs="false" ShowLog="false" ShowNewWindow="false" ShowTrack="false" ShowUsers="false" Width="300px" runat="server" />
                    </div>
                    <div class="dnnClear">
                        <div class="dnnLeft" style="width: 50px">
                            <asp:Label ID="lblMediaWidth" ResourceKey="MediaWidth" runat="server" /></div>
                        <div class="dnnLeft" style="width: 70px">
                            <asp:TextBox ID="txtMediaWidth" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth" ResourceKey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                        <div class="dnnLeft" style="width: 50px">
                            <asp:Label ID="lblMediaHeight" ResourceKey="MediaHeight" runat="server" /></div>
                        <div class="dnnLeft" style="width: 70px">
                            <asp:TextBox ID="txtMediaHeight" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight" ResourceKey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>                   
                        <div class="dnnLeft" style="width: 50px">
                            <asp:Label ID="lblMediaAlign" ResourceKey="MediaAlign" runat="server" /></div>
                        <div class="dnnLeft">
                            <asp:RadioButtonList ID="rblMediaAlign" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Left" ResourceKey="Left" />
                                <asp:ListItem Value="Right" ResourceKey="Right" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plDescription" ControlName="teDescription" Suffix=":" runat="server" />
                <div class="dnnLeft" style="width: 480px">
                    <dnn:TextEditor id="teDescription" width="480px" runat="server" CssClass="dnnFormInput" />
                    <asp:RequiredFieldValidator ID="valDescription" ResourceKey="Description.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDescription" ErrorMessage="You Must Enter A Description Of The XYZ70" Display="Dynamic" />
                </div>
            </div>
        </fieldset>
    </div>
    <div id="tabActual" class="dnnClear">
        <fieldset>
            <%--CreateEditUiControlStub--%>
        </fieldset>
    </div>
    <div id="tabDetail" class="dnnClear">
        <fieldset>
            <div class="dnnFormItem">
                <dnn:Label id="plDetails" ControlName="teDetails" Suffix=":" runat="server" />
                <div class="dnnLeft" style="width: 480px">
                    <dnn:TextEditor id="teDetails" width="480px" runat="server" />
                    <asp:RequiredFieldValidator ID="valDetails" ResourceKey="Details.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="teDetails" ErrorMessage="You Must Enter A Details Of The XYZ70" Display="Dynamic" />
                </div>
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plMediaSrc2" ControlName="ctlMediaSrc2" Suffix=":" runat="server" />
                <div class="dnnLeft">
                    <portal:URL ID="ctlMediaSrc2" ShowNone="true" ShowUrls="true" ShowFiles="true" ShowTabs="false" ShowLog="false" ShowNewWindow="false" ShowTrack="false" ShowUsers="false" Width="300px" runat="server" />
                    <div class="dnnLeft" style="width: 50px">
                        <asp:Label ID="lblMediaWidth2" ResourceKey="MediaWidth" runat="server" /></div>
                    <div class="dnnLeft" style="width: 70px">
                        <asp:TextBox ID="txtMediaWidth2" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valMediaWidth2" ResourceKey="valMediaWidth.ErrorMessage" runat="server" ControlToValidate="txtMediaWidth2" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft" style="width: 50px">
                        <asp:Label ID="lblMediaHeight2" ResourceKey="MediaHeight" runat="server" /></div>
                    <div class="dnnLeft" style="width: 70px">
                        <asp:TextBox ID="txtMediaHeight2" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valMediaHeight2" ResourceKey="valMediaHeight.ErrorMessage" runat="server" ControlToValidate="txtMediaHeight2" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                    <div class="dnnLeft" style="width: 50px">
                        <asp:Label ID="lblMediaAlign2" ResourceKey="MediaAlign" runat="server" /></div>
                    <div class="dnnLeft">
                        <asp:RadioButtonList ID="rblMediaAlign2" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Left" ResourceKey="Left" />
                            <asp:ListItem Value="Right" ResourceKey="Right" />
                        </asp:RadioButtonList>
                    </div>
                </div>                
            </div>
        </fieldset>
    </div>
    <div id="tabOther" class="dnnClear">
        <fieldset>
            <div class="dnnFormItem">
                <dnn:Label id="plNavURL" ControlName="ctlNavURL" Suffix=":" runat="server" />
                <div class="dnnLeft" style="width: 480px">
                    <portal:URL ID="ctlNavURL" ShowNone="true" ShowUrls="true" ShowFiles="true" ShowTabs="true" ShowLog="true" ShowNewWindow="true" ShowTrack="true" ShowUsers="false" Width="300px" runat="server" />
                </div>
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plPublishDate" ControlName="ddpPublishDate" Suffix=":" runat="server" />
                <dnn:DnnDatePicker ID="ddpPublishDate" MinDate="1/1/1753" Width="150px" runat="server" CssClass="dnnFormInput" />
                <asp:CompareValidator ID="valPublishDate" ResourceKey="PublishDate.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="ddpPublishDate" ErrorMessage="PublishDate must be a valid date, later than '1/1/1753'." Display="Dynamic" Type="Date" Operator="GreaterThanEqual" ValueToCompare="1/1/1753" />
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plExpiryDate" ControlName="ddpExpiryDate" Suffix=":" runat="server" />
                <dnn:DnnDatePicker ID="ddpExpiryDate" MinDate="1/1/1753" Width="150px" runat="server" CssClass="dnnFormInput" />
                <asp:CompareValidator ID="valExpiryDate" ResourceKey="ExpiryDate.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="ddpExpiryDate" ErrorMessage="ExpiryDate must be a valid date, later than '1/1/1753'." Display="Dynamic" Type="Date" Operator="GreaterThanEqual" ValueToCompare="1/1/1753" />
            </div>
            <div class="dnnFormItem">
                <dnn:Label id="plViewOrder" ControlName="txtViewOrder" Suffix=":" runat="server" />
                <asp:TextBox ID="txtViewOrder" Width="90px" runat="server" /><asp:CompareValidator ID="valViewOrder" ResourceKey="ViewOrder.ErrorMessage" runat="server" CssClass="dnnFormMessage dnnFormError" ControlToValidate="txtViewOrder" ErrorMessage="View order must be an integer value." Display="Dynamic" Type="Integer" Operator="DataTypeCheck" />
            </div>
            <div class="dnnFormItem" id="dfiPQR45s" runat="server">
                <dnn:Label id="plPQR45s" ControlName="divPQR45s" Suffix=":" runat="server" />
                <div id="divPQR45s" runat="server" />
            </div>
        </fieldset>
    </div>

    <asp:ValidationSummary ID="valValidationSummary" runat="server" CssClass="dnnFormMessage dnnFormValidationSummary" />

    <asp:DropDownList ID="ddlUpdateRedirection" runat="server" CssClass="dnnFormInput">
        <asp:ListItem Value="Listing" ResourceKey="Listing" />
        <asp:ListItem Value="NewItem" ResourceKey="NewItem" />
        <asp:ListItem Value="EditItem" ResourceKey="EditItem" />
        <asp:ListItem Value="ItemDetails" ResourceKey="ItemDetails" />
    </asp:DropDownList>
    <ul class="dnnActions dnnClear">
        <li id="liAdd" runat="server"><asp:LinkButton ID="cmdAdd" ResourceKey="Add" CssClass="dnnPrimaryAction" runat="server" /></li>
        <li id="liUpdate" runat="server"><asp:LinkButton ID="cmdUpdate" ResourceKey="cmdUpdate" CssClass="dnnPrimaryAction" runat="server" /></li>
        <li><asp:LinkButton ID="cmdCancel" ResourceKey="cmdCancel" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /></li>
        <li id="liDelete" runat="server"><asp:LinkButton ID="cmdDelete" ResourceKey="cmdDelete" CssClass="dnnSecondaryAction" CausesValidation="False" runat="server" /></li>
        <li id="liPrint" runat="server"><asp:HyperLink ID="hypPrint" Target="_blank" ResourceKey="Print" CssClass="dnnSecondaryAction" runat="server" /></li>    
    </ul>
</div>
<p><portal:Audit ID="ctlAudit" runat="server" />
<p><portal:Tracking ID="ctlTracking" runat="server" />