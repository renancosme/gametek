using System;
using FluentValidation;

namespace Redbet.Domain.Models
{
    public class Customer : Entity<Customer>
    {
        public Customer(string firstName, string lastName, string address, string favoriteFootballTeam)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            FavoriteFootballTeam = favoriteFootballTeam;
        }

        // Constructor for EF
        protected Customer()
        {
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Address { get; private set; }

        public string FavoriteFootballTeam { get; private set; }

        #region Validations

        public override bool IsValid()
        {
            FirstNameValidate();
            LastNameValidate();
            AddressValidate();
            FavoriteFootballTeamValidate();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void FirstNameValidate()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("The first name should be informed")
                .Length(2, 150).WithMessage("The first name should be between 2 and 150 characters");
        }

        private void LastNameValidate()
        {
            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("The last name should be informed")
                .Length(2, 150).WithMessage("The last name should be between 2 and 150 characters");
        }

        private void AddressValidate()
        {
            RuleFor(c => c.Address)
                .NotEmpty()
                .WithMessage("The address should be informed")
                .Length(3, 150).WithMessage("The address should be between 3 and 150 characters");
        }
                
        private void FavoriteFootballTeamValidate()
        {
            RuleFor(c => c.FavoriteFootballTeam)
                .NotEmpty()
                .WithMessage("The Favorite Football Team should be informed")
                .Length(2, 150).WithMessage("The Favorite Football Team should be between 2 and 150 characters");
        }

        #endregion
    }
}
