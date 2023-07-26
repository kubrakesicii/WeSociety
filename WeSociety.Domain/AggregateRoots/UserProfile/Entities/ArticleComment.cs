using WeSociety.Domain.Base;

namespace WeSociety.Domain.AggregateRoots.UserProfile.Entities
{
    public class ArticleComment : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
