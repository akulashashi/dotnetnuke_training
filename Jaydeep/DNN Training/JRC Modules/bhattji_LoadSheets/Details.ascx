<%@ Control Language="VB" AutoEventWireup="False" Codebehind="Details.ascx.vb" Inherits="bhattji.Modules.LoadSheets.Details" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>


<table id="tblLoads" cellSpacing="1" cellPadding="1" border="0">
	<tr>
		<td>
			<table id="Table9" cellSpacing="1" cellPadding="1" border="0">
				<tr>
					<td vAlign="top">
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; Customer &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colSpan="2">
									<table>
										<tr>
											<td class="SUBHEAD"><dnn:label id="plCustomerName" controlname="txtCustomerName" suffix=":" CssClass="SubHead"
													runat="server"></dnn:label></td>
											<td><asp:label id="txtCustomerName" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD"><dnn:label id="plCustomerNumber" controlname="ddlCustomerNumber" suffix=":" CssClass="SubHead"
													runat="server"></dnn:label></td>
											<td><asp:label id="ddlCustomerNumber" CssClass="Normallabel" runat="server" AutoPostBack="True"></asp:label>
											<asp:label id="lblCustomer" CssClass="NormalBold" runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plCustPO" controlname="txtCustPO" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="txtCustPO" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd" width="12"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colSpan="2"></td>
								<td class="jrcbottomrighttd" width="12"></td>
							</tr>
						</table>
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; Sales Representative &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colspan="2">
									<table id="Table14">
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plRepNo" runat="server" CssClass="SubHead" suffix=":" controlname="ddlRepNo"></dnn:label></td>
											<td>
												<asp:label id="ddlRepNo" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td>
												<asp:label id="txtRepDlrStd" runat="server" CssClass="Normallabel" Width="100"></asp:label></td>
											<td>
												<asp:label id="txtRepPctStd" runat="server" CssClass="Normallabel" Width="100"></asp:label></td>
										</tr>
										<tr>
											<td>
												<asp:label id="txtRepDlrM" runat="server" CssClass="Normallabel" Width="100"></asp:label></td>
											<td>
												<asp:label id="txtRepPctM" runat="server" CssClass="Normallabel" Width="100"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colspan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
						<table class="jrcskintable" id="tblDriver" cellSpacing="0" cellPadding="0" border="0" runat="server">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; DriverInfo &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colspan="2">
									<table id="Table13">
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plDriverCode" runat="server" CssClass="SubHead" suffix=":" controlname="ddlDriverCode"></dnn:label></td>
											<td>
												<asp:label id="ddlDriverCode" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plDriverName" runat="server" CssClass="SubHead" suffix=":" controlname="txtDriverName"></dnn:label></td>
											<td>
												<asp:label id="txtDriverName" runat="server" CssClass="Normallabel" Width="128px"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plAdminExempt" runat="server" CssClass="SubHead" suffix=":" controlname="chkAdminExempt"></dnn:label></td>
											<td>
												<asp:Image id="imgAdminExempt" CssClass="Normal" Runat="server" resourcekey="imgAdminExempt"></asp:Image></td>
										</tr>
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plOverrideComm" runat="server" CssClass="SubHead" suffix=":" controlname="txtOverrideComm"></dnn:label></td>
											<td>
												<asp:label id="txtOverrideComm" runat="server" CssClass="Normallabel" Width="127px"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colspan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
						<p>
							<table class="jrcskintable" id="tblInterOffice" cellSpacing="0" cellPadding="0" border="0"
								runat="server">
								<tr>
									<td class="jrctoplefttd"></td>
									<td class="jrctitletd"><span class="jrctitletext">&nbsp;
                  InnerOffice &nbsp;</span></td>
									<td class="jrctopslide"></td>
									<td class="jrctoprighttd"></td>
								</tr>
								<tr>
									<td class="jrcleftslidetd"></td>
									<td colspan="2">
										<table cellspacing="1" cellpadding="1" width="100%" border="0">
											<tr>
												<td class="SubHead">
													<dnn:label id="plIOCode" runat="server" CssClass="SubHead" suffix=":" controlname="ddlIOCode"></dnn:label></td>
												<td class="Normal">
													<asp:label id="ddlIOCode" runat="server" CssClass="Normallabel"></asp:label></td>
											</tr>
											<tr>
												<td class="SubHead">
													<dnn:label id="plOfficeCode" runat="server" CssClass="SubHead" suffix=":" controlname="txtOfficeCode"></dnn:label></td>
												<td>
													<asp:label id="txtOfficeCode" runat="server" CssClass="Normallabel" Width="116px"></asp:label></td>
											</tr>
										</table>
									</td>
									<td class="jrcrightslidetd"></td>
								</tr>
								<tr>
									<td class="jrcbottomlefttd"></td>
									<td class="jrcbottomslide" colspan="2"></td>
									<td class="jrcbottomrighttd"></td>
								</tr>
							</table>
							<table class="jrcskintable" id="tblBroker" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td class="jrctoplefttd"></td>
									<td class="jrctitletd"><span class="jrctitletext">&nbsp;
                  BrokerInfo &nbsp;</span></td>
									<td class="jrctopslide"></td>
									<td class="jrctoprighttd"></td>
								</tr>
								<tr>
									<td class="jrcleftslidetd"></td>
									<td colspan="2">
										<table id="Table12">
											<tr>
												<td class="SubHead">
													<dnn:label id="plBrokerName" runat="server" CssClass="SubHead" suffix=":" controlname="txtBrokerName"></dnn:label></td>
												<td class="Normal">
													<asp:label id="txtBrokerName" runat="server" CssClass="Normallabel"></asp:label>
													</td>
											</tr>
											<tr>
												<td class="SUBHEAD" height="21">
													<dnn:label id="plBrokerCode" runat="server" CssClass="SubHead" suffix=":" controlname="ddlBrokerCode"></dnn:label></td>
												<td height="21">
													<asp:label id="ddlBrokerCode" runat="server" CssClass="Normallabel"></asp:label></td>
											</tr>
										</table>
									</td>
									<td class="jrcrightslidetd"></td>
								</tr>
								<tr>
									<td class="jrcbottomlefttd"></td>
									<td class="jrcbottomslide" colspan="2"></td>
									<td class="jrcbottomrighttd"></td>
								</tr>
							</table>
						</p>
					</td>
					<td vAlign="top">
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; LoadSheet &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd" width="23"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd" height="90"></td>
								<td colSpan="2" height="90">
									<table id="Table11">
										<tr>
											<td class="SubHead"><dnn:label id="plLoadType" controlname="ddlLoadType" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:radiobuttonlist id="rblLoadType" CssClass="Normallabel" Runat="server" RepeatDirection="Vertical"
													AutoPostBack="True">
													<asp:listitem Value="OO" Text="Driver" resourcekey="OO" />
													<asp:listitem Value="IO" Text="InterOffice" resourcekey="IO" />
													<asp:listitem Value="BK" Text="Broker" resourcekey="BK" />
												</asp:radiobuttonlist></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plLoadID" controlname="txtLoadID" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="txtLoadID" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD"><dnn:label id="plLoadDate" controlname="txtLoadDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td noWrap><asp:label id="txtLoadDate" CssClass="Normallabel" runat="server" Width="100"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD"><dnn:label id="plDeliveryDate" controlname="txtDeliveryDate" suffix=":" CssClass="SubHead"
													runat="server"></dnn:label></td>
											<td><asp:label id="txtDeliveryDate" CssClass="Normallabel" runat="server" Width="100"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plLoadStatus" controlname="ddlLoadStatus" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="ddlLoadStatus" CssClass="Normallabel" runat="server">

												</asp:label></td>
										</tr>
									</table>
								<td class="jrcrightslidetd" width="23" height="90"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd" height="19"></td>
								<td class="jrcbottomslide" colSpan="2" height="19"></td>
								<td class="jrcbottomrighttd" width="23" height="19"></td>
							</tr>
						</table>
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; Alert
                  &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd" height="91"></td>
								<td colSpan="2" height="91">
									<table id="Table10">
										<tr>
											<td class="SUBHEAD"><dnn:label id="plIsPrinted" controlname="chkIsPrinted" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td><asp:Image id="imgIsPrinted" CssClass="Normal" Runat="server" resourcekey="imgIsPrinted"/></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plInvCommentA" controlname="txtInvCommentA" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="txtInvCommentA" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plInvCommentB" controlname="txtInvCommentB" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="txtInvCommentB" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="SUBHEAD"><dnn:label id="plInvCommentC" controlname="txtInvCommentC" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td><asp:label id="txtInvCommentC" CssClass="Normallabel" runat="server" Width="118px"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead"><dnn:label id="plInvCommentD" controlname="txtInvCommentD" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
											<td class="Normal"><asp:label id="txtInvCommentD" CssClass="Normallabel" runat="server"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd" height="91"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colSpan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp;
                  Exclusions &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colspan="2">
									<table id="Table7" cellspacing="1" cellpadding="1" width="100%" border="0">
										<tr>
											<td class="SubHead">
												<dnn:label id="plTarpLoad" runat="server" CssClass="SubHead" suffix=":" controlname="chkTarpLoad"></dnn:label></td>
											<td>
												<asp:Image id="imgTarpLoad" CssClass="Normal" Runat="server" resourcekey="imgTarpLoad"></asp:Image></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colspan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; LoadNote
                  &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colspan="2">
									<table id="Table6" height="69">
										<tr>
											<td class="SUBHEAD">
												<dnn:label id="plLoadNotes" runat="server" CssClass="SubHead" suffix=":" controlname="txtLoadNotes"></dnn:label></td>
											<td>
												<asp:label id="txtLoadNotes" runat="server" CssClass="Normallabel" TextMode="MultiLine"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead">
												<dnn:label id="plLDNotesA" runat="server" CssClass="SubHead" suffix=":" controlname="txtLDNotesA"></dnn:label></td>
											<td class="Normal">
												<asp:label id="txtLDNotesA" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead">
												<dnn:label id="plLDNotesB" runat="server" CssClass="SubHead" suffix=":" controlname="txtLDNotesB"></dnn:label></td>
											<td class="Normal">
												<asp:label id="txtLDNotesB" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead">
												<dnn:label id="plLDNotesC" runat="server" CssClass="SubHead" suffix=":" controlname="txtLDNotesC"></dnn:label></td>
											<td class="Normal">
												<asp:label id="txtLDNotesC" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td class="SubHead">
												<dnn:label id="plLDNotesD" runat="server" CssClass="SubHead" suffix=":" controlname="txtLDNotesD"></dnn:label></td>
											<td class="Normal">
												<asp:label id="txtLDNotesD" runat="server" CssClass="Normallabel"></asp:label></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
										</tr>
									</table>
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colspan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
		</td>
	</tr>
	<tr>
		<td nowrap>
			<table cellSpacing="1" cellPadding="1" border="0" width="100%">
				<tr>
					<td vAlign="top">
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; Load Pickups &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colSpan="2">
									<asp:placeholder ID="phtLoadPUs" Runat="server" />
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colSpan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="right">
						<table class="jrcskintable" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="jrctoplefttd"></td>
								<td class="jrctitletd"><span class="jrctitletext">&nbsp; LoadDrops &nbsp;</span></td>
								<td class="jrctopslide"></td>
								<td class="jrctoprighttd"></td>
							</tr>
							<tr>
								<td class="jrcleftslidetd"></td>
								<td colSpan="2">
									<asp:placeholder ID="phtLoadDrops" Runat="server" />
								</td>
								<td class="jrcrightslidetd"></td>
							</tr>
							<tr>
								<td class="jrcbottomlefttd"></td>
								<td class="jrcbottomslide" colSpan="2"></td>
								<td class="jrcbottomrighttd"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>



