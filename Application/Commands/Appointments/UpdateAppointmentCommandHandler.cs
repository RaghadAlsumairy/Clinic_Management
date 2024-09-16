using ClinicManagement.Models;
using ClinicManagementAPI.Repositories.Interfaces;
using Mapster;
using MediatR;

namespace ClinicManagement.Application.Commands.Appointments
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
    {
        private readonly ICrudRepository<Appointment> _appointmentrepository;

        public UpdateAppointmentCommandHandler(ICrudRepository<Appointment> appointmentrepository)
        {
            _appointmentrepository = appointmentrepository;
        }

        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment appointment = await _appointmentrepository.GetById(request.Id);
            if (appointment != null)
            {
                appointment.Note = request.Note;
                appointment.IsActive = false;
                await _appointmentrepository.UpdateAsync(appointment);
            }
         
            return Unit.Value;
        }
    }
}
