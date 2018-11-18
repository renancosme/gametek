using FluentValidation.Results;
using Redbet.Domain.Core.Bus;
using Redbet.Domain.Core.Notifications;
using Redbet.Domain.Interfaces;
using System;

namespace Redbet.Domain.CommandHandlers
{
    /// <summary>
    /// A generic Command Handler for whatever command handles
    /// </summary>
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _domainNotificationHandler;

        protected CommandHandler(IUnitOfWork unitOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected void NotifyErrorValidations(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            // TODO: Check business validations !
            if (_domainNotificationHandler.HasNotifications()) return false;

            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Error when saving data");
            _bus.RaiseEvent(new DomainNotification("Commit", "Error when saving data"));
            return false;
        }
    }
}
