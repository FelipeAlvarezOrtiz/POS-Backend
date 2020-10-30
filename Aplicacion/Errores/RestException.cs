using System;
using System.Net;

namespace Aplicacion.Errores
{
    public class RestException : Exception
    {
        public HttpStatusCode Code { get; }
        public object Errores { get; }

        public RestException(HttpStatusCode code, object errores = null)
        {
            Code = code;
            Errores = errores;
        }
    }
}
