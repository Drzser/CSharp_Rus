using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    public class SecurePasswordGenerator : IPasswordGenerator
    {
        private readonly IPasswordGenerator _baseGenerator;

        public SecurePasswordGenerator(IPasswordGenerator baseGenerator)
        {
            _baseGenerator = baseGenerator;
        }

        public string GeneratePassword(int requestedLength)
        {
            const int MinLength = 8; // чтобы точно хватило места для всех типов символов
            int length = Math.Clamp(requestedLength, MinLength, 64);

            while (true)
            {
                string candidate = _baseGenerator.GeneratePassword(length);

                if (HasRequiredCharacterTypes(candidate))
                {
                    return candidate;
                }

                // Если требования не выполнены — пробуем снова.
            }
        }

        private static bool HasRequiredCharacterTypes(string password)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSpecial = true; // считаем всё остальное спецсимволами
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}