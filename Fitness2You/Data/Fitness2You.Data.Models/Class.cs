namespace Fitness2You.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Class
    {
        public Class()
        {
            this.UserClasses = new HashSet<UserClass>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(0, 9999)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int? Discount { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
