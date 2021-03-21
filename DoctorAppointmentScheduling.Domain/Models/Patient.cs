namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Patient : User
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
