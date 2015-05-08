<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="bhattji.Modules.Feedbacks.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<div id="divPanelScript" runat="server">
    <script type="text/javascript">
        jQuery(function ($) {
            var setupModule = function () {
                $('#frmSettings').dnnPanels();
                $('#frmSettings .dnnFormExpandContent a').dnnExpandAll({
                    targetArea: '#frmSettings'
                });
            };
            setupModule();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                // note that this will fire when _any_ UpdatePanel is triggered,
                // which may or may not cause an issue
                setupModule();
            });
        });
    </script>
</div>
<div class="dnnForm" id="frmSettings">
    <div class="dnnFormExpandContent"><a href="">Expand All</a></div>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="plOnlyHostCanEdit" ControlName="chkOnlyHostCanEdit" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkOnlyHostCanEdit" ResourceKey="OnlyHostCanEdit" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plEmailTo" runat="server" ControlName="txtEmailTo" Text="Email To" />
            <asp:TextBox runat="server" ID="txtEmailTo" CssClass="dnnFormRequired" />
            <asp:RequiredFieldValidator ID="valEmailTo" runat="server" ControlToValidate="txtEmailTo" CssClass="dnnFormMessage dnnFormError" ErrorMessage="EmailTo is required" Display="Dynamic"/>
            <asp:RegularExpressionValidator ID="valEmailTo1" ControlToValidate="txtEmailTo" runat="server" ErrorMessage="Please enter a valid Email ID" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plEmailCc" runat="server" ControlName="txtEmailCc" Text="Email Cc" />
            <asp:TextBox runat="server" ID="txtEmailCc" CssClass="dnnFormRequired" />
            <asp:RegularExpressionValidator ID="valEmailCc" ControlToValidate="txtEmailCc" runat="server" ErrorMessage="Please enter a valid Email ID" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plEmailBcc" runat="server" ControlName="txtEmailBcc" Text="Email Bcc" />
            <asp:TextBox runat="server" ID="txtEmailBcc" CssClass="dnnFormRequired" />
            <asp:RegularExpressionValidator ID="valEmailBcc" ControlToValidate="txtEmailBcc" runat="server" ErrorMessage="Please enter a valid Email ID" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plSubscriptionRole" runat="server" ControlName="txtSubscriptionRole" Text="Subscription Role" />
            <asp:TextBox runat="server" ID="txtSubscriptionRole" CssClass="dnnFormRequired" />
            <asp:RequiredFieldValidator ID="valSubscriptionRole" runat="server" ControlToValidate="txtSubscriptionRole" CssClass="dnnFormMessage dnnFormError" ErrorMessage="Subscription Role required" Display="Dynamic"/>
        </div>
    </fieldset>
    <h2 id="pnlPayPal" class="dnnFormSectionHead"><a href="#">PayPal Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
        </div>
    </fieldset>
    
    <ul class="dnnActions dnnClear" id="ulButtons" runat="server">
        <li><asp:LinkButton ID="cmdUpdate" ResourceKey="cmdUpdate" CssClass="dnnPrimaryAction" BorderStyle="none" runat="server" /></li>
        <li><asp:LinkButton ID="cmdCancel" ResourceKey="cmdCancel" CssClass="dnnSecondaryAction" BorderStyle="none" CausesValidation="False" runat="server" /></li>
    </ul>
</div>
<p><portal:Audit id="ctlAudit" runat="server" /></p>