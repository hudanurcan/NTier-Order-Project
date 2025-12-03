using FluentValidation;
using Project.Concrats.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.Products
{
    public class ProductResponseModelValidator  : AbstractValidator<ProductResponseModel>
    {
        public ProductResponseModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Response Id 0'dan büyük olmalı");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Response ürün adı boş dönemez")
                .Length(3, 80).WithMessage("Response ürün adı 3-80 karakter olmalı");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Response fiyat 0'dan büyük olmalı");

            RuleFor(x => x.CategoryId)
                .Must(id => id == null || id > 0)
                .WithMessage("Response CategoryId null ya da 0'dan büyük olmalı");
        }
    }
}
