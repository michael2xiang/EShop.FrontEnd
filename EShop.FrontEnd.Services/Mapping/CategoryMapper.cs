using System.Collections.Generic;
using AutoMapper;
using EShop.FrontEnd.Model.Categories;
using EShop.FrontEnd.Services.ViewModels;

namespace EShop.FrontEnd.Services.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(categories);

        }
    }
}
