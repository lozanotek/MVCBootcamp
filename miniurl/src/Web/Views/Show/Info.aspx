<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<miniUrl.Models.UrlEntity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  miniurl: url info
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    info for minimized url <%=Html.Encode(Request.ApplicationPath + Model.UrlHash) %>
  </h2>
  <p>
    Original Url:
    <a href="<%= Html.Encode(Model.Url) %>" target="_blank"><%= Html.Encode(Model.Url) %></a>
  </p>
  <p>
    Url: <a href="<%=Html.Encode(Request.ApplicationPath + Model.UrlHash) %>" target="_blank">
      <%=Html.Encode(Request.ApplicationPath + Model.UrlHash) %></a>
  </p>
  <p>Views:  <%= Model.Views%> </p>
  <p>
    Created:
    <%= Html.Encode(String.Format("{0:g}", Model.Created)) %>
  </p>
</asp:Content>
