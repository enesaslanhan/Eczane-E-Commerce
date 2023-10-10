using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrate
{
    public class Order : IEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
    }
}
