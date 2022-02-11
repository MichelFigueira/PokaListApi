using PokaList.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace PokaList.Application.Dtos
{
    public class PokaDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Title { get; set; }
        public Status Status { get; set; }
        public DateTime? DateFinished { get; set; }
        public bool Favorite { get; set; }
        public string Description { get; set; }
        [Required]
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
