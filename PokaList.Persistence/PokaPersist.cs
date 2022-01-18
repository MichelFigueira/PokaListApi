using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokaList.Domain;
using PokaList.Persistence.Contexts;
using PokaList.Persistence.Contracts;
using PokaList.Persistence.Models;

namespace PokaList.Persistence
{
    public class PokaPersist : IPokaPersist
    {
        private readonly PokaListContext _context;

        public PokaPersist(PokaListContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<PageList<Poka>> GetAllPokasAsync(int userId, PageParams pageParams)
        {
            IQueryable<Poka> query = _context.Pokas
                .Include(x => x.Group);

            query = query
                .Where(x => (x.Title.ToLower().Contains(pageParams.Term.ToLower()) ||
                             x.Description.ToLower().Contains(pageParams.Term.ToLower())) &&
                             x.UserId == userId)
                .OrderBy(e => e.Id);

            return await PageList<Poka>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
            
        }
        public async Task<Poka> GetPokaByIdAsync(int userId, int pokaId)
        {
            IQueryable<Poka> query = _context.Pokas
                .Where(x => x.UserId == userId && x.Id == pokaId)
                .Include(x => x.Group);

            query = query.OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
