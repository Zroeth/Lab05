using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05
{
    public class ImplementationRuta
    {
        public static void Cifrado(string path, string root, int tamaño)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Ruta\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Ruta\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Ruta cifrado = new Ruta(texto, tamaño);
            string txtcifrado = cifrado.Cifrado();
            txtcifrado = txtcifrado.Replace("┼", "");
            List<char> bytecompress = new List<char>();

            root = root + @"\\Upload\\Vertical\\cifrado.Ruta";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
        }

        public static void Descifrado(string path, string root, int tamaño)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Ruta\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Ruta\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Ruta descifrado = new Ruta(texto, tamaño);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado = txtdescifrado.Replace("┼", "");
            root = root + @"\\Upload\\Vertical\\descifradoRuta.txt";
            txtdescifrado = txtdescifrado.Replace("↔", "");
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtdescifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
        }

    }
}
