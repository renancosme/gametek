﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Redbet.Application.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }

        public CustomerViewModel(Guid id, string firstName, string lastName, string address, string favoriteFootballTeam)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            FavoriteFootballTeam = favoriteFootballTeam;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "The first name should be informed")]
        [MinLength(2, ErrorMessage = "The minimum size of the first name is {1}")]
        [MaxLength(50, ErrorMessage = "The maximum fist name size is {1}")]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name should be informed")]
        [MinLength(2, ErrorMessage = "The minimum size of the last name is {1}")]
        [MaxLength(50, ErrorMessage = "The maximum last name size is {1}")]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The address should be informed")]
        [MinLength(3, ErrorMessage = "The minimum size of the address is {1}")]
        [MaxLength(150, ErrorMessage = "The maximum address size is {1}")]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [MinLength(2, ErrorMessage = "The minimum size of the Favorite Football Team is {1}")]
        [MaxLength(50, ErrorMessage = "The maximum Favorite Football Team size is {1}")]
        [Display(Name = "Favorite Football Team:")]
        public string FavoriteFootballTeam { get; set; }
    }
}
