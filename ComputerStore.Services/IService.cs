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

        Task Delete(TEntity entity);

        Task Update(TEntity entity);

        IEnumerable<TEntity> All();
    }
}
