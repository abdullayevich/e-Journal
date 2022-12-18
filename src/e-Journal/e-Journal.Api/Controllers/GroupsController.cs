using EJournal.DataAcces.Interfaces;
using EJournal.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Journal.Api.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;
        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await groupService.GetAllAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                return Ok(await groupService.GetByIdAsync(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] GroupCreateDto createDto)
        {
            try
            {
                return Ok(await groupService.CreateAsync(createDto));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            try
            {
                return Ok(await groupService.DeleteByIdAsync(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromForm] GroupCreateDto dto)
        {
            try
            {
                return Ok(await groupService.UpdateByIdAsync(id,dto));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
