using StudentRegistration.Models;

namespace StudentRegistration.Interface
{
    public interface IStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(Student student);
        void saved();

    }
}
