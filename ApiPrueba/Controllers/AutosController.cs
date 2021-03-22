using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicios;
using Servicios.Servicios.Interfaces;
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
        private readonly IAutoServicio servicioAuto;

        public AutosController(IAutoServicio servicioAuto)
        {
            this.servicioAuto = servicioAuto;
        }

        [HttpGet]
        public List<AutoModelo> Get()
        {
            return servicioAuto.consultar();
        }

        [HttpGet("{id}")]
        public AutoModelo Get(int id)
        {
            return servicioAuto.consultarId(id);
        }

        [HttpPost]
        public void Post([FromBody] AutoModelo autoModelo)
        {
            servicioAuto.insertar(autoModelo);
        }

        [HttpPut]
        public void Put([FromBody] AutoModelo autoModelo)
        {
            servicioAuto.actualizar(autoModelo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            servicioAuto.eliminar(id);
        }
    }
}
