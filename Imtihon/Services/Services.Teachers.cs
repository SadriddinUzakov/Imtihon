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
        public static string GetTeacherPAth()
        {
            string currentPath = Directory.GetCurrentDirectory();
            currentPath += @"\teachers.json";
            return currentPath;
        }
        public void ClearTFile()
        {
            File.WriteAllText(GetTeacherPAth(), string.Empty);
            Console.WriteLine("Informations are Cleaned");
        }
        public void SaveTeachers(List<Teachers> teachers)
        {
            string serialized = JsonSerializer.Serialize(teachers);

            File.WriteAllText(GetTeacherPAth(), serialized);
        }
        public void AddTeacher()
        {

            List<Teachers> teachers = GetTeachers();

            Console.Write("Write a Menthors Name: ");
            string teacherName = Console.ReadLine();
            Console.Write("Enter Menthors Specialist: ");
            string teacherSpc = Console.ReadLine();
            Console.Write("Enter Menthors Age: ");
            int teacherAge = int.Parse(Console.ReadLine());

            int newId = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;

            Teachers newTeacher = new Teachers
            {
                Id = newId,
                Name = teacherName,
                Spc = teacherSpc,
                Age = teacherAge
            };

            teachers.Add(newTeacher);
            SaveTeachers(teachers);

            Console.WriteLine("menthor Added Successfully!");
        }
        public List<Teachers> GetTeachers()
        {
            if (!File.Exists(GetTeacherPAth()))
            {
                Console.WriteLine("There is No Menthors Yet");
            }
            if (!File.Exists(GetTeacherPAth()))
            {
                return new List<Teachers>();
            }

            string jsonFromFile = File.ReadAllText(GetTeacherPAth());
            var teachers = string.IsNullOrEmpty(jsonFromFile) ? new List<Teachers>() : JsonSerializer.Deserialize<List<Teachers>>(jsonFromFile);

            Console.WriteLine("List of Menthors:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}, Specialist: {teacher.Spc}, Age: {teacher.Age}");
            }

            return teachers;
        }
        public void DeleteTeacher()
        {
            List<Teachers> teachers = GetTeachers();

            Console.Write("Enter Menthors Name for Deleating: ");
            int teacherId;
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.Write("Plz Enter An Id : ");
            }

            Teachers teacherToDelete = teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToDelete == null)
            {
                Console.WriteLine("Menthor Not Found!");
                return;
            }

            teachers.Remove(teacherToDelete);
            SaveTeachers(teachers);

            Console.WriteLine("Menthor is Deleted.");
        }
        public void UpdateTeacher()
        {
            List<Teachers> teachers = GetTeachers();

            Console.Write("Enter an Id For Upgrade Menthor : ");
            int teacherId;
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.Write("PLZ Enter ID: ");
            }

            Teachers teacherToUpdate = teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToUpdate == null)
            {
                Console.WriteLine("Enter Teacher.");
                return;
            }

            Console.Write("Enter a New Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                teacherToUpdate.Name = newName;
            }
            Console.Write("Enter His/Her Specialist: ");
            string newspc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newspc))
            {
                teacherToUpdate.Spc = newspc;
            }
            Console.Write("Enter an Age: ");
            int newag = int.Parse(Console.ReadLine());

            teacherToUpdate.Age = newag;


            SaveTeachers(teachers);
            Console.WriteLine("Menthor Saved Successfully! ");
        }
    }
}
