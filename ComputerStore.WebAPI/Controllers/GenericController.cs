using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Repositories.Implementations;
using ComputerStore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity> : BaseController
        where TEntity : class
    {
        public GenericController(ComputerStoreDbContext context)
        {
            this._context = context;
            _service = new GenericService<TEntity>(context);
        }

        private readonly ComputerStoreDbContext _context;
        private readonly GenericService<TEntity> _service;

        [HttpGet("[action]")]
        public IEnumerable<TEntity> GetAll()
        {
            return _service.All();
        }

        [HttpGet("[action]/{id}")]
        public async Task<TEntity> GetByID(int id)
        {
            return await _service.GetByID(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> Create(TEntity entity)
        {
            try
            {
                await _service.Create(entity);
                return "Entity has been saved to DB";
            }
            catch (Exception e)
            {
                return "Entity could not be saved to DB, Stack Trace: " + e.StackTrace;
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<string> DeleteByID(int id)
        {
            var entity = _service.GetByID(id);
            try
            {
                await _service.DeleteByID(id);
                return "Entity has been deleted from DB";
            }
            catch (Exception e)
            {
                return "Entity could not be deleted from DB, Stack Trace: " + e.StackTrace;
            }
        }

        [HttpPut("[action]")]
        public async Task Update(TEntity entity)
        {
            await _service.Update(entity);
        }
    }
}
