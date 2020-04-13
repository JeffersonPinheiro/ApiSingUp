using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DesafioConcrete.Data;
using DesafioConcrete.Models;
using DesafioConcrete.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioConcrete.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class SingUpController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            using (UsuarioContext db = new UsuarioContext())
            {
                return db.Usuarios.ToList();
            }

        }

        
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            using (UsuarioContext db = new UsuarioContext())
            {
                return db.Usuarios.FirstOrDefault( x => x.Id == id);
            }
        }

        
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            Usuario usuarios = new Usuario();
            Usuario VrfEmail = new Usuario();
            UsuarioContext dataBasee = new UsuarioContext();
            
            using (UsuarioContext db = new UsuarioContext())
            {
                VrfEmail = db.Usuarios.FirstOrDefault( x => x.Email == usuario.Email);
            }

            if (VrfEmail == null)
            {
                usuarios.Email = usuario.Email;
                usuarios.Nome = usuario.Nome;
                usuarios.Senha = usuario.Senha;
                usuario.Telefone.DDD = usuario.Telefone.DDD;
                usuario.Telefone.numero = usuario.Telefone.numero;
                usuarios.DataCriacao = DateTime.Now;
                usuarios.DataAtualizacao = DateTime.Now;
                usuarios.UltimoLogin = DateTime.Now;
                usuarios.Token = TokenService.GenerateToken(usuario);

                dataBasee.Usuarios.Add(usuarios);
                dataBasee.SaveChanges();

                return new ObjectResult(usuarios);
            }
            else
            {
                return NotFound("Email inválido ou inexistente");
            }
        }   
    }
}
