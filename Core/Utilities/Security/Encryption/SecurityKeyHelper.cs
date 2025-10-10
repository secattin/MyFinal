using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static  SecurityKey  CreateSecurityKey(string securityKey)  // SecurityKey bura onu byte haline getiriyor.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // byte alıp simetrik hale getiriyor
        }
    }
}
