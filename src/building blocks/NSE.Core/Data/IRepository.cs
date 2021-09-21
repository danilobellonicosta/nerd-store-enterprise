using NSE.Core.DomainObjetcs;
using System;

namespace NSE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAgregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
