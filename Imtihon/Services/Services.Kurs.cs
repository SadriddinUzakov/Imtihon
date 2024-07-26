using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace New_Project_LC.Services
{
    public partial class Services
    {
        public static string GetKursPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"\kurslar.json";
            return currentPath;
        }

        public void ClearKFile()
        {
            File.WriteAllText(GetKursPAth(), string.Empty);
            Console.WriteLine("Informations are cleaned! ");
        }

        public void SaveKurs(List<Kurs> kurss)
        {
            string serialized = JsonSerializer.Serialize(kurss);
            File.WriteAllText(GetKursPAth(), serialized);
        }

        public void AddKurs()
        {
            List<Kurs> kurss = GetKurs();

            Console.Write("Enter cours name: ");
            string kursName = Console.ReadLine();

            int newId = kurss.Count > 0 ? kurss.Max(t => t.Id) + 1 : 1;

            Kurs newKurs = new Kurs
            {
                Id = newId,
                Name = kursName,
            };

            kurss.Add(newKurs);
            SaveKurs(kurss);

            Console.WriteLine("course added successfully.");
        }

        public List<Kurs> GetKurs()
        {
            if (!File.Exists(GetKursPAth()))
            {
                Console.WriteLine("There is no courses yet!");
            }
            if (!File.Exists(GetKursPAth()))
            {
                return new List<Kurs>();
            }

            string jsonFromFile = File.ReadAllText(GetKursPAth());
            var kurss = string.IsNullOrEmpty(jsonFromFile) ? new List<Kurs>() : JsonSerializer.Deserialize<List<Kurs>>(jsonFromFile);

            Console.WriteLine("List of courses:");
            foreach (var kurs in kurss)
            {
                Console.WriteLine($"Id: {kurs.Id}, Name: {kurs.Name}");
            }

            return kurss;
        }

        public void DeleteKurs()
        {
            List<Kurs> kurss = GetKurs();

            Console.Write("Enter Name for deleting course: ");
            int KursId;
            while (!int.TryParse(Console.ReadLine(), out KursId))
            {
                Console.Write("Plz enter id: ");
            }

            Kurs kursToDelete = kurss.FirstOrDefault(t => t.Id == KursId);
            if (kursToDelete == null)
            {
                Console.WriteLine("course not found.");
                return;
            }

            kurss.Remove(kursToDelete);
            SaveKurs(kurss);

            Console.WriteLine("course deleted succesfully.");
        }

        public void UpdateKurs()
        {
            List<Kurs> kurss = GetKurs();

            Console.Write("Enter course Name for updating: ");
            int KursId;
            while (!int.TryParse(Console.ReadLine(), out KursId))
            {
                Console.Write("PLZ enter id: ");
            }

            Kurs kursToUpdate = kurss.FirstOrDefault(t => t.Id == KursId);
            if (kursToUpdate == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                kursToUpdate.Name = newName;
            }

            SaveKurs(kurss);
            Console.WriteLine("Course Updated Successfully! ");
        }
    }
}
