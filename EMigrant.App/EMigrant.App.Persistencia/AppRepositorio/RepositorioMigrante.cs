using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioMigrante
    {
        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Migrante> GetAll()
        {
            return _appContext.Migrantes;
        }
        public Migrante Update(Migrante newMigrante)
        {
            var encom = _appContext.Migrantes.SingleOrDefault(b => b.id == newMigrante.id);
            if (encom != null)
            {
                encom.id = newMigrante.id;
                encom.nombre = newMigrante.nombre;
                encom.apellidos = newMigrante.apellidos;
                encom.tipoIdentificacion = newMigrante.tipoIdentificacion;
                encom.numeroDocumento = newMigrante.numeroDocumento;
                encom.paisOrigen = newMigrante.paisOrigen;
                encom.fechaNacimiento = newMigrante.fechaNacimiento;
                encom.telefono = newMigrante.telefono;
                encom.direccionElectronica = newMigrante.direccionElectronica;
                encom.direccionActual = newMigrante.direccionActual;
                encom.ciudad = newMigrante.ciudad;
                encom.situacionLaboral = newMigrante.situacionLaboral;
                _appContext.SaveChanges();
            }
            return encom;
        }
        public Migrante Create(Migrante newMigrante)
        {
            var addMigrante = _appContext.Migrantes.Add(newMigrante);
            _appContext.SaveChanges();
            return addMigrante.Entity;
        }
        /*public void Delete(int id)
        {
        var encom= _appContext.Encomiendas.Find(id);
        if(encom != null){
                return;
            }
        _appContext.Encomiendas.Remove(encom);
        _appContext.SaveChanges();
        }*/

        public Migrante GetWithId(int id)
        {
            return _appContext.Migrantes.Find(id);
        }
    }


}