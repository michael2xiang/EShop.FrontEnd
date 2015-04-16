using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory);
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory);
        void Commit();
    }
}
