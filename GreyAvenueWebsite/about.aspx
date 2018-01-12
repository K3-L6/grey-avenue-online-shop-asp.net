<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

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
        
        <!--MAIN-->
        <div class="container-fluid mainAbout">
            <div class="col-md-5 col-md-offset-1">
                <h1>ABOUT US</h1><hr>
            </div>
            <!--ABOUT US-->
            <div class="row">
                <div class="col-md-6 col-md-offset-1">
                    <img src="img/frontStore2.jpg" class="img-circle">
                </div>
                
                <div class="col-md-4">
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque mattis lectus molestie libero laoreet porttitor. In vehicula ac elit luctus vestibulum. Etiam nisl ante, gravida et congue eget, convallis id purus. Mauris porttitor dui arcu, vitae hendrerit felis gravida non. Curabitur feugiat vel nisl sit amet aliquam. Donec efficitur leo fermentum porta faucibus. Sed eleifend non urna non semper. Etiam pellentesque commodo lacinia. Nulla vitae laoreet sem, et euismod ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas nec ullamcorper nunc, eu sodales sapien. Morbi ornare dignissim magna eget sagittis. Praesent sodales mi lectus, vitae luctus leo rhoncus id. Curabitur pharetra arcu sapien, et mollis orci vehicula et. Nam ligula lectus, molestie in ultrices a, scelerisque a libero.</p>
                </div>
            </div>
            
            <div class="col-md-5 col-md-offset-1">
                <h1>CONTACT US</h1><hr>
            </div>
            <!--CONTACT US-->
            <div class="row">  
                <div class="col-md-6 col-md-offset-1">
                    <h5>
                        <strong>CELL NUMBER</strong><br>
                        +63 917 813 0083<br><br>
                        <strong>LANDLINE NUMBER</strong><br>
                        +63 2 697 8515<br><br>
                        <strong>EMAIL</strong><br>
                        greyavenueph@yahoo.com<br>
                    </h5>
                </div>
                
                <div class="col-md-4">
                    <img src="img/frontStore.jpg" class="img-circle">
                </div>
            </div>
            
            <div class="col-md-5 col-md-offset-1">
                <h1>LOCATION</h1><hr>
            </div>
            <!--LOCATION-->
            <div class="row">  
                <div class="col-md-8 col-md-offset-2">
                    <div class="bs-example" data-example-id="responsive-embed-16by9-iframe-youtube">
                            <div class="embed-responsive embed-responsive-16by9">
	                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d965.3787380040674!2d120.99152648799065!3d14.569707999360759!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3397c981984fa347%3A0x33b8245a0cf750f1!2s2106+Taft%2C+Malate%2C+Manila%2C+1004+Metro+Manila!5e0!3m2!1sen!2sph!4v1474747664071" width="800" height="600" frameborder="0" style="border:0" allowfullscreen></iframe>
                            </div>
                        </div>
                </div>
            </div>
            
        </div>
        <!--MAIN END-->

</body>
</html>
