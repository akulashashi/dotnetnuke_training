<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Settings.ascx.cs" Inherits="bhattji.Modules.YouTubeVideos.Settings" %>
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
    
    <h2 id="pnlMedia" class="dnnFormSectionHead"><a href="#">Media Settings</a></h2>
    <fieldset class="dnnClear"> 
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc" controlname="txtMediaSrc" suffix=":" runat="server" />
            <asp:TextBox ID="txtMediaSrc" runat="server" Width="300px" /><asp:HyperLink ID="hypYoutube" NavigateUrl="http://youtube.com" Target="_blank" Text="Visit Youtube" CssClass="dnnPrimaryAction" runat="server"/>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plWidth" controlname="txtWidth" suffix=":" runat="server" />
            <asp:TextBox ID="txtWidth" Width="100px" runat="server" /><asp:RegularExpressionValidator ID="valWidth" resourcekey="valWidth.ErrorMessage" runat="server" ControlToValidate="txtWidth" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plHeight" controlname="txtHeight" suffix=":" runat="server" />
            <asp:TextBox ID="txtHeight" Width="100px" runat="server" /><asp:RegularExpressionValidator ID="valHeight" resourcekey="valHeight.ErrorMessage" runat="server" ControlToValidate="txtHeight" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
        </div>
        
        <div class="dnnFormItem">
            <dnn:label id="plStartTime" controlname="txtStartTime" suffix=":" runat="server" />
            <asp:TextBox ID="txtStartTime" Width="100px" runat="server" /><asp:RegularExpressionValidator ID="valStartTime" resourcekey="valStartTime.ErrorMessage" runat="server" ControlToValidate="txtStartTime" ErrorMessage="StartTime Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plEndTime" controlname="txtEndTime" suffix=":" runat="server" />
            <asp:TextBox ID="txtEndTime" Width="100px" runat="server" /><asp:RegularExpressionValidator ID="valEndTime" resourcekey="valEndTime.ErrorMessage" runat="server" ControlToValidate="txtEndTime" ErrorMessage="EndTime Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" />
            <asp:CompareValidator ID="valEndTime1" runat="server" ErrorMessage="EndTime must be greater than StartTime" CssClass="dnnFormMessage dnnFormError" ControlToCompare="txtStartTime" ControlToValidate="txtEndTime" Operator="GreaterThan" Type="Integer" />
        </div>

    </fieldset>
    <h2 id="pnlDescription" class="dnnFormSectionHead"><a href="#">Description Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:label id="plDescription" controlname="txtDescription" suffix=":" runat="server" />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" />
        </div>
    </fieldset>
    <h2 id="pnlOther" class="dnnFormSectionHead"><a href="#">Navigation Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:label id="plNavURL" controlname="ctlNavURL" suffix=":" runat="server" />
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlNavURL" Width="300px" runat="server" />                
            </div>
            <div class="dnnFormItem">
                <dnn:label id="plNewWindow" controlname="chkNewWindow" suffix=":" runat="server" />
                <asp:CheckBox ID="chkNewWindow" resourcekey="NewWindow" TextAlign="Right" runat="server" />
            </div>
        </div>
    </fieldset>
    
    <ul class="dnnActions dnnClear" id="ulButtons" runat="server">
        <li><asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="dnnPrimaryAction" BorderStyle="none" runat="server" /></li>
        <li><asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" BorderStyle="none" CausesValidation="False" runat="server" /></li>
    </ul>
</div>
<p><portal:audit id="ctlAudit" runat="server" /></p>