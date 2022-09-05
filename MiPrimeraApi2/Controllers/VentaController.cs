using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public List<Usuario> GetVentas()
        {
            return new List<Usuario>();
        }

        [HttpPost]
        public void Actualizar([FromBody] int Id, string Comentario)
        {
            VentaHandler.Actualizar(Id, Comentario);
        }

        [HttpPut]
        public void Crear([FromBody] int Id, string Comentario)
        {
            VentaHandler.Crear(Id, Comentario);
        }
        
        [HttpDelete]
        public void Eliminar([FromBody] int Id, string Comentario)
        {
            VentaHandler.Eliminar(Id);
        }
    }
}
