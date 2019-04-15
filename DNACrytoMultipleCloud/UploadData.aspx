<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.Master" AutoEventWireup="true" CodeBehind="UploadData.aspx.cs" Inherits="DNACrytoMultipleCloud.UploadData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" style="margin-left:300px;">
            <tr>
                <td style="padding-bottom:10px; padding-top:10px;" class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom:10px; padding-top:10px;">
                    <asp:TextBox ID="TxtTitle" runat="server" Width="900px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom:10px; padding-top:10px;">
                  <%--  <asp:Label ID="lbltext" runat="server" Text="Enter the text below"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtFilePath" runat="server"></asp:TextBox>--%>
                    
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="BtnBrowse" runat="server" Text="View" OnClick="BtnBrowse_Click1"/>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom:10px; padding-top:10px;">
                    <asp:TextBox ID="TxtData" runat="server" TextMode="MultiLine" Width="900px" Height="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-bottom:10px; padding-top:10px;">
                 <%--   <div class="progress-button">--%>
                        <asp:Button ID="BtnUpload" CssClass="btn btn-success" runat="server" Text="Save" OnClick="BtnUpload_Click" />
						<%--<button><span>Submit</span></button>
						<svg class="progress-circle" width="70" height="70"><path d="m35,2.5c17.955803,0 32.5,14.544199 32.5,32.5c0,17.955803 -14.544197,32.5 -32.5,32.5c-17.955803,0 -32.5,-14.544197 -32.5,-32.5c0,-17.955801 14.544197,-32.5 32.5,-32.5z"/></svg>
						<svg class="checkmark" width="70" height="70"><path d="m31.5,46.5l15.3,-23.2"/><path d="m31.5,46.5l-8.5,-7.1"/></svg>
						<svg class="cross" width="70" height="70"><path d="m35,35l-9.3,-9.3"/><path d="m35,35l9.3,9.3"/><path d="m35,35l-9.3,9.3"/><path d="m35,35l9.3,-9.3"/></svg>--%>
					<%--</div>--%>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
