using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
// http://www.kodlama.io
// hazır bir kütüphane kullanıyoruz//
// AOP - Aspect Oriented Programming - Yönelimli Programlama
// Core katmanında yazılır
// Attribute - Metotların önünde çalışır
// hazır aldık 
namespace Core.Utilities.Interceptors
{


    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
           

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
