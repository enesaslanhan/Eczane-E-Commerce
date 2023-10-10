using Core.Entities.Concrate;
using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int userId);
        IResult Update(User user);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<User> GetByEmail(string email);
    }
}
