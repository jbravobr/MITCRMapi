using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Repository
{
    public class CRMContext<T>: DbContext where T : class
    {
        public DbSet<T> DBEntity { get; set; }

        public CRMContext(DbContextOptions<CRMContext<T>> options) : base(options) { }
    }
}