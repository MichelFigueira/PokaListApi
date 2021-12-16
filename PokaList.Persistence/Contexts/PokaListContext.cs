using Microsoft.EntityFrameworkCore;
using PokaList.Domain;

namespace PokaList.Persistence.Contexts
{
    public class PokaListContext : DbContext
    {
        public PokaListContext(DbContextOptions<PokaListContext> options) : base(options) { }

        public DbSet<Poka> Pokas { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
