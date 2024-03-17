
using CourseApp.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

//GetMenues();

GroupController groupController = new GroupController();

groupController = new GroupController();

StudentController studentController = new StudentController();

studentController = new StudentController();


static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n  1. Group create \n " + " 2. Group update \n  3. Group delete \n  4. Get group by id \n  5. Get all groups by teacher name \n  6. Get all groups by room name \n  7. Get all groups \n  8. Student create \n  9. Student update \n  10. Get student by Id \n  11. Student delete \n  12. Get student by age \n  13. Get all students by group Id \n  14. Search groups by name \n  15. Search students by name or surname \n  16. Get All Students");

}




while (true)
{
    GetMenues();

    Operation:  string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat =  int.TryParse(operationStr, out operation);

    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCreate:
                groupController.Create();
                break;
            case (int)OperationType.GroupUpdate:
                ConsoleColor.Yellow.WriteConsole("Service temporarily suspended");  //Console.WriteLine("Service temporarily suspended");
                break;
            case (int)OperationType.GroupDelete:
                groupController.Delete();
                break;
            case (int)OperationType.GetGroupById:
                groupController.GetById();
                    break;
            case (int)OperationType.GetAllGroupsByTeacher:
                groupController.GetAllGroupsByTeacher();
                break;
            case (int)OperationType.GetAllGroupsByRoom:
                groupController.GetAllGroupsByRoom();
                break;
            case (int)OperationType.GetAllGroups:
                groupController.GetAll();
                break;
            case (int)OperationType.StudentCreate:
                studentController.Create();
                break;
            case (int)OperationType.StudentUpdate:
                ConsoleColor.Yellow.WriteConsole("Service temporarily suspended");  //Console.WriteLine("Service temporarily suspended");
                break;
            case (int)OperationType.GetStudentById:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.StudentDelete:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetStudentByAge:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetAllStudentsByGroupId:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.SearchGroupsByName:
                groupController.SearchGroupsByName();
                break;
            case (int)OperationType.SearchStudentsByNameOrSurname:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetAllStudents:
                studentController.GetAll();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation format is wrong, please choose again");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operations is wrong, please add operation again ");
        goto Operation;
    }
}








