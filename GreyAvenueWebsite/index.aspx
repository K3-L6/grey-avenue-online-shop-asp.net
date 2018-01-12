<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
        <title>Grey Avenue Online Shop</title>
        <link rel="stylesheet" href="css/bootstrap.min.css">
        <script src="js/jquery.min.js"></script>
        <link rel="stylesheet" href="css/main.css">
        <script src="js/bootstrap.min.js"></script>
</head>
<body class="main">

         <!--NAVIGATION BAR-->
        <nav class="navbar navbar-inverse">  
            <div class="container-fluid mainNavBox">
                
                <div class="navbar-header">
                  
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        
                        <span class="glyphicon glyphicon-th"></span>
                    
                    </button>
                  
                    <img src="img/logo.png" width="550" height="80">
                
                </div>

                <div class="collapse navbar-collapse" id="myNavbar">
                  
                    <ul class="nav navbar-nav navbar-right">
                        
                        <li class="navItems"><a href="index.aspx"><span class="glyphicon glyphicon-home"></span>Home</a></li>
                        
                        <li class="navItems"><a href="about.aspx"><span class="glyphicon glyphicon-info-sign"></span>About Us</a></li>
                        
                        <li class="navItems"><a href="shop.aspx"><span class="glyphicon glyphicon-shopping-cart"></span>Shop</a></li>
                        
                        <li class="navItems"><asp:HyperLink ID="loginLink" NavigateUrl="#" runat="server"><span class="glyphicon glyphicon-user"></span>
                        <asp:Label ID="loginText" runat="server" Text="Login"></asp:Label></asp:HyperLink></li>
                        
                    </ul>
                    
                </div>    
            </div>
        </nav>
        <!--NAVIGATION BAR END-->
        
        <!--MAIN-->
        <div class="container-fluid mainIndex">
            <!--CAROUSEL START-->
            <div class="col-md-8 col-md-offset-2">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="img/cs1.jpg" class="img-thumbnail">
                        </div>

                        <div class="item">
                            <img src="img/cs2.jpg" class="img-thumbnail">
                        </div>

                        <div class="item">
                            <img src="img/cs3.jpg" class="img-thumbnail">
                        </div>

                        <div class="item">
                            <img src="img/cs4.jpg" class="img-thumbnail">
                        </div>

                        <div class="item">
                            <img src="img/cs5.jpg" class="img-thumbnail">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--MAIN END-->

</body>
</html>
