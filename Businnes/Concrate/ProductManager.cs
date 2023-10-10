using Businnes.Abstract;
using Businnes.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Business;
using Businnes.BusinnesAspects.Autofac;

namespace Businnes.Concrate
{   
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; 
        }
        //[SecuredOperation("product.add,admin,product.admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result=BusinessRules.Run(CheckIfProductCounCategoryCorrect(product), CheckIfProductNameExists(product.Name));            
            if (result==null)
            {
                _productDal.Add(product);
                return new SuccessResult("Ürün Eklendi");
            }
            return new ErorResult();
        }
       
        public IResult Delete(int productId)
        {
            var remove = _productDal.Get(p=>p.Id==productId);
            _productDal.Delete(remove);
            var result = _productDal.Get(p => p.Id == productId);
            if (result==null)
            {
                return new SuccessResult("Ürün silindi");
            }
            return new ErorResult("Ürün silinemedi");
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult <List<Product>>(_productDal.GetAll(), "Ürün listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.Id==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            var result = _productDal.Get(p=>p.Id== product.Id);
            if (result.Id!=0)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.Quantity = product.Quantity;
                result.Desc = product.Desc;
                result.CategoryId = product.CategoryId;
                return new SuccessResult("Ürün güncellendi");
            }
            return new ErorResult("Ürün güncellenemedi");
        }
        private IResult CheckIfProductCounCategoryCorrect(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count > 10;
            if (result)
            {
                return new ErorResult("İstenilen categoride 10 dan fazla ürün olamaz");
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.Name == productName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErorResult();
        }
    }
}
