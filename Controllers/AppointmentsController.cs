using ClinicManagement.Application.Commands.Appointments;
using ClinicManagement.Application.Services;
using ClinicManagementAPI.Application.Commands.Appointments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IMediator _mediator;

        private readonly IAppointmentServices _appointmentServices;

        public AppointmentsController(ILogger<AppointmentsController> logger, IMediator mediator, IAppointmentServices appointmentServices)
        {
            _logger = logger;
            _mediator = mediator;
            _appointmentServices = appointmentServices;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAppointmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAppointments ([FromQuery] AppointmentsFilter filter)
        {
            return  Ok(await _appointmentServices.GetAppointmentsByCritiera(filter));
        }

        [HttpPut]
        public async Task<ActionResult> CancelAppointment(UpdateAppointmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
