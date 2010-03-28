<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeVM>" %>
<%@ Import Namespace="BA.MultiMvc.Sample.Models.ViewModel"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Resources["Home.Title"] %>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Model.Resources["Home.Title"] %></h1>
    <h2><%= Html.Encode(Model.Message) %></h2>
    <p>
        To learn more about ASP.NET Mvc visit <a href="http://asp.net/mvc" title="ASP.NET Mvc Website">http://asp.net/mvc</a>.
    </p>
</asp:Content>
