using ClinicManagement.Models;
using ClinicManagementAPI.Application.Dtos;

namespace ClinicManagement.Application.Services.patients
{
    public interface IPatientServices
    {
        Task<IEnumerable<PatientDto>> GetPatientsByIdsAsync(IEnumerable<int> ids);
    }
}
