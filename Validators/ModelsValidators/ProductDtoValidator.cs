using FluentValidation;
using Project.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ModelsValidators
{
    public class ProductDtoValidator : BaseValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            // Ürün adı zorunlu ve makul uzunlukta olmalı
            RequiredString(x => x.ProductName, 3, 80, "Ürün adı boş geçilemez");

            // Fiyat 0'dan büyük olmalı
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");

            // CategoryId null olabilir ama doluysa pozitif olmalı
            RuleFor(x => x.CategoryId)
                .Must(id => id == null || id > 0)
                .WithMessage("Kategori Id null ya da 0'dan büyük olmalı");
        }
    }
}
