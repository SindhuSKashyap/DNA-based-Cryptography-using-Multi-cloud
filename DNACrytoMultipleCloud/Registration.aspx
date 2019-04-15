<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DNACrytoMultipleCloud.Registration" %>

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
    <div class="login-form" style="margin: 0 auto 1%;">
        <h1>Registration</h1>
        <h2><a href="login.aspx">Sign In</a></h2>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <li>                
                <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TxtWatermarkExtender" WatermarkText="UserName" runat="server" TargetControlID="TxtUserName"></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUserName" ValidationGroup="1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                
                <span class=" icon user"></span>
            </li>
            <li>
                <asp:TextBox ID="TxtPhoneNo" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" WatermarkText="Phone No." runat="server" TargetControlID="TxtPhoneNo"></asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPhoneNo" ValidationGroup="1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                 <span class="icon user"></span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Font-Size="Smaller" ErrorMessage="Invalid Ph no." ValidationGroup="1" SetFocusOnError="true" ControlToValidate="TxtPhoneNo" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>               
            </li>
            <li>
                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Email Address" runat="server" TargetControlID="TxtEmail"></asp:TextBoxWatermarkExtender>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtEmail"  ValidationGroup="1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="reqfieldalert" Font-Size="Smaller" ValidationGroup="1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Invalid Email" ControlToValidate="TxtEmail" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"></asp:RegularExpressionValidator>
                <span class=" icon user"></span>
            </li>
            <li>

                <asp:TextBox ID="TxtPassword" CssClass="form-control" TextMode="Password" runat="server" Width="300px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" WatermarkText="Password" runat="server" TargetControlID="TxtPassword"></asp:TextBoxWatermarkExtender>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPassword" ValidationGroup="1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <span class=" icon user"></span>
            </li>
            <li>
                <asp:DropDownList ID="DropdownPrimary" CssClass="form-control" style="margin-bottom: 1px; margin-left:21px;" runat="server" Width="430px" Height="39px" AutoPostBack="True" OnSelectedIndexChanged="DropdownPrimary_SelectedIndexChanged"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropdownPrimary" ValidationGroup="1" InitialValue="-1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
               <%-- <span class=" icon user"></span>--%>
            </li>
            <li>
                <asp:DropDownList ID="DropDownSecondary" CssClass="form-control" style="margin-bottom: 1px; margin-left:21px;" runat="server" Width="430px" Height="39px"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ValidationGroup="1" ControlToValidate="DropDownSecondary" InitialValue="-1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
               <%-- <span class=" icon user"></span>--%>
            </li>
            <%--  <input type="text" id="txtUserName" runat="server" class="text" value="User Name" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'User Name';}" />
            </li>
            <li>
                 <asp:TextBox ID="TxtPhoneNo" CssClass="form-control" runat="server" Width="290px"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" WatermarkText="Phone No." runat="server" TargetControlID="TxtPhoneNo"></asp:TextBoxWatermarkExtender>
               <%-- <input type="password" id="txtPassword" runat="server" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}" /><a href="#" class=" icon lock"></a>--%>


            <div class="forgot">
                <%--<h3><a href="#">Forgot Password?</a></h3>--%>
                <%--<input type="submit" onclick="myFunction()" value="Sign In" />--%>
                <asp:Button ID="BtnSubmit" runat="server" Text="Sign Up" OnClick="BtnSubmit_Click"  ValidationGroup="1"/>                
                <asp:Label ID="lblres" runat="server" ForeColor="White"></asp:Label>
                <span class="icon arrow"> </span>
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

