using FluentValidation;
using Project.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.ModelsValidators
{
    public class OrderDetailDtoValidator : BaseValidator<OrderDetailDto>
    {
        public OrderDetailDtoValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId 0'dan büyük olmalı");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId 0'dan büyük olmalı");
        }
    }
}
