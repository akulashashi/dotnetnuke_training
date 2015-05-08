<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MsRv9.aspx.cs" Inherits="MsRv9" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Microsoft Report Viewer VS 2005 (Version=9.0.0.0) Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Text="200"/>
    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Text="Active ?" oncheckedchanged="CheckBox1_CheckedChanged" />
    <asp:Button ID="Button1" runat="server" Text="Run Report" onclick="Button1_Click" />
    <br />
    
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" />
    </form>
</body>
</html>
