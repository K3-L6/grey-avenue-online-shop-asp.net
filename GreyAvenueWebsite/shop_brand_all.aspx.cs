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

    List<string> id = new List<string>();
    List<string> name = new List<string>();
    List<string> url = new List<string>();

    protected void LoadBrandData()
    {
        id = DATABASE.GETDATA.everything("tbl_products", "id");
        
        name = DATABASE.GETDATA.everything("tbl_products where brand = '"+ INFO.selectedBrand.brandname +"'", "DISTINCT name");
        url = DATABASE.GETDATA.everything("tbl_products where brand = '"+ INFO.selectedBrand.brandname +"'", "DISTINCT imageurl");
    }

    protected void DisplayData()
    {
        for (int x = 0; x < name.Count; x++)
        {
            Panel productPanel = new Panel();
            Button addToCartBtn = new Button();
            Button moreInfoBtn = new Button();
            Label titleLbl = new Label();
            Label priceLbl = new Label();
            Image img = new Image();


            productPanel.BorderStyle = BorderStyle.Solid;
            productPanel.CssClass = "col-sm-4 col-lg-4 col-md-4 brandPanel";

            string brand = DATABASE.GETDATA.whereField("tbl_products", "brand", "name", name[x]);
            string title = name[x].Replace(brand, "");
            titleLbl.Text = title;
            titleLbl.BackColor = System.Drawing.Color.Black;
            titleLbl.ForeColor = System.Drawing.Color.White;
            titleLbl.Style.Add("font-size", "15px");
            titleLbl.Style.Add("text-align", "center");

            string price = DATABASE.GETDATA.whereField("tbl_products", "price", "name", name[x]);
            priceLbl.Text = "Price : " + price;
            priceLbl.BackColor = System.Drawing.Color.WhiteSmoke;
            priceLbl.ForeColor = System.Drawing.Color.Black;
            priceLbl.Width = Unit.Percentage(100);
            priceLbl.Style.Add("font-size", "20px");
            priceLbl.Style.Add("text-align", "center");
            priceLbl.Style.Add("padding-right", "15px");

            img.ImageUrl = url[x];
            img.Width = Unit.Percentage(100);
            img.Attributes.Add("class", "myProductImage");

            moreInfoBtn.ID = name[x] + " moreInfoClick";
            moreInfoBtn.Text = "More Info";
            moreInfoBtn.Width = Unit.Percentage(70);
            moreInfoBtn.Click += new EventHandler(moreInfoBtn_Click);

            addToCartBtn.ID = name[x] + " addToCartClick";
            addToCartBtn.Text = "Add To Cart";
            addToCartBtn.Width = Unit.Percentage(30);
            addToCartBtn.Click += new EventHandler(addToCartBtn_Click);

            productPanel.Controls.Add(titleLbl);
            productPanel.Controls.Add(img);
            productPanel.Controls.Add(priceLbl);
            productPanel.Controls.Add(moreInfoBtn);
            productPanel.Controls.Add(addToCartBtn);
            mainDiv.Controls.Add(productPanel);

        }
    }

    protected void addToCartBtn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string passString = btn.ID.Replace("addToCartClick", "");
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

    protected void moreInfoBtn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string passString = btn.ID.Replace("moreInfoClick", "");
        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + passString + "')", true);
        INFO.selectedProduct.productname = passString;
        Response.Redirect("shop_moreinfo.aspx");
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