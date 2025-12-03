using FluentValidation;
using Project.Concrats.Models.RequestModels.AppUserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.AppUserProfiles
{
    public class CreateAppUserProfileRequestModelValidator : AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileRequestModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş geçilemez")
                .Length(2, 50).WithMessage("Ad 2-50 karakter olmalı");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş geçilemez")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter olmalı");
        }
    }
}
