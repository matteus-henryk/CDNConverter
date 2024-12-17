using CDNConverter.API.Shared.Exceptions;
using FluentValidation;
using System;

namespace CDNConverter.API.Application.Services.Validators
{
    public class ByIdValidator : AbstractValidator<Guid>
    {
        public ByIdValidator()
        {
            RuleFor(id => id).NotEmpty().WithMessage(ResourceMessagesExceptions.EMPYT_IDENTIFIER);
            RuleFor(id => id).Must(ValidateGuid).WithMessage(ResourceMessagesExceptions.EMPYT_IDENTIFIER);
        }

        private bool ValidateGuid(Guid id)
        {
            var isValid = true;
            if (id == Guid.Empty) isValid = false;
            
            return isValid;
        }
    }
}
