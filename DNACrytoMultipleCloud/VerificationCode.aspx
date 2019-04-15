<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationCode.aspx.cs" Inherits="DNACrytoMultipleCloud.VerificationCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password</title>
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css' />
</head>
<body>
    <div class="login-form" style="margin: 0 auto 1%;">
        <h1>Email Verification</h1>    
         <h2><a href="login.aspx">Sign In</a></h2>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <li>
                <asp:TextBox ID="TxtVerificationCode" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
            </li>
            <div class="forgot">
                <%--   <h3><a href="#">Forgot Password?</a></h3>--%>
                <%--<input type="submit" onclick="myFunction()" value="Sign In" />--%>
                <asp:Button ID="BtnVerify" runat="server" Text="Verify" ValidationGroup="1" OnClick="BtnVerify_Click" />
            </div>

            <%--<li>
                <asp:TextBox ID="TxtNewPassword" CssClass="form-control" runat="server" Width="290px" Visible="false"></asp:TextBox>
            </li>
            <li>
                <asp:TextBox ID="TxtConfirmPassword" CssClass="form-control" runat="server" Width="290px" Visible="false"></asp:TextBox>
            </li>

            <div class="forgot">--%>
                <%--   <h3><a href="#">Forgot Password?</a></h3>--%>
                <%--<input type="submit" onclick="myFunction()" value="Sign In" />--%>
              <%--  <asp:Button ID="btnSubmit1" runat="server" Text="Reset" ValidationGroup="1" OnClick="btnSubmit1_Click" Visible="false" />
            </div>--%>

        </form>
    </div>

</body>
</html>
