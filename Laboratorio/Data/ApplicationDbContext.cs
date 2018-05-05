using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Models;

namespace Laboratorio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<PostoColeta> PostoColeta { get; set; }

        public DbSet<Convenio> Convenio { get; set; }

        public DbSet<Exame> Exame { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Solicitante> Solicitante { get; set; }

        public DbSet<TabelaPreco> TabelaPreco { get; set; }

        public DbSet<ItemTabelaPreco> ItensTabelaPreco { get; set; }

        public DbSet<Requisicao> Requisicao { get; set; }

        public DbSet<ItemRequisicaoTemp> ItemRequisicaoTemp { get; set; }

        public DbSet<ItemRequisicao> ItemRequisicao { get; set; }
    }
}
