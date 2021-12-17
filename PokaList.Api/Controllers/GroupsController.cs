using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using System;
using System.Threading.Tasks;

namespace PokaList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var groups = await _groupService.GetAllGroupsAsync();
                if (groups == null) return NoContent();

                return Ok(groups);
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
                var group = await _groupService.GetGroupByIdAsync(id);
                if (group == null) return NoContent();

                return Ok(group);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupDto model)
        {
            try
            {
                var group = await _groupService.AddGroup(model);
                if (group == null) return NoContent();

                return Ok(group);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GroupDto model)
        {
            try
            {
                var group = await _groupService.UpdateGroup(id, model);
                if (group == null) return NoContent();

                return Ok(group);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex}");
            }
        }
    }
}
