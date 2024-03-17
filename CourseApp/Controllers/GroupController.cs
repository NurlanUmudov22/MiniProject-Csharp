using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }

        public void Create()
        {
            
            ConsoleColor.Blue.WriteConsole("Add group name:");
            Name:  string name = Console.ReadLine();

            if ( string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            ConsoleColor.Blue.WriteConsole("Add teacher name:");
            TeacherName:  string teacherName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto TeacherName;
            }

            ConsoleColor.Blue.WriteConsole("Add group room name:");
            Room: string room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
            else
            {
                try
                {
                    //Group group = new Group();
                    //{
                    //    group.Name = name;
                    //    group.Teacher = teacherName;
                    //    group.Room = room;
                    //};

                    _groupService.Create(new Group {Name = name, Teacher = teacherName, Room = room });
                    ConsoleColor.Green.WriteConsole("Data successfully added");

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                    
                }
                             
            }        
        }

        public void GetAll()
        {
            var result = _groupService.GetAllWithExpression();
            foreach (var item in result)
            {
                string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                Console.WriteLine(data);
            }
        }
        
        public void Delete()
        {
                ConsoleColor.Blue.WriteConsole("Add group id:");
                Id: string idStr = Console.ReadLine();
                int id;
                bool isCorrectIdFormat = int.TryParse(idStr, out id);
                if (isCorrectIdFormat)
                {
                   try
                    {
                    _groupService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                    }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
                }
                else
                {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
                }
        }

        public void GetAllGroupsByTeacher()
        {
            ConsoleColor.Blue.WriteConsole("Add teacher name:");
            Teacher: string teacher = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(teacher))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Teacher;
            }
            else
            {
                try
                {
                    _groupService.GetAllGroupsByTeacher(teacher);

                    var result = _groupService.GetAllGroupsByTeacher( teacher);

                    foreach (var item in result)
                    {
                        string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                        Console.WriteLine(data);
                    }

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Teacher;

                }
            }

        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Add group id:");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _groupService.GetById(id);
                    var result1 = _groupService.GetById(id);

                    Console.WriteLine($"Id:{result1.Id}, Group name: {result1.Name}, Teacher name: {result1.Teacher}, Room name: {result1.Room}");
                    

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }

        public void GetAllGroupsByRoom()
        {
            ConsoleColor.Blue.WriteConsole("Add room name:");
            Room: string room = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
            else
            {
                try
                {
                    _groupService.GetAllGroupsByRoom(room);

                    var result = _groupService.GetAllGroupsByRoom(room);

                    foreach (var item in result)
                    {
                        string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                        Console.WriteLine(data);
                    }

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Room;

                }
            }
        }

        public void SearchGroupsByName()
        {
            ConsoleColor.Blue.WriteConsole("Add group name:");
            Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            else
            {
                try
                {
                    _groupService.SearchByName(name);

                    var result1 = _groupService.SearchByName(name);

                    foreach (var item in result1)
                    {
                        string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                        Console.WriteLine(data);
                    }


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;

                }
            }
        }
    }
}
