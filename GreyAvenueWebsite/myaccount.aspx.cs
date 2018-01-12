using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lastnameFld.Text = INFO.currentUser.lastname;
        firstnameFld.Text = INFO.currentUser.firstname;
        contactFld.Text = INFO.currentUser.contactnumber;
        emailFld.Text = INFO.currentUser.email;
        usernameFld.Text = INFO.currentUser.username;
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
        catch {
            loginText.Text = "Login";
            loginLink.NavigateUrl = "login.aspx";
        }
    }
    
    protected void logOutBtn_Click(object sender, EventArgs e)
    {
        INFO.currentUser.usertype = "";
        INFO.currentUser.id = "";
        INFO.currentUser.username = "";
        INFO.currentUser.password = "";
        INFO.currentUser.lastname = "";
        INFO.currentUser.firstname = "";
        INFO.currentUser.contactnumber = "";
        INFO.currentUser.email = "";
        Response.Redirect("index.aspx");
    }
}