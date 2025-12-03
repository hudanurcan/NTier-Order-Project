using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.ResponseModels.Orders
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
        //public DataStatus Status { get; set; }
    }
}
