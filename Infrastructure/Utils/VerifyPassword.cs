using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Utils;

public static class VerifyPassword
{
    public static bool VerifyingPassword(this string password, IEnumerable<byte> passwordHash, byte[] passwordSlot)
    {
        using var hash = new HMACSHA512(passwordSlot);
        var hashPass = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        return hashPass.SequenceEqual(passwordHash);
    }
}
