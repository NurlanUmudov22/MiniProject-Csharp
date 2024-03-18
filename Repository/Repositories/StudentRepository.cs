using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> GetAllStudentsByGroupId(int id)
        {
            return AppDbContext<Student>.datas.Where(m => m.Group.Id == id).ToList();
        }

        public List<Student> GetStudentsByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(m => m.Age == age).ToList();
        }


        public List<Student> SearchStudentsByNameOrSurname(string text)
        {
            return AppDbContext<Student>.datas.Where(m => m.Name.ToLower().Trim().Contains(text.ToLower().Trim()) || m.Surname.ToLower().Trim().Contains(text.ToLower().Trim())).ToList();
        }
    }
}
