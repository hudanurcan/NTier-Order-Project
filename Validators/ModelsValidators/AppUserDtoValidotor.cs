using Project.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Validators.ModelsValidators
{
    public class AppUserDtoValidator : BaseValidator<AppUserDto>
    {
        public AppUserDtoValidator()
        {
            //// UserName doğrulaması
            //RuleFor(x => x.UserName)
            //    .Length(3, 50).WithMessage("UserName must be between 3 and 50 characters");

            //// Password doğrulaması
            //RuleFor(x => x.Password)
            //    .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            //    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter");
            RequiredString(x => x.UserName, 3, 50, "Kullanıcı adı boş geçilemez");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı")
                .Matches("[A-Z]").WithMessage("Şifre en az 1 büyük harf içermeli");
        }
    }
}
