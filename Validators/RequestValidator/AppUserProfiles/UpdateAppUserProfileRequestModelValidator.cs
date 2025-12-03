using FluentValidation;
using Project.Concrats.Models.RequestModels.AppUserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.AppUserProfiles
{
    public class UpdateAppUserProfileRequestModelValidator : AbstractValidator<UpdateAppUserProfileRequestModel>
    {
        public UpdateAppUserProfileRequestModelValidator()
        {
            //RuleFor(x => x.Id)
            //    .GreaterThan(0).WithMessage("Id 0'dan büyük olmalı");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş geçilemez")
                .Length(2, 50).WithMessage("Ad 2-50 karakter olmalı");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş geçilemez")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter olmalı");
        }
    }
}
