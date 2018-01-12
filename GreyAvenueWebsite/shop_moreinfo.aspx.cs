using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (INFO.currentUser.usertype.Equals("customer"))
            {
                loginText.Text = "My Account";
                loginLink.NavigateUrl = "myaccount.aspx";
            }
            else
            {
                loginText.Text = "Login";
                loginLink.NavigateUrl = "login.aspx";
            }
        }
        catch
        {
            loginText.Text = "Login";
            loginLink.NavigateUrl = "login.aspx";
        }

        LoadBrandData();
        DisplayData();
    }

    string productname = "";
    string price = "";
    string description = "";
    string imageurl = "";
    List<string> size = new List<string>();

    protected void LoadBrandData()
    {
        productname = INFO.selectedProduct.productname;
        price = DATABASE.GETDATA.whereField("tbl_products", "price", "name", productname);
        description = DATABASE.GETDATA.whereField("tbl_products", "description", "name", productname);
        imageurl = DATABASE.GETDATA.whereField("tbl_products", "imageurl", "name", productname);
        //size = DATABASE.GETDATA.whereFieldAll("tbl_products", "size", "name", productname);
    }

    protected void DisplayData()
    {
        Panel mainPanel = new Panel();
        Label productnameLbl = new Label();
        Label priceLbl = new Label();
        Label descriptionLbl = new Label();
        Image productImage = new Image();
        Button addToCartBtn = new Button();


        productnameLbl.Text = productname;
        productnameLbl.BackColor = System.Drawing.Color.FromArgb(29, 29, 29);
        productnameLbl.ForeColor = System.Drawing.Color.White;
        productnameLbl.Style.Add("text-align", "center");
        productnameLbl.Style.Add("font-size", "25px");
        productnameLbl.Width = Unit.Percentage(70);

        priceLbl.Text = "Price : " + price;
        priceLbl.BackColor = System.Drawing.Color.Black;
        priceLbl.ForeColor = System.Drawing.Color.White;
        priceLbl.Style.Add("text-align", "center");
        priceLbl.Style.Add("font-size", "25px");
        priceLbl.Width = Unit.Percentage(30);

        productImage.ImageUrl = imageurl;
        productImage.BackColor = System.Drawing.Color.WhiteSmoke;
        productImage.Width = Unit.Percentage(100);
        productImage.Style.Add("padding-left", "100px");
        productImage.Style.Add("padding-right", "100px");
        productImage.Height = 500;

        descriptionLbl.Text = description;
        descriptionLbl.Height = Unit.Percentage(100);
        descriptionLbl.BackColor = System.Drawing.Color.FromArgb(29, 29, 29);
        descriptionLbl.ForeColor = System.Drawing.Color.White;
        descriptionLbl.Style.Add("font-size", "20px");
        descriptionLbl.Style.Add("text-align", "justify");


        addToCartBtn.Text = "ADD TO CART";
        addToCartBtn.Style.Add("font-weight", "bolder");
        addToCartBtn.Width = Unit.Percentage(100);
        addToCartBtn.Height = 50;
        addToCartBtn.ID = productname;
        addToCartBtn.Click += new EventHandler(addToCartEvent);
        

        mainPanel.CssClass = "col-sm-12 col-lg-12 col-md-12 moreInfoPanel";
        mainPanel.Controls.Add(productnameLbl);
        mainPanel.Controls.Add(priceLbl);
        mainPanel.Controls.Add(productImage);
        mainPanel.Controls.Add(descriptionLbl);
        mainPanel.Controls.Add(addToCartBtn);
        mainDiv.Controls.Add(mainPanel);
    }

    protected void addToCartEvent(object sender, EventArgs e)
    {
        string passString = productname;
        try
        {
            if (INFO.currentUser.usertype.Equals("customer"))
            {
                INFO.addToCart.customerid = INFO.currentUser.id;
                INFO.addToCart.productname = passString;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Log in')", true);
                return;
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Log in')", true);
            return;
        }
        DATABASE.INSERT.everything("tbl_cart");
        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Done')", true);
    }

    protected void myCart_Click(object sender, EventArgs e)
    {
        try
        {
            if (INFO.currentUser.usertype == "customer")
            {
                Response.Redirect("shop_mycart.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Log in')", true);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Log in')", true);
        }
    }


}