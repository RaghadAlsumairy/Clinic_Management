using ClinicManagementAPI.Application.Dtos;

namespace ClinicManagement.Application.Services
{
    public interface IAppointmentServices
    {
        public Task<IEnumerable<AppointmentDto>> GetAppointmentsByCritiera(AppointmentsFilter filter);

    }
}
