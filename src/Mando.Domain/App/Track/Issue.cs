using System;
using Volo.Abp.Domain.Entities;

namespace Mando.App.Track
{
    public class Issue : AggregateRoot<Guid>
    {
        private Issue() { }

        public string Title { get; set; }

        public string Description { get; set; }

        internal Issue(Guid id, string title, string description) : base(id)
        {
            Title = title;
            Description = description;
        }

        public bool IsClosed { get; private set; } = false;

        public void Close()
        {
            IsClosed = true;
        }

        public void Unclose()
        {
            if (IsLocked)
            {
                throw new IssueStateException("CanNotUncloseLockedIssue"); // need unlock first
            }

            IsClosed = false;
        }

        public bool IsLocked { get; private set; } = false;

        public void Lock()
        {
            if (IsClosed == false)
            {
                throw new IssueStateException("CanNotLockUnclosedIssue"); // need close first
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public bool IsInactive() => new IssueInactiveSpecification().IsSatisfiedBy(this);
    }
}
