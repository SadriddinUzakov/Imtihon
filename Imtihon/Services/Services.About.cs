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
        public static string GetAboutPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"\malumotlar.json";
            return currentPath;
        }


        public void SaveAbout(List<About> abouts)
        {
            string serialized = JsonSerializer.Serialize(abouts);
            File.WriteAllText(GetAboutPAth(), serialized);
        }

        public void AddAbout()
        {
            List<About> abouts = GetAbout();

            if (abouts.Count > 0)
            {
                Console.WriteLine("Reference already exists. No new information is added.");
                return;
            }

            Console.Write("Enter the center information and press 'Enter' after entering: ");
            string aboutName = Console.ReadLine();

            int newId = 1;

            About newabout = new About
            {
                Id = newId,
                Name = aboutName,
            };

            abouts.Add(newabout);
            SaveAbout(abouts);

            Console.WriteLine("Reference added successfully.");
        }

        public List<About> GetAbout()
        {
            if (File.Exists(GetAboutPAth()))
            {
                Console.WriteLine("No data available");
            }
            if (!File.Exists(GetAboutPAth()))
            {
                return new List<About>();
            }



            string jsonFromFile = File.ReadAllText(GetAboutPAth());
            var abouts = string.IsNullOrEmpty(jsonFromFile) ? new List<About>() : JsonSerializer.Deserialize<List<About>>(jsonFromFile);
            foreach (var about in abouts)
            {
                Console.WriteLine($"Reference: {about.Name}");
            }
            return abouts;

        }

        public void DeleteAbout()
        {
            List<About> abouts = GetAbout();

            if (abouts.Count == 0)
            {
                Console.WriteLine("No data available\r\n.");
                return;
            }

            abouts.Clear();
            SaveAbout(abouts);

            Console.WriteLine("Reference deleted successfully.");
        }

        public void UpdateAbout()
        {
            List<About> abouts = GetAbout();

            if (abouts.Count == 0)
            {
                Console.WriteLine("No data available\r\n!");
                return;
            }

            About aboutToUpdate = abouts[0];

            Console.Write("Enter new information: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                aboutToUpdate.Name = newName;
            }

            SaveAbout(abouts);
            Console.WriteLine("Information successfully updated! ");
        }
    }
}
