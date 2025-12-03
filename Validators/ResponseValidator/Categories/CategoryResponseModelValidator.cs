using FluentValidation;
using Project.Concrats.Models.ResponseModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.Categories
{
    public class CategoryResponseModelValidator : AbstractValidator<CategoryResponseModel>
    {
        public CategoryResponseModelValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .Length(3, 50).WithMessage("Kategori adı 3 - 50 karakter arasında olmalıdır");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş geçilemez")
                .Length(5, 200).WithMessage("Açıklama  5 - 200 karakter arasında olmalıdır");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Durum enum type olmalıdır");
        }
    }
}
