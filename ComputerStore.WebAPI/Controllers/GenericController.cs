﻿using BrunoZell.ModelBinding;
using ComputerStore.Common;
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
            service = new GenericService<TEntity>(context);
        }

        private readonly ComputerStoreDbContext _context;
        private readonly GenericService<TEntity> service;

        [HttpGet("[action]")]
        public virtual IEnumerable<TEntity> GetAll()
        {
            return service.All();
        }

        [HttpGet("[action]/{id}")]
        public virtual async Task<TEntity> GetByID(int id)
        {
            return await service.GetByID(id);
        }

        [HttpPost]
        [Route("[action]")]
        public virtual async Task<string> Create(TEntity entity)
        {
            try
            {
                await service.Create(entity);
                return GlobalConstants.DB_ENTITY_ADD_SUCCESS;
            }
            catch (Exception e)
            {
                return GlobalConstants.DB_ENTITY_ADD_FAIL + e.StackTrace + e.Message;
            }
        }

        [HttpDelete("[action]/{id}")]
        public virtual async Task<string> DeleteByID(int id)
        {
            var entity = service.GetByID(id);
            try
            {
                await service.DeleteByID(id);
                return GlobalConstants.DB_ENTITY_REMOVE_SUCCESS;
            }
            catch (Exception e)
            {
                return GlobalConstants.DB_ENTITY_REMOVE_FAIL + e.StackTrace;
            }
        }

        [HttpPut("[action]")]
        public virtual async Task<string> Update(TEntity entity)
        {
            try
            {
                await service.Update(entity);
                return GlobalConstants.DB_ENTITY_UPDATE_SUCCESS;
            }
            catch (Exception e)
            {
                return GlobalConstants.DB_ENTITY_UPDATE_FAIL + e.StackTrace + e.Message;
            }
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
                        await service.Create(product);
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
