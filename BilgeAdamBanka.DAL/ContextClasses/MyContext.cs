using BilgeAdamBanka.CONF.Configurations;
using BilgeAdamBanka.DAL.BogusHandling;
using BilgeAdamBanka.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.DAL.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserCardInfoConfiguration());
            UserCardInfoDataSeed.SeedUserCardInfos(modelBuilder);
        }

        public DbSet<UserCardInfo> UserCardInfos { get; set; }
    }
}
