﻿using System.ComponentModel.DataAnnotations;

namespace Fitness2You.ViewModels.Users
{
    public class LoginInputViewModel
    {
        [Required(ErrorMessage = "Username is Required.")]
        [Display(Name = "Username")]
        [StringLength(30, ErrorMessage = "Invalid username, please try again!", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Invalid password, please try again!", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
