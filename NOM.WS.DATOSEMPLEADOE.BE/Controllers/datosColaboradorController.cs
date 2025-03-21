using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NOM.WS.DATOSEMPLEADOE.BE.Controllers
{
    public class datosColaboradorController : ApiController
    {
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/colaborador/getall")]
        public IHttpActionResult Get(int id)
        {
            var colaboradores = new List<Colaborador>
            {
                new Colaborador { ID = 1, Nombre = "Juan Pérez", Edad = 30, Puesto = "Analista", Departamento = "TI", FechaIngreso = DateTime.Now.AddYears(-5) },
                new Colaborador { ID = 2, Nombre = "María López", Edad = 28, Puesto = "Diseñadora", Departamento = "Marketing", FechaIngreso = DateTime.Now.AddYears(-2) },
                new Colaborador { ID = 3, Nombre = "Carlos Gómez", Edad = 35, Puesto = "Gerente", Departamento = "Ventas", FechaIngreso = DateTime.Now.AddYears(-7) },
                new Colaborador { ID = 4, Nombre = "Ana Torres", Edad = 25, Puesto = "Programadora", Departamento = "TI", FechaIngreso = DateTime.Now.AddYears(-1) },
                new Colaborador { ID = 5, Nombre = "Luis Ramírez", Edad = 40, Puesto = "Director", Departamento = "RRHH", FechaIngreso = DateTime.Now.AddYears(-10) }
            };

            return Ok(colaboradores);

        }

        public class Colaborador
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public string Puesto { get; set; }
            public string Departamento { get; set; }
            public DateTime FechaIngreso { get; set; }
        }
    }
}