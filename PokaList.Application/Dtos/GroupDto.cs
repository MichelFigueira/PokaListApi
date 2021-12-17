using System.Collections.Generic;

namespace PokaList.Application.Dtos
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<PokaDto> Pokas { get; set; }
    }
}
