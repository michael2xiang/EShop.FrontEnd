using System.Collections.Generic;
using EShop.FrontEnd.Services.ViewModels;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class GetProductsByCategoryResponse
    {
        public string SelectedCategoryName { get; set; }
        public int SelectedCategoryId { get; set; }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }

        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductSummaryView> products { get; set; }
    }
}
