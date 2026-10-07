using System;

// Huvudmeny för programmet som håller det vid liv och informerar användaren.
// Menyn använder en bool + while-loop för att skapa en oändlig iteration tills
// användaren väljer att avsluta (val 0). Switch-satsen hanterar menyval.

bool running = true;

// Hjälpmetoder för validerad input
string ReadNonEmptyString(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
        Console.WriteLine("Input får inte vara tom. Försök igen.");
    }
}

int ReadIntInRange(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        string? s = Console.ReadLine();
        if (int.TryParse(s, out int v) && v >= min && v <= max) return v;
        Console.WriteLine($"Ogiltig input. Ange ett heltal mellan {min} och {max}.");
    }
}

int ReadPositiveInt(string prompt, int max = 1000)
{
    return ReadIntInRange(prompt, 1, max);
}

while (running)
{
    Console.Clear();
    Console.WriteLine("=== Huvudmeny ===");
    Console.WriteLine("Skriv numret för att välja funktion:");
    Console.WriteLine("1 - Ungdom eller pensionär (enkelt pris)");
    Console.WriteLine("2 - Räkna pris för ett helt sällskap");
    Console.WriteLine("3 - Upprepa tio gånger (for-loop)");
    Console.WriteLine("4 - Visa det tredje ordet i en mening");
    Console.WriteLine("0 - Avsluta programmet");
    Console.Write("Val: ");
    string? rawChoice = Console.ReadLine();
    string choice = (rawChoice ?? string.Empty).Trim();

    switch (choice)
    {
        case "0":
            Console.WriteLine("Programmet avslutas. Tryck valfri tangent...");
            running = false;
            Console.ReadKey(true);
            break;

        case "1":
            // Validera ålder och använd nästlad if enligt instruktion.
            int age = ReadIntInRange("Ange ålder i siffror: ", 0, 150);

            // Nästlad if-sats med extra regler: under 5 gratis, över 100 gratis
            if (age < 20)
            {
                if (age < 5)
                {
                    Console.WriteLine("Barn under fem går gratis!");
                }
                else
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
            }
            else
            {
                if (age > 64)
                {
                    if (age > 100)
                    {
                        Console.WriteLine("Pensionär över 100 går gratis!");
                    }
                    else
                    {
                        Console.WriteLine("Pensionärspris: 90kr");
                    }
                }
                else
                {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }

            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            break;

        case "2":
            // Pris för sällskap: validera antal och varje ålder.
            int count = ReadPositiveInt("Hur många är ni? ", 200);
            int totalCost = 0;

            for (int i = 1; i <= count; i++)
            {
                int a = ReadIntInRange($"Ålder för person {i}: ", 0, 150);

                // Prislogik: under 5 gratis, under 20 ungdom, 65-100 pensionärspris, över 100 gratis
                if (a < 5)
                {
                    // gratis
                }
                else if (a < 20)
                {
                    totalCost += 80;
                }
                else
                {
                    if (a > 100)
                    {
                        // gratis
                    }
                    else if (a > 64)
                    {
                        totalCost += 90;
                    }
                    else
                    {
                        totalCost += 120;
                    }
                }
            }

            Console.WriteLine($"Antal personer: {count}");
            Console.WriteLine($"Totalkostnad för hela sällskapet: {totalCost}kr");
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            break;

        case "3":
            // Upprepa tio gånger: validera att användaren skriver något
            string text = ReadNonEmptyString("Skriv en godtycklig text: ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i}. {text}");
                if (i < 10) Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            break;

        case "4":
            // Det tredje ordet: hantera flera mellanslag med RemoveEmptyEntries
            string sentence = ReadNonEmptyString("Skriv en mening (minst 3 ord): ");
            string[] parts = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                Console.WriteLine("Mening innehåller färre än 3 ord. Tryck valfri tangent för att återgå.");
            }
            else
            {
                Console.WriteLine($"Det tredje ordet är: {parts[2]}");
            }
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            break;

        default:
            Console.WriteLine("Felaktig input. Vänligen ange ett giltigt sifferval.");
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey(true);
            break;
    }
}

// Programmet avslutat
