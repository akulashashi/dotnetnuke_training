<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Settings.ascx.vb" Inherits="bhattji.Modules.InterOffices.Settings" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="../../controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<table width="560" cellspacing="0" cellpadding="0" border="0" summary="Edit InterOffices Settings Table">
	<tr>
		<td class="SubHead" width="150"></td>
		<td class="Normal" width="400">
		<asp:linkbutton id="cmdSort" resourcekey="cmdSort" runat="server" cssclass="CommandButton"  borderstyle="none" />&nbsp;
		<asp:linkbutton id="cmdFix" borderstyle="none"  cssclass="CommandButton" runat="server"
				resourcekey="cmdFix"></asp:linkbutton>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plGetItems" runat="server" Controlname="rblGetItems" suffix=":" /></td>
		<td class="Normal">
			<asp:radiobuttonlist id="rblGetItems" cssclass="NormalTextBox" repeatdirection="Horizontal" runat="server">
				<asp:listitem value="0" resourcekey="Module" />
				<asp:listitem value="1" resourcekey="Portal" />
				<asp:listitem value="2" resourcekey="All" />
			</asp:radiobuttonlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOnlyHostCanEdit" controlname="chkOnlyHostCanEdit" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:checkbox ID="chkOnlyHostCanEdit" resourcekey="OnlyHostCanEdit" TextAlign="Right" runat="server" /></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plViewControl" controlname="rblViewControl" suffix=":" runat="server" /></td>
		<td class="Normal">
			<asp:radiobuttonlist id="rblViewControl" runat="server" cssclass="NormalTextBox" repeatdirection="Horizontal">
				<asp:listitem value="List" resourcekey="List" />
				<asp:listitem value="Words" resourcekey="Words" />
			</asp:radiobuttonlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plTabCss" TabCssname="rblTabCss" suffix=":" runat="server" /></td>
		<td class="Normal">
			<asp:radiobuttonlist id="rblTabCss" runat="server" cssclass="NormalTextBox" repeatdirection="Horizontal">
				<asp:listitem value="tab.luna.css" resourcekey="Luna" />
				<asp:listitem value="tab.webfx.css" resourcekey="WinFx" />
				<asp:listitem value="tab.winclassic.css" resourcekey="Classic" />
			</asp:radiobuttonlist>
		</td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plTransition" runat="server" suffix=":" controlname="ddlTransition" /></td>
		<td class="Normal"><asp:dropdownlist id="ddlTransition" cssclass="NormalTextBox" runat="server">
				<asp:listitem value="" resourcekey="None" />
				<asp:listitem value="Barn" resourcekey="Barn" />
				<asp:listitem value="Blinds" resourcekey="Blinds" />
				<asp:listitem value="CheckerBoard" resourcekey="CheckerBoard" />
				<asp:listitem value="Fade" resourcekey="Fade" />
				<asp:listitem value="GradientWipe" resourcekey="GradientWipe" />
				<asp:listitem value="Inset" resourcekey="Inset" />
				<asp:listitem value="Iris" resourcekey="Iris" />
				<asp:listitem value="Pixelate" resourcekey="Pixelate" />
				<asp:listitem value="RadialWipe" resourcekey="RadialWipe" />
				<asp:listitem value="RandomBars" resourcekey="RandomBars" />
				<asp:listitem value="RandomDissolve" resourcekey="RandomDissolve" />
				<asp:listitem value="Slide" resourcekey="Slide" />
				<asp:listitem value="Spiral" resourcekey="Spiral" />
				<asp:listitem value="Stretch" resourcekey="Stretch" />
				<asp:listitem value="Strips" resourcekey="Strips" />
				<asp:listitem value="Wheel" resourcekey="Wheel" />
				<asp:listitem value="Zigzag" resourcekey="ZigZag" />
			</asp:dropdownlist></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRattleImage" controlname="chkRattleImage" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:checkbox ID="chkRattleImage" resourcekey="RattleImage" TextAlign="Right" runat="server" /></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plAddDescription" controlname="chkAddDescription" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:checkbox ID="chkAddDescription" resourcekey="AddDescription" TextAlign="Right" runat="server" /></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plAddDate" controlname="ddlAddDate" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:dropdownlist id="ddlAddDate" CssClass="NormalTextBox" Runat="server">
				<asp:listitem Value="N" resourcekey="None" />
				<asp:listitem Value="A" resourcekey="After" />
				<asp:listitem Value="B" resourcekey="Before" />
				<asp:listitem Value="U" resourcekey="Above" />
				<asp:listitem Value="D" resourcekey="Below" />
			</asp:dropdownlist></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plShowRatings" controlname="chkShowRatings" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:checkbox ID="chkShowRatings" resourcekey="ShowRatings" TextAlign="Right" runat="server" /></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plHideTextLink" controlname="chkHideTextLink" suffix=":" runat="server" /></td>
		<td class="Normal"><asp:checkbox ID="chkHideTextLink" resourcekey="HideTextLink" TextAlign="Right" runat="server" /></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plUpdateRedirection" runat="server" suffix=":" controlname="ddlUpdateRedirection" /></td>
		<td class="Normal"><asp:dropdownlist id="ddlUpdateRedirection" cssclass="NormalTextBox" runat="server">
				<asp:listitem value="Listing" resourcekey="Listing" />
				<asp:listitem value="NewItem" resourcekey="NewItem" />
				<asp:listitem value="EditItem" resourcekey="EditItem" />
				<asp:listitem value="ItemDetails" resourcekey="ItemDetails" />
			</asp:dropdownlist></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	
	
	<tr><td colspan="2"><br />
			<dnn:sectionhead id="secThumbSettings" cssclass="Head" section="tblThumbSettings" resourcekey="secThumbSettings" includerule="True" isExpanded="false" runat="server" />
			<table id="tblThumbSettings" runat="server">
	            <tr>
	                <td class="SubHead" valign="top"><dnn:label id="plDynamicThumb" controlname="chkDynamicThumb" suffix=":" runat="server" /></td>
	                <td class="Normal"><asp:checkbox ID="chkDynamicThumb" resourcekey="DynamicThumb" TextAlign="Right" runat="server" />
		      
	            </tr>
	            <tr>
		            <td class="SubHead"><dnn:label id="plThumbWidth" controlname="txtThumbWidth" suffix=":" runat="server" /></td>
		            <td class="Normal"><asp:textbox id="txtThumbWidth" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
	            </tr>
	            <tr>
		            <td class="SubHead"><dnn:label id="plThumbHeight" controlname="txtThumbHeight" suffix=":" runat="server" /></td>
		            <td class="Normal"><asp:textbox id="txtThumbHeight" CssClass="NormalTextBox" Columns="5" runat="server" /></td>
	            </tr>
	            <tr>
		            <td class="SubHead"><dnn:label id="plThumbColumns" controlname="txtThumbColumns" suffix=":" runat="server" /></td>
		            <td class="Normal"><asp:textbox id="txtThumbColumns" CssClass="NormalTextBox" Columns="5" runat="server" />
		                <asp:regularexpressionvalidator id="valThumbColumns" resourcekey="valThumbColumns.ErrorMessage" controltovalidate="txtThumbColumns" validationexpression="^[0-9]+[0-9]*$" display="Dynamic" CssClass="NormalRed" errormessage="<br />Thumb Columns Must Be A Valid Integer" runat="server" /></td>
	            </tr>
		    </table>
		</td>
	</tr>
	
	
	
	<tr>
		<td colspan="2"><br />
			<dnn:sectionhead id="secGridSettings" cssclass="Head" section="tblGridSettings" resourcekey="secGridSettings" includerule="True" isExpanded="false" runat="server" />
			<table id="tblGridSettings" runat="server">
            			
	            <tr>
		            <td class="SubHead"><dnn:label id="plImagePosition" controlname="ddlImagePosition" suffix=":" runat="server" /></td>
		            <td class="Normal"><asp:dropdownlist id="ddlImagePosition" CssClass="NormalTextBox" Runat="server">
				            <asp:listitem Value="NL" resourcekey="None" />
				            <asp:listitem Value="ZR" resourcekey="ZigZagRight" />
				            <asp:listitem Value="ZL" resourcekey="ZigZagLeft" />
				            <asp:listitem Value="AR" resourcekey="AllRight" />
				            <asp:listitem Value="AL" resourcekey="AllLeft" />
			            </asp:dropdownlist></td>
	            </tr>
			
	            <tr>
		            <td class="SubHead"><dnn:label id="plDeleteFromGrid" controlname="chkDeleteFromGrid" suffix=":" runat="server" /></td>
		            <td class="Normal"><asp:checkbox ID="chkDeleteFromGrid" resourcekey="DeleteFromGrid" TextAlign="Right" runat="server" /></td>
	            </tr>
            	            
	            <tr>
		            <td class="SubHead"><dnn:label id="plNoOfItems" controlname="txtPagerSize" suffix=":" runat="server" /></td>
		            <td class="Normal">
		                <table>
	                        <tr>
		                        <td class="SubHead"><dnn:label id="plPagerSize" controlname="txtPagerSize" suffix=":" runat="server" /></td>
		                        <td class="Normal"><asp:textbox id="txtPagerSize" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:regularexpressionvalidator id="valPagerSize" resourcekey="valPagerSize.ErrorMessage" controltovalidate="txtPagerSize" validationexpression="^[0-9]+[0-9]*$" display="Dynamic" CssClass="NormalRed" errormessage="<br />Pager Size Must Be A Valid Integer" runat="server" /></td>
	                        
		                        <td class="SubHead"><dnn:label id="plNoOfPages" controlname="txtNoOfPages" suffix=":" runat="server" /></td>
		                        <td class="Normal"><asp:textbox id="txtNoOfPages" CssClass="NormalTextBox" Columns="5" runat="server" /><asp:regularexpressionvalidator id="valNoOfPages" resourcekey="valNoOfPages.ErrorMessage" controltovalidate="txtNoOfPages" validationexpression="^[0-9]+[0-9]*$" display="Dynamic" CssClass="NormalRed" errormessage="<br />No Of Pages Must Be A Valid Integer" runat="server" /></td>
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
		                        <td class="Normal"><asp:textbox id="txtBackColor" CssClass="NormalTextBox" runat="server" /></td>
	                        </tr>
	                        <tr>
		                        <td class="SubHead"><dnn:label id="plAltColor" controlname="txtAltColor" suffix=":" runat="server" /></td>
		                        <td class="Normal"><asp:textbox id="txtAltColor" CssClass="NormalTextBox" runat="server" /></td>
	                        </tr>
	                        <tr>
		                        <td class="SubHead"><dnn:label id="plHeaderBackColor" controlname="txtHeaderBackColor" suffix=":" runat="server" /></td>
		                        <td class="Normal"><asp:textbox id="txtHeaderBackColor" CssClass="NormalTextBox" runat="server" /></td>
	                        </tr>
	                        <tr>
		                        <td class="SubHead"><dnn:label id="plPagerBackColor" controlname="txtPagerBackColor" suffix=":" runat="server" /></td>
		                        <td class="Normal"><asp:textbox id="txtPagerBackColor" CssClass="NormalTextBox" runat="server" /></td>
	                        </tr>
	                       	    
		                </table>
            		
		            </td>
	            </tr>
	            
	            		    
		    </table>
		
		</td>
	</tr>
	<tr>
	    <td colspan="2"><br />
	        <dnn:sectionhead id="secPayPalSettings" cssclass="Head" section="tblPayPalSettings" resourcekey="secPayPalSettings" includerule="True" isExpanded="false" runat="server" />
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
			<dnn:sectionhead id="secScrollerSettings" cssclass="Head" section="tblScrollerSettings" resourcekey="secScrollerSettings" includerule="True" isExpanded="false" runat="server" />
			<table id="tblScrollerSettings" runat="server" summary="Edit Scroller Settings Table">
				<tr>
					<td width="150"></td>
					<td width="400"></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollBehavior" runat="server" suffix=":" controlname="rblScrollBehavior" /></td>
					<td class="Normal"><asp:radiobuttonlist id="rblScrollBehavior" cssclass="NormalTextBox" runat="server" repeatdirection="Horizontal">
							<asp:listitem value="Off" resourcekey="Off" />
							<asp:listitem value="Scroll" resourcekey="Scroll" />
							<asp:listitem value="Slide" resourcekey="Slide" />
							<asp:listitem value="Alternate" resourcekey="Alternate" />
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollDirection" suffix=":" controlname="rblScrollDirection" runat="server" /></td>
					<td class="Normal"><asp:radiobuttonlist id="rblScrollDirection" cssclass="NormalTextBox" repeatdirection="Horizontal" runat="server">
							<asp:listitem value="Up" resourcekey="Up" />
							<asp:listitem value="Down" resourcekey="Down" />
							<asp:listitem value="Left" resourcekey="Left" />
							<asp:listitem value="Right" resourcekey="Right" />
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollAmount" runat="server" suffix=":" controlname="txtScrollAmount" /></td>
					<td class="Normal"><asp:textbox id="txtScrollAmount" cssclass="NormalTextBox" runat="server" columns="5"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollDelay" runat="server" suffix=":" controlname="txtScrollDelay" /></td>
					<td class="Normal"><asp:textbox id="txtScrollDelay" cssclass="NormalTextBox" runat="server" columns="5"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollWidth" runat="server" suffix=":" controlname="txtScrollWidth" /></td>
					<td class="Normal"><asp:textbox id="txtScrollWidth" cssclass="NormalTextBox" runat="server" columns="5"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead"><dnn:label id="plScrollHeight" runat="server" suffix=":" controlname="txtScrollHeight" /></td>
					<td class="Normal"><asp:textbox id="txtScrollHeight" cssclass="NormalTextBox" runat="server" columns="5"></asp:textbox></td>
				</tr>
				<tr>
					<td class="SubHead"></td>
					<td class="Normal"></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<p><asp:imagebutton id="imbUpdate" ImageUrl="~/images/save.gif" resourcekey="cmdUpdate" cssclass="CommandButton" borderstyle="none" runat="server" />
	<asp:linkbutton id="cmdUpdate" resourcekey="cmdUpdate" cssclass="CommandButton" borderstyle="none" runat="server" />&nbsp;
	<asp:imagebutton id="imbCancel" ImageUrl="~/images/lt.gif" resourcekey="cmdCancel" cssclass="CommandButton" borderstyle="none" causesvalidation="False" runat="server" />&nbsp;
	<asp:linkbutton id="cmdCancel" resourcekey="cmdCancel" cssclass="CommandButton" borderstyle="none" causesvalidation="False" runat="server" /></p>
<p><portal:audit id="ctlAudit" runat="server" /></p>