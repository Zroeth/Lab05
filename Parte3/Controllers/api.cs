﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab05
{
    [ApiController]
    [Route("[controller]")]
    public class Api : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public static string llaveOriginal;
        public Api(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        public class FileUploadAPI
        {
            public IFormFile files { get; set; }

        }


        [HttpPost("cipher/zigzag")]
        public IActionResult PostCipherZZ([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                    string s = @_environment.WebRootPath;
                    ImplementationZigZag.Cifrado(fileStream.Name, s, objFile.carriles);


                    return File( @"\Upload\ZigZag\cifrado.ZigZag", "text/JSON");

                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }

        [HttpPost("decipher/zigzag")]
        public IActionResult PostDecipherZZ([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                    string s = @_environment.WebRootPath;

                    ImplementationZigZag.Descifrado(fileStream.Name, s, objFile.carriles);


                    return File(@"\Upload\ZigZag\descifradoZigZag.txt", "text/JSON");

                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }

        [HttpPost("cipher/caesar")]
        public IActionResult PostCipherCaeser([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();

                    string s = @_environment.WebRootPath;
                    ImplementationCaesar.Cifrado(fileStream.Name, s, objFile.llave);
                    llaveOriginal = objFile.llave;

                    return File(@"\\Upload\\Caesar\\cifrado.Caesar", "text/JSON");
                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }

        [HttpPost("decipher/caesar")]
        public IActionResult PostDecipherCaesar([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {

                    if (objFile.llave == llaveOriginal)
                    {


                        if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                        {
                            Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                        }
                        using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        ImplementationCaesar.Descifrado(fileStream.Name, s, objFile.llave);

                        return File(@"\\Upload\\Caesar\\descifradoCaesar.txt", "text/JSON");
                    }
                    else
                    {
                        return StatusCode(500, new { name = "User Error", message = "Llave incorrecta, la llave empezaba por: " + llaveOriginal.Substring(0, 1) + ", y es de tamaño:" + llaveOriginal.Length }); ;
                    }

                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }

        [HttpPost("cipher/ruta")]
        public IActionResult PostCipherRuta([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                    string s = @_environment.WebRootPath;
                    ImplementationRuta.Cifrado(fileStream.Name, s, objFile.tamaño);

                    return File(@"\\Upload\\Ruta\\cifrado.Ruta", "text/JSON");


                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }

        [HttpPost("decipher/ruta")]
        public IActionResult  PostDecipherRuta([FromForm] ManejarArchivo objFile)
        {

            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName);
                    objFile.files.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                    string s = @_environment.WebRootPath;

                    ImplementationRuta.Descifrado(fileStream.Name, s, objFile.tamaño);


                    return File(@"\\Upload\\Ruta\\descifradoRuta.txt", "text/JSON");



                }
                else
                {
                    return StatusCode(500, new { name = "Internal Server Error", message = "Error" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = e.Message });
            }



        }



    }
}
