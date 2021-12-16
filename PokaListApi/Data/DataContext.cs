using Microsoft.EntityFrameworkCore;
using PokaListApi.Models;

namespace PokaListApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Poka> Pokas { get; set; }
    }
}
