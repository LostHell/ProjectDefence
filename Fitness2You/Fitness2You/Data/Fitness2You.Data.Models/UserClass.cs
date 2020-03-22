﻿namespace MODELS_PROJECT.Data
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;

    public partial class UserClass
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}