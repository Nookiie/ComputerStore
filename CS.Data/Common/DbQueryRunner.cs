using ComputerStore.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Data.Common
{
    public class DbQueryRunner
    {
        public DbQueryRunner(ComputerStoreDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ComputerStoreDbContext Context { get; set; }

        public async void RunQueryAsync(string query, params object[] parameters)
        {
            await this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }
    }
}
