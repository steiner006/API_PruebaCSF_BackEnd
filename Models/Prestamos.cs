// Models/Prestamo.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCSF.Models
{
    public class Prestamos
    {
        [Key]
        public int Id { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        [ForeignKey("LibroId")]
        public Libros Libro { get; set; }
    }
}
