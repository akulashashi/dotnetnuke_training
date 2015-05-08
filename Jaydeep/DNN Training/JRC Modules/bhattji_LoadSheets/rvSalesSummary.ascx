<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvSalesSummary" CodeBehind="rvSalesSummary.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>





<table id="tblSearch" runat="server">
    <tr>
      <td><table width="100%" border="0" cellspacing="3" cellpadding="0">
          <tr>
            <td width="33%" valign="top"><table width="100%" border="0" cellspacing="3" cellpadding="0" class="boxdisplay">
              <tr class="jrctitletext">
                <td width="28%" colspan="2"><table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                      <td><asp:Label ID="plJRCIOfficeCode" Text="Office" CssClass="main_title" runat="server" /></td>
                      <td><asp:DropDownList ID="ddlJRCIOfficeCode" CssClass="emaildrop" runat="server" /></td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td class="SubHead" valign="top">
				   <asp:Label ID="LoadStatus" Text="Load Status: " CssClass="SubHead" runat="server" />            
                </td>
                <td valign="top" height="49"><span class="SubHead">
                  <asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="emaildrop">
                    <asp:ListItem Value="" Text="<All Status>" Selected="True" />            
                    <asp:ListItem Value="WIP" Text="WIP" />            
                    <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />            
                    <asp:ListItem Value="COMPLETE" Text="COMPLETE" />                              </asp:DropDownList>
                </span></td>
              </tr>
            </table></td>
            <td width="35%" valign="top"><table width="100%" border="0" cellspacing="3" cellpadding="0" class="boxdisplay">
              <tr class="jrctitletext">
                <td colspan="3">
					<table border="0" cellpadding="3" cellspacing="0" width="100%">
						<tr>
							<td class="DisplayNone">
                			  <asp:Label ID="lblCustomerName" Text="Customer" CssClass="main_title" runat="server" />							</td>
			                <td width="16%" colspan="2"><asp:DropDownList ID="ddlCustomerNumber" runat="server" CssClass="emaildrop">
                    <asp:ListItem Value="" Text="&lt;All Customers&gt;" />            
                </asp:DropDownList></td>
						</tr>
					</table>				</td>
              </tr>
			  <tr>
			  	<td colspan="3" align="center"><asp:RadioButtonList ID="rblSearchType" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Value="S" Text="StartsWith" resourcekey="StartsWith" Selected="True" />                
                  <asp:ListItem Value="A" Text="Contains" resourcekey="Contains" />                
</asp:RadioButtonList></td>
			  </tr>
              <tr>
                <td width="21%"><span class="SubHead">
                  <asp:Label ID="lblCustomer" Text="Cust Search" CssClass="SubHead" runat="server" />            
                </span></td>
                <td width="61%"><span class="SubHead">
                  <asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" />            
                </span></td>
                <td width="18%" align="left"><asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
              </tr>
			 
            </table></td>
            <td width="33%" valign="top"><table width="100%" class="boxdisplay" cellpadding="3" cellspacing="3">
              <tr class="jrctitletext">
			  	<td valign="top" class="main_title">Load Dates</td>
			  </tr>
			  <tr>
                <td nowrap="nowrap" align="left" valign="top" height="51"><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />            
                    <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10"/>              
                  <asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />              
                    <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />              
                  <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10"/>              
                  <asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" /> <br />             
                  <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/refresh.gif" ToolTip="Refresh the Report with this New Dates" /></td>
              </tr>
            </table>
			</td>
          </tr>
        </table>

        </td>
    </tr>
    <tr>
      <td>
            <table width="100%">
                <tr>

                    <td nowrap id="tdNoOfItems" runat="server">
                        <%--<asp:RangeValidator ID="valNoOfItems" runat="server" ControlToValidate="txtNoOfItems"
                Display="Dynamic" ErrorMessage="No of Records to be fetched, should be be between 1 & 1000"
                MaximumValue="1000" MinimumValue="1" SetFocusOnError="True" Type="Integer" />--%>
                        <table>
                            <tr>
                               <td class="DisplayNone"><dnn:Label ID="plNoOfItems" CssClass="SubHead" ControlName="txtNoOfItems" Suffix=":" runat="server" /></td>
                                <td class="DisplayNone"><asp:TextBox ID="txtNoOfItems" Columns="3" CssClass="NormalTextBox" runat="server" /></td>
                            </tr>
                  </table>                   </td>
                  <td nowrap align="left" class="DisplayNone"><asp:RadioButtonList ID="rblSearchOn" CssClass="NormalTextBox" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="CN" Text="Customer" resourcekey="Customer" />                  
                    <asp:ListItem Value="PO" Text="PO#" resourcekey="PONo" />                  
                    <asp:ListItem Value="PJ" Text="ProJob#" resourcekey="ProJobNo" />                  
                    <asp:ListItem Value="PC" Text="PUCity" resourcekey="PUCity" />                  
                    <asp:ListItem Value="LI" Text="LoadId" resourcekey="LoadId" />                  
                    <asp:ListItem Value="ANY" Text="Any" resourcekey="Any" Selected="True" />                  
</asp:RadioButtonList></td>
                    <td nowrap align="right" valign="top"><asp:TextBox ID="txtSearch" CssClass="DisplayNone" runat="server" />                    
                      <asp:Button ID="btnSearch" usesubmitbehavior="true" runat="server" resourcekey="Search" />
                      
                      <asp:ImageButton ID="imbPrintReport" ImageUrl="~/images/1x1.gif" resourcekey="imbPrintReport" ToolTip="Print this Report" CssClass="CommandButton" BorderStyle="none" runat="server" />
                        <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" />                   </td>
                    <td nowrap align="right" class="DisplayNone"><asp:HyperLink ID="hypReport1" resourcekey="hypReport1" ImageUrl="~/images/print_this.png" NavigateUrl='<%# EditUrl("ReportType", "Report1", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container") %>' Target="_blank" runat="server" /></td>
                </tr>
            </table>      </td>
    </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />