using FirstCoreAppExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreAppExample.Data
{
    public class K100Context:DbContext
    {
        public K100Context(DbContextOptions<K100Context> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
