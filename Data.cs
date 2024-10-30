using Microsoft.EntityFrameworkCore;
using DocsAgenda.Models;
namespace DocsAgenda.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> AdmUsuarios { get; set; }
        public DbSet<Doctores> CatDoctores { get; set; }
        public DbSet<Agenda> CtaAgenda { get; set; }
    }
}
    