using System;
using System.Linq;
using BirthdayTracker.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BirthdayTracker.API.Data
{
    public class BirthdayContext : DbContext
    {
        public BirthdayContext(DbContextOptions<BirthdayContext> options)
            : base(options) { }

        public BirthdayContext() { }

        public DbSet<Birthday> Birthdays { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<BirthdayContext>();

                context.Database.EnsureCreated();

                if (context.Birthdays.Any()) return;

                context.Birthdays.AddRange(new Birthday[]
                {
                    new Birthday
                    {
                        Id = 1,
                        Name = "Jennifer Cook",
                        Birthdate = new DateTime(2018, 4, 21),
                        Email = "jcook@gmail.com",
                        Relationship = "Wife"
                    },
                    new Birthday
                    {
                        Id = 2,
                        Name = "Mary DeYeager",
                        Birthdate = new DateTime(2018, 2, 11),
                        Email = "mdeyeager@gmail.com",
                        Relationship = "Mother"
                    },
                    new Birthday
                    {
                        Id = 3,
                        Name = "Eric Currin",
                        Birthdate = new DateTime(2018, 9, 30),
                        Email = "ecurrin@gmail.com",
                        Relationship = "Friend"
                    }
                });

                context.SaveChanges();
            }
        }

    }
}
