using CakeWalk.DAL.Entity;
using CakeWalk.DAL.Entity.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace CakeWalk.DAL
{
    public partial class CakeWalkDBContext : DbContext
    {
        public CakeWalkDBContext()
        {

        }

        public CakeWalkDBContext(DbContextOptions<CakeWalkDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>();
            modelBuilder.Entity<ErrorLog>();
        }
    }
}
