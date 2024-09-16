using ClinicManagement.Models;
using ClinicManagementAPI.Repositories.Interfaces;
using Mapster;
using MediatR;

namespace ClinicManagementAPI.Application.Commands.Appointments
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        private readonly ICrudRepository<Appointment> _apponitmentRepository;

        public CreateAppointmentCommandHandler(ICrudRepository<Appointment> apponitmentRepository)
        {
            _apponitmentRepository = apponitmentRepository;
        }
        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var entity =  request.Adapt<Appointment>();

            await _apponitmentRepository.Add(entity);
            

            return Unit.Value;

        }
    }
}
