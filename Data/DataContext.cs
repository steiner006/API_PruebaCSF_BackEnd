using Microsoft.EntityFrameworkCore;
using PruebaCSF.Models;
using System.Collections.Generic;

namespace PruebaCSF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Autores> Autores { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
    }
}