using CDNConverter.API.Shared.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace CDNConverter.API.Application.Services.Validators
{
    public class ByFileValidator : AbstractValidator<IFormFile>
    {
        public ByFileValidator()
        {
            RuleFor(log => log.Length).NotEmpty().WithMessage(ResourceMessagesExceptions.CONTENT_EMPYT);
            RuleFor(log => log).Must(ValidateOriginalLogFormat).WithMessage(ResourceMessagesExceptions.FORMAT_INVALID);
        }

        private bool ValidateOriginalLogFormat(IFormFile file)
        {
            var logPattern = @"^\d{3}\|\d{3}\|[A-Za-z0-9]+?\|\""[A-Za-z]+ \/[^"" ]+ HTTP\/\d+\.\d+\""\|\d+\.\d+$";
            var isValid = false;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, logPattern))
                        isValid = true;
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
