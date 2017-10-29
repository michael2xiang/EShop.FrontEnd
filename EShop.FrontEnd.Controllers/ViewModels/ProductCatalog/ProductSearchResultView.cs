using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Controllers.ViewModels.ProductCatalog
{
    public class ProductSearchResultView:BaseProductCatalogPageView
    {
        public string SelectedCategortName { get; set; }
        public int SelectedCategory { get; set; }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        public int NumberOfTitlesFound { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ProductSummaryView> Products { get; set; }
        public int TotalNumberOfPages { get; set; }

        public ProductSearchResultView()
        {
            RefinementGroups = new List<RefinementGroup>();

        }
    }
}
