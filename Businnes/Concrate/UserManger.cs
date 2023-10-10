using Businnes.Abstract;
using Businnes.BusinnesAspects.Autofac;
using Businnes.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrate;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businnes.Concrate
{
    public class UserManger : IUserService
    {
        IUserDal _userDal;
        public UserManger(IUserDal userDal)
        {
            _userDal = userDal;
        }

        
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            var result=BusinessRules.Run(UserLogControl(user));
            if (result==null)
            {
                _userDal.Add(user);
                return new SuccessResult("Kullanıcı sisteme eklendi");
            }
            return new ErorResult();
            
        }

        public IResult Delete(int userId)
        {
            var remove = _userDal.Get(u=>u.UserId==userId);
            _userDal.Delete(remove);
            var result = _userDal.Get(u => u.UserId == userId);
            if (result==null)
            {
                return new SuccessResult("Kullanıcı silindi");
            }
            return new ErorResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll()); 
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==userId));
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u=>u.UserId==user.UserId);
            if (result!=null)
            {
                
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                //result.Password = user.Password;
                result.Email = user.Email;
                return new SuccessResult();
            }
            return new ErorResult();
        }
        private IResult UserLogControl(User user)
        {
            var result = _userDal.GetAll(u=>u.Email==user.Email).Any();
            if (result)
            {
                return new ErorResult("Sistemde aynı Telefon numarasına ait kayıt bulunmaktadır.");
            }
            return new SuccessResult();
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}
