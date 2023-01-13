using Main_Project.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main_Project.Data
{
    public class AplContext : IdentityDbContext<User>
    {
        public AplContext()
        {
              //Database.EnsureDeleted();   // удаляем бд со старой схемой
              //Database.EnsureCreated();   // создаем бд с новой схемой
        }

        public DbSet<User> Users { get; set; }


        public AplContext(DbContextOptions<AplContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //user
            /* modelBuilder.Entity<Users>()
                 .HasKey(e => new { e.Id });
             modelBuilder.Entity<Users>()
                 .HasMany(o => o.order);*/




            var user = new User()
            {
                Fullname = "Test",
                PhoneNumber = "0114422545",
                Email = "Test@gmail.com",
                PasswordHash = "dGVzdFBhc193b3Jk",
                PhoneNumberConfirmed = false,
                EmailConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                LockoutEnd = DateTime.Now,
                UserName = "test"
            };

            modelBuilder.Entity<User>().HasData(user);
        }
    }
}

