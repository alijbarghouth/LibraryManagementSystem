using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.HashingPassword;

public static class HashPassword
{

    public static void HashingPassword(this string password, out byte[] passwordHash, out byte[] passwordSlot)
    {
        using (var Hash = new HMACSHA512())
        {
            passwordSlot = Hash.Key;

            passwordHash = Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        };
    }
}
