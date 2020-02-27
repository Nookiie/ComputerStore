using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Services
{
    public interface IService<TEntity>
        where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> All();
    }
}
