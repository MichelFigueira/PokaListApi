﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokaList.Application.Dtos
{
    public class GroupDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Title { get; set; }
        public IEnumerable<PokaDto> Pokas { get; set; }
    }
}
