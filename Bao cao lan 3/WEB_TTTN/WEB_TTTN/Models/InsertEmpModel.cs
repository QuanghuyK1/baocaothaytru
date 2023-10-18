namespace WEB_TTTN.Models
{
    public class InsertEmpModel
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int ClassId { get; set; }
        public int EmployeeRoleId { get; set; }
        public int? Status { get; set; }
        public int? SalaryBasic { get; set; }
        public int RoleId { get; set; }
    }
}
