using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Model.Basket;
using EShop.FrontEnd.Repository.NHibernate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public class BasketRepository :Repository<BasketModel,Guid>, IBasketRepository
    {
        public BasketRepository(IUnitOfWork uow) : base(uow)
        { }
    }
}
