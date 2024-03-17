using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private int count = 1; 
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public void Create(Group data)
        {
            if (data == null) throw new ArgumentNullException();
            data.Id = count;
            _groupRepository.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Group group = _groupRepository.GetById(id);

            if (group == null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _groupRepository.Delete(group);
        }
        
        public List<Group> GetAllWithExpression()
        {
            return _groupRepository.GetAll();
        }

        public List<Group> GetAllGroupsByRoom(string room)
        {
            return _groupRepository.GetAllGroupsByRoom(room);
            //if (room == null) throw new ArgumentNullException();
        }

        public List<Group> GetAllGroupsByTeacher(string teacher)
        {
            return _groupRepository.GetAllGroupsByTeacher( teacher);
           // if (teacher == null) throw new ArgumentNullException();
        }

        public Group GetById(int? id)
        {
            //return _groupRepository.GetById(id);
            if (id == null) throw new ArgumentNullException();
            Group group = _groupRepository.GetById(id);

            if (group == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            return group;
        }

      
        public List<Group> SearchByName(string searchText)
        {
            return _groupRepository.GetAllWithExpression(m => m.Name == searchText);
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }
    }
}
