namespace Fitness2You.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Newsletter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        public DateTime SendOn { get; set; }
    }
}
