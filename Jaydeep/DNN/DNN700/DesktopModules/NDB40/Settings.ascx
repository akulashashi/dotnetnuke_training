<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="bhattji.Modules.XYZ70s.Settings" %>
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

    <div id="divHost" runat="server">
    <h2 id="pnlHost" class="dnnFormSectionHead"><a href="#">Host Settings</a></h2>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="plOnlyHostCanEdit" ControlName="chkOnlyHostCanEdit" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkOnlyHostCanEdit" ResourceKey="OnlyHostCanEdit" TextAlign="Right" runat="server" />
        </div>
    </fieldset>
    </div>

    <h2 id="pnlScope" class="dnnFormSectionHead"><a href="#">Scope Settings</a></h2>
    <fieldset class="dnnClear">
    </fieldset>
    <h2 id="pnlUsability" class="dnnFormSectionHead"><a href="#">Usability Settings</a></h2>
    <fieldset class="dnnClear">

        <%--CreateSettingsUiControlStub--%>

    </fieldset>
    <h2 id="pnlThumbnail" class="dnnFormSectionHead"><a href="#">Thumbnail Settings</a></h2>
    <fieldset class="dnnClear">
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