using Abhi_Silver_Plating_Shop.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abhi_Silver_Plating_Shop.Validator
{
    public class ConnectionValidator : AbstractValidator<ConnectionModel>
    {
        public ConnectionValidator()
        {
            RuleFor(c => c.Server).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength("localhost".Length);

            RuleFor(c => c.Database).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(c => c.ShopName).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10);

            RuleFor(c => c.Username).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(c => c.Password).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
        }
    }
}
