using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumberGenerator
{
    public partial class RandomNumberGenerator : System.Web.UI.Page
    {
        private static readonly Random rng = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var min = int.Parse(this.tbMin.Text);
            var max = int.Parse(this.tbMax.Text);

            this.lblResult.Text = "Number: " + rng.Next(min, max);
        }
    }
}