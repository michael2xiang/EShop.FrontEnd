using System;
using EShop.FrontEnd.Core.UnitOfWork;
using NHibernate;

namespace EShop.FrontEnd.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(Core.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(Core.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(Core.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepsoityory)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {

                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
