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

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        if (validInput())
        {
            string newpassword = createRandomNumberPassword();
            string username = DATABASE.GETDATA.whereField("tbl_customers", "username", "email", mailFld.Text);
            EMAIL.grey.send(mailFld.Text, "Grey Avenue Forgot Password", "Hi \n This is your new Login Info \n Username : "+username+" \n Password : " + newpassword);
            DATABASE.UPDATE.bymail("tbl_customers", "password", mailFld.Text, newpassword);
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Check your email for your new password')", true);
            Response.Redirect("index.aspx");
        }
    }

    protected string createRandomNumberPassword()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000000);
        string s = x.ToString("000000000");
        return s;
    }

    Boolean validInput()
    {
        if (mailFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        List<string> emailData = DATABASE.GETDATA.everything("tbl_customers", "email");
        Boolean emailExist = false;
        foreach (string x in emailData)
        {
            if (x.Equals(mailFld.Text))
            {
                emailExist = true;
            }
        }

        if (!emailExist)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Email is not registered')", true);
            return false;
        }

        return true;
    }


}