<p>
    <asp:HyperLink id="hypImgEdit" ImageUrl="~/images/edit.gif" resourcekey="Edit" cssclass="CommandButton" runat="server" Visible="false" />
    <asp:HyperLink id="hypEdit" resourcekey="Edit" cssclass="CommandButton" runat="server" Visible="false" />&nbsp;
    <asp:HyperLink id="hypImgClose" ImageUrl="~/images/lt.gif" resourcekey="Close" cssclass="CommandButton" runat="server" />
    <asp:HyperLink id="hypClose" resourcekey="Close" cssclass="CommandButton" runat="server" />
</p>
<p><portal:audit id="ctlAudit" runat="server" /></p>
<p><portal:tracking id="ctlTracking" runat="server" /></p>


<table id="tblLoadSheetEdit" style="DISPLAY: none">
	<tr>
		<td class="SubHead"><dnn:label id="plOfficeVendorNO" controlname="txtOfficeVendorNO" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtOfficeVendorNO" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plJRCIOfficeCode" controlname="txtJRCIOfficeCode" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtJRCIOfficeCode" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCompletedLoad" controlname="chkCompletedLoad" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkCompletedLoad" CssClass="Normal" Runat="server" resourcekey="chkCompletedLoad"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCompletedDate" controlname="txtCompletedDate" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtCompletedDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarCompletedDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plTrailerNumber" controlname="txtTrailerNumber" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtTrailerNumber" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plJRCIOCode" controlname="txtJRCIOCode" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtJRCIOCode" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plIOName" controlname="txtIOName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtIOName" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDriverPct" controlname="txtDriverPct" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDriverPct" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plFOB" controlname="txtFOB" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtFOB" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead">&nbsp;</td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plComCheckSeq" controlname="txtComCheckSeq" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtComCheckSeq" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plComCheckAmt" controlname="txtComCheckAmt" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtComCheckAmt" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plTarpMessage" controlname="txtTarpMessage" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtTarpMessage" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDispatchCode" controlname="txtDispatchCode" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDispatchCode" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDispName" controlname="txtDispName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDispName" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDispOverride" controlname="txtDispOverride" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDispOverride" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRepName" controlname="txtRepName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtRepName" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLastUpdate" controlname="txtLastUpdate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtLastUpdate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalenderLastUpdate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plXmissionSeq" controlname="txtXmissionSeq" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtXmissionSeq" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDriverComm" controlname="txtDriverComm" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDriverComm" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBrokerComm" controlname="txtBrokerComm" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBrokerComm" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLoadWeight" controlname="txtLoadWeight" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtLoadWeight" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLoadPieces" controlname="txtLoadPieces" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtLoadPieces" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLoadMileage" controlname="txtLoadMileage" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtLoadMileage" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plProNox" controlname="txtProNox" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtProNox" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plXMissionFile" controlname="txtXMissionFile" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtXMissionFile" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plXMissionDate" controlname="txtXMissionDate" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtXMissionDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarXMissionDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plEntryDate" controlname="txtEntryDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtEntryDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarEntryDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead" height="28"><dnn:label id="plRepDlrM" controlname="txtRepDlrM" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal" height="28"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRepPctM" controlname="txtRepPctM" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRepOverride" controlname="txtRepOverride" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtRepOverride" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRepDlrStd" controlname="txtRepDlrStd" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plRepPctStd" controlname="txtRepPctStd" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCorpTo" controlname="txtCorpTo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtCorpTo" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plTrailerType" controlname="txtTrailerType" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtTrailerType" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBrokerType" controlname="ddlBrokerType" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:label id="ddlBrokerType" CssClass="NormalTextBox" Runat="server" RepeatDirection="Horizontal">

			</asp:label></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOfficePaid" controlname="chkOfficePaid" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkOfficePaid" CssClass="Normal" Runat="server" resourcekey="chkOfficePaid"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPDCkNo" controlname="txtPDCkNo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPDCkNo" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPDDate" controlname="txtPDDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPDDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarPDDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPDAmt" controlname="txtPDAmt" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPDAmt" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plProJob" controlname="txtProJob" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtProJob" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBkrInvNo" controlname="txtBkrInvNo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBkrInvNo" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plReasonFor" controlname="txtReasonFor" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtReasonFor" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBkrInvDate" controlname="txtBkrInvDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBkrInvDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarBkrInvDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plIOAvail" controlname="chkIOAvail" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkIOAvail" CssClass="Normal" Runat="server" resourcekey="chkIOAvail"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plAcctNull" controlname="txtAcctNull" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtAcctNull" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBkrFunds" controlname="chkBkrFunds" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkBkrFunds" CssClass="Normal" Runat="server" resourcekey="chkBkrFunds"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOffFunds" controlname="chkOffFunds" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkOffFunds" CssClass="Normal" Runat="server" resourcekey="chkOffFunds"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOffOrgin" controlname="chkOffOrgin" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkOffOrgin" CssClass="Normal" Runat="server" resourcekey="chkOffOrgin"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCNOfficeVendorNO" controlname="txtCNOfficeVendorNO" suffix=":" CssClass="SubHead"
				runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtCNOfficeVendorNO" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPUSEQ" controlname="txtPUSEQ" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPUSEQ" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPUCityST" controlname="txtPUCityST" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPUCityST" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDPCityST" controlname="txtDPCityST" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDPCityST" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDPSEQ" controlname="txtDPSEQ" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDPSEQ" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plIsIODiv" controlname="chkIsIODiv" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkIsIODiv" CssClass="Normal" Runat="server" resourcekey="chkIsIODiv"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOLPUDate" controlname="txtOLPUDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtOLPUDate" CssClass="NormalTextBox" runat="server"></asp:textbox><asp:hyperlink id="cmdCalendarOLPUDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plOLNoStops" controlname="txtOLNoStops" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtOLNoStops" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCarrierName" controlname="txtCarrierName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtCarrierName" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBkrIOName" controlname="txtBkrIOName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBkrIOName" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBkrDriverNo" controlname="txtBkrDriverNo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBkrDriverNo" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBKDriver" controlname="txtBKDriver" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBKDriver" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCommPaid" controlname="chkCommPaid" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkCommPaid" CssClass="Normal" Runat="server" resourcekey="chkCommPaid"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLoadMo" controlname="ddlLoadMo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:label id="ddlLoadMo" CssClass="NormalTextBox" Runat="server" RepeatDirection="Horizontal">

			</asp:label><asp:label id="ddlLoadYR" CssClass="NormalTextBox" Runat="server" RepeatDirection="Horizontal">

			</asp:label></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plLoadYR" controlname="ddlLoadYR" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plCalc85" controlname="chkCalc85" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:checkbox id="chkCalc85" CssClass="Normal" Runat="server" resourcekey="chkCalc85"></asp:checkbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDvrDedPct" controlname="txtDvrDedPct" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDvrDedPct" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDvrDedResn" controlname="txtDvrDedResn" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtDvrDedResn" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plViewOrder" controlname="txtViewOrder" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtViewOrder" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal">&nbsp;
		</td>
	</tr>
	<tr>
		<td colSpan="2">&nbsp;
		</td>
	</tr>
