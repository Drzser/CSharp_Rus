using System.Reflection;
using System.Text.Json;

var assembly = Assembly.GetExecutingAssembly();
using var stream = assembly.GetManifestResourceStream("GuessNumber.quotes.json")
                    ?? throw new FileNotFoundException("Resource 'quotes.json' not found.");
using var reader = new StreamReader(stream);
string[] quotes = JsonSerializer.Deserialize<string[]>(reader.ReadToEnd())
                ?? Array.Empty<string>();

Random random = new Random();
int quoteIndex = 0;

Shuffle(quotes);

void Shuffle(string[] arr)
{
    for (int i = arr.Length - 1; i > 0; i--)
    {
        int j = random.Next(i + 1);
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}

void PlayGame()
{
    Random rnd = new Random();
    int secret = rnd.Next(1, 101);

    int maxAttempts = 7;
    int attempts = 0;
    bool guessed = false;

    Console.WriteLine("Угадайте число от 1 до 100.");
    Console.WriteLine($"У вас {maxAttempts} попыток.\n");

    while (attempts < maxAttempts)
    {
        attempts++;
        Console.Write($"Попытка {attempts}: ");
        int guess;

        if (!int.TryParse(Console.ReadLine(), out guess))
        {
            Console.WriteLine("Введите число!\n");
            attempts--;
            continue;
        }

        if (guess == secret)
        {
            Console.WriteLine($"Поздравляю! Вы угадали за {attempts} попыток.");

            if(quoteIndex >= quotes.Length)
            {
                Shuffle(quotes);
                quoteIndex = 0;
            }

            Console.WriteLine($"{quotes[quoteIndex]}");
            quoteIndex++;

            guessed = true;
            break;
        }
        else if (guess < secret)
        {
            Console.WriteLine("Больше!\n");
        }
        else
        {
            Console.WriteLine("Меньше!\n");
        }
    }

    if (!guessed)
    {
        Console.WriteLine($"Попытки кончились, вы проиграли. Загаданное число: {secret}.");
    }

}

bool play = true;
while (play)
{
    PlayGame();
    Console.WriteLine("Хотите сыграть еще раз? (да/нет):");
    string? input = Console.ReadLine();
    if (input == null || input.Trim() == "")
    {
        Console.WriteLine("Вы ничего не ввели");
        return;
    }

    string answer = input.ToLower();

    if (answer == "да")
    {
        play = true;
    }
    else
    {
        play = false;
    }
}