using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Students;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Journal.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await service.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                return Ok(await service.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] StudentCreateDto createDto)
        {
            
            return Ok(await service.CreateAsync(createDto));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            try
            {
                return Ok(await service.DeleteByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromForm] StudentCreateDto studentdto)
        {
            try
            {
                return Ok(await service.UpdateByIdAsync(id, studentdto));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
