using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SifirAtik.Utils.AuthenticationKeys
{
    public class KeyGenerator
    {
        public static SymmetricSecurityKey GenerateSymmetricSecurityKey(string secretKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
    }
}
