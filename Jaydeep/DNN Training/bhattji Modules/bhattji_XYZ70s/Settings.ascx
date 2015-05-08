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
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label id="plOnlyHostCanEdit" ControlName="chkOnlyHostCanEdit" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkOnlyHostCanEdit" ResourceKey="OnlyHostCanEdit" TextAlign="Right" runat="server" />
        </div>
    </fieldset>
    <h2 id="pnlScope" class="dnnFormSectionHead"><a href="#">Scope Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:Label id="plItemsScope" runat="server" ControlName="rblItemsScope" Suffix=":" />
            <table>
                <tr>
                    <td nowrap>
                        <asp:RadioButtonList ID="rblItemsScope" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="0" ResourceKey="Module" />
                            <asp:ListItem Value="1" ResourceKey="Portal" />
                            <asp:ListItem Value="2" ResourceKey="All" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:LinkButton ID="cmdClaimOrphan" ResourceKey="cmdClaimOrphan" runat="server" CssClass="dnnSecondaryAction" /></td>
                    <td>
                        <asp:LinkButton ID="cmdSetViewOrder" ResourceKey="cmdSetViewOrder" runat="server" CssClass="dnnSecondaryAction" /></td>
                </tr>
            </table>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plCategoriesScope" runat="server" ControlName="rblCategoriesScope" Suffix=":" />
            <table>
                <tr>
                    <td nowrap>
                        <asp:RadioButtonList ID="rblCategoriesScope" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="0" ResourceKey="Module" />
                            <asp:ListItem Value="1" ResourceKey="Portal" />
                            <asp:ListItem Value="2" ResourceKey="All" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:LinkButton ID="cmdClaimOrphanCat" ResourceKey="cmdClaimOrphan" runat="server" CssClass="dnnSecondaryAction" /></td>
                    <td>
                        <asp:LinkButton ID="cmdSetViewOrderCat" ResourceKey="cmdSetViewOrder" runat="server" CssClass="dnnSecondaryAction" /></td>
                </tr>
            </table>
        </div>
    </fieldset>
    <h2 id="pnlUsability" class="dnnFormSectionHead"><a href="#">Usability Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:Label id="plViewControl" ControlName="rblViewControl" Suffix=":" runat="server" />
            <asp:RadioButtonList ID="rblViewControl" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="List" ResourceKey="List" />
                <asp:ListItem Value="Catalog" ResourceKey="Catalog" />
                <asp:ListItem Value="Grid" ResourceKey="Grid" />
                <asp:ListItem Value="Thumbs" ResourceKey="Thumbs" />
                <asp:ListItem Value="Jukes" ResourceKey="Jukes" />
                <asp:ListItem Value="Tabs" ResourceKey="Tabs" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plHideSearch" ControlName="chkHideSearch" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkHideSearch" ResourceKey="HideSearch" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plTabCss" tabcssname="rblTabCss" Suffix=":" runat="server" />
            <asp:RadioButtonList ID="rblTabCss" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="tab.luna.css" ResourceKey="Luna" />
                <asp:ListItem Value="tab.webfx.css" ResourceKey="WinFx" />
                <asp:ListItem Value="tab.winclassic.css" ResourceKey="Classic" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plTransition" runat="server" Suffix=":" ControlName="ddlTransition" />
            <asp:DropDownList ID="ddlTransition" runat="server">
                <asp:ListItem Value="" ResourceKey="None" />
                <asp:ListItem Value="Barn" ResourceKey="Barn" />
                <asp:ListItem Value="Blinds" ResourceKey="Blinds" />
                <asp:ListItem Value="CheckerBoard" ResourceKey="CheckerBoard" />
                <asp:ListItem Value="Fade" ResourceKey="Fade" />
                <asp:ListItem Value="GradientWipe" ResourceKey="GradientWipe" />
                <asp:ListItem Value="Inset" ResourceKey="Inset" />
                <asp:ListItem Value="Iris" ResourceKey="Iris" />
                <asp:ListItem Value="Pixelate" ResourceKey="Pixelate" />
                <asp:ListItem Value="RadialWipe" ResourceKey="RadialWipe" />
                <asp:ListItem Value="RandomBars" ResourceKey="RandomBars" />
                <asp:ListItem Value="RandomDissolve" ResourceKey="RandomDissolve" />
                <asp:ListItem Value="Slide" ResourceKey="Slide" />
                <asp:ListItem Value="Spiral" ResourceKey="Spiral" />
                <asp:ListItem Value="Stretch" ResourceKey="Stretch" />
                <asp:ListItem Value="Strips" ResourceKey="Strips" />
                <asp:ListItem Value="Wheel" ResourceKey="Wheel" />
                <asp:ListItem Value="Zigzag" ResourceKey="ZigZag" />
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plRattleImage" ControlName="chkRattleImage" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkRattleImage" ResourceKey="RattleImage" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plAddDescription" ControlName="chkAddDescription" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkAddDescription" ResourceKey="AddDescription" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plAddDate" ControlName="ddlAddDate" Suffix=":" runat="server" />
            <asp:DropDownList ID="ddlAddDate" runat="server">
                <asp:ListItem Value="N" ResourceKey="None" />
                <asp:ListItem Value="A" ResourceKey="After" />
                <asp:ListItem Value="B" ResourceKey="Before" />
                <asp:ListItem Value="U" ResourceKey="Above" />
                <asp:ListItem Value="D" ResourceKey="Below" />
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plShowRatings" ControlName="chkShowRatings" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkShowRatings" ResourceKey="ShowRatings" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plHideTextLink" ControlName="chkHideTextLink" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkHideTextLink" ResourceKey="HideTextLink" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plUpdateRedirection" runat="server" Suffix=":" ControlName="ddlUpdateRedirection" />
            <asp:DropDownList ID="ddlUpdateRedirection" runat="server">
                <asp:ListItem Value="Listing" ResourceKey="Listing" />
                <asp:ListItem Value="NewItem" ResourceKey="NewItem" />
                <asp:ListItem Value="EditItem" ResourceKey="EditItem" />
                <asp:ListItem Value="ItemDetails" ResourceKey="ItemDetails" />
            </asp:DropDownList>
        </div>
    </fieldset>
    <h2 id="pnlThumbnail" class="dnnFormSectionHead"><a href="#">Thumbnail Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:Label id="plDynamicThumb" ControlName="chkDynamicThumb" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkDynamicThumb" ResourceKey="DynamicThumb" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plThumbWidth" ControlName="txtThumbWidth" Suffix=":" runat="server" />
            <asp:TextBox ID="txtThumbWidth" Columns="5" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plThumbHeight" ControlName="txtThumbHeight" Suffix=":" runat="server" />
            <asp:TextBox ID="txtThumbHeight" Columns="5" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plThumbColumns" ControlName="txtThumbColumns" Suffix=":" runat="server" />
            <asp:TextBox ID="txtThumbColumns" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valThumbColumns" ResourceKey="valThumbColumns.ErrorMessage" ControlToValidate="txtThumbColumns" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Thumb Columns Must Be A Valid Integer" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plThumbRows" ControlName="txtThumbRows" Suffix=":" runat="server" />
            <asp:TextBox ID="txtThumbRows" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" ResourceKey="valThumbRows.ErrorMessage" ControlToValidate="txtThumbRows" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Thumb Rows Must Be A Valid Integer" runat="server" />
        </div>
    </fieldset>
    <h2 id="pnlGrid" class="dnnFormSectionHead"><a href="#">Grid Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:Label id="plImagePosition" ControlName="ddlImagePosition" Suffix=":" runat="server" />
            <asp:DropDownList ID="ddlImagePosition" runat="server">
                <asp:ListItem Value="NL" ResourceKey="None" />
                <asp:ListItem Value="ZR" ResourceKey="ZigZagRight" />
                <asp:ListItem Value="ZL" ResourceKey="ZigZagLeft" />
                <asp:ListItem Value="AR" ResourceKey="AllRight" />
                <asp:ListItem Value="AL" ResourceKey="AllLeft" />
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plDeleteFromGrid" ControlName="chkDeleteFromGrid" Suffix=":" runat="server" />
            <asp:CheckBox ID="chkDeleteFromGrid" ResourceKey="DeleteFromGrid" TextAlign="Right" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plNoOfItems" ControlName="txtPagerSize" Suffix=":" runat="server" />
            <table>
                <tr>
                    <td>
                        <dnn:Label id="plPagerSize" ControlName="txtPagerSize" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtPagerSize" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valPagerSize" ResourceKey="valPagerSize.ErrorMessage" ControlToValidate="txtPagerSize" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Pager Size Must Be A Valid Integer" runat="server" /></td>
                    <td>
                        <dnn:Label id="plNoOfPages" ControlName="txtNoOfPages" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtNoOfPages" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valNoOfPages" ResourceKey="valNoOfPages.ErrorMessage" ControlToValidate="txtNoOfPages" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />No Of Pages Must Be A Valid Integer" runat="server" /></td>
                </tr>
            </table>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plHighLightColor" ControlName="txtHighLightColor" Suffix=":" runat="server" />
            <asp:TextBox ID="txtHighLightColor" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plGridCssClasses" ControlName="txtGridCss" Suffix=":" runat="server" />
            <table>
                <tr>
                    <td>
                        <dnn:Label id="plGridCss" ControlName="txtGridCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtGridCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plHeaderCss" ControlName="txtHeaderCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtHeaderCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plRowCss" ControlName="txtRowCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtRowCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plAltRowCss" ControlName="txtAltRowCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtAltRowCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plSelRowCss" ControlName="txtSelRowCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtSelRowCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plEditRowCss" ControlName="txtEditRowCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtEditRowCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plPagerCss" ControlName="txtPagerCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtPagerCss" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <dnn:Label id="plFooterCss" ControlName="txtFooterCss" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtFooterCss" runat="server" /></td>
                </tr>
            </table>
        </div>
        <%--
        <div class="dnnFormItem">
            <dnn:Label id="plBackColor" ControlName="txtBackColor" Suffix=":" runat="server" />
            <table>
                <tr>
                    <td><dnn:Label id="plItemBackColor" ControlName="txtBackColor" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtBackColor"  runat="server" /></td>
                </tr>
                <tr>
                    <td><dnn:Label id="plAltColor" ControlName="txtAltColor" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtAltColor"  runat="server" /></td>
                </tr>
                <tr>
                    <td><dnn:Label id="plSelectedColor" ControlName="txtSelectedColor" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtSelectedColor"  runat="server" /></td>
                </tr>
                <tr>
                    <td><dnn:Label id="plHeaderBackColor" ControlName="txtHeaderBackColor" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtHeaderBackColor"  runat="server" /></td>
                </tr>
                <tr>
                    <td><dnn:Label id="plPagerBackColor" ControlName="txtPagerBackColor" Suffix=":" runat="server" /></td>
                    <td><asp:TextBox ID="txtPagerBackColor"  runat="server" /></td>
                </tr>
            </table>
        </div>
        --%>
    </fieldset>
    <h2 id="pnlScroller" class="dnnFormSectionHead"><a href="#">Scroller Settings</a></h2>
    <fieldset class="dnnClear">
        <div class="dnnFormItem">
            <dnn:Label id="plScrollBehavior" runat="server" Suffix=":" ControlName="rblScrollBehavior" />
            <asp:RadioButtonList ID="rblScrollBehavior" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Off" ResourceKey="Off" />
                <asp:ListItem Value="Scroll" ResourceKey="Scroll" />
                <asp:ListItem Value="Slide" ResourceKey="Slide" />
                <asp:ListItem Value="Alternate" ResourceKey="Alternate" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plScrollDirection" Suffix=":" ControlName="rblScrollDirection" runat="server" />
            <asp:RadioButtonList ID="rblScrollDirection" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Value="Up" ResourceKey="Up" />
                <asp:ListItem Value="Down" ResourceKey="Down" />
                <asp:ListItem Value="Left" ResourceKey="Left" />
                <asp:ListItem Value="Right" ResourceKey="Right" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plScrollAmount" runat="server" Suffix=":" ControlName="txtScrollAmount" />
            <asp:TextBox ID="txtScrollAmount" runat="server" Columns="5" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plScrollDelay" runat="server" Suffix=":" ControlName="txtScrollDelay" />
            <asp:TextBox ID="txtScrollDelay" runat="server" Columns="5" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plScrollWidth" runat="server" Suffix=":" ControlName="txtScrollWidth" />
            <asp:TextBox ID="txtScrollWidth" runat="server" Columns="5" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label id="plScrollHeight" runat="server" Suffix=":" ControlName="txtScrollHeight" />
            <asp:TextBox ID="txtScrollHeight" runat="server" Columns="5" />
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