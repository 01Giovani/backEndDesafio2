using Desafio2.Web.Models;
using Desafio2.Web.Sql.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Services
{
    public class ClinicaService
    {
        private ClienteRepository _clienteRepository;
        private ConsultaRepository _consultaRepository;
        private ServicioRepository _servicioRepository;
        public ClinicaService(
            ClienteRepository clienteRepository,
            ConsultaRepository consultaRepository,
            ServicioRepository servicioRepository
            ) {

            _clienteRepository = clienteRepository;
            _consultaRepository = consultaRepository;
            _servicioRepository = servicioRepository;
        }

        public List<Cliente> GetClientes() {
            
            return _clienteRepository.GetListaClientes();
        }

        public List<Mascota> GetMascotas(string  dui)
        {
            Cliente cliente = _clienteRepository.GetCliente(dui);
            return cliente?.Mascotas ?? new List<Mascota>();
        }

        public List<Servicio> GetServicios() {
            return _servicioRepository.GetListaServicios();
        }

        public List<Consulta> GetConsultas(bool tracking = true)
        {
            List<Consulta> consultas = _consultaRepository.GetListaConsultas(tracking);
            consultas.ForEach(x => x.Cliente.Mascotas = new List<Mascota>());
            return consultas;
        }


        public Cliente GetCliente(string dui)
        {
            return _clienteRepository.GetCliente(dui);
        }

        public Cliente GuardarCliente(Cliente cliente)
        {
            return _clienteRepository.GuardarCliente(cliente);
        }

        public List<Consulta> GuardarConsulta(Consulta consulta)
        {
            _consultaRepository.GuardarConsulta(consulta);
            return _consultaRepository.GetListaConsultas();
        }

        public Servicio GetServicio(int codigo,bool tracking = true)
        {
            return _servicioRepository.GetServicio(codigo,tracking);
        }
    }
}