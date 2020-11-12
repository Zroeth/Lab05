using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05
{
    public class ManejarArchivo : IManejarArchivo<int>
    {
        public IFormFile files { get; set; }
        public int carriles { get; set; }
        public string nuevoNombre { get; set; }
        public string llave { get; set; }
        public int tamaño { get; set; }
        IFormFile IManejarArchivo<int>.ArchivoCargado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
