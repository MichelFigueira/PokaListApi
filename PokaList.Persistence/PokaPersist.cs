﻿
using Microsoft.EntityFrameworkCore;
using PokaList.Domain;
using PokaList.Persistence.Contexts;
using PokaList.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Poka[]> GetAllPokasAsync()
        {
            IQueryable<Poka> query = _context.Pokas
                .Include(x => x.Group);

            query = query.OrderBy(x => x.Id);

            return await query.ToArrayAsync();
            
        }
        public async Task<Poka> GetPokaByIdAsync(int pokaId)
        {
            IQueryable<Poka> query = _context.Pokas
                .Where(x => x.Id == pokaId)
                .Include(x => x.Group);

            query = query.OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }     
    }
}
