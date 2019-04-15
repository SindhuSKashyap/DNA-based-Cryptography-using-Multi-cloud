<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCloudAdmin.Master" AutoEventWireup="true" CodeBehind="RegistrationUserDetails.aspx.cs" Inherits="DNACrytoMultipleCloud.RegistrationUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
        <strong style="font-size: x-large; margin-left: 600px;">Cloud User Details</strong>
        <hr />

        
  <div style="margin-left:20%">
        <asp:GridView ID="GridCloud" CssClass="table table-bordered table-condensed table-hover" runat="server" AutoGenerateColumns="False" >
                        <Columns>                            
                            <asp:TemplateField HeaderText="User Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenPK_UserID" runat="server" Value='<%#Eval("PK_UserID")%>'></asp:HiddenField>
                                    <asp:Label ID="UserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone No">
                                <ItemTemplate>
                                    <asp:Label ID="LblPhoneNo" runat="server" Text='<%#Eval("PhoneNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmailId">
                                <ItemTemplate>
                                    <asp:Label ID="LblEmailId" runat="server" Text='<%#Eval("EmailId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Cloud SP1">
                                <ItemTemplate>
                                    <asp:Label ID="LblCSP1" runat="server" Text='<%#Eval("CSP1")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Cloud SP2">
                                <ItemTemplate>
                                    <asp:Label ID="LblCSP2" runat="server" Text='<%#Eval("CSP2")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnEdit" runat="server" CssClass="btn btn-mini btn-info" CommandName="Edit"
                                        ToolTip="Edit" CommandArgument='<%#Eval("Id") %>'><i class="icon-edit icon-white"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LnkBtnDelete" runat="server" CssClass="btn btn-mini btn-danger"
                                        CommandName="Delete" ToolTip="Delete" CommandArgument='<%#Eval("Id") %>'
                                        OnClientClick="javascript:return confirm('Are you sure you want to delete this record ')"><i class="icon-trash icon-white"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
        </div>
    </div>
</asp:Content>
