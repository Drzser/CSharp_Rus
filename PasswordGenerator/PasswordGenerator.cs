using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator : IPasswordGenerator
    {
        private const int MinLength = 8;
        private const int MaxLength = 64;

        public string GeneratePassword(int requestedLength)
        {
            
            int length = Math.Clamp(requestedLength, MinLength, MaxLength);

            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";

            
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = RandomNumberGenerator.GetInt32(alphabet.Length);
                sb.Append(alphabet[index]);
            }

            return sb.ToString();
        }
    }
}