</table>

<table id="tblLoadPUEdit" style="DISPLAY: none" cellSpacing="1" cellPadding="1">
<tr>
	<dnn:label id="plSeq" controlname="txtSeq" suffix=":" CssClass="SubHead" runat="server"></dnn:label>
	</tr>
	<tr>
		<td class="Normal"><asp:textbox id="txtSeq" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPRONo" controlname="txtPRONo" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtPRONo" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plPUState" controlname="txtPUState" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td colSpan="2"></td>
	</tr>
</table>

<table id="tblLoadDropEdit" style="DISPLAY: none" cellSpacing="1" cellPadding="1">
<tr>
	<dnn:label id="plSeqLoadDrop" controlname="txtSeqLoadDrop" suffix=":" CssClass="SubHead" runat="server"></dnn:label></tr>
	<tr>
		<td class="Normal"><asp:textbox id="txtSeqLoadDrop" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plDPState" controlname="txtDPState" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plJobno" controlname="txtJobno" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtJobno" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBillOLay" controlname="txtBillOLay" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBillOLay" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plBOLSeq" controlname="txtBOLSeq" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"><asp:textbox id="txtBOLSeq" CssClass="NormalTextBox" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SubHead"></td>
		<td class="Normal"></td>
	</tr>
	<tr>
		<td class="SubHead"><dnn:label id="plEtime" controlname="txtEtime" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td class="Normal"></td>
	</tr>
