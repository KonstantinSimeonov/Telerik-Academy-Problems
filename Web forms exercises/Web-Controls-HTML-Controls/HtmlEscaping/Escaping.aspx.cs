using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlEscaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var encoded = Server.HtmlEncode(this.tbInput.Text);
            this.tbOutput.Text = encoded;
            this.lblOutput.Text = encoded;
        }
    }
}