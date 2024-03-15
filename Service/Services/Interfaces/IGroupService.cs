using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group data);

        void Delete(int? id);

        void Update(Group data);

        Group GetById(int? id);

        List<Group> GetAll();

       // List<Group> SearchByName(string searchText);

        List<Group> GetAllGroupsByRoom(string room);


        List<Group> GetAllGroupsByTeacher(string teacher); 
    }
}
