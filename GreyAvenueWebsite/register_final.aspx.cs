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
            INFO.registrationCustomer.username = usernameFld.Text;
            INFO.registrationCustomer.password = passwordFld.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please check your email for the verification code')", true);
            EMAIL.grey.send(INFO.registrationCustomer.email, "Grey Avenue Email Verification Code", "Hi " + INFO.registrationCustomer.firstname + "\n\n We would like to verify your account here is your verification code that you can enter in our web page. Thank you\n\n" + "VERIFICATION CODE : " + createCode());
            Response.Redirect("register_emailverification.aspx");
        }
    }
    
    protected string createCode()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string s = x.ToString("000000");
        INFO.registrationCustomer.code = s;
        return s;
    }

    protected void saveToDatabase()
    {
        DATABASE.INSERT.everything("tbl_customers");
    }

    Boolean InputValid()
    {
        if (usernameFld.Text.Equals("") || passwordFld.Text.Equals("") || rpasswordFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        if (usernameFld.Text.Length < 8 || usernameFld.Text.Length > 24)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Username length should be more than 8 but not greater than 24')", true);
            return false;
        }

        List<string> usernameData = DATABASE.GETDATA.everything("tbl_customers", "username");
        Boolean usernameExist = false;
        foreach (string x in usernameData)
        {
            if (x.Equals(usernameFld.Text))
            {
                usernameExist = true;
            }
        }

        if (usernameExist)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Username is already registered')", true);
            return false;
        }

        if (passwordFld.Text.Length < 8 || passwordFld.Text.Length > 24)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Password length should be more than 8 but not greater than 24')", true);
            return false;
        }

        if (!passwordFld.Text.Equals(rpasswordFld.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Password does not match')", true);
            return false;
        }
        return true;
    }
}