using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Core.Services
{
    public abstract class CrudDomainServiceBase<TEntity> : ICrudDomainServiceBase<TEntity>
        where TEntity : ModelBase
    {
        protected IRepositoryBase<TEntity> Repository { get; }

        protected CrudDomainServiceBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual ValueTask<TEntity> Create(TEntity model)
        {
            return Repository.Create(model);
        }

        public virtual ValueTask Delete(int id)
        {
            return Repository.Delete(id);
        }

        public virtual ValueTask<TEntity?> Read(int id)
        {
            return Repository.Read(id);
        }

        public virtual ValueTask<IEnumerable<TEntity>> ReadAll()
        {
            return Repository.ReadAll();
        }

        public virtual ValueTask<TEntity> Update(TEntity model)
        {
            return Repository.Update(model);
        }
    }
}
