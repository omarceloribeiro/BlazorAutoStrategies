using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Data.Repositories
{
    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : ModelBase
    {
        public Task<TEntity> Create(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
