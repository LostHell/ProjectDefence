using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Benefits
    {
        public Benefits()
        {
            Subscription = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
