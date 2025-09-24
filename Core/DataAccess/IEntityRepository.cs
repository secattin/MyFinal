// core katmanı diğer nesnelerden referans almaz
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntites,new() // class: referans tip olabilir, IEntites olabilir veya newlenebilir olmalı
    {
        List<T> GettAll(Expression<Func<T,bool>> filter=null);// filtreleme yapmazsak null döner
        T Get(Expression<Func<T, bool>> filter); // tek bir data döner
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        

    }
}
