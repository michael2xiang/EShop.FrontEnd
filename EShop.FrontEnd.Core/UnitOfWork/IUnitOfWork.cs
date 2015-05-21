using EShop.FrontEnd.Core.Domain;

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
