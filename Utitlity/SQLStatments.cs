using ClinicManagement.Models;

namespace ClinicManagement.Utitlity
{
    public static class SQLStatments
    {

        public static string GetAppointments =
           "SELECT Appointments.Id as Id, Appointments.Date as Date, Appointments.IsActive , Appointments.Note," +
            "Appointments.PatientId , Patients.Name as PatientName   " +
            " FROM Appointments left join Patients on Appointments.PatientId = Patients.Id  " +
           "WHERE (@PatientIdNumber IS NULL OR Patients.IdNumber = @PatientIdNumber) " +
            "AND (@PatientId IS NULL OR Patients.Id = @PatientId) " +
           "AND (@PatientName IS NULL OR Patients.Name = @PatientName) " +
           "AND @Date IS NULL OR CAST(Appointments.Date AS DATE) = @Date";

    }
}
