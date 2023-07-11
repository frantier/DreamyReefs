using DreamyReefs.Data;
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

namespace DreamyReefs.Controllers
{
    public class TourController : Controller
    {

        private readonly Conexion _conexion;

        public TourController(Conexion con)
        {
            _conexion = con;
        }

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

            return View(tours);
        }

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
                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

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
        public IActionResult Crear(Tours tours)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                _conexion.CrearTour(tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
                TempData["SuccessMessage"] = "Tour creado exitosamente.";
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
                return View(tours);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public IActionResult Actualizar(Tours tours)
        {
            if (ModelState.IsValid && tours.Nombre is not null && tours.Itinerario is not null && tours.Precio > 0 && tours.Descripcion is not null && tours.Disponibilidad is not null && tours.Idioma is not null && tours.Categoria1 is not null && tours.Categoria2 is not null && tours.Categoria3 is not null && tours.Categoria4 is not null && tours.Caracteristica1 is not null && tours.Caracteristica2 is not null && tours.Caracteristica3 is not null && tours.Estatus is not null && tours.PrecioAdulto > 0 && tours.PrecioInfantes > 0)
            {
                _conexion.ActualizarTour(tours.IDTours, tours.Nombre, tours.Itinerario, tours.Precio, tours.Descripcion, tours.Disponibilidad, tours.Idioma, tours.Categoria1, tours.Categoria2, tours.Categoria3, tours.Categoria4, tours.Caracteristica1, tours.Caracteristica2, tours.Caracteristica3, tours.Estatus, tours.PrecioAdulto, tours.PrecioInfantes);
                TempData["SuccessMessage"] = "Tour actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Eliminar(int id)
        //{
        //    var storedToken = HttpContext.Session.GetString("Token");
        //    var model = new DashboardViewModel
        //    {
        //        Token = storedToken
        //    };
        //    if (model.Token != null && model.Token == storedToken)
        //    {
        //        var categorias = _conexion.GetAllCategorias();
        //        var caracteristicas = _conexion.GetAllCaracteristicas();

        //        ViewBag.Categorias = categorias;
        //        ViewBag.Caracteristicas = caracteristicas;
        //        var tours = _conexion.GetOneTour(id);
        //        return View(tours);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Login");
        //    }

        //}


        //[HttpPost]
        //public IActionResult Eliminar(Tours tours)
        //{
        //    if (tours.IDTours > 0)
        //    {
        //        _conexion.EliminarTour(tours.IDTours);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

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
                Estatus = "Pendiente" // Asigna un valor adecuado para el estatus de la reservación
            };

            CrearReservacion(reservacion);

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
                FileName = "Comprobante de Pre-Reservacion_"+modelo.IDTourReservado+".pdf",
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
            message.Body = "Para terminar su reservacion, favor de hacer el pago correspondiente. Los datos para realizar dicho pago se encuentran en el PDF Adjuntado.";

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
            if (ModelState.IsValid && reservacion.NombreCompleto is not null && reservacion.Telefono is not null && reservacion.Email is not null && reservacion.Adultos > 0 && reservacion.Infantes > 0 && reservacion.Estatus is not null)
            {
                _conexion.CrearReservaciones(reservacion.NombreCompleto, reservacion.Telefono, reservacion.Email, reservacion.Adultos, reservacion.Infantes, reservacion.Estatus);
                TempData["SuccessMessage"] = "Reservacion creada exitosamente.";
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

        //public void GenerarCodigoQR()
        //{
        //    string qrCodeData = "https://wa.me/524495168427"; // URL especial de WhatsApp

        //    // Configuración del código QR
        //    var qrWriter = new BarcodeWriterPixelData
        //    {
        //        Format = BarcodeFormat.QR_CODE,
        //        Options = new EncodingOptions
        //        {
        //            Width = 150,
        //            Height = 150,
        //            Margin = 0
        //        }
        //    };

        //    // Generar los datos del código QR
        //    var pixelData = qrWriter.Write(qrCodeData);
        //    var bitmap = new Bitmap(pixelData.Width, pixelData.Height);

        //    // Guardar los datos del código QR en una imagen
        //    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
        //        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        //    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
        //        pixelData.Pixels.Length);
        //    bitmap.UnlockBits(bitmapData);

        //    // Guardar la imagen del código QR en el archivo especificado
        //    bitmap.Save("C:\\Users\\Usuario\\Desktop\\Tareas\\Word\\9°B\\Desarrollo web integral\\DreamyReefs\\wwwroot\\images\\Temporal.png", ImageFormat.Png);

        //}
    }
}
