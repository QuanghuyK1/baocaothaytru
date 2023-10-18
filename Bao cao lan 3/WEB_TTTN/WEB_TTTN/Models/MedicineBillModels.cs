namespace WEB_TTTN.Models
{
    public class MedicineBillModels
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Serviceid { get; set; }
        public int PriceMed { get; set; }
        public string BillCode { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int Status { get; set; }
        public string? Img { get; set; }
    }
}
