using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    internal class StudentController 
    {
        private readonly IStudentService _studentService;
        //private readonly IGroupService _groupService;

        public StudentController() //IStudentService studentService, IGroupService groupService)
        {
            _studentService = new StudentService();
            //_groupService = new GroupService();
        }


        //public void Create()
        //{
        //    ConsoleColor.Blue.WriteConsole("Add student name:");
        //    Name: string name = Console.ReadLine();

        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        ConsoleColor.Red.WriteConsole("Input can't be empty");
        //        goto Name;
        //    }

        //    ConsoleColor.Blue.WriteConsole("Add student surname:");
        //    Surname: string surname = Console.ReadLine();

        //    if (string.IsNullOrWhiteSpace(surname))
        //    {
        //        ConsoleColor.Red.WriteConsole("Input can't be empty");
        //        goto Surname;
        //    }

        //    ConsoleColor.Blue.WriteConsole("Add age:");
        //    Age: string ageStr = Console.ReadLine();
        //    int age;
        //    bool isCorrectCapacityFormat = int.TryParse(ageStr, out age);

        //    if (isCorrectCapacityFormat)
        //    {

        //        ConsoleColor.Blue.WriteConsole("Add group name:");
        //         Group: string group = Console.ReadLine();

        //        if (string.IsNullOrWhiteSpace(group))
        //        {
        //            ConsoleColor.Red.WriteConsole("Input can't be empty");
        //            goto Group;
        //        }
        //        try
        //        {

        //            ConsoleColor.Green.WriteConsole("Data successfully added");
        //        }
        //        catch (Exception ex)
        //        {
        //            ConsoleColor.Red.WriteConsole(ex.Message);
        //            goto Name;
        //        }
        //    }
        //    else
        //    {
                
        //        ConsoleColor.Red.WriteConsole("Age format is wrong, please add operation again");
        //        goto Age;

        //    }

        //}
    }
}
