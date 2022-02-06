using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mando.App.Store;

public class Book : FullAuditedAggregateRoot<Guid>
{
	private Book() { /* for deserialization / ORM purpose */ }
	public Guid AuthorId { get; set; }
	public string Name { get; private set; }
	public BookType Type { get; set; }
	public DateTime PublishDate { get; set; }
	public float Price { get; set; }
	internal Book(Guid id, Guid authorId, [NotNull] string name, BookType type, DateTime publishDate, float price)
		: base(id)
	{
		AuthorId = authorId;
		Name = Check.NotNullOrWhiteSpace(name, nameof(name), BookConsts.NameMaxLength);
		Type = type;
		PublishDate = publishDate;
		Price = price;
	}
	internal Book ChangeName([NotNull] string name)
	{
		Name = Check.NotNullOrWhiteSpace(name, nameof(name), BookConsts.NameMaxLength);
		return this;
	}
}
