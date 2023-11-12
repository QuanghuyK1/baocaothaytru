namespace WEB_TTTN.Models
{
    public class ScheduleModels
    {
        public int Id { get; set; }
        public string Eventname { get; set; } = null!;
        public DateTime Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public int? Locationid { get; set; }
        public string? Locationname { get; set; }
        public string Description { get; set; } = null!;
        public int? Patientid { get; set; }
        public int? Employeeid { get; set; }
        public string? Empname { get; set; }
        public int Status { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
