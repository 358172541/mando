using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mando.App.Store
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        private Author() { /* for deserialization / ORM purpose */ }
        public string Name { get; private set; }
        public DateTime Birthday { get; set; }
        public string Biography { get; set; }
        internal Author(Guid id, [NotNull] string name, DateTime birthday, [CanBeNull] string biography = null)
            : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), AuthorConsts.NameMaxLength);
            Birthday = birthday;
            Biography = biography;
        }
        internal Author ChangeName([NotNull] string name) // internal prevents application layer to use it directly
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), AuthorConsts.NameMaxLength);
            return this;
        }
    }
}