</table>

<table id="tblLoadPUs" style="DISPLAY:none">
	<tr>
		<td class="SUBHEAD" width="105"><dnn:label id="plPUCity" controlname="txtPUCity" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUCity" CssClass="NormalTextBox" runat="server" Width="80px"></asp:textbox>&nbsp;/&nbsp;
			<asp:textbox id="txtPUState" CssClass="NormalTextBox" runat="server" Width="88px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="105"><dnn:label id="plPUName" controlname="txtPUName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUName" CssClass="NormalTextBox" runat="server" width="184px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="105"><dnn:label id="plPUAdd1" controlname="txtPUAdd1" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUAdd1" CssClass="NormalTextBox" runat="server" width="184px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="105"><dnn:label id="plPUContact" controlname="txtPUContact" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUContact" CssClass="NormalTextBox" runat="server" width="184px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="105"><dnn:label id="plPUTel" controlname="txtPUTel" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUTel" CssClass="NormalTextBox" runat="server" width="184px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="89"><dnn:label id="plPUDate" controlname="txtPUDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td noWrap><asp:textbox id="txtPUDate" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox><asp:hyperlink id="cmdCalendarPUDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="89"><dnn:label id="plPUTime" controlname="txtPUTime" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPUTime" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="89"><dnn:label id="plWeight" controlname="txtWeight" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtWeight" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="89"><dnn:label id="plPieces" controlname="txtPieces" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtPieces" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="89"><dnn:label id="plMiles" controlname="txtMiles" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtMiles" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
