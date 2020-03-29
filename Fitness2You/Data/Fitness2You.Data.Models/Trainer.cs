namespace Fitness2You.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Trainer
    {
        public Trainer()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Range(0, 10000)]
        public decimal Salary { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
