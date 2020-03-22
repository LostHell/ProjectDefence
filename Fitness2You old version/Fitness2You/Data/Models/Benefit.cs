using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MODELS_PROJECT.Data
{
    public partial class Benefit
    {
        public Benefit()
        {
            Subscription = new HashSet<Subscription>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
