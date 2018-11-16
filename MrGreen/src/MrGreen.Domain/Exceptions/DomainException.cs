using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace MrGreen.Domain.Exceptions
{
    public class DomainException : Exception
    {
        private ValidationResult _validationResult;

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(ValidationResult validationResult)
        {
            Errors = new List<string>();
            _validationResult = validationResult;
            FillDomainErros();
        }

        public IList<string> Errors { get; set; }

        private void FillDomainErros()
        {
            foreach (var item in _validationResult.Errors)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}
