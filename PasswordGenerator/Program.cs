using System;
using System.Security.Cryptography;

namespace PasswordGenerator
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Введите желаемую длину пароля (минимум 8 символов): ");

            if (int.TryParse(Console.ReadLine(), out int length))
            {
                var baseGenerator = new PasswordGenerator();
                var secureGenerator = new SecurePasswordGenerator(baseGenerator);

                try
                {
                    string password = secureGenerator.GeneratePassword(length);
                    Console.WriteLine($"Ваш надёжный пароль: {password}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}









