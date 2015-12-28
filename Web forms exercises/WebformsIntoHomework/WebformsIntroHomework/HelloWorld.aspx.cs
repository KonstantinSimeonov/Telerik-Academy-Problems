namespace WebformsIntroHomework
{
    using System;

    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitName_Click(object sender, EventArgs e)
        {
            this.lblName.Text = "Hello, " + this.tbName.Text;
        }
    }
}