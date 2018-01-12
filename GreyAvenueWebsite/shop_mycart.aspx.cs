using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop : System.Web.UI.Page
{
    protected string userType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (INFO.currentUser.usertype.Equals("customer"))
            {
                loginText.Text = "My Account";
                loginLink.NavigateUrl = "myaccount.aspx";
                userType = "customer";
            }
            else
            {
                loginText.Text = "Login";
                loginLink.NavigateUrl = "login.aspx";
                userType = "guest";
            }
        }
        catch
        {
            loginText.Text = "Login";
            loginLink.NavigateUrl = "login.aspx";
        }

        LoadData();
        DisplayData();
    }


    List<string> productname = new List<string>();

    protected void LoadData()
    {
        productname = DATABASE.GETDATA.whereFieldAll("tbl_cart", "productname", "customerid", INFO.currentUser.id);
    }

    double priceTotal = 0;
    List<string> inputProductName = new List<string>();
    List<string> inputSize = new List<string>();
    List<string> inputImage = new List<string>();
    List<string> inputPrice = new List<string>();

    protected void DisplayData()
    {
        for (int x = 0; x < productname.Count; x++)
        {
            inputProductName.Add(productname[x]);
            inputImage.Add(DATABASE.GETDATA.whereField("tbl_products", "imageurl", "name", productname[x]));
            inputPrice.Add(DATABASE.GETDATA.whereField("tbl_products", "price", "name", productname[x]));

            Panel productPanel = new Panel();
            productPanel.Width = Unit.Percentage(100);
            productPanel.BorderColor = System.Drawing.Color.Black;
            productPanel.BorderStyle = BorderStyle.Solid;
            productPanel.BorderWidth = 5;
            productPanel.BackColor = System.Drawing.Color.FromArgb(29, 29, 29);

            Image productImage = new Image();
            productImage.ImageUrl = DATABASE.GETDATA.whereField("tbl_products", "imageurl", "name", productname[x]);
            productImage.Width = Unit.Percentage(20);
            productImage.Height = 150;

            Label productnameLbl = new Label();
            productnameLbl.Text = productname[x];
            productnameLbl.Style.Add("font-size", "18px");
            productnameLbl.Style.Add("font-weight", "bolder");
            productnameLbl.ForeColor = System.Drawing.Color.White;
            productnameLbl.Width = Unit.Percentage(50);
            productnameLbl.Style.Add("padding-left", "20px");

            Label priceLbl = new Label();
            priceLbl.Text = "Price : " + DATABASE.GETDATA.whereField("tbl_products", "price", "name", productname[x]);
            double price = Convert.ToDouble(DATABASE.GETDATA.whereField("tbl_products", "price", "name", productname[x]));
            priceTotal += price;

            priceLbl.Style.Add("font-size", "20px");
            priceLbl.BackColor = System.Drawing.Color.Black;
            priceLbl.Height = 50;
            priceLbl.ForeColor = System.Drawing.Color.White;
            priceLbl.Width = Unit.Percentage(30);
            priceLbl.Style.Add("padding", "15px");
            

            Label sizeLbl = new Label();
            sizeLbl.Text = "----- Available Size -----";
            sizeLbl.Style.Add("font-size", "20px");
            sizeLbl.BackColor = System.Drawing.Color.Black;
            sizeLbl.ForeColor = System.Drawing.Color.White;
            sizeLbl.Width = Unit.Percentage(30);
            sizeLbl.Style.Add("padding-left", "20px");

            DropDownList size = new DropDownList();
            size.AutoPostBack = true;
            size.Style.Add("font-size", "20px");
            size.Width = Unit.Percentage(20);
            size.ID = productname[x] + " size " + x.ToString();
            List<string> sizeAvailable = DATABASE.GETDATA.whereFieldAll("tbl_products", "size", "name", productname[x]);
            string type = DATABASE.GETDATA.whereField("tbl_products", "type", "name", productname[x]);
            size.Items.Add("Select Value");
            if (!type.Contains("BAGS"))
            {
                foreach (string sa in sizeAvailable)
                {
                    size.Items.Add(sa);
                }
            }
            else
            {
                size.Visible = false;
                sizeLbl.Visible = false;
            }
            size.SelectedValue = "Select Value";
            size.SelectedIndexChanged += new EventHandler(sizeSelectChange);

            productPanel.Controls.Add(productImage);
            productPanel.Controls.Add(productnameLbl);
            productPanel.Controls.Add(priceLbl);
            productPanel.Controls.Add(sizeLbl);
            productPanel.Controls.Add(size);

            mainDiv.Controls.Add(productPanel);
            
            
            Button deleteBtn = new Button();
            deleteBtn.Text = "Delete From Cart";
            deleteBtn.Style.Add("font-size", "15px");
            deleteBtn.Style.Add("margin-left", "680px");
            deleteBtn.Width = Unit.Percentage(20);
            deleteBtn.ID = productname[x] + " " + x.ToString();
            deleteBtn.Click += new EventHandler(deleteProduct);


            mainDiv.Controls.Add(deleteBtn);
        }

        Label totalLbl = new Label();
        totalLbl.Width = Unit.Percentage(100);
        totalLbl.BackColor = System.Drawing.Color.Black;
        totalLbl.Style.Add("text-align", "center");
        totalLbl.ForeColor = System.Drawing.Color.White;
        totalLbl.Style.Add("font-size", "30px");
        totalLbl.Text = "Price Total : " + priceTotal.ToString();
        totalLbl.BorderStyle = BorderStyle.Solid;
        totalLbl.BorderWidth = 5;
        totalLbl.BorderColor = System.Drawing.Color.White;


        Button checkOutBtn = new Button();
        checkOutBtn.Width = Unit.Percentage(100);
        checkOutBtn.ID = "chechOutBtn";
        checkOutBtn.Text = "CHECK OUT";
        checkOutBtn.Style.Add("font-size", "30px");
        checkOutBtn.Click += new EventHandler(checkoutevent);
        checkOutBtn.Height = 50;

        mainDiv.Controls.Add(totalLbl);
        mainDiv.Controls.Add(checkOutBtn);
        



    }


    protected void deleteProduct(object sender, EventArgs e)
    {
        Button b = sender as Button;
        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('"+ b.ID +"')", true);
        string remove = b.ID.Remove(b.ID.Length - 1);
        DATABASE.DELETE.deleteOne("tbl_cart", remove);
        Response.Redirect("shop_mycart.aspx");
    }

    protected void sizeSelectChange(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        string remove = ddl.ID.Remove(ddl.ID.Length - 7);
        string productName = remove.Replace(ddl.SelectedValue, "");
        string[] split = remove.Split(null);
        DATABASE.UPDATE.cartSize(INFO.currentUser.id, ddl.SelectedValue, productName);

    }

    protected void checkoutevent(object sender, EventArgs e)
    {
        if (priceTotal == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Cart is Empty')", true);
            return;
        }
        INFO.checkout.productname = inputProductName;
        INFO.checkout.price = inputPrice;
        INFO.checkout.imageurl = inputImage;
        Response.Redirect("checkout.aspx");
    }

}