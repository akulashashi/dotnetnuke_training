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
    
    <h2 id="pnlMedia" class="dnnFormSectionHead"><a href="#">Media Settings</a></h2>
    <fieldset class="dnnClear"> 
        <div class="dnnFormItem">
            <dnn:label id="plPlayer" controlname="rblPlayer" suffix=":" runat="server" />            
            <asp:RadioButtonList ID="rblPlayer" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="video" resourcekey="Video" />
                <asp:ListItem Value="audio" resourcekey="Audio" />
                <asp:ListItem Value="img" resourcekey="Image" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc" controlname="ctlMediaSrc" suffix=":" runat="server" />
            
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlMediaSrc" Width="300px" runat="server" />
                <div class="dnnClear">
                    <asp:Label ID="lblSrcType" resourcekey="SrcType" class="dnnLeft" style="margin-right:20px" runat="server" />
                    <asp:TextBox ID="txtSrcType" Width="150px" class="dnnLeft" runat="server" />
                </div>
                <div class="dnnLeft" style="width:50px">
                    <asp:Label ID="lblWidth" resourcekey="Width" runat="server" /></div>
                <div class="dnnLeft" style="width:70px">
                    <asp:TextBox ID="txtWidth" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valWidth" resourcekey="valWidth.ErrorMessage" runat="server" ControlToValidate="txtWidth" ErrorMessage="Width Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>
                <div class="dnnLeft" style="width:50px">
                    <asp:Label ID="lblHeight" resourcekey="Height" runat="server" /></div>
                <div class="dnnLeft" style="width:70px">
                    <asp:TextBox ID="txtHeight" Width="50px" runat="server" /><asp:RegularExpressionValidator ID="valHeight" resourcekey="valHeight.ErrorMessage" runat="server" ControlToValidate="txtHeight" ErrorMessage="Height Must Be A Valid Integer" Display="Dynamic" ValidationExpression="^[1-9]+[0]*$" CssClass="dnnFormMessage dnnFormError" /></div>                
            </div>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plResponsive" controlname="chkResponsive" suffix=":" runat="server" />
            <asp:CheckBox ID="chkResponsive" resourcekey="Responsive" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plDescription" controlname="txtDescription" suffix=":" runat="server" />
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" />
        </div>
    </fieldset>
    <h2 id="pnlDescription" class="dnnFormSectionHead"><a href="#">Alternative Source Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc2" controlname="ctlMediaSrc2" suffix=":" runat="server" />
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlMediaSrc2" Width="300px" runat="server" />
                <div class="dnnClear">
                    <asp:Label ID="lblSrcType2" resourcekey="SrcType2" class="dnnLeft" style="margin-right:20px" runat="server" />
                    <asp:TextBox ID="txtSrcType2" Width="150px" class="dnnLeft" runat="server" />
                </div>
            </div>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plMediaSrc3" controlname="ctlMediaSrc3" suffix=":" runat="server" />
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlMediaSrc3" Width="300px" runat="server" />
                <div class="dnnClear">
                    <asp:Label ID="lblSrcType3" resourcekey="SrcType3" class="dnnLeft" style="margin-right:20px" runat="server" />
                    <asp:TextBox ID="txtSrcType3" Width="150px" class="dnnLeft" runat="server" />
                </div>
            </div>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plFallbackUrl" controlname="txtFallbackUrl" suffix=":" runat="server" />
            <asp:TextBox ID="txtFallbackUrl" runat="server" />
        </div>
    </fieldset>
    <h2 id="pnlImage" class="dnnFormSectionHead"><a href="#">Image Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:label id="plPosterSrc" controlname="ctlPosterSrc" suffix=":" runat="server" />            
            <div class="dnnLeft" style="width: 480px">
                <Portal:URL ID="ctlPosterSrc" Width="300px" runat="server" />
            </div>
        </div>
<%--
        <div class="dnnFormItem">
            <dnn:label id="plRattleImage" controlname="chkRattleImage" suffix=":" runat="server" />
            <asp:CheckBox ID="chkRattleImage" resourcekey="RattleImage" TextAlign="Right" runat="server" />
        </div>
--%>
    </fieldset>
    <h2 id="pnlOptions" class="dnnFormSectionHead"><a href="#">Options Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:label id="plShowControls" controlname="chkShowControls" suffix=":" runat="server" />
            <asp:CheckBox ID="chkShowControls" resourcekey="ShowControls" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plAutoPlay" controlname="chkAutoPlay" suffix=":" runat="server" />
            <asp:CheckBox ID="chkAutoPlay" resourcekey="AutoPlay" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plLoop" controlname="chkLoop" suffix=":" runat="server" />
            <asp:CheckBox ID="chkLoop" resourcekey="Loop" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plMuted" controlname="chkMuted" suffix=":" runat="server" />
            <asp:CheckBox ID="chkMuted" resourcekey="Muted" TextAlign="Right" runat="server" />
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