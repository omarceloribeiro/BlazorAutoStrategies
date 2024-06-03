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

        public virtual Task<TEntity> Create(TEntity model)
        {
            return Repository.Create(model);
        }

        public virtual Task Delete(int id)
        {
            return Repository.Delete(id);
        }

        public virtual Task<TEntity> Read(int id)
        {
            return Repository.Read(id);
        }

        public virtual Task<IEnumerable<TEntity>> ReadAll()
        {
            return Repository.ReadAll();
        }

        public virtual Task<TEntity> Update(TEntity model)
        {
            return Repository.Update(model);
        }
    }
}
