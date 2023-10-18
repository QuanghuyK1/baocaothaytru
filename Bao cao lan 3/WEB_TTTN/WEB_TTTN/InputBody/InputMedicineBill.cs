namespace WEB_TTTN.InputBody
{
    public class InputMedicineBill
    {
        public string BillCode { get; set; }
        public string MedName { get; set; }
        public int Count { get; set; }

        public int ServiceId { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

        public int Status { get; set; }
    }
}
