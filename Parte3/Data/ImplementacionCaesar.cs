﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab05
{
    public class ImplementationCaesar
    {                                                                  
        public static void Cifrado(string path, string root, string palabra)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Caesar\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Caesar\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Caesar cifrado = new Caesar(palabra, texto);
            string txtcifrado = cifrado.Cifrado();
            txtcifrado = txtcifrado.Replace("┼", "");
            root = root + @"\\Upload\\Caesar\\cifrado.Caesar";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
        }

        public static void Descifrado(string path, string root, string palabra)
        {
            string directorio;
            directorio = root + @"\\Upload\\";
            if (!Directory.Exists(directorio + "\\Caesar\\"))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio + "\\Caesar\\");
            }
            string texto = System.IO.File.ReadAllText(@path);
            Caesar descifrado = new Caesar(palabra, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado = txtdescifrado.Replace("┼", "");
            txtdescifrado = txtdescifrado.Replace("↔", "");
            root = root + @"\\Upload\\Caesar\\descifradoCaesar.txt";
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
