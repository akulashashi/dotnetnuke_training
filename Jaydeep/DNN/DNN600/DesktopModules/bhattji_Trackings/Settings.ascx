<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Settings.ascx.cs" Inherits="bhattji.Modules.Trackings.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
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
            setupModule();
        });
    });
</script>
</div>
<div class="dnnForm" id="frmSettings">
    <div class="dnnFormExpandContent"><a href="">Expand All</a></div>
    
    <h2 id="pnlTracking" class="dnnFormSectionHead"><a href="#">Tracking Settings</a></h2>
    <fieldset class="dnnClear"> 
        <div class="dnnFormItem">
            <dnn:label id="plEventId" controlname="rblEventId" suffix=":" runat="server" />            
            <asp:RadioButtonList ID="rblEventId" runat="server">
                <asp:ListItem Value="323606" resourcekey="323606" />
                <asp:ListItem Value="323676" resourcekey="323676" />
                <asp:ListItem Value="323696" resourcekey="323696" />
            </asp:RadioButtonList>
        </div>
        
        <div class="dnnFormItem">
            <dnn:label id="plOrgId" controlname="txtOrgId" suffix=":" runat="server" />
            <asp:TextBox ID="txtOrgId" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plCurrency" controlname="txtCurrency" suffix=":" runat="server" />
            <asp:TextBox ID="txtCurrency" MaxLength="3" runat="server" />
        </div>                
        <div class="dnnFormItem">
            <dnn:label id="plProductName" controlname="txtProductName" suffix=":" runat="server" />
            <asp:TextBox ID="txtProductName" runat="server" />
        </div>
    </fieldset>
    
    
    <ul class="dnnActions dnnClear" id="ulButtons" runat="server">
        <li><asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="dnnPrimaryAction" BorderStyle="none" runat="server" /></li>
        <li><asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" BorderStyle="none" CausesValidation="False" runat="server" /></li>
    </ul>
</div>
<p><portal:audit id="ctlAudit" runat="server" /></p>