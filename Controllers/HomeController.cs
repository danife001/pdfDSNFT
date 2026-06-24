using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdfDSNFT.Data;
using pdfDSNFT.Models;
using pdfDSNFT.Services;
using System.Diagnostics;

namespace pdfDSNFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly PdfService _pdfService;
        private readonly IWebHostEnvironment _env;
        public HomeController(AppDbContext context, ILogger<HomeController> logger, PdfService pdfService, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _pdfService = pdfService;
            _env = env;
        }
      
        public IActionResult Historial(int page = 1)
        {
            int pageSize = 10;

            var query = _context.Documentos
                .OrderByDescending(d => d.Id);

            var totalRegistros = query.Count();

            var documentos = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalRegistros / (double)pageSize);

            return View(documentos);
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var doc = _context.Documentos.Find(id);

            if (doc == null)
            {
                return NotFound();
            }

            return View(doc);
        }

        [HttpPost]
        public IActionResult Formulario(DocumentoModel doc)
        {
            if (ModelState.IsValid)
            {
                if (doc.ValidacionInicial==true)
                {

                    GuardarPdf($"{doc.Codigo} VM INICIAL- Notificación Servicio Conforme Norma SALCON.pdf", _pdfService.GenerarPdf, doc);

                    var PdfAproVM = doc.Clonar();
                    _context.Documentos.Add(PdfAproVM);
                    _context.SaveChanges();


                    GuardarPdf($"{doc.Codigo} Aprobación verificación metodológica NSCL AVMNSC.pdf", _pdfService.GenerarPdfVM, doc);
                    var PdfVM = doc.Clonar();
                    _context.Documentos.Add(PdfVM);
                    _context.SaveChanges();

                   
                }
                if (doc.PostValidacion==true)
                {
                    GuardarPdf($"{doc.Codigo} Aprobación verificación metodológica post validacion NSCL AVMNSC.pdf", _pdfService.GenerarPdfAproPos, doc);

                    var PdfAproPos = doc.Clonar();
                    _context.Documentos.Add(PdfAproPos);
                    _context.SaveChanges();


                    GuardarPdf($"{doc.Codigo} VM POST- VALIDACIÓN – NOTI FICACIÓN SALIDA CONFORME.pdf", _pdfService.GenerarPdfVMPos, doc);
                    var PdfVMPos = doc.Clonar();
                    _context.Documentos.Add(PdfVMPos);
                    _context.SaveChanges();
                }    
                return RedirectToAction("Historial");

            }

            return View(doc);
        }

        // metodo para crear el Pdf
        private IActionResult GuardarPdf(string nombreArchivo, Func<DocumentoModel, byte[]> generadorPdf, DocumentoModel doc)
        {
            var pdfBytes = generadorPdf(doc);


            var rutaCarpeta = Path.Combine(_env.WebRootPath, "pdfs");
            var rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            System.IO.File.WriteAllBytes(rutaArchivo, pdfBytes);

            doc.NombreArchivoPdf = nombreArchivo;


            return File(pdfBytes, "application/pdf", nombreArchivo);
        }

        [HttpPost]
        public IActionResult Editar(DocumentoModel doc)
        {
            if (!ModelState.IsValid)
            {
                return View(doc);
            }

            _context.Documentos.Update(doc);
            _context.SaveChanges();

            return RedirectToAction("Historial");
        }

        public IActionResult Eliminar(int id)
        {
            var doc = _context.Documentos.Find(id);

            if (doc != null)
            {
                // Ruta del PDF
                var rutaArchivo = Path.Combine(
                    _env.WebRootPath,
                    "pdfs",
                    doc.NombreArchivoPdf
                );

                // Verifica si existe y lo elimina
                if (System.IO.File.Exists(rutaArchivo))
                {
                    System.IO.File.Delete(rutaArchivo);
                }

                _context.Documentos.Remove(doc);
                _context.SaveChanges();
            }

            return RedirectToAction("Historial");
        }
        public IActionResult Resultado(DocumentoModel doc)
        {
            return View(doc);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
