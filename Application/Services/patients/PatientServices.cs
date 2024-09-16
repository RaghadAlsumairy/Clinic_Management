using ClinicManagement.Models;
using ClinicManagementAPI.Application.Dtos;
using ClinicManagementAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace ClinicManagement.Application.Services.patients
{
    public class PatientServices :IPatientServices
    {
        private readonly ClinicDbContext _context;

        public PatientServices(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsByIdsAsync(IEnumerable<int> ids)
        {
            var patients = await _context.Patients
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();

            // Manually map Patient to PatientDto
            var patientDtos = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
            });

            return patientDtos;
        }

    }
}
