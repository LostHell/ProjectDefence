using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class UserClass
    {
        public UserClass()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual User User { get; set; }
    }
}
