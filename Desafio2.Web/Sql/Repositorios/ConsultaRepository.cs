using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desafio2.Web.Sql.Repositorios
{
    public class ConsultaRepository
    {
        private VeterinariaContext _db;
        public ConsultaRepository(VeterinariaContext db) {
            _db = db;
            _db.Configuration.LazyLoadingEnabled = false;
        }

        public Consulta GuardarConsulta(Consulta consulta)
        {
           
            _db.Consulta.Add(consulta);                
            _db.SaveChanges();
           
            return consulta;
        }

        public List<Consulta> GetListaConsultas(bool tracking = true) {

            if(tracking)
                return _db.Consulta
                    .Include(x=>x.Cliente)
                    .Include(x=>x.Mascota)
                    .Include(x=>x.Servicio).ToList();
            else
                return _db.Consulta.AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.Mascota)
                .Include(x => x.Servicio).ToList();

        }

        public void Eliminar(int codigo) {
            Consulta consulta = _db.Consulta.FirstOrDefault(x => x.Codigo == codigo);
            _db.Consulta.Remove(consulta);
            _db.SaveChanges();
        }

        public Consulta GetConsulta(int codigo) {
            return _db.Consulta.FirstOrDefault(x => x.Codigo == codigo);
        }
    }
}