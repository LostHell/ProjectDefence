namespace Fitness2You.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class UserClass
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ClassId { get; set; }

        public DateTime TakeOn { get; set; }

        public virtual Class Class { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
