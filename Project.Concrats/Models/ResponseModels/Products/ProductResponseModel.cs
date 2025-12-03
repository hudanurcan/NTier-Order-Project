using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.ResponseModels.Products
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
