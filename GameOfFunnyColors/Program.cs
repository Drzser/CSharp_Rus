using System;


namespace GameOfFunnyColors
{
    class Program
    {
        public static void GameOfFunnyColors()
        {
            Console.WriteLine("Добро пожаловать в игру „Веселые цвета“! Введите название любого цвета");
            // специально выбрал такой формальный стиль, чтобы игрок ни о чем не догадался));-)
            Console.WriteLine("Введите „Выход“, чтобы закончить игру");

            while (true)
            {
                Console.Write("Введите цвет: ");
                var color = Console.ReadLine()?.ToLower();

                // проверка на выход из игры
                if (color == "выход")
                {
                    Console.WriteLine("Возвращайтесь еще!:-)");
                    break;
                }

                // вуухуу!)))
                switch (color)
                {
                    case "черный":
                        Console.WriteLine("Неверно, это оранжевый!");
                        break;
                    case "зеленый":
                        Console.WriteLine("Неверно, это фиолетовый!");
                        break;
                    case "белый":
                        Console.WriteLine("Неверно, это бирюзовый!");
                        break;
                    case "желтый":
                        Console.WriteLine("Неверно, это бежевый!");
                        break;
                    case "красный":
                        Console.WriteLine("Неверно, это серый!");
                        break;
                    case "розовый":
                        Console.WriteLine("Неверно, это лиловый!");
                        break;
                    case "синий":
                        Console.WriteLine("Неверно, это сиреневый!");
                        break;
                    case "бордовый":
                        Console.WriteLine("Неверно, это перламутровый!");
                        break;
                    default:
                        Console.WriteLine("Ошибка 404: цвет не найден. Попробуйте еще раз!"); // обработка неизвестных цветов
                        break;
                }
            }



        }
        static void Main()
        {
            Program.GameOfFunnyColors();
        }

    }
}