using Project.Bll.Dtos;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Validators.ModelsValidators
{
    public class CategoryDtoValidator : BaseValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            
                RequiredString(x => x.CategoryName, 2, 100, "Kategori adı boş geçilemez");
                RequiredString(x => x.Description, 5, 500, "Açıklama boş geçilemez");
            
        }
    }
}
