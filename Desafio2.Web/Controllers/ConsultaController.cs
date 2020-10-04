using Desafio2.Web.DTO;
using Desafio2.Web.Models;
using Desafio2.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desafio2.Web.Controllers
{
    public class ConsultaController : Controller
    {

        private ClinicaService _clinicaService;
        public ConsultaController(ClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }
        // GET: Consulta
        public ActionResult GetClientes()
        {
            return Json(_clinicaService.GetClientes(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMascotas(string dui)
        {
            return Json(_clinicaService.GetMascotas(dui), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServicios()
        {
            return Json(_clinicaService.GetServicios(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetConsultas()
        {
            return Json(_clinicaService.GetConsultas(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarConsulta(ConsultaDTO data)
        {
                     
            List<Consulta> consultas = _clinicaService.GetConsultas(false);
            Servicio servicio = _clinicaService.GetServicio(data.idServicio,false);

            _clinicaService.GuardarConsulta(new Consulta()
            {              
                IdCliente = data.dui,
                IdMascota = data.idMascota,
                IdServicio = data.idServicio,
                Descuento = GetDescuento(consultas, data.dui),
                Total = servicio.Precio - (servicio.Precio * GetDescuento(consultas, data.dui))
            });

            return Json(_clinicaService.GetConsultas(),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarCliente(ClienteDTO cliente)
        {


            Cliente c = _clinicaService.GuardarCliente(new Cliente() { 
                Dui = cliente.dui,
                Nombre = cliente.nombre,
                Celular = cliente.celular,
                Mascotas = new List<Mascota>()
                {
                    new Mascota(){IdCliente = cliente.dui, Nombre = cliente.nombreMascota}
                }
            });

            return Json(c, JsonRequestBehavior.AllowGet);
        }

        private decimal GetDescuento(List<Consulta> consultas, string dui)
        {
            int cantidad = consultas.Where(x => x.IdCliente == dui).Count();

            if (cantidad >= 2 && cantidad <= 4)
                return new decimal(0.05);

            if (cantidad > 4)
                return new decimal(0.10);

            return 0;
        }
    }
}