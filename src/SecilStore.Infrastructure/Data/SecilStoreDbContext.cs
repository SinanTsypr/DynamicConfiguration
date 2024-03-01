using Microsoft.EntityFrameworkCore;
using SecilStore.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.Infrastructure.Data
{
    public class SecilStoreDbContext : DbContext
    {
        public SecilStoreDbContext(DbContextOptions<SecilStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Configuration> Configurations => Set<Configuration>();
    }
}
