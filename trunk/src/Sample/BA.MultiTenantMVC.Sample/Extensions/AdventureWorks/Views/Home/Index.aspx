<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="BA.MultiTenantMVC.Sample.Views.Home.IndexView" %>
<%@ Import Namespace="BA.MultiTenantMVC.Sample.Models.ViewModel"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Resources["Home.Title"] %>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Model.Resources["Home.Title"] %></h1>
    <h2><%= Html.Encode(Model.Message) %></h2>
    <p>
        This is the substitute view
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
</asp:Content>
