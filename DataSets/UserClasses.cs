using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class UserClasses
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public virtual Classes Class { get; set; }
        public virtual Users User { get; set; }
    }
}
