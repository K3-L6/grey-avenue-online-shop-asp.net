<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

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
                        <h1>PERSONAL INFORMATION</h1>
                    </div>

                    <div class="content">
                        <h1><span class="glyphicon glyphicon-chevron-right">Last Name</h1>
                        <asp:TextBox ID="lastNameFld" runat="server" class="fld" MaxLength="50"></asp:TextBox><br>
                        <h1><span class="glyphicon glyphicon-chevron-right">First Name</h1>
                        <asp:TextBox ID="firstNameFld" runat="server" class="fld" MaxLength="50"></asp:TextBox><br>
                        <h1><span class="glyphicon glyphicon-chevron-right">Email</h1>
                        <asp:TextBox ID="emailFld" runat="server" class="fld" MaxLength="50" TextMode="Email"></asp:TextBox><br>
                        <h1><span class="glyphicon glyphicon-chevron-right">Contact Number</h1>
                        <asp:TextBox ID="contactFld" runat="server" class="fld" MaxLength="20" TextMode="Number"></asp:TextBox><br>
                        
                        <asp:Button ID="nextBtn" runat="server" Text="Next" class="btn" OnClick="nextBtn_Click"/>
                    </div>
                    
                </form>
            </div>
        </div>



</body>
</html>
