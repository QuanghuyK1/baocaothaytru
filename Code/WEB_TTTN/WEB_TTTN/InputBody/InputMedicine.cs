namespace WEB_TTTN.InputBody
{
    public class InputMedicine
    {
        public int Id { get; set; }
        public string MedName { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int Price { get; set; }
        public DateTime Getdate { get; set; }
        public int HandlePrice { get; set; }
        public int Startus { get; set; }

        public string nationname { get; set; }
    }
}
