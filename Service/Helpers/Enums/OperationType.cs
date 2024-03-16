using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum OperationType
    {
        GroupCreate = 1,
        GroupUpdate = 2,
        GroupDelete = 3,
        GetGroupById = 4,
        GetAllGroupsByTeacher = 5,
        GetAllGroupsByRoom = 6,
        GetAllGroups = 7,
        StudentCreate = 8,
        StudentUpdate = 9,
        GetStudentById = 10,
        StudentDelete = 11,
        GetStudentByAge = 12,
        GetAllStudentsByGroupId = 13,
        SearchGroupsByName = 14,
        SearchStudentsByNameOrSurname = 15

    }
}
