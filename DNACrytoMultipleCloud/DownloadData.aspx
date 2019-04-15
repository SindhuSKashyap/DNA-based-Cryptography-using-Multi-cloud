<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.Master" AutoEventWireup="true" CodeBehind="DownloadData.aspx.cs" Inherits="DNACrytoMultipleCloud.DownloadData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <table align="center" visible="false" style="margin-left:300px;">
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <asp:TextBox ID="TxtTitle" runat="server" Width="900px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <asp:Label ID="lbltext" runat="server" Text="Enter the text below"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <asp:TextBox ID="TxtData" runat="server" TextMode="MultiLine" Width="900px" Height="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px;">
                <%--   <div class="progress-button">--%>
                <%--<button><span>Submit</span></button>
						<svg class="progress-circle" width="70" height="70"><path d="m35,2.5c17.955803,0 32.5,14.544199 32.5,32.5c0,17.955803 -14.544197,32.5 -32.5,32.5c-17.955803,0 -32.5,-14.544197 -32.5,-32.5c0,-17.955801 14.544197,-32.5 32.5,-32.5z"/></svg>
						<svg class="checkmark" width="70" height="70"><path d="m31.5,46.5l15.3,-23.2"/><path d="m31.5,46.5l-8.5,-7.1"/></svg>
						<svg class="cross" width="70" height="70"><path d="m35,35l-9.3,-9.3"/><path d="m35,35l9.3,9.3"/><path d="m35,35l-9.3,9.3"/><path d="m35,35l9.3,-9.3"/></svg>--%>
                <%--</div>--%>
                    
                <asp:Button ID="Button1" runat="server" Text="Download" />
                    
            </td>
        </tr>
    </table>

    <table align="center">
        <tr>
            <td style="padding-bottom:10px; padding-top:10px;">
                <asp:GridView ID="GridData" CssClass="table" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridData_PageIndexChanging" OnRowCommand="GridData_RowCommand" OnRowDeleting="GridData_RowDeleting" OnRowEditing="GridData_RowEditing">
                    <Columns>                      
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <asp:Label ID="LblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                                 <asp:HiddenField ID="HiddenId" runat="server" Value='<%#Eval("PK_DataId")%>'></asp:HiddenField>
                                 <asp:HiddenField ID="HiddenDataId" runat="server" Value='<%#Eval("DataId")%>'></asp:HiddenField>
                                <asp:HiddenField ID="HiddenData" runat="server" Value='<%#Eval("Data")%>'></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="LblUploadedDate" runat="server" Text='<%#Eval("UploadedDate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkBtnEdit" runat="server" CssClass="btn btn-mini btn-info" CommandName="Download"
                                    ToolTip="Edit" CommandArgument='<%#Eval("PK_DataId") %>'><i class="icon-edit icon-white"></i></asp:LinkButton>                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:templatefield headertext="delete">
                            <itemtemplate>
                                <asp:linkbutton id="lnkbtnedit2" runat="server" cssclass="btn btn-mini btn-info" commandname="Delete"
                                    tooltip="edit" commandargument='<%#Eval("pk_dataid") %>'><i class="icon-delete"></i></asp:linkbutton>                               
                            </itemtemplate>
                        </asp:templatefield>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
