using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    internal class StudentController 
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public StudentController() 
        {
            _studentService = new StudentService();
            _groupService = new GroupService();
        }


        public void Create()
        {
            if (_groupService.GetAll().Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Group is not, please create group");
                return;

            }

            ConsoleColor.Blue.WriteConsole("Add student name:");
            Name: string name = Console.ReadLine();
            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Name;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            ConsoleColor.Blue.WriteConsole("Add student surname:");
            Surname: string surname = Console.ReadLine();
            if (!Regex.IsMatch(surname, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Surname;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Surname;
            }

            ConsoleColor.Blue.WriteConsole("Add age:");
            Age: string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);

            if( age < 15 || age > 50)
            {
                ConsoleColor.Red.WriteConsole("Age restrictions");
                goto Age;
            }

            if (isCorrectAgeFormat)
            {

                ConsoleColor.Blue.WriteConsole("Add student group name:");
                Group: string group = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(group))
                {
                    ConsoleColor.Red.WriteConsole("Input can't be empty");
                    goto Group;
                }
                var search = _groupService.GetByName(group);
                if (search == null)
                {
                    ConsoleColor.Red.WriteConsole("Group is not exist");
                    goto Group;
                }

                try
                {
                    _studentService.Create(new Student { Name = name, Surname = surname, Age = age, Group = search});

                    ConsoleColor.Green.WriteConsole("Data successfully added");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }
            }
            else
            {

                ConsoleColor.Red.WriteConsole("Age format is wrong, please add operation again");
                goto Age;

            }

        }
        public void GetAll()
        {
            var result = _studentService.GetAll();

            if(result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data is notfound");
                
            }

            foreach (var item in result)
            {
                string data = $"Id:{item.Id}, Name: {item.Name}, Surname: {item.Surname}, Group name: {item.Group.Name}, Age: {item.Age}";
                Console.WriteLine(data);
            }
        }

        public void GetStudentById()
        {
            ConsoleColor.Blue.WriteConsole(" Add student id:");
            Id: string idStr = Console.ReadLine();

            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Id;
                //return;

            }
            try
            {
                _studentService.GetById(id);
                var result = _studentService.GetById(id);
                string data = $"Id:{result.Id}, Name: {result.Name}, Surname: {result.Surname}, Group name: {result.Group.Name}, Age: {result.Age}";
                Console.WriteLine(data);

            }
            catch (Exception)
            {
                // ConsoleColor.Red.WriteConsole(ex.Message);
                //goto Id;
                //return;
                ConsoleColor.Red.WriteConsole("Id not found");
            }





        }

        public void StudentDelete()
        {
            ConsoleColor.Blue.WriteConsole("Add student id:");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {

                    _studentService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                    //var result = _studentService.GetById(id);
                    //if (result != null)
                    //{
                    //    _studentService.Delete(id);
                    //    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                    //}
                    //
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

        public void GetStudentsByAge()
        {
            ConsoleColor.Blue.WriteConsole("Add age:");
            Age: string ageStr = Console.ReadLine();
            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);

            if (isCorrectAgeFormat)
            {
                try
                {
                    var result1 = _studentService.GetStudentsByAge(age);

                    if( result1.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole("Data is notfound");

                    }

                    foreach (var item in result1)
                    {
                        string data = $"Id:{item.Id}, Name: {item.Name}, Surname: {item.Surname}, Group name: {item.Group.Name}, Age: {item.Age}";
                        Console.WriteLine(data);
                    }

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Age;
                    

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
        }

        public void GetAllStudentsByGroupId()
        {
            ConsoleColor.Blue.WriteConsole("Add group id:");
            Id:  string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Id;
            }
            if (isCorrectIdFormat)
            {

                try
                {
                    var result = _studentService.GetAllStudentsByGroupId(id);

                    if (result.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole("Id notfound");
                        
                    }

                    foreach (var item in result)
                    {
                        string data = $"Id:{item.Id}, Name: {item.Name}, Surname: {item.Surname}, Group name: {item.Group.Name}, Age: {item.Age}";
                        Console.WriteLine(data);
                    }

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
           
        }

        public void SearchStudentsByNameOrSurname()
        {
            ConsoleColor.Blue.WriteConsole("Add student name or surname:");
        Name: string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;

            }
            
                try
                {
                    _studentService.SearchStudentsByNameOrSurname(text);

                    var result1 = _studentService.SearchStudentsByNameOrSurname(text);

                    if (result1.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data is notfound");
                    
                }


                    if (result1 != null)
                    {
                        foreach (var item in result1)
                        {
                            string data = $"Id:{item.Id}, Name: {item.Name}, Surname: {item.Surname}, Group name: {item.Group.Name}, Age: {item.Age}";
                            Console.WriteLine(data);
                        }

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
