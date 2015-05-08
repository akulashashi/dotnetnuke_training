<%@ Control Language="c#" AutoEventWireup="true" Codebehind="Settings.ascx.cs" Inherits="bhattji.Modules.SalesReps.Settings" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="../../controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<table width="560" cellspacing="0" cellpadding="0" border="0" summary="Edit SalesReps Settings Table">
    <tr>
        <td class="SubHead" width="150"></td>
        <td class="Normal" width="400"></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:label id="plOnlyHostCanEdit" controlname="chkOnlyHostCanEdit" suffix=":" runat="server" /></td>
        <td class="Normal"><asp:CheckBox ID="chkOnlyHostCanEdit" resourcekey="OnlyHostCanEdit" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secScopeSettings" cssclass="Head" section="tblScopeSettings" resourcekey="secScopeSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblScopeSettings" runat="server">
                <tr>
                    <td class="SubHead"><dnn:label id="plItemsScope" runat="server" controlname="rblItemsScope" suffix=":" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="Normal">
                                    <asp:RadioButtonList ID="rblItemsScope" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="0" resourcekey="Module" />
                                        <asp:ListItem Value="1" resourcekey="Portal" />
                                        <asp:ListItem Value="2" resourcekey="All" />
                                    </asp:RadioButtonList></td>
                                <td class="Normal"><asp:LinkButton ID="cmdClaimOrphan" resourcekey="cmdClaimOrphan" runat="server" CssClass="CommandButton" BorderStyle="none" /></td>
                                <td class="Normal"><asp:LinkButton ID="cmdSetViewOrder" resourcekey="cmdSetViewOrder" runat="server" CssClass="CommandButton" BorderStyle="none" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plCategoriesScope" runat="server" controlname="rblCategoriesScope" suffix=":" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="Normal">
                                    <asp:RadioButtonList ID="rblCategoriesScope" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="0" resourcekey="Module" />
                                        <asp:ListItem Value="1" resourcekey="Portal" />
                                        <asp:ListItem Value="2" resourcekey="All" />
                                    </asp:RadioButtonList></td>
                                <td class="Normal"><asp:LinkButton ID="cmdClaimOrphanCat" resourcekey="cmdClaimOrphan" runat="server" CssClass="CommandButton" BorderStyle="none" /></td>
                                <td class="Normal"><asp:LinkButton ID="cmdSetViewOrderCat" resourcekey="cmdSetViewOrder" runat="server" CssClass="CommandButton" BorderStyle="none" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secUsabilitySettings" cssclass="Head" section="tblUsabilitySettings" resourcekey="secUsabilitySettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblUsabilitySettings" runat="server">
                <tr>
                    <td class="SubHead"><dnn:label id="plViewControl" controlname="rblViewControl" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblViewControl" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                            <asp:ListItem Value="List" resourcekey="List" />
                            <asp:ListItem Value="Catalog" resourcekey="Catalog" />
                            <asp:ListItem Value="Grid" resourcekey="Grid" />
                            <asp:ListItem Value="Thumbs" resourcekey="Thumbs" />
                            <asp:ListItem Value="Jukes" resourcekey="Jukes" />
                            <asp:ListItem Value="Tabs" resourcekey="Tabs" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plHideSearch" controlname="chkHideSearch" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkHideSearch" resourcekey="HideSearch" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plTabCss" tabcssname="rblTabCss" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblTabCss" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                            <asp:ListItem Value="tab.luna.css" resourcekey="Luna" />
                            <asp:ListItem Value="tab.webfx.css" resourcekey="WinFx" />
                            <asp:ListItem Value="tab.winclassic.css" resourcekey="Classic" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plTransition" runat="server" suffix=":" controlname="ddlTransition" /></td>
                    <td class="Normal">
                        <asp:DropDownList ID="ddlTransition" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="" resourcekey="None" />
                            <asp:ListItem Value="Barn" resourcekey="Barn" />
                            <asp:ListItem Value="Blinds" resourcekey="Blinds" />
                            <asp:ListItem Value="CheckerBoard" resourcekey="CheckerBoard" />
                            <asp:ListItem Value="Fade" resourcekey="Fade" />
                            <asp:ListItem Value="GradientWipe" resourcekey="GradientWipe" />
                            <asp:ListItem Value="Inset" resourcekey="Inset" />
                            <asp:ListItem Value="Iris" resourcekey="Iris" />
                            <asp:ListItem Value="Pixelate" resourcekey="Pixelate" />
                            <asp:ListItem Value="RadialWipe" resourcekey="RadialWipe" />
                            <asp:ListItem Value="RandomBars" resourcekey="RandomBars" />
                            <asp:ListItem Value="RandomDissolve" resourcekey="RandomDissolve" />
                            <asp:ListItem Value="Slide" resourcekey="Slide" />
                            <asp:ListItem Value="Spiral" resourcekey="Spiral" />
                            <asp:ListItem Value="Stretch" resourcekey="Stretch" />
                            <asp:ListItem Value="Strips" resourcekey="Strips" />
                            <asp:ListItem Value="Wheel" resourcekey="Wheel" />
                            <asp:ListItem Value="Zigzag" resourcekey="ZigZag" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plRattleImage" controlname="chkRattleImage" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkRattleImage" resourcekey="RattleImage" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plAddDescription" controlname="chkAddDescription" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkAddDescription" resourcekey="AddDescription" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plAddDate" controlname="ddlAddDate" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:DropDownList ID="ddlAddDate" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="N" resourcekey="None" />
                            <asp:ListItem Value="A" resourcekey="After" />
                            <asp:ListItem Value="B" resourcekey="Before" />
                            <asp:ListItem Value="U" resourcekey="Above" />
                            <asp:ListItem Value="D" resourcekey="Below" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plShowRatings" controlname="chkShowRatings" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkShowRatings" resourcekey="ShowRatings" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plHideTextLink" controlname="chkHideTextLink" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkHideTextLink" resourcekey="HideTextLink" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plUpdateRedirection" runat="server" suffix=":" controlname="ddlUpdateRedirection" /></td>
                    <td class="Normal">
                        <asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="Listing" resourcekey="Listing" />
                            <asp:ListItem Value="NewItem" resourcekey="NewItem" />
                            <asp:ListItem Value="EditItem" resourcekey="EditItem" />
                            <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secThumbSettings" cssclass="Head" section="tblThumbSettings" resourcekey="secThumbSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblThumbSettings" runat="server">
                <tr>
                    <td class="SubHead" valign="top"><dnn:label id="plDynamicThumb" controlname="chkDynamicThumb" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkDynamicThumb" resourcekey="DynamicThumb" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plThumbWidth" controlname="txtThumbWidth" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbWidth" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plThumbHeight" controlname="txtThumbHeight" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbHeight" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plThumbColumns" controlname="txtThumbColumns" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbColumns" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valThumbColumns" resourcekey="valThumbColumns.ErrorMessage" ControlToValidate="txtThumbColumns" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Thumb Columns Must Be A Valid Integer" runat="server" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secGridSettings" cssclass="Head" section="tblGridSettings" resourcekey="secGridSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblGridSettings" runat="server">
                <tr>
                    <td class="SubHead"><dnn:label id="plImagePosition" controlname="ddlImagePosition" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:DropDownList ID="ddlImagePosition" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="NL" resourcekey="None" />
                            <asp:ListItem Value="ZR" resourcekey="ZigZagRight" />
                            <asp:ListItem Value="ZL" resourcekey="ZigZagLeft" />
                            <asp:ListItem Value="AR" resourcekey="AllRight" />
                            <asp:ListItem Value="AL" resourcekey="AllLeft" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plDeleteFromGrid" controlname="chkDeleteFromGrid" suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkDeleteFromGrid" resourcekey="DeleteFromGrid" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plNoOfItems" controlname="txtPagerSize" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="SubHead"><dnn:label id="plPagerSize" controlname="txtPagerSize" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtPagerSize" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valPagerSize" resourcekey="valPagerSize.ErrorMessage" ControlToValidate="txtPagerSize" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Pager Size Must Be A Valid Integer" runat="server" /></td>
                                <td class="SubHead"><dnn:label id="plNoOfPages" controlname="txtNoOfPages" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtNoOfPages" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valNoOfPages" resourcekey="valNoOfPages.ErrorMessage" ControlToValidate="txtNoOfPages" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />No Of Pages Must Be A Valid Integer" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plBackColor" controlname="txtBackColor" suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="SubHead"><dnn:label id="plItemBackColor" controlname="txtBackColor" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtBackColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:label id="plAltColor" controlname="txtAltColor" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtAltColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:label id="plSelectedColor" controlname="txtSelectedColor" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtSelectedColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:label id="plHeaderBackColor" controlname="txtHeaderBackColor" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtHeaderBackColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:label id="plPagerBackColor" controlname="txtPagerBackColor" suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtPagerBackColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secPayPalSettings" cssclass="Head" section="tblPayPalSettings" resourcekey="secPayPalSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblPayPalSettings" runat="server" summary="Edit PayPal Settings Table">
                <tr>
                    <td width="150"></td>
                    <td width="400"></td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:sectionhead id="secScrollerSettings" cssclass="Head" section="tblScrollerSettings" resourcekey="secScrollerSettings" includerule="True" isexpanded="false" runat="server" />
            <table id="tblScrollerSettings" runat="server" summary="Edit Scroller Settings Table">
                <tr>
                    <td width="150"></td>
                    <td width="400"></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollBehavior" runat="server" suffix=":" controlname="rblScrollBehavior" /></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblScrollBehavior" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Off" resourcekey="Off" />
                            <asp:ListItem Value="Scroll" resourcekey="Scroll" />
                            <asp:ListItem Value="Slide" resourcekey="Slide" />
                            <asp:ListItem Value="Alternate" resourcekey="Alternate" />
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollDirection" suffix=":" controlname="rblScrollDirection" runat="server" /></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblScrollDirection" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="Up" resourcekey="Up" />
                            <asp:ListItem Value="Down" resourcekey="Down" />
                            <asp:ListItem Value="Left" resourcekey="Left" />
                            <asp:ListItem Value="Right" resourcekey="Right" />
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollAmount" runat="server" suffix=":" controlname="txtScrollAmount" /></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollAmount" CssClass="NormalTextBox" runat="server" Columns="5"/></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollDelay" runat="server" suffix=":" controlname="txtScrollDelay" /></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollDelay" CssClass="NormalTextBox" runat="server" Columns="5" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollWidth" runat="server" suffix=":" controlname="txtScrollWidth" /></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollWidth" CssClass="NormalTextBox" runat="server" Columns="5" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:label id="plScrollHeight" runat="server" suffix=":" controlname="txtScrollHeight" /></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollHeight" CssClass="NormalTextBox" runat="server" Columns="5" /></td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<center>
    <table id="tblButtons" style="text-align: center" runat="server">
        <tr>
            <td class="SubHead" align="center" valign="bottom">
                <asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                <asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
            </td>
            <td class="SubHead" align="center" valign="bottom">
                <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /><br />
                <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />
            </td>
        </tr>
    </table>
</center>
<p><portal:audit id="ctlAudit" runat="server" /></p>