using Francis_Castillo_P1_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace Francis_Castillo_P1_AP1.Components.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<ParcialModelo> Parcial { get; set; }

    }
}
