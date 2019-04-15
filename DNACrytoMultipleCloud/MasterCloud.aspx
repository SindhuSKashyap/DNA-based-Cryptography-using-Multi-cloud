<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCloudAdmin.Master" AutoEventWireup="true" CodeBehind="MasterCloud.aspx.cs" Inherits="DNACrytoMultipleCloud.MasterCloud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdpadding {
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <strong style="font-size: x-large; margin-left: 600px;">Cloud Master</strong>
        <hr />
        <table align="center" style="margin-top: 20px;">
            <tr>
                <td style="padding-right: 50px;">Cloud Name
                </td>
                <td>
                    <asp:TextBox ID="TxtCloudName" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TxtWatermarkExtender" WatermarkText="Cloud Name" runat="server" TargetControlID="TxtCloudName"></asp:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                <td>Server Name
                </td>
                <td class="tdpadding">
                    <asp:TextBox ID="TxtDBServerName" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" WatermarkText="Server Name" runat="server" TargetControlID="TxtDBServerName"></asp:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                <td>User Name
                </td>
                <td class="tdpadding">
                    <asp:TextBox ID="TxtDBUserName" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" WatermarkText="UserName" runat="server" TargetControlID="TxtDBUserName"></asp:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                <td>Password
                </td>
                <td class="tdpadding">
                    <asp:TextBox ID="TxtDBPassword" CssClass="form-control" runat="server" Width="290px" TextMode="Password"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" WatermarkText="Password" runat="server" TargetControlID="TxtDBPassword"></asp:TextBoxWatermarkExtender>
                </td>
            </tr>

            <tr>
                <td></td>
                <td class="tdpadding">
                    <asp:Button ID="BtnSubmit" runat="server" Text="Save" CssClass="btn btn-success" OnClick="BtnSubmit_Click" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="BtnCancel_Click" />
                    <asp:HiddenField ID="HiddenID" runat="server" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td style="padding-top: 30px; padding-bottom: 30px;">
                    <asp:Label ID="lblres" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        <table align="center" style="margin-top: 20px;">
            <tr>
                <td>
                    <asp:GridView ID="GridCloud" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCommand="GridCloud_RowCommand" OnRowDeleting="GridCloud_RowDeleting" OnRowEditing="GridCloud_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Cloud Name">
                                <ItemTemplate>
                                    <asp:Label ID="LblCloudName" runat="server" Text='<%#Eval("CloudName")%>'></asp:Label>
                                    <asp:HiddenField ID="HiddenId" runat="server" Value='<%#Eval("Id")%>'></asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Server Name">
                                <ItemTemplate>
                                    <asp:Label ID="LblCloudDBServerName" runat="server" Text='<%#Eval("CloudDBServerName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name">
                                <ItemTemplate>
                                    <asp:Label ID="LblCloudDBUserName" runat="server" Text='<%#Eval("CloudDBUserName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LblCloudDBPassword" runat="server" Text='<%#Eval("CloudDBPassword")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Action">
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
                </td>
            </tr>
        </table>   
    </div>
</asp:Content>
