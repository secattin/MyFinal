using Castle.DynamicProxy;
using System;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
// http://www.kodlama.io
// hazır bir kütüphane kullanıyoruz//
// AOP - Aspect Oriented Programming - Yönelimli Programlama
// Core katmanında yazılır
// Attribute - Metotların önünde çalışır
// hazır aldık 
namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
