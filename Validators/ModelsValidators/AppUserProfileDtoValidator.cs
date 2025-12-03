using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Bll.Dtos;

namespace Validators.ModelsValidators
{
    public class AppUserProfileDtoValidator : BaseValidator<AppUserProfileDto>
    {
        public AppUserProfileDtoValidator()
        {
            RequiredString(x => x.FirstName, 2, 50, "Ad boş geçilemez");
            RequiredString(x => x.LastName, 2, 50, "Soyad boş geçilemez");
        }
    }
}
