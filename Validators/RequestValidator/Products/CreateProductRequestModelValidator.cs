using FluentValidation;
using Project.Concrats.Models.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.Products
{
    public class CreateProductRequestModelValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestModelValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş geçilemez")
                .Length(3, 80).WithMessage("Ürün adı 3-80 karakter olmalı");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");

            RuleFor(x => x.CategoryId)
                .Must(id => id == null || id > 0)
                .WithMessage("CategoryId null ya da 0'dan büyük olmalı");
        }
    }
}
