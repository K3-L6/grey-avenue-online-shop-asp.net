<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="login" %>

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

        <div class="container-fluid mainCheckout">
            <div class="col-md-8 col-md-offset-2 checkoutWindow">
                
                <form runat="server">
                
                    <h1><span class="glyphicon glyphicon-chevron-right">DELIVERY ADDRESS</h1>
                    <asp:TextBox ID="addFld" runat="server" class="fld"></asp:TextBox><br>
                    <h1><span class="glyphicon glyphicon-chevron-right">PAYMENT TYPE</h1><br>
                    <asp:RadioButton ID="cashRd" GroupName="payment" value="CASH" runat="server" /> Cash<br>
                    <asp:RadioButton ID="creditRd" GroupName="payment" value="CREDIT CARD" runat="server" /> Credit Card<br>
                    <asp:Button ID="loginBtn" runat="server" Text="Submit" class="btn" OnClick="submitBtn_Click"/><br>

                    
                </form>
            
            </div>
        </div>

</body>
</html>
