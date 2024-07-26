using Models;

namespace New_Project_LC.Services
{
    public partial class Services
    {
        private List<Teachers> teachers = new List<Teachers>();
        private List<Ariza> specialists = new List<Ariza>();
        private List<Kurs> kurss = new List<Kurs>();
        private List<About> rooms = new List<About>();

        public static void KursMenu(Services CentrServices)
        {
            bool exit = false;
            var index = 0;
            List<string> buyruq3 = new List<string>()
        {

            "Add Courses",
            "List of Courses",
            "Edit List of Courses",
            "Delete Courses",
            "Clear List of Courses",
            "Back to Menu"
        };
            while (!exit)
            {
                Console.Clear();
                for (int i = 0; i < buyruq3.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
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
                            CentrServices.AddKurs();
                            break;
                        case 1:
                            CentrServices.GetKurs();
                            break;
                        case 2:
                            CentrServices.UpdateKurs();
                            break;
                        case 3:
                            CentrServices.DeleteKurs();
                            break;
                        case 4:
                            CentrServices.ClearKFile();
                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }


        public static void TeacherMenu(Services CentrServices)
        {
            bool exit = false;
            var index = 0;
            List<string> buyruq4 = new List<string>()
                {
            "Add Menthor",
            "List of Menthors",
            "edit List of Menthors",
            "Delete Menthors",
            "Clear List of Menthors",
            "Back"
                };
            while (!exit)
            {
                Console.Clear();
                for (int i = 0; i < buyruq4.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(buyruq4[i]);
                    Console.ResetColor();
                }
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    index = (index + 1) % buyruq4.Count;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    index = (index - 1 + buyruq4.Count) % buyruq4.Count;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (index)
                    {
                        case 0:
                            CentrServices.AddTeacher();
                            break;
                        case 1:
                            CentrServices.GetTeachers();
                            break;
                        case 2:
                            CentrServices.UpdateTeacher();
                            break;
                        case 3:
                            CentrServices.DeleteTeacher();
                            break;
                        case 4:
                            CentrServices.ClearTFile();
                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
        public static void AboutMenu(Services CentrServices)
        {
            bool exit = false;
            var index = 0;
            List<string> buyruq3 = new List<string>()
                {
            "Add Information",
            "Problems",
            "Read Problems",
            "Delete Problems",
            "Back"
                };
            while (!exit)
            {
                Console.Clear();
                for (int i = 0; i < buyruq3.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
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
                            CentrServices.AddAbout();
                            break;
                        case 1:
                            CentrServices.GetAbout();
                            break;
                        case 2:
                            CentrServices.UpdateAbout();
                            break;
                        case 3:
                            CentrServices.DeleteAbout();
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
        public static void ArizaMenu(Services CentrServices)
        {
            bool exit = false;
            var index = 0;
            List<string> buyruq3 = new List<string>()
                {
                    "Filling out an application",
                    "My applications",
                    "Edit My Application",
                    "Delete My Applications",
                    "Back"
                };
            while (!exit)
            {
                Console.Clear();
                for (int i = 0; i < buyruq3.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
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
                            CentrServices.AddAriza();
                            break;
                        case 1:
                            CentrServices.GetAriza();
                            break;
                        case 2:
                            CentrServices.UpdateAriza();
                            break;
                        case 3:
                            CentrServices.DeleteAriza();
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
        public static void GetKursforS(Services CentrServices)
        {
            CentrServices.GetKurs();
        }
        public static void GetTeachersforS(Services CentrServices)
        {
            CentrServices.GetTeachers();
        }
        public static void GetAboutforS(Services CentrServices)
        {
            CentrServices.GetAbout();
        }
        public static void GetArizaforA(Services CentrServices)
        {
            CentrServices.GetAriza();
        }
    }
}
