using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface ICartService
    {
        IDataResult<List<Cart>> GetByUserId(int userId);
        IResult Add(Cart cart);
        IResult Delete(Cart cart);
        IResult Update(Cart cart);


    }
}
