using System.Collections.Generic;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Services.ViewModels;
using AutoMapper;
namespace EShop.FrontEnd.Services.Mapping
{
   public static class ProductTitleMapper
    {
       public static IEnumerable<ProductSummaryView> ConverToProductviews(this IEnumerable<ProductTitle> products)
       {
           return Mapper.Map<IEnumerable<ProductTitle>, IEnumerable<ProductSummaryView>>(products);
       }

       public static ProductView ConvertToProductDetailView(this ProductTitle product)
       {
           return Mapper.Map<ProductTitle, ProductView>(product);
       }
    }
}
