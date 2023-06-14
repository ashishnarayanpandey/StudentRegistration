using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentRegistration.Interface;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public class StudentRepo:IStudent
    {
        private readonly DatabaseContext _Context;

        public StudentRepo(DatabaseContext context)
        {
            _Context = context;
        }

        public void Delete(Student student)
        {
            _Context.Students.Remove(student);
        }

        public IEnumerable<Student> GetAll()
        {
            var data =_Context.Students.ToList();  
            return data;    
          
        }

        public Student GetById(int id)
        {
            var data = _Context.Students.Where(x => x.Student_Id == id).FirstOrDefault();
            return data;
        }

        public void Insert(Student student)
        {
            _Context.Students.Add(student);
            
        }

        public void saved()
        {
            _Context.SaveChanges();
        }

        public void Update(Student student)
        {
            _Context.Students.Update(student);
        }
    }
}
