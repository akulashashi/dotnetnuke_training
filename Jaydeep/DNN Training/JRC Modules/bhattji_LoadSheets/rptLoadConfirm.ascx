<%@ Control Language="vb" AutoEventWireup="False" CodeBehind="rptLoadConfirm.ascx.vb" Inherits="bhattji.Modules.LoadSheets.rptLoadConfirm" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>
<asp:Label ID="lblMsg" runat="server" CssClass="NormalRed" EnableViewState="false" />
<table border="0" cellpadding="0" cellspacing="0">
    <caption>
        <h1><asp:Label ID="lblReportHeading" CssClass="Head" runat="server" /></h1>
    </caption>
    <tr>
        <td align="center">
            <div id="divButtons" runat="server">
                <table>
                    <tr>
                        <td id="tdEdit" class="DisplayNone" align="center" valign="bottom" runat="server"><asp:HyperLink ID="hypImgEdit" ImageUrl="~/images/update_and_list.png" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /><br />
                            <asp:HyperLink ID="hypEdit" resourcekey="Edit" CssClass="CommandButton" runat="server" Visible="false" /></td>
                        <td class="DisplayNone" align="center" valign="bottom"><asp:HyperLink ID="hypImgClose" ImageUrl="~/images/cancel_changes.png" resourcekey="Close" CssClass="CommandButton" runat="server" /><br />
                            <asp:HyperLink ID="hypClose" resourcekey="Close" CssClass="CommandButton" runat="server" /></td>
                        <td class="SubHead" align="center" valign="bottom"><asp:HyperLink ID="hypImgPrint" ImageUrl="~/images/print_this.png" resourcekey="Print" CssClass="CommandButton" runat="server" /><br />
                            <asp:HyperLink ID="hypPrint" resourcekey="Print" CssClass="CommandButton" runat="server" /></td>
                            
                        <td class="SubHead" align="center" valign="bottom"><asp:HyperLink ID="hypImgPdf" ImageUrl="~/images/pdfIcon.jpg" resourcekey="Pdf" Height="32px" Width="32px" CssClass="CommandButton" runat="server" /><br />
                            <asp:HyperLink ID="hypPdf" resourcekey="Pdf" Text="PDF" CssClass="CommandButton" runat="server" /></td>
                            
                        <td class="SubHead" align="center" valign="bottom"><asp:ImageButton ID="imbEmail" ImageUrl="~/images/email_this.png" resourcekey="email_this" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                            <asp:LinkButton ID="lnbEmail" Text="eMail" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
                  
                        <td class="SubHead" align="center" valign="bottom"><asp:ImageButton ID="imbEmailPdf" ImageUrl="~/images/email_this.png" resourcekey="email_this" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /><br />
                            <asp:LinkButton ID="lnbEmailPdf" Text="eMail PDF" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
             
                    </tr>
                </table>
                
                <%--<asp:Button ID="btnExport" runat="server" Text="Export to PDF" />--%>
                
                <br />
                <br />
                <Portal:audit id="ctlAudit" runat="server" />
            </div>
       </td>
    </tr>
    <tr>
        <td align="center"><asp:Label ID="lblOOMsg" CssClass="SubHead" runat="server" /></td>
    </tr>
    <tr>
        <td>
            <table id="tblLoadConfrm" runat="server" width="700">
                <tr>
                    <td valign="top">
                        <table width="700" border="0" class="style6">
                            <tr>
                                <td width="341" class="style5" valign="top">
                                    <table id="tblDriverPayables" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Office</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0">
                                                    <tr>
                                                        <td valign="top"><h1><asp:Label ID="lblJRCIOfficeCode" CssClass="DisplayNone" runat="server" /></h1>
                                                            <asp:Label ID="lblAddress" CssClass="Head" runat="server" /></td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                                <td width="104" valign="top">
                                    <table width="116" border="0">
                                    </table>
                               </td>
                                <td width="241" valign="top">
                                    <table id="Table8" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td colspan="2" class="Head">Please contact JRC Upon Completion of Delivery</td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                                    <table id="Table1" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">JRC Load # :</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table border="0">
                                                    <tr>
                                                        <td width="130" class="style2"><strong>Load ID : </strong></td>
                                                        <td width="129"><asp:Label ID="lblLoadId" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="130" class="style2"><strong>Load Date : </strong></td>
                                                        <td width="129"><asp:Label ID="lblLoadDate" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                                    <table id="Table7" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1" valign="top">Load Notes :</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td colspan="2" class="style2">
                                                            <%--<strong>Notes go here :</strong>--%>
                                                            <asp:Label ID="lblLoadNotes" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                        <table width="700">
                            <tr>
                                <td width="361" valign="top">
                                    <table id="Table2" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Carrier:</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table border="0">
                                                    <tr>
                                                        <td width="52" valign="top" rowspan="4" class="style2"><strong>Carrier:</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top"><asp:Label ID="lblCarrierName" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                                <td width="169" valign="top">
                                    <table id="Table3" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">JRC Carrier #</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="41%"><asp:Label ID="lblJRCarrier" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblTrailerNumber" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblTrailerDue" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><asp:Label ID="lblTrailerType" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                </table>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                                <td width="154" valign="top">
                                    <table id="Table4" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Contact Info :</td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table>
                                                    <tr>
                                                        <td width="61" class="style2"><strong>PhoneNo:</strong></td>
                                                        <td width="394"><asp:Label ID="lblPhNo" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="61" class="style2"><strong>Cell Phone:</strong></td>
                                                        <td width="394"><asp:Label ID="lblCellPhone" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style2"><strong>Fax No:</strong></td>
                                                        <td><asp:Label ID="lblFaxNo" CssClass="SubHead" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style2"><strong>Email:</strong></td>
                                                        <td><asp:Label ID="txtEmail" runat="server" CssClass="SubHead" /><%--<asp:TextBox ID="txtEmail" runat="server" CssClass="NormalTextBox" /><asp:ImageButton Height="20" ID="btnEmail" runat="server" ImageUrl="~/images/email_this.png" CssClass="CommandButton" OnClientClick="return confirm('Are you sure, you wish to send eMail ?');" />--%>
                                                       </td>
                                                    </tr>
                                                </table>
                                                <%--<asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="eMail needs to be in valid Format" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>--%>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                        <table id="Table9" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                            <tr>
                                <td bgcolor="#000000" class="style1" valign="top">Terms and Condition :</td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                        <tr>
                                            <td colspan="2" class="Normal"><asp:Label ID="lblBWords" CssClass="SubHead" runat="server" /></td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                        <table id="Table5" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                            <tr>
                                <td bgcolor="#000000" class="style1" valign="top">Tarp Messages :</td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="style2">
                                        <tr>
                                            <td colspan="2" class="Normal"><asp:Label ID="lblTarpMsg" CssClass="SubHead" runat="server" /></td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                        <table id="Table6" runat="server" width="100%" border="1" cellspacing="0" cellpadding="2">
                            <tr>
                                <td bgcolor="#000000" class="style1">Signature & Date</td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="700" class="style7">
                                        <tr>
                                            <td width="332" align="left"><strong>Signature:______________________</strong></td>
                                            <td width="88" class="style2"><strong>Total Charges:</strong></td>
                                            <td><asp:Label ID="lblDRTotDue" CssClass="SubHead" runat="server" /></td>
                                            <td width="208" align="right"><strong>Date:___________</strong></td>
                                        </tr>
                                        <%-- <tr>
                                            <td colspan="4" class="style2">
                                                <strong>Notes/Instructions:</strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                Insert notes/instructions</td>
                                        </tr>--%>
                                    </table>
                               </td>
                            </tr>
                        </table>
            <table width="700">
                            <tr>
                                <td width="351" valign="top" class="style9">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Load pickups</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gdvLoadPUs" DataSourceID="odsLoadPUs" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="Horizontal" Width="100%" EmptyDataText="<center class='NormalRed'>No Data Defined</center>">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<nobr>Name & Address</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                            <ItemTemplate>
                                                                <%--
                                                                <asp:Label ID="lblPUCity" runat="server" CssClass="Normal" Text='<%# Eval("PUCity") %>' />/<asp:Label ID="lblPUState" runat="server" CssClass="Normal" Text='<%# Eval("PUState") %>' />/<asp:Label ID="lblZipCode" runat="server" CssClass="Normal" Text='<%# Eval("ZipCode") %>' />
                                                                --%>
                                                                <asp:Literal ID="ltrAditional1" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<nobr>Pickup Details</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                            <ItemTemplate>
                                                                <%--
                                                                <asp:Label ID="lblPUDate" runat="server" Text='<%# Eval("PUDate", "{0:d}") %>' CssClass="Normal" />
                                                                <asp:Label ID="lblPUTime" runat="server" Text='<%# Eval("PUTime", "{0:t}") %>' CssClass="Normal" />
                                                                <asp:Label ID="lblPUDate" runat="server" CssClass="Normal" />
                                                                <asp:Label ID="lblPUTime" runat="server" CssClass="Normal" />
                                                                --%>
                                                                <asp:Literal ID="ltrAditional2" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                                                    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <EmptyDataTemplate>
                                                        <p class="NormalRed" align="center">No Load-Pickup Defined</p>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="odsLoadPUs" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadPUInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadPUsController" SelectMethod="GetLoadPUByLoadId">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="LoadID" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                                <td width="337" valign="top" class="style9">
                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td bgcolor="#000000" class="style1">Load Drops</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gdvLoadDrops" DataSourceID="odsLoadDrops" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="Horizontal" Width="100%" EmptyDataText="<center class='NormalRed'>No Data Defined</center>">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<nobr>Name & Address</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                            <ItemTemplate>
                                                                <%--
                                                                <asp:Label ID="lblDPCity" runat="server" CssClass="Normal" Text='<%# Eval("DPCity") %>' />/<asp:Label ID="lblDPState" runat="server" CssClass="Normal" Text='<%# Eval("DPState") %>' />/<asp:Label ID="lblZipCode" runat="server" CssClass="Normal" Text='<%# Eval("ZipCode") %>' />
                                                                --%>
                                                                <asp:Literal ID="ltrAditional1" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<nobr>Drop Details</nobr>" HeaderStyle-CssClass="SubHead" ItemStyle-VerticalAlign="Top">
                                                            <ItemTemplate>
                                                                <%--
                                                                <asp:Label ID="lblDPDate" runat="server" Text='<%# Eval("DPDate", "{0:d}") %>' CssClass="Normal" />
                                                                <asp:Label ID="lblStime" runat="server" Text='<%# Eval("Stime", "{0:t}") %>' CssClass="Normal" />
                                                                <asp:Label ID="lblEtime" runat="server" Text='<%# Eval("Etime", "{0:t}") %>' CssClass="Normal" />
                                                                <asp:Label ID="lblDPDate" runat="server" CssClass="Normal" />
                                                                <asp:Label ID="lblStime" runat="server" CssClass="Normal" />
                                                                <asp:Label ID="lblEtime" runat="server" CssClass="Normal" />
                                                                --%>
                                                                <asp:Literal ID="ltrAditional2" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="NormalBold" Font-Bold="True" />
                                                    <PagerStyle CssClass="NormalBold" Font-Bold="True" HorizontalAlign="Center" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <EmptyDataTemplate>
                                                        <p class="NormalRed" align="center">No Load-Drop Defined</p>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="odsLoadDrops" runat="server" DataObjectTypeName="bhattji.Modules.LoadSheets.Business.LoadDropInfo" TypeName="bhattji.Modules.LoadSheets.Business.LoadDropsController" SelectMethod="GetLoadDropByLoadId">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="LoadID" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                           </td>
                                        </tr>
                                    </table>
                               </td>
                            </tr>
                        </table>
                        
                   </td>
                </tr>
            </table>
       </td>
    </tr>
</table>
