using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokaList.Api.Extensions;
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
        private readonly IUserService _userService;

        public GroupsController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var groups = await _groupService.GetAllGroupsAsync(User.GetUserId());
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
                var group = await _groupService.GetGroupByIdAsync(User.GetUserId(), id);
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
                var group = await _groupService.AddGroup(User.GetUserId(), model);
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
                var group = await _groupService.UpdateGroup(User.GetUserId(), id, model);
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
