namespace ClinicManagement.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Note { get; set; }
        public bool IsActive { get; set; } = true;
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
