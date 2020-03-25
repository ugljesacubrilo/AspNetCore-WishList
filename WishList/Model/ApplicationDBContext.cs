using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WishList.Model
{
    public class ApplicationDBContext : DbContext
    {
        private readonly DbContextOptions dbContextOptions;

        public ApplicationDBContext(
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public DbSet<Item> Items { get; set; }
    }
}
