using System.Collections.Generic;
using EShop.FrontEnd.Core.Querying;
using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Model.Categories;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow)
            : base(uow)
        { 
        }

        public IEnumerable<Category> FindBy(Query query)
        {
            throw new System.NotImplementedException();
        }
    }
}
