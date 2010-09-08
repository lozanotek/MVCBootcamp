<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<part2_Templates.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="home/create" method="post">
        <%
            Html.RenderPartial("PersonPartial", Model);%>
        <input type="submit" value="Save" id="saveButton" />
    </form>
</asp:Content>
