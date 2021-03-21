namespace DoctorAppointmentScheduling.DataAccess.Models
{
    public class PatientDataEntity : UserDataEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
