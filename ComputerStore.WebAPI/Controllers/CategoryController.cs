﻿using ComputerStore.Data.Data;
using ComputerStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.WebAPI.Controllers
{
    public class CategoryController : GenericController<Category>
    {
        public CategoryController(ComputerStoreDbContext context) : base(context)
        {

        }
    }
}
