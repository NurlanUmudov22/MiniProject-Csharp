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
              

        public List<Group> GetAllGroupsByRoom(string roomName)
        {
            return AppDbContext<Group>.datas.Where(m=> m.Room ==roomName).ToList();
        }

        public List<Group> GetAllGroupsByTeacher(string teacherName)
        {
            return AppDbContext<Group>.datas.Where(m => m.Teacher == teacherName).ToList();
        }

        public Group GetByName(string group)
        {
            return AppDbContext<Group>.datas.FirstOrDefault(m => m.Name == group);
        }
    }
}
