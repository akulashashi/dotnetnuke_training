<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Views.ascx.cs" Inherits="bhattji.Modules.Feedbacks.Views" %>
<div id="divFeedbackCover" runat="server">
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblName" runat="server" Text="Name" CssClass="fbLabel" /><br />
        <asp:TextBox ID="txtName" runat="server" CssClass="fbTextBox" /><br/>
        <asp:RequiredFieldValidator ID="valName" ControlToValidate="txtName" ErrorMessage="Please enter your Name" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
    </div>
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblCompany" runat="server" Text="Company" CssClass="fbLabel" /><br />
        <asp:TextBox ID="txtCompany" runat="server" CssClass="fbTextBox" />
    </div>
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="fbLabel" /><br />
        <asp:TextBox ID="txtPhone" runat="server" CssClass="fbTextBox" />
    </div>
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="fbLabel" /><br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="fbTextBox" /><br/>
        <asp:RequiredFieldValidator ID="valEmail" ControlToValidate="txtEmail" ErrorMessage="Please enter your Email" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
        <asp:RegularExpressionValidator ID="valEmail1" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please enter a valid Email ID" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
    </div>
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblComments" runat="server" Text="Questions/Comments" CssClass="fbLabel" /><br />
        <asp:TextBox ID="txtComments" runat="server" CssClass="fbTextBox" Rows="5" TextMode="MultiLine" /><br />
        <asp:RequiredFieldValidator ID="valComments" ControlToValidate="txtComments" ErrorMessage="Please enter your Comments" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
    </div>
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:Label ID="lblQuestion" runat="server" Text="Math Question <sup>*</sup>" CssClass="fbLabel" /><br />
        <asp:CheckBox ID="chkSubscribe" runat="server" Text="Sign Me Up for the Newsletter" style="float:right;padding-top:15px;" />
        <asp:Label ID="lblAnswer" runat="server" Text="10 + 2 = " />
        <asp:TextBox ID="txtAnswer" runat="server" CssClass="fbTextBox" style="width:30px" /><br/>
        <asp:RequiredFieldValidator ID="valAnswer" ControlToValidate="txtAnswer" ErrorMessage="Please enter the right no" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" runat="server" />
        <asp:CompareValidator ID="valAnswer1" runat="server" ErrorMessage="Please enter the right no" ControlToValidate="txtAnswer" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" Type="Integer" ValueToCompare="12"/>
    </div>
    
    <div class="dnnClear" style="padding-bottom: 20px;">
        <asp:LinkButton ID="lnbSend" runat="server" CssClass="dnnPrimaryAction" Text="Send" style="float:right;" />
    </div>
    <asp:Label ID="lblMsg" runat="server" EnableViewState="false" />
</div>




