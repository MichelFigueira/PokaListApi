using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PokaList.Domain.Enum;

namespace PokaList.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }
        public string About { get; set; }
        public string PhotoURL { get; set; }
        public byte[] PhotoBytes { get; set; }
        public string StatusText { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        public int? LoveUserId { get; set; }
        public bool socialLogin { get; set; }
    }
}
