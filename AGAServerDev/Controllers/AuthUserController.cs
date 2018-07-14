using AGAServerDev.Models;
using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class AuthUserController : Controller
    {
        // Post: AuthUser - Login
        [HttpPost]
        public JsonResult Login(AUTH_USER auth_user)
        {
            AUTH_USER_SERV serv = new AUTH_USER_SERV();
            var obj = serv.Login(auth_user);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        // Post: AuthUser - Permiso
        [HttpPost]
        public JsonResult Permisos(AUTH_USER auth_user)
        {
            AUTH_USER_SERV serv = new AUTH_USER_SERV();
            var obj = serv.Permisos(auth_user);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        // Post: AuthUser - Perfil de Usuario
        [HttpGet]
        public JsonResult PerfilUsuario(string IdModulo)
        {
            AUTH_USER_SERV serv = new AUTH_USER_SERV();
            var obj = serv.GetUserProfile(IdModulo);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}