using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql.Repositorios
{
    public class ServicioRepository
    {
        private VeterinariaContext _db;
        public ServicioRepository(VeterinariaContext db) {
            _db = db;
        }

        public Servicio GuardarServicio(Servicio servicio) {

            _db.Servicio.Add(servicio);
            _db.SaveChanges();
            return servicio;
        }

        public List<Servicio> GetListaServicios() {
            return _db.Servicio.ToList();
        }

        public void Eliminar(int codigo) {
            Servicio servicio = _db.Servicio.FirstOrDefault(x => x.Codigo == codigo);
            _db.Servicio.Remove(servicio);
            _db.SaveChanges();
        }

        public Servicio GetServicio(int codigo, bool tracking = true) {
            if(tracking)
                return _db.Servicio.FirstOrDefault(x => x.Codigo == codigo);
            else
                return _db.Servicio.AsNoTracking().FirstOrDefault(x => x.Codigo == codigo);

        }
    }
}