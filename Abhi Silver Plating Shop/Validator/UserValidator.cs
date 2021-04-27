using Abhi_Silver_Plating_Shop.Model;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Abhi_Silver_Plating_Shop.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .Length(5, 10)
                .Must(ValidUsername).WithMessage("{PropertyName} should contains only alphabets")
                .Must(RestrictSpacesInBetween).WithMessage("{PropertyName} Space not allowed.");

            RuleFor(u => u.Password).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);

            RuleFor(u => u.Role).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .Length(3, 20);
        }

        /// <summary>
        ///  If method return true then validation will pass
        /// </summary>
        /// <param name="username"></param>
        /// <returns>boolean</returns>
        protected static bool ValidUsername(string username)
        {
            username = username.Replace(" ", "").Replace("-", "");
            return username.All(Char.IsLetter);
        }

        protected static bool RestrictSpacesInBetween(string username)
        {
            return !Regex.IsMatch(username, @"\s");
        }
    }
}
