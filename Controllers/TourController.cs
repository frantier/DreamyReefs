﻿using DreamyReefs.Data;
using DreamyReefs.Models;
using DreamyReefs.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Diagnostics;
using DreamyReefs.Controllers;
using System.Net;
using System.Net.Mail;
using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace DreamyReefs.Controllers
{
    public class TourController : Controller
    {

        private readonly Conexion _conexion;

        public TourController(Conexion con)
        {
            _conexion = con;
        }

        #region User

        public IActionResult Index2()
        {
            var tours = _conexion.GetAllTours().ToList();
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View(tours);
        }

        [HttpPost]
        public IActionResult Horario2(string horario)
        {
            var tours = _conexion.SearchHorario(horario); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horarios = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horarios;

            return View("Index2", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        [HttpPost]
        public IActionResult Caracteristica2(string caracteristica)
        {
            var tours = _conexion.SearchCaracteristica(caracteristica); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View("Index2", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        [HttpPost]
        public IActionResult Categoria2(string categoria)
        {
            var tours = _conexion.SearchCategoria(categoria); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View("Index2", tours); // Pasar los resultados de la búsqueda a la vista Index
        }


        public IActionResult Detalle(int id)
        {
            var tours = _conexion.GetOneTour(id);

            #region //Datos de categorias y caracteristicas
            // Obtener el nombre de la categoría basado en el ID

            var imagenID = tours.IDTours;
            int categoria1Int = int.Parse(tours.Categoria1);
            int categoria2Int = int.Parse(tours.Categoria2);
            int categoria3Int = int.Parse(tours.Categoria3);
            int categoria4Int = int.Parse(tours.Categoria4);
            int Caracteristica1Int = int.Parse(tours.Caracteristica1);
            int Caracteristica2Int = int.Parse(tours.Caracteristica2);
            int Caracteristica3Int = int.Parse(tours.Caracteristica3);

            //Buscamos el nombre
            var img = _conexion.GetOneImagenesTour(imagenID);
            var categoria1 = _conexion.GetOneCategoria(categoria1Int);
            var categoria2 = _conexion.GetOneCategoria(categoria2Int);
            var categoria3 = _conexion.GetOneCategoria(categoria3Int);
            var categoria4 = _conexion.GetOneCategoria(categoria4Int);
            var Caracteristica1 = _conexion.GetOneCaracteristicas(Caracteristica1Int);
            var Caracteristica2 = _conexion.GetOneCaracteristicas(Caracteristica2Int);
            var Caracteristica3 = _conexion.GetOneCaracteristicas(Caracteristica3Int);

            // Asignar el nombre de la categoría al ViewBag
            ViewBag.img = img.ImagenBase64;
            ViewBag.categoria1 = categoria1.NombreCategoria;
            ViewBag.categoria2 = categoria2.NombreCategoria;
            ViewBag.categoria3 = categoria3.NombreCategoria;
            ViewBag.categoria4 = categoria4.NombreCategoria;
            ViewBag.Caracteristica1 = Caracteristica1.NombreCaracteristica;
            ViewBag.Caracteristica2 = Caracteristica2.NombreCaracteristica;
            ViewBag.Caracteristica3 = Caracteristica3.NombreCaracteristica;

            #endregion 

            return View(tours);
        }

        public IActionResult CrearPDF(int ID, string NombreCompleto, string Telefono, string Email, int Adultos, int Ninos)
        {

            ViewModelTour? modelo = _conexion.Tours.Where(v => v.IDTours == ID)
                .Select(v => new ViewModelTour()
                {
                    IDTourReservado = ID,
                    NombreTour = v.Nombre,
                    ItinerarioTour = v.Itinerario,
                    Horario = v.Disponibilidad,
                    IdiomaTour = v.Idioma,
                    PrecioTour = v.Precio,
                    AdultoPrecio = v.PrecioAdulto,
                    InfantePrecio = v.PrecioInfantes,
                    NombrePersona = NombreCompleto,
                    TelefonoPersona = Telefono,
                    EmailPersona = Email,
                    AdultosPersona = Adultos,
                    InfantesPersona = Ninos
                }).FirstOrDefault();

            modelo.CalcularTotales();

            Reservacion reservacion = new Reservacion
            {
                NombreCompleto = NombreCompleto,
                Telefono = Telefono,
                Email = Email,
                Adultos = Adultos,
                Infantes = Ninos,
                Estatus = "Pendiente",
                TourID = ID// Asigna un valor adecuado para el estatus de la reservación
            };

            CrearReservacion(reservacion);

            TourGrafica tourGrafica = new TourGrafica
            {
                NombreCliente = NombreCompleto,
                NombreTour = modelo.NombreTour,
                TotalVTA = modelo.PrecioTour,
                Estatus = reservacion.Estatus
            };

            CrearTourGraficaDash(tourGrafica);

            string qrCodeData = "https://wa.me/524495168427"; // URL especial de WhatsApp
            string rutaImagenQR = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\" + "Temporal.png";



            // Configuración del código QR
            var qrWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 150,
                    Height = 150,
                    Margin = 0
                }
            };

            // Generar los datos del código QR
            var pixelData = qrWriter.Write(qrCodeData);
            var bitmap = new Bitmap(pixelData.Width, pixelData.Height);

            // Guardar los datos del código QR en una imagen
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                pixelData.Pixels.Length);
            bitmap.UnlockBits(bitmapData);

            // Guardar la imagen del código QR en el archivo especificado
            bitmap.Save(rutaImagenQR, ImageFormat.Png);

            modelo.RutaImagenQR = rutaImagenQR;

            var pdf = new ViewAsPdf("CrearPDF", modelo)
            {
                FileName = "Comprobante de Pre-Reservacion_" + modelo.IDTourReservado + ".pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };

            var pdfContent = pdf.BuildFile(ControllerContext).Result;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", pdf.FileName);
            System.IO.File.WriteAllBytes(filePath, pdfContent);

            string fromMail = "dreamyreefscompany@gmail.com";
            string fromPassword = "dhaxqnvqbtncrmtx";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Pre-Reservacion - " + modelo.NombreTour;
            message.To.Add(new MailAddress(modelo.EmailPersona));
            message.CC.Add("Brandonavila218@gmail.com");

            // Crear el contenido HTML del mensaje
            string htmlBody = "<div style='text-align: center;'>"; // Inicia el contenedor central
            htmlBody += "<p>Para finalizar su reservacion, favor de realizar el pago correspondiente.</p>";

            htmlBody += "<p>Los datos para realizar el deposito o transferencia electrónica se encuentran en el PDF adjunto.</p>";

            htmlBody += "<p style='text-align: center;'>Atte: Javier Alejandro Ruvalcaba Novelo.</p>";

            htmlBody += "<table style='margin: 0 auto;'>";
            htmlBody += "<tr><td style='text-align: center;'><img src='https://i.ibb.co/y6zZ2W3/Logo.png' alt='Comprobante de Reservacion' width='150'></td></tr>";
            htmlBody += "</table>";

            htmlBody += "</div>"; // Cierra el contenedor central

            // Asignar el contenido HTML al cuerpo del mensaje
            message.IsBodyHtml = true;
            message.Body = htmlBody;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            message.Attachments.Add(new Attachment(filePath));

            smtpClient.Send(message);

            System.IO.File.Delete(rutaImagenQR);
            //HttpContext.Session.SetString("FilePath", filePath);

            return RedirectToAction("Index2");
        }

        [HttpPost]
        public IActionResult CrearReservacion(Reservacion reservacion)
        {
            if (ModelState.IsValid && reservacion.NombreCompleto is not null && reservacion.Telefono is not null && reservacion.Email is not null && reservacion.Adultos > 0 && reservacion.Infantes > 0 && reservacion.Estatus is not null && reservacion.TourID > 0)
            {
                _conexion.CrearReservaciones(reservacion.NombreCompleto, reservacion.Telefono, reservacion.Email, reservacion.Adultos, reservacion.Infantes, reservacion.Estatus, reservacion.TourID);
                return RedirectToAction("Home", "Index");
            }
            TempData["SuccessMessage"] = "Reservacion creada exitosamente.";
            return View();
        }

        [HttpPost]
        public IActionResult CrearTourGraficaDash(TourGrafica tourGrafica)
        {
            if (ModelState.IsValid && tourGrafica.NombreCliente is not null && tourGrafica.NombreTour is not null && tourGrafica.TotalVTA > 0 && tourGrafica.Estatus is not null)
            {
                _conexion.CrearTourGrafica(tourGrafica.NombreCliente, tourGrafica.NombreTour, tourGrafica.TotalVTA, tourGrafica.Estatus);
                return RedirectToAction("Home", "Index");
            }
            return View();
        }

        public IActionResult CrearOpinion(int IDTour, string Comentario)
        {
            Review review = new Review
            {
                TourID = IDTour,
                Comentario = Comentario
            };

            CrearReview(review);
            return View();
        }

        [HttpPost]
        public IActionResult CrearReview(Review review)
        {
            if (ModelState.IsValid && review.TourID > 0 && review.Comentario is not null)
            {
                _conexion.CrearReviews(review.TourID, review.Comentario);
                TempData["SuccessMessage"] = "Opinion enviada exitosamente.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index2");
        }

        #endregion

        #region Dashboard

        public IActionResult Index()
        {
            var storedToken = HttpContext.Session.GetString("Token");
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
                var tours = _conexion.GetAllTours().ToList();
                ViewBag.Imagen = new Dictionary<int, string>();

                foreach (var tour in tours)
                {
                    var imagenID = tour.IDTours;
                    var img = _conexion.GetOneImagenesTour(imagenID);
                    ViewBag.Imagen[imagenID] = img.ImagenBase64;
                }

                var categorias = _conexion.GetAllCategorias();
                var caracteristicas = _conexion.GetAllCaracteristicas();
                var horario = _conexion.GetAllDisponible();

                ViewBag.Categorias = categorias;
                ViewBag.Caracteristicas = caracteristicas;
                ViewBag.Horario = horario;

                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public IActionResult Buscar(string busqueda)
        {
            var tours = _conexion.SearchTour(busqueda); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View("Index", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        [HttpPost]
        public IActionResult Horario(string horario)
        {
            var tours = _conexion.SearchHorario(horario); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horarios = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horarios;

            return View("Index", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        [HttpPost]
        public IActionResult Caracteristica(string caracteristica)
        {
            var tours = _conexion.SearchCaracteristica(caracteristica); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View("Index", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        [HttpPost]
        public IActionResult Categoria(string categoria)
        {
            var tours = _conexion.SearchCategoria(categoria); // Modificar SearchTour para devolver los resultados
            ViewBag.Imagen = new Dictionary<int, string>();

            foreach (var tour in tours)
            {
                var imagenID = tour.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.Imagen[imagenID] = img.ImagenBase64;
            }

            var categorias = _conexion.GetAllCategorias();
            var caracteristicas = _conexion.GetAllCaracteristicas();
            var horario = _conexion.GetAllDisponible();

            ViewBag.Categorias = categorias;
            ViewBag.Caracteristicas = caracteristicas;
            ViewBag.Horario = horario;

            return View("Index", tours); // Pasar los resultados de la búsqueda a la vista Index
        }

        public IActionResult Crear()
        {
            var storedToken = HttpContext.Session.GetString("Token");
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
                var categorias = _conexion.GetAllCategorias();
                var caracteristicas = _conexion.GetAllCaracteristicas();

                ViewBag.Categorias = categorias;
                ViewBag.Caracteristicas = caracteristicas;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult Crear(Tours tours, Imagen imagen, IFormFile ImagenBase64)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                int nuevotour = _conexion.CrearTour(tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
                imagen.TourID = nuevotour;
                CrearImagen(imagen, ImagenBase64);
                TempData["SuccessMessage"] = "Tour creado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CrearImagen(Imagen imagen, IFormFile ImagenBase64)
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
            var storedToken = HttpContext.Session.GetString("Token");
            var model = new DashboardViewModel
            {
                Token = storedToken
            };
            if (model.Token != null && model.Token == storedToken)
            {
                var categorias = _conexion.GetAllCategorias();
                var caracteristicas = _conexion.GetAllCaracteristicas();

                ViewBag.Categorias = categorias;
                ViewBag.Caracteristicas = caracteristicas;

                var tours = _conexion.GetOneTour(id);
                
                var imagenID = tours.IDTours;
                var img = _conexion.GetOneImagenesTour(imagenID);
                ViewBag.img = img.ImagenBase64;

                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public IActionResult Actualizar(Tours tours, Imagen imagen, IFormFile ImagenBase64)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                int nuevaimagen = _conexion.ActualizarTour(tours.IDTours, tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
                imagen.IDImagenes = nuevaimagen;
                imagen.TourID = tours.IDTours;
                ActualizarImagen(imagen, ImagenBase64);
                TempData["SuccessMessage"] = "Tour actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ActualizarImagen(Imagen imagen, IFormFile ImagenBase64)
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
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (id > 0)
            {
                _conexion.EliminarTour(id);
                return Ok(); // Devuelve una respuesta exitosa al AJAX
            }

            return BadRequest(); // Otra respuesta de error si el id no es válido
        }

        #endregion
    }
}
