using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Classes
    {
        public Classes()
        {
            UserClasses = new HashSet<UserClasses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserClasses> UserClasses { get; set; }
    }
}
