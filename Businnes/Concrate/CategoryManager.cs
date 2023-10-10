using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;        
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(int categoryId)
        {
            var remove = _categoryDal.Get(c => c.Id == categoryId);
            _categoryDal.Delete(remove);
            var result = _categoryDal.Get(c => c.Id == categoryId);
            if (result==null)
            {
                return new SuccessResult("Categori Silindi");
            }
            return new ErorResult("Categori silinemedi");
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IResult Update(Category category)
        {
            Category result = _categoryDal.Get(c=>c.Id==category.Id);
            if (result.Id!=0)
            {
                result.Desc = category.Desc;
                result.Name = category.Name;
                return new SuccessResult("Categori güncellendi");
            }
            return new ErorResult("Categori güncellenmedi");
        }
    }
}
