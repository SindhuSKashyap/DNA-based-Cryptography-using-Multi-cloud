<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DNACrytoMultipleCloud.login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    
        <h1>Sign In</h1>
        <h2><a href="Registration.aspx">Create Account</a></h2>       
        <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <li>
                <%--<input type="text" id="txtUserName" style="width:290px;" runat="server" class="text" placeholder="User Name" />--%>
                <asp:TextBox ID="txtUserName" Style="width: 290px;" runat="server" CssClass="text"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="Txtwatermark" runat="server" WatermarkText="Email Id" TargetControlID="txtUserName" ></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="1"  ControlToValidate="txtUserName" ForeColor="Red"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName"
                 Font-Size="Smaller" ForeColor="Red" ErrorMessage="Invalid Email" ValidationGroup="1"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <%--<span class=" icon user"></span>--%>
            </li>
            <li>
                <asp:TextBox ID="txtPassword" Style="width: 290px;" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
               <%-- <input type="password" id="txtPassword" style="width: 290px;" runat="server" value="Password" placeholder="Password" />--%>
                  <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="********" TargetControlID="txtPassword" ></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="1"  ControlToValidate="txtPassword" ForeColor="Red"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
               <%-- <span class=" icon lock"></span>--%>
            </li>

            <div class="forgot">
                <%--   <h3><a href="#">Forgot Password?</a></h3>--%>
                <%--<input type="submit" onclick="myFunction()" value="Sign In" />--%>
                <asp:Button ID="BtnSubmit" runat="server" Text="Sign In" OnClick="BtnSubmit_Click" ValidationGroup="1"  />
                <asp:Button ID="BtnForgotPwd" runat="server" Text="Forgot Password" OnClick="BtnForgotPwd_Click" />
                <asp:Label ID="lblres" runat="server" ForeColor="Red"></asp:Label>
                <a href="#" class=" icon arrow"></a>
            </div>            
              
        </form>
    </div>
    <!--//End-login-form-->
    <div class="ad728x90" style="text-align: center">
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <!-- w3layouts_demo_728x90 -->
        <%--  <ins class="adsbygoogle"
                style="display: inline-block; width: 728px; height: 90px"
                data-ad-client="ca-pub-9153409599391170"
                data-ad-slot="8639520288"></ins>--%>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({});
        </script>
    </div>


    <!-----start-copyright---->
    <%--<div class="copy-right">--%>
    <%--<p>DNA based Cyrptography for multi cloud</p>--%>
    <%-- </div>--%>
    <!-----//end-copyright---->

</body>
</html>
