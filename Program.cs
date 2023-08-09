using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AssessmentTwo
{
    internal class Program
    {
        static List<Teacher> teacher = new List<Teacher>();
        public static void ReadFile()
        {
            string path = @"D:\Raven\Practice Exercise\C#\AssessmentTwo\Teacher.txt";
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    Teacher teach = new Teacher { Id = int.Parse(parts[0].Trim()), Name = parts[1].Trim(), Class = parts[2].Trim() };
                    teacher.Add(teach);
                }
            }
        }
        public static void AddTeacher()
        {
            Console.WriteLine("Enter Teacher Id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Teacher's Class");
            string classs=Console.ReadLine();
            teacher.Add(new Teacher { Id=id, Name=name, Class=classs });
            Console.WriteLine("New Teacher is Added");
        }
        public static void DisplayTeachers()
        {
            foreach (Teacher teach in teacher)
            {
                Console.WriteLine($"Teacher Id : {teach.Id}\t\tTeach Name : {teach.Name}\t\t Class : {teach.Class}");
            }
        }
        public static void UpdateTeacher(int id)
        {
            Teacher teach = teacher.Find(teacher => teacher.Id == id);
            if (teach != null)
            {
                Console.WriteLine("Enter New Name");
                teach.Name = Console.ReadLine();
                Console.WriteLine("Enter New Class");
                teach.Class = Console.ReadLine();
                Console.WriteLine("\nTeacher Data is Updated");
            }
            else
            {
                Console.WriteLine($"\nTeacher with the Id = {id} is not in the system");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                ReadFile();
                again:
                Console.WriteLine("The Avaliable Options Are : \n1. Add Teacher\n2. Update Teacher\n3. Retrieve All Teacher");
                Console.Write("Enter the Option : ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            AddTeacher();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nEnter the Id of teacher to Update");
                            int id = int.Parse(Console.ReadLine());
                            UpdateTeacher(id);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nList of All Teachers\n");
                            DisplayTeachers();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter the Correct the Option");
                            goto again;
                        }
                }
                Console.WriteLine("\nPress Y to continue.... Others to Exit.");
                if (char.Parse(Console.ReadLine()) == 'y')
                    goto again;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                string path = @"D:\Raven\Practice Exercise\C#\AssessmentTwo\Teacher.txt";
                using (StreamWriter write=new StreamWriter(path))
                {
                    foreach(Teacher teach in teacher)
                    {
                        write.WriteLine($"{teach.Id}, {teach.Name}, {teach.Class}");
                    }
                }
                Console.WriteLine("Data Saved in the File");
            }
        }
    }
}
