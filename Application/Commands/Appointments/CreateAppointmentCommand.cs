using MediatR;

namespace ClinicManagementAPI.Application.Commands.Appointments
{
    public class CreateAppointmentCommand : IRequest
    {
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; } = true;
        public int PatientId { get; set; }

    }

}
