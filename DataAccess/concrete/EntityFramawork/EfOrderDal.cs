﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramawork
{
    public class EfOrderDal:EfEntityRepositoryBase<Order,NorthwindeContex>,IOrderDal
    {
    }
}
