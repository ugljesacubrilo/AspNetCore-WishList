﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Model;

namespace WishList.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly DbContextOptions dbContextOptions;

        public ApplicationDbContext(
            DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public DbSet<Item> Items { get; set; }
    }
}
