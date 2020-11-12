using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05
{
    public interface IManejarArchivo<T>
    {
        IFormFile ArchivoCargado { get; set; }
        T carriles { get; set; }
        string nuevoNombre { get; set; }
        string llave { get; set; }
        int tamaño { get; set; }
    }
}
