using FluentValidation;
using Project.Concrats.Models.ResponseModels.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.AppUsers
{
    public class AppUserResponseModelValidator
        : AbstractValidator<AppUserResponseModel>
    {
        public AppUserResponseModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName boş dönemez")
                .Length(3, 50).WithMessage("UserName 3-50 karakter olmalı");
        }
    }
}
