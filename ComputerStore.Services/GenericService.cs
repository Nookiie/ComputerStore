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
        private readonly GenericRepository<TEntity> _categoryRepo;

        public GenericService(ComputerStoreDbContext context)
        {
            this._context = context;
            this._categoryRepo = new GenericRepository<TEntity>(context);
        }

        public IEnumerable<TEntity> All() => this._categoryRepo.All();

        public async Task<TEntity> GetByID(int id) => await _categoryRepo.GetByIdAsync(id); 

        public async Task<TEntity> Create(TEntity entity)
        {
            await _categoryRepo.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Update(TEntity entity)
        {
            _categoryRepo.Update(entity);
            _context.SaveChangesAsync();
        }

        public async void Delete(TEntity entity)
        {
            _categoryRepo.Delete(entity);
            await _context.SaveChangesAsync();
        }
    }
}
