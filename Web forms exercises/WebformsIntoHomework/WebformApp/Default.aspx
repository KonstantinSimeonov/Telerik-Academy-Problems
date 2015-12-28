<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebformApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Web Forms Architecture Explanation</h1>
    </div>

    <ul>
        <li>
            <h3>App_Data</h3>
            <p>holds references to any databases and data storages that our ASP.NET application uses.</p>
        </li>
        <li>
            <h3>App_Start</h3>
            <p>holds startup configuration for the application. The default configurations are <strong>bundling</strong>(minifying/uglifying/uniting javascript, css and font files),
                <strong>identity</strong>(authentication/registration configurations) and <strong>routes</strong>(configures the action that is executed when a page is accessed as an url).
            </p>
        </li>
        <li>
            <h3>Content</h3>
            <p>contains the style sheets for the application.</p>
        </li>
        <li>
            <h3>fonts</h3>
            <p>holds the app's fonts.</p>
        </li>
        <li>
            <h3>Models</h3>
            <p>is the folder in which is meant to contain the request and response models for the app. By default it holds an <strong>ApplicationUser</strong> model.</p>
        </li>
        <li>
            <h3>Default aspx pages</h3>
            <p>The <strong>About</strong>, <strong>Contact</strong> and <strong>Default</strong> pages come packed with the template project and form a sample application.</p>
        </li>
        <li>
            <h3>Site.Master</h3>
            <p>is a <a href="http://www.asp.net/web-forms/overview/older-versions-getting-started/master-pages/creating-a-site-wide-layout-using-master-pages-cs">master page</a>. All other pages in the application inherit its layout and reuse its components</p>
        </li>
        <li>
            <h3>Site.Mobile.Master</h3>
            <p>a master page that is visualized for mobile devices.</p>
        </li>
        <li>
            <h3>Global.asax</h3>
            <p>The entry point for the Web forms application. Calls methods from startup and configures them.</p>
        </li>
        <li>
            <h3>ViewSwitcher</h3>
            <p>allows switching between different master pages and views.</p>
        </li>
        <li>
            <h3>Web.config</h3>
            <p>is an XML file that allows security configuration, session state configuration, and changing the application language and compilation settings. Web.config files can also contain application specific items such as database connection strings.</p>
        </li>
    </ul>

</asp:Content>
