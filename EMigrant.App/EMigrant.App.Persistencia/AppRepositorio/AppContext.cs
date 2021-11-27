using Microsoft.EntityFrameworkCore;
using EMigrant.App.Dominio;

namespace EMigrant.App.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<GrupoFamiliar> Familiares { get; set; }
        public DbSet<Amigos> Amigos { get; set; }
        public DbSet<Parientes> Parientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = AllKeys_Grupo__4");
            }
        }
    }
}
/*
dotnet ef migrations add Migracion2.3 --startup-project ..\EMigrant.App.Consola\
dotnet ef database update --startup-project ..\EMigrant.App.Consola\
*/