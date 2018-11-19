using System;
using FluentValidation;
using Redbet.Domain.Core.Models;

namespace Redbet.Domain.Models.Customers
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
            Removed = false;
        }
        
        private Customer() { }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Address { get; private set; }

        public string FavoriteFootballTeam { get; private set; }

        public bool Removed { get; private set; }

        public void RemoveCustomer()
        {
            Removed = true;
        }

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
                .Length(2, 50).WithMessage("The first name should be between 2 and 50 characters");
        }

        private void LastNameValidate()
        {
            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("The last name should be informed")
                .Length(2, 50).WithMessage("The last name should be between 2 and 50 characters");
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
                .Length(2, 50).WithMessage("The Favorite Football Team should be between 2 and 50 characters");
        }        

        #endregion

        #region Factory

        public static class CustomerFactory
        {
            public static Customer NewCompleteCustomer(Guid id, string firstName, string lastName, string address, string favoriteFootballTeam)
            {
                var customer = new Customer()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    FavoriteFootballTeam = favoriteFootballTeam
                };

                return customer;
            }
        }

        #endregion
    }
}
