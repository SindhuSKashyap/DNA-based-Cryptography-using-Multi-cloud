<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cloudadminlogin.aspx.cs" Inherits="DNACrytoMultipleCloud.adminlogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css' />
    <!--//webfonts-->
</head>
<body>
    <div class="login-form">    
        <h1>Cloud Admin Sign In</h1>
        <h2><a href="home/index.aspx">Home</a></h2>            
        <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <li>
                <%--<input type="text" id="txtUserName" style="width:290px;" runat="server" class="text" placeholder="User Name" />--%>
                <asp:TextBox ID="txtUserName" Style="width: 290px;" runat="server" CssClass="text"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="Txtwatermark" runat="server" WatermarkText="User Name" TargetControlID="txtUserName" ></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName" ForeColor="Red"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;
<%--                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName"
                    ErrorMessage="Email Improper" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>--%>
                <%--<span class=" icon user"></span>--%>
            </li>
            <li>
                <asp:TextBox ID="txtPassword" Style="width: 290px;" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
               <%-- <input type="password" id="txtPassword" style="width: 290px;" runat="server" value="Password" placeholder="Password" />--%>
                  <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="********" TargetControlID="txtPassword" ></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ForeColor="Red"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
               <%-- <span class=" icon lock"></span>--%>
            </li>

            <div class="forgot">
                <%--   <h3><a href="#">Forgot Password?</a></h3>--%>
                <%--<input type="submit" onclick="myFunction()" value="Sign In" />--%>
                <asp:Button ID="BtnSubmit" runat="server" Text="Sign In" OnClick="BtnSubmit_Click" />
                <asp:Label ID="lblres" runat="server" ForeColor="Red"></asp:Label>
                <a href="#" class=" icon arrow"></a>
            </div>
        </form>
    </div>
</body>
</html>
