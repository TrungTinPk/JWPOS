using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Web.Services
{
    public class TokenSetting
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = String.Empty;
        public int ExpiryMinutes { get; set; } = 0;
    }
}
