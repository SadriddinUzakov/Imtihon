
using New_Project_LC.Services;

public static class Program
{
    static void Main(string[] args)
    {
        var CentrServices = new Services();
        bool exit = false;
        int index = 0;

        List<string> buyruq1 = new List<string>
        {
            "Admin",
            "Student"
        };
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Are You a Student or Admin?");
            for (int i = 0; i < buyruq1.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(buyruq1[i]);
                Console.ResetColor();
            }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                index = (index + 1) % buyruq1.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                index = (index - 1 + buyruq1.Count) % buyruq1.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (index)
                {
                    case 0:
                        AdminMenu(CentrServices);
                        break;
                    case 1:
                        StudentMenu(CentrServices);
                        break;
                }
                Console.ReadKey();
            }
        }
    }

    static void AdminMenu(Services CentrServices)
    {
        bool exit = false;
        var index = 0;
        List<string> buyruq2 = new List<string>()
        {
            "Courses",
            "Menthors",
            "About Learning Centre",
            "Applications",
            "Back"
        };
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("< Admin >");
            for (int i = 0; i < buyruq2.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(buyruq2[i]);
                Console.ResetColor();
            }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                index = (index + 1) % buyruq2.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                index = (index - 1 + buyruq2.Count) % buyruq2.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (index)
                {
                    case 0:
                        Services.KursMenu(CentrServices);
                        break;
                    case 1:
                        Services.TeacherMenu(CentrServices);
                        break;
                    case 2:
                        Services.AboutMenu(CentrServices);
                        break;
                    case 3:
                        Services.GetArizaforA(CentrServices);
                        break;
                    case 4:
                        exit = true;
                        break;


                }
                Console.ReadKey();
            }
        }
    }

    static void StudentMenu(Services CentrServices)
    {
        bool exit = false;
        var index = 0;
        List<string> buyruq3 = new List<string>()
        {
            "Courses",
            "Menthors",
            "About Learning Centre",
            "Applications",
            "Back"
        };
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("< Student >");
            for (int i = 0; i < buyruq3.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(buyruq3[i]);
                Console.ResetColor();
            }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                index = (index + 1) % buyruq3.Count;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                index = (index - 1 + buyruq3.Count) % buyruq3.Count;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                switch (index)
                {
                    case 0:
                        Services.GetKursforS(CentrServices);
                        break;
                    case 1:
                        Services.GetTeachersforS(CentrServices);
                        break;
                    case 2:
                        Services.GetAboutforS(CentrServices);
                        break;
                    case 3:
                        Services.ArizaMenu(CentrServices);
                        break;
                    case 4:
                        exit = true;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
