using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public class GenericService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        private readonly ComputerStoreDbContext _context;
        private readonly GenericRepository<TEntity> _repo;

        public GenericService(ComputerStoreDbContext context)
        {
            this._context = context;
            this._repo = new GenericRepository<TEntity>(context);
        }

        public IEnumerable<TEntity> All() => this._repo.All();

        public async Task<TEntity> GetByID(int id) => await _repo.GetByIdAsync(id); 

        public async Task<TEntity> Create(TEntity entity)
        {
            await _repo.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _repo.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByID(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            _repo.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _repo.Delete(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByID(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            _repo.Delete(entity);
            await _context.SaveChangesAsync();
        }
    }
}
