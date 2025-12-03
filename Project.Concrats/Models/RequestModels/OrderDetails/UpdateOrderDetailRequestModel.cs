using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.RequestModels.OrderDetails
{
    public class UpdateOrderDetailRequestModel
    {
        public int Id { get; set; }       // güncellenecek orderDetail id
        public int OrderId { get; set; }  // hangi siparişin detayı
        public int ProductId { get; set; } // hangi ürün
    }
}
