using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class GenericService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected readonly ComputerStoreDbContext _context;
        protected readonly GenericRepository<TEntity> _repo;

        public GenericService(ComputerStoreDbContext context)
        {
            this._context = context;
            this._repo = new GenericRepository<TEntity>(context);
        }

        public virtual IEnumerable<TEntity> All() => this._repo.All();

        public virtual async Task<TEntity> GetByID(int id) => await _repo.GetByIdAsync(id); 

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await _repo.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            _repo.Update(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _repo.Delete(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByID(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            _repo.Delete(entity);

            await _context.SaveChangesAsync();
        }
    }
}
