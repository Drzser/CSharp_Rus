using System;

namespace PasswordGenerator
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Введите желаемую длину пароля (минимум 8 символов): ");

            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                return;
            }

            var baseGenerator = new PasswordGenerator();
            var secureGenerator = new SecurePasswordGenerator(baseGenerator);

            string? answer;

            do
            {
                try
                {
                    string password = secureGenerator.GeneratePassword(length);
                    Console.WriteLine($"Ваш надёжный пароль: {password}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    // При ошибке сразу выходим, чтобы не зациклиться на ошибке
                    break;
                }

                Console.Write("Хотите сгенерировать ещё один пароль той же длины? (да/д): ");
                answer = Console.ReadLine()?.Trim().ToLower();

            } while (answer is "да" or "д");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
