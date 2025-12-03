using FluentValidation;
using Project.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ModelsValidators 
{
    public class OrderDtoValidator : BaseValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            // Adres zorunlu ve mantıklı uzunlukta olmalı
            RequiredString(x => x.ShippingAddress, 10, 250, "Adres boş geçilemez");

            // AppUserId null olabilir ama doluysa pozitif olmalı
            RuleFor(x => x.AppUserId)
                .Must(id => id == null || id > 0)
                .WithMessage("AppUserId null ya da 0'dan büyük olmalı");
        }
    }
}
