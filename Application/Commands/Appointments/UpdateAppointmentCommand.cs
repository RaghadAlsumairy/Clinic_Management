using MediatR;

namespace ClinicManagement.Application.Commands.Appointments
{
    public class UpdateAppointmentCommand : IRequest
    {
        public int Id { get; set; }
        public string Note { get; set; }
    }
}
