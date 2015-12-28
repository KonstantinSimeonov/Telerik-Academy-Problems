namespace HellpWebForms
{
    using System;
    using System.Web.UI;

    public partial class Hello : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblName.Text = "Hello, " + this.tbName.Text;
        }
    }
}