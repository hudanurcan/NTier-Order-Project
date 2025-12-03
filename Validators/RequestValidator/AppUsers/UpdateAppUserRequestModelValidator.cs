using FluentValidation;
using Project.Concrats.Models.RequestModels.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.AppUsers
{
    public class UpdateAppUserRequestModelValidator
        : AbstractValidator<UpdateAppUserRequestModel>
    {
        public UpdateAppUserRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalı");

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
