using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Benefit
    {
        public Benefit()
        {
            this.Id = Guid.NewGuid().ToString();
            Subscription = new HashSet<Subscription>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
