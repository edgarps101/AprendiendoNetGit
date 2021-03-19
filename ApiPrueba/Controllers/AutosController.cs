using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        [HttpGet]
        public List<AutoModelo> Get()
        {
            return new AutoServicios().consultar();
        }

        [HttpGet("{id}")]
        public AutoModelo Get(int id)
        {
            return new AutoServicios().consultarId(id);
        }

        [HttpPost]
        public void Post([FromBody] AutoModelo autoModelo)
        {
            new AutoServicios().insertar(autoModelo);
        }

        [HttpPut]
        public void Put([FromBody] AutoModelo autoModelo)
        {
            new AutoServicios().actualizar(autoModelo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new AutoServicios().eliminar(id);
        }
    }
}
