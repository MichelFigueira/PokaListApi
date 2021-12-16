using PokaList.Persistence.Contexts;
using PokaList.Persistence.Contracts;
using System.Threading.Tasks;

namespace PokaList.Persistence
{
    public class DefaultPersist : IDefaultPersist
    {
        private readonly PokaListContext _context;

        public DefaultPersist(PokaListContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }   
    }
}
