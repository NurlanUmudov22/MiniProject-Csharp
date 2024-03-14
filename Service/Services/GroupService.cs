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

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public void Create(Group data)
        {
            if (data == null) throw new ArgumentNullException();
            _groupRepository.Create(data);
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Group group = _groupRepository.GetById(id);

            if (group == null) throw new NotFoundException(ResponseMessages.DataNotFound);
        }
        ///
        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Group GetByRoom(string room)
        {
            throw new NotImplementedException();
        }

        public Group GetByTeacher(string teacher)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchByName(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
