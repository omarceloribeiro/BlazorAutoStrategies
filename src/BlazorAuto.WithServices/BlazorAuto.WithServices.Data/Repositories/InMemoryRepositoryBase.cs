using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Data.Repositories
{
    internal abstract class InMemoryRepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : ModelBase
    {
        public ValueTask<TEntity> Create(TEntity model)
        {
            throw new NotImplementedException();
        }

        public ValueTask Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity?> Read(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<TEntity>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> Update(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
