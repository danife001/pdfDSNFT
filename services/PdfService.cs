using pdfDSNFT.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;

namespace pdfDSNFT.Services
{
    public class PdfService
    {
        public byte[] GenerarPdf(DocumentoModel doc)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.MarginVertical(0.98f, Unit.Inch);
                    page.MarginHorizontal(1.18f, Unit.Inch);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().PaddingTop(20).Text("Profesional vinculado a la estandarización/normalización de competencias,")
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("Cordial saludo,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).LineHeight(1.4f).FontFamily("Aptos"));

                            text.Span("Le informamos que el producto de normalización con código ");
                            text.Span(doc.Codigo.ToString()).Bold();

                            text.Span(" versión ");
                            text.Span(doc.Version.ToString());

                            text.Span(" título ");
                            text.Span(doc.Titulo).Bold();

                            text.Span(" asociado a la Mesa Sectorial ");
                            text.Span(doc.MesaSectorial).Bold();

                            text.Span(" ha cumplido con la Fase de Verificación Metodológica Inicial y obtuvo ");

                            text.Span("SALIDA CONFORME.").Bold();
                        });

                        column.Item().Text(
                            "Lo invitamos a continuar con las actividades correspondientes, para dar continuidad a la gestión del producto y así avanzar en la ejecución del Proyecto Anual de Estandarización/Normalización – PAE 2025.")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .LineHeight(1.4f);

                        column.Item().Text($"{doc.FechaValidacionInicial:dd/MM/yyyy HH:mm:ss}")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .FontColor(Colors.Grey.Darken1);

