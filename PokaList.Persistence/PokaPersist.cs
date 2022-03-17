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

                newGroup = new Group { Title = "Feelings", TitlePtBr = "Prazeres", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Ride a limousine", TitlePtBr = "Andar de Limousine", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Play at a casino", TitlePtBr = "Jogar em um cassino", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to a sex shop", TitlePtBr = "Ir a um sex shop", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a motorcycle", TitlePtBr = "Andar de moto", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Boating", TitlePtBr = "Passear de barco", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a jetski", TitlePtBr = "Andar de jetski", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to spa", TitlePtBr = "Ir a um spa", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Dance", TitlePtBr = "Dançar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Skiing", TitlePtBr = "Esquiar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a old buggy", TitlePtBr = "Andar de charrete", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Discover a winery", TitlePtBr = "Conhecer uma vinícola", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to an observatory", TitlePtBr = "Ir em um observatório", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "See a fight", TitlePtBr = "Ver uma luta", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a cable car", TitlePtBr = "Andar de bondinho", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Do a good deed", TitlePtBr = "Fazer uma boa ação", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to the circus", TitlePtBr = "Ir ao circo", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to a costume party", TitlePtBr = "Ir a uma festa a fantasia", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Having sex in a risky place", TitlePtBr = "Fazer sexo em um local arriscado", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to an amusement park", TitlePtBr = "Ir a um parque de diversões", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go down on a waterslide", TitlePtBr = "Descer em um toboágua", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Walk hand in hand", TitlePtBr = "Andar de mãos dadas", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a speedboat", TitlePtBr = "Andar de lancha", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a buggy on the dunes", TitlePtBr = "Andar de buggy nas dunas", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a roller coaster", TitlePtBr = "Andar de montanha russa", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Rida a karting", TitlePtBr = "Andar de kart", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Riding a quad", TitlePtBr = "Andar de quadriciclo", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Sing in a karaoke", TitlePtBr = "Cantar em um karaokê", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Take dance class", TitlePtBr = "Fazer aula de dança", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to a rock concert", TitlePtBr = "Ir a um show de rock", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Swim in the pool", TitlePtBr = "Nadar na piscina", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Toasting an event with champagne", TitlePtBr = "Brindar um acontecimento com champanhe", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a train", TitlePtBr = "Andar de trem", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a bike", TitlePtBr = "Andar de bicicleta", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Celebrate dating anniversary", TitlePtBr = "Comemorar aniversário de namoro", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Photo book", TitlePtBr = "Book de fotos", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Dinner by candlelight", TitlePtBr = "Jantar a luz de velas", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Watch a theatrical presentation", TitlePtBr = "Assistir uma peça de teatro", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to the cinema", TitlePtBr = "Ir ao cinema", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Ride a helicopter", TitlePtBr = "Andar de helicóptero", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go on a cruise", TitlePtBr = "Fazer um cruzeiro", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Drink a cold beer in the afternoon", TitlePtBr = "Beber um chopp bem gelado a tardinha", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go to the zoo", TitlePtBr = "Ir ao zoológico", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Pedal boat", TitlePtBr = "Andar de pedalinho", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Balloon fly", TitlePtBr = "Voar de balão", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Watch a game in a stadium", TitlePtBr = "Assistir um jogo em um estádio", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Go by airplane", TitlePtBr = "Andar de Avião", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Home", TitlePtBr = "Comidas", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Pillow war", TitlePtBr = "Guerra de travesseiro", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Paint a room in the house", TitlePtBr = "Pintar um cômodo da casa", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Spend the day in bed", TitlePtBr = "Passar o dia na cama", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "To cook", TitlePtBr = "Cozinhar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Get under the covers in the cold", TitlePtBr = "Ficar debaixo das cobertas no frio", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Bathe together", TitlePtBr = "Tomar banho juntos", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Coffee in bed", TitlePtBr = "Tomar café na cama", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Food", TitlePtBr = "Comidas", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Have a good wine", TitlePtBr = "Tomar um bom vinho", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Eat japanese food", TitlePtBr = "Comer comida japonesa", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Drink tequila", TitlePtBr = "Tomar tequila", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Eat mexican food", TitlePtBr = "Comer comida mexicana", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Eat cotton candy", TitlePtBr = "Comer algodão doce", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Eat Pop corn", TitlePtBr = "Comer pipoca", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Nature", TitlePtBr = "Comidas", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Bathing in a natural pool", TitlePtBr = "Tomar banho em uma piscina natural", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Horseback riding", TitlePtBr = "Andar à cavalo", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Run in the rain", TitlePtBr = "Correr na chuva", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Bathe in the sea", TitlePtBr = "Tomar banho de mar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Discover a cave", TitlePtBr = "Conhecer uma caverna ou gruta", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "To camp", TitlePtBr = "Acampar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "See the sunset", TitlePtBr = "Ver o pôr-do-sol", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Climb a mountain", TitlePtBr = "Subir uma montanha", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Plant a tree", TitlePtBr = "Plantar uma árvore", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Kiss in the rain", TitlePtBr = "Beijar na chuva", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Trail", TitlePtBr = "Trilha", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Play in the snow", TitlePtBr = "Brincar na neve", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Dive in the sea", TitlePtBr = "Mergulhar no mar", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "See the sunrise", TitlePtBr = "Ver o nascer do sol", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Bathe in waterfall", TitlePtBr = "Tomar banho de cachoeira", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Walking barefoot on the beach", TitlePtBr = "Andar descalço na areia da praia", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Have a picnic", TitlePtBr = "Fazer um piquenique", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

                newGroup = new Group { Title = "Trip", TitlePtBr = "Comidas", Default = true, UserId = userId };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();

                _context.Pokas.AddRange(
                    new Poka { Title = "Traveling by car along the coast", TitlePtBr = "Viajar de carro pelo litoral", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Get married in las vegas", TitlePtBr = "Casar em Las Vegas", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Stay in a 5 star hotel", TitlePtBr = "Hospedar-se em um hotel 5 estrelas", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Stay in a chalet", TitlePtBr = "Hospedar-se em um chalé", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Travel to a farm hotel", TitlePtBr = "Viajar para um hotel fazenda", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Being a tourist in your own city", TitlePtBr = "Ser turista em sua própria cidade", Default = true, GroupId = newGroup.Id, UserId = userId },
                    new Poka { Title = "Backpacking in Europe", TitlePtBr = "Mochilão na Europa", Default = true, GroupId = newGroup.Id, UserId = userId }
                 );
                _context.SaveChanges();

            }

        }
    }
}
