using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokaList.Api.Extensions;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using PokaList.Persistence.Models;
using System;
using System.Threading.Tasks;

namespace PokaList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokasController : ControllerBase
    {
        private readonly IPokaService _pokaService;
        private readonly IUserService _userService;

        public PokasController(IPokaService pokaService, IUserService userService)
        {
            _pokaService = pokaService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            try
            {
                var pokas = await _pokaService.GetAllPokasAsync(User.GetUserId(), pageParams);
                if (pokas == null) return NoContent();

                Response.AddPagination(pokas.CurrentPage, pokas.PageSize, pokas.TotalCount, pokas.TotalPages);

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
                var poka = await _pokaService.GetPokaByIdAsync(User.GetUserId(), id);
                if (poka == null) return NoContent();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PokaDto model)
        {
            try
            {
                var poka = await _pokaService.AddPoka(User.GetUserId(), model);
                if (poka == null) return NoContent();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PokaDto model)
        {
            try
            {
                var poka = await _pokaService.UpdatePoka(User.GetUserId(), id, model);
                if (poka == null) return NoContent();

                return Ok(poka);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }
    }
}
