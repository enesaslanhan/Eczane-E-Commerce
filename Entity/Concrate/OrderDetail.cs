using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrate
{
    public class OrderDetail : IEntity 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
