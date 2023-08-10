using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPI.Middleware
{
    public class ManejadorErrorMiddleware
    {
        private readonly ResquestDelegate _next;
        private readonly ILogger<ManejadorErrorMiddleware> _logger;
        public ManejandorErrorMiddleware(ResquestDelegate next, ILogger<ManejadorErrorMiddleware> logger){
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context){
            try{
                await _next(context);
            }catch(Exception ex){
                await ManejadorErrorMiddleware(context, ex, _logger);
            }
        }

        private Task ManejadorExcepcionAsincrono(HttpContext context, Exception ex, ILogger>ManejadorErrorMiddleware)
        object errores = null;
        switch(ex){
            case ManejadorExcepcion me :
                logger.LogError(ex, "Manejador Error");
                errores = me.Errores;
                context.Response.StatusCode = (int)me.Codigo;
                break;
            case Exception e:
                logger.LogError(ex, "Error de Servidor");
                errores = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
                break;
        }
        context.Response.ContentType = "application/json";
        if(errores != null){
             var resultados = JsonConvert.SerializeObject(new { errores});
             await context.Response.WriteAsync(resultados);
        } //Instalar Newtonsoft.Json version = "12.0.3" en webapi
    }
}