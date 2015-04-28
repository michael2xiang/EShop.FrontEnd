using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Model.Products;
using NHibernate;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public class ProductRepository:Repository<Product,int>,IProductRepository
    {
        public ProductRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override void AppendCriteria(ICriteria criteriaQuery)
        {
            criteriaQuery.CreateAlias("Title", "ProductTitle");
            criteriaQuery.CreateAlias("ProductTitle.Category", "Category");
            criteriaQuery.CreateAlias("ProductTitle.Brand", "Brand");
            criteriaQuery.CreateAlias("ProductTitle.Color", "Color");
        }
    }
}
