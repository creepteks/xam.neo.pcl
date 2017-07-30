using System;
using Liphsoft.Crypto.Argon2;
using BCrypt.Net;
using System.Diagnostics;

public class Hasher
{
    private static PasswordHasher hasher = new PasswordHasher();
    private static string GetRandomSalt()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(12);
    }

    public static string HashPassword(string password)
    {
        //return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        return hasher.Hash(password);
    }
    public static string HashPassword(string password, string salt)
    {
        return hasher.Hash(password, salt);
    }
    public static bool ValidatePassword(string password, string correctHash)
    {
        //return BCrypt.Net.BCrypt.Verify(password, correctHash);
        return hasher.Verify(correctHash, password);
    }

    internal static bool ValidateAndUpdatePassword(string secondLoginPass, string passOnServer)
    {
        bool updated;
        string newHash = null;
        var res = hasher.VerifyAndUpdate(passOnServer, secondLoginPass, out updated, out newHash);
        Debug.WriteLine("updated: " + updated.ToString() + " new hash : " + newHash);
        return res;

    }
}
