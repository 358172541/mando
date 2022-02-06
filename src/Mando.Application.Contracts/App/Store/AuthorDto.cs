using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Mando.App.Store;

public class AuthorDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant, IHasConcurrencyStamp
{
	public Guid? TenantId { get; set; }

	public string Name { get; set; }

	public DateTime Birthday { get; set; }

	public string Biography { get; set; }

	public string ConcurrencyStamp { get; set; }
}
