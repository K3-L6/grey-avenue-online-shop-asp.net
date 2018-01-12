using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
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

    

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        if (InputValid())
        {
            DATABASE.UPDATE.byfield("tbl_customers", "email", INFO.currentUser.id, INFO.currentUser.email);
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Email Updated')", true);
            Response.Redirect("myaccount.aspx");
        }
    }

    protected void resendBtn_Click(object sender, EventArgs e)
    {
        EMAIL.grey.send(INFO.currentUser.email, "Grey Avenue Email Verification Code", "Hi " + INFO.currentUser.firstname + "\n\n We would like to verify your account here is your verification code that you can enter in our web page. Thank you\n\n" + "VERIFICATION CODE : " + createCode());
        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Another verification code is sended to your email')", true);
    }

    protected string createCode()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string s = x.ToString("000000");
        INFO.currentUser.code = s;
        return s;
    }
    
    Boolean InputValid()
    {
        if (codeFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        if (!codeFld.Text.Equals(INFO.currentUser.code))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Verification Code is Incorect')", true);
            return false;
        }

        
        return true;
    }
}