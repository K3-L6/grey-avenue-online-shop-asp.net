<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shop_womens_shorts.aspx.cs" Inherits="shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" lang="en">
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
        
        <div class="container">

        <div class="row">
            <div class="col-md-3" style="font-family:'MS Gothic'; font-size:20px; position:relative;">

                <button type="button" runat="server" onserverclick="myCart_Click" class="btn btn-default btn-block btn-lg"><span class="glyphicon glyphicon-shopping-cart"> MY CART</button> 
                <div class="li-group">
                    <h3 style="color:white; background-color:black; padding:5px;">WOMENS FASHION</h3>
                    <a href="shop_womens_dress.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> DRESS</a>
                    <a href="shop_womens_tops.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> TOPS</a>
                    <a href="shop_womens_pants.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> PANTS</a>
                    <a href="shop_womens_skirts.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> SKIRTS</a>
                    <a href="shop_womens_shorts.aspx" class="list-group-item active"><span class="glyphicon glyphicon-chevron-right"> SHORTS</a>
                    <a href="shop_womens_shoes.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> SHOES</a>
                </div>

                <div class="li-group">
                    <h3 style="color:white; background-color:black; padding:5px;">MENS FASHION</h3>
                    <a href="shop_mens_tops.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> TOPS</a>
                    <a href="shop_mens_pants.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> PANTS</a>
                    <a href="shop_mens_shorts.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> SHORTS</a>
                    <a href="shop_mens_shoes.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> SHOES</a>
                    <a href="shop_mens_bags.aspx" class="list-group-item"><span class="glyphicon glyphicon-chevron-right"> BAGS</a>
                </div>
            </div>

            <form runat="server">
            <div class="col-md-9">

                <div runat="server" id="mainDiv" class="row">
                    
                </div>

            </div>
            </form>

        </div>

    </div>    
    
        
        

</body>
</html>
