using Core.Models;

namespace Core.RepositoryInterfaces
{
    public interface IRepositoryBase
    {
        Task<ModelBase> Create(ModelBase model);
        Task<ModelBase> Read(ModelBase model);
        Task<ModelBase> Update(ModelBase model);
        Task Delete(ModelBase model);
        Task<IEnumerable<ModelBase>> ReadAll();
    }
}
