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
        public void CreateDefaultPokas(int userId, int countryId)
        {

            if (countryId == 2)
            {

                var newGroup = new Group { Title = "Prazeres", UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Andar descalço na areia da praia", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Voar de balão", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Andar de pedalinho", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Tomar banho de cachoeira", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ver o nascer do sol", Description = "", GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Comidas", UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Beber um chopp bem gelado a tardinha", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Comer a cebola do Outback", Description = "", GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Tomar café na cama", Description = "", GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

            }

        }
    }
}
