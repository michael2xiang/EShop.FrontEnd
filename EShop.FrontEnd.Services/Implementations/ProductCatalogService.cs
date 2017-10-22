using EShop.FrontEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Model.Categories;

namespace EShop.FrontEnd.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductCatalogService(IProductTitleRepository productTitleRepository,
            IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productTitleRepository = productTitleRepository;
        }

        //TODO
        public GetAllCategoriesResponse GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public GetFeatureProductsResponse GetFeatureProducts()
        {
            throw new NotImplementedException();
        }

        public GetProductResponse GetProduct(GetProductRequest requset)
        {
            throw new NotImplementedException();
        }

        public GetProductsByCategoryResponse GetProductByCategory(GetProductsByCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
