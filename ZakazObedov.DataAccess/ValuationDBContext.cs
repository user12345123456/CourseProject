using Microsoft.EntityFrameworkCore;
using ZakazObedov.Entities;

namespace ZakazObedov.DataAccess
{
    public class ValuationDBContext: DbContext
    {
        public ValuationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
    }


}