using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrGreen.Domain.Models
{
    public class Customer : Entity<Customer>
    {
        public Customer(string firstName, string lastName, string address, string personalNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PersonalNumber = personalNumber;
        }

        // Constructor for EF
        protected Customer()
        {
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Address { get; private set; }

        public string PersonalNumber { get; private set; }

		
        #region Validations

        public override bool IsValid()
        {
            FirstNameValidate();
            LastNameValidate();
            AddressValidate();
            PersonalNumberValidate();

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

        private void PersonalNumberValidate()
        {
            RuleFor(c => c.PersonalNumber)
                .NotEmpty()
                .WithMessage("The Personal Number should be informed")
                .Length(9, 10).WithMessage("The Personal Number should be between 9 and 10 characters");
        }
		

        #endregion
    }
}
