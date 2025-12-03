using FluentValidation;
using Project.Concrats.Models.RequestModels.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.AppUsers
{
    public class CreateAppUserRequestModelValidator
        : AbstractValidator<CreateAppUserRequestModel>
    {
        public CreateAppUserRequestModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName boş geçilemez")
                .Length(3, 50).WithMessage("UserName 3-50 karakter olmalı");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı")
                .Matches("[A-Z]").WithMessage("Şifre en az 1 büyük harf içermeli");
        }
    }
}