                        column.Item().Text("Atentamente,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().PaddingTop(20).PaddingBottom(0).Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).FontFamily("Aptos"));

                            text.Line("SISTEMA DE INFORMACIÓN DSNFT").Bold();
                            text.Line("Grupo de Gestión Competencias Laborales");
                            text.Line("Dirección Sistema Nacional de Formación para el Trabajo");
                            text.Line("Calle 57 # 8 - 69, Torre Central – Piso 6, Bogotá, Colombia");
                            text.Line("Tel.: +57 (1) 5461500 Ext. 13518");
                        });

                        column.Item().Text("sistemasdsnft@sena.edu.co")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("WWW.SENA.EDU.CO")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .Bold()
                            .FontFamily("Aptos")
                            .FontSize(12);
                    });
                });
            }).GeneratePdf();

            return pdf;
        }

        public byte[] GenerarPdfVM(DocumentoModel doc)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.MarginVertical(0.98f, Unit.Inch);
                    page.MarginHorizontal(1.18f, Unit.Inch);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().PaddingTop(20).Text("Estimado colaborador del proceso de Instancias de Concertación")
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("Cordial saludo,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).LineHeight(1.4f).FontFamily("Aptos"));

                            text.Span("Le informamos que para la Norma Sectorial de Competencia Laboral NSCL con  código ");
                            text.Span(doc.Codigo.ToString()).Bold();

                            text.Span(" versión ");
                            text.Span(doc.Version.ToString());

                            text.Span(" título ");
                            text.Span(doc.Titulo).Bold();

                            text.Span(" asociado a la Mesa Sectorial ");
                            text.Span(doc.MesaSectorial).Bold();

                            text.Span(" fue aprobada la ");

                            text.Span("Verificación Metodológica.").Bold();
                        });

                        column.Item().Text(
                            "Lo invitamos a ingresar al sistema de información a realizar la gestión correspondiente.")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .LineHeight(1.4f);

                        column.Item().Text($"{doc.FechaValidacionInicial:dd/MM/yyyy HH:mm:ss}")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .FontColor(Colors.Grey.Darken1);

                        column.Item().Text("Atentamente,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().PaddingTop(20).PaddingBottom(0).Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).FontFamily("Aptos"));

                            text.Line("SISTEMA DE INFORMACIÓN DSNFT").Bold();
                            text.Line("Grupo de Gestión Competencias Laborales");
                            text.Line("Dirección Sistema Nacional de Formación para el Trabajo");
                            text.Line("Calle 57 # 8 - 69, Torre Central – Piso 6, Bogotá, Colombia");
                            text.Line("Tel.: +57 (1) 5461500 Ext. 13518");
                        });

                        column.Item().Text("sistemasdsnft@sena.edu.co")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("WWW.SENA.EDU.CO")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .Bold()
                            .FontFamily("Aptos")
                            .FontSize(12);
                    });
                });
            }).GeneratePdf();

            return pdf;
        }

        public byte[] GenerarPdfAproPos(DocumentoModel doc)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.MarginVertical(0.98f, Unit.Inch);
                    page.MarginHorizontal(1.18f, Unit.Inch);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().PaddingTop(20).Text("Estimado colaborador del proceso de Instancias de Concertación")
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("Cordial saludo,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).LineHeight(1.4f).FontFamily("Aptos"));

                            text.Span("Le informamos que para la Norma Sectorial de Competencia Laboral NSCL con  código ");
                            text.Span(doc.Codigo.ToString()).Bold();

                            text.Span(" versión ");
                            text.Span(doc.Version.ToString());

                            text.Span(" título ");
                            text.Span(doc.Titulo).Bold();

                            text.Span(" asociado a la Mesa Sectorial ");
                            text.Span(doc.MesaSectorial).Bold();

                            text.Span(" fue aprobada la ");

                            text.Span("Verificación Metodológica - Pos Validación Técnica.").Bold();
                        });

                        column.Item().Text(
                            "Lo invitamos a ingresar al sistema de información a realizar la gestión correspondiente.")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .LineHeight(1.4f);

                        column.Item().Text($"{doc.FechaValidacionInicial:dd/MM/yyyy HH:mm:ss}")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .FontColor(Colors.Grey.Darken1);

                        column.Item().Text("Atentamente,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().PaddingTop(20).PaddingBottom(0).Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).FontFamily("Aptos"));

                            text.Line("SISTEMA DE INFORMACIÓN DSNFT").Bold();
                            text.Line("Grupo de Gestión Competencias Laborales");
                            text.Line("Dirección Sistema Nacional de Formación para el Trabajo");
                            text.Line("Calle 57 # 8 - 69, Torre Central – Piso 6, Bogotá, Colombia");
                            text.Line("Tel.: +57 (1) 5461500 Ext. 13518");
                        });

                        column.Item().Text("sistemasdsnft@sena.edu.co")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("WWW.SENA.EDU.CO")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .Bold()
                            .FontFamily("Aptos")
                            .FontSize(12);
                    });
                });
            }).GeneratePdf();

            return pdf;
        }

        public byte[] GenerarPdfVMPos(DocumentoModel doc)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var pdf = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.MarginVertical(0.98f, Unit.Inch);
                    page.MarginHorizontal(1.18f, Unit.Inch);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().PaddingTop(20).Text("Profesional vinculado a la estandarización/normalización de competencias,")
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("Cordial saludo,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).LineHeight(1.4f).FontFamily("Aptos"));

                            text.Span("Le informamos que para la Norma Sectorial de Competencia Laboral NSCL con código");
                            text.Span(doc.Codigo.ToString()).Bold();

                            text.Span(" versión ");
                            text.Span(doc.Version.ToString());

                            text.Span(" título ");
                            text.Span(doc.Titulo).Bold();

                            text.Span(", asociado a la Mesa Sectorial ");
                            text.Span(doc.MesaSectorial).Bold();

                            text.Span(" ha cumplido con la fase de Verificación Metodológica Post-Validación y obtuvo ");

                            text.Span("SALIDA CONFORME.").Bold();
                        });

                        column.Item().Text(
                            "Lo invitamos a continuar con las actividades correspondientes, para dar continuidad a la gestión del producto y así avanzar en la ejecución del Proyecto Anual de Estandarización/Normalización – PAE 2025.")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .LineHeight(1.4f);

                        column.Item().Text($"{doc.FechaValidacionInicial:dd/MM/yyyy HH:mm:ss}")
                        .FontFamily("Aptos")
                            .FontSize(12)
                            .FontColor(Colors.Grey.Darken1);

                        column.Item().Text("Atentamente,")
                        .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().PaddingTop(20).PaddingBottom(0).Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(12).FontFamily("Aptos"));

                            text.Line("SISTEMA DE INFORMACIÓN DSNFT").Bold();
                            text.Line("Grupo de Gestión Competencias Laborales");
                            text.Line("Dirección Sistema Nacional de Formación para el Trabajo");
                            text.Line("Calle 57 # 8 - 69, Torre Central – Piso 6, Bogotá, Colombia");
                            text.Line("Tel.: +57 (1) 5461500 Ext. 13518");
                        });

                        column.Item().Text("sistemasdsnft@sena.edu.co")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .FontFamily("Aptos")
                            .FontSize(12);

                        column.Item().Text("WWW.SENA.EDU.CO")
                            .FontColor(Colors.Blue.Medium)
                            .Underline()
                            .Bold()
                            .FontFamily("Aptos")
                            .FontSize(12);
                    });
                });
            }).GeneratePdf();

            return pdf;
        }
    }
}