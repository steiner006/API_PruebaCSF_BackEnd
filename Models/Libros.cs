using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaCSF.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AnioPublicacion { get; set; }
        public string Autores { get; set; }
    }
}

