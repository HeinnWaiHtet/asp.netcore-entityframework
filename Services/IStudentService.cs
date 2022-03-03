using StudentManagement.models;

namespace StudentManagement.Services
{
    public interface IStudentService
    {
        List<Student> Get();
        Student GetById(string id);

        Student Create(Student student);

        void Update(string id, Student student);

        void Remove(string id);
    }
}
