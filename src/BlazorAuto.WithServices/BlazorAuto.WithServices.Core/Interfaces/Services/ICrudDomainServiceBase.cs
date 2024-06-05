using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Core.Interfaces.Services
{
    public interface ICrudDomainServiceBase<TEntity>
        where TEntity : ModelBase
    {
        ValueTask<TEntity> Create(TEntity model);
        ValueTask<TEntity?> Read(int id);
        ValueTask<TEntity> Update(TEntity model);
        ValueTask Delete(int id);
        ValueTask<IEnumerable<TEntity>> ReadAll();
    }
}
