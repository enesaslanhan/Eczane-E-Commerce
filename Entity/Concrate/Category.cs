using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }


    }
}
