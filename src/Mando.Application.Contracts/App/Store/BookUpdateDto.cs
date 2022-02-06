using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Mando.App.Store;

public class BookUpdateDto : ExtensibleObject
{
	[Required]
	public Guid AuthorId { get; set; }

	[Required]
	[StringLength(BookConsts.NameMaxLength)]
	public string Name { get; set; }

	[Required]
	public BookType Type { get; set; }

	[Required]
	public DateTime PublishDate { get; set; }

	[Required]
	public float Price { get; set; }
}
