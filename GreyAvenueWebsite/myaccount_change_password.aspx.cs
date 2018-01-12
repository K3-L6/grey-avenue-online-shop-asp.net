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


    protected void changeBtn_Click(object sender, EventArgs e)
    {
        if (InputValid())
        {
            DATABASE.UPDATE.byfield("tbl_customers", "password", INFO.currentUser.id, newFld.Text);
            INFO.currentUser.password = newFld.Text;
            Response.Redirect("myaccount.aspx");
        }
    }

    Boolean InputValid()
    {
        if (newFld.Text.Equals("") || oldFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        if (!oldFld.Text.Equals(INFO.currentUser.password))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Old Password Incorrect')", true);
            return false;
        }
        
        if (newFld.Text.Length < 8 || newFld.Text.Length > 24)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Password length should be more than 8 but not greater than 24')", true);
            return false;
        }

        if (!newFld.Text.Equals(rnewFld.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Password Does not Match')", true);
            return false;
        }

        return true;
    }

}