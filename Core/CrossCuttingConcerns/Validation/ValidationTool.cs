using Core.Utilities.Results;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool // bu gibi araçlar static yapılır
    {
        public static void Validation(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid) //eğer geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);   //hata fırlat 

            }





                //var context = new ValidationContext<Product>(product); //ürün doğrulayıcıyı kullanmak için context oluştur
                //ProductValidator productValidator = new ProductValidator();//ürün doğrulayıcı yarat ve  ürün doğrulayıcıyı kullan       
                //var result = productValidator.Validate(context);// ürün doğrulayıcıyı kullanarak doğrula
                //if (!result.IsValid)//eğer geçerli değilse hata fırlat
                //{
                //    throw new ValidationException(result.Errors);   //hata fırlat 

                //}
        }
    }
}


