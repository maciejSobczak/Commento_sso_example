using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Commento_sso_example.Models
{
    public class User
    {
        public string token { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string photo { get; set; }
    }
}