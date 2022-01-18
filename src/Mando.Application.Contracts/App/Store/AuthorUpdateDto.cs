using System;
using System.ComponentModel.DataAnnotations;

namespace Mando.App.Store
{
    public class AuthorUpdateDto
    {
        [Required]
        [StringLength(AuthorConsts.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public string Biography { get; set; }
    }
}
