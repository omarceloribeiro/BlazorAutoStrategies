using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Core.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : ModelBase
    {
        Task<TEntity> Create(TEntity model);
        Task<TEntity> Read(int id);
        Task<TEntity> Update(TEntity model);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> ReadAll();
    }
}
