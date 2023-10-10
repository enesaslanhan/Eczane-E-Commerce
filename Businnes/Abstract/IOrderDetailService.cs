using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<List<OrderDetail>> GetAllByOrderId(int OrderId);
        IResult Add(OrderDetail orderDetail);
        IResult Delete(int OrderDetailId);
        IResult Update(OrderDetail orderDetail);
    }
}
