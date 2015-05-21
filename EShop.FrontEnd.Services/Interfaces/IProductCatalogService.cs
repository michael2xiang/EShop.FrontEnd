using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;

namespace EShop.FrontEnd.Services.Interfaces
{
    public interface IProductCatalogService
    {
        GetFeatureProductsResponse GetFeatureProducts();
        GetProductsByCategoryResponse GetProductByCategory(GetProductsByCategoryRequest request );

        GetProductResponse GetProduct(GetProductRequest requset);

        GetAllCategoriesResponse GetAllCategories();
    }
}
