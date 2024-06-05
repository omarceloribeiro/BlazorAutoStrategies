using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorAuto.WithServices.DataEF.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : ModelBase
        
    {
        protected AppDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        protected RepositoryBase(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public async ValueTask<TEntity> Create(TEntity model)
        {
            DbSet.Add(model);
            await DbContext.SaveChangesAsync();
            return model;
        }

        public async ValueTask Delete(int id)
        {
            var model = await DbSet.FindAsync(id);
            if (model != null)
            {
                DbSet.Remove(model);
                await DbContext.SaveChangesAsync();
            }
        }

        public ValueTask<TEntity?> Read(int id)
        {
            return DbSet.FindAsync(id);
        }

        public async ValueTask<IEnumerable<TEntity>> ReadAll()
        {
            var query = DbSet.AsNoTracking();
            query = DefaultIncludes(query);
            return await query.ToListAsync();
        }

        public async ValueTask<TEntity> Update(TEntity model)
        {
            DbContext.ChangeTracker.Clear();
            //DbSet.Entry(model).State = EntityState.Modified;
            DbSet.Attach(model).State = EntityState.Modified;
            //DbSet.Update(model);
            await DbContext.SaveChangesAsync();
            return model;
        }

        protected virtual IQueryable<TEntity> DefaultIncludes(IQueryable<TEntity> query)
        {
            return query;
        }
    }
}
