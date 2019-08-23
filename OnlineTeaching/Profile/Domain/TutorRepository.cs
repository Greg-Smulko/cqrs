using OnlineTeaching;
using Profile.Domain.Models;

namespace Profile.Domain
{
    public interface TutorRepository
    {
        Tutor TutorOf(Id id);
        void Save(Tutor tutor);
    }
}
