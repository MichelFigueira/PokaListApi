using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokaList.Application.Contracts;
using PokaList.Domain;
using PokaList.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokaList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokasController : ControllerBase
    {
        private readonly IPokaService _pokaService;

        public PokasController(IPokaService pokaService)
        {
            _pokaService = pokaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pokas = await _pokaService.GetAllPokasAsync();
                if (pokas == null) return NotFound();

                return Ok(pokas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var poka = await _pokaService.GetPokaByIdAsync(id);
                if (poka == null) return NotFound();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Poka model)
        {
            try
            {
                var poka = await _pokaService.AddPoka(model);
                if (poka == null) return BadRequest();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int pokaId, Poka model)
        {
            try
            {
                var poka = await _pokaService.UpdatePoka(pokaId, model);
                if (poka == null) return BadRequest();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }
    }
}
