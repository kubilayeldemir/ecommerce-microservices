using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace UserService.Helpers
{
    public static class EncryptionHelper
    {
        public static (string HashedData, string Salt) EncryptData(string data)
        {
            var salt = GetRandomSalt();
            var hashedByteArray = HashDataWithPbkdf2(data, salt);
            var hashedData = Convert.ToBase64String(hashedByteArray);

            return (hashedData,Convert.ToBase64String(salt));
        }
        
        public static (string hashedData, string salt) EncryptData(string data, string base64Salt)
        {
            var salt = Convert.FromBase64String(base64Salt);
            var hashedByteArray = HashDataWithPbkdf2(data, salt);
            var hashedData = Convert.ToBase64String(hashedByteArray);

            return (hashedData,Convert.ToBase64String(salt));
        }

        private static byte[] HashDataWithPbkdf2(string data, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: data,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);
        }

        private static byte[] GetRandomSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}