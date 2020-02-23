using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Class
    {
        public Class()
        {
            this.Id = Guid.NewGuid().ToString();
            UserClasses = new HashSet<UserClass>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
