namespace EventDump
{
    using System;

    public partial class Events : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("<ol>");
            Response.Write("<li>" + "Page_PreInit invoked" + "</li>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_Init invoked" + "</li>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_PreLoad invoked" + "</li>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_Load invoked" + "</li>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_LoadComplete invoked" + "</li>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_PreRender invoked" + "</li>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_PreRenderComplete invoked" + "</li>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            Response.Write("<li>" + "Page_SaveStateComplete invoked" + "</li>");
            Response.Write("</ol>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // the page no longer exists
        }
    }
}