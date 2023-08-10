using System.Collections.Generic;
using Dominio;

namespace Aplicacion.Contratos
{
    public interface IJwtGenerador
    {
        string CrearToken(Usuario usuario, List<string> roles);
    }
}

// Agregamos los apquetes a la identidad model para los Tokens:
// dotnet add package System.IdentityModel.Tokens.Jwt --version="6.5.0"