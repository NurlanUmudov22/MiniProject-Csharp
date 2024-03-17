using Domain.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
       

        private readonly IStudentRepository _studentRepository;
        private int count = 1;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }



        public void Create(Student data)
        {
            if (data == null) throw new ArgumentNullException();
            data.Id = count;
            _studentRepository.Create(data);
            count++;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            Student student = _studentRepository.GetById(id);

            if (student == null) throw new NotFoundException(ResponseMessages.DataNotFound);

            _studentRepository.Delete(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetAllStudentsByGroupId(int id)
        {
            return _studentRepository.GetAllStudentsByGroupId(id); 
        }

        public Student GetById(int? id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepository.GetStudentsByAge(age);
        }

        public List<Student> SearchByName(string searchText)
        {
            return _studentRepository.GetAllWithExpression(m => m.Name == searchText);
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
