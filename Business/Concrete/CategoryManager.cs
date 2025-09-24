using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal  _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            // iş kodları
            return _categoryDal.GettAll();
        }
        // select * from categories where categoryıd=3
        public Category GetById(int CategoryId)
        {
            return _categoryDal.Get(c=>c.CategoryID == CategoryId);
        }
    }
}
