using System;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
