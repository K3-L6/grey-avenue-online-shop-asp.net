<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myaccount_change_contact.aspx.cs" Inherits="_Default" %>

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
        <div class="mainMyaccount">
            
            <form runat="server">
                <div class="content col-md-8 col-md-offset-2">
                    <h1>Contact Number</h1>
                    <h1 style="font-size:15px;">Old</h1>
                    <asp:TextBox ID="oldFld" runat="server" class="fld" ReadOnly="true"></asp:TextBox>
                    <h1 style="font-size:15px;">New</h1>
                    <asp:TextBox ID="newFld" runat="server" class="fld" ReadOnly="false"></asp:TextBox>
                    
                    <asp:Button ID="changeBtn" style="" runat="server" Text="Submit" class="btn" OnClick="changeBtn_Click"/>
                </div>
            </form>
        </div>
        <!--MAIN END-->

</body>
</html>
