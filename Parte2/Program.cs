using System;
using System.Collections.Generic;
using System.IO;
using Lab05;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribir texto: ");
            string texto = Console.ReadLine();
            Console.Write("Escribir llave: ");
            string llave = Console.ReadLine();
            Console.Write("Escribir Tamaño: ");
            int tamaño =Convert.ToInt32( Console.ReadLine());

            Caesar cifradoC = new Caesar(llave, texto);
            string txtcifradoC = cifradoC.Cifrado();
            txtcifradoC = txtcifradoC.Replace("┼", "");
            string raiz = @"..\\..\\..\\cifrado.Caesar";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifradoC)
                {
                    outputFile.Write(caracter.ToString());
                }

            }

            Ruta cifradoR = new Ruta(texto, tamaño );
            string txtcifradoR = cifradoR.Cifrado();
            txtcifradoR = txtcifradoR.Replace("┼", "");
            raiz = @"..\\..\\..\\cifrado.Ruta";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifradoR)
                {
                    outputFile.Write(caracter.ToString());
                }

            }

            ZigZagCifrar cifradoZ = new ZigZagCifrar(texto.Length, texto);
            string txtcifradoZ = cifradoZ.Cifrado();
            txtcifradoZ = txtcifradoZ.Replace("┼", "");


            raiz = @"..\\..\\..\\cifrado.ZigZag";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifradoZ)
                {
                    outputFile.Write(caracter.ToString());
                }
            }






            Console.WriteLine("Archivos creados y cifrados!, revisar carpeta");


            bool correcto = false;
            while(!correcto)
            {
                Console.WriteLine("Escribir llave para descifrar: ");
                string llaveDes = Console.ReadLine();
                if (llaveDes==llave)
                {
                    Caesar descifradoC = new Caesar(llave, txtcifradoC);
                    string txtdescifradoC = descifradoC.Descifrado();
                    txtdescifradoC = txtdescifradoC.Replace("┼", "");
                    txtdescifradoC = txtdescifradoC.Replace("↔", "");
                    raiz = @"..\\..\\..\\Caesar.txt";
                    using (StreamWriter outputFile = new StreamWriter(raiz))
                    {
                        foreach (char caracter in txtdescifradoC)
                        {
                            outputFile.Write(caracter.ToString());
                        }
                    }
                    correcto = true;

                }
                else
                {
                    Console.WriteLine("Llave incorrecta, la llave empezaba por: "+llave.Substring(0,1)+", y es de tamaño:"+llave.Length);
                }


            }


            Ruta descifradoR = new Ruta(txtcifradoR, tamaño);
            string txtdescifradoR = descifradoR.Descifrado();
            txtdescifradoR = txtdescifradoR.Replace("┼", "");
            raiz = @"..\\..\\..\\Ruta.txt";
            txtdescifradoR = txtdescifradoR.Replace("↔", "");
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtdescifradoR)
                {
                    outputFile.Write(caracter.ToString());
                }
            }

            

            ZigZagDescifrar descifrado = new ZigZagDescifrar(texto.Length, txtcifradoZ);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado = txtdescifrado.Replace("┼", "");
            raiz = @"..\\..\\..\\ZigZag.txt";
            txtdescifrado = txtdescifrado.Replace("↔", "");
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtdescifrado)
                {
                    outputFile.Write(caracter.ToString());

                }
            }




          



            Console.WriteLine("Archivos creados y descifrados!, revisar carpeta");






        }
    }
}
