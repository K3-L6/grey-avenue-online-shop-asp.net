using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
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
    }

    

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        List<string> finalSize = new List<string>();
        for(int x = 0; x < INFO.checkout.productname.Count; x++)
        {
            List<string> size = new List<string>();
            size.Clear();
            size = DATABASE.GETDATA.whereFieldAllAnd("tbl_cart", "size", "productname ", INFO.checkout.productname[x], "customerid", INFO.currentUser.id);

            foreach (string xx in size)
            {
                finalSize.Add(xx);
            }
        }

        EMAIL.grey.send(INFO.currentUser.email, "Grey Avenue Order Update", "Hi " + INFO.currentUser.firstname + " " + INFO.currentUser.lastname + "\nThank you for using Grey Avenue Online System\nYour order is now on process");

        for (int z = 0; z < INFO.checkout.productname.Count; z++)
        {
            Response.Write(INFO.checkout.productname[z] + " " + finalSize[z] + " " + INFO.currentUser.id + "<br>");
        }

        if (validInput())
        {
            string paymentType = "";
            string address = addFld.Text.ToUpper();
            
            if (cashRd.Checked)
            {
                paymentType = "CASH";
            }
            else if (creditRd.Checked)
            {
                paymentType = "CREDIT";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Select a payment type')", true);
                return;
            }
            string orderID = randomID();
            //check duplicate id here
            DATABASE.INSERT.orders(orderID, INFO.currentUser.id, addFld.Text, paymentType, INFO.checkout.productname, finalSize);
            DATABASE.DELETE.deleteByID("tbl_cart", INFO.currentUser.id);
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Thank you')", true);
            Response.Redirect("shop_mycart.aspx");
        }

        

    }

    string randomID()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string year = DateTime.Now.Year.ToString();
        string month = "";
        if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
        {
            month = "0" + DateTime.Now.Month.ToString();
        }
        else
        {
            month = DateTime.Now.Month.ToString();
        }
        string id = year + "-" + month + "-" + x.ToString("000000");
        return id;
    }

    Boolean checkID(string id)
    {
        Boolean c = true;
        List<string> idData = DATABASE.GETDATA.everything("tbl_products", "id");
        foreach (string x in idData)
        {
            if (x.Equals(id))
            {
                c = false;
            }
        }
        return c;
    }


    Boolean validInput()
    {
        if (addFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete the form')", true);
        }
        return true;
    }


}