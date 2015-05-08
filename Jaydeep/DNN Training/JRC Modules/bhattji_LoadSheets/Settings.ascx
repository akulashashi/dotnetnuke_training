<%@ Control Language="vb" AutoEventWireup="False" CodeBehind="Settings.ascx.vb" Inherits="bhattji.Modules.LoadSheets.Settings" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="../../controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<table width="560" cellspacing="0" cellpadding="0" border="0" summary="Edit LoadSheets Settings Table">
    <tr>
        <td class="SubHead" width="150"></td>
        <td class="Normal" width="400"><asp:LinkButton ID="cmdSort" resourcekey="cmdSort" runat="server" CssClass="CommandButton" BorderStyle="none" />&nbsp; <asp:LinkButton ID="cmdFix" BorderStyle="none" CssClass="CommandButton" runat="server" resourcekey="cmdFix" />
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plGetItems" runat="server" ControlName="rblGetItems" Suffix=":" /></td>
        <td class="Normal">
            <asp:RadioButtonList ID="rblGetItems" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Value="0" resourcekey="Module" />
                <asp:ListItem Value="1" resourcekey="Portal" />
                <asp:ListItem Value="2" resourcekey="All" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plOnlyHostCanEdit" ControlName="chkOnlyHostCanEdit" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkOnlyHostCanEdit" resourcekey="OnlyHostCanEdit" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plViewControl" ControlName="rblViewControl" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:RadioButtonList ID="rblViewControl" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                <asp:ListItem Value="List" resourcekey="List" />
                <asp:ListItem Value="Xmission" resourcekey="Xmission" />
                <asp:ListItem Value="Report" resourcekey="Report" />
                <asp:ListItem Value="Grid" resourcekey="Grid" />
                <asp:ListItem Value="Thumbs" resourcekey="Thumbs" />
                <asp:ListItem Value="Tabs" resourcekey="Tabs" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plAsyncXmission" ControlName="chkAsyncXmission" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAsyncXmission" runat="server" resourcekey="AsyncXmission" CssClass="NormalTextBox" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plXmissionFileBackupFolder" ControlName="txtXmissionFileBackupFolder" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:TextBox ID="txtXmissionFileBackupFolder" CssClass="NormalTextBox" Width="300" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plTabCss" TabCssname="rblTabCss" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:RadioButtonList ID="rblTabCss" runat="server" CssClass="NormalTextBox" RepeatDirection="Horizontal">
                <asp:ListItem Value="tab.luna.css" resourcekey="Luna" />
                <asp:ListItem Value="tab.webfx.css" resourcekey="WinFx" />
                <asp:ListItem Value="tab.winclassic.css" resourcekey="Classic" />
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plTransition" runat="server" Suffix=":" ControlName="ddlTransition"></dnn:Label></td>
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
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plRattleImage" ControlName="chkRattleImage" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkRattleImage" resourcekey="RattleImage" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plAddDescription" ControlName="chkAddDescription" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:CheckBox ID="chkAddDescription" resourcekey="AddDescription" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plAddDate" ControlName="ddlAddDate" Suffix=":" runat="server" /></td>
        <td class="Normal">
            <asp:DropDownList ID="ddlAddDate" CssClass="NormalTextBox" runat="server">
                <asp:ListItem Value="N" resourcekey="None" />
                <asp:ListItem Value="A" resourcekey="After" />
                <asp:ListItem Value="B" resourcekey="Before" />
                <asp:ListItem Value="U" resourcekey="Above" />
                <asp:ListItem Value="D" resourcekey="Below" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plShowRatings" ControlName="chkShowRatings" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:CheckBox ID="chkShowRatings" resourcekey="ShowRatings" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plHideTextLink" ControlName="chkHideTextLink" Suffix=":" runat="server" /></td>
        <td class="Normal"><asp:CheckBox ID="chkHideTextLink" resourcekey="HideTextLink" TextAlign="Right" runat="server" /></td>
    </tr>
    <tr>
        <td class="SubHead"><dnn:Label ID="plUpdateRedirection" runat="server" Suffix=":" ControlName="ddlUpdateRedirection"></dnn:Label></td>
        <td class="Normal">
            <asp:DropDownList ID="ddlUpdateRedirection" CssClass="NormalTextBox" runat="server">
                <asp:ListItem Value="Listing" resourcekey="Listing" />
                <asp:ListItem Value="NewItem" resourcekey="NewItem" />
                <asp:ListItem Value="EditItem" resourcekey="EditItem" />
                <asp:ListItem Value="ItemDetails" resourcekey="ItemDetails" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead"></td>
        <td class="Normal"></td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:SectionHead ID="secThumbSettings" CssClass="Head" Section="tblThumbSettings" ResourceKey="secThumbSettings" IncludeRule="True" IsExpanded="false" runat="server" />
            <table id="tblThumbSettings" runat="server">
                <tr>
                    <td class="SubHead" valign="top"><dnn:Label ID="plDynamicThumb" ControlName="chkDynamicThumb" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkDynamicThumb" resourcekey="DynamicThumb" TextAlign="Right" runat="server" />
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plThumbWidth" ControlName="txtThumbWidth" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbWidth" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plThumbHeight" ControlName="txtThumbHeight" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbHeight" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plThumbColumns" ControlName="txtThumbColumns" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtThumbColumns" CssClass="NormalTextBox" Columns="5" runat="server" /> <asp:RegularExpressionValidator ID="valThumbColumns" resourcekey="valThumbColumns.ErrorMessage" ControlToValidate="txtThumbColumns" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Thumb Columns Must Be A Valid Integer" runat="server" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><br />
            <dnn:SectionHead ID="secGridSettings" CssClass="Head" Section="tblGridSettings" ResourceKey="secGridSettings" IncludeRule="True" IsExpanded="false" runat="server" />
            <table id="tblGridSettings" runat="server">
                <tr>
                    <td class="SubHead"><dnn:Label ID="plImagePosition" ControlName="ddlImagePosition" Suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <asp:DropDownList ID="ddlImagePosition" CssClass="NormalTextBox" runat="server">
                            <asp:ListItem Value="NL" resourcekey="None" />
                            <asp:ListItem Value="ZR" resourcekey="ZigZagRight" />
                            <asp:ListItem Value="ZL" resourcekey="ZigZagLeft" />
                            <asp:ListItem Value="AR" resourcekey="AllRight" />
                            <asp:ListItem Value="AL" resourcekey="AllLeft" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plDeleteFromGrid" ControlName="chkDeleteFromGrid" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkDeleteFromGrid" resourcekey="DeleteFromGrid" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plNoOfItems" ControlName="txtPagerSize" Suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="SubHead"><dnn:Label ID="plPagerSize" ControlName="txtPagerSize" Suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtPagerSize" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valPagerSize" resourcekey="valPagerSize.ErrorMessage" ControlToValidate="txtPagerSize" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />Pager Size Must Be A Valid Integer" runat="server" /></td>
                                <td class="SubHead"><dnn:Label ID="plNoOfPages" ControlName="txtNoOfPages" Suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtNoOfPages" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:RegularExpressionValidator ID="valNoOfPages" resourcekey="valNoOfPages.ErrorMessage" ControlToValidate="txtNoOfPages" ValidationExpression="^[0-9]+[0-9]*$" Display="Dynamic" CssClass="NormalRed" ErrorMessage="<br />No Of Pages Must Be A Valid Integer" runat="server" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plShowNoOfItems" ControlName="chkShowNoOfItems" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:CheckBox ID="chkShowNoOfItems" resourcekey="ShowNoOfItems" TextAlign="Right" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plrptNoOfItems" ControlName="txtrptNoOfItems" Suffix=":" runat="server" /></td>
                    <td class="Normal"><asp:TextBox ID="txtrptNoOfItems" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plBackColor" ControlName="txtBackColor" Suffix=":" runat="server" /></td>
                    <td class="Normal">
                        <table>
                            <tr>
                                <td class="SubHead"><dnn:Label ID="plItemBackColor" ControlName="txtBackColor" Suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtBackColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:Label ID="plAltColor" ControlName="txtAltColor" Suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtAltColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:Label ID="plHeaderBackColor" ControlName="txtHeaderBackColor" Suffix=":" runat="server" /></td>
                                <td class="Normal"><asp:TextBox ID="txtHeaderBackColor" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="SubHead"><dnn:Label ID="plPagerBackColor" ControlName="txtPagerBackColor" Suffix=":" runat="server" /></td>
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
            <dnn:SectionHead ID="secPayPalSettings" CssClass="Head" Section="tblPayPalSettings" ResourceKey="secPayPalSettings" IncludeRule="True" IsExpanded="false" runat="server" />
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
            <dnn:SectionHead ID="secScrollerSettings" CssClass="Head" Section="tblScrollerSettings" ResourceKey="secScrollerSettings" IncludeRule="True" IsExpanded="false" runat="server" />
            <table id="tblScrollerSettings" runat="server" summary="Edit Scroller Settings Table">
                <tr>
                    <td width="150"></td>
                    <td width="400"></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollBehavior" runat="server" Suffix=":" ControlName="rblScrollBehavior"></dnn:Label></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblScrollBehavior" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Off" resourcekey="Off" />
                            <asp:ListItem Value="Scroll" resourcekey="Scroll" />
                            <asp:ListItem Value="Slide" resourcekey="Slide" />
                            <asp:ListItem Value="Alternate" resourcekey="Alternate" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollDirection" Suffix=":" ControlName="rblScrollDirection" runat="server" /></td>
                    <td class="Normal">
                        <asp:RadioButtonList ID="rblScrollDirection" CssClass="NormalTextBox" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="Up" resourcekey="Up" />
                            <asp:ListItem Value="Down" resourcekey="Down" />
                            <asp:ListItem Value="Left" resourcekey="Left" />
                            <asp:ListItem Value="Right" resourcekey="Right" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollAmount" runat="server" Suffix=":" ControlName="txtScrollAmount"></dnn:Label></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollAmount" CssClass="NormalTextBox" runat="server" Columns="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollDelay" runat="server" Suffix=":" ControlName="txtScrollDelay"></dnn:Label></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollDelay" CssClass="NormalTextBox" runat="server" Columns="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollWidth" runat="server" Suffix=":" ControlName="txtScrollWidth"></dnn:Label></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollWidth" CssClass="NormalTextBox" runat="server" Columns="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="SubHead"><dnn:Label ID="plScrollHeight" runat="server" Suffix=":" ControlName="txtScrollHeight"></dnn:Label></td>
                    <td class="Normal"><asp:TextBox ID="txtScrollHeight" CssClass="NormalTextBox" runat="server" Columns="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="SubHead"></td>
                    <td class="Normal"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<p><asp:ImageButton ID="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />
<asp:LinkButton ID="cmdUpdate" resourcekey="cmdUpdate" CssClass="CommandButton" BorderStyle="none" runat="server" />&nbsp; <asp:ImageButton ID="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" />&nbsp; <asp:LinkButton ID="cmdCancel" resourcekey="cmdCancel" CssClass="CommandButton" BorderStyle="none" CausesValidation="False" runat="server" /></p>
<p><Portal:Audit ID="ctlAudit" runat="server" /></p>