using CDNConverter.API.Application.Services.Validators;
using CDNConverter.API.Shared.Exceptions;
using CDNConverter.API.Shared.Exceptions.ExceptionsBase;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CDNConverter.API.Extentions
{
    public static class ValidatorExtention
    {
        public static async Task ValidateAsync(this IFormFile file)
        {
            var validator = new ByFileValidator();
            var result = await validator.ValidateAsync(file);

            if (!result.IsValid)
                throw new BadRequestException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }

        public static async Task ValidateAsync(this Guid id, bool exists)
        {
            var validator = new ByIdValidator();
            var result = await validator.ValidateAsync(id);

            if (exists)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagesExceptions.LOG_EXISTS));

            if (!result.IsValid)
                throw new BadRequestException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }

        public static async Task ValidateAsync(this Guid id)
        {
            var validator = new ByIdValidator();
            var result = await validator.ValidateAsync(id);

            if (!result.IsValid)
                throw new BadRequestException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}
