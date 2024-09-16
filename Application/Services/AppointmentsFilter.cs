namespace ClinicManagement.Application.Services
{
    public class AppointmentsFilter
    {
        public int? PatientId { get; set; }
        public string? PatientIdNumber { get; set; }
        public string? PatientName { get; set; }

        public DateTime? Date {get; set; } 
    }
}
