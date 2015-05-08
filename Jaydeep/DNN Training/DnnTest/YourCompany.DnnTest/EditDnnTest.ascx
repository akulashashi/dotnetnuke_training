<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDnnTest.ascx.cs" Inherits="YourCompany.Modules.DnnTest.EditDnnTest" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>

<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<div class="dnnForm" id="form-demo">
    <asp:Label runat="server" CssClass="dnnFormMessage dnnFormInfo" ResourceKey="Intro" />
    <div class="dnnFormItem dnnFormHelp dnnClear">
        <p class="dnnFormRequired"><asp:Label runat="server" ResourceKey="Required Indicator" /></p>
    </div>
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="NameTextBox" ResourceKey="Name" />
            <asp:TextBox runat="server" ID="NameTextBox" CssClass="dnnFormRequired" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="NameTextBox" 
                CssClass="dnnFormMessage dnnFormError" ResourceKey="Name.Required" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="DescriptionTextBox" ResourceKey="Description" />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="DescriptionTextBox" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="ChoiceDropDown" ResourceKey="Choice" />
            <asp:DropDownList runat="server" ID="ChoiceDropDown">
                <asp:ListItem Text="-- Make a Choice --" />
                <asp:ListItem Text="First Choice" />
                <asp:ListItem Text="Second Choice" />
            </asp:DropDownList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="RateRadioButtons" ResourceKey="Rate" />
            <asp:RadioButtonList runat="server" ID="RateRadioButtons"
                RepeatDirection="Horizontal" CssClass="dnnFormRadioButtons">
                <asp:ListItem Text="1" />
                <asp:ListItem Text="2" />
                <asp:ListItem Text="3" />
                <asp:ListItem Text="4" />
                <asp:ListItem Text="5" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="AgreeCheckbox" ResourceKey="Agree" />
            <asp:CheckBox runat="server" ID="AgreeCheckbox" />
        </div>
        <div class="dnnFormItem">
            <asp:Label runat="server" CssClass="dnnFormLabel" AssociatedControlID="StartDatePicker" ResourceKey="Start Date" />
            <dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="StartDatePicker" />
        </div>
    </fieldset>
    <ul class="dnnActions dnnClear">
        <li><asp:LinkButton runat="server" CssClass="dnnPrimaryAction" ResourceKey="Save" /></li>
        <li><asp:HyperLink runat="server" CssClass="dnnSecondaryAction" NavigateUrl="/" ResourceKey="Cancel" /></li>
    </ul>
</div>
            

<table width="650" cellspacing="0" cellpadding="0" border="0" summary="Edit Table">

    <tr valign="top">
		<td class="SubHead" width="125"><dnn:Label id="lblTitle" runat="server" controlname="lblTitle" suffix=":"></dnn:Label></td>

        <td>
			<asp:TextBox id="txtTitle" runat="server" width="500" />
			
		</td>
	</tr>

    <tr valign="top">
		<td class="SubHead" width="125"><dnn:Label id="lblContent" runat="server" controlname="lblContent" suffix=":"></dnn:Label></td>

        <td>
			<dnn:texteditor id="txtContent" runat="server" height="200" width="500" />
			<asp:RequiredFieldValidator ID="valContent" resourcekey="valContent.ErrorMessage" ControlToValidate="txtContent"
				CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br>Content is required" Runat="server" />
		</td>
	</tr>
</table>
<p>
    <asp:linkbutton cssclass="CommandButton" id="cmdUpdate" resourcekey="cmdUpdate" runat="server" borderstyle="none" text="Update" OnClick="cmdUpdate_Click"></asp:linkbutton>&nbsp;
    <asp:linkbutton cssclass="CommandButton" id="cmdCancel" resourcekey="cmdCancel" runat="server" borderstyle="none" text="Cancel" causesvalidation="False" OnClick="cmdCancel_Click"></asp:linkbutton>&nbsp;
    <asp:linkbutton cssclass="CommandButton" id="cmdDelete" resourcekey="cmdDelete" runat="server" borderstyle="none" text="Delete" causesvalidation="False" OnClick="cmdDelete_Click"></asp:linkbutton>&nbsp;
</p>
<dnn:Audit id="ctlAudit" runat="server" />
