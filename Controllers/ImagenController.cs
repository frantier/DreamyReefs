using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DreamyReefs.Data;
using DreamyReefs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DreamyReefs.Controllers
{
    public class ImagenController : Controller
    {
        private readonly Conexion _conexion;

        public ImagenController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var imagenes = _conexion.GetAllImagenes().ToList();
            ViewBag.Tours = new Dictionary<int, string>();

            foreach (var imagen in imagenes)
            {
                var tourID = imagen.TourID;
                var tour = _conexion.GetOneTour(tourID);
                ViewBag.Tours[tourID] = tour.Nombre;
            }

            return View(imagenes);
        }


        public IActionResult Crear()
        {
            var tours = _conexion.GetAllTours();

            ViewBag.Tours = tours;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Imagen imagen, IFormFile ImagenBase64)
        {
            if (ModelState.IsValid && ImagenBase64 != null && imagen.TourID > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    ImagenBase64.CopyTo(memoryStream);
                    byte[] bytes = memoryStream.ToArray();
                    string base64String = Convert.ToBase64String(bytes);
                    imagen.ImagenBase64 = base64String;
                }

                _conexion.CrearImagenes(imagen.ImagenBase64, imagen.TourID);
                TempData["SuccessMessage"] = "Imagen agregada exitosamente.";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Actualizar(int id)
        {
            var tours = _conexion.GetAllTours();

            ViewBag.Tours = tours;
            var imagenes = _conexion.GetOneImagenes(id);
            return View(imagenes);
        }

        [HttpPost]
        public IActionResult Actualizar(Imagen imagen, IFormFile ImagenBase64)
        {
            if (ModelState.IsValid && imagen.IDImagenes > 0 && ImagenBase64 is not null && imagen.TourID > 0)
            {
                // Obtener la imagen original de la base de datos
                var imagenOriginal = _conexion.GetOneImagenes(imagen.IDImagenes);

                if (imagenOriginal != null)
                {
                    // Actualizar los datos de la imagen original con los valores del modelo recibido
                    using (var memoryStream = new MemoryStream())
                    {
                        ImagenBase64.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        string base64String = Convert.ToBase64String(bytes);
                        imagen.ImagenBase64 = base64String;
                    }

                    // Guardar los cambios en la base de datos
                    _conexion.ActualizarImagenes(imagen.IDImagenes, imagen.ImagenBase64, imagen.TourID);
                    TempData["SuccessMessage"] = "Imagen actualizada exitosamente.";

                    return RedirectToAction("Index");
                }
                else
                {
                    // La imagen original no existe, mostrar un mensaje de error o realizar alguna acción apropiada
                    ModelState.AddModelError("", "La imagen no se encontró en la base de datos.");
                }
            }

            // Si el modelo no es válido o la actualización no fue exitosa, volver a la vista de actualización
            var tours = _conexion.GetAllTours();
            ViewBag.Tours = tours;
            return View();
        }


        //public IActionResult Eliminar(int id)
        //{
        //    var tours = _conexion.GetAllTours();

        //    ViewBag.Tours = tours;
        //    var imagenes = _conexion.GetOneImagenes(id);
        //    return View(imagenes);
        //}


        //[HttpPost]
        //public IActionResult Eliminar(Imagen imagen)
        //{
        //    if (imagen.IDImagenes > 0)
        //    {
        //        _conexion.EliminarImagenes(imagen.IDImagenes);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (id > 0)
            {
                _conexion.EliminarImagenes(id);
                return Ok(); // Devuelve una respuesta exitosa al AJAX
            }

            return BadRequest(); // Otra respuesta de error si el id no es válido
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}