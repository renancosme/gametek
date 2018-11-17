using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unified.Presentation.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }

        public CustomerViewModel(Guid id, string firstName, string lastName, string address, string personalNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PersonalNumber = personalNumber;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "The first name should be informed")]
        [MinLength(2, ErrorMessage = "The minimum size of the first name is {1}")]
        [MaxLength(150, ErrorMessage = "The maximum fist name size is {1}")]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name should be informed")]
        [MinLength(2, ErrorMessage = "The minimum size of the last name is {1}")]
        [MaxLength(150, ErrorMessage = "The maximum last name size is {1}")]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The address should be informed")]
        [MinLength(3, ErrorMessage = "The minimum size of the address is {1}")]
        [MaxLength(150, ErrorMessage = "The maximum address size is {1}")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
                
        [MinLength(9, ErrorMessage = "The minimum size of the personal number is {1}")]
        [MaxLength(10, ErrorMessage = "The maximum personal number size is {1}")]
        [Display(Name = "Personal number:")]
        public string PersonalNumber { get; set; }
                
        [MinLength(2, ErrorMessage = "The minimum size of the Favorite Football Team is {1}")]
        [MaxLength(150, ErrorMessage = "The maximum Favorite Football Team size is {1}")]
        [Display(Name = "Favorite Football Team:")]
        public string FavoriteFootballTeam { get; set; }
    }
}
