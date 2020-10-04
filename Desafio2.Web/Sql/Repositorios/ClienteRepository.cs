using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desafio2.Web.Sql.Repositorios
{
    public class ClienteRepository
    {
        private VeterinariaContext _db;
        public ClienteRepository(VeterinariaContext db) {
            _db = db;
        }

        public Cliente GuardarCliente(Cliente cliente) {

            Cliente remoto = _db.Cliente.Include(x=>x.Mascotas).FirstOrDefault(x => x.Dui == cliente.Dui);
            if (remoto != null)
            {
                remoto.Celular = cliente.Celular;                
                remoto.Nombre = cliente.Nombre;
                if (!remoto.Mascotas.Any(x => x.Nombre.ToLower() == cliente.Mascotas.First().Nombre.ToLower()))
                    remoto.Mascotas.Add(cliente.Mascotas.First());
            }
            else {
                _db.Cliente.Add(cliente);
                remoto = cliente;
            }
            _db.SaveChanges();
            return remoto;
        }

        public List<Cliente> GetListaClientes() {           
            return _db.Cliente.Include(x=>x.Mascotas).ToList();
        }

        public Cliente GetCliente(string dui) {
            return _db.Cliente.Include(x=>x.Mascotas).FirstOrDefault(x => x.Dui == dui);
        }

        public void EliminarCliente(string dui) {
            Cliente cliente = _db.Cliente.FirstOrDefault(x => x.Dui == dui);
            _db.Cliente.Remove(cliente);
            _db.SaveChanges();
        }

    }
}