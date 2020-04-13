using DesafioConcrete.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace DesafioConcrete.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-QLMN6CM@jeffe;Initial Catalog=master;Data Source=DESKTOP-QLMN6CM");
        }

    }
}
