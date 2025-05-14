using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OgrenciAjaxProjesi.Models
{
    public class OkulDbContext : DbContext
    {
        public OkulDbContext(DbContextOptions<OkulDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}
