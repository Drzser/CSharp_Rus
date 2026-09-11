using System;
using System.Globalization;
using System.Threading;

namespace CalculatorLite
{
    public class Calculator
    {
        private decimal _num1;
        private decimal _num2;
        private decimal _result;

        public void Start()
        {
            RunLoop();
        }

        private void RunLoop()
        {
            bool continueCalculation = true;

            while (continueCalculation)
            {
                // Ввод данных
                Console.Write("Введите первое число: ");
                if (!decimal.TryParse(Console.ReadLine(), out _num1))
                {
                    Console.WriteLine("Ошибка: введено не число!");
                    continue;
                }

                Console.Write("Введите второе число: ");
                if (!decimal.TryParse(Console.ReadLine(), out _num2))
                {
                    Console.WriteLine("Ошибка: введено не число!");
                    continue;
                }

                Console.Write("Операция (+, -, *, /): ");
                string? operation = Console.ReadLine();

                // Логика вычислений
                switch (operation)
                {
                    case "+": Add(); break;
                    case "-": Subtract(); break;
                    case "*": Multiply(); break;
                    case "/": Divide(); break;
                    default: Console.WriteLine("Неизвестная операция"); continue;
                }


                Console.WriteLine("Хотите посчитать еще? (да/нет)");
                string? answer = Console.ReadLine()?.Trim().ToLower();

                if (answer != "да")
                {
                    continueCalculation = false;
                    Console.WriteLine("До свидания!");
                }
            }
        }

        private void Add() => CalculateAndPrint(_num1 + _num2);
        private void Subtract() => CalculateAndPrint(_num1 - _num2);
        private void Multiply() => CalculateAndPrint(_num1 * _num2);

        private void Divide()
        {
            if (_num2 == 0)
            {
                Console.WriteLine("Нельзя делить на ноль! (даже если очень сильно хочется xD)");
                return;
            }

            CalculateAndPrint(_num1 / _num2);
        }

        private void CalculateAndPrint(decimal value)
        {
            _result = value;
            PrintResult();
        }

        private void PrintResult()
        {
            Console.WriteLine($"Результат: {_result}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Настройка культуры для точки как разделителя
            CultureInfo culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var calc = new Calculator();
            calc.Start();
        }
    }
}
