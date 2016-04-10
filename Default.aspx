<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>FirstName
                </td>
                <td>
                    <asp:TextBox ID="txt_firstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Lastname
                </td>
                <td>
                    <asp:TextBox ID="txt_lastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Emailid
                </td>
                <td>
                    <asp:TextBox ID="txt_emailid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mobileno
                </td>
                <td>
                    <asp:TextBox ID="txt_mobileno" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click"></asp:Button>
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click"></asp:Button>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" DataKeyNames="intglcode" PageSize="10" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                           <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                    <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("intglcode") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Link" />
                            <asp:TemplateField HeaderText="Firstname">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("firstname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lastname">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%#Eval("lastname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emailid">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("emailid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Mobileno">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("mobileno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Firstname" DataField="firstname" />
                            <asp:BoundField HeaderText="Lastname" DataField="lastname" />
                            <asp:BoundField HeaderText="Emailid" DataField="emailid" />
                            <asp:BoundField HeaderText="Mobileno" DataField="mobileno" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
         <input type="hidden" runat="server" id="hidCustomerID" />
    </form>
</body>
</html>

