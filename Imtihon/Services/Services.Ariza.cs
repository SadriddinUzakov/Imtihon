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
        public static string GetArizaPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"\arizalar.json";
            return currentPath;
        }

        public void ClearArFile()
        {
            File.WriteAllText(GetKursPAth(), string.Empty);
            Console.WriteLine("Infos are cleaned! ");
        }

        public void SaveAriza(List<Ariza> arizas)
        {
            string serialized = JsonSerializer.Serialize(arizas);
            File.WriteAllText(GetArizaPAth(), serialized);
        }

        public void AddAriza()
        {
            List<Ariza> arizas = GetAriza();

            Console.Write("Write application: ");
            Console.WriteLine();
            Console.Write("In this Application you must write your LastName and which course you want to study");
            Console.WriteLine();
            Console.Write("or you can write some questions and you neewd to write youur number!");
            Console.WriteLine();
            Console.Write("We will call you :) !");
            string arizaName = Console.ReadLine();

            int newId = arizas.Count > 0 ? arizas.Max(t => t.Id) + 1 : 1;

            Ariza newAriza = new Ariza
            {
                Id = newId,
                Name = arizaName,
            };

            arizas.Add(newAriza);
            SaveAriza(arizas);

            Console.WriteLine("Application submitted successfully. Wait for our reply!");
        }

        public List<Ariza> GetAriza()
        {
            if (!File.Exists(GetArizaPAth()))
            {
                Console.WriteLine("No Applications");
            }
            if (!File.Exists(GetArizaPAth()))
            {
                return new List<Ariza>();
            }

            string jsonFromFile = File.ReadAllText(GetArizaPAth());
            var arizas = string.IsNullOrEmpty(jsonFromFile) ? new List<Ariza>() : JsonSerializer.Deserialize<List<Ariza>>(jsonFromFile);

            Console.WriteLine("Applications: ");
            foreach (var ariza in arizas)
            {
                Console.WriteLine($"Id: {ariza.Id}, Application: {ariza.Name}");
            }

            return arizas;
        }

        public void DeleteAriza()
        {
            List<Ariza> arizas = GetAriza();

            Console.Write("Enter Application Id to delete: ");
            int ArizaId;
            while (!int.TryParse(Console.ReadLine(), out ArizaId))
            {
                Console.Write("Plz enter id: ");
            }

            Ariza arizaToDelete = arizas.FirstOrDefault(t => t.Id == ArizaId);
            if (arizaToDelete == null)
            {
                Console.WriteLine("Application Not Found.");
                return;
            }

            arizas.Remove(arizaToDelete);
            SaveAriza(arizas);

            Console.WriteLine("The application was successfully deletedi.");
        }

        public void UpdateAriza()
        {
            List<Ariza> arizas = GetAriza();

            Console.Write("Enter Application Id to update : ");
            int ArizaId;
            while (!int.TryParse(Console.ReadLine(), out ArizaId))
            {
                Console.Write("Plz enter id: ");
            }

            Ariza arizaToUpdate = arizas.FirstOrDefault(t => t.Id == ArizaId);
            if (arizaToUpdate == null)
            {
                Console.WriteLine("Application not foundi!");
                return;
            }

            Console.Write("Update application: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                arizaToUpdate.Name = newName;
            }

            SaveAriza(arizas);
            Console.WriteLine("Application updatet successfully! ");
        }
    }
}
