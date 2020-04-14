using RestApi.DataLoader.Auth;
using RestApi.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controller
{
    public class AuthController : ApiController
    {
        [HttpGet]
        public string TestMethod()
        {
            return "Success";
        }

        [HttpPost]
        public bool CheckLogin(UserData user)
        {
            AuthDataLoader loader = new AuthDataLoader();
            return loader.CheckLogin(user);
        }

        [HttpPost]
        public bool CreateUser(UserData user)
        {
            AuthDataLoader loader = new AuthDataLoader();
            return loader.CreateUser(user);
        }
    }
}
