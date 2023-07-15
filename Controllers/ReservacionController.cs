using DreamyReefs.Data;
using DreamyReefs.Models;
using DreamyReefs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using ZXing;
using ZXing.Common;

namespace DreamyReefs.Controllers
{
    public class ReservacionController : Controller
    {
        private readonly Conexion _conexion;

        public ReservacionController(Conexion con)
        {
            _conexion = con;
        }

        public IActionResult Index()
        {
            var reservaciones = _conexion.GetAllReservaciones().ToList();
            return View(reservaciones);
        }

        [HttpPost]
        public IActionResult Buscar(string busqueda)
        {
            var reservaciones = _conexion.SearchReservaciones(busqueda); // Modificar SearchTour para devolver los resultados

            return View("Index", reservaciones); // Pasar los resultados de la búsqueda a la vista Index
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var reservacion = _conexion.GetOneReservaciones(id);
            return View(reservacion);
        }

        [HttpPost]
        public IActionResult Actualizar(Reservacion reservacion)
        {
            if (ModelState.IsValid && reservacion.IDReservaciones > 0 && reservacion.NombreCompleto is not null && reservacion.Telefono is not null && reservacion.Email is not null && reservacion.Adultos > 0 && reservacion.Infantes > 0 && reservacion.Estatus is not null && reservacion.TourID > 0)
            {
                _conexion.ActualizarReservaciones(reservacion.IDReservaciones, reservacion.NombreCompleto, reservacion.Telefono, reservacion.Email, reservacion.Adultos, reservacion.Infantes, reservacion.Estatus, reservacion.TourID);
                if (reservacion.Estatus == "Concluido")
                {
                    PagoPDF(reservacion.IDReservaciones);
                }
                TempData["SuccessMessage"] = "Reservacion actualizada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (id > 0)
            {
                _conexion.EliminarReservaciones(id);
                return Ok(); // Devuelve una respuesta exitosa al AJAX
            }

            return BadRequest(); // Otra respuesta de error si el id no es válido
        }

        public IActionResult EliminarArchivosEnCarpeta()
        {
            // string carpeta = "C:\\Users\\Usuario\\Desktop\\Tareas\\Word\\9°B\\Desarrollo web integral\\DreamyReefs\\PDFs\\";
            string carpeta = Directory.GetCurrentDirectory() + "\\PDFs\\"; // Especifica la ruta de la carpeta que deseas limpiar

            string[] archivos = Directory.GetFiles(carpeta);

            foreach (string archivo in archivos)
            {
                System.IO.File.Delete(archivo);
            }

            return RedirectToAction("Index"); // Redirecciona a la acción "Index" u otra acción deseada
        }

        public IActionResult PagoPDF(int ID)
        {
            ViewModelReservacion? modelo = _conexion.Reservaciones.Where(v => v.IDReservaciones == ID)
                .Select(v => new ViewModelReservacion()
                {
                    IDReservacionUsuario = ID,
                    NombrePersona = v.NombreCompleto,
                    TelefonoPersona = v.Telefono,
                    EmailPersona = v.Email,
                    AdultosPersona = v.Adultos,
                    InfantesPersona = v.Infantes,
                    TourIDPersona = v.TourID
                }).FirstOrDefault();

            var tours = _conexion.GetOneTour(modelo.TourIDPersona);

            modelo.NombreTour = tours.Nombre;
            modelo.DescripcionTour = tours.Descripcion;
            modelo.ItinerarioTour = tours.Itinerario;
            modelo.Horario = tours.Disponibilidad;
            modelo.IdiomaTour = tours.Idioma;

            var imagen = _conexion.BuscarImagen(modelo.TourIDPersona);

            modelo.imagenTour = imagen;

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

            var pdf = new ViewAsPdf("PagoPDF", modelo)
            {
                FileName = "Comprobante de Reservacion.pdf",
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
            message.Subject = "Comprobante de Reservacion - " + modelo.NombrePersona;
            message.To.Add(new MailAddress(modelo.EmailPersona));
            message.CC.Add("Brandonavila218@gmail.com");

            // Crear el contenido HTML del mensaje
            string htmlBody = "<div style='text-align: center;'>"; // Inicia el contenedor central
            htmlBody += "<p>Gracias por realizar su pago. Adjuntamos el comprobante de reservacion.</p>";

            htmlBody += "<p>Quedamos a sus órdenes para cualquier consulta o aclaración, no dude en contactarnos.</p>";

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
    }
}
