using File.Validator.Domain.Entities.DocumentEntity;
using File.Validator.Domain.Entities.DocumentLogEntity;
using Microsoft.EntityFrameworkCore;

namespace File.Validator.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<DocumentLog> DocumentsLog { get; set; }

}
