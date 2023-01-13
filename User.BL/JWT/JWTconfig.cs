using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.BL.JWT
{
    public class JWTconfig
    {
        public const string ISSUER = "https://localhost/:"; // издатель токена
        public const string AUDIENCE = "https://localhost/:"; // потребитель токена
        public const string KEY = "SecretKeyForJWTTechnologe25225";   // key for 
        public const int LIFETIME = 240;

        public static bool ValidateLifeTime(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
