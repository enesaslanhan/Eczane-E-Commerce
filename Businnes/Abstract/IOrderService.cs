using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IResult Add(Order order);
        IResult Delete(int OrderId);
        IResult Update(Order order);
        IResult GetById(int OrderId);

    }
}
