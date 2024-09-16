using ClinicManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Data
{
    
    public class DataSeeder
    {
        public static void Seed(ClinicDbContext context)
        {
            if (!context.Patients.Any())
                context.Database.ExecuteSqlRaw(@"
            INSERT INTO Patients ( IdNumber, Name, Email, PhoneNumber) VALUES
            ( '1023456', 'Ahmad Al-Harbi', 'ahmad.alharbi@example.com', '0555001234'),
            ( '1123456', 'Fatima Al-Farsi', 'fatima.alfarsi@example.com', '0551235678'),
            ( '1123456', 'Omar Al-Shehri', 'omar.alshehri@example.com', '0505128765');
        ");
        }
    }

}
