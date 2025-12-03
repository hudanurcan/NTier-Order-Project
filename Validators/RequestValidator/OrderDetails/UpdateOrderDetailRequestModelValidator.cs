using FluentValidation;
using Project.Concrats.Models.RequestModels.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.RequestValidator.OrderDetails
{
    public class UpdateOrderDetailRequestModelValidator : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalı");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId 0'dan büyük olmalı");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId 0'dan büyük olmalı");
        }
    }
}
