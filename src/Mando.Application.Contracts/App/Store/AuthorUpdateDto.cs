using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Mando.App.Store
{
    public class AuthorUpdateDto : ExtensibleObject
    {
        [Required]
        [StringLength(AuthorConsts.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public string Biography { get; set; }
    }
}
