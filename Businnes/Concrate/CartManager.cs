using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrate
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public IResult Add(Cart cart)
        {
            
            var result = _cartDal.GetAll(c => c.ProductId == cart.ProductId);
            foreach (var item in result)
            {
                if (item.UserId==cart.UserId)
                {
                    item.Quantity++;
                    _cartDal.Update(item);
                    return new SuccessResult("Ürün Sepete Eklendi");
                }
            }
            _cartDal.Add(cart);
            return new SuccessResult("Ürün Sepete Eklendi");
            
            
            
        }

        public IResult Delete(Cart cart)
        {
            var remove =_cartDal.Get(c=>c.Id==cart.Id);
            _cartDal.Delete(remove);
            return new SuccessResult("Ürün Sepetten Silindi");
        }

        public IDataResult<List<Cart>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll(c=>c.UserId==userId));
        }

        public IResult Update(Cart cart)
        {
            var result = _cartDal.Get(c => c.Id == cart.Id);
            result.Quantity = cart.Quantity;
            _cartDal.Update(result);
            return new SuccessResult("Ürün güncellendi");
        }
    }
}
