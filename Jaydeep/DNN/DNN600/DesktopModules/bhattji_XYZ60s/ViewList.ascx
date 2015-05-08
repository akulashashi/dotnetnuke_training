<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ViewList.ascx.cs" Inherits="bhattji.Modules.XYZ60s.ViewList" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls"%>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<div id="divSearch" runat="server" style="width: 100%">
    <div class="dnnClear" style="width: 100%">
        <div class="dnnLeft" style="padding: 5px">
            <asp:RadioButtonList ID="rblSearchOn" CssClass="dnnFormInput" runat="server" BackColor="Transparent" RepeatDirection="Horizontal">
                <asp:ListItem Value="Title" Text="Title" ResourceKey="Title" />
                <asp:ListItem Value="Description" Text="Description" ResourceKey="Description" />
                <asp:ListItem Value="Details" Text="Details" ResourceKey="Details" />
                <asp:ListItem Value="ANY" Text="Any" ResourceKey="Any" Selected="True" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnRight" style="padding: 5px">
            <asp:RadioButtonList ID="rblSearchType" CssClass="dnnFormInput" BackColor="Transparent" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="S" Text="StartsWith" ResourceKey="StartsWith" Selected="True" />
                <asp:ListItem Value="A" Text="Contains" ResourceKey="Contains" />
            </asp:RadioButtonList>
        </div>
        <div class="dnnRight" style="padding: 5px">
            <asp:RequiredFieldValidator ID="valPageSize" runat="server" ErrorMessage="PageSize is required" ControlToValidate="txtPageSize" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" SetFocusOnError="True" />
            <asp:RangeValidator ID="valRangePageSize" runat="server" ErrorMessage="PageSize has to be between 2 & 100"  ControlToValidate="txtPageSize" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" MaximumValue="100" MinimumValue="2" Type="Integer" SetFocusOnError="True"/>
            <asp:Label ID="plPageSize" runat="server" Text="PageSize" />
            <asp:TextBox ID="txtPageSize" Style="width:20px" runat="server" ToolTip="PageSize" />
        </div>
    </div>
    <div class="dnnClear" style="width: 100%">
        <div class="dnnLeft" style="padding: 5px">
            <asp:Label ID="plFromDate" Text="From" runat="server" /><dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="txtFrom" MinDate="1/1/1753" Width="100px" /></div>
        <div class="dnnLeft" style="padding: 5px">
            <asp:Label ID="plToDate" Text="To" runat="server" /><dnn:DnnDatePicker runat="server" CssClass="dnnFormInput" ID="txtTo" MinDate="1/1/1753" Width="100px" /></div>
        <div class="dnnLeft" style="padding: 5px">
            
        </div>

        <div class="dnnRight" style="padding: 5px">
            <asp:TextBox ID="txtSearch" CssClass="dnnFormInput" runat="server" /><asp:Button ID="btnSearch" runat="server" ResourceKey="Search" /></div>
        <div class="dnnRight" style="padding: 5px">
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" CssClass="dnnFormInput" />
            <asp:HyperLink ID="hypEditCategory" runat="server" ImageUrl="~/images/action_settings.gif" ResourceKey="Edit" /></div>
    </div>
</div>
<div>
<%= GetMarquee() %><asp:GridView ID="gdvViewList"  
    runat="server" AllowSorting="True" 
    AutoGenerateColumns="False" DataKeyNames="ItemId" GridLines="None" Width="100%" 
    EmptyDataText="<center class='NormalRed'>No XYZ60 Defined</center>" 
    CssClass="dnnGrid" BackColor="Transparent">
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <HeaderTemplate>
                <asp:HyperLink ID="hypAddItem" ImageUrl="~/images/Add.gif" ResourceKey="Add" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="hypEditItem" ImageUrl="~/images/edit.gif" ResourceKey="Edit" runat="server" />
                <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/delete.gif" ResourceKey="cmdDelete" CommandName="Delete" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypThumb" ImageUrl="~/images/icon_profile_16px.gif" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypTitle" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="RatingAverage">
            <ItemTemplate>
                <asp:HyperLink ID="hypRatings" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypPrint" ImageUrl="~/images/print.gif" ResourceKey="Print" CssClass="SubHead" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Title">
            <ItemTemplate>
                <asp:HyperLink ID="hypMoreLink" ResourceKey="ReadMore" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <p class="NormalRed" align="center">No XYZ60 Defined<br />
            <asp:HyperLink ImageUrl="~/images/add.gif" NavigateUrl='<%# EditUrl() %>' ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /><asp:HyperLink NavigateUrl='<%# EditUrl() %>' ResourceKey="Add" Visible='<%# IsEditable %>' runat="server" /></p>
    </EmptyDataTemplate>
    <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Left" Font-Bold="True" />
    <RowStyle CssClass="dnnGridItem" VerticalAlign="Top" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" VerticalAlign="Top" />
    <SelectedRowStyle CssClass="dnnFormError" />
    <EditRowStyle CssClass="dnnFormInput" />
    <PagerStyle CssClass="dnnGridPager" Font-Bold="True" HorizontalAlign="Center" />
    <PagerSettings Mode="NumericFirstLast" />
    <FooterStyle CssClass="dnnGridFooter" />
</asp:GridView><%= GetMarqueeEnd() %>
    <span class="dnnLeft">
        <asp:Label ID="lblPager" runat="server" Text="Displaying Page 1" />
    </span>
    <span class="dnnRight">        
        <asp:RequiredFieldValidator ID="valPageIndex" runat="server" ErrorMessage="PageIndex is required" ControlToValidate="txtPageIndex" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" SetFocusOnError="True" />
        <asp:RangeValidator ID="valRangePageIndex" runat="server" ErrorMessage="PageIndex has to be between 1 & 10"  ControlToValidate="txtPageIndex" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" MaximumValue="10" MinimumValue="1" Type="Integer" SetFocusOnError="True"/>

        <asp:Button ID="btnFirst" runat="server" Text="<<" style="min-width:20px" />
        <asp:Button ID="btnPrev" runat="server" Text="<" style="min-width:20px" />
        <asp:TextBox ID="txtPageIndex" Style="width:20px" runat="server" ToolTip="PageIndex" />
        <asp:Button ID="btnGo" runat="server" Text="!" style="min-width:20px;margin-left:-5px" />&nbsp;
        <asp:Button ID="btnNext" runat="server" Text=">" style="min-width:20px" />
        <asp:Button ID="btnLast" runat="server" Text=">>" style="min-width:20px" />
    </span>
</div>
<%--<asp:ObjectDataSource ID="odsXYZ60s" runat="server" />--%>
