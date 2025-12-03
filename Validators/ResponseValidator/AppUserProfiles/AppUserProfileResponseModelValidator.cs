using FluentValidation;
using Project.Concrats.Models.RequestModels.AppUserProfiles;
using Project.Concrats.Models.ResponseModels.AppUserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.AppUserProfiles
{
    public class AppUserProfileResponseModelValidator : AbstractValidator<AppUserProfileResponseModel>
    {
        public AppUserProfileResponseModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş dönemez")
                .Length(2, 50).WithMessage("Ad 2-50 karakter olmalı");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş dönemez")
                .Length(2, 50).WithMessage("Soyad 2-50 karakter olmalı");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status geçerli bir enum olmalı");
        }
    }
}
