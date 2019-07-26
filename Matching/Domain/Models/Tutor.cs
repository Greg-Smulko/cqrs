using OnlineTeaching;

namespace Matching.Domain.Models
{
    // entity
    public class Tutor
    {
        public Id Id { get; }
        public Tutor(string id)
        {
            Id = Id.FromExisting(id);
        }
    }
}