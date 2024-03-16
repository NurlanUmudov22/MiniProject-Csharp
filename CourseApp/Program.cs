
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

GetMenues();





static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n  1. Group create \n " + " 2. Group update \n  3. Group delete \n  4. Get group by id \n  5. Get all groups by teacher name \n  6. Get all groups by room name \n  7. Get all groups \n  8. Student create \n  9. Student update \n  10. Get student by Id \n  11. Student delete \n  12. Get student by age \n  13. Get all students by group Id \n  14. Search groups by name \n  15. Search students by name or surname ");

}




//Console.WriteLine("Choose one operation : \n  1. Group create \n " + " 2. Group delete  \n  3. Group update \n  4. Get all groups ");



while (true)
{
    Operation:  string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat =  int.TryParse(operationStr, out operation);

    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GroupCreate:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GroupUpdate:
                Console.WriteLine("no");
                break;
            case (int)OperationType.GroupDelete:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetGroupById:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetAllGroupsByTeacher:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetAllGroupsByRoom:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.GetAllGroups:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.StudentCreate:
                Console.WriteLine("yes");
                break;
            case (int)OperationType.StudentUpdate:
                Console.WriteLine("yes");
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
                Console.WriteLine("yes");
                break;
            case (int)OperationType.SearchStudentsByNameOrSurname:
                Console.WriteLine("yes");
                break;




        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operations is wrong, please add operation again ");
        goto Operation;
    }
}








