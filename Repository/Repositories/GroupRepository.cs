using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public Group GetByRoom(string room)
        {
            return AppDbContext<Group>.datas.FirstOrDefault(m => m.Room == room);
        }

        public Group GetByTeacher(string teacher)
        {
            return AppDbContext<Group>.datas.FirstOrDefault(m => m.Teacher == teacher);

        }
    }
}
