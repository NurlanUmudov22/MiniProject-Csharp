using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student data);

        void Delete(int? id);

        void Update(Student data);

        Student GetById(int? id);

        List<Student> GetAll();

        List<Student> GetAllStudentsByGroupId(int id);

        List<Student> GetStudentsByAge(int age);

        //List<Student> SearchByName(string searchText);

        List<Student> SearchStudentsByNameOrSurname(string text);

    }
}
