using System.Data.Entity;
using VoituresEF.Classes;

namespace VoituresEF.Data
{
    public class Contexte : DbContext
    {
        public DbSet<Marque> Marques { get; set; }

        public DbSet<Modele> Modeles { get; set; }

        public DbSet<Segment> Segments { get; set; }
    }

}
