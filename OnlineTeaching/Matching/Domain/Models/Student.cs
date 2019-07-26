using OnlineTeaching;

namespace Matching.Domain.Models
{
    // entity
    public class Student
    {
        public Id Id { get; }

        public Student(string id)
        {
            Id = Id.FromExisting(id);
        }
    }
}