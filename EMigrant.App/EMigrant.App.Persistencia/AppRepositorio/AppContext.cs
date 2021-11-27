using Microsoft.EntityFrameworkCore;
using EMigrant.App.Dominio;

namespace EMigrant.App.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Migrante> Migrantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = AllKeys_Grupo__4");
            }
        }
    }
}
