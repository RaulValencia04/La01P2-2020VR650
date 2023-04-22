using System;
using System.ComponentModel.DataAnnotations;

namespace L01PO2_2020VR650.Models
{
	public class Usuario
	{
        [Key]
        public int usuarioId { get; set; }

        public int rolId { get; set; }

        public String? nombreUsuario { get; set; }
        public String? clave { get; set; }

        public String? nombre { get; set; }

        public String? apellido { get; set; }

    }
}

