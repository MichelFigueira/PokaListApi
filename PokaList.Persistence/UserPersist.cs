using Microsoft.EntityFrameworkCore;
using PokaList.Domain.Identity;
using PokaList.Persistence.Contexts;
using PokaList.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokaList.Persistence
{
    public class UserPersist : DefaultPersist, IUserPersist
    {
        private readonly PokaListContext _context;

        public UserPersist(PokaListContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName.ToLower());
        }

    }
}
