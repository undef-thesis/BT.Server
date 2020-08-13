namespace BT.Application.Services.Auth
{
    public interface IPasswordService
    {
        string HashPassword(string password, byte[] salt);
        byte[] CreateSalt();
    }
}