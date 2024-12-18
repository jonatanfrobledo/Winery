﻿using System.ComponentModel.DataAnnotations;

namespace Winery.Entities
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del invitado es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        public int CataId { get; set; }
        public Cata Cata { get; set; }
    }
}