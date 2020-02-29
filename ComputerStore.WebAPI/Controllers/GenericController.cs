using BrunoZell.ModelBinding;
using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using ComputerStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _service.All();
        }

        [HttpGet("[action]/{id}")]
        public virtual async Task<TEntity> GetByID(int id)
        {
            return await _service.GetByID(id);
        }

        [HttpPost]
        [Route("[action]")]
        public virtual async Task<string> Create(TEntity entity)
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
        public virtual async Task<string> DeleteByID(int id)
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
        public virtual async Task Update(TEntity entity)
        {
            await _service.Update(entity);
        }

        [HttpPost("[action]")]
        public virtual async Task<string> ImportJSON(
            [ModelBinder(BinderType = typeof(JsonModelBinder))] string fileValues,
                IList<IFormFile> files)
        {
            IList<string> debugMessages = new List<string>();
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (var file in files)
                {
                    using (StreamReader streamReader = new StreamReader(file.OpenReadStream()))
                    using (JsonTextReader jsonReader = new JsonTextReader(streamReader))
                    {
                        fileValues = JToken.ReadFrom(jsonReader).ToString();
                    }

                    var products = JsonConvert.DeserializeObject<IList<TEntity>>(fileValues);

                    foreach (var product in products)
                    {
                        await _service.Create(product);
                    }

                    debugMessages.Add(string.Format("JSON file:{0} imported successfully \n", file.FileName));
                }
            }
            catch (Exception e)
            {
                return "Error, could not import JSON file: " + e.StackTrace + e.Message;
            }
            finally
            {
                foreach (var message in debugMessages)
                {
                    sb.Append(message);
                }
            }

            return sb.ToString();
        }
    }
}
