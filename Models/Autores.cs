// Models/Autor.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaCSF.Models
{
    public class Autores
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
