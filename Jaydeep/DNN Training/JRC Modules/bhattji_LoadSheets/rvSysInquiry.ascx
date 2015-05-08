<%@ Control Language="vb" Inherits="bhattji.Modules.LoadSheets.rvSysInquiry" CodeBehind="rvSysInquiry.ascx.vb" AutoEventWireup="False" Explicit="True" %>
<%--
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table width="770" id="tblSearch">
  <tr>
    <td valign="top"><table class="boxdisplay">
      <tr>
        <td><table id="tblOffice">
          <tr class="jrctitletext">
            <td nowrap><asp:Label ID="plJRCIOfficeCode" Text="Office:" CssClass="SubHead_white" runat="server" /></td>
            <td nowrap><asp:DropDownList ID="ddlJRCIOfficeCode" runat="server" CssClass="NormalTextBox" AutoPostBack="true" />
            </td>
          </tr>
          <tr>
            <td class="SubHead_white"><asp:Label ID="LoadStatus" Text="Status:" CssClass="SubHead" runat="server" /></td>
            <td><asp:DropDownList ID="ddlLoadStatus" runat="server" CssClass="NormalTextBox">
              <asp:ListItem Value="" Text="<All Status>" Selected="True" />
              <asp:ListItem Value="WIP" Text="WIP" />
              <asp:ListItem Value="SUSPENSE" Text="SUSPENSE" />
              <asp:ListItem Value="COMPLETE" Text="COMPLETE" />
              <asp:ListItem Value="VOIDED" Text="VOIDED" />
            </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td nowrap><asp:Label ID="plLoadType" Text="Type:" CssClass="SubHead" runat="server" /></td>
            <td nowrap><asp:RadioButtonList ID="rblLoadType" CssClass="SubHead" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
              <asp:ListItem Value="OO" Text="Dvr" />
              <asp:ListItem Value="BK" Text="Bkr" />
              <asp:ListItem Value="IO" Text="I/O" />
              <asp:ListItem Value="" Text="All" Selected="True" />
            </asp:RadioButtonList>
                    <asp:Label ID="lblLoadType" runat="server" EnableViewState="false" CssClass="NormalRed" />  
            </td>
          </tr>
        </table>
              <table id="tblOO" runat="server">
                <tr class="jrctitletext">
                  <td nowrap><asp:Label ID="plDriverCode" Text="Driver:" CssClass="SubHead_white" runat="server" /></td>
                  <td nowrap><asp:DropDownList ID="ddlDriverCode" runat="server" CssClass="NormalTextBox">
                      <asp:ListItem Value="" Text="<All Drivers>" />  
                  </asp:DropDownList>
                  </td>
                </tr>
              </table>
          <table id="tblBK" runat="server">
                <tr class="jrctitletext">
                  <td nowrap><asp:Label ID="plBroker" Text="Broker:" CssClass="SubHead_white" runat="server" /></td>
                  <td nowrap><asp:DropDownList ID="ddlBrokerCode" runat="server" CssClass="NormalTextBox">
                      <asp:ListItem Value="" Text="<All Brokers>" />  
                  </asp:DropDownList>
                  </td>
                </tr>
                <tr>
                  <td nowrap><asp:Label ID="plSerachBroker" Text="Search:" CssClass="SubHead" runat="server" /></td>
                  <td nowrap><asp:TextBox ID="txtBrokerCode" runat="server" CssClass="NormalTextBox" />  
                      <asp:ImageButton ID="btnBrokerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
                </tr>
                <tr>
                  <td nowrap><asp:Label ID="plBkrInvNo" Text="Bkr Inv#:" CssClass="SubHead" runat="server" /></td>
                  <td nowrap><asp:TextBox ID="txtBkrInvNo" runat="server" CssClass="NormalTextBox" /></td>
                </tr>
            </table>
          <table id="tblIO" runat="server">
                <tr class="jrctitletext">
                  <td nowrap><asp:Label ID="plJRCIOCode" Text="I/O:" CssClass="SubHead_white" runat="server" /></td>
                  <td nowrap><asp:DropDownList ID="ddlJRCIOCode" runat="server" CssClass="NormalTextBox">
                      <asp:ListItem Value="" Text="<All I/Os>" />  
                  </asp:DropDownList>                  </td>
                </tr>
            </table></td>
      </tr>
    </table></td>
    <td valign="top"><table class="boxdisplay">
      <tr>
        <td><table id="tblCustomer">
          <tr class="jrctitletext">
            <td nowrap><asp:Label ID="plCustomer" Text="Customer:" CssClass="SubHead_white" runat="server" /></td>
            <td nowrap><asp:DropDownList ID="ddlCustomerNumber" runat="server" CssClass="NormalTextBox">
              <asp:ListItem Value="" Text="<All Customers>" />
            </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td nowrap><asp:Label ID="plSerachCustomer" Text="Search:" CssClass="SubHead" runat="server" /></td>
            <td nowrap><asp:TextBox ID="txtCustomerNumber" runat="server" CssClass="NormalTextBox" />
                    <asp:ImageButton ID="btnCustomerSearch" ImageUrl="~/images/view.gif" runat="server" CausesValidation="False" /></td>
          </tr>
          <tr>
            <td nowrap><asp:Label ID="plCustPO" Text="PO:" CssClass="SubHead" runat="server" /></td>
            <td nowrap><asp:TextBox ID="txtCustPO" runat="server" CssClass="NormalTextBox" /></td>
          </tr>
          <tr>
            <td nowrap><asp:Label ID="plProJob" Text="Pro Job#:" CssClass="SubHead" runat="server" /></td>
            <td nowrap><asp:TextBox ID="txtProJob" runat="server" CssClass="NormalTextBox" /></td>
          </tr>
        </table>
              <table id="tblLoadDates">
                <tr class="jrctitletext">
                  <td nowrap colspan="2"><asp:Label ID="plLoadDates" Text="LoadDates:" CssClass="SubHead_white" runat="server" /></td>
                </tr>
                <tr>
                  <td nowrap colspan="2"><asp:Label ID="plFromDate" Text="From" CssClass="SubHead" runat="server" />  
                      <asp:TextBox ID="txtFrom" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarFromDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                      <asp:Label ID="plToDate" Text="To" CssClass="SubHead" runat="server" />    
                    <asp:TextBox ID="txtTo" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarToDate" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                  </td>
                </tr>
              </table>
          <table id="tblCompletedDates">
                <tr class="jrctitletext">
                  <td nowrap colspan="2"><asp:Label ID="plCompletedDates" Text="CompletedDates:" CssClass="SubHead_white" runat="server" /></td>
                </tr>
                <tr>
                  <td nowrap colspan="2"><asp:Label ID="plFromDate3" Text="From" CssClass="SubHead" runat="server" />  
                      <asp:TextBox ID="txtFrom3" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarFromDate3" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                      <asp:Label ID="plToDate3" Text="To" CssClass="SubHead" runat="server" />    
                    <asp:TextBox ID="txtTo3" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarToDate3" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                  </td>
                </tr>
            </table>
          <table id="tblDeliveryDates">
                <tr class="jrctitletext">
                  <td nowrap colspan="2"><asp:Label ID="plDeliveryDates" Text="DeliveryDates:" CssClass="SubHead_white" runat="server" /></td>
                </tr>
                <tr>
                  <td nowrap colspan="2"><asp:Label ID="plFromDate2" Text="From" CssClass="SubHead" runat="server" />  
                      <asp:TextBox ID="txtFrom2" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarFromDate2" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                      <asp:Label ID="plToDate2" Text="To" CssClass="SubHead" runat="server" />    
                    <asp:TextBox ID="txtTo2" CssClass="NormalTextBox" runat="server" Columns="10" />    
                    <asp:HyperLink ID="hypCalandarToDate2" CssClass="CommandButton" ImageUrl="~/images/calendar.png" resourcekey="Calendar" runat="server" />    
                  </td>
                </tr>
            </table></td>
      </tr>
    </table></td>
    <td valign="top"><table class="boxdisplay">
      <tr>
        <td><table id="tblPickup">
          <tr class="jrctitletext">
            <td nowrap colspan="2"><asp:Label ID="plPickups" Text="First Pickup:" CssClass="SubHead_white" runat="server" /></td>
          </tr>
          <tr>
            <td nowrap colspan="2"><table>
              <tr>
                <td nowrap><asp:Label ID="plPUCity" Text="City"  CssClass="SubHead" runat="server" />
                          <br/>
                  <asp:TextBox ID="txtPUCity" CssClass="NormalTextBox" runat="server" /></td>
                <td nowrap><asp:Label ID="plPUState" Text="St"  CssClass="SubHead" runat="server" />
                          <br/>
                  <asp:TextBox ID="txtPUState" Columns="1" CssClass="NormalTextBox" runat="server" />  
                  <asp:ImageButton ID="imbSearchCity" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                <td nowrap><asp:Label ID="plZipCode" Text="Zip"  CssClass="SubHead" runat="server" />
                          <br/>
                  <asp:TextBox ID="txtZipCode" Columns="5" CssClass="NormalTextBox" runat="server" />  
                  <asp:ImageButton ID="imbSearchZipCode" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td nowrap colspan="2"><table cellpadding="0" cellspacing="0">
              <tr>
                <td class="SubHead_white" nowrap><asp:Label ID="plSearchZipCode" Text="Select"  CssClass="SubHead" runat="server" /></td>
                <td class="SubHead_white"><asp:DropDownList ID="ddlZipCodes" AutoPostBack="true" CssClass="NormalTextBox" runat="server" />
                </td>
              </tr>
            </table></td>
          </tr>
        </table>
              <table id="tblDrops">
                <tr class="jrctitletext">
                  <td nowrap colspan="2"><asp:Label ID="plDrops" Text="Last Drop:" CssClass="SubHead_white" runat="server" /></td>
                </tr>
                <tr>
                  <td nowrap colspan="2"><table>
                      <tr>
                        <td nowrap><asp:Label ID="plDPCity" Text="City"  CssClass="SubHead" runat="server" />  
                            <br/>
                          <asp:TextBox ID="txtDPCity" CssClass="NormalTextBox" runat="server" /></td>
                        <td nowrap><asp:Label ID="plDPState" Text="St"  CssClass="SubHead" runat="server" />  
                            <br/>
                          <asp:TextBox ID="txtDPState" Columns="1" CssClass="NormalTextBox" runat="server" />    
                          <asp:ImageButton ID="imbSearchCity2" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                        <td nowrap><asp:Label ID="plZipCode2" Text="Zip"  CssClass="SubHead" runat="server" />  
                            <br/>
                          <asp:TextBox ID="txtZipCode2" Columns="5" CssClass="NormalTextBox" runat="server" />    
                          <asp:ImageButton ID="imbSearchZipCode2" ImageUrl="~/images/view.gif" runat="server" CausesValidation="false" /></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td colspan="2" align="left" nowrap><table cellpadding="0" cellspacing="0">
                      <tr>
                        <td class="SubHead_white" nowrap><asp:Label ID="plSearchZipCode2" Text="Select"  CssClass="SubHead" runat="server" /></td>
                        <td class="SubHead_white"><asp:DropDownList ID="ddlZipCodes2" AutoPostBack="true" CssClass="NormalTextBox" runat="server" />                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td colspan="2" align="right" nowrap><asp:TextBox ID="txtSearch" CssClass="NormalTextBox" runat="server" Visible="false" />                  
                    <asp:Button ID="btnSearch" usesubmitbehavior="true" runat="server" resourcekey="Search" />                    
                  <asp:ImageButton ID="imbPrintSelection" ImageUrl="~/images/print_this.png" ToolTip="Print this Report Selection" CssClass="CommandButton" BorderStyle="none" runat="server" /></td>
                </tr>
            </table></td>
      </tr>
    </table></td>
  </tr>
</table>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" width="1500px" height="2200px" />