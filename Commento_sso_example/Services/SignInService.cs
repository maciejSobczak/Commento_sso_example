using Commento_sso_example.Models;
using Newtonsoft.Json;

namespace Commento_sso_example.Services
{
    public class SignInService
    {
        public SignInService()
        {
        }

        public string GetUserDataJson(string token)
        {
            var user = new User();
            user.token = token;
            user.email = "kamil.kowalski@example.com";
            user.name = "Kamil Kowalski";
            user.link = "/Home/KamilK";
            user.photo = "~/Content/kamilK.jpg";

            return JsonConvert.SerializeObject(user);
        }
    }
}