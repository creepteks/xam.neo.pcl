namespace neo.pcl
{
    internal interface ICryptoService
    {
        string HashPassword(string password, string salt);
        bool ValidatePassword(string password, string hash);
        bool ValidateAndUpdatePassword(string password, string expectedHash);

    }
}