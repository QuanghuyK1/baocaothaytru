namespace WEB_TTTN.Helpers
{
    public class EmailSetting
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}
