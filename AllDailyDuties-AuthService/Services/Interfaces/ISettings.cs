namespace AllDailyDuties_AuthService.Services.Interfaces
{
    public interface ISettings
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}
