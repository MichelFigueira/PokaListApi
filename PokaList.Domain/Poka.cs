using PokaList.Domain.Enum;
using PokaList.Domain.Identity;
using System;

namespace PokaList.Domain
{
    public class Poka
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime? DateFinished { get; set; }
        public bool Favorite { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
