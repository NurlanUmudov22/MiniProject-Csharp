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
        Group GetByTeacher(string teacher);

        Group GetByRoom(string room);
    }
}
