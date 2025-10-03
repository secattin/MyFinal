using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi  geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductsListed = "ürün eklendi";
        public static string ProductCountOfEror ="bir kategoride en fazla 10 tane olabilir";
        public static string ProductNameError = "ürün ismi geçersiz";
        public static string CategoryLimitExceded ="katagori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
