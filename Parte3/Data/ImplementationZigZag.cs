using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05
{
    public static class ImplementationZigZag
    {
        public static void Cifrado(string path, string root, int niveles)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\ZigZag\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\ZigZag\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagCifrar cifrado = new ZigZagCifrar(niveles, texto);
            string txtcifrado = cifrado.Cifrado();
            txtcifrado = txtcifrado.Replace("┼", "");
            List<char> bytecompress = new List<char>();


            root = root + @"\\Upload\\ZigZag\\cifrado.ZigZag";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
        }
        public static void Descifrado(string path, string root, int niveles)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\ZigZag\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\ZigZag\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagDescifrar descifrado = new ZigZagDescifrar(niveles, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado = txtdescifrado.Replace("┼", "");
            root = root + @"\\Upload\\ZigZag\\descifradoZigZag.txt";
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
