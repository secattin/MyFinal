﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category: IEntites
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        
    }
}
