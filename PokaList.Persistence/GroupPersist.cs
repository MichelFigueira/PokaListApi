
using Microsoft.EntityFrameworkCore;
using PokaList.Domain;
using PokaList.Persistence.Contexts;
using PokaList.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace PokaList.Persistence
{
    public class GroupPersist : IGroupPersist
    {
        private readonly PokaListContext _context;

        public GroupPersist(PokaListContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<Group[]> GetAllGroupsAsync(int userId)
        {
            IQueryable<Group> query = _context.Groups;

            query = query
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }       

        public async Task<Group> GetGroupByIdAsync(int userId, int groupId)
        {
            IQueryable<Group> query = _context.Groups
                .Where(x => x.Id == groupId && x.UserId == userId);

            query = query.OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();

        }        
    }
}
