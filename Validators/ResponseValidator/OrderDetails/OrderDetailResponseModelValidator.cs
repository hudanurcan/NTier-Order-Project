using FluentValidation;
using Project.Concrats.Models.RequestModels.OrderDetails;
using Project.Concrats.Models.ResponseModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ResponseValidator.OrderDetails
{
    public class OrderDetailResponseModelValidator : AbstractValidator<OrderDetailResponseModel>
    {
        public OrderDetailResponseModelValidator()
        {
            //RuleFor(x => x.Id)
            //    .GreaterThan(0).WithMessage("Response Id 0'dan büyük olmalı");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Response OrderId 0'dan büyük olmalı");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Response ProductId 0'dan büyük olmalı");
        }
    }
}