</table>

<table id="tblLoadDrops" style="DISPLAY:none">
	<tr>
		<td class="SUBHEAD" width="124"><dnn:label id="plDPCity" controlname="txtDPCity" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td noWrap><asp:textbox id="txtDPCity" CssClass="NormalTextBox" runat="server" Width="88px"></asp:textbox>&nbsp;/&nbsp;
			<asp:textbox id="txtDPState" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
	<tr class="SUBHEAD">
		<td width="124"><dnn:label id="plDPName" controlname="txtDPName" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtDPName" CssClass="NormalTextBox" runat="server" width="208px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="124"><dnn:label id="plDPAddr" controlname="txtDPAddr" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtDPAddr" CssClass="NormalTextBox" runat="server" width="208px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="124"><dnn:label id="plDPContact" controlname="txtDPContact" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtDPContact" CssClass="NormalTextBox" runat="server" width="208px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="124"><dnn:label id="plDPPhone" controlname="txtDPPhone" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td><asp:textbox id="txtDPPhone" CssClass="NormalTextBox" runat="server" width="208px"></asp:textbox></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="125"><dnn:label id="plDPDate" controlname="txtDPDate" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td vAlign="top"><asp:textbox id="txtDPDate" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox><asp:hyperlink id="cmdCalendarDPDate" CssClass="CommandButton" Runat="server" ImageUrl="~/images/calendar.png"
				resourcekey="Calendar" Text="Calendar"></asp:hyperlink></td>
	</tr>
	<tr>
		<td class="SUBHEAD" width="125"><dnn:label id="plStime" controlname="txtStime" suffix=":" CssClass="SubHead" runat="server"></dnn:label></td>
		<td vAlign="top"><asp:textbox id="txtStime" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox><asp:textbox id="txtEtime" CssClass="NormalTextBox" runat="server" Width="100"></asp:textbox></td>
	</tr>
</table>
