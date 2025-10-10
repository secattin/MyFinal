using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation.Caching
{
    public interface ICacheManager
    {
        T GetT<T>(string key);// generic yapı
        object Get(string key); 
        void Add(string key,object value,int duration);
        bool IsAdd(string key);// cachede var mı diye bakar
        void Remove(string key); // key e göre siler
        void RemoveByPattern(string pattern);// pattern e göre siler

    }
}
