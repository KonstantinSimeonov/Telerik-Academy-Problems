namespace Calculator
{
    using System;
    using System.Web.UI.WebControls;

    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalcBtnClick(object sender, CommandEventArgs e)
        {
            if (this.ViewState["first"] == null)
            {
                this.ViewState["first"] = "";
                this.tbResult.Text = "";
            }

            this.ViewState["first"] += e.CommandArgument as string;
            this.tbResult.Text += e.CommandArgument as string;
        }

        protected void Operation(object sender, CommandEventArgs e)
        {
            this.ViewState["operation"] = e.CommandArgument as string;

            if(this.ViewState["first"] == null)
            {
                if(this.tbResult.Text != string.Empty)
                {
                    this.ViewState["first"] = this.tbResult.Text;
                }
                else
                {
                    return;
                }
            }

            if (this.ViewState["operation"] == "sr")
            {
                this.Evaluate(sender, e);
            }

            this.ViewState["second"] = this.ViewState["first"];
            this.ViewState["first"] = null;
        }

        protected void Clear(object sender, EventArgs e)
        {
            this.tbResult.Text = "";
            this.ViewState["first"] = null;
            this.ViewState["second"] = null;
            this.ViewState["operation"] = null;
        }

        protected void Evaluate(object sender, EventArgs e)
        {
            var operation = this.ViewState["operation"] as string;

            if(operation == null)
            {
                return;
            }

            double result;

            if (operation == "sr")
            {
                if(this.ViewState["first"] == null)
                {
                    return;
                }

                result = Math.Sqrt(double.Parse(this.ViewState["first"] as string));
            }
            else
            {
                var second = double.Parse(this.ViewState["first"] as string);
                var first = double.Parse(this.ViewState["second"] as string);

                switch (operation)
                {
                    case "+":
                        result = first + second;
                        break;
                    case "-":
                        result = first - second;
                        break;
                    case "X":
                        result = first * second;
                        break;
                    case "/":
                        result = first / second;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            this.ViewState["first"] = null;
            this.ViewState["second"] = null;
            this.ViewState["operation"] = null;

            this.tbResult.Text = result.ToString();
        }
    }
}