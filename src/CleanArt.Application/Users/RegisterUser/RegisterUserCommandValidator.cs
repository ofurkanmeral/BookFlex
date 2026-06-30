using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandValidator :AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator() 
        {
            RuleFor(c=>c.FirstName).NotEmpty();
            RuleFor(c=>c.LastName).NotEmpty();
            RuleFor(c=>c.Email).NotEmpty();
            RuleFor(c=>c.Password).NotEmpty().MinimumLength(5).WithMessage("Lütfen Daha Güçlü Bir Şifre Giriniz");
        }
    }
}
