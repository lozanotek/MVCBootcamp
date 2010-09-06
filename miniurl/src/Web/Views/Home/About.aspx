<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    miniurl :: about
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>So...</h2>
    <p>
        Just a sample <a href="http://www.asp.net/mvc">ASP.NET MVC</a> application that shows the power of routing!
    </p>
</asp:Content>
