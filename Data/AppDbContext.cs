using Microsoft.EntityFrameworkCore;
using pdfDSNFT.Models;

namespace pdfDSNFT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<DocumentoModel> Documentos { get; set; }
    }
}