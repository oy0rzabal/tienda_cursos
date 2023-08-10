using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using Dominio;
using Persistencia;
using System.Linq;

namespace WebAPI.Controllers
{
    //localhaost:500/WeatherForecsat
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {
        private readonly CursosOnlineContext context;
        private readonly CursosOnlineContext _context;

        public WeatherForecastController(CursosOnlineContext context){
            this.context = _context;
        }

            [HttpGet]
        public IEnumerable<CursoDto> Get(){
            return context.Curso.ToList();
        }
    }
}