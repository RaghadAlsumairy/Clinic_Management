using ClinicManagement.Application.Services.patients;
using ClinicManagement.Models;
using ClinicManagement.Utitlity;
using ClinicManagementAPI.Application.Dtos;
using ClinicManagementAPI.Data;
using ClinicManagementAPI.Repositories.Interfaces;
using Mapster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.ObjectPool;

namespace ClinicManagement.Application.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly ClinicDbContext _context;
        private readonly IPatientServices _patientServices;

        public AppointmentServices(ClinicDbContext context, IPatientServices patientServices)
        {
            _context = context;
            _patientServices = patientServices;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByCritiera(AppointmentsFilter filter)
        {
            var appointments = await _context.Appointments
                .FromSqlRaw(SQLStatments.GetAppointments,
                    new SqlParameter("@PatientId", (object)filter.PatientId ?? DBNull.Value),
                    new SqlParameter("@PatientIdNumber", (object)filter.PatientIdNumber ?? DBNull.Value),
                    new SqlParameter("@PatientName", (object)filter.PatientName ?? DBNull.Value),
                    new SqlParameter("@Date", filter.Date.HasValue ? filter.Date.Value.Date : DBNull.Value)) // Handle nullable DateTime
                .ToListAsync();

            var patientIds = appointments.Select(a => a.PatientId).Distinct();

            var patients = await _patientServices.GetPatientsByIdsAsync(patientIds);

            var patientDict = patients.ToDictionary(p => p.Id, p => p.Name);

            var appointmentDtos = appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                Date = a.Date,
                Note = a.Note,
                IsActive = a.IsActive,
                PatientId = a.PatientId,
                PatientName = patientDict.TryGetValue(a.PatientId, out var name) ? name : string.Empty
            }).ToList();
            return appointmentDtos;
        }

    }
}
