﻿using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,ECommerceContext>,IProductDal
    {
    }
}
