namespace ClinicManagementAPI.Application.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
       public int PatientId { get; set; }
        public string PatientName { get; set;}
    }
}
