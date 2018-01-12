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
            List<string> id = DATABASE.GETDATA.everything("tbl_customers", "id");
            List<string> username = DATABASE.GETDATA.everything("tbl_customers", "username");
            List<string> password = DATABASE.GETDATA.everything("tbl_customers", "password");
            List<string> lastname = DATABASE.GETDATA.everything("tbl_customers", "lastname");
            List<string> firstname = DATABASE.GETDATA.everything("tbl_customers", "firstname");
            List<string> contactnumber = DATABASE.GETDATA.everything("tbl_customers", "contactnumber");
            List<string> email = DATABASE.GETDATA.everything("tbl_customers", "email");

            for (int x = 0; x < username.Count; x++)
            {
                if (usernameFld.Text.Equals(username[x]) && passwordFld.Text.Equals(password[x]))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Login Complete')", true);
                    INFO.currentUser.usertype = "customer";
                    INFO.currentUser.id = id[x];
                    INFO.currentUser.username = username[x];
                    INFO.currentUser.password = password[x];
                    INFO.currentUser.lastname = lastname[x];
                    INFO.currentUser.firstname = firstname[x];
                    INFO.currentUser.contactnumber = contactnumber[x];
                    INFO.currentUser.email = email[x];
                    Response.Redirect("shop.aspx");
                }
            }

        }
    }

    Boolean validInput()
    {
        if (usernameFld.Text.Equals("") || passwordFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }
        return true;
    }


}