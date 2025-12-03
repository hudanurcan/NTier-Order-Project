using FluentValidation;
using Project.Concrats.Models.ResponseModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.Orders
{
    public class OrderResponseModelValidator : AbstractValidator<OrderResponseModel>
    {
        public OrderResponseModelValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Response adres boş dönemez")
                .MinimumLength(5).WithMessage("Response adres en az 5 karakter olmalı")
                .MaximumLength(200).WithMessage("Response adres en fazla 200 karakter olmalı");

            RuleFor(x => x.AppUserId)
                .Must(id => id == null || id > 0)
                .WithMessage("Response AppUserId null ya da 0'dan büyük olmalı");
        }
    }
}
