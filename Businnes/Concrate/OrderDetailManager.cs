using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrate
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult();
        }

        public IResult Delete(int OrderDetailId)
        {
            var remove = _orderDetailDal.Get(od=>od.Id==OrderDetailId);
            _orderDetailDal.Delete(remove);
            var result = _orderDetailDal.Get(od => od.Id == OrderDetailId);
            if (result==null)
            {
                return new SuccessResult();
            }
            return new ErorResult();
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll());
        }

        public IDataResult<List<OrderDetail>> GetAllByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(o=>o.OrderId==orderId));
        }

        public IResult Update(OrderDetail orderDetail)
        {
            var result = _orderDetailDal.Get(od => od.Id == orderDetail.Id);
            
            if (result!=null)
            {
                result.OrderDate = orderDetail.OrderDate;
                result.ProductId = orderDetail.ProductId;
                result.Quantity = orderDetail.Quantity;
                return new SuccessResult();
            }
            return new ErorResult();
        }
    }
}
