﻿using System;
using System.ComponentModel.DataAnnotations;

namespace L01PO2_2020VR650.Models
{
	public class Comentarios
	{
		[Key]
		public int cometarioId { get; set; }
		public int publicacionId { get; set; }
		public string? comentario { get; set; }
		public int usuarioId { get; set; }



    }
}

