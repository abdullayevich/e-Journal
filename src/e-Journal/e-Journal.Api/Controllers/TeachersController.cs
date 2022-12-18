using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Teachers;
using EJournal.Service.Dtos;
using EJournal.Service.Dtos.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Journal.Api.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await teacherService.GetAllAsync());
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
                return Ok(await teacherService.GetByIdAsync(id));
            }
            catch
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromForm] TeacherCreateDto teacher)
        {
            try
            {
                return Ok(await teacherService.CreateAsync(teacher));
            }
            catch
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(long id)
        {
            try
            {
                return Ok(await teacherService.DeleteByIdAsync(id));
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateById(long id, [FromForm] TeacherCreateDto teacher)
        {
            try
            {
                return Ok(await teacherService.UpdateByIdAsync(id, teacher));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
