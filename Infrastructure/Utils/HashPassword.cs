using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Utils;

public static class HashPassword
{

    public static void HashingPassword(this string password, out byte[] passwordHash, out byte[] passwordSlot)
    {
        using var hash = new HMACSHA512();
        passwordSlot = hash.Key;

        passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        ;
    }
}
