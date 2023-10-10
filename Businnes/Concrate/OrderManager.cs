using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrate
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Sipariş eklendi");
        }

        public IResult Delete(int orderId)
        {
            var remove = _orderDal.Get(o=>o.Id==orderId);
            _orderDal.Delete(remove);
            var result = _orderDal.Get(o => o.Id == orderId);
            if (result==null)
            {
                return new SuccessResult("Sipariş silindi.");
            }
            return new ErorResult("Sipariş silinmedi.");
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IResult GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.Id==orderId));
        }

        public IResult Update(Order order)
        {
            var result = _orderDal.Get(o=>o.Id==order.Id);
            if (result!=null)
            {
                result.Total = order.Total;
                return new SuccessResult();
            }
            return new ErorResult();
        }
    }
}
