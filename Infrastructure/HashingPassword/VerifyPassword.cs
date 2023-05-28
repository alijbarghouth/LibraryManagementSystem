using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.HashingPassword;

public static class VerifyPassword
{
    public static bool VerifyingPassword(this string password, byte[] passwordhash, byte[] passwordSlot)
    {
        using (var hash = new HMACSHA512(passwordSlot))
        {
            var HashPass = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return HashPass.SequenceEqual(passwordhash);
        }
    }
}
