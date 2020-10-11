using Commento_sso_example.Extensions;
using Commento_sso_example.Services;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Commento_sso_example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public RedirectResult SignIn(string token, string hmac)
        {
            var service = new SignInService();

            byte[] secretKeyDecoded = ConfigurationManager.AppSettings["CommentoSsoSecretKey"].HexDecode();
            var tokenBytes = token.HexDecode();
            var hmacBytes = Convert.ToBase64String(hmac.HexDecode());

            HMACSHA256 newHmac = new HMACSHA256(secretKeyDecoded);
            var expectedHmac = Convert.ToBase64String(newHmac.ComputeHash(tokenBytes));

            if (hmacBytes != expectedHmac)
            {
                return Redirect("~/Shared/Error");
            }

            var payloadJson = service.GetUserDataJson(token);
            var payloadJsonBytes = Encoding.Default.GetBytes(payloadJson);

            var payloadHmac = newHmac.ComputeHash(payloadJsonBytes).HexEncode();
            var payloadHex = payloadJsonBytes.HexEncode();

            return Redirect("https://commento.io/api/oauth/sso/callback?payload=" + payloadHex + "&hmac=" + payloadHmac);
        }
    }
}
