using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.RequestModels.Products
{
    public class UpdateProductRequestModel
    {
        //public int Id { get; set; } // güncellencek ürün id si
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
