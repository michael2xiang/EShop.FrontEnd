using System.Collections.Generic;
using EShop.FrontEnd.Core.Querying;
using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Model.Products;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public class ProductTitleRepository : Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
