using System.ComponentModel.DataAnnotations;

namespace PokaList.Application.Dtos
{
    public class PokaDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}
