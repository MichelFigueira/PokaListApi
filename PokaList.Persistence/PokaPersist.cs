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
                             x.TitlePtBr.ToLower().Contains(pageParams.Term.ToLower()) ||
                             x.Group.Title.ToLower().Contains(pageParams.Term.ToLower())) &&
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

            {
                var newGroup = new Group { Title = "Custom", TitlePtBr = "Personalizado", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                newGroup = new Group { Title = "Pleasures", TitlePtBr = "Prazeres", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Walking Barefoot on the Beach", TitlePtBr = "Andar descalço na areia da praia", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Balloon Fly", TitlePtBr = "Voar de balão", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Pedal Boat", TitlePtBr = "Andar de pedalinho", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Bathe in Waterfall", TitlePtBr = "Tomar banho de cachoeira", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "See the Sunrise", TitlePtBr = "Ver o nascer do sol", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Food", TitlePtBr = "Comidas", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Drink a cold beer in the afternoon", TitlePtBr = "Beber um chopp bem gelado a tardinha", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Eating the Outback Onion", TitlePtBr = "Comer a cebola do Outback", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Coffee in bed", TitlePtBr = "Tomar café na cama", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

            }

        }
    }
}
