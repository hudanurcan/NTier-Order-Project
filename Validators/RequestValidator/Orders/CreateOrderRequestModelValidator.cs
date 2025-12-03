using FluentValidation;
using Project.Concrats.Models.RequestModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.Orders
{
    public class CreateOrderRequestModelValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestModelValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Adres boş geçilemez")
                .MinimumLength(5).WithMessage("Adres en az 5 karakter olmalı")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olmalı");

            RuleFor(x => x.AppUserId)
                .Must(id => id == null || id > 0)
                .WithMessage("AppUserId null ya da 0'dan büyük olmalı");
        }
    }
}
