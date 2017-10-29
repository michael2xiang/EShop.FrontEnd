<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="EShop.FrontEnd.UI.Web.MVC.Views.Shared.Categories" %>
<%@ Import Namespace ="EShop.FrontEnd.Service.ViewModels"%>

<h2>Categories</h2>
<ul class="refine-attributes">						
<% foreach (CategoryView categoryView in Model) 
   { %> 
    <li><%= Html.ActionLink(categoryView.Name, "GetProductsByCategory", "Product", 
                                       new { categoryId = categoryView.Id }, null)%></li>                                        
<% }  %>				
</ul>