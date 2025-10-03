using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p => p.ProductName).NotEmpty();//boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);//en az 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty();// Unitprice boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);// 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);// eğer kategori 1 ise fiyatı 10 dan büyük veya eşit olmalı
            RuleFor(p => p.ProductName).Must(startWithA).WithMessage("Ürünler A harfi ile başlamalı");//ürünler A harfi ile başlamalı
        }
        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");

        }
        
    }

}
