using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group> 
    {
        List<Group> GetAllGroupsByTeacher(string teacherName);

        List<Group> GetAllGroupsByRoom(string roomName);
        Group GetByName(string group);
    }
}
