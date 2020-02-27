using ComputerStore.Data.Data;
using ComputerStore.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(ComputerStoreDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected ComputerStoreDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public virtual Task<TEntity> GetByIdAsync(params object[] id) => this.DbSet.FindAsync(id).AsTask();

        public void Dispose() => this.Context.Dispose();

        public void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }
        
        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

    }
}
