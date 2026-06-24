using System.ComponentModel.DataAnnotations;

namespace pdfDSNFT.Models
{
    public class DocumentoModel
    {
        public int Id { get; set; }
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "El título es obligatorio")]
        public int Version { get; set; }
        [Required(ErrorMessage = "La version es obligatoria")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La Mesa Sectorial es obligatoria")]
        public string MesaSectorial { get; set; }
        [Required(ErrorMessage = "La Fecha es obligatoria")]
        public DateTime? Fecha { get; set; }
        public Boolean ValidacionInicial { get; set; }
        public DateTime? FechaValidacionInicial { get; set; }
        public Boolean PostValidacion { get; set; }
        public DateTime? FechaPostValidacion { get; set; }

        public string? NombreArchivoPdf { get; set; }

        //Metodo para copiar un objeto
        public DocumentoModel Clonar()
        {
            return (DocumentoModel)this.MemberwiseClone();
        }
    }


}