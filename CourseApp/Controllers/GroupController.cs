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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Group = Domain.Models.Group;

namespace CourseApp.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupController()
        {
            _groupService = new GroupService();
            _studentService = new StudentService();
        }

        public void Create()
        {
            
            ConsoleColor.Blue.WriteConsole("Add group name:");
            Name:  string name = Console.ReadLine();

            if ( string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
                //return;
                
            }
            if (name.Count() > 30)
            {
                ConsoleColor.Red.WriteConsole("The group name cannot be more than 30 characters");
                goto Name;
            }
            if (_groupService.GetAll().Any(m => m.Name.ToLower() == name.ToLower())) 
            {
                ConsoleColor.Red.WriteConsole("Group names can not be the same");
                goto Name;
            }



            ConsoleColor.Blue.WriteConsole("Add teacher name:");
            TeacherName:  string teacherName = Console.ReadLine();
            if (!Regex.IsMatch(teacherName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto TeacherName;
            }

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto TeacherName;
            }

            if ( teacherName.Count() > 50)
            {
                ConsoleColor.Red.WriteConsole("The teacher name cannot be more than 50 characters");
                goto TeacherName;
            }

            ConsoleColor.Blue.WriteConsole("Add group room name:");
            Room: string room = Console.ReadLine();
            if (room.Count() > 40)
            {
                ConsoleColor.Red.WriteConsole("The room name cannot be more than 40 characters");
                goto Room;
            }
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
            if (result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data is notfound ");
                
            }

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
                    var response = _groupService.GetById(id);
                    if (response.Id == 0)
                    {
                        Console.WriteLine("data is deleted");
                        return;

                    }





                    _groupService.Delete(id);
                    _studentService.DeleteAll(id);

                    ConsoleColor.Green.WriteConsole("Data successfully deleted");                   
                    }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    //goto Id;
                    return;
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
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                            Console.WriteLine(data);
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("There is no teacher with this name");
                        goto Teacher;
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
                    //goto Id;
                    // return;
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

                    if (result.Count !=  0)
                    {
                        foreach (var item in result)
                        {
                            string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                            Console.WriteLine(data);
                        }

                    }
                    //foreach (var item in result)
                    //{
                    //    string data = $"Id:{item.Id}, Group name: {item.Name}, Teacher name: {item.Teacher}, Room name: {item.Room}";
                    //    Console.WriteLine(data);
                    //}
                    else
                    {
                        ConsoleColor.Red.WriteConsole("There is no group with this name");
                        goto Room;
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
            
            
                try
                {
                    _groupService.SearchByName(name);

                    var result1 = _groupService.SearchByName(name);

                    if (result1.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                    
                }


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
