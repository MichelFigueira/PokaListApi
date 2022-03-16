using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokaList.Application.Dtos
{
    public class GroupDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Title { get; set; }
        public string TitlePtBr { get; set; }
        public bool Default { get; set; }
        public IEnumerable<PokaDto> Pokas { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
