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
    List<string> brandname = new List<string>();
    List<string> brandInProducts = new List<string>();

    protected void LoadBrandData()
    {
        id = DATABASE.GETDATA.everything("tbl_brands", "id");
        brandname = DATABASE.GETDATA.everything("tbl_brands", "brandname");
        brandInProducts = DATABASE.GETDATA.everything("tbl_products", "brand");
    }

    protected void DisplayData()
    {
        
        foreach (string x in brandname)
        {
            if (brandInProducts.Contains(x))
            {
                string imgurl = DATABASE.GETDATA.whereField("tbl_products", "imageurl", "brand", x);

                Panel pnl = new Panel();
                Button btn = new Button();
                Label lbl = new Label();
                Image img = new Image();

                pnl.BorderStyle = BorderStyle.Solid;
                pnl.CssClass = "col-sm-4 col-lg-4 col-md-4 brandPanel";
                

                lbl.Text = x;
                lbl.BackColor = System.Drawing.Color.Black;
                lbl.ForeColor = System.Drawing.Color.White;
                lbl.Style.Add("font-size", "20px");

                img.ImageUrl = imgurl;
                img.Width = Unit.Percentage(100);
                img.Attributes.Add("class", "myProductImage");
                btn.ID = x;
                btn.Text = "See More Products";
                btn.Width = Unit.Percentage(100);
                btn.Click += new EventHandler(seemoreBtn_Click);
                pnl.Controls.Add(lbl);
                pnl.Controls.Add(img);
                pnl.Controls.Add(btn);
                mainDiv.Controls.Add(pnl);



                //btn.Attributes.Add("OnClick", "seemoreBtn_Click");
                //mainDiv.Controls.Add(btn);

                //<asp:HyperLink ID="loginLink" NavigateUrl="#" runat="server">
                //< button type = ""button"" OnServerClick = ""seemoreBtn_Click"" class=""btn btn-primary btn-sm btn-block productBtn"">" + "See Products" + @"</button>          
                //<asp:Button ID="loginBtn" runat="server" Text="Login" class="btn" OnClick="loginBtn_Click"/>
            }
        }
        
    }

    protected void seemoreBtn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        INFO.selectedBrand.brandname = btn.ID;
        Response.Redirect("shop_brand_all.aspx");
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