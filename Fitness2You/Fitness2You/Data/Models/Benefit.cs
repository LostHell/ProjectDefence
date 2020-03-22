namespace Fitness2You.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Benefit
    {
        public Benefit()
        {
            this.Subscription = new HashSet<Subscription>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
