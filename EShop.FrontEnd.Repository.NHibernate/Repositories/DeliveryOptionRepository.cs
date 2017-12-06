using EShop.FrontEnd.Model.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Core.UnitOfWork;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public class DeliveryOptionRepository : Repository<DeliveryOption, int>, IDeliveryOptionRepository
    {
        public DeliveryOptionRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
