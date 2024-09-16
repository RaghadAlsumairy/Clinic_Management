﻿namespace ClinicManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
