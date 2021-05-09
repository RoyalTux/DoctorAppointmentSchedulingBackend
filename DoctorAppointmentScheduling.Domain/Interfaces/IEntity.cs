namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
