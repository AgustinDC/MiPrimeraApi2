using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;
using MiPrimeraApi2.Controllers.DTO;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            return new List<Usuario>();
        }


        [HttpGet("{NombreUsuario}/{Contraseña}")]
        public Usuario UsuarioConContraseña(string NombreUsuario, string Contraseña)
        {
            Usuario usuario = UsuarioHandler.UsuarioConContraseña(NombreUsuario, Contraseña);
            return new Usuario();
        }

        [HttpPut]
        public void Actualizar([FromBody] PutUsuario usuario)
        {
            UsuarioHandler.Actualizar(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
        }

        [HttpPost]
        public void Crear([FromBody] PostUsuario usuario)
        {
            UsuarioHandler.Crear(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail
            });
        }

        [HttpDelete]
        public void Eliminar([FromBody] int Id)
        {
            UsuarioHandler.Eliminar(Id);
        }
    }
}
