<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Views.ascx.cs" Inherits="bhattji.Modules.JsonUpdates.Views" %>
<div style="font-family: Calibri; font-size: 13pt">
        <h3>
            Update Multiple Rows of GridView using JSON in DotNetNuke</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            Width="480px">
            <Columns>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StudentID" HeaderText="ID" SortExpression="StudentID"
                    ItemStyle-Width="25px" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:TemplateField HeaderText="C" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("C") %>'></asp:Label>
                        <asp:TextBox ID="txtC" runat="server" Text='<%# Eval("C") %>' Width="30px" Visible="false"
                            MaxLength="3"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C++" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("CPP") %>'></asp:Label>
                        <asp:TextBox ID="txtCPP" runat="server" Text='<%# Eval("CPP") %>' Width="30px" Visible="false"
                            MaxLength="3"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("CS") %>'></asp:Label>
                        <asp:TextBox ID="txtCS" runat="server" Text='<%# Eval("CS") %>' Width="30px" Visible="false"
                            MaxLength="3"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    </div>
<asp:Button ID="btnSendEmail" runat="server" Text="Send Email" onclick="btnSendEmail_Click" />