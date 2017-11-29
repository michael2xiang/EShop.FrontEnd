using AutoMapper;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Model.Categories;
using EShop.FrontEnd.Services.ViewModels;
using EShop.FrontEnd.Core.Helpers;
using EShop.FrontEnd.Model.Shipping;
using EShop.FrontEnd.Model.Basket;

namespace EShop.FrontEnd.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();

            Mapper.CreateMap<Category, CategoryView>();

            Mapper.CreateMap<IProductAttribute, Refinement>();

            Mapper.AddFormatter<MoneyFormatter>();

            Mapper.CreateMap<DeliveryOption, DeliveryOptionView>();
            Mapper.CreateMap<BasketItem, BasketItemView>();
            Mapper.CreateMap<BasketModel, BasketView>();
        }

    }

    public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                decimal money = (decimal)context.SourceValue;
                return money.FormatMoney();
            }
            return context.SourceValue.ToString();

        }

    }
}
