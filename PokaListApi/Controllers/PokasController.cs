using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokaListApi.Data;
using PokaListApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokaListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokasController : ControllerBase
    {
        private readonly DataContext _context;

        public PokasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Poka> Get()
        {
            return _context.Pokas;
        }

        [HttpGet("{id}")]
        public Poka GetById(int id)
        {
            return _context.Pokas.FirstOrDefault(poka => poka.Id == id);
        }
    }
}
