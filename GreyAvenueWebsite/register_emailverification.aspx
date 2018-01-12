<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register_emailverification.aspx.cs" Inherits="register" %>

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

        <div class="container-fluid mainRegister">
            <div class="col-md-8 col-md-offset-2 registerWindow">
                <form runat="server">

                    <div class="header">
                        <h1>EMAIL VERIFICATION</h1>
                    </div>

                    <div class="content">

                        <h1><span class="glyphicon glyphicon-chevron-right">Verification Code</h1>
                        <asp:TextBox ID="codeFld" runat="server" class="fld"></asp:TextBox><br>

                        <asp:Button ID="registerBtn" runat="server" Text="Submit" class="btn" OnClick="registerBtn_Click"/>
                        <asp:Button ID="resendBtn" runat="server" Text="Resend Verification Code" class="btn" OnClick="resendBtn_Click" BackColor="WindowFrame" ForeColor="Black"/>
                    </div>

                </form>
            </div>
        </div>



</body>
</html>
