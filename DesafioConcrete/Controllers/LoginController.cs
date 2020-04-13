using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioConcrete.Data;
using DesafioConcrete.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioConcrete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Authenticate([FromBody] Usuario usuario)
        {
            UsuarioContext dataBasee = new UsuarioContext();
            Usuario user = new Usuario();

            using (UsuarioContext db = new UsuarioContext())
            {
                user = db.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
            }

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha Inválidos" });
            }
            var token = TokenService.GenerateToken(user);
            user.Senha = "";

            user.UltimoLogin = DateTime.Now;
            dataBasee.Usuarios.Update(user);
            dataBasee.SaveChanges();

            return new ObjectResult(user);
        } 
    }
}