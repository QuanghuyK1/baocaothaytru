namespace WEB_TTTN.InputBody
{
    public class InputScheduleEmp
    {
        public string Eventname { get; set; } = null!;
        public DateTime Starttime { get; set; }
        public string Description { get; set; } = null!;
        public string LocationName { get; set; }
    }
}
