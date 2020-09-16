﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Site.MVC.UI.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Your name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A subject is required")]
        public string Subject { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "A message is requierd")]
        public string Message { get; set; }
    }
}