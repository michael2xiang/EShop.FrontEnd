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
    }
}
