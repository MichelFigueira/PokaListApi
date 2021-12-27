using PokaList.Domain.Identity;
using System.Collections.Generic;

namespace PokaList.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Poka> Pokas { get; set; }
    }
}
