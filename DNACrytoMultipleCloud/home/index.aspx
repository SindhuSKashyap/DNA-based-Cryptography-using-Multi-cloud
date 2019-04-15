<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DNACrytoMultipleCloud.home.index" %>

<!DOCTYPE html>

<!DOCTYPE HTML>
<html>
<head>
    <title>DNA Based Cryptography</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/slimmenu.css" rel="stylesheet" media="screen">
    <!--web-fonts -->
    <link href='http://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>
    <!--web-fonts -->
   <%-- <link href="../hovercss/css/demo-page.css" rel="stylesheet" />--%>
    <link href="../hovercss/css/hover-min.css" rel="stylesheet" />
    <link href="../hovercss/css/hover.css" rel="stylesheet" />
  <%--  <script src="js/jquery.min.js"></script>--%>
</head>
<body>

    <div class="container">
        <div class="wrap">
            <div class="header">
                <header id="topnav">
                    <nav>
                        <ul>
                            <li class="hvr-back-pulse hvr-grow-shadow hvr-wobble-to-top-right"><a href="index.aspx" >Home</a></li>
                            <li class="hvr-back-pulse hvr-grow-shadow hvr-wobble-to-top-right"><a href="../Registration.aspx" >User Registration</a></li>
                            <li class="hvr-back-pulse hvr-grow-shadow hvr-wobble-to-top-right"><a href="../login.aspx" >User Login</a></li>
                            <li class="hvr-push hvr-wobble-to-top-right"><a href="../cloudadminlogin.aspx" >Cloud Admin</a></li>
                          <%--  <li><a href="#contact" class="scroll">Contact</a></li>--%>
                          <%--  <div class="clear"></div>--%>
                        </ul>
                    </nav>
                    <h1><a href="index.aspx">
                        <img src="images/logo.png" alt=""></a></h1>
                    <a href="#" id="navbtn">Nav Menu</a>
                    <div class="clear"></div>
                </header>
            </div>
            <!-----script------------->
            <script type="text/javascript" src="js/menu.js"></script>

            <div class="slider" id="home">

                <div class="wrap">
                    <!---start-da-slider----->
                    <div id="da-slider" class="da-slider">
                      <%--  <div class="da-slide">
                            <p>Can you build the Website of my dreams?</p>
                            <h2>Yup<img src="images/coma.png" alt="">
                                we can do that<img src="images/dot.png" alt=""></h2>
                            <a href="#" class="da-link">Learn More</a>
                        </div>
                        <div class="da-slide">
                            <p>Can you build the Website of my dreams?</p>
                            <h2>Yup<img src="images/coma.png" alt="">
                                we can do that<img src="images/dot.png" alt=""></h2>
                            <a href="#" class="da-link">Learn More</a>
                        </div>
                        <div class="da-slide">
                            <p>Can you build the Website of my dreams?</p>
                            <h2>Yup<img src="images/coma.png" alt="">
                                we can do that<img src="images/dot.png" alt=""></h2>
                            <a href="#" class="da-link">Learn More</a>

                        </div>
                        <div class="da-slide">
                            <p>Can you build the Website of my dreams?</p>
                            <h2>Yup<img src="images/coma.png" alt="">
                                we can do that<img src="images/dot.png" alt=""></h2>
                            <a href="#" class="da-link">Learn More</a>

                        </div>--%>
                    </div>

                    <script type="text/javascript" src="js/jquery.cslider.js"></script>
                    <!---strat-slider---->
                    <link rel="stylesheet" type="text/css" href="css/slider.css" />
                    <script type="text/javascript" src="js/modernizr.custom.28468.js"></script>
                    <script type="text/javascript">
                        $(function () {

                            $('#da-slider').cslider({
                                autoplay: true,
                                bgincrement: 450
                            });

                        });
                    </script>
                    <!---//End-da-slider----->
                </div>
            </div>
        </div>
    </div>
    <!-- scroll_top_btn -->
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear'
            };


            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>

    <!---smoth-scrlling---->
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
            });
        });
    </script>
</body>
</html>
