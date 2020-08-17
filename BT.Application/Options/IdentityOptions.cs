namespace BT.Application.Options
{
    public class IdentityOptions
    {
        public string SecretKey { get; set; }
        public int TokenValidInMinutes { get; set; }
        public int RefreshTokenValidInDays { get; set; }
    }
}