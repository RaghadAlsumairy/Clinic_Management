using ClinicManagement.Models;
using ClinicManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly ICrudRepository<Patient> _repository;

        public PatientsController(ILogger<PatientsController> logger, ICrudRepository<Patient> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());

        }
    }
}
